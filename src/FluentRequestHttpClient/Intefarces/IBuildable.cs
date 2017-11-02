using System;
using System.Net.Http;
using System.Threading.Tasks;
using FluentRequestHttpClient.Request;
using FluentRequestHttpClient.Response;

namespace FluentRequestHttpClient.Intefarces
{
	public interface IBuildable<TResponse, TRequest> :  IDisposable
	    //where TResponse : BaseResponseMessage, new()
        //where TRequest : BaseRequestMessage, new()
    {
        //BuilderSettings BuilderSettings { get; set; }
	    Task<TResponse> GetAsync();


        TResponse Build();
	}
}