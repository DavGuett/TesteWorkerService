namespace TesteWorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private HttpClient Client;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            Client = new HttpClient();
            return base.StartAsync(cancellationToken);
        }
        public override Task StopAsync(CancellationToken cancellationToken)
        {
            Client.Dispose();
            _logger.LogInformation("Serviço parado");
            return base.StopAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var result = await Client.GetAsync("https://www.proa.tec.br");
                if(result.IsSuccessStatusCode)
                {
                    _logger.LogInformation($"Website está online. Status code {result.StatusCode}");
                }
                else
                {
                    _logger.LogError($"Website está offline. Status code: {result.StatusCode}");
                }
                _logger.LogInformation("Worker rodando em: {time}", DateTimeOffset.Now);
                await Task.Delay(5000, stoppingToken);
            }
        }
    }
}