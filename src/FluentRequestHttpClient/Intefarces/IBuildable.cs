using System;
using System.Net.Http;
using System.Threading.Tasks;
using FluentRequestHttpClient.Request;
using FluentRequestHttpClient.Response;

namespace FluentRequestHttpClient.Intefarces
{
	public interface IBuildable :  IDisposable
    {
        Task<TResponse> GetAsync<TRequest, TResponse>() 
            where TRequest : BaseRequestMessage 
            where TResponse : BaseResponseMessage, new();
    }
}