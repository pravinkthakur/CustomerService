var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();
app.MapGet("/", () => "Pravin/49");
app.MapGet("/name", () => "Pravin");
app.MapGet("/age", () => 49);

app.Run();

// Required so WebApplicationFactory<Program> in tests can see Program
public partial class Program { }
