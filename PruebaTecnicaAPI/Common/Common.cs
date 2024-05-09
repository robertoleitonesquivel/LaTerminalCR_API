
using System.Net.Http.Headers;
using System.Text;

namespace PruebaTecnicaAPI.Common
{
	public class Common : ICommon
	{

		private readonly IHttpClientFactory _httpClientFactory;
		private readonly IConfiguration _configuration;

		public Common(IHttpClientFactory httpClientFactory, IConfiguration configuration)
		{
			_httpClientFactory = httpClientFactory;
			_configuration = configuration;
		}

		public async Task<HttpResponseMessage> ExecuteHttpRequestAsync(HttpMethod httpMethod, string endpoint,  string body = null)
		{
			try
			{
				string baseurl = _configuration.GetValue<string>(Constants.BaseUrl);
				string username = _configuration.GetValue<string>(Constants.UserName);
				string password = _configuration.GetValue<string>(Constants.Password);
				string url = $"{baseurl}{endpoint}";

				var httpClient = _httpClientFactory.CreateClient();
				var encodedCredentials = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}"));
				httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
				httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", encodedCredentials);


				HttpResponseMessage httpResponseMessage = null;

				if (httpMethod == HttpMethod.Get)
				{
					httpResponseMessage = await httpClient.GetAsync(url);
				}

				if (httpMethod == HttpMethod.Post)
				{
					var contenido = new StringContent(body, Encoding.UTF8, "application/json");

					httpResponseMessage = await httpClient.PostAsync(url, contenido);
				}

				if (httpResponseMessage is null)
				{
					throw new Exception("Lo sentimos no se ha logrado realizar la solicitud ya que no se ha proporcionado el verbo HTTP.");
				}

				if (!httpResponseMessage.IsSuccessStatusCode)
				{
					var response = await httpResponseMessage.Content.ReadAsStringAsync();
					throw new Exception($"Lo sentimos ha ocurrido un error, detalle: {response}");
				}

				return httpResponseMessage;
			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
