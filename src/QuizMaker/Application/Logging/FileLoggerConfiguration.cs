using Microsoft.Extensions.Logging;

namespace QuizMaker.Application.Logging
{
    public class FileLoggerConfiguration
    {
        public LogLevel LogLevel { get; set; }
        /// <summary>Gets/sets the path of the log file </summary>
        public string LogPath { get; set; }
        public EventId EventId { get; set; }
    }
}