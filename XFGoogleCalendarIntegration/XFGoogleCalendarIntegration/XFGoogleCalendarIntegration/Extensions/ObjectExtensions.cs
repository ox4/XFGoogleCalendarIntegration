using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace XFGoogleCalendarIntegration.Extensions
{
    public static class ObjectExtensions
    {
        public static string ToQueryString(this object obj)
        {
            var properties = obj.GetType().GetTypeInfo().DeclaredProperties
                .Where(x => x.GetValue(obj, null) != null)
                .Select(x =>
                {
                    string objToString;
                    var value = x.GetValue(obj, null);
                    if (value is DateTime)
                    {
                        objToString = ((DateTime) value).ToRFC3339();
                    }
                    else
                    {
                        objToString = value.ToString();
                    }

                    return ConvertFirstLetterToLowerCase(x.Name) + "=" + WebUtility.UrlEncode(objToString);
                });

            return "?" + string.Join("&", properties.ToArray());
        }

        private static string ConvertFirstLetterToLowerCase(string text)
        {
            return char.ToLowerInvariant(text[0]) + text.Substring(1);
        }
    }
}
