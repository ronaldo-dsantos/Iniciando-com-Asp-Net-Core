using PorBaixoDosPanos;

// Configura��o Builder
var builder = WebApplication.CreateBuilder(args);

// Configura��o do Pipeline

//builder.Host.UseSerilog(); // Implementando o UseSerilog() de maneira convencional
builder.AddSerilog(); // Implementando o UseSerilog() de maneira encapsulada

// Middlewares

// Services

// Configura��o do App
var app = builder.Build();

//app.UseMiddleware<LogTempoMiddleware>(); // Implementando o middleware de maneira convencional
app.UseLogTempo(); // Implementando o middleware de maneira encapsulada

app.MapGet("/", () => "Hello World!");
app.MapGet("/teste", () => 
{
    Thread.Sleep(1500);
    return "Teste 2";
});

app.Run();
