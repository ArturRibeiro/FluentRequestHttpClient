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
using FluentRequestHttpClient.Request;
using FluentRequestHttpClient.Response;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Net;

namespace FluentRequestHttpClient
{
    public class FluentRequestBuilder<TResponse, TRequest> : IObjectBuilder<TResponse, TRequest>
    {
        private string _USER;
        private string _PASSWORD;
        
        private HttpClient _httpClient;
        public FluentHttpSetup _setup;


        public FluentRequestBuilder()
        {
            _setup = new FluentHttpSetup();
            _USER = null;
            _PASSWORD = null;
        }


        public ISingleObjectBuilder<TResponse, TRequest> Authenticate(string user, string password)
        {
            _USER = user;
            _PASSWORD = password;

            return this;
        }

        public ISingleObjectBuilder<TResponse, TRequest> WithHeader(string key, string value)
        {
            _setup.DefaultRequestHeaders.Add(key, value);

            return this;
        }

        public ISingleObjectBuilder<TResponse, TRequest> AddUri(string uri)
        {
            _setup.Uri = new Uri(uri);

            return this;
        }

        public ISingleObjectBuilder<TResponse, TRequest> AddRota(string rota)
        {
            _setup.Rota = rota;

            return this;
        }

        public ISingleObjectBuilder<TResponse, TRequest> WithTimeout(int timeout)
        {
            _setup.Timeout = timeout;

            return this;
        }

        public ISingleObjectBuilder<TResponse, TRequest> SetVerb(HttpVerb verb)
        {
            _setup.HttpVerb = verb;

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
                .ForEach(x => _setup.Arguments.Add(x));

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

        

        public async Task<TResponse> GetAsync()
        {
            return await this.DoRequestAsync<TResponse>();

        }

        public void Dispose()
        {
            _setup = null;
            _USER = null;
            _PASSWORD = null;
        }

        #region Private Methods

        private async Task<TResponse> DoRequestAsync<TResponse>()
            //where TRequest : BaseRequestMessage
            //where TResponse : BaseResponseMessage, new()
        {
            var responseMessage = await new FluentGetRequest<TResponse>(_setup).ExecuteAsync();

            switch (responseMessage.StatusCode)
            {
                case HttpStatusCode.BadRequest:
                    {
                        //AdicionaMensagem("HTTP-400", "Request mal formado.", response);
                        break;
                    }
                case HttpStatusCode.Forbidden:
                    {
                        //AdicionaMensagem("HTTP-403", "Request proibido. O servidor recusou a requisição. ", response);
                        break;
                    }
                case HttpStatusCode.InternalServerError:
                    {
                        //AdicionaMensagem("HTTP-500", string.Concat("Ocorreu um erro interno ao servidor.", responseMessage.ReasonPhrase, ". Retorno: ", JsonConvert.SerializeObject(response)), response);
                        break;
                    }
                case HttpStatusCode.NotFound:
                    {
                        //AdicionaMensagem("HTTP-404", "Recurso não encontrado no servidor.", response);
                        break;
                    }
                case HttpStatusCode.ServiceUnavailable:
                    {
                        //AdicionaMensagem("HTTP-503", "Serviço indisponível.", response);
                        break;
                    }
                case HttpStatusCode.Unauthorized:
                    {
                        //AdicionaMensagem("HTTP-401", "O acesso a este recurso não está autorizado.", response);
                        break;
                    }
            }

            var response = await responseMessage.ReadResponse2<TResponse>().ConfigureAwait(false);

            return response;
        }

        #endregion
    }
}