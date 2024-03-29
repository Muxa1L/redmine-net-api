/*
   Copyright 2011 - 2014 Adrian Popescu, Dorin Huzum.

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

//#if RUNNING_ON_35_OR_ABOVE
using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using Redmine.Net.Api.Types;

namespace Redmine.Net.Api.JSonConverters
{
    public class AttachmentConverter : JavaScriptConverter
    {
        #region Overrides of JavaScriptConverter

        public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
        {
            if (dictionary != null)
            {
                var attachment = new Attachment();

                attachment.Id = dictionary.GetValue<int>("id");
                attachment.Description = dictionary.GetValue<string>("description");
                attachment.Author = dictionary.GetValueAsIdentifiableName("author");
                attachment.ContentType = dictionary.GetValue<string>("content_type");
                attachment.ContentUrl = dictionary.GetValue<string>("content_url");
                attachment.CreatedOn = dictionary.GetValue<DateTime?>("created_on");
                attachment.FileName = dictionary.GetValue<string>("filename");
                attachment.FileSize = dictionary.GetValue<int>("filesize");

                return attachment;
            }

            return null;
        }

        public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer) { return null; }

        public override IEnumerable<Type> SupportedTypes { get { return new List<Type>(new[] { typeof(Attachment) }); } }

        #endregion
    }
}
//#endif