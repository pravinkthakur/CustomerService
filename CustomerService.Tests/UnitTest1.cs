using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace CustomerService.Tests;

public class CustomerServiceTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public CustomerServiceTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task GetName_ReturnsPravin()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync("/name");
        var body = (await response.Content.ReadAsStringAsync()).Trim();

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal("Pravin", body);
    }

    [Fact]
    public async Task GetAge_Returns49()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync("/age");
        var body = (await response.Content.ReadAsStringAsync()).Trim();

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        // allow string or number (Linux sometimes serialises differently)
        Assert.True(body == "49" || body == 49.ToString(), $"Expected '49' but got '{body}'");
    }

   
}
