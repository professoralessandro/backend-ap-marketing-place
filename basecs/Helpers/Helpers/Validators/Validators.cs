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
    }
}
