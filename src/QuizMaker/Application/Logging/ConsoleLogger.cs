using System;

namespace QuizMaker.Application.Logging
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string title, string message)
        {
            Console.WriteLine($"{DateTime.UtcNow}\t - {title}\n{message}");
        }
    }
}