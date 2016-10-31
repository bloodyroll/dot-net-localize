using System;
using System.Collections.Generic;

using AppLocalizer;
using AppLocalizer.XmlRead;


namespace AppLocTest
{
    class Program
    {
        static void Main(string[] args)
        {

            var ph1 = new Phrase("1", new List<string> { "eng1", "rus1" });
            var ph2 = new Phrase("2", new List<string> { "eng2", "rus2" });

            var pLst = new PhraseList();
            pLst.Phrases.Add(ph1);
            pLst.Phrases.Add(ph2);

            pLst.Languages.Add("English");
            pLst.Languages.Add("Русский");
            pLst.Languages.Add("Deutsch");


            var filename = AppDomain.CurrentDomain.BaseDirectory + @"\somefile.xml";


            Serialization.SaveToXmlFile(filename, pLst);


            //var lst = Serialization.LoadXmlFile(typeof (PhraseList), filename);

            Console.WriteLine(Translate.Dictionary["1"][0]);
            Console.WriteLine(Translate.Dictionary["2"][0]);


            Console.Read();
        }
    }
}
