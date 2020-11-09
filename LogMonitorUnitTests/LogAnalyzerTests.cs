using System;
using LogMonitor.UnitTests.Mocks__Handwritten_;
using LogMonitor.UnitTests.Stubs__Handwritten_;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogMonitor.UnitTests
{
    [TestClass]
    public class LogAnalyzerTests
    {
        [TestMethod]
        [TestCategory(Constants.LogAnalyzerCategory)]
        [ExpectedException(typeof(ArgumentNullException),"the filename cannot be null")]
        public void IsValidFileName_ShouldThrowArgumentNullException_WhenNameIsNull()
        {
            //Arrange
            IExtensionManager extensionManager = new StubExtensionManager();
            ILogger logger = new StubLogger();
            var logAnalyzer = new LogAnalyzer(extensionManager, logger);

            //Act + Assert
            logAnalyzer.IsValidFileName(null);
        }


        [TestMethod]
        [TestCategory(Constants.LogAnalyzerCategory)]
        public void IsValidFileName_ShouldBeValid_WhenNameStartsWithProperPrefix()
        {
            //Arrange
            IExtensionManager extensionManager = new StubExtensionManager();
            ILogger logger = new StubLogger();
            var logAnalyzer = new LogAnalyzer(extensionManager, logger);

            //Act
            var result = logAnalyzer.IsValidFileName("Log_LGO.json");

            //Assert
            Assert.IsTrue(result, "The file name must always starts with the prefix Log_");
        }


        [TestMethod]
        [TestCategory(Constants.LogAnalyzerCategory)]

        public void IsValidFileName_ShouldCallWebServiceLogger_WhenNameIsIncorrect()
        {
            //Arrange
            IExtensionManager extensionManager = new StubExtensionManagerAlwaysInvalid();
            MockLogger logger = new MockLogger();
            var logAnalyzer = new LogAnalyzer(extensionManager, logger);
            var invalidFileName = "Invalid_LGO.xlsx";
            var expectedLogMessage = $"The fileName: {invalidFileName} is invalid!!";

            //Act
            logAnalyzer.IsValidFileName(invalidFileName);

            //Assert
            Assert.AreEqual(expectedLogMessage, logger.LastError, "The message logged is not correct");
        }

    }
}