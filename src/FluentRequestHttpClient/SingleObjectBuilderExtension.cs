using System.Collections.Generic;
using FluentRequestHttpClient.Enuns;

namespace FluentRequestHttpClient
{
	public static class SingleObjectBuilderExtension
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

		public static ISingleObjectBuilder<TResponse, TRequest> WithArguments<TResponse, TRequest>(this ISingleObjectBuilder<TResponse, TRequest> objectBuilder, IDictionary<string, string> parameters)
		{
			((IObjectBuilder<TResponse, TRequest>)objectBuilder).WithArguments(parameters);
			return objectBuilder;
		}

	}
}