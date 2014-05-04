using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ContentModel1._5.Entities;
using ContentModel1._5.Common;
using System.Reflection;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxHtmlEditor;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace ContentModel1._5.CommonModel
{
    public partial class Field : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string ModelName = Request.QueryString["ModelName"];//表名
                string FieldCode = Request.QueryString["FieldCode"];//字段编码
                string EditMode = Request.QueryString["EditMode"];//编辑模式
                List<ContentModel1._5.Entities.ModelField> fields = new List<ContentModel1._5.Entities.ModelField>();
                List<ContentModel1._5.Common.ModuleField> moduleFieldList = new List<ContentModel1._5.Common.ModuleField>();
                if (EditMode == "Edit")
                {
                    //保存按钮可用
                    EBtnSubmit.Enabled = true;
                    //编辑时，首先获取FieldID，用来获取是编辑的哪个ModelName表的Field字段
                    using (TestDBEntities entities = new TestDBEntities())
                    {
                        fields = entities.ModelField.Where(s => s.Code == FieldCode).ToList();
                        ContentModel1._5.Entities.ModelField field = (ContentModel1._5.Entities.ModelField)fields.FirstOrDefault();
                        //绑定控件内的内容
                        BindData(field);
                    }
                }
                ModelNameHidden.Value = ModelName;
                EditModeHidden.Value = EditMode;
            }
        }

        //控件选择的改变，触发改变页面的事件
        /// <summary>
        /// 控件选择的改变，触发改变页面的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void RadlFieldType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DevExpress.Web.ASPxEditors.ASPxRadioButton Rdb = (DevExpress.Web.ASPxEditors.ASPxRadioButton)sender;
            //如果选项选中，必然有选项取消，当选项取消的时候不做任何事
            EBtnSubmit.Enabled = true;
            if (Rdb.Checked == false)
            {
                return;
            }
            #region 选项显示或隐藏
            switch (Rdb.ID)
            {
                case "RadTextType":
                    PnlText.Visible = true;
                    PnlMultiText.Visible = false;
                    PnlEditor.Visible = false;
                    PnlRadio.Visible = false;
                    PnlNumber.Visible = false;
                    PnlCurrency.Visible = false;
                    PnlDate.Visible = false;
                    PnlTime.Visible = false;
                    PnlURL.Visible = false;
                    PnlPhoneMobile.Visible = false;
                    PnlPhoneFixed.Visible = false;
                    PnlColor.Visible = false;
                    PnlCustomized.Visible = false;
                    PnlTableField.Visible = false;
                    PnlPicture.Visible = false;
                    PnlMultiPicture.Visible = false;
                    PnlFile.Visible = false;
                    PnlMultiFile.Visible = false;
                    PnlRegion.Visible = false;
                    PnlKeyword.Visible = false;
                    PnlCaptcha.Visible = false;
                    PnlSelectUser.Visible = false;
                    PnlSelectDepartment.Visible = false;
                    PnlSelectRole.Visible = false;
                    PnlSelectCode.Visible = false;
                    PnlVote.Visible = false;
                    HdnFieldType.Value = "1";
                    break;
                case "RadMultipleTextType":
                    PnlText.Visible = false;
                    PnlMultiText.Visible = true;
                    PnlEditor.Visible = false;
                    PnlRadio.Visible = false;
                    PnlNumber.Visible = false;
                    PnlCurrency.Visible = false;
                    PnlDate.Visible = false;
                    PnlTime.Visible = false;
                    PnlURL.Visible = false;
                    PnlPhoneMobile.Visible = false;
                    PnlPhoneFixed.Visible = false;
                    PnlColor.Visible = false;
                    PnlCustomized.Visible = false;
                    PnlTableField.Visible = false;
                    PnlPicture.Visible = false;
                    PnlMultiPicture.Visible = false;
                    PnlFile.Visible = false;
                    PnlMultiFile.Visible = false;
                    PnlRegion.Visible = false;
                    PnlKeyword.Visible = false;
                    PnlCaptcha.Visible = false;
                    PnlSelectUser.Visible = false;
                    PnlSelectDepartment.Visible = false;
                    PnlSelectRole.Visible = false;
                    PnlSelectCode.Visible = false;
                    PnlVote.Visible = false;                    
                    HdnFieldType.Value = "2";
                    break;
                case "RadMultipleHtmlTextType":
                    PnlText.Visible = false;
                    PnlMultiText.Visible = false;
                    PnlEditor.Visible = true;
                    PnlRadio.Visible = false;
                    PnlNumber.Visible = false;
                    PnlCurrency.Visible = false;
                    PnlDate.Visible = false;
                    PnlTime.Visible = false;
                    PnlURL.Visible = false;
                    PnlPhoneMobile.Visible = false;
                    PnlPhoneFixed.Visible = false;
                    PnlColor.Visible = false;
                    PnlCustomized.Visible = false;
                    PnlTableField.Visible = false;
                    PnlPicture.Visible = false;
                    PnlMultiPicture.Visible = false;
                    PnlFile.Visible = false;
                    PnlMultiFile.Visible = false;
                    PnlRegion.Visible = false;
                    PnlKeyword.Visible = false;
                    PnlCaptcha.Visible = false;
                    PnlSelectUser.Visible = false;
                    PnlSelectDepartment.Visible = false;
                    PnlSelectRole.Visible = false;
                    PnlSelectCode.Visible = false;
                    PnlVote.Visible = false;                    
                    HdnFieldType.Value = "3";
                    break;
                case "PnlRadioType":
                    PnlRadioWidthTd.Visible = false;
                    PnlRadioHeightTd.Visible = false;
                    PnlText.Visible = false;
                    PnlMultiText.Visible = false;
                    PnlEditor.Visible = false;
                    PnlRadio.Visible = true;
                    PnlNumber.Visible = false;
                    PnlCurrency.Visible = false;
                    PnlDate.Visible = false;
                    PnlTime.Visible = false;
                    PnlURL.Visible = false;
                    PnlPhoneMobile.Visible = false;
                    PnlPhoneFixed.Visible = false;
                    PnlColor.Visible = false;
                    PnlCustomized.Visible = false;
                    PnlTableField.Visible = false;
                    PnlPicture.Visible = false;
                    PnlMultiPicture.Visible = false;
                    PnlFile.Visible = false;
                    PnlMultiFile.Visible = false;
                    PnlRegion.Visible = false;
                    PnlKeyword.Visible = false;
                    PnlCaptcha.Visible = false;
                    PnlSelectUser.Visible = false;
                    PnlSelectDepartment.Visible = false;
                    PnlSelectRole.Visible = false;
                    PnlSelectCode.Visible = false;
                    PnlVote.Visible = false;
                    //HdnFieldType.Value在内部选项设定4,5,6,7
                    #region 加载代码“选项”数据项
                    try
                    {
                        using (TestDBEntities db = new TestDBEntities())
                        {
                            List<Dictionary> codelist = db.Dictionary.Where(p => p.ControlType == "SelectCode").ToList();
                            RadlChoiceCode.DataSource = codelist;
                            RadlChoiceCode.DataBind();
                        }
                    }
                    catch (Exception ex)
                    { throw ex; }
                    #endregion
                    break;
                case "RadNumberType":
                    PnlText.Visible = false;
                    PnlMultiText.Visible = false;
                    PnlEditor.Visible = false;
                    PnlRadio.Visible = false;
                    PnlNumber.Visible = true;
                    PnlCurrency.Visible = false;
                    PnlDate.Visible = false;
                    PnlTime.Visible = false;
                    PnlURL.Visible = false;
                    PnlPhoneMobile.Visible = false;
                    PnlPhoneFixed.Visible = false;
                    PnlColor.Visible = false;
                    PnlCustomized.Visible = false;
                    PnlTableField.Visible = false;
                    PnlPicture.Visible = false;
                    PnlMultiPicture.Visible = false;
                    PnlFile.Visible = false;
                    PnlMultiFile.Visible = false;
                    PnlRegion.Visible = false;
                    PnlKeyword.Visible = false;
                    PnlCaptcha.Visible = false;
                    PnlSelectUser.Visible = false;
                    PnlSelectDepartment.Visible = false;
                    PnlSelectRole.Visible = false;
                    PnlSelectCode.Visible = false;
                    PnlVote.Visible = false;                    
                    HdnFieldType.Value = "8";
                    #region 加载代码选择Number 数据项
                    try
                    {
                        using (TestDBEntities entity = new TestDBEntities())
                        {
                            Dictionary codecat = entity.Dictionary.Where(p => p.ControlType == "NumberField").FirstOrDefault();
                            List<DictionaryItem> detaillist = entity.DictionaryItem.Where(oo => oo.DictionaryItemCode.StartsWith(codecat.DictionaryCode)).ToList();
                            TxtNumberDisplayFormat.DataSource = detaillist;
                            TxtNumberDisplayFormat.DataBind();
                        }
                    }
                    catch (Exception ex)
                    { throw ex; }
                    #endregion
                    break;
                case "RadMoneyType":
                    PnlText.Visible = false;
                    PnlMultiText.Visible = false;
                    PnlEditor.Visible = false;
                    PnlRadio.Visible = false;
                    PnlNumber.Visible = false;
                    PnlCurrency.Visible = true;
                    PnlDate.Visible = false;
                    PnlTime.Visible = false;
                    PnlURL.Visible = false;
                    PnlPhoneMobile.Visible = false;
                    PnlPhoneFixed.Visible = false;
                    PnlColor.Visible = false;
                    PnlCustomized.Visible = false;
                    PnlTableField.Visible = false;
                    PnlPicture.Visible = false;
                    PnlMultiPicture.Visible = false;
                    PnlFile.Visible = false;
                    PnlMultiFile.Visible = false;
                    PnlRegion.Visible = false;
                    PnlKeyword.Visible = false;
                    PnlCaptcha.Visible = false;
                    PnlSelectUser.Visible = false;
                    PnlSelectDepartment.Visible = false;
                    PnlSelectRole.Visible = false;
                    PnlSelectCode.Visible = false;
                    PnlVote.Visible = false;                    
                    HdnFieldType.Value = "9";
                    #region 加载代码选择Currency 数据项
                    try
                    {
                        using (TestDBEntities entity = new TestDBEntities())
                        {
                            Dictionary codecat = entity.Dictionary.Where(p => p.ControlType == "CurrencyField").FirstOrDefault();
                            List<DictionaryItem> detaillist = entity.DictionaryItem.Where(oo => oo.DictionaryItemCode.StartsWith(codecat.DictionaryCode)).ToList();
                            PnlCurrencyDisplayFormat.DataSource = detaillist;
                            PnlCurrencyDisplayFormat.DataBind();
                        }
                    }
                    catch (Exception ex)
                    { throw ex; }
                    #endregion
                    break;
                case "RadDateType":
                    PnlText.Visible = false;
                    PnlMultiText.Visible = false;
                    PnlEditor.Visible = false;
                    PnlRadio.Visible = false;
                    PnlNumber.Visible = false;
                    PnlCurrency.Visible = false;
                    PnlDate.Visible = true;
                    PnlTime.Visible = false;
                    PnlURL.Visible = false;
                    PnlPhoneMobile.Visible = false;
                    PnlPhoneFixed.Visible = false;
                    PnlColor.Visible = false;
                    PnlCustomized.Visible = false;
                    PnlTableField.Visible = false;
                    PnlPicture.Visible = false;
                    PnlMultiPicture.Visible = false;
                    PnlFile.Visible = false;
                    PnlMultiFile.Visible = false;
                    PnlRegion.Visible = false;
                    PnlKeyword.Visible = false;
                    PnlCaptcha.Visible = false;
                    PnlSelectUser.Visible = false;
                    PnlSelectDepartment.Visible = false;
                    PnlSelectRole.Visible = false;
                    PnlSelectCode.Visible = false;
                    PnlVote.Visible = false;
                    HdnFieldType.Value = "10";
                    #region 加载代码选择DateField 数据项
                    try
                    {
                        using (TestDBEntities entity = new TestDBEntities())
                        {
                            Dictionary codecat = entity.Dictionary.Where(p => p.ControlType == "DateField").FirstOrDefault();
                            List<DictionaryItem> detaillist = entity.DictionaryItem.Where(oo => oo.DictionaryItemCode.StartsWith(codecat.DictionaryCode)).ToList();
                            PnlDateDisplayFormat.DataSource = detaillist;
                            PnlDateDisplayFormat.DataBind();
                        }
                    }
                    catch (Exception ex)
                    { throw ex; }
                    #endregion
                    break;
                case "RadTimeType":
                    PnlText.Visible = false;
                    PnlMultiText.Visible = false;
                    PnlEditor.Visible = false;
                    PnlRadio.Visible = false;
                    PnlNumber.Visible = false;
                    PnlCurrency.Visible = false;
                    PnlDate.Visible = false;
                    PnlTime.Visible = true;
                    PnlURL.Visible = false;
                    PnlPhoneMobile.Visible = false;
                    PnlPhoneFixed.Visible = false;
                    PnlColor.Visible = false;
                    PnlCustomized.Visible = false;
                    PnlTableField.Visible = false;
                    PnlPicture.Visible = false;
                    PnlMultiPicture.Visible = false;
                    PnlFile.Visible = false;
                    PnlMultiFile.Visible = false;
                    PnlRegion.Visible = false;
                    PnlKeyword.Visible = false;
                    PnlCaptcha.Visible = false;
                    PnlSelectUser.Visible = false;
                    PnlSelectDepartment.Visible = false;
                    PnlSelectRole.Visible = false;
                    PnlSelectCode.Visible = false;
                    PnlVote.Visible = false;                    
                    HdnFieldType.Value = "11";
                    #region 加载代码选择TimeField 数据项
                    try
                    {
                        using (TestDBEntities entity = new TestDBEntities())
                        {
                            Dictionary codecat = entity.Dictionary.Where(p => p.ControlType == "TimeField").FirstOrDefault();
                            List<DictionaryItem> detaillist = entity.DictionaryItem.Where(oo => oo.DictionaryItemCode.StartsWith(codecat.DictionaryCode)).ToList();
                            PnlTimeDisplayFormat.DataSource = detaillist;
                            PnlTimeDisplayFormat.DataBind();
                        }
                    }
                    catch (Exception ex)
                    { throw ex; }
                    #endregion
                    break;
                case "RadHyperLinkType":
                    PnlText.Visible = false;
                    PnlMultiText.Visible = false;
                    PnlEditor.Visible = false;
                    PnlRadio.Visible = false;
                    PnlNumber.Visible = false;
                    PnlCurrency.Visible = false;
                    PnlDate.Visible = false;
                    PnlTime.Visible = false;
                    PnlURL.Visible = true;
                    PnlPhoneMobile.Visible = false;
                    PnlPhoneFixed.Visible = false;
                    PnlColor.Visible = false;
                    PnlCustomized.Visible = false;
                    PnlTableField.Visible = false;
                    PnlPicture.Visible = false;
                    PnlMultiPicture.Visible = false;
                    PnlFile.Visible = false;
                    PnlMultiFile.Visible = false;
                    PnlRegion.Visible = false;
                    PnlKeyword.Visible = false;
                    PnlCaptcha.Visible = false;
                    PnlSelectUser.Visible = false;
                    PnlSelectDepartment.Visible = false;
                    PnlSelectRole.Visible = false;
                    PnlSelectCode.Visible = false;
                    PnlVote.Visible = false;                    
                    HdnFieldType.Value = "12";
                    break;
                case "RadTelephoneType":
                    PnlText.Visible = false;
                    PnlMultiText.Visible = false;
                    PnlEditor.Visible = false;
                    PnlRadio.Visible = false;
                    PnlNumber.Visible = false;
                    PnlCurrency.Visible = false;
                    PnlDate.Visible = false;
                    PnlTime.Visible = false;
                    PnlURL.Visible = false;
                    PnlPhoneMobile.Visible = false;
                    PnlPhoneFixed.Visible = true;
                    PnlColor.Visible = false;
                    PnlCustomized.Visible = false;
                    PnlTableField.Visible = false;
                    PnlPicture.Visible = false;
                    PnlMultiPicture.Visible = false;
                    PnlFile.Visible = false;
                    PnlMultiFile.Visible = false;
                    PnlRegion.Visible = false;
                    PnlKeyword.Visible = false;
                    PnlCaptcha.Visible = false;
                    PnlSelectUser.Visible = false;
                    PnlSelectDepartment.Visible = false;
                    PnlSelectRole.Visible = false;
                    PnlSelectCode.Visible = false;
                    PnlVote.Visible = false;                    
                    HdnFieldType.Value = "13";
                    break;
                case "RadMobilephoneType":
                    PnlText.Visible = false;
                    PnlMultiText.Visible = false;
                    PnlEditor.Visible = false;
                    PnlRadio.Visible = false;
                    PnlNumber.Visible = false;
                    PnlCurrency.Visible = false;
                    PnlDate.Visible = false;
                    PnlTime.Visible = false;
                    PnlURL.Visible = false;
                    PnlPhoneMobile.Visible = true;
                    PnlPhoneFixed.Visible = false;
                    PnlColor.Visible = false;
                    PnlCustomized.Visible = false;
                    PnlTableField.Visible = false;
                    PnlPicture.Visible = false;
                    PnlMultiPicture.Visible = false;
                    PnlFile.Visible = false;
                    PnlMultiFile.Visible = false;
                    PnlRegion.Visible = false;
                    PnlKeyword.Visible = false;
                    PnlCaptcha.Visible = false;
                    PnlSelectUser.Visible = false;
                    PnlSelectDepartment.Visible = false;
                    PnlSelectRole.Visible = false;
                    PnlSelectCode.Visible = false;
                    PnlVote.Visible = false;
                    HdnFieldType.Value = "14";
                    break;
                case "RadUserTextType":
                    PnlText.Visible = false;
                    PnlMultiText.Visible = false;
                    PnlEditor.Visible = false;
                    PnlRadio.Visible = false;
                    PnlNumber.Visible = false;
                    PnlCurrency.Visible = false;
                    PnlDate.Visible = false;
                    PnlTime.Visible = false;
                    PnlURL.Visible = false;
                    PnlPhoneMobile.Visible = false;
                    PnlPhoneFixed.Visible = false;
                    PnlColor.Visible = false;
                    PnlCustomized.Visible = true;
                    PnlTableField.Visible = false;
                    PnlPicture.Visible = false;
                    PnlMultiPicture.Visible = false;
                    PnlFile.Visible = false;
                    PnlMultiFile.Visible = false;
                    PnlRegion.Visible = false;
                    PnlKeyword.Visible = false;
                    PnlCaptcha.Visible = false;
                    PnlSelectUser.Visible = false;
                    PnlSelectDepartment.Visible = false;
                    PnlSelectRole.Visible = false;
                    PnlSelectCode.Visible = false;
                    PnlVote.Visible = false;
                    #region 加载代码选择自定义控件的数据项
                    try
                    {
                        using (TestDBEntities entity = new TestDBEntities())
                        {
                            string customtext = FieldType.CustomText.ToString();
                            Dictionary codecat = entity.Dictionary.Where(p => p.ControlType == customtext).FirstOrDefault();
                            List<DictionaryItem> detaillist = entity.DictionaryItem.Where(oo => oo.DictionaryItemCode.StartsWith(codecat.DictionaryCode)).ToList();
                            PnlCustomizedDisplayFormat.DataSource = detaillist;
                            PnlCustomizedDisplayFormat.DataBind();
                        }
                    }
                    catch (Exception ex)
                    { throw ex; }
                    #endregion
                    HdnFieldType.Value = "15";
                    break;
                case "RadColorType":
                    PnlText.Visible = false;
                    PnlMultiText.Visible = false;
                    PnlEditor.Visible = false;
                    PnlRadio.Visible = false;
                    PnlNumber.Visible = false;
                    PnlCurrency.Visible = false;
                    PnlDate.Visible = false;
                    PnlTime.Visible = false;
                    PnlURL.Visible = false;
                    PnlPhoneMobile.Visible = false;
                    PnlPhoneFixed.Visible = false;
                    PnlColor.Visible = true;
                    PnlCustomized.Visible = false;
                    PnlTableField.Visible = false;
                    PnlPicture.Visible = false;
                    PnlMultiPicture.Visible = false;
                    PnlFile.Visible = false;
                    PnlMultiFile.Visible = false;
                    PnlRegion.Visible = false;
                    PnlKeyword.Visible = false;
                    PnlCaptcha.Visible = false;
                    PnlSelectUser.Visible = false;
                    PnlSelectDepartment.Visible = false;
                    PnlSelectRole.Visible = false;
                    PnlSelectCode.Visible = false;
                    PnlVote.Visible = false;                    
                    HdnFieldType.Value = "16";
                    
                    break;                
                case "RadPictureType":
                    PnlText.Visible = false;
                    PnlMultiText.Visible = false;
                    PnlEditor.Visible = false;
                    PnlRadio.Visible = false;
                    PnlNumber.Visible = false;
                    PnlCurrency.Visible = false;
                    PnlDate.Visible = false;
                    PnlTime.Visible = false;
                    PnlURL.Visible = false;
                    PnlPhoneMobile.Visible = false;
                    PnlPhoneFixed.Visible = false;
                    PnlColor.Visible = false;
                    PnlCustomized.Visible = false;
                    PnlTableField.Visible = false;
                    PnlPicture.Visible = true;
                    PnlMultiPicture.Visible = false;
                    PnlFile.Visible = false;
                    PnlMultiFile.Visible = false;
                    PnlRegion.Visible = false;
                    PnlKeyword.Visible = false;
                    PnlCaptcha.Visible = false;
                    PnlSelectUser.Visible = false;
                    PnlSelectDepartment.Visible = false;
                    PnlSelectRole.Visible = false;
                    PnlSelectCode.Visible = false;
                    PnlVote.Visible = false;                    
                    HdnFieldType.Value = "17";
                    break;
                case "RadMultiPictureType":
                    PnlText.Visible = false;
                    PnlMultiText.Visible = false;
                    PnlEditor.Visible = false;
                    PnlRadio.Visible = false;
                    PnlNumber.Visible = false;
                    PnlCurrency.Visible = false;
                    PnlDate.Visible = false;
                    PnlTime.Visible = false;
                    PnlURL.Visible = false;
                    PnlPhoneMobile.Visible = false;
                    PnlPhoneFixed.Visible = false;
                    PnlColor.Visible = false;
                    PnlCustomized.Visible = false;
                    PnlTableField.Visible = false;
                    PnlPicture.Visible = false;
                    PnlMultiPicture.Visible = true;
                    PnlFile.Visible = false;
                    PnlMultiFile.Visible = false;
                    PnlRegion.Visible = false;
                    PnlKeyword.Visible = false;
                    PnlCaptcha.Visible = false;
                    PnlSelectUser.Visible = false;
                    PnlSelectDepartment.Visible = false;
                    PnlSelectRole.Visible = false;
                    PnlSelectCode.Visible = false;
                    PnlVote.Visible = false;                    
                    HdnFieldType.Value = "18";
                    break;
                case "RadFileType":
                    PnlText.Visible = false;
                    PnlMultiText.Visible = false;
                    PnlEditor.Visible = false;
                    PnlRadio.Visible = false;
                    PnlNumber.Visible = false;
                    PnlCurrency.Visible = false;
                    PnlDate.Visible = false;
                    PnlTime.Visible = false;
                    PnlURL.Visible = false;
                    PnlPhoneMobile.Visible = false;
                    PnlPhoneFixed.Visible = false;
                    PnlColor.Visible = false;
                    PnlCustomized.Visible = false;
                    PnlTableField.Visible = false;
                    PnlPicture.Visible = false;
                    PnlMultiPicture.Visible = false;
                    PnlFile.Visible = true;
                    PnlMultiFile.Visible = false;
                    PnlRegion.Visible = false;
                    PnlKeyword.Visible = false;
                    PnlCaptcha.Visible = false;
                    PnlSelectUser.Visible = false;
                    PnlSelectDepartment.Visible = false;
                    PnlSelectRole.Visible = false;
                    PnlSelectCode.Visible = false;
                    PnlVote.Visible = false;                    
                    HdnFieldType.Value = "19";
                    break;
                case "RadMultiFileType":
                    PnlText.Visible = false;
                    PnlMultiText.Visible = false;
                    PnlEditor.Visible = false;
                    PnlRadio.Visible = false;
                    PnlNumber.Visible = false;
                    PnlCurrency.Visible = false;
                    PnlDate.Visible = false;
                    PnlTime.Visible = false;
                    PnlURL.Visible = false;
                    PnlPhoneMobile.Visible = false;
                    PnlPhoneFixed.Visible = false;
                    PnlColor.Visible = false;
                    PnlCustomized.Visible = false;
                    PnlTableField.Visible = false;
                    PnlPicture.Visible = false;
                    PnlMultiPicture.Visible = false;
                    PnlFile.Visible = false;
                    PnlMultiFile.Visible = true;
                    PnlRegion.Visible = false;
                    PnlKeyword.Visible = false;
                    PnlCaptcha.Visible = false;
                    PnlSelectUser.Visible = false;
                    PnlSelectDepartment.Visible = false;
                    PnlSelectRole.Visible = false;
                    PnlSelectCode.Visible = false;
                    PnlVote.Visible = false;                    
                    HdnFieldType.Value = "20";
                    break;
                case "RadRegionType":
                    PnlText.Visible = false;
                    PnlMultiText.Visible = false;
                    PnlEditor.Visible = false;
                    PnlRadio.Visible = false;
                    PnlNumber.Visible = false;
                    PnlCurrency.Visible = false;
                    PnlDate.Visible = false;
                    PnlTime.Visible = false;
                    PnlURL.Visible = false;
                    PnlPhoneMobile.Visible = false;
                    PnlPhoneFixed.Visible = false;
                    PnlColor.Visible = false;
                    PnlCustomized.Visible = false;
                    PnlTableField.Visible = false;
                    PnlPicture.Visible = false;
                    PnlMultiPicture.Visible = false;
                    PnlFile.Visible = false;
                    PnlMultiFile.Visible = false;
                    PnlRegion.Visible = true;
                    PnlKeyword.Visible = false;
                    PnlCaptcha.Visible = false;
                    PnlSelectUser.Visible = false;
                    PnlSelectDepartment.Visible = false;
                    PnlSelectRole.Visible = false;
                    PnlSelectCode.Visible = false;
                    PnlVote.Visible = false;                    
                    HdnFieldType.Value = "26";
                    break;
                case "RadWordsType":
                    PnlText.Visible = false;
                    PnlMultiText.Visible = false;
                    PnlEditor.Visible = false;
                    PnlRadio.Visible = false;
                    PnlNumber.Visible = false;
                    PnlCurrency.Visible = false;
                    PnlDate.Visible = false;
                    PnlTime.Visible = false;
                    PnlURL.Visible = false;
                    PnlPhoneMobile.Visible = false;
                    PnlPhoneFixed.Visible = false;
                    PnlColor.Visible = false;
                    PnlCustomized.Visible = false;
                    PnlTableField.Visible = false;
                    PnlPicture.Visible = false;
                    PnlMultiPicture.Visible = false;
                    PnlFile.Visible = false;
                    PnlMultiFile.Visible = false;
                    PnlRegion.Visible = false;
                    PnlKeyword.Visible = true;
                    PnlCaptcha.Visible = false;
                    PnlSelectUser.Visible = false;
                    PnlSelectDepartment.Visible = false;
                    PnlSelectRole.Visible = false;
                    PnlSelectCode.Visible = false;
                    PnlVote.Visible = false;                    
                    HdnFieldType.Value = "21";
                    break;
                case "RadCaptchaType":
                    PnlText.Visible = false;
                    PnlMultiText.Visible = false;
                    PnlEditor.Visible = false;
                    PnlRadio.Visible = false;
                    PnlNumber.Visible = false;
                    PnlCurrency.Visible = false;
                    PnlDate.Visible = false;
                    PnlTime.Visible = false;
                    PnlURL.Visible = false;
                    PnlPhoneMobile.Visible = false;
                    PnlPhoneFixed.Visible = false;
                    PnlColor.Visible = false;
                    PnlCustomized.Visible = false;
                    PnlTableField.Visible = false;
                    PnlPicture.Visible = false;
                    PnlMultiPicture.Visible = false;
                    PnlFile.Visible = false;
                    PnlMultiFile.Visible = false;
                    PnlRegion.Visible = false;
                    PnlKeyword.Visible = false;
                    PnlCaptcha.Visible = true;
                    PnlSelectUser.Visible = false;
                    PnlSelectDepartment.Visible = false;
                    PnlSelectRole.Visible = false;
                    PnlSelectCode.Visible = false;
                    PnlVote.Visible = false;                    
                    HdnFieldType.Value = "28";
                    break;
                case "RadSelectUserType":
                    PnlText.Visible = false;
                    PnlMultiText.Visible = false;
                    PnlEditor.Visible = false;
                    PnlRadio.Visible = false;
                    PnlNumber.Visible = false;
                    PnlCurrency.Visible = false;
                    PnlDate.Visible = false;
                    PnlTime.Visible = false;
                    PnlURL.Visible = false;
                    PnlPhoneMobile.Visible = false;
                    PnlPhoneFixed.Visible = false;
                    PnlColor.Visible = false;
                    PnlCustomized.Visible = false;
                    PnlTableField.Visible = false;
                    PnlPicture.Visible = false;
                    PnlMultiPicture.Visible = false;
                    PnlFile.Visible = false;
                    PnlMultiFile.Visible = false;
                    PnlRegion.Visible = false;
                    PnlKeyword.Visible = false;
                    PnlCaptcha.Visible = false;
                    PnlSelectUser.Visible = true;
                    PnlSelectDepartment.Visible = false;
                    PnlSelectRole.Visible = false;
                    PnlSelectCode.Visible = false;
                    PnlVote.Visible = false;                    
                    HdnFieldType.Value = "24";
                    break;
                case "RadSelectRegionType":
                    PnlText.Visible = false;
                    PnlMultiText.Visible = false;
                    PnlEditor.Visible = false;
                    PnlRadio.Visible = false;
                    PnlNumber.Visible = false;
                    PnlCurrency.Visible = false;
                    PnlDate.Visible = false;
                    PnlTime.Visible = false;
                    PnlURL.Visible = false;
                    PnlPhoneMobile.Visible = false;
                    PnlPhoneFixed.Visible = false;
                    PnlColor.Visible = false;
                    PnlCustomized.Visible = false;
                    PnlTableField.Visible = false;
                    PnlPicture.Visible = false;
                    PnlMultiPicture.Visible = false;
                    PnlFile.Visible = false;
                    PnlMultiFile.Visible = false;
                    PnlRegion.Visible = false;
                    PnlKeyword.Visible = false;
                    PnlCaptcha.Visible = false;
                    PnlSelectUser.Visible = false;
                    PnlSelectDepartment.Visible = true;
                    PnlSelectRole.Visible = false;
                    PnlSelectCode.Visible = false;
                    PnlVote.Visible = false;                    
                    HdnFieldType.Value = "23";
                    break;
                case "RadSelectRoleType":
                    PnlText.Visible = false;
                    PnlMultiText.Visible = false;
                    PnlEditor.Visible = false;
                    PnlRadio.Visible = false;
                    PnlNumber.Visible = false;
                    PnlCurrency.Visible = false;
                    PnlDate.Visible = false;
                    PnlTime.Visible = false;
                    PnlURL.Visible = false;
                    PnlPhoneMobile.Visible = false;
                    PnlPhoneFixed.Visible = false;
                    PnlColor.Visible = false;
                    PnlCustomized.Visible = false;
                    PnlTableField.Visible = false;
                    PnlPicture.Visible = false;
                    PnlMultiPicture.Visible = false;
                    PnlFile.Visible = false;
                    PnlMultiFile.Visible = false;
                    PnlRegion.Visible = false;
                    PnlKeyword.Visible = false;
                    PnlCaptcha.Visible = false;
                    PnlSelectUser.Visible = false;
                    PnlSelectDepartment.Visible = false;
                    PnlSelectRole.Visible = true;
                    PnlSelectCode.Visible = false;
                    PnlVote.Visible = false;                    
                    HdnFieldType.Value = "25";
                    break;
                case "RadSelectCodeType":
                    PnlText.Visible = false;
                    PnlMultiText.Visible = false;
                    PnlEditor.Visible = false;
                    PnlRadio.Visible = false;
                    PnlNumber.Visible = false;
                    PnlCurrency.Visible = false;
                    PnlDate.Visible = false;
                    PnlTime.Visible = false;
                    PnlURL.Visible = false;
                    PnlPhoneMobile.Visible = false;
                    PnlPhoneFixed.Visible = false;
                    PnlColor.Visible = false;
                    PnlCustomized.Visible = false;
                    PnlTableField.Visible = false;
                    PnlPicture.Visible = false;
                    PnlMultiPicture.Visible = false;
                    PnlFile.Visible = false;
                    PnlMultiFile.Visible = false;
                    PnlRegion.Visible = false;
                    PnlKeyword.Visible = false;
                    PnlCaptcha.Visible = false;
                    PnlSelectUser.Visible = false;
                    PnlSelectDepartment.Visible = false;
                    PnlSelectRole.Visible = false;
                    PnlSelectCode.Visible = true;
                    PnlVote.Visible = false;                    
                    HdnFieldType.Value = "22";
                    #region 加载代码选择SelectCode 数据项
                    try
                    {
                        using (TestDBEntities db = new TestDBEntities())
                        {
                            List<Dictionary> codelist = db.Dictionary.Where(p => p.ControlType == "SelectCode").ToList();
                            PnlCode.DataSource = codelist;
                            PnlCode.DataBind();
                        }
                    }
                    catch (Exception ex)
                    { throw ex; }
                    #endregion
                    break;
                case "RadVoteCtrlType":
                    PnlText.Visible = false;
                    PnlMultiText.Visible = false;
                    PnlEditor.Visible = false;
                    PnlRadio.Visible = false;
                    PnlNumber.Visible = false;
                    PnlCurrency.Visible = false;
                    PnlDate.Visible = false;
                    PnlTime.Visible = false;
                    PnlURL.Visible = false;
                    PnlPhoneMobile.Visible = false;
                    PnlPhoneFixed.Visible = false;
                    PnlColor.Visible = false;
                    PnlCustomized.Visible = false;
                    PnlTableField.Visible = false;
                    PnlPicture.Visible = false;
                    PnlMultiPicture.Visible = false;
                    PnlFile.Visible = false;
                    PnlMultiFile.Visible = false;
                    PnlRegion.Visible = false;
                    PnlKeyword.Visible = false;
                    PnlCaptcha.Visible = false;
                    PnlSelectUser.Visible = false;
                    PnlSelectDepartment.Visible = false;
                    PnlSelectRole.Visible = false;
                    PnlSelectCode.Visible = false;
                    PnlVote.Visible = true;                    
                    HdnFieldType.Value = "27";
                    break;
                case "RadTableField":
                    PnlText.Visible = false;
                    PnlMultiText.Visible = false;
                    PnlEditor.Visible = false;
                    PnlRadio.Visible = false;
                    PnlNumber.Visible = false;
                    PnlCurrency.Visible = false;
                    PnlDate.Visible = false;
                    PnlTime.Visible = false;
                    PnlURL.Visible = false;
                    PnlPhoneMobile.Visible = false;
                    PnlPhoneFixed.Visible = false;
                    PnlColor.Visible = false;
                    PnlCustomized.Visible = false;
                    PnlTableField.Visible = true;
                    PnlPicture.Visible = false;
                    PnlMultiPicture.Visible = false;
                    PnlFile.Visible = false;
                    PnlMultiFile.Visible = false;
                    PnlRegion.Visible = false;
                    PnlKeyword.Visible = false;
                    PnlCaptcha.Visible = false;
                    PnlSelectUser.Visible = false;
                    PnlSelectDepartment.Visible = false;
                    PnlSelectRole.Visible = false;
                    PnlSelectCode.Visible = false;
                    PnlVote.Visible = false;
                    HdnFieldType.Value = "29";
                    #region 加载数据项
                    try
                    {
                        using (TestDBEntities db = new TestDBEntities())
                        {
                            string modelname = Request.Params["ModelName"];
                            TableFieldtable.Text = "";
                            List<Model> codelist = db.Model.Where(q => q.ModelName != modelname).ToList();
                            TableFieldtable.DataSource = codelist;
                            TableFieldtable.DataBind();
                        }
                    }
                    catch (Exception ex)
                    { throw ex; }
                    #endregion
                    break;
                default:
                    break;
            }
            #endregion
        }

        //更改日期的格式时，更改日期默认值的格式
        protected void DateDisplayFormatChanged(Object sender, EventArgs e)
        {
            DevExpress.Web.ASPxEditors.ASPxComboBox cob = (DevExpress.Web.ASPxEditors.ASPxComboBox)sender;
            RadlDateDefaultType.EditFormatString = cob.Text;
            #region 加载代码选择DateField 数据项
            try
            {
                using (TestDBEntities entity = new TestDBEntities())
                {
                    Dictionary codecat = entity.Dictionary.Where(p => p.ControlType == "DateField").FirstOrDefault();
                    List<DictionaryItem> detaillist = entity.DictionaryItem.Where(oo => oo.DictionaryItemCode.StartsWith(codecat.DictionaryCode)).ToList();
                    PnlDateDisplayFormat.DataSource = detaillist;
                    PnlDateDisplayFormat.DataBind();
                }
            }
            catch (Exception ex)
            { throw ex; }
            #endregion
        }

        //更改时间的格式时，更改时间默认值的格式
        protected void TimeDisplayFormatChanged(Object sender, EventArgs e)
        {
            DevExpress.Web.ASPxEditors.ASPxComboBox cob = (DevExpress.Web.ASPxEditors.ASPxComboBox)sender;
            RadlTimeDefaultType.EditFormatString = cob.Text;
            #region 加载代码选择TimeField 数据项
            try
            {
                using (TestDBEntities entity = new TestDBEntities())
                {
                    Dictionary codecat = entity.Dictionary.Where(p => p.ControlType == "TimeField").FirstOrDefault();
                    List<DictionaryItem> detaillist = entity.DictionaryItem.Where(oo => oo.DictionaryItemCode.StartsWith(codecat.DictionaryCode)).ToList();
                    PnlTimeDisplayFormat.DataSource = detaillist;
                    PnlTimeDisplayFormat.DataBind();
                }
            }
            catch (Exception ex)
            { throw ex; }
            #endregion
        }

        //控件：“选项”中的四种类型，触发事件
        /// <summary>
        /// 控件：选项中的四种类型，触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void RadlChoiceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (RadlChoiceType.SelectedItem.Value.ToString())
            {
                case "1":
                    HdnFieldType.Value = "4";
                    PnlRadioWidthTd.Visible = true;
                    PnlRadioHeightTd.Visible = true;
                    #region 加载代码选择数据项
                    try
                    {
                        using (TestDBEntities db = new TestDBEntities())
                        {
                            List<Dictionary> codelist = db.Dictionary.Where(p => p.ControlType == "SelectCode").ToList();
                            RadlChoiceCode.DataSource = codelist;
                            RadlChoiceCode.DataBind();
                        }
                    }
                    catch (Exception ex)
                    { throw ex; }
                    #endregion
                    break;
                case "2":
                    HdnFieldType.Value = "5";
                    PnlRadioWidthTd.Visible = true;
                    PnlRadioHeightTd.Visible = true;
                    #region 加载代码选择数据项
                    try
                    {
                        using (TestDBEntities db = new TestDBEntities())
                        {
                            List<Dictionary> codelist = db.Dictionary.Where(p => p.ControlType == "SelectCode").ToList();
                            RadlChoiceCode.DataSource = codelist;
                            RadlChoiceCode.DataBind();
                        }
                    }
                    catch (Exception ex)
                    { throw ex; }
                    #endregion
                    break;
                case "3":
                    HdnFieldType.Value = "6";
                    PnlRadioWidthTd.Visible = false;
                    PnlRadioHeightTd.Visible = false;
                    #region 加载代码选择数据项
                    try
                    {
                        using (TestDBEntities db = new TestDBEntities())
                        {
                            List<Dictionary> codelist = db.Dictionary.Where(p => p.ControlType == "SelectCode").ToList();
                            RadlChoiceCode.DataSource = codelist;
                            RadlChoiceCode.DataBind();
                        }
                    }
                    catch (Exception ex)
                    { throw ex; }
                    #endregion
                    break;
                case "4":
                    HdnFieldType.Value = "7";
                    PnlRadioWidthTd.Visible = false;
                    PnlRadioHeightTd.Visible = false;
                    #region 加载代码选择数据项
                    try
                    {
                        using (TestDBEntities db = new TestDBEntities())
                        {
                            List<Dictionary> codelist = db.Dictionary.Where(p => p.ControlType == "SelectCode").ToList();
                            RadlChoiceCode.DataSource = codelist;
                            RadlChoiceCode.DataBind();
                        }
                    }
                    catch (Exception ex)
                    { throw ex; }
                    #endregion
                    break;
            }
        }
               
        //提交按钮的触发事件
        /// <summary>
        /// 提交按钮的触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void SaveButtion_Click(Object sender, EventArgs e)
        {
            Response.Write("<br>");
            Response.Write("<br>");
            Response.Write("<br>");
            #region 更新字段
            if (EditModeHidden.Value == "Edit")
            {
                #region 更新ModelField表
                StringBuilder SQL = new StringBuilder();
                string FieldCode = Request.QueryString["FieldCode"];//字段编码
                using (TestDBEntities entities = new TestDBEntities())
                {
                    ContentModel1._5.Entities.ModelField field = (ContentModel1._5.Entities.ModelField)entities.ModelField.Where(s => s.Code == FieldCode).FirstOrDefault();

                    string name = TxtFieldName.Text;
                    string nick = TxtFieldAliax.Text;
                    string tooltip = TxtTips.Text;
                    string remark = TxtDescription.Text;
                    int isrequired = Convert.ToInt16(RadlEnableNull.SelectedItem.Value);
                    int isallowsearch = Convert.ToInt16(RadlEnableShowOnSearchForm.SelectedItem.Value);
                    int isvisble = Convert.ToInt16(RadDisabled.SelectedItem.Value);
                    int isreadonly = Convert.ToInt16(IsReadOnly.SelectedItem.Value);
                    short fieldtype = (short)field.FieldType;
                    string _start = string.Format("update ModelField set Name='{0}',Nick='{1}',Tooltip='{2}',Remark='{3}',IsRequired={4},IsAllowSearch={5},IsReadOnly={6},IsVisible={7},FieldType={8}",
                        name, nick, tooltip, remark, isrequired, isallowsearch, isreadonly, isvisble, fieldtype, field.FieldID
                        );
                    SQL.Append(_start);

                    #region 数据
                    string _dysql = string.Empty;
                    string width;
                    string height;
                    string maxlength;
                    string errortext;
                    string nulltext;
                    string codecat;
                    string displayformat;
                    int singleormultiple;
                    string defaultvalue;
                    string minvalue;
                    string maxvalue;
                    string imagesize;
                    string haswatermark;
                    string watermarktype;
                    #endregion
                    switch (field.FieldType)
                    {
                        case 1:
                            width = PnlTextWidth.Number.ToString();
                            height = PnlTextHeight.Number.ToString();
                            maxlength = TxtTextMaxLength.Number.ToString();
                            errortext = PnlTextErrorText.Text;
                            nulltext = PnlTextNullText.Text;
                            defaultvalue = TxtTextDefaultValue.Text;
                            _dysql = string.Format(",Width='{0}',Height='{1}',MaxLength='{2}',ErrorText='{3}',NullText='{4}',DefaultValue='{5}'", width, height, maxlength, errortext, nulltext, defaultvalue);
                            break;
                        case 2:
                            width = TxtMultiTextWidth.Number.ToString();
                            height = TxtMultiTextHeight.Number.ToString();
                            errortext = PnlMultiTextErrorText.Text;
                            nulltext = PnlMultiTextNullText.Text;
                            defaultvalue = TxtMultiDefault.Text;
                            _dysql = string.Format(",Width='{0}',Height='{1}',ErrorText='{2}',NullText='{3}',DefaultValue='{4}'", width, height, errortext, nulltext, defaultvalue);
                            break;
                        case 3:
                            width = TxtEditorWidth.Number.ToString();
                            height = TxtEditorHight.Number.ToString();
                            errortext = PnlEditorErrorText.Text;
                            defaultvalue = PnlEditorDefault.Html;
                            _dysql = string.Format(",Width='{0}',Height='{1}',ErrorText='{2}',DefaultValue='{3}'", width, height, errortext, defaultvalue);
                            break;
                        case 4:
                            errortext = PnlRadioErrorTip.Text;
                            width = PnlRadioWidth.Number.ToString();
                            height = PnlRadioHeight.Number.ToString();
                            codecat = RadlChoiceCode.Text;
                            _dysql = string.Format(",ErrorText='{0}',Width='{1}',Height='{2}',CodeCat='{3}'", errortext, width, height, codecat);
                            break;
                        case 5:
                            errortext = PnlRadioErrorTip.Text;
                            width = PnlRadioWidth.Number.ToString();
                            height = PnlRadioHeight.Number.ToString();
                            codecat = RadlChoiceCode.Text;
                            _dysql = string.Format(",ErrorText='{0}',Width='{1}',Height='{2}',CodeCat='{3}'", errortext, width, height, codecat);
                            break;
                        case 6:
                            errortext = PnlRadioErrorTip.Text;
                            codecat = RadlChoiceCode.Text;
                            _dysql = string.Format(",ErrorText='{0}',CodeCat='{1}'", errortext, codecat);
                            break;
                        case 7:
                            errortext = PnlRadioErrorTip.Text;
                            codecat = RadlChoiceCode.Text;
                            _dysql = string.Format(",ErrorText='{0}',CodeCat='{1}'", errortext, codecat);
                            break;
                        case 8:
                            width = PnlNumberWidth.Number.ToString();
                            height = PnlNumberHeight.Number.ToString();
                            maxlength = PnlNumberMaxLength.Text;
                            minvalue = TxtNumberMinValue.Number.ToString();
                            maxvalue = TxtNumberMaxValue.Number.ToString();
                            displayformat = TxtNumberDisplayFormat.Text;
                            errortext = PnlNumberErrorText.Text;
                            nulltext = PnlNumberNullText.Text;
                            defaultvalue = TxtNumberDefaultValue.Number.ToString();
                            _dysql = string.Format(",Width='{0}',Height='{1}',MaxLength='{2}',MinValue='{3}',MaxValue='{4}',DisplayFormat='{5}',ErrorText='{6}',NullText='{7}',DefaultValue='{8}'", width, height, maxlength, minvalue, maxvalue, displayformat, errortext, nulltext, defaultvalue);
                            break;
                        case 9:
                            width = PnlCurrencyWidth.Number.ToString();
                            height = PnlCurrencyHeight.Number.ToString();
                            maxlength = PnlCurrencyMaxLength.Text;
                            minvalue = TxtCurrencyMin.Number.ToString();
                            maxvalue = TxtCurrencyMax.Number.ToString();
                            displayformat = PnlCurrencyDisplayFormat.Text;
                            errortext = PnlCurrencyErrorText.Text;
                            nulltext = PnlCurrencyNullText.Text;
                            defaultvalue = TxtCurrencyDefaultValue.Number.ToString();
                            _dysql = string.Format(",Width='{0}',Height='{1}',MaxLength='{2}',MinValue='{3}',MaxValue='{4}',DisplayFormat='{5}',ErrorText='{6}',NullText='{7}',DefaultValue='{8}'", width, height, maxlength, minvalue, maxvalue, displayformat, errortext, nulltext, defaultvalue);
                            break;
                        case 10:
                            width = PnlDateWidth.Number.ToString();
                            height = PnlDateHeight.Number.ToString();
                            displayformat = PnlDateDisplayFormat.Text;
                            errortext = PnlDateErrorText.Text;
                            nulltext = PnlDateNullText.Text;
                            defaultvalue = RadlDateDefaultType.Date.ToString();
                            _dysql = string.Format(",Width='{0}',Height='{1}',DisplayFormat='{2}',ErrorText='{3}',NullText='{4}',DefaultValue='{5}'", width, height, displayformat, errortext, nulltext, defaultvalue);
                            break;
                        case 11:
                            width = PnlTimeWidth.Number.ToString();
                            height = PnlTimeHeight.Number.ToString();
                            displayformat = PnlTimeDisplayFormat.Text;
                            errortext = PnlTimeErrorText.Text;
                            defaultvalue = RadlTimeDefaultType.DateTime.ToString();
                            _dysql = string.Format(",Width='{0}',Height='{1}',DisplayFormat='{2}',ErrorText='{3}',DefaultValue='{4}'", width, height, displayformat, errortext, defaultvalue);
                            break;
                        case 12:
                            width = PnlURLWidth.Number.ToString();
                            height = PnlURLHeight.Number.ToString();
                            _dysql = string.Format(",Width='{0}',Height='{1}'", width, height);
                            break;
                        case 13:
                            width = PnlPhoneFixedWidth.Number.ToString();
                            height = PnlPhoneFixedHeight.Number.ToString();
                            errortext = PnlPhoneFixedErrorText.Text;
                            defaultvalue = PnlPhoneFixedDefault.Text;
                            _dysql = string.Format(",Width='{0}',Height='{1}',ErrorText='{2}',DefaultValue='{3}'", width, height, errortext, defaultvalue);
                            break;
                        case 14:
                            width = PnlPhoneMobileWidth.Number.ToString();
                            height = PnlPhoneMobileHeight.Number.ToString();
                            errortext = PnlPhoneMobileErrorText.Text;
                            defaultvalue = PnlPhoneMobileDefaultText.Text;
                            _dysql = string.Format(",Width='{0}',Height='{1}',ErrorText='{2}',DefaultValue='{3}'", width, height, errortext, defaultvalue);
                            break;
                        case 15:
                            width = PnlCustomizedWidth.Number.ToString();
                            height = PnlCustomizedHeight.Number.ToString();
                            displayformat = PnlCustomizedDisplayFormat.Text;
                            errortext = PnlCustomizedErrorText.Text;
                            nulltext = PnlCustomizedNullText.Text;
                            defaultvalue = PnlCustomizedDefaultValue.Text.ToString();
                            _dysql = string.Format(",Width='{0}',Height='{1}',DisplayFormat='{2}',ErrorText='{3}',NullText='{4}',DefaultValue='{5}'", width, height, displayformat, errortext, nulltext, defaultvalue);
                            break;
                        case 16:
                            width = PnlColorWidth.Number.ToString();
                            height = PnlColorHeight.Number.ToString();
                            errortext = PnlColorErrorText.Text;
                            nulltext = PnlColorNullText.Text;
                            defaultvalue = PnlColorDefaultValue.Text;
                            _dysql = string.Format(",Width='{0}',Height='{1}',ErrorText='{2}',NullText='{3}',DefaultValue='{4}'", width, height, errortext, nulltext, defaultvalue);
                            break;
                        case 17:
                            width = PnlImageWidth.Number.ToString();
                            height = PnlImageHeight.Number.ToString();
                            imagesize = TxtImageSize.Number.ToString();
                            haswatermark = PnlImageRadlHasWm.SelectedItem.Value.ToString();
                            watermarktype = PnlImageRadWmStyle.SelectedItem.Value.ToString();
                            displayformat = PictureStyle.Text;
                            _dysql = string.Format(",Width='{0}',Height='{1}',ImageSize='{2}',HasWaterMark='{3}',WaterMarkType='{4}',DisplayFormat='{5}'", width, height, imagesize, haswatermark, watermarktype, displayformat);
                            break;
                        case 18:
                            width = PnlMultipleImageWidth.Number.ToString();
                            height = PnlMultipleImageHeight.Number.ToString();
                            imagesize = PnlMultipleImageMaxSize.Number.ToString();
                            haswatermark = PnlMultipleImageHasWm.SelectedItem.Value.ToString();
                            watermarktype = PnlMultipleImageWmStyle.SelectedItem.Value.ToString();
                            displayformat = MultiPictureStyle.Text;
                            _dysql = string.Format(",Width='{0}',Height='{1}',ImageSize='{2}',HasWaterMark='{3}',WaterMarkType='{4}',DisplayFormat='{5}'", width, height, imagesize, haswatermark, watermarktype, displayformat);
                            break;
                        case 22:
                            errortext = PnlSelectCodeErrorText.Text;
                            nulltext = PnlSelectCodeNullText.Text;
                            codecat = PnlCode.Text;
                            displayformat = DisplayFormat.SelectedItem.Value.ToString();
                            singleormultiple = Convert.ToInt16(SingleOrMultiple.SelectedItem.Value.ToString());
                            _dysql = string.Format(",ErrorText='{0}',NullText='{1}',CodeCat='{2}',DisplayFormat='{3}',SingleOrMultiple={4}", errortext, nulltext, codecat, displayformat, singleormultiple);
                            break;
                        case 23:
                            break;
                        case 24:
                            break;
                        case 25:
                            break;
                    }
                    SQL.Append(_dysql);
                    string _end = string.Format(" where Code='{0}'", field.Code);
                    SQL.Append(_end);
                    if (ReturnType.Succuss == SqlHelper.UpDateRecord(SQL.ToString()))
                    {
                        Response.Write("ModelField记录更新成功！");
                    }
                }

                #endregion
            }
            #endregion
            #region 添加字段
            else
            {
                #region 修改生成表结构
                //表名称
                string modelName = Request.Params["ModelName"];
                //模型编码
                string modelCode = Request.Params["ModelCode"];
                //生成字段Guid（即code）
                string code = Guid.NewGuid().ToString("N").ToUpper();
                //获取控件类型以确定新表列的类型
                short ctrltype = Convert.ToInt16(HdnFieldType.Value);
                //新表列的名称
                string fieldName = null;
                //新表列的类型
                string sqlType = null;
                fieldName = TxtFieldName.Text;
                sqlType = FieldTypeToSqlDataType(ctrltype);
                var result = ReturnType.Error;
                if (ctrltype == 4 || ctrltype == 5 || ctrltype == 6 || ctrltype == 7 || ctrltype == 22 || ctrltype == 23 || ctrltype == 24 || ctrltype == 25)
                {
                    try
                    {
                        result = SqlHelper.InsertField(modelName, fieldName + "Code", sqlType);
                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex.Message);
                    }
                    if (ReturnType.Succuss == result) { Response.Write("模型字段Code添加成功！"); } else { return; }
                    try
                    {
                        result = SqlHelper.InsertField(modelName, fieldName + "Value", sqlType);
                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex.Message);
                    }
                    if (ReturnType.Succuss == result) { Response.Write("模型字段Value添加成功！"); } else { return; }
                }
                else
                {
                    try
                    {
                        result = SqlHelper.InsertField(modelName, fieldName, sqlType);
                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex.Message);
                    }
                    if (ReturnType.Succuss == result) { Response.Write("模型字段添加成功！"); } else { return; }
                }
                #endregion
                #region 写入TableRelation表，TableFieldRelation表中
                if (ctrltype == 29)
                {
                    string tableCode = Request.Params["ModelCode"];
                    string tableName = Request.Params["ModelName"];
                    result = SqlHelper.InsertTableRelation(TableFieldtable.Value.ToString(), TableFieldtable.Text, tableCode, tableName);
                    if (ReturnType.Succuss == result) { Response.Write("表关联关系添加成功！"); } else { return; }
                    result = SqlHelper.InsertTableFieldRelation(TableFieldtable.Value.ToString(), TableFieldtable.Text, TableFieldfield.Value.ToString(), TableFieldfield.Text, tableCode, tableName, code, TxtFieldName.Text);
                    if (ReturnType.Succuss == result) { Response.Write("表字段关联关系添加成功！"); } else { return; }
                }
                #endregion
                #region 写入ModelField表中
                if (ctrltype == 4 || ctrltype == 5 || ctrltype == 6 || ctrltype == 7 || ctrltype == 22 || ctrltype == 23 || ctrltype == 24 || ctrltype == 25)
                {
                    #region 写入ModelField表中Code
                    string SQL = null;
                    StringBuilder tableField = new StringBuilder();
                    StringBuilder fieldValue = new StringBuilder();
                    //模型编码
                    tableField.Append("ModelCode,");
                    fieldValue.Append("'" + modelCode + "',");
                    //模型名称
                    tableField.Append("ModelName,");
                    fieldValue.Append("'" + modelName + "',");
                    //字段编码
                    tableField.Append("Code,");
                    fieldValue.Append("'" + code + "',");
                    //字段名称
                    tableField.Append("Name,");
                    fieldValue.Append("'" + TxtFieldName.Text + "Code',");
                    //字段别名
                    tableField.Append("Nick,");
                    fieldValue.Append("'" + TxtFieldAliax.Text + "',");
                    //字段提示
                    tableField.Append("Tooltip,");
                    fieldValue.Append("'" + TxtTips.Text + "',");
                    //字段描述
                    tableField.Append("Remark,");
                    fieldValue.Append("'" + TxtDescription.Text + "',");
                    //是否必填
                    tableField.Append("IsRequired,");
                    fieldValue.Append(RadlEnableNull.SelectedItem.Value + ",");
                    //是否在搜索项中
                    tableField.Append("IsAllowSearch,");
                    fieldValue.Append(RadlEnableShowOnSearchForm.SelectedItem.Value + ",");
                    //是否可显示
                    tableField.Append("IsVisible,");
                    fieldValue.Append("0,");
                    //是否只读
                    tableField.Append("IsReadOnly,");
                    fieldValue.Append(IsReadOnly.SelectedItem.Value + ",");
                    /////////////////
                    //类型独有字段，对于不同控件具有不同的提交的控件，SQL相应变化
                    /////////////////
                    #region switch
                    switch (ctrltype)
                    {
                        case 4://4.	单选下拉列表框
                            tableField.Append("ErrorText,Width,Height,CodeCat,");
                            fieldValue.Append("'" + PnlRadioErrorTip.Text + "',");
                            fieldValue.Append("'" + PnlRadioWidth.Number + "',");
                            fieldValue.Append("'" + PnlRadioHeight.Number + "',");
                            fieldValue.Append("'" + RadlChoiceCode.Text + "',");
                            break;
                        case 5://5.	多选下拉列表框
                            tableField.Append("ErrorText,Width,Height,CodeCat,");
                            fieldValue.Append("'" + PnlRadioErrorTip.Text + "',");
                            fieldValue.Append("'" + PnlRadioWidth.Number + "',");
                            fieldValue.Append("'" + PnlRadioHeight.Number + "',");
                            fieldValue.Append("'" + RadlChoiceCode.Text + "',");
                            break;
                        case 6://6.	单选按钮
                            tableField.Append("ErrorText,CodeCat,");
                            fieldValue.Append("'" + PnlRadioErrorTip.Text + "',");
                            fieldValue.Append("'" + RadlChoiceCode.Text + "',");
                            break;
                        case 7://7.	复选按钮
                            tableField.Append("ErrorText,CodeCat,");
                            fieldValue.Append("'" + PnlRadioErrorTip.Text + "',");
                            fieldValue.Append("'" + RadlChoiceCode.Text + "',");
                            break;
                        case 22://22.	代码选择
                            tableField.Append("ErrorText,NullText,CodeCat,SingleOrMultiple,DisplayFormat,TargetModelName,");
                            fieldValue.Append("'" + PnlSelectCodeErrorText.Text + "',");
                            fieldValue.Append("'" + PnlSelectCodeNullText.Text + "',");
                            fieldValue.Append("'" + PnlCode.Text + "',"); //AspxComboBox
                            fieldValue.Append("'" + SingleOrMultiple.SelectedItem.Value.ToString() + "',");
                            fieldValue.Append("'" + DisplayFormat.SelectedItem.Value.ToString() + "',");
                            fieldValue.Append("'Dictionary',");
                            break;
                        case 23://23.	机构选择
                            tableField.Append("TargetModelName,");
                            fieldValue.Append("'Base_Org',");
                            break;
                        case 24://24.	用户选择
                            tableField.Append("TargetModelName,");
                            fieldValue.Append("'Base_User',");
                            break;
                        case 25://25.	角色选择
                            tableField.Append("TargetModelName,");
                            fieldValue.Append("'Base_Role',");
                            break;
                    }
                    #endregion
                    tableField.Append("FieldType,");
                    fieldValue.Append(ctrltype + ",");
                    tableField.Remove(tableField.Length - 1, 1);
                    fieldValue.Remove(fieldValue.Length - 1, 1);
                    SQL = string.Format("insert into ModelField({0}) values({1})", tableField.ToString(), fieldValue.ToString());
                    //写入数据库
                    if (ReturnType.Succuss == SqlHelper.InsertRecord(SQL))
                    {
                        Response.Write("ModelField记录Code添加成功！");
                    }
                    #endregion
                    #region 写入ModelField表中Value
                    SQL = null;
                    tableField = new StringBuilder();
                    fieldValue = new StringBuilder();
                    //模型编码
                    tableField.Append("ModelCode,");
                    fieldValue.Append("'" + modelCode + "',");
                    //模型名称
                    tableField.Append("ModelName,");
                    fieldValue.Append("'" + modelName + "',");
                    //字段编码
                    tableField.Append("Code,");
                    fieldValue.Append("'" + code + "',");
                    //字段名称
                    tableField.Append("Name,");
                    fieldValue.Append("'" + TxtFieldName.Text + "Value',");
                    //字段别名
                    tableField.Append("Nick,");
                    fieldValue.Append("'" + TxtFieldAliax.Text + "',");
                    //字段提示
                    tableField.Append("Tooltip,");
                    fieldValue.Append("'" + TxtTips.Text + "',");
                    //字段描述
                    tableField.Append("Remark,");
                    fieldValue.Append("'" + TxtDescription.Text + "',");
                    //是否必填
                    tableField.Append("IsRequired,");
                    fieldValue.Append(RadlEnableNull.SelectedItem.Value + ",");
                    //是否在搜索项中
                    tableField.Append("IsAllowSearch,");
                    fieldValue.Append(RadlEnableShowOnSearchForm.SelectedItem.Value + ",");
                    //是否可显示
                    tableField.Append("IsVisible,");
                    fieldValue.Append(RadDisabled.SelectedItem.Value + ",");
                    //是否只读
                    tableField.Append("IsReadOnly,");
                    fieldValue.Append(IsReadOnly.SelectedItem.Value + ",");
                    /////////////////
                    //类型独有字段，对于不同控件具有不同的提交的控件，SQL相应变化
                    /////////////////
                    #region switch
                    switch (ctrltype)
                    {
                        case 4://4.	单选下拉列表框
                            tableField.Append("ErrorText,Width,Height,CodeCat,");
                            fieldValue.Append("'" + PnlRadioErrorTip.Text + "',");
                            fieldValue.Append("'" + PnlRadioWidth.Number + "',");
                            fieldValue.Append("'" + PnlRadioHeight.Number + "',");
                            fieldValue.Append("'" + RadlChoiceCode.Text + "',");
                            break;
                        case 5://5.	多选下拉列表框
                            tableField.Append("ErrorText,Width,Height,CodeCat,");
                            fieldValue.Append("'" + PnlRadioErrorTip.Text + "',");
                            fieldValue.Append("'" + PnlRadioWidth.Number + "',");
                            fieldValue.Append("'" + PnlRadioHeight.Number + "',");
                            fieldValue.Append("'" + RadlChoiceCode.Text + "',");
                            break;
                        case 6://6.	单选按钮
                            tableField.Append("ErrorText,CodeCat,");
                            fieldValue.Append("'" + PnlRadioErrorTip.Text + "',");
                            fieldValue.Append("'" + RadlChoiceCode.Text + "',");
                            break;
                        case 7://7.	复选按钮
                            tableField.Append("ErrorText,CodeCat,");
                            fieldValue.Append("'" + PnlRadioErrorTip.Text + "',");
                            fieldValue.Append("'" + RadlChoiceCode.Text + "',");
                            break;
                        case 22://22.	代码选择
                            tableField.Append("ErrorText,NullText,CodeCat,SingleOrMultiple,DisplayFormat,TargetModelName,");
                            fieldValue.Append("'" + PnlSelectCodeErrorText.Text + "',");
                            fieldValue.Append("'" + PnlSelectCodeNullText.Text + "',");
                            fieldValue.Append("'" + PnlCode.Text + "',");
                            fieldValue.Append("'" + SingleOrMultiple.SelectedItem.Value.ToString() + "',");
                            fieldValue.Append("'" + DisplayFormat.SelectedItem.Value.ToString() + "',");
                            fieldValue.Append("'Dictionary',");//TargetModelName赋默认值：Dictionary
                            break;
                        case 23://23.	机构选择
                            tableField.Append("TargetModelName,"); //TargetModelName赋默认值：Base_Org
                            fieldValue.Append("'Base_Org',");  
                            break;
                        case 24://24.	用户选择
                            tableField.Append("TargetModelName,");//TargetModelName赋默认值：Base_User
                            fieldValue.Append("'Base_User',");
                            break;
                        case 25://25.	角色选择
                            tableField.Append("TargetModelName,");//TargetModelName赋默认值：Base_Role
                            fieldValue.Append("'Base_Role',");
                            break;
                    }
                    #endregion
                    tableField.Append("FieldType,");
                    fieldValue.Append(ctrltype + ",");
                    tableField.Remove(tableField.Length - 1, 1);
                    fieldValue.Remove(fieldValue.Length - 1, 1);
                    SQL = string.Format("insert into ModelField({0}) values({1})", tableField.ToString(), fieldValue.ToString());
                    //写入数据库
                    if (ReturnType.Succuss == SqlHelper.InsertRecord(SQL))
                    {
                        Response.Write("ModelField记录Value添加成功！");
                    }
                    #endregion

                }
                else if (ctrltype == 29)
                {
                    string SQL = null;
                    StringBuilder tableField = new StringBuilder();
                    StringBuilder fieldValue = new StringBuilder();
                    //模型编码
                    tableField.Append("ModelCode,");
                    fieldValue.Append("'" + modelCode + "',");
                    //模型名称
                    tableField.Append("ModelName,");
                    fieldValue.Append("'" + modelName + "',");
                    //字段编码
                    tableField.Append("Code,");
                    fieldValue.Append("'" + code + "',");
                    //字段名称
                    tableField.Append("Name,");
                    fieldValue.Append("'" + TxtFieldName.Text + "',");
                    //字段别名
                    tableField.Append("Nick,");
                    fieldValue.Append("'" + TxtFieldAliax.Text + "',");
                    //字段提示
                    tableField.Append("Tooltip,");
                    fieldValue.Append("'" + TxtTips.Text + "',");
                    //字段描述
                    tableField.Append("Remark,");
                    fieldValue.Append("'" + TxtDescription.Text + "',");

                    tableField.Append("FieldType,");
                    fieldValue.Append(ctrltype + ",");
                    tableField.Remove(tableField.Length - 1, 1);
                    fieldValue.Remove(fieldValue.Length - 1, 1);
                    SQL = string.Format("insert into ModelField({0}) values({1})", tableField.ToString(), fieldValue.ToString());
                    //写入数据库
                    if (ReturnType.Succuss == SqlHelper.InsertRecord(SQL))
                    {
                        Response.Write("ModelField记录添加成功！");
                    }
                }
                else
                {
                    #region 写入ModelField表中
                    string SQL = null;
                    StringBuilder tableField = new StringBuilder();
                    StringBuilder fieldValue = new StringBuilder();
                    //模型编码
                    tableField.Append("ModelCode,");
                    fieldValue.Append("'" + modelCode + "',");
                    //模型名称
                    tableField.Append("ModelName,");
                    fieldValue.Append("'" + modelName + "',");
                    //字段编码
                    tableField.Append("Code,");
                    fieldValue.Append("'" + code + "',");
                    //字段名称
                    tableField.Append("Name,");
                    fieldValue.Append("'" + TxtFieldName.Text + "',");
                    //字段别名
                    tableField.Append("Nick,");
                    fieldValue.Append("'" + TxtFieldAliax.Text + "',");
                    //字段提示
                    tableField.Append("Tooltip,");
                    fieldValue.Append("'" + TxtTips.Text + "',");
                    //字段描述
                    tableField.Append("Remark,");
                    fieldValue.Append("'" + TxtDescription.Text + "',");
                    //是否必填
                    tableField.Append("IsRequired,");
                    fieldValue.Append(RadlEnableNull.SelectedItem.Value + ",");
                    //是否在搜索项中
                    tableField.Append("IsAllowSearch,");
                    fieldValue.Append(RadlEnableShowOnSearchForm.SelectedItem.Value + ",");
                    //是否可显示
                    tableField.Append("IsVisible,");
                    fieldValue.Append(RadDisabled.SelectedItem.Value + ",");
                    //是否只读
                    tableField.Append("IsReadOnly,");
                    fieldValue.Append(IsReadOnly.SelectedItem.Value + ",");
                    /////////////////
                    //类型独有字段，对于不同控件具有不同的提交的控件，SQL相应变化
                    /////////////////
                    #region switch
                    switch (ctrltype)
                    {
                        case 0:
                            break;
                        case 1://1.	单行文本
                            tableField.Append("ErrorText,NullText,Width,Height,MaxLength,DefaultValue,");
                            fieldValue.Append("'" + PnlTextErrorText.Text + "',");
                            fieldValue.Append("'" + PnlTextNullText.Text + "',");
                            fieldValue.Append("'" + PnlTextWidth.Number + "',");
                            fieldValue.Append("'" + PnlTextHeight.Number + "',");
                            fieldValue.Append("'" + TxtTextMaxLength.Number + "',");
                            fieldValue.Append("'" + TxtTextDefaultValue.Text + "',");
                            break;
                        case 2://2.	多行文本
                            tableField.Append("ErrorText,NullText,Width,Height,DefaultValue,");
                            fieldValue.Append("'" + PnlMultiTextErrorText.Text + "',");
                            fieldValue.Append("'" + PnlMultiTextNullText.Text + "',");
                            fieldValue.Append("'" + TxtMultiTextWidth.Number + "',");
                            fieldValue.Append("'" + TxtMultiTextHeight.Number + "',");
                            fieldValue.Append("'" + TxtMultiDefault.Text + "',");
                            break;
                        case 3://3.	HTML文本
                            tableField.Append("ErrorText,Width,Height,DefaultValue,");
                            fieldValue.Append("'" + PnlEditorErrorText.Text + "',");
                            fieldValue.Append("'" + TxtEditorWidth.Number + "',");
                            fieldValue.Append("'" + TxtEditorHight.Number + "',");
                            fieldValue.Append("'" + PnlEditorDefault.Html + "',");
                            break;
                        case 8://8.	数字
                            tableField.Append("Width,Height,MaxLength,MinValue,MaxValue,DisplayFormat,ErrorText,NullText,DefaultValue,");
                            fieldValue.Append(PnlNumberWidth.Number + ",");
                            fieldValue.Append(PnlNumberHeight.Number + ",");
                            fieldValue.Append(PnlNumberMaxLength.Number + ",");
                            fieldValue.Append("'" + TxtNumberMinValue.Number + "',");
                            fieldValue.Append("'" + TxtNumberMaxValue.Number + "',");
                            fieldValue.Append("'" + TxtNumberDisplayFormat.Text + "',");
                            fieldValue.Append("'" + PnlNumberErrorText.Text + "',");
                            fieldValue.Append("'" + PnlNumberNullText.Text + "',");
                            fieldValue.Append("'" + TxtNumberDefaultValue.Number + "',");
                            break;
                        case 9://9.	货币
                            tableField.Append("Width,Height,MaxLength,MinValue,MaxValue,DisplayFormat,ErrorText,NullText,DefaultValue,");
                            fieldValue.Append(PnlCurrencyWidth.Number + ",");
                            fieldValue.Append(PnlCurrencyHeight.Number + ",");
                            fieldValue.Append(PnlCurrencyMaxLength.Number + ",");
                            fieldValue.Append("'" + TxtCurrencyMin.Number + "',");
                            fieldValue.Append("'" + TxtCurrencyMax.Number + "',");
                            fieldValue.Append("'" + PnlCurrencyDisplayFormat.Text + "',");
                            fieldValue.Append("'" + PnlCurrencyErrorText.Text + "',");
                            fieldValue.Append("'" + PnlCurrencyNullText.Text + "',");
                            fieldValue.Append("'" + TxtCurrencyDefaultValue.Number + "',");
                            break;
                        case 10://10.	日期
                            tableField.Append("Width,Height,DisplayFormat,ErrorText,NullText,DefaultValue,");
                            fieldValue.Append("'" + PnlDateWidth.Number + "',");
                            fieldValue.Append("'" + PnlDateHeight.Number + "',");
                            fieldValue.Append("'" + PnlDateDisplayFormat.Text + "',");
                            fieldValue.Append("'" + PnlDateErrorText.Text + "',");
                            fieldValue.Append("'" + PnlDateNullText.Text + "',");
                            fieldValue.Append("'" + RadlDateDefaultType.Date + "',");
                            break;
                        case 11://11.	时间
                            tableField.Append("Width,Height,DisplayFormat,ErrorText,DefaultValue,");
                            fieldValue.Append("'" + PnlTimeWidth.Number + "',");
                            fieldValue.Append("'" + PnlTimeHeight.Number + "',");
                            fieldValue.Append("'" + PnlTimeDisplayFormat.Text + "',");
                            fieldValue.Append("'" + PnlTimeErrorText.Text + "',");
                            fieldValue.Append("'" + RadlTimeDefaultType.DateTime + "',");
                            break;
                        case 12://12.	超链接
                            tableField.Append("Width,Height,");
                            fieldValue.Append("'" + PnlURLWidth.Number + "',");
                            fieldValue.Append("'" + PnlURLHeight.Number + "',");
                            break;
                        case 13://13.	固定电话号码
                            tableField.Append("Width,Height,ErrorText,DefaultValue,");
                            fieldValue.Append("'" + PnlPhoneFixedWidth.Number + "',");
                            fieldValue.Append("'" + PnlPhoneFixedHeight.Number + "',");
                            fieldValue.Append("'" + PnlPhoneFixedErrorText.Text + "',");
                            fieldValue.Append("'" + PnlPhoneFixedDefault.Text + "',");
                            break;
                        case 14://14.	移动电话号码
                            tableField.Append("Width,Height,ErrorText,DefaultValue,");
                            fieldValue.Append("'" + PnlPhoneMobileWidth.Number + "',");
                            fieldValue.Append("'" + PnlPhoneMobileHeight.Number + "',");
                            fieldValue.Append("'" + PnlPhoneMobileErrorText.Text + "',");
                            fieldValue.Append("'" + PnlPhoneMobileDefaultText.Text + "',");
                            break;
                        case 15://15.	自定义文本
                            tableField.Append("Width,Height,DisplayFormat,ErrorText,NullText,DefaultValue,");
                            fieldValue.Append("'" + PnlCustomizedWidth.Number + "',");
                            fieldValue.Append("'" + PnlCustomizedHeight.Number + "',");
                            fieldValue.Append("'" + PnlCustomizedDisplayFormat.Text + "',");
                            fieldValue.Append("'" + PnlCustomizedErrorText.Text + "',");
                            fieldValue.Append("'" + PnlCustomizedNullText.Text + "',");
                            fieldValue.Append("'" + PnlCustomizedDefaultValue.Text + "',");
                            break;
                        case 16://16.	颜色代码
                            tableField.Append("Width,Height,ErrorText,NullText,DefaultValue,");
                            fieldValue.Append("'" + PnlColorWidth.Number + "',");
                            fieldValue.Append("'" + PnlColorHeight.Number + "',");
                            fieldValue.Append("'" + PnlColorErrorText.Text + "',");
                            fieldValue.Append("'" + PnlColorNullText.Text + "',");
                            fieldValue.Append("'" + PnlColorDefaultValue.Text + "',");
                            break;
                        case 17://17.	图片
                            tableField.Append("Width,Height,ImageSize,HasWaterMark,WaterMarkType,DisplayFormat,");
                            fieldValue.Append("'" + PnlImageWidth.Number + "',");
                            fieldValue.Append("'" + PnlImageHeight.Number + "',");
                            fieldValue.Append("'" + TxtImageSize.Number + "',");
                            fieldValue.Append("'" + PnlImageRadlHasWm.SelectedItem.Value.ToString() + "',");
                            fieldValue.Append("'" + PnlImageRadWmStyle.SelectedItem.Value.ToString() + "',");
                            fieldValue.Append("'" + PictureStyle.Text + "',");
                            break;
                        case 18://18.	多图
                            tableField.Append("Width,Height,ImageSize,HasWaterMark,WaterMarkType,DisplayFormat,");
                            fieldValue.Append("'" + PnlMultipleImageWidth.Number + "',");
                            fieldValue.Append("'" + PnlMultipleImageHeight.Number + "',");
                            fieldValue.Append("'" + PnlMultipleImageMaxSize.Number + "',");
                            fieldValue.Append("'" + PnlMultipleImageHasWm.SelectedItem.Value.ToString() + "',");
                            fieldValue.Append("'" + PnlMultipleImageWmStyle.SelectedItem.Value.ToString() + "',");
                            fieldValue.Append("'" + MultiPictureStyle.Text + "',");
                            break;
                        case 19://19.	文件
                            break;
                        case 20://20.	多文件
                            break;
                        case 21://21.	词条
                            break;                        
                        case 26://26.	行政区划
                            break;
                        case 27://27.	评分
                            break;
                        case 28://28.	验证码
                            break;
                        default:
                            break;
                    }
                    #endregion
                    tableField.Append("FieldType,");
                    fieldValue.Append(ctrltype + ",");
                    tableField.Remove(tableField.Length - 1, 1);
                    fieldValue.Remove(fieldValue.Length - 1, 1);
                    SQL = string.Format("insert into ModelField({0}) values({1})", tableField.ToString(), fieldValue.ToString());
                    //写入数据库
                    if (ReturnType.Succuss == SqlHelper.InsertRecord(SQL))
                    {
                        Response.Write("ModelField记录添加成功！");
                    }
                    #endregion
                }
                #endregion
            }
            #endregion
        }

        //根据选择类型来转换成数据库的类型
        /// <summary>
        /// 根据选择类型来转换成数据库的类型
        /// </summary>
        /// <param name="vFieldType"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public string FieldTypeToSqlDataType(short vFieldType)
        {
            FieldType fieldType = (FieldType)vFieldType;
            string result = null;
            switch (fieldType)
            {
                case FieldType.None:
                    result = "nVarChar(10)";
                    break;
                case FieldType.SingleLineText:
                    result = string.Format("nVarChar({0})", 200);
                    break;
                case FieldType.MultiLineNoHtml:
                    result = string.Format("nVarChar({0})", 200);
                    break;
                case FieldType.MultiLineHtml:
                    result = string.Format("text");
                    break;
                case FieldType.SingleDropDownList:
                    result = string.Format("nVarChar({0})", 100);
                    break;
                case FieldType.MultiDropDownList:
                    result = string.Format("nVarChar({0})", 100);
                    break;
                case FieldType.RadioButtonField:
                    result = string.Format("nVarChar({0})", 100);
                    break;
                case FieldType.CheckBoxField:
                    result = string.Format("nVarChar({0})", 100);
                    break;
                case FieldType.NumberField:
                    result = string.Format("nVarChar({0})", 100);
                    break;
                case FieldType.MoneyField:
                    result = string.Format("nVarChar({0})", 100);
                    break;
                case FieldType.ColorField:
                    result = string.Format("nVarChar({0})", 100);
                    break;
                case FieldType.DateField:
                    result = string.Format("nVarChar({0})", 100);
                    break;
                case FieldType.TimeField:
                    result = string.Format("nVarChar({0})", 100);
                    break;
                case FieldType.LinkField:
                    result = string.Format("nVarChar({0})", 100);
                    break;
                case FieldType.CustomText:
                    result = string.Format("nVarChar({0})", 100);
                    break;
                default:
                    result = "nVarChar(100)";
                    break;
            }
            return result;
        }

        //更改字段时，赋值公共内容
        /// <summary>
        /// 更改字段，赋值
        /// </summary>
        /// <param name="field"></param>
        protected void BindData(ContentModel1._5.Entities.ModelField field)
        {
            TxtFieldName.Text = field.Name;
            TxtFieldAliax.Text = field.Nick;
            TxtTips.Text = field.Tooltip;
            TxtDescription.Text = field.Remark;
            RadlEnableNull.Items.FindByValue(Convert.ToInt16(field.IsRequired).ToString()).Selected = true;
            RadlEnableShowOnSearchForm.Items.FindByValue(Convert.ToInt16(field.IsAllowSearch).ToString()).Selected = true;
            RadDisabled.Items.FindByValue(Convert.ToInt16(field.IsVisible).ToString()).Selected = true;
            IsReadOnly.Items.FindByValue(Convert.ToInt16(field.IsReadOnly).ToString()).Selected = true;
            //为下方变化控件赋值
            RadioChecked(field);
        }

        //更改字段时，赋值随控件变化的内容
        /// <summary>
        /// 更改字段时，赋值随控件变化的内容
        /// </summary>
        /// <param name="fieldType"></param>
        /// <param name="field"></param>
        protected void RadioChecked(ContentModel1._5.Entities.ModelField field)
        {
            switch (field.FieldType)
            {
                case 1:
                    RadTextType.Checked = true;
                    PnlText.Visible = true;
                    PnlMultiText.Visible = false;
                    PnlEditor.Visible = false;
                    PnlRadio.Visible = false;
                    PnlNumber.Visible = false;
                    PnlCurrency.Visible = false;
                    PnlDate.Visible = false;
                    PnlTime.Visible = false;
                    PnlURL.Visible = false;
                    PnlPhoneMobile.Visible = false;
                    PnlPhoneFixed.Visible = false;
                    PnlColor.Visible = false;
                    PnlCustomized.Visible = false;
                    PnlTableField.Visible = false;
                    PnlPicture.Visible = false;
                    PnlMultiPicture.Visible = false;
                    PnlFile.Visible = false;
                    PnlMultiFile.Visible = false;
                    PnlRegion.Visible = false;
                    PnlKeyword.Visible = false;
                    PnlCaptcha.Visible = false;
                    PnlSelectUser.Visible = false;
                    PnlSelectDepartment.Visible = false;
                    PnlSelectRole.Visible = false;
                    PnlSelectCode.Visible = false;
                    PnlVote.Visible = false;
                    PnlTextWidth.Number = Convert.ToDecimal(field.Width);
                    PnlTextHeight.Number = Convert.ToDecimal(field.Height);
                    TxtTextMaxLength.Number = Convert.ToDecimal(field.MaxLength);
                    PnlTextErrorText.Text = field.ErrorText;
                    PnlTextNullText.Text = field.NullText;
                    TxtTextDefaultValue.Text = field.DefaultValue;
                    break;
                case 2:
                    RadMultipleTextType.Checked = true;
                    PnlText.Visible = false;
                    PnlMultiText.Visible = true;
                    PnlEditor.Visible = false;
                    PnlRadio.Visible = false;
                    PnlNumber.Visible = false;
                    PnlCurrency.Visible = false;
                    PnlDate.Visible = false;
                    PnlTime.Visible = false;
                    PnlURL.Visible = false;
                    PnlPhoneMobile.Visible = false;
                    PnlPhoneFixed.Visible = false;
                    PnlColor.Visible = false;
                    PnlCustomized.Visible = false;
                    PnlTableField.Visible = false;
                    PnlPicture.Visible = false;
                    PnlMultiPicture.Visible = false;
                    PnlFile.Visible = false;
                    PnlMultiFile.Visible = false;
                    PnlRegion.Visible = false;
                    PnlKeyword.Visible = false;
                    PnlCaptcha.Visible = false;
                    PnlSelectUser.Visible = false;
                    PnlSelectDepartment.Visible = false;
                    PnlSelectRole.Visible = false;
                    PnlSelectCode.Visible = false;
                    PnlVote.Visible = false;
                    TxtMultiTextWidth.Number = Convert.ToDecimal(field.Width);
                    TxtMultiTextHeight.Number = Convert.ToDecimal(field.Height);
                    PnlMultiTextErrorText.Text = field.ErrorText;
                    PnlMultiTextNullText.Text = field.NullText;
                    TxtMultiDefault.Text = field.DefaultValue;
                    break;
                case 3:
                    RadMultipleHtmlTextType.Checked = true;
                    PnlText.Visible = false;
                    PnlMultiText.Visible = false;
                    PnlEditor.Visible = true;
                    PnlRadio.Visible = false;
                    PnlNumber.Visible = false;
                    PnlCurrency.Visible = false;
                    PnlDate.Visible = false;
                    PnlTime.Visible = false;
                    PnlURL.Visible = false;
                    PnlPhoneMobile.Visible = false;
                    PnlPhoneFixed.Visible = false;
                    PnlColor.Visible = false;
                    PnlCustomized.Visible = false;
                    PnlTableField.Visible = false;
                    PnlPicture.Visible = false;
                    PnlMultiPicture.Visible = false;
                    PnlFile.Visible = false;
                    PnlMultiFile.Visible = false;
                    PnlRegion.Visible = false;
                    PnlKeyword.Visible = false;
                    PnlCaptcha.Visible = false;
                    PnlSelectUser.Visible = false;
                    PnlSelectDepartment.Visible = false;
                    PnlSelectRole.Visible = false;
                    PnlSelectCode.Visible = false;
                    PnlVote.Visible = false;
                    TxtEditorWidth.Number = Convert.ToDecimal(field.Width);
                    TxtEditorHight.Number = Convert.ToDecimal(field.Height);
                    PnlEditorErrorText.Text = field.ErrorText;
                    PnlEditorDefault.Html = field.DefaultValue;
                    break;
                case 4:
                    PnlRadioType.Checked = true;
                    PnlRadioWidthTd.Visible = true;
                    PnlRadioHeightTd.Visible = true;
                    PnlText.Visible = false;
                    PnlMultiText.Visible = false;
                    PnlEditor.Visible = false;
                    PnlRadio.Visible = true;
                    PnlNumber.Visible = false;
                    PnlCurrency.Visible = false;
                    PnlDate.Visible = false;
                    PnlTime.Visible = false;
                    PnlURL.Visible = false;
                    PnlPhoneMobile.Visible = false;
                    PnlPhoneFixed.Visible = false;
                    PnlColor.Visible = false;
                    PnlCustomized.Visible = false;
                    PnlTableField.Visible = false;
                    PnlPicture.Visible = false;
                    PnlMultiPicture.Visible = false;
                    PnlFile.Visible = false;
                    PnlMultiFile.Visible = false;
                    PnlRegion.Visible = false;
                    PnlKeyword.Visible = false;
                    PnlCaptcha.Visible = false;
                    PnlSelectUser.Visible = false;
                    PnlSelectDepartment.Visible = false;
                    PnlSelectRole.Visible = false;
                    PnlSelectCode.Visible = false;
                    PnlVote.Visible = false;
                    RadlChoiceType.Items.FindByValue("1").Selected = true;
                    RadlChoiceCode.Text = field.CodeCat;
                    PnlRadioWidth.Number = Convert.ToDecimal(field.Width);
                    PnlRadioHeight.Number = Convert.ToDecimal(field.Height);
                    PnlRadioErrorTip.Text = field.ErrorText;
                    break;
                case 5:
                    PnlRadioType.Checked = true;
                    PnlRadioWidthTd.Visible = true;
                    PnlRadioHeightTd.Visible = true;
                    PnlText.Visible = false;
                    PnlMultiText.Visible = false;
                    PnlEditor.Visible = false;
                    PnlRadio.Visible = true;
                    PnlNumber.Visible = false;
                    PnlCurrency.Visible = false;
                    PnlDate.Visible = false;
                    PnlTime.Visible = false;
                    PnlURL.Visible = false;
                    PnlPhoneMobile.Visible = false;
                    PnlPhoneFixed.Visible = false;
                    PnlColor.Visible = false;
                    PnlCustomized.Visible = false;
                    PnlTableField.Visible = false;
                    PnlPicture.Visible = false;
                    PnlMultiPicture.Visible = false;
                    PnlFile.Visible = false;
                    PnlMultiFile.Visible = false;
                    PnlRegion.Visible = false;
                    PnlKeyword.Visible = false;
                    PnlCaptcha.Visible = false;
                    PnlSelectUser.Visible = false;
                    PnlSelectDepartment.Visible = false;
                    PnlSelectRole.Visible = false;
                    PnlSelectCode.Visible = false;
                    PnlVote.Visible = false;
                    RadlChoiceType.Items.FindByValue("2").Selected = true;
                    RadlChoiceCode.Text = field.CodeCat;
                    PnlRadioWidth.Number = Convert.ToDecimal(field.Width);
                    PnlRadioHeight.Number = Convert.ToDecimal(field.Height);
                    PnlRadioErrorTip.Text = field.ErrorText;
                    break;
                case 6:
                    PnlRadioType.Checked = true;
                    PnlRadioWidthTd.Visible = false;
                    PnlRadioHeightTd.Visible = false;
                    PnlText.Visible = false;
                    PnlMultiText.Visible = false;
                    PnlEditor.Visible = false;
                    PnlRadio.Visible = true;
                    PnlNumber.Visible = false;
                    PnlCurrency.Visible = false;
                    PnlDate.Visible = false;
                    PnlTime.Visible = false;
                    PnlURL.Visible = false;
                    PnlPhoneMobile.Visible = false;
                    PnlPhoneFixed.Visible = false;
                    PnlColor.Visible = false;
                    PnlCustomized.Visible = false;
                    PnlTableField.Visible = false;
                    PnlPicture.Visible = false;
                    PnlMultiPicture.Visible = false;
                    PnlFile.Visible = false;
                    PnlMultiFile.Visible = false;
                    PnlRegion.Visible = false;
                    PnlKeyword.Visible = false;
                    PnlCaptcha.Visible = false;
                    PnlSelectUser.Visible = false;
                    PnlSelectDepartment.Visible = false;
                    PnlSelectRole.Visible = false;
                    PnlSelectCode.Visible = false;
                    PnlVote.Visible = false;
                    RadlChoiceType.Items.FindByValue("3").Selected = true;
                    RadlChoiceCode.Text = field.CodeCat;
                    PnlRadioErrorTip.Text = field.ErrorText;
                    break;
                case 7:
                    PnlRadioType.Checked = true;
                    PnlRadioWidthTd.Visible = false;
                    PnlRadioHeightTd.Visible = false;
                    PnlText.Visible = false;
                    PnlMultiText.Visible = false;
                    PnlEditor.Visible = false;
                    PnlRadio.Visible = true;
                    PnlNumber.Visible = false;
                    PnlCurrency.Visible = false;
                    PnlDate.Visible = false;
                    PnlTime.Visible = false;
                    PnlURL.Visible = false;
                    PnlPhoneMobile.Visible = false;
                    PnlPhoneFixed.Visible = false;
                    PnlColor.Visible = false;
                    PnlCustomized.Visible = false;
                    PnlTableField.Visible = false;
                    PnlPicture.Visible = false;
                    PnlMultiPicture.Visible = false;
                    PnlFile.Visible = false;
                    PnlMultiFile.Visible = false;
                    PnlRegion.Visible = false;
                    PnlKeyword.Visible = false;
                    PnlCaptcha.Visible = false;
                    PnlSelectUser.Visible = false;
                    PnlSelectDepartment.Visible = false;
                    PnlSelectRole.Visible = false;
                    PnlSelectCode.Visible = false;
                    PnlVote.Visible = false;
                    RadlChoiceType.Items.FindByValue("4").Selected = true;
                    RadlChoiceCode.Text = field.CodeCat;
                    PnlRadioErrorTip.Text = field.ErrorText;
                    break;
                case 8:
                    RadNumberType.Checked = true;
                    PnlText.Visible = false;
                    PnlMultiText.Visible = false;
                    PnlEditor.Visible = false;
                    PnlRadio.Visible = false;
                    PnlNumber.Visible = true;
                    PnlCurrency.Visible = false;
                    PnlDate.Visible = false;
                    PnlTime.Visible = false;
                    PnlURL.Visible = false;
                    PnlPhoneMobile.Visible = false;
                    PnlPhoneFixed.Visible = false;
                    PnlColor.Visible = false;
                    PnlCustomized.Visible = false;
                    PnlTableField.Visible = false;
                    PnlPicture.Visible = false;
                    PnlMultiPicture.Visible = false;
                    PnlFile.Visible = false;
                    PnlMultiFile.Visible = false;
                    PnlRegion.Visible = false;
                    PnlKeyword.Visible = false;
                    PnlCaptcha.Visible = false;
                    PnlSelectUser.Visible = false;
                    PnlSelectDepartment.Visible = false;
                    PnlSelectRole.Visible = false;
                    PnlSelectCode.Visible = false;
                    PnlVote.Visible = false;
                    #region 加载代码选择Number 数据项
                    try
                    {
                        using (TestDBEntities entity = new TestDBEntities())
                        {
                            Dictionary codecat = entity.Dictionary.Where(p => p.ControlType == "NumberField").FirstOrDefault();
                            List<DictionaryItem> detaillist = entity.DictionaryItem.Where(oo => oo.DictionaryItemCode.StartsWith(codecat.DictionaryCode)).ToList();
                            TxtNumberDisplayFormat.DataSource = detaillist;
                            TxtNumberDisplayFormat.DataBind();
                        }
                    }
                    catch (Exception ex)
                    { throw ex; }
                    #endregion
                    PnlNumberWidth.Number = Convert.ToDecimal(field.Width);
                    PnlNumberHeight.Number = Convert.ToDecimal(field.Height);
                    PnlNumberMaxLength.Number = Convert.ToDecimal(field.MaxLength);
                    TxtNumberMinValue.Number = Convert.ToDecimal(field.MinValue);
                    TxtNumberMaxValue.Number = Convert.ToDecimal(field.MaxValue);
                    TxtNumberDisplayFormat.Text = field.DisplayFormat ;
                    PnlNumberErrorText.Text = field.ErrorText;
                    PnlNumberNullText.Text=field.NullText;
                    TxtNumberDefaultValue.Number = Convert.ToDecimal(field.DefaultValue);
                    break;
                case 9:
                    RadMoneyType.Checked = true;
                    PnlText.Visible = false;
                    PnlMultiText.Visible = false;
                    PnlEditor.Visible = false;
                    PnlRadio.Visible = false;
                    PnlNumber.Visible = false;
                    PnlCurrency.Visible = true;
                    PnlDate.Visible = false;
                    PnlTime.Visible = false;
                    PnlURL.Visible = false;
                    PnlPhoneMobile.Visible = false;
                    PnlPhoneFixed.Visible = false;
                    PnlColor.Visible = false;
                    PnlCustomized.Visible = false;
                    PnlTableField.Visible = false;
                    PnlPicture.Visible = false;
                    PnlMultiPicture.Visible = false;
                    PnlFile.Visible = false;
                    PnlMultiFile.Visible = false;
                    PnlRegion.Visible = false;
                    PnlKeyword.Visible = false;
                    PnlCaptcha.Visible = false;
                    PnlSelectUser.Visible = false;
                    PnlSelectDepartment.Visible = false;
                    PnlSelectRole.Visible = false;
                    PnlSelectCode.Visible = false;
                    PnlVote.Visible = false;
                    #region 加载代码选择Currency数据项
                    try
                    {
                        using (TestDBEntities entity = new TestDBEntities())
                        {
                            Dictionary codecat = entity.Dictionary.Where(p => p.ControlType == "CurrencyField").FirstOrDefault();
                            List<DictionaryItem> detaillist = entity.DictionaryItem.Where(oo => oo.DictionaryItemCode.StartsWith(codecat.DictionaryCode)).ToList();
                            PnlCurrencyDisplayFormat.DataSource = detaillist;
                            PnlCurrencyDisplayFormat.DataBind();
                        }
                    }
                    catch (Exception ex)
                    { throw ex; }
                    #endregion
                    PnlCurrencyWidth.Number = Convert.ToDecimal(field.Width);
                    PnlCurrencyHeight.Number = Convert.ToDecimal(field.Height);
                    PnlCurrencyMaxLength.Number = Convert.ToDecimal(field.MaxLength);
                    TxtCurrencyMin.Number = Convert.ToDecimal(field.MinValue);
                    TxtCurrencyMax.Number = Convert.ToDecimal(field.MaxValue);
                    PnlCurrencyDisplayFormat.Text = field.DisplayFormat;
                    PnlCurrencyErrorText.Text = field.ErrorText;
                    PnlCurrencyNullText.Text = field.NullText;
                    TxtCurrencyDefaultValue.Number = Convert.ToDecimal(field.DefaultValue);
                    break;
                case 10:
                    RadDateType.Checked = true;
                    PnlText.Visible = false;
                    PnlMultiText.Visible = false;
                    PnlEditor.Visible = false;
                    PnlRadio.Visible = false;
                    PnlNumber.Visible = false;
                    PnlCurrency.Visible = false;
                    PnlDate.Visible = true;
                    PnlTime.Visible = false;
                    PnlURL.Visible = false;
                    PnlPhoneMobile.Visible = false;
                    PnlPhoneFixed.Visible = false;
                    PnlColor.Visible = false;
                    PnlCustomized.Visible = false;
                    PnlTableField.Visible = false;
                    PnlPicture.Visible = false;
                    PnlMultiPicture.Visible = false;
                    PnlFile.Visible = false;
                    PnlMultiFile.Visible = false;
                    PnlRegion.Visible = false;
                    PnlKeyword.Visible = false;
                    PnlCaptcha.Visible = false;
                    PnlSelectUser.Visible = false;
                    PnlSelectDepartment.Visible = false;
                    PnlSelectRole.Visible = false;
                    PnlSelectCode.Visible = false;
                    PnlVote.Visible = false;
                    #region 加载代码选择DateField 数据项
                    try
                    {
                        using (TestDBEntities entity = new TestDBEntities())
                        {
                            Dictionary codecat = entity.Dictionary.Where(p => p.ControlType == "DateField").FirstOrDefault();
                            List<DictionaryItem> detaillist = entity.DictionaryItem.Where(oo => oo.DictionaryItemCode.StartsWith(codecat.DictionaryCode)).ToList();
                            PnlDateDisplayFormat.DataSource = detaillist;
                            PnlDateDisplayFormat.DataBind();
                        }
                    }
                    catch (Exception ex)
                    { throw ex; }
                    #endregion
                    PnlDateWidth.Number = Convert.ToDecimal(field.Width);
                    PnlDateHeight.Number = Convert.ToDecimal(field.Height);
                    PnlDateDisplayFormat.Text = field.DisplayFormat;
                    PnlDateErrorText.Text = field.ErrorText;
                    PnlDateNullText.Text = field.NullText;
                    RadlDateDefaultType.Date = Convert.ToDateTime(field.DefaultValue);
                    RadlDateDefaultType.EditFormatString = field.DisplayFormat;
                    break;
                case 11:
                    RadTimeType.Checked = true;
                    PnlText.Visible = false;
                    PnlMultiText.Visible = false;
                    PnlEditor.Visible = false;
                    PnlRadio.Visible = false;
                    PnlNumber.Visible = false;
                    PnlCurrency.Visible = false;
                    PnlDate.Visible = false;
                    PnlTime.Visible = true;
                    PnlURL.Visible = false;
                    PnlPhoneMobile.Visible = false;
                    PnlPhoneFixed.Visible = false;
                    PnlColor.Visible = false;
                    PnlCustomized.Visible = false;
                    PnlTableField.Visible = false;
                    PnlPicture.Visible = false;
                    PnlMultiPicture.Visible = false;
                    PnlFile.Visible = false;
                    PnlMultiFile.Visible = false;
                    PnlRegion.Visible = false;
                    PnlKeyword.Visible = false;
                    PnlCaptcha.Visible = false;
                    PnlSelectUser.Visible = false;
                    PnlSelectDepartment.Visible = false;
                    PnlSelectRole.Visible = false;
                    PnlSelectCode.Visible = false;
                    PnlVote.Visible = false;
                    #region 加载代码选择TimeField 数据项
                    try
                    {
                        using (TestDBEntities entity = new TestDBEntities())
                        {
                            Dictionary codecat = entity.Dictionary.Where(p => p.ControlType == "TimeField").FirstOrDefault();
                            List<DictionaryItem> detaillist = entity.DictionaryItem.Where(oo => oo.DictionaryItemCode.StartsWith(codecat.DictionaryCode)).ToList();
                            PnlTimeDisplayFormat.DataSource = detaillist;
                            PnlTimeDisplayFormat.DataBind();
                        }
                    }
                    catch (Exception ex)
                    { throw ex; }
                    #endregion
                    PnlTimeWidth.Number = Convert.ToDecimal(field.Width);
                    PnlTimeHeight.Number = Convert.ToDecimal(field.Height);
                    PnlTimeDisplayFormat.Text = field.DisplayFormat;
                    PnlTimeErrorText.Text = field.ErrorText;
                    RadlTimeDefaultType.DateTime = Convert.ToDateTime(field.DefaultValue);
                    RadlTimeDefaultType.EditFormatString = field.DisplayFormat;
                    break;
                case 12:
                    RadHyperLinkType.Checked = true;
                    PnlText.Visible = false;
                    PnlMultiText.Visible = false;
                    PnlEditor.Visible = false;
                    PnlRadio.Visible = false;
                    PnlNumber.Visible = false;
                    PnlCurrency.Visible = false;
                    PnlDate.Visible = false;
                    PnlTime.Visible = false;
                    PnlURL.Visible = true;
                    PnlPhoneMobile.Visible = false;
                    PnlPhoneFixed.Visible = false;
                    PnlColor.Visible = false;
                    PnlCustomized.Visible = false;
                    PnlTableField.Visible = false;
                    PnlPicture.Visible = false;
                    PnlMultiPicture.Visible = false;
                    PnlFile.Visible = false;
                    PnlMultiFile.Visible = false;
                    PnlRegion.Visible = false;
                    PnlKeyword.Visible = false;
                    PnlCaptcha.Visible = false;
                    PnlSelectUser.Visible = false;
                    PnlSelectDepartment.Visible = false;
                    PnlSelectRole.Visible = false;
                    PnlSelectCode.Visible = false;
                    PnlVote.Visible = false;
                    PnlURLWidth.Number = Convert.ToDecimal(field.Width);
                    PnlURLHeight.Number = Convert.ToDecimal(field.Height);
                    break;
                case 13:
                    RadTelephoneType.Checked = true;
                    PnlText.Visible = false;
                    PnlMultiText.Visible = false;
                    PnlEditor.Visible = false;
                    PnlRadio.Visible = false;
                    PnlNumber.Visible = false;
                    PnlCurrency.Visible = false;
                    PnlDate.Visible = false;
                    PnlTime.Visible = false;
                    PnlURL.Visible = false;
                    PnlPhoneMobile.Visible = false;
                    PnlPhoneFixed.Visible = true;
                    PnlColor.Visible = false;
                    PnlCustomized.Visible = false;
                    PnlTableField.Visible = false;
                    PnlPicture.Visible = false;
                    PnlMultiPicture.Visible = false;
                    PnlFile.Visible = false;
                    PnlMultiFile.Visible = false;
                    PnlRegion.Visible = false;
                    PnlKeyword.Visible = false;
                    PnlCaptcha.Visible = false;
                    PnlSelectUser.Visible = false;
                    PnlSelectDepartment.Visible = false;
                    PnlSelectRole.Visible = false;
                    PnlSelectCode.Visible = false;
                    PnlVote.Visible = false;

                    PnlPhoneFixedWidth.Number = Convert.ToDecimal(field.Width);
                    PnlPhoneFixedHeight.Number = Convert.ToDecimal(field.Height);
                    PnlPhoneFixedErrorText.Text = field.ErrorText;
                    PnlPhoneFixedDefault.Text = field.DefaultValue;
                    break;
                case 14:
                    RadMobilephoneType.Checked = true;
                    PnlText.Visible = false;
                    PnlMultiText.Visible = false;
                    PnlEditor.Visible = false;
                    PnlRadio.Visible = false;
                    PnlNumber.Visible = false;
                    PnlCurrency.Visible = false;
                    PnlDate.Visible = false;
                    PnlTime.Visible = false;
                    PnlURL.Visible = false;
                    PnlPhoneMobile.Visible = true;
                    PnlPhoneFixed.Visible = false;
                    PnlColor.Visible = false;
                    PnlCustomized.Visible = false;
                    PnlTableField.Visible = false;
                    PnlPicture.Visible = false;
                    PnlMultiPicture.Visible = false;
                    PnlFile.Visible = false;
                    PnlMultiFile.Visible = false;
                    PnlRegion.Visible = false;
                    PnlKeyword.Visible = false;
                    PnlCaptcha.Visible = false;
                    PnlSelectUser.Visible = false;
                    PnlSelectDepartment.Visible = false;
                    PnlSelectRole.Visible = false;
                    PnlSelectCode.Visible = false;
                    PnlVote.Visible = false;

                    PnlPhoneMobileWidth.Number = Convert.ToDecimal(field.Width);
                    PnlPhoneMobileHeight.Number = Convert.ToDecimal(field.Height);
                    PnlPhoneMobileErrorText.Text = field.ErrorText;
                    PnlPhoneMobileDefaultText.Text = field.DefaultValue;
                    break;
                //自定义控件
                case 15:
                    RadUserTextType.Checked = true;
                    PnlText.Visible = false;
                    PnlMultiText.Visible = false;
                    PnlEditor.Visible = false;
                    PnlRadio.Visible = false;
                    PnlNumber.Visible = false;
                    PnlCurrency.Visible = false;
                    PnlDate.Visible = false;
                    PnlTime.Visible = false;
                    PnlURL.Visible = false;
                    PnlPhoneMobile.Visible = false;
                    PnlPhoneFixed.Visible = false;
                    PnlColor.Visible = false;
                    PnlCustomized.Visible = true;
                    PnlTableField.Visible = false;
                    PnlPicture.Visible = false;
                    PnlMultiPicture.Visible = false;
                    PnlFile.Visible = false;
                    PnlMultiFile.Visible = false;
                    PnlRegion.Visible = false;
                    PnlKeyword.Visible = false;
                    PnlCaptcha.Visible = false;
                    PnlSelectUser.Visible = false;
                    PnlSelectDepartment.Visible = false;
                    PnlSelectRole.Visible = false;
                    PnlSelectCode.Visible = false;
                    PnlVote.Visible = false;

                    #region 加载代码选择自定义控件的数据项
                    try
                    {
                        using (TestDBEntities entity = new TestDBEntities())
                        {
                            string customtext = FieldType.CustomText.ToString();
                            Dictionary codecat = entity.Dictionary.Where(p => p.ControlType == customtext).FirstOrDefault();
                            List<DictionaryItem> detaillist = entity.DictionaryItem.Where(oo => oo.DictionaryItemCode.StartsWith(codecat.DictionaryCode)).ToList();
                            PnlCustomizedDisplayFormat.DataSource = detaillist;
                            PnlCustomizedDisplayFormat.DataBind();
                        }
                    }
                    catch (Exception ex)
                    { throw ex; }
                    #endregion

                    PnlCustomizedWidth.Number = Convert.ToDecimal(field.Width);
                    PnlCustomizedHeight.Number = Convert.ToDecimal(field.Height);
                    PnlCustomizedDisplayFormat.Text = field.DisplayFormat;
                    PnlCustomizedErrorText.Text = field.ErrorText;
                    PnlCustomizedNullText.Text = field.NullText;
                    PnlCustomizedDefaultValue.Text = field.DefaultValue;

                    break;
                //颜色控件
                case 16:
                    RadColorType.Checked = true;
                    PnlText.Visible = false;
                    PnlMultiText.Visible = false;
                    PnlEditor.Visible = false;
                    PnlRadio.Visible = false;
                    PnlNumber.Visible = false;
                    PnlCurrency.Visible = false;
                    PnlDate.Visible = false;
                    PnlTime.Visible = false;
                    PnlURL.Visible = false;
                    PnlPhoneMobile.Visible = false;
                    PnlPhoneFixed.Visible = false;
                    PnlColor.Visible = true;
                    PnlCustomized.Visible = false;
                    PnlTableField.Visible = false;
                    PnlPicture.Visible = false;
                    PnlMultiPicture.Visible = false;
                    PnlFile.Visible = false;
                    PnlMultiFile.Visible = false;
                    PnlRegion.Visible = false;
                    PnlKeyword.Visible = false;
                    PnlCaptcha.Visible = false;
                    PnlSelectUser.Visible = false;
                    PnlSelectDepartment.Visible = false;
                    PnlSelectRole.Visible = false;
                    PnlSelectCode.Visible = false;
                    PnlVote.Visible = false;

                    PnlColorWidth.Number = Convert.ToDecimal(field.Width);
                    PnlColorHeight.Number = Convert.ToDecimal(field.Height);
                    PnlColorErrorText.Text = field.ErrorText;
                    PnlColorNullText.Text = field.NullText;
                    PnlColorDefaultValue.Text = field.DefaultValue;
                    break;
                case 17:
                    RadPictureType.Checked = true;
                    PnlText.Visible = false;
                    PnlMultiText.Visible = false;
                    PnlEditor.Visible = false;
                    PnlRadio.Visible = false;
                    PnlNumber.Visible = false;
                    PnlCurrency.Visible = false;
                    PnlDate.Visible = false;
                    PnlTime.Visible = false;
                    PnlURL.Visible = false;
                    PnlPhoneMobile.Visible = false;
                    PnlPhoneFixed.Visible = false;
                    PnlColor.Visible = false;
                    PnlCustomized.Visible = false;
                    PnlTableField.Visible = false;
                    PnlPicture.Visible = true;
                    PnlMultiPicture.Visible = false;
                    PnlFile.Visible = false;
                    PnlMultiFile.Visible = false;
                    PnlRegion.Visible = false;
                    PnlKeyword.Visible = false;
                    PnlCaptcha.Visible = false;
                    PnlSelectUser.Visible = false;
                    PnlSelectDepartment.Visible = false;
                    PnlSelectRole.Visible = false;
                    PnlSelectCode.Visible = false;
                    PnlVote.Visible = false;

                    PnlImageWidth.Number = Convert.ToDecimal(field.Width);
                    PnlImageHeight.Number = Convert.ToDecimal(field.Height);
                    TxtImageSize.Number = Convert.ToDecimal(field.ImageSize);
                    PnlImageRadlHasWm.Items.FindByValue(Convert.ToInt16(field.HasWaterMark).ToString()).Selected = true;
                    PnlImageRadWmStyle.Items.FindByValue(Convert.ToInt16(field.WaterMarkType).ToString()).Selected = true;
                    PictureStyle.Text = field.DisplayFormat;
                    break;
                case 18:
                    RadMultiPictureType.Checked = true;
                    PnlText.Visible = false;
                    PnlMultiText.Visible = false;
                    PnlEditor.Visible = false;
                    PnlRadio.Visible = false;
                    PnlNumber.Visible = false;
                    PnlCurrency.Visible = false;
                    PnlDate.Visible = false;
                    PnlTime.Visible = false;
                    PnlURL.Visible = false;
                    PnlPhoneMobile.Visible = false;
                    PnlPhoneFixed.Visible = false;
                    PnlColor.Visible = false;
                    PnlCustomized.Visible = false;
                    PnlTableField.Visible = false;
                    PnlPicture.Visible = false;
                    PnlMultiPicture.Visible = true;
                    PnlFile.Visible = false;
                    PnlMultiFile.Visible = false;
                    PnlRegion.Visible = false;
                    PnlKeyword.Visible = false;
                    PnlCaptcha.Visible = false;
                    PnlSelectUser.Visible = false;
                    PnlSelectDepartment.Visible = false;
                    PnlSelectRole.Visible = false;
                    PnlSelectCode.Visible = false;
                    PnlVote.Visible = false;

                    PnlMultipleImageWidth.Number = Convert.ToDecimal(field.Width);
                    PnlMultipleImageHeight.Number = Convert.ToDecimal(field.Height);
                    PnlMultipleImageMaxSize.Number = Convert.ToDecimal(field.ImageSize);
                    PnlMultipleImageHasWm.Items.FindByValue(Convert.ToInt16(field.HasWaterMark).ToString()).Selected = true;
                    PnlMultipleImageWmStyle.Items.FindByValue(Convert.ToInt16(field.WaterMarkType).ToString()).Selected = true;
                    MultiPictureStyle.Text = field.DisplayFormat;
                    break;
                case 19:
                    PnlText.Visible = false;
                    PnlMultiText.Visible = false;
                    PnlEditor.Visible = false;
                    PnlRadio.Visible = false;
                    PnlNumber.Visible = false;
                    PnlCurrency.Visible = false;
                    PnlDate.Visible = false;
                    PnlTime.Visible = false;
                    PnlURL.Visible = false;
                    PnlPhoneMobile.Visible = false;
                    PnlPhoneFixed.Visible = false;
                    PnlColor.Visible = false;
                    PnlCustomized.Visible = false;
                    PnlTableField.Visible = false;
                    PnlPicture.Visible = false;
                    PnlMultiPicture.Visible = false;
                    PnlFile.Visible = true;
                    PnlMultiFile.Visible = false;
                    PnlRegion.Visible = false;
                    PnlKeyword.Visible = false;
                    PnlCaptcha.Visible = false;
                    PnlSelectUser.Visible = false;
                    PnlSelectDepartment.Visible = false;
                    PnlSelectRole.Visible = false;
                    PnlSelectCode.Visible = false;
                    PnlVote.Visible = false;
                    break;
                case 20:
                    PnlText.Visible = false;
                    PnlMultiText.Visible = false;
                    PnlEditor.Visible = false;
                    PnlRadio.Visible = false;
                    PnlNumber.Visible = false;
                    PnlCurrency.Visible = false;
                    PnlDate.Visible = false;
                    PnlTime.Visible = false;
                    PnlURL.Visible = false;
                    PnlPhoneMobile.Visible = false;
                    PnlPhoneFixed.Visible = false;
                    PnlColor.Visible = false;
                    PnlCustomized.Visible = false;
                    PnlTableField.Visible = false;
                    PnlPicture.Visible = false;
                    PnlMultiPicture.Visible = false;
                    PnlFile.Visible = false;
                    PnlMultiFile.Visible = true;
                    PnlRegion.Visible = false;
                    PnlKeyword.Visible = false;
                    PnlCaptcha.Visible = false;
                    PnlSelectUser.Visible = false;
                    PnlSelectDepartment.Visible = false;
                    PnlSelectRole.Visible = false;
                    PnlSelectCode.Visible = false;
                    PnlVote.Visible = false;
                    break;
                case 21:
                    PnlText.Visible = false;
                    PnlMultiText.Visible = false;
                    PnlEditor.Visible = false;
                    PnlRadio.Visible = false;
                    PnlNumber.Visible = false;
                    PnlCurrency.Visible = false;
                    PnlDate.Visible = false;
                    PnlTime.Visible = false;
                    PnlURL.Visible = false;
                    PnlPhoneMobile.Visible = false;
                    PnlPhoneFixed.Visible = false;
                    PnlColor.Visible = false;
                    PnlCustomized.Visible = false;
                    PnlTableField.Visible = false;
                    PnlPicture.Visible = false;
                    PnlMultiPicture.Visible = false;
                    PnlFile.Visible = false;
                    PnlMultiFile.Visible = false;
                    PnlRegion.Visible = false;
                    PnlKeyword.Visible = true;
                    PnlCaptcha.Visible = false;
                    PnlSelectUser.Visible = false;
                    PnlSelectDepartment.Visible = false;
                    PnlSelectRole.Visible = false;
                    PnlSelectCode.Visible = false;
                    PnlVote.Visible = false;
                    break;
                case 22:
                    RadSelectCodeType.Checked = true;
                    PnlText.Visible = false;
                    PnlMultiText.Visible = false;
                    PnlEditor.Visible = false;
                    PnlRadio.Visible = false;
                    PnlNumber.Visible = false;
                    PnlCurrency.Visible = false;
                    PnlDate.Visible = false;
                    PnlTime.Visible = false;
                    PnlURL.Visible = false;
                    PnlPhoneMobile.Visible = false;
                    PnlPhoneFixed.Visible = false;
                    PnlColor.Visible = false;
                    PnlCustomized.Visible = false;
                    PnlTableField.Visible = false;
                    PnlPicture.Visible = false;
                    PnlMultiPicture.Visible = false;
                    PnlFile.Visible = false;
                    PnlMultiFile.Visible = false;
                    PnlRegion.Visible = false;
                    PnlKeyword.Visible = false;
                    PnlCaptcha.Visible = false;
                    PnlSelectUser.Visible = false;
                    PnlSelectDepartment.Visible = false;
                    PnlSelectRole.Visible = false;
                    PnlSelectCode.Visible = true;
                    PnlVote.Visible = false;
                    try
                    {
                        using (TestDBEntities db = new TestDBEntities())
                        {
                            List<Dictionary> codelist = db.Dictionary.Where(p => p.ControlType == "SelectCode").ToList();
                            PnlCode.DataSource = codelist;
                            PnlCode.DataBind();
                        }
                    }
                    catch (Exception ex)
                    { throw ex; }
                    PnlSelectCodeErrorText.Text = field.ErrorText;
                    PnlSelectCodeNullText.Text = field.NullText;
                    PnlCode.Text = field.CodeCat;
                    SingleOrMultiple.Items.FindByValue(Convert.ToInt16(field.SingleOrMultiple).ToString()).Selected = true;
                    DisplayFormat.Items.FindByValue(field.DisplayFormat).Selected = true;
                    break;
                case 23:
                    PnlText.Visible = false;
                    PnlMultiText.Visible = false;
                    PnlEditor.Visible = false;
                    PnlRadio.Visible = false;
                    PnlNumber.Visible = false;
                    PnlCurrency.Visible = false;
                    PnlDate.Visible = false;
                    PnlTime.Visible = false;
                    PnlURL.Visible = false;
                    PnlPhoneMobile.Visible = false;
                    PnlPhoneFixed.Visible = false;
                    PnlColor.Visible = false;
                    PnlCustomized.Visible = false;
                    PnlTableField.Visible = false;
                    PnlPicture.Visible = false;
                    PnlMultiPicture.Visible = false;
                    PnlFile.Visible = false;
                    PnlMultiFile.Visible = false;
                    PnlRegion.Visible = false;
                    PnlKeyword.Visible = false;
                    PnlCaptcha.Visible = false;
                    PnlSelectUser.Visible = false;
                    PnlSelectDepartment.Visible = true;
                    PnlSelectRole.Visible = false;
                    PnlSelectCode.Visible = false;
                    PnlVote.Visible = false;
                    break;
                case 24:
                    PnlText.Visible = false;
                    PnlMultiText.Visible = false;
                    PnlEditor.Visible = false;
                    PnlRadio.Visible = false;
                    PnlNumber.Visible = false;
                    PnlCurrency.Visible = false;
                    PnlDate.Visible = false;
                    PnlTime.Visible = false;
                    PnlURL.Visible = false;
                    PnlPhoneMobile.Visible = false;
                    PnlPhoneFixed.Visible = false;
                    PnlColor.Visible = false;
                    PnlCustomized.Visible = false;
                    PnlTableField.Visible = false;
                    PnlPicture.Visible = false;
                    PnlMultiPicture.Visible = false;
                    PnlFile.Visible = false;
                    PnlMultiFile.Visible = false;
                    PnlRegion.Visible = false;
                    PnlKeyword.Visible = false;
                    PnlCaptcha.Visible = false;
                    PnlSelectUser.Visible = true;
                    PnlSelectDepartment.Visible = false;
                    PnlSelectRole.Visible = false;
                    PnlSelectCode.Visible = false;
                    PnlVote.Visible = false;
                    break;
                case 25:
                    PnlText.Visible = false;
                    PnlMultiText.Visible = false;
                    PnlEditor.Visible = false;
                    PnlRadio.Visible = false;
                    PnlNumber.Visible = false;
                    PnlCurrency.Visible = false;
                    PnlDate.Visible = false;
                    PnlTime.Visible = false;
                    PnlURL.Visible = false;
                    PnlPhoneMobile.Visible = false;
                    PnlPhoneFixed.Visible = false;
                    PnlColor.Visible = false;
                    PnlCustomized.Visible = false;
                    PnlTableField.Visible = false;
                    PnlPicture.Visible = false;
                    PnlMultiPicture.Visible = false;
                    PnlFile.Visible = false;
                    PnlMultiFile.Visible = false;
                    PnlRegion.Visible = false;
                    PnlKeyword.Visible = false;
                    PnlCaptcha.Visible = false;
                    PnlSelectUser.Visible = false;
                    PnlSelectDepartment.Visible = false;
                    PnlSelectRole.Visible = true;
                    PnlSelectCode.Visible = false;
                    PnlVote.Visible = false;
                    break;
                case 26:
                    PnlText.Visible = false;
                    PnlMultiText.Visible = false;
                    PnlEditor.Visible = false;
                    PnlRadio.Visible = false;
                    PnlNumber.Visible = false;
                    PnlCurrency.Visible = false;
                    PnlDate.Visible = false;
                    PnlTime.Visible = false;
                    PnlURL.Visible = false;
                    PnlPhoneMobile.Visible = false;
                    PnlPhoneFixed.Visible = false;
                    PnlColor.Visible = false;
                    PnlCustomized.Visible = false;
                    PnlTableField.Visible = false;
                    PnlPicture.Visible = false;
                    PnlMultiPicture.Visible = false;
                    PnlFile.Visible = false;
                    PnlMultiFile.Visible = false;
                    PnlRegion.Visible = true;
                    PnlKeyword.Visible = false;
                    PnlCaptcha.Visible = false;
                    PnlSelectUser.Visible = false;
                    PnlSelectDepartment.Visible = false;
                    PnlSelectRole.Visible = false;
                    PnlSelectCode.Visible = false;
                    PnlVote.Visible = false;
                    break;
                case 27:
                    PnlText.Visible = false;
                    PnlMultiText.Visible = false;
                    PnlEditor.Visible = false;
                    PnlRadio.Visible = false;
                    PnlNumber.Visible = false;
                    PnlCurrency.Visible = false;
                    PnlDate.Visible = false;
                    PnlTime.Visible = false;
                    PnlURL.Visible = false;
                    PnlPhoneMobile.Visible = false;
                    PnlPhoneFixed.Visible = false;
                    PnlColor.Visible = false;
                    PnlCustomized.Visible = false;
                    PnlTableField.Visible = false;
                    PnlPicture.Visible = false;
                    PnlMultiPicture.Visible = false;
                    PnlFile.Visible = false;
                    PnlMultiFile.Visible = false;
                    PnlRegion.Visible = false;
                    PnlKeyword.Visible = false;
                    PnlCaptcha.Visible = false;
                    PnlSelectUser.Visible = false;
                    PnlSelectDepartment.Visible = false;
                    PnlSelectRole.Visible = false;
                    PnlSelectCode.Visible = false;
                    PnlVote.Visible = true;
                    break;
                case 28:
                    PnlText.Visible = false;
                    PnlMultiText.Visible = false;
                    PnlEditor.Visible = false;
                    PnlRadio.Visible = false;
                    PnlNumber.Visible = false;
                    PnlCurrency.Visible = false;
                    PnlDate.Visible = false;
                    PnlTime.Visible = false;
                    PnlURL.Visible = false;
                    PnlPhoneMobile.Visible = false;
                    PnlPhoneFixed.Visible = false;
                    PnlColor.Visible = false;
                    PnlCustomized.Visible = false;
                    PnlTableField.Visible = false;
                    PnlPicture.Visible = false;
                    PnlMultiPicture.Visible = false;
                    PnlFile.Visible = false;
                    PnlMultiFile.Visible = false;
                    PnlRegion.Visible = false;
                    PnlKeyword.Visible = false;
                    PnlCaptcha.Visible = true;
                    PnlSelectUser.Visible = false;
                    PnlSelectDepartment.Visible = false;
                    PnlSelectRole.Visible = false;
                    PnlSelectCode.Visible = false;
                    PnlVote.Visible = false;
                    break;
                case 29:
                    RadTableField.Checked = true;
                    PnlText.Visible = false;
                    PnlMultiText.Visible = false;
                    PnlEditor.Visible = false;
                    PnlRadio.Visible = false;
                    PnlNumber.Visible = false;
                    PnlCurrency.Visible = false;
                    PnlDate.Visible = false;
                    PnlTime.Visible = false;
                    PnlURL.Visible = false;
                    PnlPhoneMobile.Visible = false;
                    PnlPhoneFixed.Visible = false;
                    PnlColor.Visible = false;
                    PnlCustomized.Visible = false;
                    PnlTableField.Visible = true;
                    PnlPicture.Visible = false;
                    PnlMultiPicture.Visible = false;
                    PnlFile.Visible = false;
                    PnlMultiFile.Visible = false;
                    PnlRegion.Visible = false;
                    PnlKeyword.Visible = false;
                    PnlCaptcha.Visible = false;
                    PnlSelectUser.Visible = false;
                    PnlSelectDepartment.Visible = false;
                    PnlSelectRole.Visible = false;
                    PnlSelectCode.Visible = false;
                    PnlVote.Visible = false;
                    break;
                default:
                    break;
            }
        }

        //表字段 表名变更触发 字段显示改变
        protected void TableTextChanged(Object sender, EventArgs e)
        {
            DevExpress.Web.ASPxEditors.ASPxComboBox table = (DevExpress.Web.ASPxEditors.ASPxComboBox)sender;
            try
            {
                using (TestDBEntities db = new TestDBEntities())
                {
                    string modelname = Request.Params["ModelName"];
                    List<Model> codelist1 = db.Model.Where(q => q.ModelName != modelname).ToList();
                    TableFieldtable.DataSource = codelist1;
                    TableFieldtable.DataBind();

                    string modelcode = table.Value.ToString();
                    TableFieldfield.Text = "";
                    List<ModelField> codelist2 = db.ModelField.Where(q => q.ModelCode == modelcode).ToList();
                    TableFieldfield.DataSource = codelist2;
                    TableFieldfield.DataBind();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}