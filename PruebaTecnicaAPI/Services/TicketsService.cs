using PruebaTecnicaAPI.Common;
using PruebaTecnicaAPI.Models;
using System.Text.Json;

namespace PruebaTecnicaAPI.Services
{
	public class TicketsService : ITicketsService
	{
		private readonly ICommon _common;

		public TicketsService(ICommon common)
		{
			_common = common;
		}

		public async Task<List<TicketDetail>> GetTicketDetailAsync(TicketDetailParam ticketDetailParam)
		{
			string body = JsonSerializer.Serialize(ticketDetailParam);
			var response = await _common.ExecuteHttpRequestAsync(HttpMethod.Post, "new/seats", body);
			return JsonSerializer.Deserialize<List<TicketDetail>>(await response.Content.ReadAsStringAsync());
		}

		public async Task<List<TicketFilter>> GetTicketFiltersAsync(TicketParam ticketParam)
		{
			string body = JsonSerializer.Serialize(ticketParam);
			var response = await _common.ExecuteHttpRequestAsync(HttpMethod.Post, "new/search", body);
			return JsonSerializer.Deserialize<List<TicketFilter>>(await response.Content.ReadAsStringAsync());
		}
	}
}
