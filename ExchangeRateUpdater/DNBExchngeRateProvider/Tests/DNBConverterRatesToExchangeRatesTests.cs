using System;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExchangeRateUpdater.DNBExchngeRateProvider.Tests
{
    [TestClass]
    public class DNBConverterRatesToExchangeRatesTests
    {
        [TestMethod]        
        public void Convert_Success()
        {
            // Arrange
            var converterUnderTest = new DNBConverterRatesToExchangeRates();

            var testRates = new exchangerates
            {
                refcur = "DKK",
                dailyrates =
                    new exchangeratesDailyrates
                    {
                        currency =
                            new[]
                            {
                                new exchangeratesDailyratesCurrency { rate = "488.79", code = "AUD", },
                                new exchangeratesDailyratesCurrency { rate = "-", code = "ISK", },
                                new exchangeratesDailyratesCurrency { rate = "43.17", code = "ZAR", },
                            }
                    }
            };

            // Act
            var actualData = converterUnderTest.Convert(testRates);

            // Assert
            Assert.IsNotNull(actualData);            
            Assert.AreEqual(2, actualData.Count());
                        
            var rate1 = actualData.First();
            Assert.AreEqual("AUD", rate1.TargetCurrency.Code);
            Assert.AreEqual("DKK", rate1.SourceCurrency.Code);
            Assert.AreEqual((decimal) 488.79, rate1.Value);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCastException))]
        public void Convert_WrongRateFormat_ThrowExc()
        {
            // Arrange
            var converterUnderTest = new DNBConverterRatesToExchangeRates();

            var testRates = new exchangerates
            {
                refcur = "DKK",
                dailyrates = new exchangeratesDailyrates
                    { currency = new[] { new exchangeratesDailyratesCurrency { rate = "WOW!!", code = "AUD", },} }
            };

            // Act
            converterUnderTest.Convert(testRates);            
        }
    }
}
