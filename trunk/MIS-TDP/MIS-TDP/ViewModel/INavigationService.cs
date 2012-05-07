using System;
using System.Collections.Generic;

namespace MIS_TDP
{
    public interface INavigationService
    {
        void Navigate(string uri);
        void Navigate(string uri, IDictionary<string, string> parameters);
    }
}
