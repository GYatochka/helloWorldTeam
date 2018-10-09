using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Task1_Currency
{
    /// <summary>
    /// Additional class for converting currency
    /// </summary>
    public class CurrencyConverter
    {
      
        struct UAHConverter
        {
            public const float EUR = 32.76f;
            public const float USD = 28.16f;
        }
        struct EURConverter
        {
            public const float USD = 0.86f;
            public const float UAH = 0.031f;
        }
        struct USDConverter
        {
            public const float UAH = 0.036f;
            public const float EUR = 1.16f;
        }
      static List<float> Calculation(Dictionary<string, float> currencies, string CurrencyNameToConvert)
        {
            switch (CurrencyNameToConvert)
            {
                case "UAH":
                    List<float> UAHcurrencies = new List<float>(currencies.Count);
                    foreach (KeyValuePair<string, float> pair in currencies)
                    {
                        switch (pair.Key)
                        {
                            case "UAH":
                                UAHcurrencies.Add(pair.Value);
                                break;
                            case "USD":
                                UAHcurrencies.Add(pair.Value * UAHConverter.USD);
                                break;
                            case "EUR":
                                UAHcurrencies.Add(pair.Value * UAHConverter.EUR);
                                break;
                        }


                    }
                    return UAHcurrencies;
                case "USD":
                    List<float> USDcurrencies = new List<float>(currencies.Count);
                    foreach (KeyValuePair<string, float> pair in currencies)
                    {
                        switch (pair.Key)
                        {
                            case "UAH":
                                USDcurrencies.Add(pair.Value * USDConverter.UAH);
                                break;
                            case "USD":
                                USDcurrencies.Add(pair.Value);
                                break;
                            case "EUR":
                                USDcurrencies.Add(pair.Value * USDConverter.EUR);
                                break;
                        }
                    }
                    return USDcurrencies;
                case "EUR":
                    List<float> EURcurrencies = new List<float>(currencies.Count);
                    foreach (KeyValuePair<string, float> pair in currencies)
                    {
                        switch (pair.Key)
                        {
                            case "UAH":
                                EURcurrencies.Add(pair.Value * EURConverter.UAH);
                                break;
                            case "USD":
                                EURcurrencies.Add(pair.Value * EURConverter.USD);
                                break;
                            case "EUR":
                                EURcurrencies.Add(pair.Value);
                                break;
                        }
                    }
                    return EURcurrencies;
                default:
                    throw new Exception("wrong type of currency!");
                    return new List<float>();
            }
        }
        public static void Convert(Dictionary<string, float> currencies,string path)
        {

            /// <summary>
            /// method for converting different currency in one
            /// </summary>
            List<float> convertedCurrencies;
            Console.Write("Enter currency to convert(USD/EUR/UAH): ");
            string CurrencyNameToConvert = Console.ReadLine();
            convertedCurrencies = Calculation(currencies, CurrencyNameToConvert);
            CurrencyStorage.WriteInFile(convertedCurrencies, CurrencyNameToConvert, path);
        }
      
        

    }
}