using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExchangeRateUpdater.BaseExchngeRateProvider.Tests
{    
    [TestClass]
    public class BaseExchangeRateProviderTests
    {
        class NonAbstractExchangeRateProvider : BaseExchangeRateProvider
        {
            public override IEnumerable<ExchangeRate> GetExchangeRates(IEnumerable<Currency> currencies)
            {
                throw new NotImplementedException();
            }

            public IEnumerable<ExchangeRate> TestFilterRatesByCurrency(IEnumerable<Currency> currencies, IEnumerable<ExchangeRate> rates)
            {
                return FilterRatesByCurrency(currencies, rates);
            }
        }

        [TestMethod]        
        public void GetExchangeRates_Success()
        {
            // Arrange
            var rateProviderUnderTest = new NonAbstractExchangeRateProvider();
            var currencyList = new List<Currency>
            {
                new Currency("USD"),
                new Currency("eur"),
                new Currency("RUB"),
            };

            var rateList = new List<ExchangeRate>
            {
                new ExchangeRate(new Currency("DKK"), new Currency("usd"), 100),
                new ExchangeRate(new Currency("DKK"), new Currency("EUR"), 100),
                new ExchangeRate(new Currency("DKK"), new Currency("XYZ"), 100),
                new ExchangeRate(new Currency("DKK"), new Currency("DDD"), 100),
            };

            // Act
            var actualFilteredRates = rateProviderUnderTest.TestFilterRatesByCurrency(currencyList, rateList);

            // Assert
            Assert.IsNotNull(actualFilteredRates);            
            Assert.AreEqual(2, actualFilteredRates.Count());            
            Assert.IsNotNull(actualFilteredRates.SingleOrDefault(x => x.TargetCurrency.Code == "USD"));
            Assert.IsNotNull(actualFilteredRates.SingleOrDefault(x => x.TargetCurrency.Code == "EUR"));
        }       
    }
}
