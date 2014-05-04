using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.Web.ASPxPanel;
using DevExpress.Web.ASPxUploadControl;
using System.Web.UI;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxRoundPanel;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxPopupControl;
using DevExpress.Web.ASPxClasses;
using System.Text;
using DevExpress.Web.ASPxHiddenField;

namespace ContentModel1._5.Common
{
    public class MultiPicture : ControlBase
    {
        public MultiPicture(ModuleField moduleField)
            : base(moduleField)
        {
        }
        public override System.Web.UI.Control Build()
        {
            base.Build();
            ASPxPanel panel = new ASPxPanel();
            ASPxUploadControl uploadpctrl = new ASPxUploadControl();
            ASPxButton uploadpbutton = new ASPxButton();
            ASPxTextBox uploadptext = new ASPxTextBox();
            ASPxButton previewpbutton = new ASPxButton();
            ASPxButton clippingpbutton = new ASPxButton();
            ASPxButton clearpbutton = new ASPxButton();
            ASPxButton savepbutton = new ASPxButton();
            ASPxRoundPanel listpround = new ASPxRoundPanel();
            PanelContent listcontent = new PanelContent();
            ASPxGridView listgrid = new ASPxGridView();
            //上传控件
            uploadpctrl.ClientInstanceName = "uploadpctrl" + ModuleField.FieldID;
            uploadpctrl.BrowseButton.Text = "浏览";
            uploadpctrl.Width = Unit.Percentage(100);
            uploadpctrl.ClientSideEvents.TextChanged = "function(s,e){TextChangedEvent(" + ModuleField.FieldID + ");}";
            uploadpctrl.ClientSideEvents.FileUploadStart = "function(s,e){FileUploadStartEvent(" + ModuleField.FieldID + ");}";
            uploadpctrl.ClientSideEvents.FileUploadComplete = "function(s,e){FileUploadCompleteEvent(" + ModuleField.FieldID + ",e);}";
            uploadpctrl.FileUploadComplete += new EventHandler<FileUploadCompleteEventArgs>(uploadpctrl_FileUploadComplete);
            //上传按钮
            uploadpbutton.ClientInstanceName = "uploadpbutton" + ModuleField.FieldID;
            uploadpbutton.AutoPostBack = false;
            uploadpbutton.Text = "上传";
            uploadpbutton.Width = 45;
            uploadpbutton.Height = 25;
            uploadpbutton.ClientEnabled = false;
            uploadpbutton.ClientSideEvents.Click = "function(s,e){uploadpctrl" + ModuleField.FieldID + ".Upload();}";
            //文件名text
            uploadptext.ClientInstanceName = "uploadptext" + ModuleField.FieldID;
            uploadptext.Width = Unit.Percentage(100);
            uploadptext.Height = 25;
            uploadptext.ReadOnly = true;
            //预览按钮
            previewpbutton.ClientInstanceName = "previewpbutton" + ModuleField.FieldID;
            previewpbutton.AutoPostBack = false;
            previewpbutton.Text = "预览";
            previewpbutton.Width = Unit.Percentage(100);
            previewpbutton.Height = 25;
            previewpbutton.ClientEnabled = false;
            previewpbutton.ClientSideEvents.Click = "function(s,e){PreviewClickEvent(" + ModuleField.FieldID + ");}";
            //预览按钮弹出窗口
            #region 弹出窗口
            ASPxPopupControl previewpopup = new ASPxPopupControl();
            previewpopup.ClientInstanceName = "previewpopup" + ModuleField.FieldID;
            previewpopup.CloseAction = CloseAction.CloseButton;
            previewpopup.HeaderText = "图片预览";
            previewpopup.Modal = true;
            previewpopup.AllowDragging = true;
            previewpopup.PopupHorizontalAlign = PopupHorizontalAlign.WindowCenter;
            previewpopup.PopupVerticalAlign = PopupVerticalAlign.WindowCenter;
            previewpopup.Controls.Add(new LiteralControl("<div style='width:500px;height:375px;text-align:center;overflow:scroll;'><img id='previewimage" + ModuleField.FieldID + "' alt='' src='' /></div>"));
            #endregion
            //剪裁按钮
            clippingpbutton.ClientInstanceName = "clippingpbutton" + ModuleField.FieldID;
            clippingpbutton.AutoPostBack = false;
            clippingpbutton.Text = "剪裁";
            clippingpbutton.Width = 45;
            clippingpbutton.Height = 25;
            clippingpbutton.ClientEnabled = false;
            clippingpbutton.ClientSideEvents.Click = "function(s,e){ClippingClickEvent(" + ModuleField.FieldID + ");}";
            //剪裁按钮弹出窗口
            #region 弹出窗口
            ASPxPopupControl clippingpopup = new ASPxPopupControl();
            clippingpopup.ClientInstanceName = "clippingpopup" + ModuleField.FieldID;
            clippingpopup.CloseAction = CloseAction.CloseButton;
            clippingpopup.HeaderText = "图片剪裁";
            clippingpopup.Modal = true;
            clippingpopup.AllowDragging = true;
            clippingpopup.PopupHorizontalAlign = PopupHorizontalAlign.WindowCenter;
            clippingpopup.PopupVerticalAlign = PopupVerticalAlign.WindowCenter;
            ASPxLabel lbX1 = new ASPxLabel();
            ASPxLabel lbX2 = new ASPxLabel();
            ASPxLabel lbY1 = new ASPxLabel();
            ASPxLabel lbY2 = new ASPxLabel();
            ASPxLabel lbW = new ASPxLabel();
            ASPxLabel lbH = new ASPxLabel();
            ASPxLabel lbwh = new ASPxLabel(); lbwh.Text = "自定义长宽：";
            ASPxButton bwh = new ASPxButton(); bwh.Text = "确定修改";
            ASPxButton clippingsubmit = new ASPxButton(); clippingsubmit.Text = "确定剪裁";
            ASPxButton clippingcancel = new ASPxButton(); clippingcancel.Text = "取消剪裁";
            StringBuilder clippingpicshowtable = new StringBuilder();
            clippingpicshowtable.Append("<table><tr><td>");
            clippingpicshowtable.Append("<table cellpadding='0' cellspacing='0'><tr><td>");
            clippingpicshowtable.Append("<div style='width:500px;height:375px;text-align:center;overflow:scroll;'><img id='clippingimage" + ModuleField.FieldID + "' alt='' src='' /></div>");
            clippingpicshowtable.Append("</td><td>");
            clippingpicshowtable.Append("<table><tr><td align='center'><div style='width:180px;height:180px;'><div id='smalldiv1" + ModuleField.FieldID + "' style='width:180px;height:180px;overflow:hidden;'><img id='small1" + ModuleField.FieldID + "' alt='' src='' /></div></div></td></tr>");
            clippingpicshowtable.Append("<tr><td align='center'><div style='width:120px;height:120px;'><div id='smalldiv2" + ModuleField.FieldID + "' style='width:120px;height:120px;overflow:hidden;'><img id='small2" + ModuleField.FieldID + "' alt='' src='' /></div></div></td></tr>");
            clippingpicshowtable.Append("<tr><td align='center'><div style='width:60px;height:60px;'><div id='smalldiv3" + ModuleField.FieldID + "' style='width:60px;height:60px;overflow:hidden;'><img id='small3" + ModuleField.FieldID + "' alt='' src='' /><div></div></td></tr></table>");
            clippingpicshowtable.Append("</td></tr></table></td></tr><tr><td>");
            clippingpopup.Controls.Add(new LiteralControl(clippingpicshowtable.ToString()));
            clippingpopup.Controls.Add(new LiteralControl("<table><tr><td>"));
            clippingpopup.Controls.Add(lbX1); clippingpopup.Controls.Add(new LiteralControl("</td><td>"));
            clippingpopup.Controls.Add(lbY1); clippingpopup.Controls.Add(new LiteralControl("</td><td>"));
            clippingpopup.Controls.Add(lbX2); clippingpopup.Controls.Add(new LiteralControl("</td><td>"));
            clippingpopup.Controls.Add(lbY2); clippingpopup.Controls.Add(new LiteralControl("</td><td>"));
            clippingpopup.Controls.Add(lbW); clippingpopup.Controls.Add(new LiteralControl("</td><td>"));
            clippingpopup.Controls.Add(lbH); clippingpopup.Controls.Add(new LiteralControl("</td></tr><tr><td>"));
            clippingpopup.Controls.Add(new LiteralControl("<label>X1 <input type='text' size='4' id='X1" + ModuleField.FieldID + "' name='X1" + ModuleField.FieldID + "' readonly='readonly' /></label></td><td>"));
            clippingpopup.Controls.Add(new LiteralControl("<label>Y1 <input type='text' size='4' id='Y1" + ModuleField.FieldID + "' name='Y1" + ModuleField.FieldID + "' readonly='readonly' /></label></td><td>"));
            clippingpopup.Controls.Add(new LiteralControl("<label>X2 <input type='text' size='4' id='X2" + ModuleField.FieldID + "' name='X2" + ModuleField.FieldID + "' readonly='readonly' /></label></td><td>"));
            clippingpopup.Controls.Add(new LiteralControl("<label>Y2 <input type='text' size='4' id='Y2" + ModuleField.FieldID + "' name='Y2" + ModuleField.FieldID + "' readonly='readonly' /></label></td><td>"));
            clippingpopup.Controls.Add(new LiteralControl("<label>W <input type='text' size='4' id='W" + ModuleField.FieldID + "' name='W" + ModuleField.FieldID + "' /></label></td><td>"));
            clippingpopup.Controls.Add(new LiteralControl("<label>H <input type='text' size='4' id='H" + ModuleField.FieldID + "' name='H" + ModuleField.FieldID + "' /></label></td></tr>"));
            clippingpopup.Controls.Add(new LiteralControl("<tr><td colspan='4'><input type='checkbox' id='ar_lock" + ModuleField.FieldID + "'/><label for='ar_lock'>固定为正方</label></td><td>"));
            clippingpopup.Controls.Add(lbwh);
            clippingpopup.Controls.Add(new LiteralControl("</td><td>"));
            clippingpopup.Controls.Add(bwh);
            clippingpopup.Controls.Add(new LiteralControl("</td></tr><tr><td colspan='3' align='right'>"));
            clippingpopup.Controls.Add(clippingsubmit);
            clippingpopup.Controls.Add(new LiteralControl("</td><td colspan='3' align='left'>"));
            clippingpopup.Controls.Add(clippingcancel);
            clippingpopup.Controls.Add(new LiteralControl("</td></tr></table>"));
            clippingpopup.Controls.Add(new LiteralControl("</td></tr></table>"));
            #endregion
            //清空按钮
            clearpbutton.ClientInstanceName = "clearpbutton" + ModuleField.FieldID;
            clearpbutton.AutoPostBack = false;
            clearpbutton.Text = "清空";
            clearpbutton.Width = 45;
            clearpbutton.Height = 25;
            clearpbutton.ClientEnabled = false;
            clearpbutton.ClientSideEvents.Click = "function(s,e){ClearClickEvent(" + ModuleField.FieldID + ");}";
            //保存按钮
            savepbutton.ClientInstanceName = "savepbutton" + ModuleField.FieldID;
            savepbutton.AutoPostBack = false;
            savepbutton.Text = "保存";
            savepbutton.Width = Unit.Percentage(100);
            savepbutton.Height = 25;
            savepbutton.ClientEnabled = false;
            //文件显示列表
            listpround.HeaderText = "图片列表";
            listpround.HeaderStyle.Height = 10;
            listpround.Width = Unit.Percentage(100);
            //girdview
            GridViewDataHyperLinkColumn namecolumn = new GridViewDataHyperLinkColumn();
            GridViewDataTextColumn sizecolumn = new GridViewDataTextColumn();
            GridViewCommandColumn operation = new GridViewCommandColumn();
            namecolumn.Caption = "文件名";
            namecolumn.Width = 150;
            namecolumn.FieldName = "picname";
            sizecolumn.Caption = "文件大小";
            sizecolumn.Width = 50;
            sizecolumn.FieldName = "picsize";
            operation.Caption = "文件操作";
            operation.Width = 30;
            operation.DeleteButton.Visible = true;
            operation.DeleteButton.Text = "删除";
            listgrid.Columns.Add(namecolumn);
            listgrid.Columns.Add(sizecolumn);
            listgrid.Columns.Add(operation);
            listgrid.Settings.ShowColumnHeaders = false;
            List<PicList> piclist = new List<PicList>();
            PicList newrow = new PicList();
            newrow.picname = "123.jpg";
            newrow.picsize = "123KB";
            piclist.Add(newrow);
            newrow = new PicList();
            newrow.picname = "456.jpg";
            newrow.picsize = "456KB";
            piclist.Add(newrow);
            //gridview加入roundpanel
            listgrid.DataSource = piclist;
            listgrid.DataBind();
            listcontent.Controls.Add(listgrid);
            listpround.Controls.Add(listcontent);
            #region 页面构建
            Table pictable = new Table();
            panel.Controls.Add(new LiteralControl("<table width=\"500px\"><tr><td><table cellspacing=\"1\" cellpadding=\"2\"><tr><td colspan=\"3\" width=\"135px\">"));
            panel.Controls.Add(uploadpctrl);
            panel.Controls.Add(new LiteralControl("</td><td width=\"45px\">"));
            panel.Controls.Add(uploadpbutton);
            panel.Controls.Add(new LiteralControl("</td></tr><tr><td colspan=\"4\" width=\"180px\">"));
            panel.Controls.Add(uploadptext);
            panel.Controls.Add(new LiteralControl("</tr><tr><td colspan=\"2\" width=\"90px\">"));
            panel.Controls.Add(previewpbutton);
            panel.Controls.Add(previewpopup);
            panel.Controls.Add(new LiteralControl("</td><td width=\"45px\">"));
            panel.Controls.Add(clippingpbutton);
            panel.Controls.Add(clippingpopup);
            panel.Controls.Add(new LiteralControl("</td><td width=\"45px\">"));
            panel.Controls.Add(clearpbutton);
            panel.Controls.Add(new LiteralControl("</td></tr><tr><td colspan=\"4\" width=\"180px\">"));
            panel.Controls.Add(savepbutton);
            panel.Controls.Add(new LiteralControl("</td></tr></table></td><td  valign=\"top\" width=\"300px\">"));
            panel.Controls.Add(listpround);
            panel.Controls.Add(new LiteralControl("</td></tr></table>"));
            #endregion
            return panel;
        }
        protected void uploadpctrl_FileUploadComplete(object sender, FileUploadCompleteEventArgs e)
        {
            e.CallbackData = SaveToServer(e.UploadedFile);
        }
        protected string SaveToServer(UploadedFile uploadedfile)
        {
            if (!uploadedfile.IsValid)
                return string.Empty;
            string filep = HttpContext.Current.Server.MapPath("../UploadImages/" + uploadedfile.FileName);            
            uploadedfile.SaveAs(filep);
            return uploadedfile.FileName;
        }
    }
}