using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using DevExpress.Web.ASPxEditors;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Text;
using System.Web.UI.HtmlControls;
using ContentModel1._5.Common;

namespace ContentModel1._5.Common
{
    public class PageInput : PageBase, IBuilder
    {
        //用来返回键值对
        List<KeyField> keyFieldList = new List<KeyField>();
        public PageInput(List<ModuleField> moduleFieldList, System.Web.UI.Page page)
            : base(moduleFieldList, page)
        {
        }

        #region IBuilder 成员

        public System.Web.UI.Control Build()
        {
            DevExpress.Web.ASPxPanel.ASPxPanel panel = new DevExpress.Web.ASPxPanel.ASPxPanel();
            panel.ID = "panel";
            foreach (ModuleField moduleField in moduleFieldList)
            {
                if (moduleField.IsVisible == true)
                {
                    ControlBase ctrl = null;
                    System.Web.UI.Control buildCtrl = null;
                    string Key = null;
                    string FieldName = null;
                    switch (moduleField.FieldType)
                    {
                        #region switch
                        //单行文本
                        case FieldType.SingleLineText:
                            ctrl = new SingleLineText(moduleField);
                            buildCtrl = ctrl.Build();
                            buildCtrl.ID = "SL";
                            buildCtrl.ID += moduleField.FieldID;
                            Key = "panel_" + buildCtrl.ID + "_Raw";
                            FieldName = moduleField.Name;
                            keyFieldList.Add(new KeyField(Key, FieldName));
                            break;

                        //多行文本
                        case FieldType.MultiLineNoHtml:
                            ctrl = new MultiLineNoHtml(moduleField);
                            buildCtrl = ctrl.Build();
                            buildCtrl.ID = "ML";
                            buildCtrl.ID += moduleField.FieldID;
                            Key = "panel_" + buildCtrl.ID + "_Raw";
                            FieldName = moduleField.Name;
                            keyFieldList.Add(new KeyField(Key, FieldName));
                            break;

                        //HTML文本
                        case FieldType.MultiLineHtml:
                            ctrl = new MultiLineHtml(moduleField);
                            buildCtrl = ctrl.Build();
                            buildCtrl.ID = "HT";
                            buildCtrl.ID += moduleField.FieldID;
                            Key = "panel_" + buildCtrl.ID + "_Html";
                            FieldName = moduleField.Name;
                            keyFieldList.Add(new KeyField(Key, FieldName));
                            break;

                        //单选下拉列表框
                        case FieldType.SingleDropDownList:
                            ctrl = new SingleDropDownList(moduleField);
                            buildCtrl = ctrl.Build();
                            buildCtrl.ID = "SD";
                            buildCtrl.ID += moduleField.FieldID;
                            Key = "panel$" + buildCtrl.ID;
                            FieldName = moduleField.Name;
                            keyFieldList.Add(new KeyField(Key, FieldName));
                            break;

                        //多选下拉列表框
                        case FieldType.MultiDropDownList:
                            ctrl = new MultiDropDownList(moduleField);
                            #region 脚本写入
                            page.ClientScript.RegisterClientScriptInclude("MultiDrop", "../Scripts/MultiDrop.js");
                            #endregion
                            buildCtrl = ctrl.Build();
                            buildCtrl.ID = "MD";
                            buildCtrl.ID += moduleField.FieldID;
                            Key = "panel$" + buildCtrl.ID;
                            FieldName = moduleField.Name;
                            keyFieldList.Add(new KeyField(Key, FieldName));
                            break;

                        //单选按钮
                        case FieldType.RadioButtonField:
                            ctrl = new RadioButton(moduleField);
                            #region 脚本写入
                            StringBuilder radiobuttonjs = new StringBuilder();
                            radiobuttonjs.Append("<script type='text/javascript'>");
                            radiobuttonjs.Append("function RBchange(s) {RBhiddenfield.Clear();RBhiddenfield.Add(s.GetSelectedItem().text,s.GetSelectedItem().value);}");
                            radiobuttonjs.Append("</script>");
                            page.ClientScript.RegisterClientScriptBlock(typeof(string), "RadioButton", radiobuttonjs.ToString());
                            #endregion
                            buildCtrl = ctrl.Build();
                            buildCtrl.ID = "RB";
                            buildCtrl.ID += moduleField.FieldID;
                            Key = "panel$" + buildCtrl.ID + "$ctl02$I";
                            FieldName = moduleField.Name;
                            keyFieldList.Add(new KeyField(Key, FieldName));
                            break;

                        //复选按钮
                        case FieldType.CheckBoxField:
                            ctrl = new CheckBox(moduleField);
                            #region 脚本写入
                            StringBuilder checkboxjs = new StringBuilder();
                            checkboxjs.Append("<script type='text/javascript'>");
                            checkboxjs.Append("function CBchange(s,e) {if(s.GetChecked()){CBhiddenfield.Add(s.GetText(),'');CBhiddenfieldc.Add(CBhiddenfieldall.Get(s.GetText()),'');}else{CBhiddenfield.Remove(s.GetText(),'');CBhiddenfieldc.Remove(CBhiddenfieldall.Get(s.GetText()),'');}}");
                            checkboxjs.Append("</script>");
                            page.ClientScript.RegisterClientScriptBlock(typeof(string), "CheckBox", checkboxjs.ToString());
                            #endregion
                            buildCtrl = ctrl.Build();
                            buildCtrl.ID = "CB";
                            buildCtrl.ID += moduleField.FieldID;
                            Key = "panel$" + buildCtrl.ID;
                            FieldName = moduleField.Name;
                            keyFieldList.Add(new KeyField(Key, FieldName));
                            break;

                        //数字
                        case FieldType.NumberField:
                            ctrl = new Number(moduleField);
                            buildCtrl = ctrl.Build();
                            buildCtrl.ID = "NUM";
                            buildCtrl.ID += moduleField.FieldID;
                            Key = "panel_" + buildCtrl.ID + "_Raw";
                            FieldName = moduleField.Name;
                            keyFieldList.Add(new KeyField(Key, FieldName));
                            break;

                        //货币
                        case FieldType.MoneyField:
                            ctrl = new Money(moduleField);
                            buildCtrl = ctrl.Build();
                            buildCtrl.ID = "MON";
                            buildCtrl.ID += moduleField.FieldID;
                            Key = "panel_" + buildCtrl.ID + "_Raw";
                            FieldName = moduleField.Name;
                            keyFieldList.Add(new KeyField(Key, FieldName));
                            break;

                        //日期
                        case FieldType.DateField:
                            ctrl = new DateField(moduleField);
                            buildCtrl = ctrl.Build();
                            buildCtrl.ID = "DAT";
                            buildCtrl.ID += moduleField.FieldID;
                            Key = "panel$" + buildCtrl.ID;
                            FieldName = moduleField.Name;
                            keyFieldList.Add(new KeyField(Key, FieldName));
                            break;

                        //时间
                        case FieldType.TimeField:
                            ctrl = new TimeField(moduleField);
                            buildCtrl = ctrl.Build();
                            buildCtrl.ID = "TIM";
                            buildCtrl.ID += moduleField.FieldID;
                            Key = "panel$" + buildCtrl.ID;
                            FieldName = moduleField.Name;
                            keyFieldList.Add(new KeyField(Key, FieldName));
                            break;

                        //超链接
                        case FieldType.LinkField:
                            ctrl = new Link(moduleField);
                            buildCtrl = ctrl.Build();
                            buildCtrl.ID = "LINK";
                            buildCtrl.ID += moduleField.FieldID;
                            Key = "panel$" + buildCtrl.ID;
                            FieldName = moduleField.Name;
                            keyFieldList.Add(new KeyField(Key, FieldName));
                            break;

                        //固定电话号码
                        case FieldType.PhoneFixed:
                            ctrl = new PhoneFixed(moduleField);
                            buildCtrl = ctrl.Build();
                            buildCtrl.ID = "PHO";
                            buildCtrl.ID += moduleField.FieldID;
                            Key = "panel_" + buildCtrl.ID + "_Raw";
                            FieldName = moduleField.Name;
                            keyFieldList.Add(new KeyField(Key, FieldName));
                            break;

                        //移动电话号码
                        case FieldType.PhoneMobile:
                            ctrl = new PhoneMobile(moduleField);
                            buildCtrl = ctrl.Build();
                            buildCtrl.ID = "MIB";
                            buildCtrl.ID += moduleField.FieldID;
                            Key = "panel_" + buildCtrl.ID + "_Raw";
                            FieldName = moduleField.Name;
                            keyFieldList.Add(new KeyField(Key, FieldName));
                            break;

                        //颜色
                        case FieldType.ColorField:
                            ctrl = new Color(moduleField);
                            buildCtrl = ctrl.Build();
                            buildCtrl.ID = "COL";
                            buildCtrl.ID += moduleField.FieldID;
                            Key = "panel_" + buildCtrl.ID + "_Raw";
                            FieldName = moduleField.Name;
                            keyFieldList.Add(new KeyField(Key, FieldName));
                            break;

                        //自定义文本
                        case FieldType.CustomText:
                            ctrl = new CustomText(moduleField);
                            buildCtrl = ctrl.Build();
                            buildCtrl.ID = "CT";
                            buildCtrl.ID += moduleField.FieldID;
                            Key = "panel_" + buildCtrl.ID + "_Raw";
                            FieldName = moduleField.Name;
                            keyFieldList.Add(new KeyField(Key, FieldName));
                            break;

                        //图片上传
                        case FieldType.Picture:
                            ctrl = new Picture(moduleField);
                            buildCtrl = ctrl.Build();
                            buildCtrl.ID = "PIC";
                            buildCtrl.ID += moduleField.FieldID;
                            Key = "panel$" + buildCtrl.ID;
                            FieldName = moduleField.Name;
                            keyFieldList.Add(new KeyField(Key, FieldName));
                            #region 写入JS脚本与CSS
                            StringBuilder Picturejs = new StringBuilder();
                            Picturejs.Append("<script type=\"text/javascript\">");
                            //Picturejs.Append("function Uploader_PictureUploadStart() {}");
                            Picturejs.Append("var filename;");
                            Picturejs.Append("var imageheadpath='../UploadImages/';");
                            Picturejs.Append("function Uploader_PictureUploadStart() {uploadpicturebotton.SetEnabled(false);}");
                            Picturejs.Append("function Uploader_PictureUploadComplete(args) {if(args.callbackData!=''){var Name=args.callbackData;uploadurl.SetText(Name);uploadfinishname.SetText(Name);picturehf.Clear();picturehf.Add('001',imageheadpath+Name);filename=Name;document.getElementById('previewpicture').src=imageheadpath+filename;clippingbutton.SetEnabled(true);previewbutton.SetEnabled(true);imagedeletebutton.SetEnabled(true);}}");
                            //Picturejs.Append("function Uploader_PicturesUploadComplete(args) {}");
                            Picturejs.Append("function PictureUpdateUploadButton() {uploadpicturebotton.SetEnabled(upload.GetText(0) != '');}");
                            Picturejs.Append("function clipping() {document.getElementById('clippingpicture').src=imageheadpath+uploadurl.GetText();document.getElementById('small').src=imageheadpath+uploadurl.GetText();clippingview.Show();}");
                            Picturejs.Append("function preview() {previewview.Show();}");
                            Picturejs.Append("function imagedelete() {callbackdeleteimg.PerformCallback(uploadurl.GetText());uploadfinishname.SetText('');uploadurl.SetText('');clippingbutton.SetEnabled(false);previewbutton.SetEnabled(false);imagedeletebutton.SetEnabled(false);}");
                            Picturejs.Append("function CallbackComplete(args) {filename=args.result;uploadfinishname.SetText(filename);picturehf.Clear();picturehf.Add('001',imageheadpath+filename);document.getElementById('previewpicture').src=imageheadpath+filename;previewview.SetSize(10,10);}");
                            Picturejs.Append("</script>");

                            page.ClientScript.RegisterClientScriptBlock(typeof(string), "UploadPictureScript", Picturejs.ToString());
                            page.ClientScript.RegisterClientScriptInclude("min", "../Scripts/jquery.min.js");
                            page.ClientScript.RegisterClientScriptInclude("Jcrop", "../Scripts/jquery.Jcrop.js");
                            page.ClientScript.RegisterClientScriptInclude("imageupload", "../Scripts/imageupload.js");

                            HtmlLink link = new HtmlLink();
                            link.Attributes.Add("type", "text/css");
                            link.Attributes.Add("rel", "stylesheet");
                            link.Attributes.Add("href", "../css/jquery.Jcrop.css");
                            page.Header.Controls.Add(link);
                            #endregion
                            break;
                        //多图上传
                        case FieldType.MultiPicture:
                            ctrl = new MultiPicture(moduleField);
                            buildCtrl = ctrl.Build();
                            buildCtrl.ID = "MUPT";
                            buildCtrl.ID += moduleField.FieldID;
                            Key = "panel$" + buildCtrl.ID;
                            FieldName = moduleField.Name;
                            keyFieldList.Add(new KeyField(Key, FieldName));
                            #region JS脚本+CSS样式                            
                            page.ClientScript.RegisterClientScriptInclude("MultiPicturejQuerymin", "../Scripts/jquery.min.js");
                            page.ClientScript.RegisterClientScriptInclude("MultiPicturejQueryjcrop", "../Scripts/jquery.Jcrop.js");
                            page.ClientScript.RegisterClientScriptInclude("MultiPicture", "../Scripts/MultiPicture.js");

                            HtmlLink linkmp = new HtmlLink();
                            linkmp.Attributes.Add("type", "text/css");
                            linkmp.Attributes.Add("rel", "stylesheet");
                            linkmp.Attributes.Add("href", "../css/jquery.Jcrop.css");
                            page.Header.Controls.Add(linkmp);
                            #endregion
                            break;
                        //文件上传
                        case FieldType.Upload:
                            ctrl = new Upload(moduleField);
                            buildCtrl = ctrl.Build();
                            buildCtrl.ID = "ULF";
                            buildCtrl.ID += moduleField.FieldID;
                            Key = "panel$" + buildCtrl.ID;
                            FieldName = moduleField.Name;
                            keyFieldList.Add(new KeyField(Key, FieldName));
                            #region 写入JS脚本
                            StringBuilder Filejs = new StringBuilder();
                            Filejs.Append("<script type=\"text/javascript\">");
                            //Picturejs.Append("function Uploader_PictureUploadStart() {}");
                            Filejs.Append("var filename;");
                            Filejs.Append("var flieheadpath='Common/UploadFiles/';");
                            Filejs.Append("function Uploader_FileUploadStart() {uploadfilebutton.SetEnabled(false);}");
                            Filejs.Append("function Uploader_FileUploadComplete(args) {if(args.callbackData!=''){var Name=args.callbackData;uploadfileurl.SetText(Name);filename=Name;uploadfiledelete.SetEnabled(true);}}");
                            //Filejs.Append("function Uploader_PicturesUploadComplete(args) {}");
                            Filejs.Append("function FileUpdateUploadButton() {uploadfilebutton.SetEnabled(uploadfile.GetText(0) != '');}");
                            Filejs.Append("function uploadfiledeletefunc() {callbackdeletefile.PerformCallback(uploadfileurl.GetText())}");
                            Filejs.Append("</script>");
                            page.ClientScript.RegisterClientScriptBlock(typeof(string), "UploadFileScript", Filejs.ToString());
                            #endregion
                            break;
                        //多文件上传
                        case FieldType.MultiUpload:
                            ctrl = new MultiUpload(moduleField);
                            buildCtrl = ctrl.Build();
                            buildCtrl.ID = "MULF";
                            buildCtrl.ID += moduleField.FieldID;
                            Key = "panel$" + buildCtrl.ID;
                            FieldName = "20";
                            keyFieldList.Add(new KeyField(Key, FieldName));
                            #region 写入JS脚本
                            StringBuilder Filesjs = new StringBuilder();
                            Filesjs.Append("<script type='text/javascript'>");
                            Filesjs.Append("var fieldSeparator = '|';");
                            Filesjs.Append("function FilesUploadStart() {document.getElementById('uploadedListFiles').innerHTML = '';}");
                            Filesjs.Append("function FilesUploaded(s, e) {");
                            Filesjs.Append("if(e.isValid) {");
                            Filesjs.Append("var linkFile = document.createElement('a');");
                            Filesjs.Append("var indexSeparator = e.callbackData.indexOf(fieldSeparator);");
                            Filesjs.Append("var fileName = e.callbackData.substring(0, indexSeparator);");
                            Filesjs.Append("var fileUrl = e.callbackData.substring(indexSeparator + fieldSeparator.length);");
                            Filesjs.Append("var fileSrc = 'Common/UploadFiles/' + fileUrl;");
                            Filesjs.Append("linkFile.innerHTML = fileName;");
                            Filesjs.Append("linkFile.setAttribute('href', fileSrc);");
                            Filesjs.Append("linkFile.setAttribute('target', '_blank');");
                            Filesjs.Append("var container = document.getElementById('uploadedListFiles');");
                            Filesjs.Append("container.appendChild(linkFile);");
                            Filesjs.Append("container.appendChild(document.createElement('br'));}}");
                            Filesjs.Append("</script>");
                            page.ClientScript.RegisterClientScriptBlock(typeof(string), "UploadFilesScript", Filesjs.ToString());
                            #endregion
                            break;

                        case FieldType.Org:
                        case FieldType.User:
                        case FieldType.Role:
                        // 代码选择
                        case FieldType.SelectCode:
                            ctrl = new SelectCode(moduleField);

                            #region  动态加载css代码和动态向页面注入js文件
                            string _popupjs = HttpContext.Current.Request.ApplicationPath + "Scripts/popup.js";
                            page.ClientScript.RegisterClientScriptInclude("popup", _popupjs);
                            page.ClientScript.RegisterClientScriptInclude("jquery", HttpContext.Current.Request.ApplicationPath + "Scripts/jquery-1.4.1.js");
                            page.ClientScript.RegisterClientScriptInclude("min1", HttpContext.Current.Request.ApplicationPath + "Scripts/jquery.min.js");
                            page.ClientScript.RegisterClientScriptInclude("min2", HttpContext.Current.Request.ApplicationPath + "Scripts/jquery-1.4.1.min.js");

                            HtmlLink navlink = new HtmlLink();
                            navlink.Attributes.Add("type", "text/css");
                            navlink.Attributes.Add("rel", "stylesheet");
                            string _popupcss = HttpContext.Current.Request.ApplicationPath + "css/popupnav.css";//System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "css\\popupnav.css";
                            page.ClientScript.RegisterClientScriptInclude("popup", _popupcss);
                            navlink.Attributes.Add("href", _popupcss);
                            page.Header.Controls.Add(navlink);
                            
                            #endregion

                            buildCtrl = ctrl.Build();
                            buildCtrl.ID = "SLCOD";
                            buildCtrl.ID += moduleField.FieldID;
                            Key = "panel_" + buildCtrl.ID + "_ctl01_Raw";
                            FieldName = moduleField.Name;
                            keyFieldList.Add(new KeyField(Key, FieldName));
                            break;                                                    
                        //词条
                        case FieldType.ListBox:
                            //    ctrl = new ListBox(moduleField);
                            //    buildCtrl = ctrl.Build();
                            break;
                        //评分评比
                        case FieldType.VoteField:
                            ctrl = new Vote(moduleField);
                            buildCtrl = ctrl.Build();
                            buildCtrl.ID = "VOT";
                            buildCtrl.ID += moduleField.FieldID;
                            Key = "panel_" + buildCtrl.ID + "S";
                            FieldName = moduleField.Name;
                            keyFieldList.Add(new KeyField(Key, FieldName));
                            break;
                        //验证码
                        case FieldType.Captcha:
                            ctrl = new Captcha(moduleField);
                            buildCtrl = ctrl.Build();
                            break;
                        default:
                            break;
                        #endregion
                    }
                    if (buildCtrl != null)
                    {
                        panel.Controls.Add(new LiteralControl("<tr>"));
                        panel.Controls.Add(new LiteralControl("<td width=250px>"));
                        panel.Controls.Add(new LiteralControl(moduleField.Nick));
                        panel.Controls.Add(new LiteralControl("</td>"));
                        panel.Controls.Add(new LiteralControl("<td width=400px>"));
                        panel.Controls.Add(buildCtrl);
                        panel.Controls.Add(new LiteralControl("</td>"));
                        panel.Controls.Add(new LiteralControl("</tr>"));
                    }
                }
            }
            //序列化KeyFieldList
            HiddenField hfKeyFields = new HiddenField();
            hfKeyFields.ID = "hfKeyFields";
            hfKeyFields.Value = JsonConvert.SerializeObject(keyFieldList);
            panel.Controls.Add(hfKeyFields);
            return panel;
        }
        #endregion
    }
}