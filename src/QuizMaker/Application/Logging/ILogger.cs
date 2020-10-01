using System;

namespace QuizMaker.Application.Logging
{
    public interface ILogger
    {

    }

    public class LogItem
    {
        public DateTime Occured { get; } = DateTime.Now;
    }
}