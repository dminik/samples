using System.Collections.Generic;

using ExchangeRateUpdater.BaseExchngeRateProvider;

namespace ExchangeRateUpdater.DNBExchngeRateProvider
{
    public interface IDNBConverterRatesToExchangeRates
    {
        IEnumerable<ExchangeRate> Convert(exchangerates xmlEntities);
    }
}