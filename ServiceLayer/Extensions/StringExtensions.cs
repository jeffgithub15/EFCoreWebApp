using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Extensions
{
    public static class StringExtensions
    {
        public static string ConcatStr(this string txt, int length)
        {
            if (!string.IsNullOrEmpty(txt))
            {
                if (txt.Length > length)
                {
                    return $"{txt.Substring(0, length)} {(txt.Length > length ? "..." : "")}";
                }
                return txt;
            }
            return "";
        }
    }
}
