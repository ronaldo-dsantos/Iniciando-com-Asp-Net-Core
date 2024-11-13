using DemoVS;
using Serilog;

// Configuração Builder
var builder = WebApplication.CreateBuilder(args);

// Configuração do Pipeline

//builder.Host.UseSerilog(); // 
builder.AddSerilog();

// Middlewares

// Services

// Configuração do App
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
