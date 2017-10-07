using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FluentRequestHttpClient.Enuns;
using FluentRequestHttpClient.Parameters;
using System.Linq;
using FluentRequestHttpClient.Intefarces;
using FluentRequestHttpClient.Extensions;

namespace FluentRequestHttpClient
{
    public class FluentRequestBuilder<TResponse, TRequest> : IObjectBuilder<TResponse, TRequest>
    {
        private string _USER;
        private string _PASSWORD;
        private Uri _uri;
        private string _rota;
        private int? _timeout;
        private HttpVerb _verb;
        private IDictionary<string, string> _headers;
        private ParameterQueryStringCollection _arguments;
        private HttpClient _httpClient;

        public FluentRequestBuilder()
        {
            _headers = new Dictionary<string, string>();
            _arguments = new ParameterQueryStringCollection();

            _USER = null;
            _PASSWORD = null;
            _uri = null; ;
            _rota = null; ;
            _timeout = null;
            _verb = HttpVerb.Undefined;
        }


        public ISingleObjectBuilder<TResponse, TRequest> Authenticate(string user, string password)
        {
            _USER = user;
            _PASSWORD = password;

            return this;
        }

        public ISingleObjectBuilder<TResponse, TRequest> WithHeader(string key, string value)
        {
            _headers.Add(key, value);

            return this;
        }

        public ISingleObjectBuilder<TResponse, TRequest> AddUri(string uri)
        {
            _uri = new Uri(uri);

            return this;
        }

        public ISingleObjectBuilder<TResponse, TRequest> AddRota(string rota)
        {
            _rota = rota;

            return this;
        }

        public ISingleObjectBuilder<TResponse, TRequest> WithTimeout(int timeout)
        {
            _timeout = timeout;

            return this;
        }

        public ISingleObjectBuilder<TResponse, TRequest> SetVerb(HttpVerb verb)
        {
            _verb = verb;

            return this;
        }

        public ISingleObjectBuilder<TResponse, TRequest> WithArguments(IDictionary<string, string> parameters)
        {
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arguments"></param>
        /// <returns></returns>
        public ISingleObjectBuilder<TResponse, TRequest> WithArguments(object arguments)
        {
            arguments.ToDictionary()
                .Select(x => ParameterQueryString.Factor.Create(x.Key, x.Value))
                .ToList()
                .ForEach(x => _arguments.Add(x));

            return this;
        }

        public ISingleObjectBuilder<TResponse, TRequest> WithArguments(Action<ParameterQueryString> arguments)
        {
            //arguments.ToDictionary()
            //    .Select(x => ParameterQueryString.Factor.Create(x.Key, x.Value))
            //    .ToList()
            //    .ForEach(x => _arguments.Add(x));

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
                switch (this._verb)
                {
                    case HttpVerb.Undefined: break;
                    case HttpVerb.Delete: break;
                    case HttpVerb.Get: { return await ExecuteGet(); }
                    case HttpVerb.Head: break;
                    case HttpVerb.Put: break;
                    case HttpVerb.OPTIONS: break;
                    case HttpVerb.Post: break;
                    case HttpVerb.Trace: break;
                    default:
                        break;
                }

            }
            catch (Exception ex)
            {
                throw;
            }

            throw new NotImplementedException("The verb was not implemented");
        }

        private async Task<HttpResponseMessage> ExecuteGet()
        {
            using (var client = new HttpClient { BaseAddress = _uri })
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //client.Timeout = new TimeSpan(this.timeout);

                var url = _arguments.Count > 0 ? $"{_rota}?{_arguments.ToString()}" : _rota;

                var response = await client.GetAsync(url);

                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                //new ObjectContent<Foo>(foo,
                //    Configuration.Formatters.JsonFormatter)

                //var result = JsonConvert.DeserializeObject<IList<TResponse>>(body);

                response.Content = new StringContent(body);

                return response;
            }
        }

        public void Dispose()
        {
            _headers = null;
            _arguments = null;

            _USER = null;
            _PASSWORD = null;
            _uri = null; ;
            _rota = null; ;
            _timeout = null;
            _verb = HttpVerb.Undefined;
        }
    }
}