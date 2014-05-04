using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.Web.ASPxEditors;
using System.Web.UI.WebControls;

namespace ContentModel1._5.Common
{
    public class Money : ControlBase
    {
        public Money(ModuleField moduleField)
            : base(moduleField)
        {
        }

        public override System.Web.UI.Control Build()
        {
            base.Build();
            ASPxSpinEdit se = new ASPxSpinEdit();
            se.Width = ModuleField.Width;
            se.Height = ModuleField.Height;
            se.MaxLength = ModuleField.MaxLength;
            se.MaxValue = Convert.ToDecimal(ModuleField.MaxValue);
            se.MinValue = Convert.ToDecimal(ModuleField.MinValue);
            se.DisplayFormatString = ModuleField.DisplayFormat;
            se.ValidationSettings.RequiredField.IsRequired = ModuleField.IsRequired;
            se.ValidationSettings.RequiredField.ErrorText = ModuleField.ErrorText;
            se.Number = ModuleField.CurrentValue == null ? ModuleField.DefaultValue == null ? Decimal.Zero : Convert.ToDecimal(ModuleField.DefaultValue) : Convert.ToDecimal(ModuleField.CurrentValue);
            se.NullText = ModuleField.NullText;
            return se;
        }
    }
}