namespace ExchangeRateUpdater.DNBExchangeRateProvider
{
    public interface IDNBRemoteDataProvider
    {
        exchangerates GetData();
    }
}