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
    [Route("api/regions")]
    public class RegionController : ControllerBase
    {
        private readonly IRegionService _regionService;

        public RegionController(IRegionService regionService)
        {
            _regionService = regionService;
        }

        [HttpGet, AllowAnonymous]
        public async Task<CustomResponse<IEnumerable<RegionResponseDto>>> GetAll()
        {
            return new CustomResponse<IEnumerable<RegionResponseDto>>((int)HttpStatusCode.OK, await _regionService.GetAllAsync());
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<IActionResult> Single(int id)
        {
            try
            {
                var region = await _regionService.SingleAsync(id);
                var response = new CustomResponse<Region>((int)HttpStatusCode.OK, region);
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
        public async Task<IActionResult> Create(RegionCreateDto dto)
        {
            try
            {
                await _regionService.CreateAsync(RegionCreateDto.ToEntity(dto));
                var response = new CustomResponse<RegionCreateDto>((int)HttpStatusCode.OK, dto);
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
        public async Task<IActionResult> Update(RegionUpdateDto dto)
        {
            try
            {
                await _regionService.UpdateAsync(RegionUpdateDto.ToEntity(dto));
                var response = new CustomResponse<RegionUpdateDto>((int)HttpStatusCode.OK, dto);
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