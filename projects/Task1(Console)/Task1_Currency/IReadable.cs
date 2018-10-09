using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_Currency
{
    /// <summary>
    /// Interface for reading from file
    /// </summary>
    interface IReadable
    {
        void Read(string fileName);
    }
}

