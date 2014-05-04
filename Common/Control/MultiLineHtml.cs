using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxHtmlEditor;
 
namespace ContentModel1._5.Common
{
    public class MultiLineHtml : ControlBase
    {
        public MultiLineHtml(ModuleField moduleField)
            : base(moduleField)
        {            
        }
        public override System.Web.UI.Control Build()
        {
            base.Build();
            ASPxHtmlEditor he = new ASPxHtmlEditor();
            he.Width = ModuleField.Width;
            he.Height = ModuleField.Height;
            he.SettingsValidation.RequiredField.IsRequired = ModuleField.IsRequired;
            he.SettingsValidation.RequiredField.ErrorText = ModuleField.ErrorText;
            he.Html = ModuleField.CurrentValue == null ? ModuleField.DefaultValue == null ? null : ModuleField.DefaultValue.ToString() : ModuleField.CurrentValue.ToString();
            return he;
        }
    }
}