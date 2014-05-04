using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.Web.ASPxEditors;

namespace ContentModel1._5.Common
{
    public class CustomText : ControlBase
    {
        public CustomText(ModuleField moduleField)
            : base(moduleField)
        {
        }

        public override System.Web.UI.Control Build()
        {
            base.Build();
            ASPxTextBox tb = new ASPxTextBox();
            tb.Width = ModuleField.Width;
            tb.Height = ModuleField.Height;
            tb.MaskSettings.Mask = ModuleField.DisplayFormat;
            //tb.DisplayFormatString = ModuleField.DisplayFormat;
            //目的是在与DB交互的时候，把非数字字符去除
            tb.MaskSettings.IncludeLiterals = MaskIncludeLiteralsMode.None;
            tb.ValidationSettings.RequiredField.IsRequired = ModuleField.IsRequired;
            tb.ValidationSettings.RequiredField.ErrorText = ModuleField.ErrorText;
            tb.NullText = ModuleField.NullText;
            if (ModuleField.CurrentValue == null)
            {
                tb.Text = ModuleField.DefaultValue.ToString();
            }
            else
            {
                tb.Text = ModuleField.CurrentValue.ToString();
            }
            return tb;
        }
    }
}