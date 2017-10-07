using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FluentRequestHttpClient.Intefarces
{
	public interface IBuildable<TResponse, TRequest> :  IDisposable
	{
        //BuilderSettings BuilderSettings { get; set; }
	    Task<HttpResponseMessage> BuildAsync();

	    TResponse Build();
	}
}