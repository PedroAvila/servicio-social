using System.Net;
using Microsoft.AspNetCore.Mvc;
using ServicioSocial.Services;

namespace ServicioSocial.Api.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<CustomResponse<IEnumerable<UserResponseDto>>> GetAll()
        {
            return new CustomResponse<IEnumerable<UserResponseDto>>((int)HttpStatusCode.OK, await _userService.GetAllAsync());
        }
    }
}