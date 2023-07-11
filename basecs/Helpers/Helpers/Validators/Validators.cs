using basecs.Models;
using Microsoft.Security.Application;
using System.Text.RegularExpressions;

namespace basecs.Helpers.Helpers.Validators
{
    public static class Validators
    {
        public static string RemoveInjections(this string param)
        {
            return !string.IsNullOrEmpty(param) ? Regex.Replace(Sanitizer.GetSafeHtmlFragment(param), "[^0-9a-zA-Z ]+", "").Trim() : string.Empty;
        }

        public static string FoneMPSanitizer(this string param)
        {
            if (param.Length > 9)
            {
                return param.Substring(param.Length - 9);
            }

            return param;
        }
    }
}
