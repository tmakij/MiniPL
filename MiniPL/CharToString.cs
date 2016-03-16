using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniPL
{
    public static class CharToString
    {
        public static string Convert(char ToConvert)
        {
            switch (ToConvert)
            {
                case '\0':
                    return "null character";
                case ' ':
                    return "space";
                case '\u0009':
                    return "tab";
                case '\n':
                    return "newline";
                case '\r':
                    return "carriage return";
                default:
                    return ToConvert.ToString();
            }
        }
    }
}
