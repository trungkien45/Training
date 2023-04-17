using Training.API.Settings;
using Training.Common.Exceptions;
using Training.Contracts.Dto;
using Training.Contracts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NuGet.Protocol.Plugins;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace Training.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class AuthenticationController : ControllerBase
    {
        private IAccountService accountService;
        private ILogger<AccountController> logger;
        private readonly IConfiguration configuration;


        public AuthenticationController(IAccountService accountService, ILogger<AccountController> logger, IConfiguration configuration)
        {
            this.accountService = accountService;
            this.logger = logger;
            this.configuration = configuration;
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public LoginResponse Login([FromBody] LoginRequest request)
        {
            AccountDto account = accountService.CheckLogin(request.Username, request.Password);
            if (account == null)
            {
                throw new HttpResponseException((int)HttpStatusCode.Unauthorized);
            }
            // tạo access token
            var accessToken = GenerateAccessToken(account);

            // tạo refresh token
            var refreshToken = GenerateRefreshToken();

            return new LoginResponse { AccessToken = accessToken, RefreshToken = refreshToken };
        }

        private string GenerateAccessToken(AccountDto user)
        {
            var jwtSettings = configuration.GetSection("JwtSettings").Get<JwtSettings>();

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username)
            };

            SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey));
            var token = new JwtSecurityToken(
                issuer: jwtSettings.Issuer,
                audience: jwtSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(100),
                signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        private string GenerateRefreshToken()
        {
            return Guid.NewGuid().ToString();
        }

    }
}
