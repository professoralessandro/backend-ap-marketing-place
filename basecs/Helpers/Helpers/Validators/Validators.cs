using Microsoft.Security.Application;
using System.Text.RegularExpressions;

namespace basecs.Helpers.Helpers.Validators
{
    public static class Validators
    {
        public static string RemoveInjections(string param)
        {
            param = Sanitizer.GetSafeHtmlFragment(param);

            param = Regex.Replace(param.Trim(), "[^0-9a-zA-Z ]+", "");

            return param;
        }
    }
}
