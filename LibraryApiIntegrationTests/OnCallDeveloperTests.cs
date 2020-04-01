using LibraryApi;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LibraryApiIntegrationTests
{
    public class OnCallDeveloperTests: IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient Client;

        public OnCallDeveloperTests(CustomWebApplicationFactory<Startup> factory)
        {
            Client = factory.CreateClient();
        }

        [Fact]
        public async Task CanGetOnCallEmployee()
        {
            var response = await Client.GetAsync("/oncalldeveloper");
            Assert.True(response.IsSuccessStatusCode);
            var data = await response.Content.ReadAsAsync<DeveloperResponse>();
            Assert.Equal("testing@test.com", data.email);
        }
    }

    public class DeveloperResponse
    {
        public string email { get; set; }
    }
}
