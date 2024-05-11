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
			string body = JsonSerializer.Serialize(ticketDetailParam);
			var response = await _common.ExecuteHttpRequestAsync(HttpMethod.Post, "new/seats", body);
			JsonSerializerOptions options = new JsonSerializerOptions();
			options.Converters.Add(new JsonStringEnumConverter());
			options.Converters.Add(new StringToIntConverter());
			var result = JsonSerializer.Deserialize<List<TicketDetail>>(await response.Content.ReadAsStringAsync(),options);
			return result.OrderBy(s => s.position.y)
							   .ThenBy(s => s.position.x).ToList();
		}

		public async Task<List<TicketFilter>> GetTicketFiltersAsync(TicketParam ticketParam)
		{
			string body = JsonSerializer.Serialize(ticketParam);
			var response = await _common.ExecuteHttpRequestAsync(HttpMethod.Post, "new/search", body);
			var result = JsonSerializer.Deserialize<List<TicketFilter>>(await response.Content.ReadAsStringAsync());

			foreach (var item in result)
			{
				item.orderDate = DateTime.ParseExact($"{item.departure.date} {item.departure.time}", "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
			}

			return result.OrderBy(x => x.orderDate).ToList();
		}

		public class StringToIntConverter : JsonConverter<int>
		{
			public override int Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
			{
				if (reader.TokenType == JsonTokenType.String && int.TryParse(reader.GetString(), out int intValue))
				{
					return intValue;
				}
				else if (reader.TokenType == JsonTokenType.Number)
				{
					return reader.GetInt32();
				}
				else
				{
					throw new JsonException($"Unexpected token type: {reader.TokenType}");
				}
			}

			public override void Write(Utf8JsonWriter writer, int value, JsonSerializerOptions options)
			{
				writer.WriteNumberValue(value);
			}
		}
	}
}
