using System.Collections.Generic;
using System.Xml.Serialization;


namespace AppLocalizer.XmlRead
{
    [XmlType("Phrase")]
    public class Phrase
    {
        #region ctors

        internal Phrase()
        {

        }

        public Phrase(string key, IEnumerable<string> values)
        {
            Values = new List<string>(values);
            PhraseKey = key;
        }

        #endregion

        #region fields

        public string PhraseKey;

        
        public List<string> Values;

        #endregion


    }

    [XmlRoot("Phrases")]
    [XmlInclude(typeof(Phrase))]
    public class PhraseList
    {
        #region ctors

        public PhraseList()
        {
            
        }

        #endregion

        
        #region fields
        
        //[XmlArray("PhraseArray")]
        //[XmlArrayItem("PhraseObject")]
        public List<Phrase> Phrases = new List<Phrase>();

        public List<string> Languages = new List<string>();

        #endregion

        
    }
}