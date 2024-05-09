using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaAPI.Models;
using PruebaTecnicaAPI.Services;

namespace PruebaTecnicaAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TicketsController : ControllerBase
	{
		private readonly ITicketsService _ticketsService;

		public TicketsController(ITicketsService ticketsService)
		{
			_ticketsService = ticketsService;
		}

		[HttpGet("GetTickets")]
		public async Task<IActionResult> GetTickets([FromQuery] TicketParam ticketParam)
		{
			try
			{
				var response = await _ticketsService.GetTicketFiltersAsync(ticketParam);

				if (response is null || response.Count == 0)
				{
					return NotFound("No se encontraron vuelos disponibles.");
				}

				return Ok(response);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
			}
		}


		[HttpGet("GetDetailTicket")]
		public async Task<IActionResult> GetDetailTicket([FromQuery] TicketDetailParam ticketDetailParam)
		{
			try
			{
				var response = await _ticketsService.GetTicketDetailAsync(ticketDetailParam);

				if (response is null)
				{
					return NotFound("No se obtuvo el detalle del vuelo.");
				}

				return Ok(response);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
			}
		}
	}
}
