using TesteWorkerService;
using Serilog;
using Serilog.Events;
using Microsoft.Extensions.Hosting;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .WriteTo.File(@"C:\temp\testeservice\LogFile.txt")
    .CreateLogger();

try
{
    Log.Information("Iniciando o serviço");
    IHost host = Host.CreateDefaultBuilder(args)
     .UseWindowsService()
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
    }).UseSerilog().Build();

    await host.RunAsync();
    return;
} catch (Exception ex)
{
    Log.Fatal(ex, "Houve um problema ao iniciar o serviço");
    return;
}
finally
{
    Log.CloseAndFlush();    
}


