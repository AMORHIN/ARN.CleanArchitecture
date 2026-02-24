using ARN.Pedidos.Application.DTOS.JwtDTO;
using ARN.Pedidos.Application.Interfaces.External.JwtToken;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ARN.Pedidos.Infrastructure.External.TokenJwt
{
    internal class TokenJwtService : ITokenJwtService
    {

        private readonly IConfiguration _configuration;
        private const int SaltSize = 16;
        private const int KeySize = 32;

        private HashingOptions Optinons { get; }

        public TokenJwtService(IConfiguration configuration)
        {
            _configuration = configuration;
            Optinons = new HashingOptions();
        }

        public string GeradorTOken(UserPasswordDTO user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            string jwt = _configuration["SecretKeyJwt"] ?? string.Empty;
            var signiKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt));

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Usuario?? string.Empty),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString(), ClaimValueTypes.Integer64),

                new Claim("UserId", user.UsuarioId.ToString() ?? string.Empty),
                new Claim("Usuario", user.Usuario ?? string.Empty),
                new Claim("Rol", user.Rol ?? string.Empty),
                new Claim("Correo", user.Correo ?? string.Empty),
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(signiKey, SecurityAlgorithms.HmacSha256Signature),
                Issuer = _configuration["IsserJwt"],
                Audience = _configuration["AudienceJwt"]
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }

        public (bool Verified, bool NeedsUpgrade) Check(string hash, string password)
        {
            try
            {
                var parts = hash.Split('.', 3);
                if (parts.Length != 3)
                {
                    return (false, false);
                    throw new FormatException("formato de hast es incorrexto");
                }

                var iterations = Convert.ToInt32(parts[0]);
                var salt = Convert.FromBase64String(parts[1]);
                var key = Convert.FromBase64String(parts[2]);

                var needsUpgrade = iterations != Optinons.Iterations;

                using (var algoritthm = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA512))
                {
                    var keyToCheck = algoritthm.GetBytes(KeySize);
                    var verified = keyToCheck.SequenceEqual(key);

                    return (verified, needsUpgrade);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public string Hash(string password)
        {
            using (var algorithm = new Rfc2898DeriveBytes(password, SaltSize, Optinons.Iterations, HashAlgorithmName.SHA512))
            {
                var key = Convert.ToBase64String(algorithm.GetBytes(KeySize));
                var salt = Convert.ToBase64String(algorithm.Salt);
                return $"{Optinons.Iterations}.{salt}.{key}";
            }
        }

        public sealed class HashingOptions
        {
            public int Iterations { get; set; } = 10000;
        }
    }
}
