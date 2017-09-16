using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using FluentHttpClient;
using FluentHttpClient.Enuns;

namespace FluentHttpClient.Unit.Test
{
    public class PessoaMessaResponse
    {
        public Dictionary<string, string> Headers { get; set; }
    }

    public class PessoaMessaRequest
    {
        public Dictionary<string, string> Headers { get; set; }

        public int Id { get; set; }

        public string Nome { get; set; }
    }

    public class FluentRequestHttpClientTest
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(4)]
        public void FromSeconds(int timeout)
        {
            using (var rest = new Rest())
            {
                rest.WithTimeout(timeout);

                Assert.Equal(rest.TimeOut, TimeSpan.FromSeconds(timeout));
            }
        }

        [Theory()]
        [InlineData("Accept", "text/html, image/*")]
        [InlineData("Accept-Charset", "iso8859-5")]
        [InlineData("Accept-Encoding", "gzip, compress")]
        [InlineData("Accept-Language", "bt-br")]
        [InlineData("Authorization", "012345679")]
        public void Header(string name, string value)
        {
            using (var rest = new Rest())
            {
                rest.WithHeader(name, value);

                Assert.True(rest.Headers.Keys.Any(x => x.Equals(name)));
                Assert.Equal(rest.Headers[name], value);
            }
        }

        [Theory()]
        [InlineData("https://github.com/Pathoschild/FluentHttpClient/blob/develop/Client")]
        public void Uri(string url)
        {
            using (var rest = new Rest())
            {
                rest.WithBaseUrl(url);

                Assert.Equal(rest.Uri.AbsoluteUri, url + "/");

            }
        }

        [Fact]
        public void CreateNewTest()
        {

            //var response =
            //	this.HttpService.SubmitRequest<PedidoCreateRequest, PedidoCreateResponse>
            //	(createRequest,
            //		string.Concat(this.HostUri, EndPointResource),
            //		HttpVerbEnum.Post,
            //		HttpContentTypeEnum.json,
            //		headers);

            //1 - Utilizar os Verbos

            var ob = new ObjectBuilder<PessoaMessaResponse, PessoaMessaRequest>();



            var response = Builder<PessoaMessaResponse, PessoaMessaRequest>
                .CreateNew()
                .Authenticate("usuario", "senha")
                    .WithHeader("", "")
                    .WithTimeout(93873)
                    .WithArguments(new Dictionary<string, string>()
                    {
                        { "tetse", "teste" },
                        { "tetse1", "teste" },
                        { "tetse2", "teste" }
                    })
                    .AddUri("https://transaction.stone.com.br/Sale/cancel")
                    .SetVerb(HttpVerb.Get)
                .Build();


        }
    }
}
