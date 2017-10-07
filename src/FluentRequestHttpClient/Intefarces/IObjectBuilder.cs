using System;
using System.Collections.Generic;
using FluentRequestHttpClient.Enuns;
using FluentRequestHttpClient.Parameters;

namespace FluentRequestHttpClient.Intefarces
{
	public interface IObjectBuilder<TResponse, TRequest> : ISingleObjectBuilder<TResponse, TRequest>
	{
		ISingleObjectBuilder<TResponse, TRequest> Authenticate(string user, string password);

	    ISingleObjectBuilder<TResponse, TRequest> WithHeader(string key, string value);

        ISingleObjectBuilder<TResponse, TRequest> AddUri(string uri);

	    ISingleObjectBuilder<TResponse, TRequest> AddRota(string rota);

        ISingleObjectBuilder<TResponse, TRequest> WithTimeout(int timeout);

		ISingleObjectBuilder<TResponse, TRequest> SetVerb(HttpVerb verb);

		ISingleObjectBuilder<TResponse, TRequest> WithArguments(IDictionary<string, string> arguments);

        ISingleObjectBuilder<TResponse, TRequest> WithArguments(object arguments);

        ISingleObjectBuilder<TResponse, TRequest> WithArguments(Action<ParameterQueryString> arguments);

        ISingleObjectBuilder<TResponse, TRequest> PostAsync();
        
	}
}