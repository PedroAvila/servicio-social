using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServicioSocial.Services;

namespace ServicioSocial.Api.Controllers
{
    [Authorize(Roles = "Administrator")]
    [ApiController]
    [Route("api/socialServices")]
    public class SocialServiceController : ControllerBase
    {
        private readonly ISocialServiceService _socialServiceService;

        public SocialServiceController(ISocialServiceService socialServiceService)
        {
            _socialServiceService = socialServiceService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(SocialServiceCreateDto dto)
        {
            await _socialServiceService.CreateSocialServiceByCommuneAsync(dto);
            var response = new CustomResponse<SocialServiceCreateDto>((int)HttpStatusCode.OK, dto);
            return Ok(response);
        }
    }
}