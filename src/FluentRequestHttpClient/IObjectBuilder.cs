using System;
using System.Collections.Generic;
using FluentHttpClient.Enuns;

namespace FluentHttpClient
{
	public interface IObjectBuilder<TResponse, TRequest> : ISingleObjectBuilder<TResponse, TRequest>
	{
		ISingleObjectBuilder<TResponse, TRequest> Authenticate(string user, string password);

	    ISingleObjectBuilder<TResponse, TRequest> WithHeader(string key, string value);

        ISingleObjectBuilder<TResponse, TRequest> AddUri(string uri);

		ISingleObjectBuilder<TResponse, TRequest> WithTimeout(int timeout);

		ISingleObjectBuilder<TResponse, TRequest> SetVerb(HttpVerb verb);

		ISingleObjectBuilder<TResponse, TRequest> WithArguments(IDictionary<string, string> parameters);
		
		ISingleObjectBuilder<TResponse, TRequest> PostAsync();
        
	}
}