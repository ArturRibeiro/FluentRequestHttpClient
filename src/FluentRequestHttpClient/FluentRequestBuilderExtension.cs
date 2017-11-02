using System.Collections.Generic;
using FluentRequestHttpClient.Enuns;
using FluentRequestHttpClient.Intefarces;
using System;
using FluentRequestHttpClient.Parameters;

namespace FluentRequestHttpClient
{
    public static class FluentRequestBuilderExtension
    {
		public static ISingleObjectBuilder Authenticate(this ISingleObjectBuilder objectBuilder, string user, string password)
		{
			((IObjectBuilder)objectBuilder).Authenticate(user, password);
			return objectBuilder;
		}

	    public static ISingleObjectBuilder WithHeader(this ISingleObjectBuilder objectBuilder, string key, string value)
	    {
	        ((IObjectBuilder)objectBuilder).WithHeader(key, value);
	        return objectBuilder;
        }

        public static ISingleObjectBuilder AddUri(this ISingleObjectBuilder objectBuilder, string uri)
		{
			((IObjectBuilder)objectBuilder).AddUri(uri);
			return objectBuilder;
		}

        public static ISingleObjectBuilder AddRota(this ISingleObjectBuilder objectBuilder, string rota)
		{
			((IObjectBuilder)objectBuilder).AddRota(rota);
			return objectBuilder;
		}

		public static ISingleObjectBuilder WithTimeout(this ISingleObjectBuilder objectBuilder, int timeout)
		{
			((IObjectBuilder)objectBuilder).WithTimeout(timeout);
			return objectBuilder;
		}

		public static ISingleObjectBuilder SetVerb(this ISingleObjectBuilder objectBuilder, HttpVerb verb)
		{
			((IObjectBuilder)objectBuilder).SetVerb(verb);
			return objectBuilder;
		}

		public static ISingleObjectBuilder WithArguments(this ISingleObjectBuilder objectBuilder, IDictionary<string, string> arguments)
		{
			((IObjectBuilder)objectBuilder).WithArguments(arguments);
			return objectBuilder;
		}

        public static ISingleObjectBuilder WithArguments(this ISingleObjectBuilder objectBuilder, object arguments)
        {
            ((IObjectBuilder)objectBuilder).WithArguments(arguments);
            return objectBuilder;
        }

        public static ISingleObjectBuilder WithArguments(this ISingleObjectBuilder objectBuilder, Action<ParameterQueryString> arguments)
        {
            ((IObjectBuilder)objectBuilder).WithArguments(arguments);
            return objectBuilder;
        }
    }
}