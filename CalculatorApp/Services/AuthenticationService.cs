using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

// This file contains the implementation of authentication services used in the CalculatorApp API. 
// It includes functionality for generating JWT tokens and validating user credentials. 
// These services are critical for managing secure access to API endpoints.

namespace CalculatorApp.Services
{
	public interface IAuthenticationService
	{
		string GenerateJwtToken(string username);
		bool ValidateUser(string username, string password);
	}

	public class AuthenticationService : IAuthenticationService
	{
		private readonly IConfiguration _configuration;

		public AuthenticationService(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public string GenerateJwtToken(string username)
		{
			var claims = new[]
			{
		new Claim(ClaimTypes.Name, username)
	};

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsASecretKey12345!"));

			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken(
				issuer: "DummyIssuer", 
				audience: "DummyAudience",
				claims: claims,
				expires: DateTime.Now.AddMinutes(60),
				signingCredentials: creds
			);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}


		public bool ValidateUser(string username, string password)
		{
			return username == "admin" && password == "password";
		}
	}
}
