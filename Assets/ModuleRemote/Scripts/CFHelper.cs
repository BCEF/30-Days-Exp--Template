using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using System.Xml;
using System.Xml.Serialization;



    public class CFHelper
    {

        /// <summary>
        /// It saves the specified object’s data into a string.
        /// </summary>
        public static string GetXMLString(object data)
        {

            using (StringWriter writer = new StringWriter())
            {
                new XmlSerializer(data.GetType()).Serialize((TextWriter)writer, data);
                return writer.ToString();
            }

        }


        /// <summary>
        /// It saves the specified object’s data into a XML file.
        /// </summary>
        public static void SaveData(string fileName, object data)
        {
            string path = fileName;
            Stream stream = File.Create(path);
            XmlSerializer serializer = new XmlSerializer(data.GetType());
            using (XmlWriter writer = new XmlTextWriter(stream, Encoding.Unicode))
            {
                serializer.Serialize(writer, data);
                writer.Close();
            }

            // Close the file
            stream.Close();
        }

        /// <summary>
        /// It reads from a XML file into the specified type class.
        /// </summary>
        public static object LoadData(string fileName, Type type)
        {

            try
            {
                string path = fileName;
                Stream stream = File.OpenRead(path);
                XmlSerializer serializer = new XmlSerializer(type);

                object obj = serializer.Deserialize(stream);

                stream.Close();
                return obj;
            }
#pragma warning disable CS0168 // 声明了变量，但从未使用过
        catch (Exception ex)
#pragma warning restore CS0168 // 声明了变量，但从未使用过
        {
                
            }
            return null;

        }

        public static object GetObject(string xmlString, Type type)
        {
            try
            {

                XmlSerializer serializer = new XmlSerializer(type);
                using (StringReader reader = new StringReader(xmlString))
                {
                    return serializer.Deserialize(reader);
                }

            }
#pragma warning disable CS0168 // 声明了变量，但从未使用过
        catch (Exception ex)
#pragma warning restore CS0168 // 声明了变量，但从未使用过
        {

            }
            return null;

        }

    }

