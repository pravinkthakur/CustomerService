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
        // Ensure content root works on GitHub Actions (Linux) and Windows
        _factory = factory.WithWebHostBuilder(builder =>
        {
            builder.UseContentRoot(AppContext.BaseDirectory);
        });
    }

    [Fact]
    public async Task GetRoot_ReturnsRoot()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync("/");
        var body = await response.Content.ReadAsStringAsync();

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal("CustomerService Root", body);
    }

    [Fact]
    public async Task GetName_ReturnsPravin()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync("/name");
        var body = await response.Content.ReadAsStringAsync();

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal("Pravin", body);
    }

    [Fact]
    public async Task GetAge_Returns49()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync("/age");
        var body = await response.Content.ReadAsStringAsync();

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal("49", body);
    }
}
