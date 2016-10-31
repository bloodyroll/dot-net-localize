using System;
using System.IO;
using System.Xml.Serialization;


namespace AppLocalizer.XmlRead
{
    public static class Serialization
    {
        /// <summary>
        /// Сохранение текущего класса
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool SaveToXmlFile(string filename, object obj)
        {
            try
            {
                using (var fs = new FileStream(filename, FileMode.Create, FileAccess.ReadWrite))
                {
                    var xs = new XmlSerializer(obj.GetType());
                    xs.Serialize(fs, obj);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public static object LoadXmlFile(Type type, string fileName)
        {
            var serializer = new XmlSerializer(type);
            try
            {
                using (var file = new StreamReader(fileName))
                {
                    return serializer.Deserialize(file);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}