using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.Web.ASPxEditors;
using System.Web.UI.WebControls;
using System.Web.UI;
using DevExpress.Web.ASPxHiddenField;
using DevExpress.Web.ASPxPanel;
using ContentModel1._5.Entities;

namespace ContentModel1._5.Common
{
    public class RadioButton : ControlBase
    {
        public RadioButton(ModuleField moduleField)  : base(moduleField)
        {                     
        }
        public override System.Web.UI.Control Build()
        {
            base.Build();
            ASPxPanel panel = new ASPxPanel();
            ASPxRadioButtonList radioList = new ASPxRadioButtonList();
            radioList.ClientInstanceName = "radioList";
            //是否必填
            radioList.ValidationSettings.RequiredField.IsRequired = ModuleField.IsRequired;
            //选项为空的提示
            radioList.ValidationSettings.RequiredField.ErrorText = ModuleField.ErrorText;
            //排列方式
            radioList.RepeatDirection = RepeatDirection.Horizontal;
            //代码分类
            List<DictionaryItem> itemslist = new List<DictionaryItem>();
            using (TestDBEntities entity = new TestDBEntities())
            {
                itemslist = entity.DictionaryItem.Where(oo => oo.DictionaryItemCode.StartsWith(ModuleField.CodeCat) && oo.DictionaryItemCode.Length == 7).ToList();
            }
            foreach (DictionaryItem item in itemslist)
            {
                radioList.Items.Add(item.DictionaryItemName, item.DictionaryItemValue);
            }
            //默认值与当前值
            string selected = ModuleField.CurrentValue == null ? ModuleField.DefaultValue == null ? null : ModuleField.DefaultValue.ToString() : ModuleField.CurrentValue.ToString();
            if (selected != null) { radioList.Items.FindByText(selected).Selected = true; }
            //为RBlist添加改变事件
            radioList.ClientSideEvents.SelectedIndexChanged = "function (s,e){RBchange(s);}";
            //添加一个隐藏控件
            ASPxHiddenField RBhiddenfield = new ASPxHiddenField();
            RBhiddenfield.ClientInstanceName = "RBhiddenfield";
            RBhiddenfield.Clear();
            //写入值
            if (selected != null) { RBhiddenfield.Add(radioList.Items.FindByText(selected).Text, radioList.Items.FindByText(selected).Value); }
            panel.Controls.Add(radioList);
            panel.Controls.Add(RBhiddenfield);
            return panel;
        }
    }
}