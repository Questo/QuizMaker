using System;
using System.IO;
using Microsoft.Extensions.Logging;

namespace QuizMaker.Application.Logging
{
    public class FileLogger : ILogger
    {
        private readonly string _name;
        private readonly FileLoggerConfiguration _config;

        public FileLogger(string name, FileLoggerConfiguration config)
            => (_name, _config) = (name, config);

        public IDisposable BeginScope<TState>(TState state) => null;

        public bool IsEnabled(LogLevel logLevel) => logLevel == _config.LogLevel;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state,
            Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
                return;

            if (_config.EventId == 0 || _config.EventId == eventId.Id)
            {
                // append text to an existing file named "Log.txt"
                string text = $"{DateTime.Now} - {logLevel} - {eventId.Id} - {_name} - {formatter(state, exception)}";
                using (var outputFile = new StreamWriter(Path.Combine(_config.LogPath, "Log.txt"), true))
                    outputFile.WriteLine(text);
            }
        }
    }
}