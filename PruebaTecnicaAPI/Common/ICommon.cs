namespace PruebaTecnicaAPI.Common
{
	public interface ICommon
	{
		Task<HttpResponseMessage> ExecuteHttpRequestAsync(HttpMethod httpMethod, string url, string body = null);
	}
}
