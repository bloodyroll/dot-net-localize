using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace AppLocalizer
{
    public class NullReadOnlyDictionary<TKey, TValue> : ReadOnlyDictionary<TKey, TValue>
    {
        public NullReadOnlyDictionary(IDictionary<TKey, TValue> dictionary)
            : base(dictionary)
        {

        }
        public new TValue this[TKey key]
        {
            get
            {
                TValue value;
                return TryGetValue(key, out value) ? value : default(TValue);
            }
        }
    }
    public class LanguageDictionary : NullReadOnlyDictionary<string, string>
    {
        public LanguageDictionary(IDictionary<string, string> dictionary)
            : base(dictionary)
        {

        }
        public new string this[string key]
        {
            get
            {
                if (key == null) return string.Empty;
                string value;
                return TryGetValue(key, out value) ? value : key;
            }
        }
    }
}