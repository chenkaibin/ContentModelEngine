using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.Web.ASPxEditors;
using System.Web.UI;
using System.Web.UI.WebControls;
using ContentModel1._5.Entities;
using System.Text;
using DevExpress.Web.ASPxHiddenField;
using DevExpress.Web.ASPxPanel;

namespace ContentModel1._5.Common
{
    public class MultiDropDownList : ControlBase
    {
        public MultiDropDownList(ModuleField moduleField)
            : base(moduleField)
        {
        }
        public override System.Web.UI.Control Build()
        {
            base.Build();
            ASPxDropDownEdit ddedit = new ASPxDropDownEdit();
            ASPxHiddenField hfddedit = new ASPxHiddenField();
            ASPxPanel panel = new ASPxPanel();
            ddedit.Width = ModuleField.Width;
            ddedit.Height = ModuleField.Height;
            ddedit.ValidationSettings.RequiredField.IsRequired = ModuleField.IsRequired;
            ddedit.ValidationSettings.RequiredField.ErrorText = ModuleField.ErrorText;
            ddedit.ReadOnly = true;
            ddedit.Text = ModuleField.CurrentValue == null ? ModuleField.DefaultValue == null ? null : ModuleField.DefaultValue.ToString() : ModuleField.CurrentValue.ToString();
            ddedit.ClientInstanceName = "dropdown";
            ddedit.DropDownWindowTemplate = new MyTemplate(ModuleField.CodeCat, hfddedit);
            ddedit.ClientSideEvents.TextChanged = "SynchronizeListBoxValues";
            ddedit.ClientSideEvents.DropDown = "SynchronizeListBoxValues";
            //ddedit.Enabled 可用来做只读

            //hf
            hfddedit.ClientInstanceName = "hfddedit";
            hfddedit.Clear();
            if (ModuleField.CurrentCode != null)
            {
                List<string> codelist = ModuleField.CurrentCode.ToString().Split(';').ToList();
                foreach (string code in codelist)
                {
                    hfddedit.Add(code, "");
                }
            }
            panel.Controls.Add(ddedit);
            panel.Controls.Add(hfddedit);
            return panel;
        }
    }
    //实现添加列表项
    class MyTemplate : ITemplate
    {
        private string CodeCat;
        public MyTemplate(string codecat, ASPxHiddenField hfddedit)
        {
            CodeCat = codecat;
        }
        public void InstantiateIn(System.Web.UI.Control container)
        {
            ASPxListBox listbox = new ASPxListBox();
            listbox.ClientInstanceName = "listbox";
            listbox.Width = Unit.Parse("100%");
            listbox.ID = "listBox";
            listbox.SelectionMode = ListEditSelectionMode.CheckColumn;
            List<DictionaryItem> itemslist = new List<DictionaryItem>();
            using (TestDBEntities entity = new TestDBEntities())
            {
                itemslist = entity.DictionaryItem.Where(oo => oo.DictionaryItemCode.StartsWith(CodeCat) && oo.DictionaryItemCode.Length == 7).ToList();
            }
            StringBuilder allitem = new StringBuilder();
            foreach (DictionaryItem item in itemslist)
            {
                allitem.Append(item.DictionaryItemValue + ";");
            }
            allitem.Remove(allitem.Length - 1, 1);
            listbox.Items.Add("(全选)", allitem.ToString());
            foreach (DictionaryItem item in itemslist)
            {
                listbox.Items.Add(item.DictionaryItemName, item.DictionaryItemValue);
            }
            listbox.ClientSideEvents.SelectedIndexChanged = "OnListBoxSelectionChanged";
            container.Controls.Add(listbox);
        }
    }
}