using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FluentRequestHttpClient.Enuns;
using FluentRequestHttpClient.Response;
using Newtonsoft.Json;

namespace FluentRequestHttpClient
{
    public class ObjectBuilder<TResponse, TRequest> : IObjectBuilder<TResponse, TRequest>
    {
        private string USER;
        private string PASSWORD;
        private Uri uri;
        private string Rota;
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

        public ISingleObjectBuilder<TResponse, TRequest> AddRota(string rota)
        {
            this.Rota = rota;

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

        public async Task<HttpResponseMessage> BuildAsync()
        {
            try
            {

                using (var client = new HttpClient { BaseAddress = this.uri })
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    
                    //client.Timeout = new TimeSpan(this.timeout);

                    var response = await client.GetAsync(this.Rota);

                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    
                    //new ObjectContent<Foo>(foo,
                    //    Configuration.Formatters.JsonFormatter)

                    //var result = JsonConvert.DeserializeObject<IList<TResponse>>(body);

                    response.Content = new StringContent(body);

                    return response;


                }

            }
            catch (Exception ex)
            {

                throw;
            }

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