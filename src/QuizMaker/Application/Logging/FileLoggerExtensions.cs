using System;
using Microsoft.Extensions.Logging;

namespace QuizMaker.Application.Logging
{
    public static class FileLoggerExtensions
    {
        public static ILoggerFactory AddColorConsoleLogger(
                                          this ILoggerFactory loggerFactory,
                                          FileLoggerConfiguration config)
        {
            loggerFactory.AddProvider(new FileLoggerLoggerProvider(config));
            return loggerFactory;
        }
        public static ILoggerFactory AddColorConsoleLogger(
                                          this ILoggerFactory loggerFactory)
        {
            var config = new FileLoggerConfiguration();
            return loggerFactory.AddColorConsoleLogger(config);
        }
        public static ILoggerFactory AddColorConsoleLogger(
                                        this ILoggerFactory loggerFactory,
                                        Action<FileLoggerConfiguration> configure)
        {
            var config = new FileLoggerConfiguration();
            configure(config);
            return loggerFactory.AddColorConsoleLogger(config);
        }
    }
}
