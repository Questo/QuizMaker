using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;

namespace QuizMaker.Application.Logging
{
    public class FileLoggerLoggerProvider : ILoggerProvider
    {
        private readonly FileLoggerConfiguration _config;
        private readonly ConcurrentDictionary<string, FileLogger> _loggers = new ConcurrentDictionary<string, FileLogger>();

        public FileLoggerLoggerProvider(FileLoggerConfiguration config)
        {
            _config = config;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return _loggers.GetOrAdd(categoryName, name => new FileLogger(name, _config));
        }

        public void Dispose()
        {
            _loggers.Clear();
        }
    }
}
