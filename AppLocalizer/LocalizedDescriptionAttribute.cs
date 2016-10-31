using System.ComponentModel;


namespace AppLocalizer
{
    public class LocalizedDescriptionAttribute : DescriptionAttribute
    {
        private static string Localize(string key)
        {
            return Translate.Value(key);
        }

        public LocalizedDescriptionAttribute(string key)
            : base(Localize(key))
        {
        }
    }
}