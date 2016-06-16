namespace ExchangeRateUpdater.DNBExchngeRateProvider
{    
    public class exchangerates
    {                
        public exchangeratesDailyrates dailyrates { get; set; }
                
        [System.Xml.Serialization.XmlAttribute()]
        public string refcur { get; set; }        
    }
        
    public class exchangeratesDailyrates
    {        
        [System.Xml.Serialization.XmlElementAttribute("currency")]
        public exchangeratesDailyratesCurrency[] currency { get; set; }
    }
        
    public class exchangeratesDailyratesCurrency
    {        
        [System.Xml.Serialization.XmlAttribute()]
        public string code { get; set; }
                
        [System.Xml.Serialization.XmlAttribute()]
        public string rate { get; set; }
    }
}
