using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_Currency
{
    class Currency: IReadable
    {
        private string _currencyName;
        private int _ammount;

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
        public int Ammount {
            get {
                return _ammount;
            }
            set {
                if (value > 0)
                {
                    _ammount = value;
                }
                else
                {
                    throw new NotSupportedException("Wrong valeu!");
                }
            }
        }

        public void Read()
        {
            return;
        }
    }
}
