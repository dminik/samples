using System;

namespace ExchangeRateUpdater.BaseExchngeRateProvider
{
    public class ExchangeRate
    {
        public ExchangeRate(Currency sourceCurrency, Currency targetCurrency, decimal value)
        {
            if (sourceCurrency == null)
            {
                throw new ArgumentNullException(nameof(sourceCurrency));
            }
            if (targetCurrency == null)
            {
                throw new ArgumentNullException(nameof(targetCurrency));
            }
            SourceCurrency = sourceCurrency;
            TargetCurrency = targetCurrency;
            Value = value;
        }

        public Currency SourceCurrency { get; private set; }

        public Currency TargetCurrency { get; private set; }

        public decimal Value { get; private set; }

        public override string ToString()
        {
            return SourceCurrency.Code + "/" + TargetCurrency.Code + "=" + Value;
        }
    }
}
