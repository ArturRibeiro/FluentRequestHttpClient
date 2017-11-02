using System;
using System.Collections.Generic;
using FluentRequestHttpClient.Enuns;
using FluentRequestHttpClient.Parameters;

namespace FluentRequestHttpClient.Intefarces
{
	public interface IObjectBuilder : ISingleObjectBuilder
	{
		ISingleObjectBuilder Authenticate(string user, string password);

	    ISingleObjectBuilder WithHeader(string key, string value);

        ISingleObjectBuilder AddUri(string uri);

	    ISingleObjectBuilder AddRota(string rota);

        ISingleObjectBuilder WithTimeout(int timeout);

		ISingleObjectBuilder SetVerb(HttpVerb verb);

		ISingleObjectBuilder WithArguments(IDictionary<string, string> arguments);

        ISingleObjectBuilder WithArguments(object arguments);

        ISingleObjectBuilder WithArguments(Action<ParameterQueryString> arguments);

        ISingleObjectBuilder PostAsync();
        
	}
}