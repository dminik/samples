using System.Linq;

using ExchangeRateUpdater.BaseExchngeRateProvider;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

namespace ExchangeRateUpdater.DNBExchngeRateProvider.Tests
{
    [TestClass]
    public class DNBExchangeRateProviderTests
    {
        [TestMethod]        
        public void GetExchangeRates_Success()
        {
            // Arrange
            var remoteDataProviderMock = new Mock<IDNBRemoteDataProvider>();
            var converterRatesMock = new Mock<IDNBConverterRatesToExchangeRates>();

            var rateProviderUnderTest = new DNBExchangeRateProvider(remoteDataProviderMock.Object, converterRatesMock.Object);
            
            // Act
            var actualData = rateProviderUnderTest.GetExchangeRates(Enumerable.Empty<Currency>());

            // Assert
            Assert.IsNotNull(actualData);            
            Assert.AreEqual(0, actualData.Count());            
        }       
    }
}
