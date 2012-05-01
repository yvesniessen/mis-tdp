using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;


namespace WCF_WebService
{
     [ServiceContract]
    interface interfaceTest
    {
        [OperationContract]
        string Add(int x, int y);
    }
}
