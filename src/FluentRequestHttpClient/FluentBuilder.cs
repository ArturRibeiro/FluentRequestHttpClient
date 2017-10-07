using FluentRequestHttpClient.Intefarces;

namespace FluentRequestHttpClient
{

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TResponse">Remover TResponse, não precisa trafegar em todas as classes</typeparam>
    /// <typeparam name="TRequest"></typeparam>
	public static class FluentBuilder<TResponse, TRequest>
	{
		public static ISingleObjectBuilder<TResponse, TRequest> CreateNew()
		{
			return new FluentRequestBuilder<TResponse, TRequest>();
		}
	}
}