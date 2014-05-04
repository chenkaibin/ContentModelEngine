using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.Web.ASPxUploadControl;
using DevExpress.Web.ASPxPanel;
using DevExpress.Web.ASPxRoundPanel;
using System.Web.UI;
using System.IO;

namespace ContentModel1._5.Common
{
    public class MultiUpload :ControlBase
    {
        public MultiUpload(ModuleField moduleField)
            : base(moduleField)
        { 
        }
        public override System.Web.UI.Control Build()
        {
            base.Build();
            ASPxPanel panel = new ASPxPanel();
            ASPxUploadControl MUploadControl = new ASPxUploadControl();
            ASPxRoundPanel MUploadRoundPanel = new ASPxRoundPanel();
            PanelContent MUploadPanelContent = new PanelContent();
            
            //对上传控件的定义
            MUploadControl.ShowAddRemoveButtons = true;
            MUploadControl.BrowseButton.Text = "浏览";
            MUploadControl.UploadButton.Text = "上传";
            MUploadControl.AddButton.Text = "添加";
            MUploadControl.RemoveButton.Text = "移除";
            MUploadControl.Width = 300;
            MUploadControl.ShowUploadButton = true;
            MUploadControl.AddUploadButtonsHorizontalPosition = AddUploadButtonsHorizontalPosition.Left;
            MUploadControl.ShowProgressPanel = true;
            MUploadControl.ClientInstanceName = "MUploadControl";
            MUploadControl.FileUploadComplete += new EventHandler<FileUploadCompleteEventArgs>(FilesUploadComplete);
            MUploadControl.FileInputCount = 3;
            //MUploadControl.ValidationSettings.MaxFileSize = 4194304;
            //string[] fileExtensions = new string[4] { ".jpg", ".jpeg", ".jpe", ".gif" };
            //MUploadControl.ValidationSettings.AllowedFileExtensions = fileExtensions;
            MUploadControl.ClientSideEvents.FileUploadComplete = "function(s, e) { FilesUploaded(s, e) }";
            MUploadControl.ClientSideEvents.FileUploadStart = "function(s, e) { FilesUploadStart(); }";

            //对上传显示的定义
            MUploadRoundPanel.Width = 300;
            MUploadRoundPanel.ClientInstanceName = "MUploadRoundPanel";
            MUploadRoundPanel.HeaderText = "上传文件列表";

            //RoundPanel内部插件
            MUploadPanelContent.Controls.Add(new LiteralControl("<div id='uploadedListFiles' style='height: 150px; font-family: Arial;'></div>"));
            MUploadRoundPanel.Controls.Add(MUploadPanelContent);
            //MUploadRoundPanel.Height = 100%;

            //构建panel
            panel.Controls.Add(new LiteralControl("<table><tr><td>"));
            panel.Controls.Add(MUploadControl);
            panel.Controls.Add(new LiteralControl("</td><td>"));
            panel.Controls.Add(MUploadRoundPanel);
            panel.Controls.Add(new LiteralControl("</td></tr></table>"));
            return panel;
        }
        void FilesUploadComplete(object sender, FileUploadCompleteEventArgs e)
        {
            e.CallbackData = SavePostedFiles(e.UploadedFile);
        }
        string SavePostedFiles(UploadedFile uploadedFile)
        {
            if (!uploadedFile.IsValid)
                return string.Empty;

            FileInfo fileInfo = new FileInfo(uploadedFile.FileName);
            string resFileName = HttpContext.Current.Server.MapPath("Common\\UploadFiles\\" + fileInfo.Name);
            uploadedFile.SaveAs(resFileName);

            string fileLabel = fileInfo.Name;
            string fileType = uploadedFile.ContentType.ToString();
            string fileLength = uploadedFile.ContentLength / 1024 + "K";
            return string.Format("{0} <i>({1})</i> {2}|{3}", fileLabel, fileType,
                fileLength, fileInfo.Name);
        }
    }
}