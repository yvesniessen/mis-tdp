using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WCF_WebService
{
    class Test : interfaceTest
    {
        public string Add(int x, int y)
        {
            int total = x + y;
            return total.ToString();
        }
    }
}
