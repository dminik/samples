using System;
using System.Configuration;
using System.Xml;
using System.Xml.Serialization;

namespace ExchangeRateUpdater.DNBExchangeRateProvider
{
    public class DNBRemoteDataProvider : IDNBRemoteDataProvider
    {
        private Uri UrlDnbRates { get; set; }

        public DNBRemoteDataProvider()
        {
            var strDNBRatesUrl = ConfigurationManager.AppSettings["DNBRatesUrl"];
            UrlDnbRates = new Uri(strDNBRatesUrl);
        }

        public DNBRemoteDataProvider(Uri urlDNBRatesUrl)
        {
            if (urlDNBRatesUrl == null)            
                throw new ArgumentNullException(nameof(urlDNBRatesUrl));

            UrlDnbRates = urlDNBRatesUrl;
        }

        public exchangerates GetData()
        {            
            exchangerates rates;
           
            using (var reader = XmlReader.Create(UrlDnbRates.AbsoluteUri))
            {
                var ser = new XmlSerializer(typeof(exchangerates));
                rates = (exchangerates)ser.Deserialize(reader);
            }

            return rates;
        }
    }
}
