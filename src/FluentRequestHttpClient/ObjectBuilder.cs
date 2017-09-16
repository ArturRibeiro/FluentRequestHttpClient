using System;
using System.Collections.Generic;
using System.Net.Http;
using FluentRequestHttpClient.Enuns;

namespace FluentRequestHttpClient
{
	public class ObjectBuilder<TResponse, TRequest> : IObjectBuilder<TResponse, TRequest>
	{
		private string USER;
		private string PASSWORD;
		private Uri uri;
		private int timeout;
		private HttpVerb verb;
        private IDictionary<string, string> headers = new Dictionary<string, string>();
	    public HttpClient BaseClient;


        public ISingleObjectBuilder<TResponse, TRequest> Authenticate(string user, string password)
		{
			this.USER = user;
			this.PASSWORD = password;

			return this;
		}

		public ISingleObjectBuilder<TResponse, TRequest> WithHeader(string key, string value)
		{
		    headers.Add(key, value);

            return this;
		}

		public ISingleObjectBuilder<TResponse, TRequest> AddUri(string uri)
		{
			this.uri = new Uri(uri);

			return this;
		}

		public ISingleObjectBuilder<TResponse, TRequest> WithTimeout(int timeout)
		{
			this.timeout = timeout;

			return this;
		}

		public ISingleObjectBuilder<TResponse, TRequest> SetVerb(HttpVerb verb)
		{
			this.verb = verb;

			return this;
		}

		public ISingleObjectBuilder<TResponse, TRequest> WithArguments(IDictionary<string, string> parameters)
		{
			return this;
		}

		public ISingleObjectBuilder<TResponse, TRequest> PostAsync()
		{
			return this;
		}

	    public TResponse Build()
		{
			throw new NotImplementedException();
		}

	    public void Dispose()
	    {
	        BaseClient?.Dispose();

	        this.USER = null;
	        this.PASSWORD = null;
            this.uri = null;
            this.timeout = 0;
            this.verb = HttpVerb.None;
            this.headers = new Dictionary<string, string>();
    }
	}
}