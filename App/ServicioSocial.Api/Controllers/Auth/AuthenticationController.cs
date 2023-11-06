using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ServicioSocial.Entities;
using ServicioSocial.Operations;
using ServicioSocial.Services;

namespace ServicioSocial.Api.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IKeyEncryptor _keyEncryptor;
        private readonly IUserService _userService;

        public AuthenticationController(
            IUserService userService,
            IConfiguration configuration,
            IKeyEncryptor keyEncryptor
            )
        {
            _keyEncryptor = keyEncryptor;
            _configuration = configuration;
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Create(UserCreateDto dto)
        {
            try
            {
                var entity = await _userService.CreateAsync(UserCreateDto.ToEntity(dto));
                var response = new CustomResponse<UserCreateResponse>((int)HttpStatusCode.OK, entity);
                return Ok(response);
            }
            catch (BusinessException e)
            {
                return StatusCode(e.Status, new CustomResponse<string>(e.Status, e.Mensaje!));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto dto)
        {
            var validation = await IsValidUser(dto);
            if (validation.Item1)
            {
                var token = GenerateToken(validation.Item2);
                var response = new CustomResponse<string>
                {
                    Status = (int)HttpStatusCode.OK,
                    Data = token
                };
                return Ok(response);
            }
            return StatusCode((int)HttpStatusCode.Unauthorized, new CustomResponse<string>((int)HttpStatusCode.Unauthorized, "User no Autorizado"));
        }

        private async Task<(bool, User)> IsValidUser(UserLoginDto dto)
        {
            var user = await _userService.LoginByCredentialAsync(dto);
            var validate = _keyEncryptor.ValidatePasword(user.Password!, dto.Password!);
            return (validate, user);
        }

        private string GenerateToken(User user)
        {
            //Header
            var symetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]));
            var signingCredentials = new SigningCredentials(symetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);

            //Claims
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Name!),
                new Claim("User", user.Email!),
                new Claim(ClaimTypes.Role, user.RoleId.ToString())
            };

            //Payload
            var payload = new JwtPayload
            (
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claims,
                DateTime.Now,
                DateTime.UtcNow.AddMinutes(10)
            );

            var token = new JwtSecurityToken(header, payload);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}