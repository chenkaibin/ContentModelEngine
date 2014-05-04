using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxPanel;
using DevExpress.Web.ASPxHiddenField;
using ContentModel1._5.Entities;

namespace ContentModel1._5.Common
{
    public class CheckBox:ControlBase
    {
        public CheckBox(ModuleField moduleField)
            : base(moduleField)
        { 
        }
        /// <summary>
        /// 用一个foreach的函数填入相关信息
        /// </summary>
        /// <returns></returns>
        public override System.Web.UI.Control Build()
        {
            base.Build();
            ASPxPanel panel = new ASPxPanel();
            ASPxCheckBox checkbox;
            ASPxHiddenField CBhiddenfield = new ASPxHiddenField();
            ASPxHiddenField CBhiddenfieldc = new ASPxHiddenField();
            ASPxHiddenField CBhiddenfieldall = new ASPxHiddenField();
            CBhiddenfield.ClientInstanceName = "CBhiddenfield";
            CBhiddenfield.Clear();
            CBhiddenfieldc.ClientInstanceName = "CBhiddenfieldc";
            CBhiddenfieldc.Clear();
            CBhiddenfieldall.ClientInstanceName = "CBhiddenfieldall";
            CBhiddenfieldall.Clear();
            //先添加隐藏控件
            panel.Controls.Add(CBhiddenfield);
            panel.Controls.Add(CBhiddenfieldc);
            panel.Controls.Add(CBhiddenfieldall);
            string selected = ModuleField.CurrentValue == null ? ModuleField.DefaultValue == null ? null : ModuleField.DefaultValue.ToString() : ModuleField.CurrentValue.ToString();
            List<string> selectedlist=new List<string>();
            if (selected != null)
            {
                string[] selectedarray = selected.Split(';');
                selectedlist = selectedarray.ToList<string>();
            }
            List<DictionaryItem> itemslist = new List<DictionaryItem>();
            using (TestDBEntities entity = new TestDBEntities())
            {
                itemslist = entity.DictionaryItem.Where(oo => oo.DictionaryItemCode.StartsWith(ModuleField.CodeCat) && oo.DictionaryItemCode.Length == 7).ToList();
            }
            foreach (DictionaryItem item in itemslist)
            {
                checkbox = new ASPxCheckBox();
                checkbox.Text = item.DictionaryItemName;
                checkbox.Value = item.DictionaryItemValue;
                CBhiddenfieldall.Add(item.DictionaryItemName, item.DictionaryItemValue);
                checkbox.ClientSideEvents.CheckedChanged = "function (s,e) {CBchange(s,e);}";
                if (selected != null)
                {
                    foreach (string defaultchecked in selectedlist)
                    {
                        if (item.DictionaryItemName == defaultchecked)
                        {
                            checkbox.Checked = true;
                            CBhiddenfield.Add(item.DictionaryItemName, "");
                            CBhiddenfield.Add(item.DictionaryItemValue, "");
                        }
                    }
                }
                panel.Controls.Add(checkbox);
            }
            //排列方式
            
            return panel;
        }
    }
}