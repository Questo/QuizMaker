using System;

namespace QuizMaker.Application.Logging
{
    public class LogItem
    {
        public DateTime Occured { get; } = DateTime.Now;
        public string Title { get; set; }
        public string Message { get; set; }
    }
}