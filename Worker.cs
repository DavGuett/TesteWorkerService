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

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var result = await Client.GetAsync("https://www.proa.tec.br");
                if(result.IsSuccessStatusCode)
                {
                    _logger.LogInformation($"Website is up and running. Status code {result.StatusCode}");
                }
                else
                {
                    _logger.LogError($"Website is down. Status code: {result.StatusCode}");
                }
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}