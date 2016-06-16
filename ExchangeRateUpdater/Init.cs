using ExchangeRateUpdater.BaseExchngeRateProvider;
using ExchangeRateUpdater.DNBExchangeRateProvider;

using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace ExchangeRateUpdater
{
    class Init
    {
        public static void InitServiceLocator()
        {
            var container = new UnityContainer();

            container.RegisterType<IDNBRemoteDataProvider, DNBRemoteDataProvider>(new ContainerControlledLifetimeManager());
            container.RegisterType<IDNBConverterRatesToExchangeRates, DNBConverterRatesToExchangeRates>(new ContainerControlledLifetimeManager());
            container.RegisterType<IExchangeRateProvider, DNBExchangeRateProvider.DNBExchangeRateProvider>(new ContainerControlledLifetimeManager());

            ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(container));
        }
    }
}
