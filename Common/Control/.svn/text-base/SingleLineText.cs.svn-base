using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.Web.ASPxPanel;
using DevExpress.Web.ASPxEditors;
using System.Web.UI.WebControls;


namespace ContentModel1._5.Common
{
    public class SingleLineText : ControlBase
    {
        public SingleLineText(ModuleField moduleField): base(moduleField)
        {

        }
        public override System.Web.UI.Control Build()
        {
            base.Build();
            ASPxTextBox tb = new ASPxTextBox();            
            tb.Width = ModuleField.Width;
            tb.Height = ModuleField.Height;
            tb.MaxLength = ModuleField.MaxLength;
            tb.ValidationSettings.RequiredField.IsRequired = ModuleField.IsRequired;
            tb.ValidationSettings.RequiredField.ErrorText = ModuleField.ErrorText;
            tb.NullText = ModuleField.NullText;
            tb.Text = ModuleField.CurrentValue == null ? ModuleField.DefaultValue == null ? null : ModuleField.DefaultValue.ToString() : ModuleField.CurrentValue.ToString();
            return tb;
        }
    }
}