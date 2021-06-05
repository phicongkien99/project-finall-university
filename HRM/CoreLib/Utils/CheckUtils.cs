using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLib.Utils
{
    public static class CheckUtils
    {
        /// <summary>
        /// Kiểm tra ký tự tiếng việt
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool ContainsUnicodeCharacter(string input)
        {
            bool ok = false;
            foreach (char c in input)
            {
                if ((c > 47 && c < 58))
                    ok = true;
                else if ((c > 64 && c < 91))
                    ok = true;
                else if ((c > 96 && c < 123))
                {
                    ok = true;
                }
                else if (c == 45 || c == 46 || c == 95)
                {
                    ok = true;
                }
                else
                {
                    ok = false;
                    break;
                }
            }
            return ok;
        }
    }
}
