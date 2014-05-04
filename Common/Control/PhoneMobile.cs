using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.Web.ASPxEditors;

namespace ContentModel1._5.Common
{
    public class PhoneMobile : ControlBase
    {
        public PhoneMobile(ModuleField moduleField)
            : base(moduleField)
        {            
        }
        public override System.Web.UI.Control Build()
        {            
            base.Build();
            ASPxTextBox tb = new ASPxTextBox();
            tb.Width = ModuleField.Width;
            tb.Height = ModuleField.Height;
            tb.MaskSettings.Mask = "(999)9999-9999";
            tb.MaskSettings.ErrorText = "格式错误！";
            tb.MaskSettings.IncludeLiterals = MaskIncludeLiteralsMode.None;
            tb.ValidationSettings.RequiredField.IsRequired = ModuleField.IsRequired;
            tb.ValidationSettings.RequiredField.ErrorText = ModuleField.ErrorText;
            tb.Text = ModuleField.CurrentValue == null ? ModuleField.DefaultValue == null ? null : ModuleField.DefaultValue.ToString() : ModuleField.CurrentValue.ToString();
            tb.NullText = ModuleField.NullText;
            return tb;
        }
    }
}