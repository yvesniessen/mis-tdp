using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace PhoneWebService
{
    /// <summary>
    /// Zusammenfassungsbeschreibung für Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Um das Aufrufen dieses Webdiensts aus einem Skript mit ASP.NET AJAX zuzulassen, heben Sie die Auskommentierung der folgenden Zeile auf. 
    // [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {
        private List<String> _registeredPhones;
        public String RegisteredPhones
        {
            set { if(!_registeredPhones.Contains(value))
                        _registeredPhones.Add( value) ; }
        }

        [WebMethod]
        public string registerPhone(String phoneID)
        {
            return phoneID;
        }

        [WebMethod]
        public void showRegisteredClients()
        {
            foreach (var item in _registeredPhones)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}