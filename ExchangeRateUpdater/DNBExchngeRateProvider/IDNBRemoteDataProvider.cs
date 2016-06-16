namespace ExchangeRateUpdater.DNBExchngeRateProvider
{
    public interface IDNBRemoteDataProvider
    {
        exchangerates GetData();
    }
}