using Moq;
using System;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogMonitor.UnitTests.Useful_Libraries
{
    [TestClass]
    public class MsftFakesLogAnalyzerTests
    {
        [TestMethod]
        [Ignore]
        public void IsValidFileName_ShouldSetLastInvalidFileNameDate_WhenNameIsIncorrect()
        {
            using (ShimsContext.Create())
            {
                //Arrange
                var expectedDate = new DateTime(2000, 1, 1);
                System.Fakes.ShimDateTime.UtcNowGet = () => expectedDate;

                Mock<IExtensionManager> extensionManager = new Mock<IExtensionManager>();
                extensionManager
                    .Setup(e => e.IsValid(It.IsAny<string>()))
                    .Returns(false);

                Mock<ILogger> logger = new Mock<ILogger>();
                var logAnalyzer = new LogAnalyzer(extensionManager.Object, logger.Object);

                //Act
                var result = logAnalyzer.IsValidFileName("Invalid_LGO.xlsx");

                //Assert
                Assert.AreEqual(expectedDate, logAnalyzer.LastInvalidFileNameDate);
            }
        }
    }
}