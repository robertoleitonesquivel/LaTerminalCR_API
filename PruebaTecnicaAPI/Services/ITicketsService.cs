using PruebaTecnicaAPI.Models;

namespace PruebaTecnicaAPI.Services
{
	public interface ITicketsService
	{
		Task<List<TicketFilter>> GetTicketFiltersAsync(TicketParam ticketParam);
		Task<List<TicketDetail>> GetTicketDetailAsync(TicketDetailParam ticketDetailParam);	
	}
}
