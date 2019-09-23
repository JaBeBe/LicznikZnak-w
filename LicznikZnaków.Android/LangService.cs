using LicznikZnaków.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(LicznikZnaków.Droid.LangService))]
namespace LicznikZnaków.Droid
{
    public class LangService : ILangService
    {     

        public string GetLangCode()
        {
            var droidLocale = Java.Util.Locale.Default;

            return droidLocale.ToString().Replace("_", "-").TrimEnd('-');
        }
    }
}