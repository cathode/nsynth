using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;


namespace NSynth
{
    public static class FilterManager
    {
        public static void LoadFilters()
        {
            FilterManager.LoadFilters(Assembly.GetAssembly(typeof(FilterManager)));
        }

        public static void LoadFilters(Assembly from)
        {
            throw new NotImplementedException();
        }

        public static Filter GetFilter(string name)
        {
            throw new NotImplementedException();
        }
    }
}
