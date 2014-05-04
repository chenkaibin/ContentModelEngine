using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.Web.ASPxEditors;
using System.Web.UI.WebControls;

namespace ContentModel1._5.Common
{
    public class TimeField : ControlBase
    {
        public TimeField(ModuleField moduleField)
            : base(moduleField)
        { 
        }
        public override System.Web.UI.Control Build()
        {
            base.Build();
            ASPxTimeEdit te = new ASPxTimeEdit();
            te.Width = ModuleField.Width;
            te.Height = ModuleField.Height;
            te.EditFormatString = ModuleField.DisplayFormat;
            te.ValidationSettings.RequiredField.IsRequired = ModuleField.IsRequired;
            te.ValidationSettings.RequiredField.ErrorText = ModuleField.ErrorText;
            //te.NullText = ModuleField.NullText;没有NullText方法
            if (ModuleField.CurrentValue != null)
            {
                te.DateTime = Convert.ToDateTime(ModuleField.CurrentValue);
            }
            else
            {
                te.DateTime = Convert.ToDateTime(ModuleField.DefaultValue);
            }
            return te;
        }
    }
}