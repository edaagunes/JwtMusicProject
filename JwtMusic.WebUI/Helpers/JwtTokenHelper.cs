using JwtMusic.EntityLayer.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JwtMusic.WebUI.Helpers
{
	public class JwtTokenHelper
	{
		private const string SecretKey = "JwtMusicProject+*010203JWTMUSIC01+*..020304JwtMusicProject";
		private readonly SigningCredentials _signingCredentials;
		private readonly TokenValidationParameters _tokenValidationParameters;

		public JwtTokenHelper()
		{
			var key = Encoding.ASCII.GetBytes(SecretKey);
			_signingCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);
			_tokenValidationParameters = new TokenValidationParameters
			{
				ValidateIssuer = false,
				ValidateAudience = false,
				ValidateLifetime = true,
				ValidateIssuerSigningKey = true,
				IssuerSigningKey = new SymmetricSecurityKey(key)
			};
		}

		public string GenerateToken(AppUser user)
		{
			var claims = new[]
			{
			new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
			new Claim(ClaimTypes.Name, user.UserName),
			new Claim("Package", user.PackageId.ToString()) // Kullanıcının paket bilgisi
        };

			var securityTokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(claims),
				Expires = DateTime.UtcNow.AddHours(1),
				SigningCredentials = _signingCredentials
			};

			var tokenHandler = new JwtSecurityTokenHandler();
			var token = tokenHandler.CreateToken(securityTokenDescriptor);
			return tokenHandler.WriteToken(token);
		}

		public async Task<int?> GetPackageIdFromTokenAsync(string token)
		{
			try
			{
				var tokenHandler = new JwtSecurityTokenHandler();
				var principal = tokenHandler.ValidateToken(token, _tokenValidationParameters, out var validatedToken);

				// Token'dan PackageId'yi al
				var packageClaim = principal?.FindFirst("Package");
				if (packageClaim != null)
				{
					return int.Parse(packageClaim.Value);
				}

				return null;
			}
			catch
			{
				return null;
			}
		}
	}
}
