using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sesshin.Service
{
    public static class Extentions
    {
        public static string ToString<T>(this T? value, string format, string coalesce = null)
        where T : struct, IFormattable
        {
            if (value == null)
            {
                return coalesce;
            }
            else
            {
                return value.Value.ToString(format, null);
            }
        }
    }
}
