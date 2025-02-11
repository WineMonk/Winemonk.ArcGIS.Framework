using Microsoft.Extensions.Logging;

namespace Winemonk.ArcGIS.Framework.Samples.Services
{
    [RegisterService(typeof(TestLogService))]
    public class TestLogService
    {
        private readonly ILogger<TestLogService> _logger;
        public TestLogService(ILogger<TestLogService> logger)
        {
            _logger = logger;
        }

        public void WriteLog()
        {
            _logger?.LogTrace("Configured Logger Class LogTrace");
            _logger?.LogDebug("Configured Logger Class LogDebug");
            _logger?.LogInformation("Configured Logger Class LogInformation");
            _logger?.LogWarning("Configured Logger Class LogWarning");
            _logger?.LogError("Configured Logger Class LogError");
            _logger?.LogCritical("Configured Logger Class LogCritical");
        }
    }
}
