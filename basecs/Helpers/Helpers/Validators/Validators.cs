using Microsoft.Security.Application;
using System.Text.RegularExpressions;

namespace basecs.Helpers.Helpers.Validators
{
    public static class Validators
    {
        public static string RemoveInjections(this string param)
        {
            param = Sanitizer.GetSafeHtmlFragment(param);

            return Regex.Replace(param, "[^0-9a-zA-Z ]+", "").Trim();
        }
    }
}
