using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.Web.ASPxEditors;
using ContentModel1._5.Entities;

namespace ContentModel1._5.Common
{
    public class SingleDropDownList : ControlBase
    {
        public SingleDropDownList(ModuleField moduleField)
            : base(moduleField)
        {

        }
        public override System.Web.UI.Control Build()
        {
            base.Build();
            ASPxComboBox cbox = new ASPxComboBox();
            cbox.Width = ModuleField.Width;
            cbox.Height = ModuleField.Height;
            cbox.ValidationSettings.RequiredField.IsRequired = ModuleField.IsRequired;
            cbox.ValidationSettings.RequiredField.ErrorText = ModuleField.ErrorText;
            List<DictionaryItem> itemslist = new List<DictionaryItem>();
            using (TestDBEntities entity = new TestDBEntities())
            {
                itemslist = entity.DictionaryItem.Where(oo => oo.DictionaryItemCode.StartsWith(ModuleField.CodeCat) && oo.DictionaryItemCode.Length == 7).ToList();
            }
            foreach (DictionaryItem item in itemslist)
            {
                cbox.Items.Add(item.DictionaryItemName, item.DictionaryItemValue);
            }
            cbox.Text = ModuleField.CurrentValue == null ? ModuleField.DefaultValue == null ? null : ModuleField.DefaultValue.ToString() : ModuleField.CurrentValue.ToString();
            return cbox;
        }
    }
}