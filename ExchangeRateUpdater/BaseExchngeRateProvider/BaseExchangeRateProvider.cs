using System;
using System.Collections.Generic;
using System.Linq;

namespace ExchangeRateUpdater.BaseExchngeRateProvider
{
    public abstract class BaseExchangeRateProvider : IExchangeRateProvider
    {
        /// <summary>
        /// Should return exchange rates among the specified currencies that are defined by the source. But only those defined
        /// by the source, do not return calculated exchange rates. E.g. if the source contains "EUR/USD" but not "USD/EUR",
        /// do not return exchange rate "USD/EUR" with value calculated as 1 / "EUR/USD". If the source does not provide
        /// some of the currencies, ignore them.
        /// </summary>
        public abstract IEnumerable<ExchangeRate> GetExchangeRates(IEnumerable<Currency> currencies);

        protected IEnumerable<ExchangeRate> FilterRatesByCurrency(IEnumerable<Currency> currencies, IEnumerable<ExchangeRate> rates)
        {
            if (currencies == null)
            {
                throw new ArgumentNullException(nameof(currencies));
            }

            if (rates == null)
            {
                throw new ArgumentNullException(nameof(rates));
            }

            var currenciesNames = currencies.Select(c => c.Code.ToUpperInvariant());
            var filteredRates = rates.Where(x => currenciesNames.Contains(x.TargetCurrency.Code.ToUpperInvariant()));

            return filteredRates;
        }
    }
}
