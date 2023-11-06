using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServicioSocial.Entities;
using ServicioSocial.Operations;
using ServicioSocial.Services;

namespace ServicioSocial.Api.Controllers
{
    [Authorize(Roles = "Administrator")]
    [ApiController]
    [Route("api/communes")]
    public class CommuneController : ControllerBase
    {
        private readonly ICommuneService _communeService;

        public CommuneController(ICommuneService communeService)
        {
            _communeService = communeService;
        }

        [HttpGet, AllowAnonymous]
        public async Task<CustomResponse<IEnumerable<CommuneResponseDto>>> GetAll()
        {
            return new CustomResponse<IEnumerable<CommuneResponseDto>>((int)HttpStatusCode.OK, await _communeService.GetAllAsync());
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<IActionResult> Single(int id)
        {
            try
            {
                var commune = await _communeService.SingleAsync(id);
                var response = new CustomResponse<Commune>((int)HttpStatusCode.OK, commune);
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

        [HttpPost]
        public async Task<IActionResult> Create(CommuneCreateDto dto)
        {
            try
            {
                await _communeService.CreateAsync(CommuneCreateDto.ToEntity(dto));
                var response = new CustomResponse<CommuneCreateDto>((int)HttpStatusCode.OK, dto);
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

        [HttpPut()]
        public async Task<IActionResult> Update(CommuneUpdateDto dto)
        {
            try
            {
                await _communeService.UpdateAsync(CommuneUpdateDto.ToEntity(dto));
                var response = new CustomResponse<CommuneUpdateDto>((int)HttpStatusCode.OK, dto);
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
    }
}