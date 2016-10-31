using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

using AppLocalizer.XmlRead;


namespace AppLocalizer
{
    public static class Translate
    {
        #region private

        private static bool _isInitialized;
        private static NullReadOnlyDictionary<string, string[]> _dictionary = new NullReadOnlyDictionary<string, string[]>(new Dictionary<string, string[]>());
        private static LanguageDictionary _oneLangDictionary = new LanguageDictionary(new Dictionary<string, string>());
        private static byte _currentLanguage = byte.MinValue;
        private static NullReadOnlyDictionary<byte, string> _languages = new NullReadOnlyDictionary<byte, string>(new Dictionary<byte, string>());


        #endregion

        #region fields

        public static string Filename
        {
            get;
        } = AppDomain.CurrentDomain.BaseDirectory + @"\resources.xml";


        public static NullReadOnlyDictionary<string, string[]> Dictionary
        {
            get { return _dictionary; }
            private set
            {
                _dictionary = value;
                NotifyStaticPropertyChanged(nameof(Dictionary));
            }
        }


        public static LanguageDictionary OneLangDictionary
        {
            get { return _oneLangDictionary; }
            private set
            {
                _oneLangDictionary = value;
                NotifyStaticPropertyChanged(nameof(OneLangDictionary));
            }
        }


        public static byte CurrentLanguage
        {
            get { return _currentLanguage; }
            private set
            {
                _currentLanguage = value;

                var newDict = Dictionary.ToDictionary(pair => pair.Key, pair => pair.Value.Length > _currentLanguage ? pair.Value[_currentLanguage] : pair.Key);
                OneLangDictionary = new LanguageDictionary(newDict);

                NotifyStaticPropertyChanged(nameof(CurrentLanguage));
                NotifyStaticPropertyChanged(nameof(Dictionary));
            }
        }


       public static NullReadOnlyDictionary<byte, string> Languages
        {
            get { return _languages; }
            private set
            {
                if (Equals(_languages, value)) return;
                _languages = value;
                NotifyStaticPropertyChanged(nameof(Languages));
            }
        }

        #endregion

        #region public  methods
        

        public static void SetLanguage(byte languageIndex)
        {
            if(!_isInitialized) return;
            var contains = Languages.ContainsKey(languageIndex);
            if (contains)
            {
                CurrentLanguage = languageIndex;
            }
        }

    
        public static string Value(string key)
        {
            return OneLangDictionary[key];


            //try
            //{
            //    return Dictionary[key][(int)Language];
            //}
            //catch (Exception)
            //{
            //    return key; //string.Empty;
            //}
        }

       

        public static void Initialize()
        {
            if(_isInitialized) return;

            
            var lst = Serialization.LoadXmlFile(typeof(PhraseList), Filename);

            var phList = lst as PhraseList;
            if (phList == null) return;

            var dict = new Dictionary<string, string[]>();

            foreach (var phrase in phList.Phrases.
                Where(phrase => !dict.ContainsKey(phrase.PhraseKey)).
                Where(phrase => !string.IsNullOrEmpty(phrase.PhraseKey)))
            {
                dict.Add(phrase.PhraseKey, phrase.Values.ToArray());
            }

            Dictionary = new NullReadOnlyDictionary<string, string[]>(dict);

            //--------------------
            var langDict = new Dictionary<byte, string>();
            for (byte i = 0; i < phList.Languages.Count; i++)
            {
                langDict.Add(i, phList.Languages[i]);
            }
            Languages = new NullReadOnlyDictionary<byte, string>(langDict);
            //--------------------

            
            _isInitialized = true;
        }



        #endregion



        #region prop changed

        public static event EventHandler<PropertyChangedEventArgs> StaticPropertyChanged;
        private static void NotifyStaticPropertyChanged(string propertyName)
        {
            StaticPropertyChanged?.Invoke(null, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        
    }

    

   
}