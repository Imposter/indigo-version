/*
*
*	Title: IndigoVersion
*	Authors: Imposter
*	Date: 8/22/2015
*
*	Copyright (C) 2018 Imposter. All Rights Reserved.
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
            var serializer = new XmlSerializer(typeof(T));

            try
            {
                var reader = XmlReader.Create(stream);
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
            var serializer = new XmlSerializer(typeof(T));

            try
            {
                var writer = XmlWriter.Create(stream);
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
