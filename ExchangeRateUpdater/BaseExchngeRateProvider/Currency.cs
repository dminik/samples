using System;

namespace ExchangeRateUpdater.BaseExchngeRateProvider
{
    public class Currency
    {
        public Currency(string code)
        {
            if (code == null)
            {
                throw new ArgumentNullException(nameof(code));
            }

            Code = code.ToUpperInvariant();
        }

        /// <summary>
        /// Three-letter ISO 4217 code of the currency.
        /// </summary>
        public string Code { get; private set; }
    }
}
