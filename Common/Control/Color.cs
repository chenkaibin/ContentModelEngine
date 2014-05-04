using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.Web.ASPxEditors;

namespace ContentModel1._5.Common
{
    public class Color : ControlBase
    {
        public Color(ModuleField moduleField)
            : base(moduleField)
        {
        }

        public override System.Web.UI.Control Build()
        {
            base.Build();
            ASPxColorEdit ce = new ASPxColorEdit();
            ce.Width = ModuleField.Width;
            ce.Height = ModuleField.Height;
            ce.ValidationSettings.RequiredField.IsRequired = ModuleField.IsRequired;
            ce.ValidationSettings.RequiredField.ErrorText = ModuleField.ErrorText;
            ce.NullText = ModuleField.NullText;
            //CurrentValue值为App_ 表中的值；DefaultValue值为ModelField表中的值
            if (ModuleField.CurrentValue == null)
            {
                ce.Value = ModuleField.DefaultValue;
            }
            else
            {
                ce.Value = ModuleField.CurrentValue;
            }
            return ce;
        }
    }
}