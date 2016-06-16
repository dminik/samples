using System.Collections.Generic;

using ExchangeRateUpdater.BaseExchngeRateProvider;

namespace ExchangeRateUpdater.DNBExchangeRateProvider
{
    public interface IDNBConverterRatesToExchangeRates
    {
        IEnumerable<ExchangeRate> Convert(exchangerates xmlEntities);
    }
}