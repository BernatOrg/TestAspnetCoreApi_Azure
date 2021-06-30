using TestAspnetCore.Web;
using Xunit;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.IO;
using System;
using System.Net;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace TestAspnetCore.IntegrationTest.InMemory
{
    public class UnitTest
    {

        #region fields

        private IHost server;
        private HttpClient client;

        #endregion

         #region tests

         private async Task StartServer()
         {
            var hostBuilder = new HostBuilder()
            .ConfigureWebHost(webHost =>
            {
                webHost.UseTestServer();
                webHost.UseEnvironment("Development");
                webHost.UseStartup<Startup>();
                webHost.ConfigureAppConfiguration((context, config) =>
                {
                config.SetBasePath(Directory.GetCurrentDirectory());
                });
                
            });

            this.server = await hostBuilder.StartAsync();       
            this.client = this.server.GetTestClient();
            this.client.BaseAddress = new Uri("http://localhost:8888");
            this.client.DefaultRequestHeaders
                    .Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        [Fact]
        public async Task Echoping_Test()
        {
           // Arrange
           await this.StartServer();
           var request = new HttpRequestMessage(HttpMethod.Get, "api/v1/test/echoping");
 
           //Act
           var response = await client.SendAsync(request);
 
           //Assert
           Assert.Equal(
               HttpStatusCode.OK,
               response.StatusCode);
        }

        [Fact] 
        public async Task GetTest_BadRequestTest()
        {
          // Arrange
           await this.StartServer();
           var request = new HttpRequestMessage(HttpMethod.Get, "api/v1/test/gettest");
 
           //Act
           var response = await client.SendAsync(request);
           string content = await response.Content.ReadAsStringAsync();
 
           //Assert
           Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
           
        }

         [Fact] 
        public async Task GetTest_RequestTest()
        {
          // Arrange
           await this.StartServer();
           var request = new HttpRequestMessage(HttpMethod.Get, "api/v1/test/gettest?Name=John");
 
           //Act
           var response = await client.SendAsync(request);
           string content = await response.Content.ReadAsStringAsync();
 
           //Assert
           Assert.Equal(HttpStatusCode.OK, response.StatusCode);
           Assert.Contains("John",content);
           
        }

        #endregion
    }
}
