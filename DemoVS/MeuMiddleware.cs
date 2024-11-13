
using Serilog;
using System.Diagnostics;

namespace PorBaixoDosPanos
{
    // Estrutura de um middleware
    public class TemplateMiddleware
    {
        private readonly RequestDelegate _next; // RequestDelegate vai fazer uma chamada e ficar aguardando o retorno dela

        public TemplateMiddleware(RequestDelegate next)         
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext) // HttpContext objeto com o contexto da requisição
        {
            // Faz algo antes

            // Chama o próximo middleware no pipeline
            await _next(httpContext);

            // Faz algo depois
        }
    }

    // Middleware para verificar quanto tempo demorou a chamada
    public class LogTempoMiddleware
    {
        private readonly RequestDelegate _next; 

        public LogTempoMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext) // HttpContext objeto com o contexto da requisição
        {
            // Faz algo antes
            var sw = Stopwatch.StartNew();

            // Chama o próximo middleware no pipeline
            await _next(httpContext);

            // Faz algo depois
            sw.Stop();

            Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
            Log.Information($"A execução demorou {sw.Elapsed.TotalMilliseconds}ms ({sw.Elapsed.TotalSeconds} segundos)");            
        }
    }

    public static class SerilogExtensions // criando a extensão, isso é útil para encapsular várias instruções de código e ser implementada com uma única linha na classe Program.cs 
    {    
        public static void AddSerilog(this WebApplicationBuilder builder) // extendendo o comportamento do WebApplicationBuilder (extension method)
        {
            builder.Host.UseSerilog();
            // Caso exista mais que uma linha de código
            //
            //
            //
        }
    }

    public static class LogTempoMiddlewareExtensions // criando a extensão, isso é útil para encapsular várias instruções de código e ser implementada com uma única linha na classe Program.cs
    {
        public static void UseLogTempo(this WebApplication app) // extendendo o comportamento do WebApplication (extension method)
        {
            app.UseMiddleware<LogTempoMiddleware>();
            // Caso exista outras configurações ou outros middlewares
        }
    }
}
