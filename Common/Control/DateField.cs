using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.Web.ASPxEditors;
using System.Web.UI.WebControls;

namespace ContentModel1._5.Common
{
    public class DateField : ControlBase
    {
        public DateField(ModuleField moduleField) : base(moduleField)
        {
        }
        public override System.Web.UI.Control Build()
        {
            base.Build();
            ASPxDateEdit de = new ASPxDateEdit();
            de.Width = ModuleField.Width;
            de.Height = ModuleField.Height;
            de.EditFormatString = ModuleField.DisplayFormat;
            de.ValidationSettings.RequiredField.IsRequired = ModuleField.IsRequired;
            de.ValidationSettings.RequiredField.ErrorText = ModuleField.ErrorText;
            de.NullText = ModuleField.NullText;
            if (ModuleField.CurrentValue != null)
            {
                de.Date = Convert.ToDateTime(ModuleField.CurrentValue);
            }
            else
            {
                de.Date = Convert.ToDateTime(ModuleField.DefaultValue);
            }
            return de;
        }
    }
}