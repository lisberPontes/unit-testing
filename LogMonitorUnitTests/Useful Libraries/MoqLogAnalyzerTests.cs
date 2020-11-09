using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogMonitor.UnitTests.Useful_Libraries
{
    [TestClass]
    public class MoqLogAnalyzerTests
    {

        [TestMethod]
        public void IsValidFileName_ShouldBeValid_WhenNameStartsWithProperPrefix()
        {
            //Arrange
            Mock<IExtensionManager> extensionManager = new Mock<IExtensionManager>();
            extensionManager
                .Setup(e => e.IsValid(It.IsAny<string>()))
                .Returns(true);

            Mock<ILogger> logger = new Mock<ILogger>();
            var logAnalyzer = new LogAnalyzer(extensionManager.Object, logger.Object);

            //Act
            var result = logAnalyzer.IsValidFileName("Log_LGO.json");

            //Assert
            Assert.IsTrue(result, "The file name must always starts with the prefix Log_");
        }


        [TestMethod]
        public void IsValidFileName_ShouldCallWebServiceLogger_WhenNameIsIncorrect()
        {
            //Arrange
            Mock<IExtensionManager> extensionManager = new Mock<IExtensionManager>();
            extensionManager
                .Setup(e => e.IsValid(It.IsAny<string>()))
                .Returns(false);

            Mock<ILogger> logger = new Mock<ILogger>();

            var logAnalyzer = new LogAnalyzer(extensionManager.Object, logger.Object);
            var invalidFileName = "Invalid_LGO.xlsx";
            var expectedLogMessage = $"The fileName: {invalidFileName} is invalid!!";

            //Act
            logAnalyzer.IsValidFileName(invalidFileName);

            //Assert
            logger.Verify(l => l.LogErrorMessage(expectedLogMessage), Times.Once, 
                "This method must be called one time");
        }

    }
}