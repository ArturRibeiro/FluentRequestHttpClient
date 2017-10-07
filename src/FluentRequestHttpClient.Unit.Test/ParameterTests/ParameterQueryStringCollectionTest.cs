using FluentRequestHttpClient.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace FluentRequestHttpClient.Unit.Test.ParameterTests
{
    public class ParameterQueryStringCollectionTest
    {
        [Fact]
        public void Create_ParameterUrl()
        {
            var p = new ParameterQueryStringCollection();
            p.Add(ParameterQueryString.Factor.Create("name", "Artur Araújo Santos Ribeiro"));
            p.Add(ParameterQueryString.Factor.Create("phoneNumber", "55219632145"));
            p.Add(ParameterQueryString.Factor.Create("email", "captain.America@gmail.com"));

            var parameters = System.Net.WebUtility.UrlDecode(p.ToString()).Split('&').ToList();

            Assert.Equal(parameters.ElementAt(0), "name=Artur Araújo Santos Ribeiro");
            Assert.Equal(parameters.ElementAt(1), "phoneNumber=55219632145");
            Assert.Equal(parameters.ElementAt(2), "email=captain.America@gmail.com");
        }
    }
}
