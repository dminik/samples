using System;
using System.IO;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExchangeRateUpdater.DNBExchangeRateProvider.Tests
{
    [TestClass]
    public class DNBRemoteDataProviderTests
    {
        [TestMethod]
        [TestCategory("Integration")]
        public void GetDataFromRemoteServer_Success()
        {
            // Arrange
            var dataProviderUnderTest = new DNBRemoteDataProvider();

            // Act
            var actualData = dataProviderUnderTest.GetData();

            // Assert
            Assert.IsNotNull(actualData);            
            Assert.IsFalse(string.IsNullOrEmpty(actualData.refcur));
            Assert.IsNotNull(actualData.dailyrates);
            Assert.IsNotNull(actualData.dailyrates.currency);
            Assert.IsTrue(actualData.dailyrates.currency.Any());
        }

        [TestMethod]        
        public void GetDataFromLocalDisk_Success()
        {
            // Arrange
            var progectPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../");
            var testFilePath = new Uri(Path.Combine(progectPath, @"DNBExchangeRateProvider\Tests\TestRates.xml"));
            Assert.IsTrue(File.Exists(testFilePath.LocalPath));
            var dataProviderUnderTest = new DNBRemoteDataProvider(testFilePath);

            // Act
            var actualData = dataProviderUnderTest.GetData();

            // Assert
            Assert.IsNotNull(actualData);            
            Assert.AreEqual("DKK", actualData.refcur);
            Assert.IsNotNull(actualData.dailyrates);
            Assert.IsNotNull(actualData.dailyrates.currency);
            Assert.IsTrue(actualData.dailyrates.currency.Any());
            Assert.AreEqual(3, actualData.dailyrates.currency.Count());
            var currency = actualData.dailyrates.currency.First();
            Assert.AreEqual("488.79", currency.rate);
            Assert.AreEqual("AUD", currency.code);
        }
    }
}
