using DemoVS;
using Serilog;

// Configura��o Builder
var builder = WebApplication.CreateBuilder(args);

// Configura��o do Pipeline

//builder.Host.UseSerilog(); // 
builder.AddSerilog();

// Middlewares

// Services

// Configura��o do App
var app = builder.Build();

//app.UseMiddleware<LogTempoMiddleware>(); 
app.UseLogTempo();

app.MapGet("/", () => "Hello World!");
app.MapGet("/teste", () => 
{
    Thread.Sleep(1500);
    return "Teste 2";
});

app.Run();
