using System.Collections.Generic;
using FluentRequestHttpClient.Enuns;
using FluentRequestHttpClient.Intefarces;
using System;
using FluentRequestHttpClient.Parameters;

namespace FluentRequestHttpClient
{
    public static class FluentRequestBuilderExtension
    {
		public static ISingleObjectBuilder<TResponse, TRequest> Authenticate<TResponse, TRequest>(this ISingleObjectBuilder<TResponse, TRequest> objectBuilder, string user, string password)
		{
			((IObjectBuilder<TResponse, TRequest>)objectBuilder).Authenticate(user, password);
			return objectBuilder;
		}

	    public static ISingleObjectBuilder<TResponse, TRequest> WithHeader<TResponse, TRequest>(this ISingleObjectBuilder<TResponse, TRequest> objectBuilder, string key, string value)
	    {
	        ((IObjectBuilder<TResponse, TRequest>)objectBuilder).WithHeader(key, value);
	        return objectBuilder;
        }

        public static ISingleObjectBuilder<TResponse, TRequest> AddUri<TResponse, TRequest>(this ISingleObjectBuilder<TResponse, TRequest> objectBuilder, string uri)
		{
			((IObjectBuilder<TResponse, TRequest>)objectBuilder).AddUri(uri);
			return objectBuilder;
		}

        public static ISingleObjectBuilder<TResponse, TRequest> AddRota<TResponse, TRequest>(this ISingleObjectBuilder<TResponse, TRequest> objectBuilder, string rota)
		{
			((IObjectBuilder<TResponse, TRequest>)objectBuilder).AddRota(rota);
			return objectBuilder;
		}

		public static ISingleObjectBuilder<TResponse, TRequest> WithTimeout<TResponse, TRequest>(this ISingleObjectBuilder<TResponse, TRequest> objectBuilder, int timeout)
		{
			((IObjectBuilder<TResponse, TRequest>)objectBuilder).WithTimeout(timeout);
			return objectBuilder;
		}

		public static ISingleObjectBuilder<TResponse, TRequest> SetVerb<TResponse, TRequest>(this ISingleObjectBuilder<TResponse, TRequest> objectBuilder, HttpVerb verb)
		{
			((IObjectBuilder<TResponse, TRequest>)objectBuilder).SetVerb(verb);
			return objectBuilder;
		}

		public static ISingleObjectBuilder<TResponse, TRequest> WithArguments<TResponse, TRequest>(this ISingleObjectBuilder<TResponse, TRequest> objectBuilder, IDictionary<string, string> arguments)
		{
			((IObjectBuilder<TResponse, TRequest>)objectBuilder).WithArguments(arguments);
			return objectBuilder;
		}

        public static ISingleObjectBuilder<TResponse, TRequest> WithArguments<TResponse, TRequest>(this ISingleObjectBuilder<TResponse, TRequest> objectBuilder, object arguments)
        {
            ((IObjectBuilder<TResponse, TRequest>)objectBuilder).WithArguments(arguments);
            return objectBuilder;
        }

        public static ISingleObjectBuilder<TResponse, TRequest> WithArguments<TResponse, TRequest>(this ISingleObjectBuilder<TResponse, TRequest> objectBuilder, Action<ParameterQueryString> arguments)
        {
            ((IObjectBuilder<TResponse, TRequest>)objectBuilder).WithArguments(arguments);
            return objectBuilder;
        }
    }
}