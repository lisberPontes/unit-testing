using FluentAssertions;
using LogMonitor.UnitTests.Stubs__Handwritten_;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogMonitor.UnitTests.Useful_Libraries
{
    [TestClass]
    public class FluentAssertionsLogAnalyzerTests
    {
        [TestMethod]
        public void IsValidFileName_ShouldBeValid_WhenNameStartsWithProperPrefix()
        {
            //Arrange
            IExtensionManager extensionManager = new StubExtensionManager();
            ILogger logger = new StubLogger();
            var logAnalyzer = new LogAnalyzer(extensionManager, logger);

            //Act
            var result = logAnalyzer.IsValidFileName("Log_LGO.json");

            //Assert
            result.Should().BeTrue("The file name must always starts with the prefix Log_");
        }
    }
}