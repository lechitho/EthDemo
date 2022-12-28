using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EthDemo.Util
{
    public static class ConvertHelper
    {
        public static string ToHex(this int value)
        {
            return String.Format("0x{0:X}", value);
        }
        public static int FromHex(string value)
        {
            // strip the leading 0x
            if (value.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
            {
                value = value.Substring(2);
            }
            return Int32.Parse(value, NumberStyles.HexNumber);
        }
    }
}
