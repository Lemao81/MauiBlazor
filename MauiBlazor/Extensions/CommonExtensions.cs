using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBlazor.Extensions
{
    internal static class CommonExtensions
    {
        public static string ToTwoDigitString(this double d) => d.ToString("0.##");

        public static string ToTwoDigitString(this double? d) => d.HasValue ? d.Value.ToTwoDigitString() : string.Empty;

        public static bool IsNullOrEmpty(this string str) => string.IsNullOrEmpty(str);
    }
}
