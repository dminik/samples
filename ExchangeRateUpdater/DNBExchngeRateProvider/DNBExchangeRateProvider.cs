using System;
using System.Collections.Generic;

using ExchangeRateUpdater.BaseExchngeRateProvider;

namespace ExchangeRateUpdater.DNBExchngeRateProvider
{
    public class DNBExchangeRateProvider : BaseExchangeRateProvider
    {        
        IDNBRemoteDataProvider DNBRemoteDataProvider { get; set; }
        IDNBConverterRatesToExchangeRates ConverterDNBRatesToExchangeRates { get; set; }

        public DNBExchangeRateProvider(IDNBRemoteDataProvider dNBRemoteDataProvider, IDNBConverterRatesToExchangeRates converterDNBRatesToExchangeRates)
        {
            if (dNBRemoteDataProvider == null)
            {
                throw new ArgumentNullException(nameof(dNBRemoteDataProvider));
            }
            if (converterDNBRatesToExchangeRates == null)
            {
                throw new ArgumentNullException(nameof(converterDNBRatesToExchangeRates));
            }

            DNBRemoteDataProvider = dNBRemoteDataProvider;
            ConverterDNBRatesToExchangeRates = converterDNBRatesToExchangeRates;
        }

        /// <summary>
        /// Should return exchange rates among the specified currencies that are defined by the source. But only those defined
        /// by the source, do not return calculated exchange rates. E.g. if the source contains "EUR/USD" but not "USD/EUR",
        /// do not return exchange rate "USD/EUR" with value calculated as 1 / "EUR/USD". If the source does not provide
        /// some of the currencies, ignore them.
        /// </summary>
        public override IEnumerable<ExchangeRate> GetExchangeRates(IEnumerable<Currency> currencies)
        {
            if (currencies == null)
            {
                throw new ArgumentNullException(nameof(currencies));
            }

            var remoteData = DNBRemoteDataProvider.GetData();            
            var exchangeRates = ConverterDNBRatesToExchangeRates.Convert(remoteData);            
            var filteredExchangRates = base.FilterRatesByCurrency(currencies, exchangeRates);

            return filteredExchangRates;
        }
    }
}
