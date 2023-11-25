using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace test_rest_sharp.Helpers
{
    public static class LoggingConfig
    {
        public static ILoggerFactory LoggerFactory { get; } = new LoggerFactory();

        public static void ConfigureLogging(IServiceCollection services)
        {
            services.AddLogging(builder =>
            {
                builder.SetMinimumLevel(LogLevel.Trace);
                builder.AddConsole();
                builder.AddDebug();
            });

            LoggerFactory.AddProvider(new LoggerFactoryProvider());
        }

        public static ILogger<T> CreateLogger<T>() =>
            LoggerFactory.CreateLogger<T>();
    }

    public class LoggerFactoryProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName) =>
            LoggingConfig.LoggerFactory.CreateLogger(categoryName);

        public void Dispose() { }
    }
}
