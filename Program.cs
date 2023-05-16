using TesteWorkerService;
using Serilog;
using Serilog.Events;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .WriteTo.File(@"C:\temp\testeservice\LogFile.txt")
    .CreateLogger();

try
{
    Log.Information("Iniciando o servi�o");
    IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
    })
    .Build();

    await host.RunAsync();
    return;
} catch (Exception ex)
{
    Log.Fatal(ex, "Houve um problema ao iniciar o servi�o");
    return;
}
finally
{
    Log.CloseAndFlush();    
}


