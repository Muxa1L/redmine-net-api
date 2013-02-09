/*
   Copyright 2011 - 2013 Adrian Popescu, Dorin Huzum.

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Redmine.Net.Api
{
    public static partial class RedmineSerialization
    {
        /// <summary>
        /// Serializes the specified System.Object and writes the XML document to a string.
        /// </summary>
        /// <typeparam name="T">The type of objects to serialize.</typeparam>
        /// <param name="obj">The object to serialize.</param>
        /// <returns>The System.String that contains the XML document.</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static string ToXML<T>(T obj) where T : class
        {
            var xws = new XmlWriterSettings{OmitXmlDeclaration = true};
            using (var stringWriter = new StringWriter())
            {
                using (var xmlWriter = XmlWriter.Create(stringWriter, xws))
                {
                    var sr = new XmlSerializer(typeof (T));
                    sr.Serialize(xmlWriter, obj);
                    return stringWriter.ToString();
                }
            }
        }

        /// <summary>
        /// Deserializes the XML document contained by the specific System.String.
        /// </summary>
        /// <typeparam name="T">The type of objects to deserialize.</typeparam>
        /// <param name="xml">The System.String that contains the XML document to deserialize.</param>
        /// <returns>The T object being deserialized.</returns>
        /// <exception cref="System.InvalidOperationException"> An error occurred during deserialization. The original exception is available
        /// using the System.Exception.InnerException property.</exception>
        public static T FromXML<T>(string xml) where T : class
        {
            using (var text = new StringReader(xml))
            {
                var sr = new XmlSerializer(typeof (T));
                return sr.Deserialize(text) as T;
            }
        }

        /// <summary>
        /// Deserializes the XML document contained by the specific System.String.
        /// </summary>
        /// <param name="xml">The System.String that contains the XML document to deserialize.</param>
        /// <param name="type">The type of objects to deserialize.</param>
        /// <returns>The System.Object being deserialized.</returns>
        /// <exception cref="System.InvalidOperationException"> An error occurred during deserialization. The original exception is available
        /// using the System.Exception.InnerException property.</exception>
        public static object FromXML(string xml, Type type)
        {
            using (var text = new StringReader(xml))
            {
                var sr = new XmlSerializer(type);
                return sr.Deserialize(text);
            }
        }
    }
}