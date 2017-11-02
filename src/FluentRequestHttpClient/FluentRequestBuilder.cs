using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentRequestHttpClient.Enuns;
using FluentRequestHttpClient.Parameters;
using System.Linq;
using FluentRequestHttpClient.Intefarces;
using FluentRequestHttpClient.Extensions;
using FluentRequestHttpClient.Request;
using FluentRequestHttpClient.Response;
using System.Net;

namespace FluentRequestHttpClient
{
    public class FluentRequestBuilder : IObjectBuilder
    {
        public FluentHttpSetup _setup;


        public FluentRequestBuilder()
        {
            _setup = new FluentHttpSetup();
        }


        public ISingleObjectBuilder Authenticate(string user, string password)
        {
            //TODO: 
            return this;
        }

        public ISingleObjectBuilder WithHeader(string key, string value)
        {
            _setup.DefaultRequestHeaders.Add(key, value);

            return this;
        }

        public ISingleObjectBuilder AddUri(string uri)
        {
            _setup.Uri = new Uri(uri);

            return this;
        }

        public ISingleObjectBuilder AddRota(string rota)
        {
            _setup.Rota = rota;

            return this;
        }

        public ISingleObjectBuilder WithTimeout(int timeout)
        {
            _setup.Timeout = timeout;

            return this;
        }

        public ISingleObjectBuilder SetVerb(HttpVerb verb)
        {
            _setup.HttpVerb = verb;

            return this;
        }

        public ISingleObjectBuilder WithArguments(IDictionary<string, string> parameters)
        {
            return this;
        }
        
        public ISingleObjectBuilder WithArguments(object arguments)
        {
            arguments.ToDictionary()
                .Select(x => ParameterQueryString.Factor.Create(x.Key, x.Value))
                .ToList()
                .ForEach(x => _setup.Arguments.Add(x));

            return this;
        }

        public ISingleObjectBuilder WithArguments(Action<ParameterQueryString> arguments)
        {
            arguments.ToDictionary()
                .Select(x => ParameterQueryString.Factor.Create(x.Key, x.Value))
                .ToList()
                .ForEach(x => _setup.Arguments.Add(x));

            return this;
        }

        public ISingleObjectBuilder PostAsync()
        {
            return this;
        }


        public async Task<TResponse> GetAsync<TRequest, TResponse>() 
            where TRequest : BaseRequestMessage
            where TResponse : BaseResponseMessage, new()
        {
            return await this.DoRequestAsync<TRequest, TResponse>();
        }

        #region Private Methods

        private async Task<TResponse> DoRequestAsync<TRequest, TResponse>() 
            where TRequest : BaseRequestMessage
            where TResponse : BaseResponseMessage, new()
        {
            var responseMessage = await new FluentGetRequest(_setup).ExecuteAsync();
            
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

            return await responseMessage
                .ReadResponse<TRequest, TResponse>()
                .ConfigureAwait(false);
        }

        #endregion

        public void Dispose()
        {
            _setup = null;

        }
    }
}