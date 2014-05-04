using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.Web.ASPxEditors;

namespace ContentModel1._5.Common
{
    public class MultiLineNoHtml : ControlBase
    {
        public MultiLineNoHtml(ModuleField moduleField): base(moduleField)
        {
            
        }
        public override System.Web.UI.Control Build()
        {
            base.Build();
            ASPxMemo memo = new ASPxMemo();
            memo.Width = ModuleField.Width;
            memo.Height = ModuleField.Height;
            memo.ValidationSettings.RequiredField.IsRequired = ModuleField.IsRequired;
            memo.ValidationSettings.RequiredField.ErrorText = ModuleField.ErrorText;
            memo.NullText = ModuleField.NullText;
            memo.Text = ModuleField.CurrentValue == null ? ModuleField.DefaultValue == null ? null : ModuleField.DefaultValue.ToString() : ModuleField.CurrentValue.ToString();
            return memo;
        }
    }
}