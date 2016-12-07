using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFGoogleCalendarIntegration.Services
{
    public static class StringExtensions
    {
        public static string InjectParameters(this string str, IDictionary<string, string> parameters)
        {
            var newStr = str;
            foreach (var parameter in parameters)
            {
                var key = "{" + parameter.Key + "}";
                newStr = newStr.Replace(key, parameter.Value);
            }

            return newStr;
        }
    }
}
