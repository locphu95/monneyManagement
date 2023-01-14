using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Core
{
    public class Auth : IAuth
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private User? _user;
        protected readonly ILoggerManager _logger;

        public Auth(UserManager<User> userManager, IConfiguration configuration, IMapper mapper, ILoggerManager logger)
        {
            _userManager = userManager;
            _configuration = configuration;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<IdentityResult> RegisterUserAsync(UserRegistrationRequest userRegistration)
        {
            IdentityResult? identityResult = new IdentityResult();
            try
            {
                var user = new User
                {
                    UserName = userRegistration.UserName,
                    Email = userRegistration.Email,
                    PhoneNumber = userRegistration.PhoneNumber,
                    ChannelId = userRegistration.Channel
                };
                if (user == null)
                {

                }
                var userExists = await _userManager.FindByNameAsync(userRegistration.UserName);
                if (userExists != null)
                    return identityResult;

                identityResult = await _userManager.CreateAsync(user, userRegistration.Password);
                if (!identityResult.Succeeded)
                {
                    return identityResult;
                }
                return identityResult;
            }
            catch (Exception ex)
            {
                _logger.LogDebug($"Error: >>{ex}");
                return identityResult;
            }

        }

        public async Task<User> ValidateUserAsync(LoginRequest loginDto)
        {
            _user = await _userManager.FindByNameAsync(loginDto.UserName);
            var result = _user != null && await _userManager.CheckPasswordAsync(_user, loginDto.Password);
#pragma warning disable CS8603 // Possible null reference return.
            return _user;
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<LoginResponse> CreateTokenAsync(User user)
        {

            try
            {
                var jwtSettings = _configuration.GetSection("JwtConfig");
                var signingCredentials = GetSigningCredentials();
                var claims = await GetClaims();
                var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
                string token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                string? refreshToken = user.RefreshToken;
                if (!string.IsNullOrEmpty(user.RefreshToken) || user.RefreshTokenExpiryTime <= DateTime.Now) { }
                {
                    _ = int.TryParse(jwtSettings["refreshTokenValidityInDays"], out int refreshTokenValidityInDays);
                    refreshToken = user.RefreshToken = GenerateRefreshToken();
                    user.RefreshTokenExpiryTime = DateTime.Now.AddDays(refreshTokenValidityInDays);
                }

                await _userManager.UpdateAsync(user);
                return new LoginResponse(requestID: user.Id, channelId: "")
                {
                    Token = token,
                    RefreshToken = refreshToken,
                    Expiration = 10,
                };
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex.Message);
                return null;
            }
        }

        private SigningCredentials GetSigningCredentials()
        {
            var jwtConfig = _configuration.GetSection("jwtConfig");
            var key = Encoding.UTF8.GetBytes(jwtConfig["Secret"]);
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private async Task<List<Claim>> GetClaims()
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, _user.UserName)
        };
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            var roles = await _userManager.GetRolesAsync(_user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JwtConfig");

            var tokenOptions = new JwtSecurityToken
            (
            issuer: jwtSettings["validIssuer"],
            audience: jwtSettings["validAudience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expiresIn"])),
            signingCredentials: signingCredentials
            );
            return tokenOptions;
        }
        
        private static string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        public async Task<RefreshResponse> RefreshToken(RefreshRequest refreshRequest)
        {
            try
            {
                string? accessToken = refreshRequest.AccessToken;
                string? refreshToken = refreshRequest.RefreshToken;

                ClaimsPrincipal? principal = GetPrincipalFromExpiredToken(accessToken);
                if (principal == null)
                {
                    return new RefreshResponse("a", "a")
                    {
                        Message = "Invalid access token or refresh token",
                        Status = "400"
                    };
                }
                string? username = principal?.Identity?.Name;

                _user = await _userManager.FindByNameAsync(username);

                if (_user == null || _user.RefreshToken != refreshToken || _user.RefreshTokenExpiryTime <= DateTime.Now)
                {
                    return new RefreshResponse("a", "a")
                    {
                        Message = "Invalid access token or refresh token",
                        Status = "400"
                    };
                }
                LoginResponse? newAccessToken = await CreateTokenAsync(_user);

                return new RefreshResponse("a", "a")
                {
                    Status = "200",
                    AccessToken = newAccessToken.Token,
                    RefreshToken = newAccessToken.RefreshToken,
                };
            }
            catch (Exception ex)
            {
                return new RefreshResponse("a", "a")
                {
                    Status = "500",
                };
            }
        }
        
        private ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token)
        {
            var jwtConfig = _configuration.GetSection("jwtConfig");
            var key = Encoding.UTF8.GetBytes(jwtConfig["Secret"]);
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateLifetime = false
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
            if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");
            return principal;
        }

        public async Task<RevokeResponse> Revoke(RevokeResquest resquest)
        {
            RevokeResponse response = new RevokeResponse(resquest?.RequestId, resquest?.Channel);
            try
            {
                _user = await _userManager.FindByNameAsync(resquest?.UserName);

                if (_user == null)
                {
                    response.Status = "404"; response.ResCode = "00";
                }
                _user.RefreshToken = null;
                await _userManager.UpdateAsync(_user);

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex.ToString());
                response.ResCode = "05";
                response.Message = "05";
                response.Status = "505";
                return response;
            }


        }

        public Task<RevokeResponse> RevokeAll()
        {
            throw new NotImplementedException();
        }
    }
}