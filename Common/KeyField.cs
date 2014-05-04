using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContentModel1._5.Common
{
    public class KeyField
    {
        public string Key
        {
            get;
            set;
        }

        public string FieldName
        {
            get;
            set;
        }
        public KeyField(string key,string fieldName)
        {
            this.Key = key;
            this.FieldName = fieldName;
        }
    }
}