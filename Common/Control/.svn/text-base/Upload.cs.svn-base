using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.Web.ASPxUploadControl;
using DevExpress.Web.ASPxPanel;
using DevExpress.Web.ASPxEditors;
using System.Web.UI;
using DevExpress.Web.ASPxCallback;
using System.IO;

namespace ContentModel1._5.Common
{
    public class Upload:ControlBase
    {
        public Upload(ModuleField moduleField)
            : base(moduleField)
        { 
        }
        public override System.Web.UI.Control Build()
        {
            base.Build();
            ASPxPanel panel = new ASPxPanel();
            ASPxUploadControl uploadfile = new ASPxUploadControl();
            ASPxButton uploadfilebutton = new ASPxButton();
            ASPxLabel uploadfileurl = new ASPxLabel();
            ASPxButton uploadfiledelete = new ASPxButton();
            ASPxCallback callbackfiledelete = new ASPxCallback();
            //定义上传框体
            uploadfile.BrowseButton.Text = "浏览";
            uploadfile.ClientInstanceName = "uploadfile";
            uploadfile.FileUploadComplete += new EventHandler<FileUploadCompleteEventArgs>(FileUploadComplete);
            //uploadfile.ClientSideEvents.FilesUploadComplete = "function(s, e) { Uploader_PicturesUploadComplete(e); }";
            uploadfile.ClientSideEvents.FileUploadComplete = "function(s, e) { Uploader_FileUploadComplete(e); }";
            uploadfile.ClientSideEvents.FileUploadStart = "function(s, e) { Uploader_FileUploadStart(); }";
            uploadfile.ClientSideEvents.TextChanged = "function(s, e) { FileUpdateUploadButton(); }";
            //uploadfile.ValidationSettings.MaxFileSize = 4194304;
            //string[] fileExtensions = new string[4] { ".jpg", ".jpeg", ".jpe", ".gif" };
            //uploadfile.ValidationSettings.AllowedFileExtensions = fileExtensions;

            //定义上传文件按钮
            uploadfilebutton.AutoPostBack = false;
            uploadfilebutton.Text = "上传";
            uploadfilebutton.ClientEnabled = false;
            uploadfilebutton.ClientInstanceName = "uploadfilebutton";
            uploadfilebutton.ClientSideEvents.Click = "function(s, e) { uploadfiledeletefunc();uploadfile.Upload();}";
            //定义上传后文件名显示
            uploadfileurl.Text = "文件名：";
            uploadfileurl.ClientInstanceName = "uploadfileurl";
            //定义删除文件按钮
            uploadfiledelete.Text = "删除";
            uploadfiledelete.ClientInstanceName = "uploadfiledelete";
            uploadfiledelete.ClientEnabled = false;
            uploadfiledelete.ClientSideEvents.Click = "function(s, e) { uploadfiledeletefunc(); }";
            //callback回传服务器删除文件
            callbackfiledelete.ClientInstanceName = "callbackdeletefile";
            callbackfiledelete.Callback += new CallbackEventHandler(OnCallbackDeleteFile);

            panel.Controls.Add(new LiteralControl("<table><tr><td>"));
            panel.Controls.Add(uploadfile);
            panel.Controls.Add(new LiteralControl("</td><td>"));
            panel.Controls.Add(uploadfilebutton);
            panel.Controls.Add(new LiteralControl("</td></tr><tr><td>"));
            panel.Controls.Add(uploadfileurl);
            panel.Controls.Add(new LiteralControl("</td><td>"));
            panel.Controls.Add(uploadfiledelete);
            panel.Controls.Add(new LiteralControl("</td></tr></table>"));
            panel.Controls.Add(callbackfiledelete);
            return panel;
        }

        void FileUploadComplete(object sender, FileUploadCompleteEventArgs e)
        {
            e.CallbackData = SavePostedFile(e.UploadedFile);
        }
        public string SavePostedFile(UploadedFile uploadedFile)
        {
            if (!uploadedFile.IsValid)
                return string.Empty;

            string path = HttpContext.Current.Server.MapPath("Common\\UploadFiles\\" + uploadedFile.FileName); //真实物理路径
            uploadedFile.SaveAs(path);
            return uploadedFile.FileName;
        }

        void OnCallbackDeleteFile(object sender, CallbackEventArgs e)
        {
            string filename = e.Parameter.ToString();
            string path = HttpContext.Current.Server.MapPath("Common\\UploadFiles\\" + filename);
            if (filename != "")
            {
                File.Delete(path);
            }
        }
    }
}