using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServicioSocial.Entities;
using ServicioSocial.Operations;
using ServicioSocial.Services;
using ServicioSocial.Services.Dtos;

namespace ServicioSocial.Api.Controllers
{
    [Authorize(Roles = "Administrator")]
    [ApiController]
    [Route("api/countrys")]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet, AllowAnonymous]
        public async Task<CustomResponse<IEnumerable<CountryResponseDto>>> GetAll()
        {
            return new CustomResponse<IEnumerable<CountryResponseDto>>((int)HttpStatusCode.OK, await _countryService.GetAllAsync());
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<IActionResult> Single(int id)
        {
            try
            {
                var usuario = await _countryService.SingleAsync(id);
                var response = new CustomResponse<Country>((int)HttpStatusCode.OK, usuario);
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
        public async Task<IActionResult> Create(CountryCreateDto dto)
        {
            try
            {
                await _countryService.CreateAsync(CountryCreateDto.ToEntity(dto));
                var response = new CustomResponse<CountryCreateDto>((int)HttpStatusCode.OK, dto);
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
        public async Task<IActionResult> Update(CountryUpdateDto dto)
        {
            try
            {
                await _countryService.UpdateAsync(CountryUpdateDto.ToEntity(dto));
                var response = new CustomResponse<CountryUpdateDto>((int)HttpStatusCode.OK, dto);
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