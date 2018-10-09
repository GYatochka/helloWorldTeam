using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_Currency
{
    using System.IO;

    public class Currency
    {
        private string _currencyName;
        private float _amount;

        public string CurrencyName {
            get
            {
                return _currencyName;
            }
            set
            {
                _currencyName = value;
            }
        }
        public float Amount
        {
            get
            {
                return _amount;
            }
            set {
                if (value > 0)
                {
                    _amount = value;
                }
                else
                {
                    throw new Exception("Wrong value!");
                }
            }
        }

        public Currency()
        {
            _amount = 1;
            _currencyName = "UAH";
        }
        public Currency(string currencyName, float amount)
        {
            Amount = amount;
            _currencyName = currencyName;
        }

        /// <summary>
        /// override "ToString" method for writing our currency objects
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Currency: " + _amount + " " + _currencyName;
        }

    }
}
