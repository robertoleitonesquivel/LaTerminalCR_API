using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaAPI.Services;
using System.Net;

namespace PruebaTecnicaAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CitiesController : ControllerBase
	{
		private readonly ICitiesService _citiesService;

		public CitiesController(ICitiesService citiesService)
		{
			_citiesService = citiesService;
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			try
			{
				var cities = await _citiesService.GetCitiesAsync();

				if (cities is null || cities.Count == 0)
				{
					return NotFound("No se encontraron ciudades.");
				}

				return Ok(cities);
			}
			catch (Exception ex)
			{

				return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
			}
		}
	}
}
