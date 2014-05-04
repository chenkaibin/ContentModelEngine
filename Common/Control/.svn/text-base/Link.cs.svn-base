using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.Web.ASPxPanel;
using DevExpress.Web.ASPxEditors;
using System.Web.UI;

namespace ContentModel1._5.Common
{
    public class Link : ControlBase
    {
        public Link(ModuleField moduleField)
            : base(moduleField)
        {
        }

        public override System.Web.UI.Control Build()
        {
            base.Build();
            ASPxPanel panel = new ASPxPanel();
            ASPxLabel linktextlab = new ASPxLabel();
            linktextlab.Text = "显示文本：";
            ASPxTextBox linktext = new ASPxTextBox();
            linktext.Width = ModuleField.Width;
            linktext.Height = ModuleField.Height;
            linktext.ValidationSettings.RequiredField.IsRequired = ModuleField.IsRequired;
            linktext.ValidationSettings.RequiredField.ErrorText = "请输入链接显示文本！";
            ASPxLabel linkurllab = new ASPxLabel();
            linkurllab.Text = "输入网址：";
            ASPxTextBox linkurl = new ASPxTextBox();
            linkurl.Width = ModuleField.Width;
            linkurl.Height = ModuleField.Height;
            linkurl.ValidationSettings.RequiredField.IsRequired = ModuleField.IsRequired;
            linkurl.ValidationSettings.RequiredField.ErrorText = "请输入链接地址！";
            linkurl.ValidationSettings.RegularExpression.ErrorText = "格式不正确！";
            linkurl.ValidationSettings.RegularExpression.ValidationExpression = "[a-zA-z]+://[^\\s]*";
            if (ModuleField.CurrentValue != null)
            {
                int index = ModuleField.CurrentValue.ToString().IndexOf("||||||||||");
                string text = ModuleField.CurrentValue.ToString().Substring(0, index);
                string url = ModuleField.CurrentValue.ToString().Substring(index + 10, ModuleField.CurrentValue.ToString().Length - index - 10);
                linktext.Text = text;
                linkurl.Text = url;
            }
            panel.Controls.Add(new LiteralControl("<table><tr><td>"));
            panel.Controls.Add(linktextlab);
            panel.Controls.Add(new LiteralControl("</td><td>"));
            panel.Controls.Add(linktext);
            panel.Controls.Add(new LiteralControl("</td></tr><tr><td>"));
            panel.Controls.Add(linkurllab);
            panel.Controls.Add(new LiteralControl("</td><td>"));
            panel.Controls.Add(linkurl);
            panel.Controls.Add(new LiteralControl("</td></tr></table>"));
            return panel;
        }
    }
}