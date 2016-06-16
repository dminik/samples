using System;
using System.Collections.Generic;
using System.Globalization;

using ExchangeRateUpdater.BaseExchngeRateProvider;

namespace ExchangeRateUpdater.DNBExchngeRateProvider
{
    class DNBConverterRatesToExchangeRates : IDNBConverterRatesToExchangeRates
    {
        public IEnumerable<ExchangeRate> Convert(exchangerates xmlEntities)
        {
            if (xmlEntities == null)
            {
                throw new ArgumentNullException(nameof(xmlEntities));
            }

            var result = new List<ExchangeRate>();

            foreach (var currentCurrency in xmlEntities.dailyrates.currency)
            {
                var sourceCurrency = new Currency(xmlEntities.refcur);
                var targetCurrency = new Currency(currentCurrency.code);

                if(currentCurrency.rate == "-") // no rate, skip
                    continue;

                decimal rate;
                if (!decimal.TryParse(currentCurrency.rate, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture,  out rate))
                {
                    throw new InvalidCastException(string.Format("Can't convert '{0}' to decimal", currentCurrency.rate));
                }

                var newExchangeRate = new ExchangeRate(sourceCurrency, targetCurrency, rate);

                result.Add(newExchangeRate);
            }

            return result;
        }
    }
}
