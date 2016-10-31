
using System;

using AppLocalizer;
using AppLocalizer.XmlRead;


namespace GenerateLocTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Serialization.SaveToXmlFile(Translate.Filename, CreateList());

                Console.WriteLine($"data saved: {Translate.Filename}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.Read();
        }

        private static PhraseList CreateList()
        {
            var pLst = new PhraseList();

            //---phrases
            pLst.Phrases.Add(new Phrase("1",
                             new[]
                             {
                                 "eng 1",
                                 "rus 1",
                                 "ger 1"
                             }));

            pLst.Phrases.Add(new Phrase("2",
                             new[]
                             {
                                 "eng 2",
                                 "rus 2",
                                 "ger 2"
                             }));

            pLst.Phrases.Add(new Phrase("TestLang_First",
                             new[]
                             {
                                 "english enum 1",
                                 "russian enum 1",
                                 "german enum  1"
                             }));

            pLst.Phrases.Add(new Phrase("TestLang_Second",
                             new[]
                             {
                                 "english enum 2",
                                 "russian enum 2",
                                 "german enum  2"
                             }));



            //---languages

            pLst.Languages.Add("English");
            pLst.Languages.Add("Русский");
            pLst.Languages.Add("Deutsch");

            //-------

            return pLst;
        }
    }
}
