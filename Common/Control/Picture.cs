using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.Web.ASPxPanel;
using DevExpress.Web.ASPxUploadControl;
using DevExpress.Web.ASPxEditors;
using System.Web.UI;
using System.IO;
using DevExpress.Web.ASPxPopupControl;
using DevExpress.Web.ASPxClasses;
using DevExpress.Web.ASPxCallback;
using System.Drawing;
using System.Drawing.Drawing2D;
using DevExpress.Web.ASPxHiddenField;
using System.Web.UI.WebControls;

namespace ContentModel1._5.Common
{
    public class Picture : ControlBase
    {
        public Picture(ModuleField moduleField)
            : base(moduleField)
        { 
        }
        public override System.Web.UI.Control Build()
        {
            base.Build();
            ASPxPanel panel = new ASPxPanel();
            ASPxUploadControl upload = new ASPxUploadControl();
            ASPxButton uploadbotton = new ASPxButton();
            ASPxLabel uploadurl=new ASPxLabel();
            ASPxButton clippingbutton = new ASPxButton();
            ASPxButton previewbutton = new ASPxButton();
            ASPxButton clippingWH = new ASPxButton();
            ASPxButton clippingSubmit = new ASPxButton();
            ASPxButton clippingCancel = new ASPxButton();
            ASPxPopupControl clipping = new ASPxPopupControl();
            ASPxPopupControl preview = new ASPxPopupControl();
            ASPxCallback callbackpic = new ASPxCallback();
            ASPxLabel uploadfinishname = new ASPxLabel();
            ASPxButton imagedelete = new ASPxButton();
            ASPxCallback callbackdelete = new ASPxCallback();
            ASPxHiddenField picturehf = new ASPxHiddenField();

            //定义upload
            upload.ClientInstanceName = "upload";
            upload.ShowProgressPanel = true;
            upload.BrowseButton.Text = "浏览";
            upload.FileUploadComplete += new EventHandler<FileUploadCompleteEventArgs>(uc_FileUploadComplete);
            //upload.ClientSideEvents.FilesUploadComplete = "function(s, e) { Uploader_PicturesUploadComplete(e); }";
            upload.ClientSideEvents.FileUploadComplete = "function(s, e) { Uploader_PictureUploadComplete(e); }";
            upload.ClientSideEvents.FileUploadStart = "function(s, e) { Uploader_PictureUploadStart(); }";
            upload.ClientSideEvents.TextChanged = "function(s, e) { PictureUpdateUploadButton(); }";
            upload.ValidationSettings.MaxFileSize = 4194304;
            string[] fileExtensions = new string[4] { ".jpg", ".jpeg", ".jpe", ".gif" };
            upload.ValidationSettings.AllowedFileExtensions = fileExtensions;
            //定义上传按钮
            uploadbotton.AutoPostBack = false;
            uploadbotton.Text = "上传";
            uploadbotton.ClientInstanceName = "uploadpicturebotton";
            uploadbotton.ClientEnabled = false;
            uploadbotton.ClientSideEvents.Click = "function(s, e) { imagedelete();upload.Upload();}";
            //定义剪裁按钮
            clippingbutton.AutoPostBack = false;
            clippingbutton.Text = "剪裁";
            clippingbutton.ClientInstanceName = "clippingbutton";
            clippingbutton.ClientEnabled = false;
            clippingbutton.ClientSideEvents.Click = "function(s, e) { clipping();initialization();}";
            //弹出的剪裁窗口定义
            clipping.CloseAction = CloseAction.CloseButton;
            clipping.Modal = true;
            clipping.PopupHorizontalAlign = PopupHorizontalAlign.WindowCenter;
            clipping.PopupVerticalAlign = PopupVerticalAlign.WindowCenter;
            clipping.ClientInstanceName = "clippingview";
            clipping.HeaderText = "图片剪裁";
            clipping.AllowDragging = true;
            clipping.EnableAnimation = false;
            clipping.EnableViewState = false;
            clipping.MinWidth = 500;
            clipping.MinHeight = 400;
            clipping.ClientSideEvents.CloseButtonClick = "function(s, e) { destroy();}";
            clipping.ClientSideEvents.Init = "function(s, e){s.hideBodyScrollWhenModal = false;}";
            //弹出剪裁窗口中的控件定义
            clippingWH.AutoPostBack = false;
            clippingWH.Text = "更改长宽";
            clippingWH.ClientSideEvents.Click = "function(s, e) { clippingWHclick();}";

            clippingSubmit.AutoPostBack = false;
            clippingSubmit.Text = "剪裁";
            clippingSubmit.ClientSideEvents.Click = "function(s, e) { clippingSubmit();}";
            
            //callback接收剪裁数据
            callbackpic.ClientInstanceName = "callbackpic";
            callbackpic.Callback += new CallbackEventHandler(OnCallbackComplete);
            callbackpic.ClientSideEvents.CallbackComplete = "function(s, e) { CallbackComplete(e);}";
            
            clippingCancel.AutoPostBack = false;
            clippingCancel.Text = "取消";
            clippingCancel.ClientSideEvents.Click = "function(s, e) { clippingview.Hide();destroy();}";
            clipping.Controls.Add(new LiteralControl("<table><tr><td>"));
            clipping.Controls.Add(new LiteralControl("<img src='' id='clippingpicture' alt='' />"));
			clipping.Controls.Add(new LiteralControl("</td><td>"));
			clipping.Controls.Add(new LiteralControl("<div style='width:150px;height:150px;overflow:hidden;' id='divsmall'>"));
			clipping.Controls.Add(new LiteralControl("<img src='' id='small' alt='' />"));
            clipping.Controls.Add(new LiteralControl("</div></td></tr></table>"));
            clipping.Controls.Add(new LiteralControl("<br />"));
            clipping.Controls.Add(new LiteralControl("<table><tr><td colspan='6'>可自定义框体长宽：</td>"));
            clipping.Controls.Add(new LiteralControl("<tr><td><label>X1 <input type='text' size='4' id='x1' name='x1' readonly='readonly' /></label></td>"));
            clipping.Controls.Add(new LiteralControl("<td><label>Y1 <input type='text' size='4' id='y1' name='y1' readonly='readonly' /></label></td>"));
            clipping.Controls.Add(new LiteralControl("<td><label>X2 <input type='text' size='4' id='x2' name='x2' readonly='readonly' /></label></td>"));
            clipping.Controls.Add(new LiteralControl("<td><label>Y2 <input type='text' size='4' id='y2' name='y2' readonly='readonly' /></label></td>"));
            clipping.Controls.Add(new LiteralControl("<td><label>W <input type='text' size='4' id='w' name='w' /></label></td>"));
            clipping.Controls.Add(new LiteralControl("<td><label>H <input type='text' size='4' id='h' name='h' /></label></td></tr>"));
            clipping.Controls.Add(new LiteralControl("<tr><td colspan='4'></td>"));
            clipping.Controls.Add(new LiteralControl("<td colspan='2' align='middle'>"));
            clipping.Controls.Add(clippingWH);
            clipping.Controls.Add(new LiteralControl("</td></tr>"));
            clipping.Controls.Add(new LiteralControl("<tr><td>"));
            clipping.Controls.Add(clippingSubmit);
            clipping.Controls.Add(new LiteralControl("</td>"));
            clipping.Controls.Add(new LiteralControl("<td>"));
            clipping.Controls.Add(clippingCancel);
            clipping.Controls.Add(new LiteralControl("</td>"));
            clipping.Controls.Add(new LiteralControl("<td>"));
            clipping.Controls.Add(new LiteralControl("<input type='checkbox' id='ar_lock'/><label for='ar_lock'>比例固定</label>"));
            clipping.Controls.Add(new LiteralControl("</td>"));
            clipping.Controls.Add(new LiteralControl("<td colspan='5'></td></tr></table>"));
            //定义Label
            uploadurl.Text = "";//文件名
            uploadurl.ClientInstanceName = "uploadurl";
            //定义预览按钮
            previewbutton.AutoPostBack = false;
            previewbutton.Text = "预览";
            previewbutton.ClientInstanceName = "previewbutton";
            previewbutton.ClientEnabled = false;
            previewbutton.ClientSideEvents.Click = "function(s, e) { preview(); }";
            //弹出的预览窗口定义
            preview.CloseAction = CloseAction.CloseButton;
            preview.Modal = true;
            preview.PopupHorizontalAlign = PopupHorizontalAlign.WindowCenter;
            preview.PopupVerticalAlign = PopupVerticalAlign.WindowCenter;
            preview.ClientInstanceName = "previewview";
            preview.HeaderText = "图片预览";
            preview.AllowDragging = true;
            preview.EnableAnimation = false;
            preview.EnableViewState = false;
            preview.Controls.Add(new LiteralControl("<img id='previewpicture' alt='' src=''"));
            preview.ClientSideEvents.Init = "function(s, e){s.hideBodyScrollWhenModal = false;}";
            //定义上传后保存的文件名。uploadfinishname
            uploadfinishname.Text = "";
            uploadfinishname.ClientInstanceName = "uploadfinishname";
            //上传后，删除按钮
            imagedelete.AutoPostBack = false;
            imagedelete.Text = "删除";
            imagedelete.ClientInstanceName = "imagedeletebutton";
            imagedelete.ClientEnabled = false;
            imagedelete.ClientSideEvents.Click = "function(s, e) { imagedelete(); }";
            //点击删除按钮callback服务器删除对应图片
            callbackdelete.ClientInstanceName = "callbackdeleteimg";
            callbackdelete.Callback += new CallbackEventHandler(OnCallbackDeleteImg);
            //隐藏控件保存图片地址
            picturehf.ClientInstanceName = "picturehf";

            panel.Controls.Add(new LiteralControl("<table><tr><td>"));
            panel.Controls.Add(upload);
            panel.Controls.Add(new LiteralControl("</td><td>"));
            panel.Controls.Add(uploadbotton);
            panel.Controls.Add(new LiteralControl("</td></tr><tr><td>"));
            panel.Controls.Add(uploadurl);
            panel.Controls.Add(new LiteralControl("</td><td>"));
            panel.Controls.Add(clippingbutton);
            panel.Controls.Add(clipping);
            panel.Controls.Add(new LiteralControl("</td></tr><tr><td>"));
            panel.Controls.Add(uploadfinishname);
            panel.Controls.Add(new LiteralControl("</td><td>"));
            panel.Controls.Add(imagedelete);
            panel.Controls.Add(previewbutton);
            panel.Controls.Add(preview);
            panel.Controls.Add(new LiteralControl("</td></tr></table>"));
            panel.Controls.Add(callbackpic);
            panel.Controls.Add(callbackdelete);
            panel.Controls.Add(picturehf);
            return panel;
        }

        void OnCallbackComplete(object sender, CallbackEventArgs e)
        {
            
            string callback = e.Parameter.ToString();
            string[] data = callback.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            string clippingpath = HttpContext.Current.Server.MapPath("../UploadImages" + data[0]);
            string date = DateTime.Now.ToFileTime().ToString();
            string newpath = HttpContext.Current.Server.MapPath("../UploadImages" + date + data[0]);
            using (var OriginalImage = new Bitmap(clippingpath))
            {
                using (var bmp = new Bitmap(Convert.ToInt32(data[3]), Convert.ToInt32(data[4]), OriginalImage.PixelFormat))
                {
                    bmp.SetResolution(OriginalImage.HorizontalResolution, OriginalImage.VerticalResolution);
                    using (Graphics Graphic = Graphics.FromImage(bmp))
                    {
                        Graphic.SmoothingMode = SmoothingMode.AntiAlias;
                        Graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        Graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        Graphic.DrawImage(OriginalImage, new Rectangle(0, 0, Convert.ToInt32(data[3]), Convert.ToInt32(data[4])), Convert.ToInt32(data[1]), Convert.ToInt32(data[2]), Convert.ToInt32(data[3]), Convert.ToInt32(data[4]),
                                          GraphicsUnit.Pixel);
                        bmp.Save(newpath, OriginalImage.RawFormat);
                    }
                }
            }
            e.Result = date + data[0];
        }

        void OnCallbackDeleteImg(object sender, CallbackEventArgs e)
        {
            string filename=e.Parameter.ToString();
            string path = HttpContext.Current.Server.MapPath("../UploadImages/" + filename);
            if (filename != "")
            {
                File.Delete(path);
            }
            string[] fileNames = Directory.GetFiles(HttpContext.Current.Server.MapPath("../UploadImages/"));
            foreach (string file in fileNames)
            {
                if (System.IO.Path.GetFileName(file).Contains(filename))
                {
                    File.Delete(file);
                }
            }  
        }
        
        void uc_FileUploadComplete(object sender, FileUploadCompleteEventArgs e)
        {
            e.CallbackData = SavePostedPic(e.UploadedFile);
        }
        public string SavePostedPic(UploadedFile uploadedFile)
        {
            if (!uploadedFile.IsValid)
                return string.Empty;
            string path = HttpContext.Current.Server.MapPath("../UploadImages/" + uploadedFile.FileName); //真实物理路径
            uploadedFile.SaveAs(path);            
            return uploadedFile.FileName;
        }
    }
}