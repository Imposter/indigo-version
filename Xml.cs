/*
*
*	Title: IndigoVersion
*	Authors: Imposter (Eyaz Rehman) [http://www.igonline.eu]
*	Date: 8/22/2015
*
*	Copyright (C) 2015 Indigo Games. All Rights Reserved.
*
*/

using System.Xml;
using System.IO;
using System.Xml.Serialization;

namespace IndigoVersion
{
    class Xml
    {
        public static bool Deserialize<T>(Stream stream, ref T obj)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            try
            {
                XmlReader reader = XmlReader.Create(stream);
                obj = (T)serializer.Deserialize(reader);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool Serialize<T>(Stream stream, T obj)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            try
            {
                XmlWriter writer = XmlWriter.Create(stream);
                serializer.Serialize(writer, obj);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
