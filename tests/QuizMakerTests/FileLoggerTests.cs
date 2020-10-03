using System;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuizMaker.Application.Logging;

namespace QuizMakerTests
{
    [TestClass]
    public class FileLoggerTests
    {
        private FileLogger _sut;
        private FileLoggerConfiguration _testConfig;
        private Func<FileLoggerTests, Exception, string> _testFormatter;

        [TestInitialize]
        public void Initialize()
        {
            _testFormatter = (state, exception) => $"{state} - {exception.ToString()}";

            _testConfig = new FileLoggerConfiguration
            {
                LogLevel = LogLevel.Debug,
                LogPath = "./",
                EventId = 1,
            };

            _sut = new FileLogger(nameof(FileLoggerTests), _testConfig);
        }

        [TestCleanup]
        public void Cleanup() => _sut = null;

        [TestMethod]
        public void TestMethod1()
        {
            _sut.Log<FileLoggerTests>(LogLevel.Debug, _testConfig.EventId, this, new ApplicationException("ERROR c312"), _testFormatter);
        }
    }
}
