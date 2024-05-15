using Newtonsoft.Json;
using PruebaTecnicaAPI.Common;
using PruebaTecnicaAPI.Models;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

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
			string body = JsonConvert.SerializeObject(ticketDetailParam);
			var response = await _common.ExecuteHttpRequestAsync(HttpMethod.Post, "new/seats", body);
			JsonSerializerOptions options = new JsonSerializerOptions();
			return JsonConvert.DeserializeObject<List<TicketDetail>>(await response.Content.ReadAsStringAsync());
			//return result.OrderBy(s => s.position.y).ThenBy(s => s.position.x).ToList();
		}

		public async Task<List<TicketFilter>> GetTicketFiltersAsync(TicketParam ticketParam)
		{
			string body = JsonConvert.SerializeObject(ticketParam);
			var response = await _common.ExecuteHttpRequestAsync(HttpMethod.Post, "new/search", body);
			var result = JsonConvert.DeserializeObject<List<TicketFilter>>(await response.Content.ReadAsStringAsync());

			foreach (var item in result)
			{
				item.orderDate = DateTime.ParseExact($"{item.departure.date} {item.departure.time}", "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
			}

			return result.OrderBy(x => x.orderDate).ToList();
		}

	}
}
