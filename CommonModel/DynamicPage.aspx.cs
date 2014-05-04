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
    public partial class DynamicPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!this.IsPostBack)
            //{
            string ModelName = Request.QueryString["ModelName"];//表名
            string tableCode = Request.QueryString["tableCode"];//用户数据内容GUID
            string EditMode = Request.QueryString["EditMode"];//编辑模式
            List<ContentModel1._5.Entities.ModelField> fields = new List<ContentModel1._5.Entities.ModelField>();
            List<ContentModel1._5.Common.ModuleField> moduleFieldList = new List<ContentModel1._5.Common.ModuleField>();
            #region Edit
            if (EditMode == "Edit")
            {
                using (TestDBEntities entities = new TestDBEntities())
                {
                    fields = entities.ModelField.Where(s => s.ModelName == ModelName).ToList();
                }
                //读取特定用户表数据行
                SqlConnection con = new SqlConnection("Data Source=180.85.152.37;Initial Catalog=TestDB;Persist Security Info=True;User ID=sa;Password=123456");
                SqlDataAdapter ada = new SqlDataAdapter("SELECT * FROM App_" + ModelName + " WHERE " + ModelName + "Code='" + tableCode + "'", con);
                DataSet userset = new DataSet();
                ada.Fill(userset, "usertable");
                con.Close();
                foreach (ModelField field in fields)
                {
                    #region 根据数据库中ModuleField构造对应表的字段控件
                    ContentModel1._5.Common.ModuleField commonField = new ContentModel1._5.Common.ModuleField();
                    commonField.FieldID = field.FieldID;
                    commonField.ModelCode = field.ModelCode;
                    commonField.ModelName = field.ModelName;
                    commonField.TargetModelName = field.TargetModelName==null?null:field.TargetModelName;
                    commonField.Code = field.Code;
                    commonField.Name = field.Name;
                    commonField.Nick = field.Nick == null ? null : field.Nick;
                    commonField.Tooltip = field.Tooltip == null ? null : field.Tooltip;
                    commonField.Remark = field.Remark == null ? null : field.Remark;
                    commonField.ErrorText = field.ErrorText == null ? null : field.ErrorText;
                    commonField.NullText = field.NullText == null ? null : field.NullText;
                    if (field.Width != null) { commonField.Width = Convert.ToInt16(field.Width); }
                    if (field.Height != null) { commonField.Height = Convert.ToInt16(field.Height); }
                    if (field.MaxLength != null) { commonField.MaxLength = Convert.ToInt16(field.MaxLength); }
                    commonField.GroupCode = field.GroupCode == null ? null : field.GroupCode;
                    commonField.GroupName = field.GroupName == null ? null : field.GroupName;
                    if (field.DisplayOrder != null) { commonField.DisplayOrder = Convert.ToInt16(field.DisplayOrder); }
                    if (field.IsRequired != null) { commonField.IsRequired = Convert.ToBoolean(field.IsRequired); }
                    if (field.IsAllowSearch != null) { commonField.IsAllowSearch = Convert.ToBoolean(field.IsAllowSearch); }
                    if (field.IsReadOnly != null) { commonField.IsReadOnly = Convert.ToBoolean(field.IsReadOnly); }
                    if (field.IsVisible != null) { commonField.IsVisible = Convert.ToBoolean(field.IsVisible); }
                    commonField.DefaultValue = field.DefaultValue == null ? null : field.DefaultValue;
                    commonField.MaxValue = field.MaxValue == null ? null : field.MaxValue;
                    commonField.MinValue = field.MinValue == null ? null : field.MinValue;
                    if (field.FieldType == 4 || field.FieldType == 5 || field.FieldType == 6 || field.FieldType == 7 || field.FieldType == 22 || field.FieldType == 23 || field.FieldType == 24 || field.FieldType == 25)
                    {
                        //if (field.Name.Substring(field.Name.Length - 4, 4) == "Code")
                        //{
                        //    commonField.CurrentValue = userset.Tables["usertable"].Rows[0][field.Name].ToString() == "" ? null : userset.Tables["usertable"].Rows[0][field.Name];
                        //    commonField.CurrentCode = userset.Tables["usertable"].Rows[0][field.Name].ToString() == "" ? null : userset.Tables["usertable"].Rows[0][field.Name];
                        //}
                        if (field.Name.Substring(field.Name.Length - 5, 5) == "Value")
                        {
                            commonField.CurrentValue = userset.Tables["usertable"].Rows[0][field.Name].ToString() == "" ? null : userset.Tables["usertable"].Rows[0][field.Name];
                            commonField.CurrentCode = userset.Tables["usertable"].Rows[0][field.Name.Substring(0, field.Name.Length - 5) + "Code"].ToString() == "" ? null : userset.Tables["usertable"].Rows[0][field.Name];
                        }
                    }
                    else
                    {
                        commonField.CurrentValue = userset.Tables["usertable"].Rows[0][field.Name].ToString() == "" ? null : userset.Tables["usertable"].Rows[0][field.Name];
                    }
                    commonField.CodeCat = field.CodeCat == null ? null : field.CodeCat;
                    commonField.DisplayFormat = field.DisplayFormat == null ? null : field.DisplayFormat;
                    if (field.HasWaterMark != null) { commonField.HasWaterMark = Convert.ToBoolean(field.HasWaterMark); }
                    if (field.WaterMarkType != null) { commonField.WaterMarkType = field.WaterMarkType == null ? null : field.WaterMarkType; }
                    if (field.ImageSize != null) { commonField.ImageSize = Convert.ToInt16(field.ImageSize); }
                    if (field.SingleOrMultiple != null) { commonField.SingleOrMultiple = Convert.ToBoolean(field.SingleOrMultiple); }
                    if (field.FieldType != null) { commonField.FieldType = (FieldType)field.FieldType; } else { commonField.FieldType = FieldType.None; }
                    #endregion
                    moduleFieldList.Add(commonField);
                }
                /// <summary>
                /// 初始化该页面并添加到主页面中
                /// </summary>
                PageInput pi = new PageInput(moduleFieldList, this);
                Control ctrl = pi.Build();
                this.Form.Controls.Add(new LiteralControl("<br>"));
                this.Form.Controls.Add(new LiteralControl("<br>"));
                this.Form.Controls.Add(new LiteralControl("<br>"));
                this.Form.Controls.Add(new LiteralControl("<br>"));
                this.Form.Controls.Add(new LiteralControl("<table border='1' align= 'center'>"));
                this.Form.Controls.Add(ctrl);
                this.Form.Controls.Add(new LiteralControl("<td>"));
                this.Form.Controls.Add(new LiteralControl("</td>"));
                this.Form.Controls.Add(new LiteralControl("<td>"));
                ASPxButton button = new ASPxButton();
                button.Click += new EventHandler(this.update_Click);
                button.Text = "提交更改";
                //button.Attributes.Add("onclick", "myButton_Click");
                this.Form.Controls.Add(button);
                this.Form.Controls.Add(new LiteralControl("</td>"));
                this.Form.Controls.Add(new LiteralControl("</table>"));
            }
            #endregion
            #region Add
            else
            {
                using (TestDBEntities entities = new TestDBEntities())
                {
                    fields = entities.ModelField.Where(s => s.ModelName == ModelName).ToList();
                }
                foreach (ModelField field in fields)
                {
                    #region 根据数据库中ModuleField构造对应表的字段控件
                    ContentModel1._5.Common.ModuleField commonField = new ContentModel1._5.Common.ModuleField();
                    commonField.FieldID = field.FieldID;
                    commonField.ModelCode = field.ModelCode;
                    commonField.ModelName = field.ModelName;
                    commonField.TargetModelName = field.TargetModelName == null ? null : field.TargetModelName;
                    commonField.Code = field.Code;
                    commonField.Name = field.Name;
                    commonField.Nick = field.Nick == null ? null : field.Nick;
                    commonField.Tooltip = field.Tooltip == null ? null : field.Tooltip;
                    commonField.Remark = field.Remark == null ? null : field.Remark;
                    commonField.ErrorText = field.ErrorText == null ? null : field.ErrorText;
                    commonField.NullText = field.NullText == null ? null : field.NullText;
                    if (field.Width != null) { commonField.Width = Convert.ToInt16(field.Width); }
                    if (field.Height != null) { commonField.Height = Convert.ToInt16(field.Height); }
                    if (field.MaxLength != null) { commonField.MaxLength = Convert.ToInt16(field.MaxLength); }
                    commonField.GroupCode = field.GroupCode == null ? null : field.GroupCode;
                    commonField.GroupName = field.GroupName == null ? null : field.GroupName;
                    if (field.DisplayOrder != null) { commonField.DisplayOrder = Convert.ToInt16(field.DisplayOrder); }
                    if (field.IsRequired != null) { commonField.IsRequired = Convert.ToBoolean(field.IsRequired); }
                    if (field.IsAllowSearch != null) { commonField.IsAllowSearch = Convert.ToBoolean(field.IsAllowSearch); }
                    if (field.IsReadOnly != null) { commonField.IsReadOnly = Convert.ToBoolean(field.IsReadOnly); }
                    if (field.IsVisible != null) { commonField.IsVisible = Convert.ToBoolean(field.IsVisible); }
                    commonField.DefaultValue = field.DefaultValue == null ? null : field.DefaultValue;
                    commonField.MaxValue = field.MaxValue == null ? null : field.MaxValue;
                    commonField.MinValue = field.MinValue == null ? null : field.MinValue;
                    commonField.CodeCat = field.CodeCat == null ? null : field.CodeCat;
                    commonField.DisplayFormat = field.DisplayFormat == null ? null : field.DisplayFormat;
                    if (field.HasWaterMark != null) { commonField.HasWaterMark = Convert.ToBoolean(field.HasWaterMark); }
                    if (field.WaterMarkType != null) { commonField.WaterMarkType = field.WaterMarkType == null ? null : field.WaterMarkType; }
                    if (field.ImageSize != null) { commonField.ImageSize = Convert.ToInt16(field.ImageSize); }
                    if (field.SingleOrMultiple != null) { commonField.SingleOrMultiple = Convert.ToBoolean(field.SingleOrMultiple); }
                    if (field.FieldType != null) { commonField.FieldType = (FieldType)field.FieldType; } else { commonField.FieldType = FieldType.None; }
                    #endregion
                    moduleFieldList.Add(commonField);
                }
                #region 测试数据

                //ModuleField selectcode = new ModuleField();
                //selectcode.FieldType = FieldType.SelectCode;
                //selectcode.Nick = "代码选择：";
                //selectcode.CodeCat = "003";
                ////selectcode.Width = 500;
                ////selectcode.Height = 400;
                //selectcode.SingleOrMultiple = true;
                //selectcode.DisplayFormat = CommonField.TreeList.ToString();
                //moduleFieldList.Add(selectcode);

                #endregion
                PageInput pi = new PageInput(moduleFieldList, this);
                Control ctrl = pi.Build();
                this.Form.Controls.Add(new LiteralControl("<br>"));
                this.Form.Controls.Add(new LiteralControl("<br>"));
                this.Form.Controls.Add(new LiteralControl("<br>"));
                this.Form.Controls.Add(new LiteralControl("<br>"));
                this.Form.Controls.Add(new LiteralControl("<table border='1' align= 'center'>"));
                this.Form.Controls.Add(ctrl);
                this.Form.Controls.Add(new LiteralControl("<td>"));
                this.Form.Controls.Add(new LiteralControl("</td>"));
                this.Form.Controls.Add(new LiteralControl("<td>"));
                ASPxButton button = new ASPxButton();
                button.Click += new EventHandler(this.insert_Click);
                button.Text = "添加";
                this.Form.Controls.Add(button);
                this.Form.Controls.Add(new LiteralControl("</td>"));
                this.Form.Controls.Add(new LiteralControl("</table>"));
                //}
            }
            #endregion
        }
        protected void insert_Click(Object sender, EventArgs e)
        {
            #region 写入ModelField表中



            foreach (string key in Request.Form.AllKeys)
            {
                Response.Write(key + ":********");

                Response.Write(Request.Form[key]);

                Response.Write("<br>");
                Response.Write("<br>");
            }
            Response.Write("<br>");
            Response.Write("<br>");
            Response.Write("<br>");
            string modelName = Request.Params["ModelName"]; //获取得到表名
            //反序列化该KeyFieldList
            List<KeyField> keyFieldList = (List<KeyField>)JsonConvert.DeserializeObject(Request.Params["panel$hfKeyFields"], typeof(List<KeyField>));
            string modelCode = Guid.NewGuid().ToString("N").ToUpper();
            string SQL = null;
            StringBuilder tableField = new StringBuilder();
            StringBuilder fieldValue = new StringBuilder();
            tableField.Append(modelName + "Code,");
            fieldValue.Append("'" + modelCode + "',");
            foreach (KeyField kf in keyFieldList)
            {
                #region 多行文本HTML数据需要处理
                if (kf.Key.ToString().Contains("_HT"))
                {
                    tableField.Append(kf.FieldName + ",");
                    fieldValue.Append("'" + System.Web.HttpUtility.HtmlDecode(Request.Params[kf.Key]) + "',");
                }
                #endregion
                #region 单选获取的数据需要处理
                else if (kf.Key.ToString().Contains("$RB"))
                {
                    string rb = Request.Params[kf.Key];
                    string rbc = Request.Params[kf.Key];
                    if (rb == "12|#|#")//一项都没选择
                    {
                        tableField.Append(kf.FieldName.Substring(0, kf.FieldName.Length - 5) + "Code,");
                        fieldValue.Append("'',");
                        tableField.Append(kf.FieldName + ",");
                        fieldValue.Append("'',");
                    }
                    else
                    {
                        tableField.Append(kf.FieldName.Substring(0, kf.FieldName.Length - 5) + "Code,");
                        rbc = rbc.Substring(5, rbc.Length - 6);
                        int index = rbc.IndexOf("|4|8|1");
                        rbc = rbc.Substring(index + 6, rbc.Length - index - 6);
                        fieldValue.Append("'" + rbc + "',");
                        tableField.Append(kf.FieldName + ",");
                        index = rb.IndexOf("|");
                        index = rb.IndexOf("|", index + 1);
                        rb = rb.Substring(index + 1, rb.IndexOf("|", index + 1) - index - 1);
                        fieldValue.Append("'" + rb + "',");
                    }
                }
                #endregion
                #region 复选获取的数据需要处理
                else if (kf.Key.ToString().Contains("$CB"))
                {
                    string cbvalue = Request.Params[kf.Key + "$ctl01$I"];
                    string cbcode = Request.Params[kf.Key + "$ctl02$I"];
                    if (cbcode == "12|#|#")//一项都没选择
                    {
                        tableField.Append(kf.FieldName.Substring(0, kf.FieldName.Length - 5) + "Code,");
                        fieldValue.Append("'',");
                        tableField.Append(kf.FieldName + ",");
                        fieldValue.Append("'',");
                    }
                    else
                    {
                        tableField.Append(kf.FieldName.Substring(0, kf.FieldName.Length - 5) + "Code,");
                        cbcode = cbcode.Substring(5, cbcode.Length - 5);
                        cbcode = cbcode.Replace("|4|1|1", ";");
                        cbcode = cbcode.Replace("|8|1|1", ";");
                        cbcode = cbcode.Substring(0, cbcode.Length - 2);
                        fieldValue.Append("'" + cbcode + "',");
                        tableField.Append(kf.FieldName + ",");
                        cbvalue = cbvalue.Substring(5, cbvalue.Length - 5);
                        cbvalue = cbvalue.Replace("|4|1|1", ";");
                        cbvalue = cbvalue.Replace("|8|1|1", ";");
                        cbvalue = cbvalue.Substring(0, cbvalue.Length - 2);
                        fieldValue.Append("'" + cbvalue + "',");
                    }
                }
                #endregion
                #region 下拉单选的数据需要处理
                else if (kf.Key.ToString().Contains("$SD"))
                {
                    tableField.Append(kf.FieldName.Substring(0, kf.FieldName.Length - 5) + "Code,");
                    fieldValue.Append("'" + Request.Params[kf.Key.Replace("$", "_") + "_VI"] + "',");
                    tableField.Append(kf.FieldName + ",");
                    fieldValue.Append("'" + Request.Params[kf.Key] + "',");
                }
                #endregion
                #region 下拉多选的数据需要处理
                else if (kf.Key.ToString().Contains("$MD"))
                {
                    string md = Request.Params[kf.Key + "$ctl02$I"];
                    if (md == "12|#|#")//一项都没选择
                    {
                        tableField.Append(kf.FieldName.Substring(0, kf.FieldName.Length - 5) + "Code,");
                        fieldValue.Append("'',");
                    }
                    else
                    {
                        tableField.Append(kf.FieldName.Substring(0, kf.FieldName.Length - 5) + "Code,");
                        md = md.Substring(5, md.Length - 5);
                        md = md.Replace("|4|1|1", ";");
                        md = md.Substring(0, md.Length - 2);
                        fieldValue.Append("'" + md + "',");
                    }
                    tableField.Append(kf.FieldName + ",");
                    fieldValue.Append("'" + Request.Params[kf.Key + "$ctl01"] + "',");
                }
                #endregion
                #region 日期获取的数据需要处理
                else if (kf.Key.ToString().Contains("_DAT"))
                {
                    tableField.Append(kf.FieldName + ",");
                    fieldValue.Append("'" + Request.Params[kf.Key] + "',");
                }
                #endregion
                #region 时间获取的数据需要处理
                else if (kf.Key.ToString().Contains("_TIM"))
                {
                    tableField.Append(kf.FieldName + ",");
                    fieldValue.Append("'" + Request.Params[kf.Key] + "',");
                }
                #endregion
                #region 超链接的数据需要处理
                else if (kf.Key.ToString().Contains("$LINK"))
                {
                    tableField.Append(kf.FieldName + ",");
                    fieldValue.Append("'" + Request.Params[kf.Key + "$ctl02"] + "||||||||||" + Request.Params[kf.Key + "$ctl04"] + "',");
                }
                #endregion
                #region 选择代码的数据需要处理
                else if (kf.Key.ToString().Contains("SLCOD"))
                {
                    string repalce = kf.Key.Replace("_", "$");
                    repalce = repalce.Substring(0, repalce.Length - 9);                    
                    int slcode_idx = repalce.IndexOf("SLCOD") + 5; //panel$SLCOD123$
                    string fieldID = repalce.Substring(slcode_idx, repalce.Length - slcode_idx - 1);
                    repalce += "hidden_sc" + fieldID + "$I";
                    string hidden = kf.Key.Replace(kf.Key, repalce);
                    string hidden_sc = Request.Params[hidden];
                    if (hidden_sc == "12|#|#")
                    {
                        tableField.Append(kf.FieldName + ",");                        
                        //为null的情况为gridview下情况
                        if (Request.Params[kf.Key] == null)
                        {
                            string rvalue = kf.Key.Replace("_", "$");
                            rvalue = rvalue.Substring(0, rvalue.Length - 4);
                            fieldValue.Append("'" + Request.Params[rvalue] + "',");
                        }
                        else {
                            fieldValue.Append("'" + Request.Params[kf.Key] + "',");
                        }
                    }
                    else
                    {
                        #region hidden_sc替换
                        string flagStr = string.Empty;
                        if (hidden_sc.Contains("4|8|1"))
                            flagStr = "4|8|1";
                        else if (hidden_sc.Contains("4|12|1"))
                            flagStr = "4|12|1";
                        else if (hidden_sc.Contains("4|16|1"))
                            flagStr = "4|16|1"; //treelist nav
                        else if (hidden_sc.Contains("4|4|1"))
                            flagStr = "4|4|1";  //gridview
                        else if (hidden_sc.Contains("4|5|1"))
                            flagStr = "4|5|1";  //gridview

                        #region 
                        //int idx = hidden_sc.IndexOf(flagStr);
                        //string subStr = hidden_sc.Substring(idx);
                        //subStr = subStr.Replace(flagStr, ";");
                        //subStr = subStr.Replace("#", "");
                        //subStr = subStr.Substring(1);
                        #endregion
                        int idx = hidden_sc.IndexOf("00");
                        string subStr = hidden_sc.Substring(idx);
                        subStr = subStr.Replace("#", "");
                        // 后续处理TreeList(特殊字符)
                        if (subStr.Contains("4|"))//003-001;003-0024|12|1003-002-0014|12|1003-002-0024|16|1003-002-002-001
                            subStr = subStr.Replace("4|", ";");
                        if (subStr.Contains("|1"))//003-001;003-002;12|1003-002-001;12|1003-002-002;16|1003-002-002-001
                            subStr = subStr.Replace("|1", "|");
                        if (subStr.Contains("|"))
                        {
                            StringBuilder builder = new StringBuilder();
                            string[] _strarr = subStr.Split('|');
                            for (int i = 0; i < _strarr.Length - 1; i++)
                            {
                                int index = _strarr[i].LastIndexOf(";");  //003-001;003-002;12|003-002-001;12|003-002-002;16|003-002-002-001                              
                                builder.Append(_strarr[i].Substring(0, index));
                                builder.Append(";");
                            }
                            builder.Append(_strarr[_strarr.Length - 1]);
                            subStr = builder.ToString();
                        }

                        #endregion
                        tableField.Append(kf.FieldName.Substring(0, kf.FieldName.Length - 5) + "Code,");
                        fieldValue.Append("'"+subStr+"',");
                        tableField.Append(kf.FieldName+",");
                        //fieldValue.Append("'"+Request.Params[kf.Key]+"',");
                        if (Request.Params[kf.Key] == null)
                        {
                            string rvalue = kf.Key.Replace("_", "$");
                            rvalue = rvalue.Substring(0, rvalue.Length - 4);
                            fieldValue.Append("'" + Request.Params[rvalue] + "',");
                        }
                        else
                        {
                            fieldValue.Append("'" + Request.Params[kf.Key] + "',");
                        }
                    }
                }
                #endregion                   
                    
                #region 不需要处理的数据，通用
                else
                {
                    tableField.Append(kf.FieldName + ",");
                    fieldValue.Append("'" + Request.Params[kf.Key] + "',");
                }
                #endregion
            }
            tableField.Remove(tableField.Length - 1, 1);
            fieldValue.Remove(fieldValue.Length - 1, 1);
            SQL = string.Format("INSERT INTO App_{0} ({1}) VALUES ({2})", modelName, tableField, fieldValue);
            //写入数据库 
            if (ReturnType.Succuss == SqlHelper.InsertRecord(SQL))
            {
                Response.Write("记录添加成功！");
            }
            #endregion
        }
        protected void update_Click(Object sender, EventArgs e)
        {
            #region 写入ModelField表中
            foreach (string key in Request.Form.AllKeys)
            {
                Response.Write(key + ":********");
                Response.Write(Request.Form[key]);
                Response.Write("<br>");
                Response.Write("<br>");
            }
            Response.Write("<br>");
            Response.Write("<br>");
            Response.Write("<br>");
            string modelName = Request.Params["ModelName"];//结构表表名
            string userCode = Request.Params["tableCode"];//结构表编码
            //反序列化该KeyFieldList
            List<KeyField> keyFieldList = (List<KeyField>)JsonConvert.DeserializeObject(Request.Params["panel$hfKeyFields"], typeof(List<KeyField>));

            StringBuilder SQL = new StringBuilder();
            List<string> tableField = new List<string>();
            List<string> fieldValue = new List<string>();
            foreach (KeyField kf in keyFieldList)
            {
                #region 多行文本HTML
                if (kf.Key.ToString().Contains("_HT"))
                {
                    tableField.Add(kf.FieldName);
                    fieldValue.Add(System.Web.HttpUtility.HtmlDecode(Request.Params[kf.Key]));
                }
                #endregion
                #region 单选获取的数据需要处理
                else if (kf.Key.ToString().Contains("$RB"))
                {
                    string rb = Request.Params[kf.Key];
                    string rbc = Request.Params[kf.Key];
                    if (rb == "12|#|#")//一项都没选择
                    {
                        tableField.Add(kf.FieldName.Substring(0, kf.FieldName.Length - 5) + "Code");
                        fieldValue.Add(",");
                        tableField.Add(kf.FieldName);
                        fieldValue.Add("");
                    }
                    else
                    {
                        tableField.Add(kf.FieldName.Substring(0, kf.FieldName.Length - 5) + "Code");
                        rbc = rbc.Substring(5, rbc.Length - 6);
                        int index = rbc.IndexOf("|4|8|1");
                        rbc = rbc.Substring(index + 6, rbc.Length - index - 6);
                        fieldValue.Add(rbc);
                        tableField.Add(kf.FieldName);
                        index = rb.IndexOf("|");
                        index = rb.IndexOf("|", index + 1);
                        rb = rb.Substring(index + 1, rb.IndexOf("|", index + 1) - index - 1);
                        fieldValue.Add(rb);
                    }
                }
                #endregion
                #region 复选获取的数据需要处理
                else if (kf.Key.ToString().Contains("$CB"))
                {
                    string cbvalue = Request.Params[kf.Key + "$ctl01$I"];
                    string cbcode = Request.Params[kf.Key + "$ctl02$I"];
                    if (cbcode == "12|#|#")//一项都没选择
                    {
                        tableField.Add(kf.FieldName.Substring(0, kf.FieldName.Length - 5) + "Code");
                        fieldValue.Add("");
                        tableField.Add(kf.FieldName);
                        fieldValue.Add("");
                    }
                    else
                    {
                        tableField.Add(kf.FieldName.Substring(0, kf.FieldName.Length - 5) + "Code");
                        cbcode = cbcode.Substring(5, cbcode.Length - 5);
                        cbcode = cbcode.Replace("|4|1|1", ";");
                        cbcode = cbcode.Replace("|8|1|1", ";");
                        cbcode = cbcode.Substring(0, cbcode.Length - 2);
                        fieldValue.Add(cbcode);
                        tableField.Add(kf.FieldName);
                        cbvalue = cbvalue.Substring(5, cbvalue.Length - 5);
                        cbvalue = cbvalue.Replace("|4|1|1", ";");
                        cbvalue = cbvalue.Replace("|8|1|1", ";");
                        cbvalue = cbvalue.Substring(0, cbvalue.Length - 2);
                        fieldValue.Add(cbvalue);
                    }
                }
                #endregion
                #region 下拉单选的数据需要处理
                else if (kf.Key.ToString().Contains("$SD"))
                {
                    tableField.Add(kf.FieldName.Substring(0, kf.FieldName.Length - 5) + "Code");
                    fieldValue.Add(Request.Params[kf.Key.Replace("$", "_") + "_VI"]);
                    tableField.Add(kf.FieldName);
                    fieldValue.Add(Request.Params[kf.Key]);
                }
                #endregion
                #region 下拉多选的数据需要处理
                else if (kf.Key.ToString().Contains("$MD"))
                {
                    string md = Request.Params[kf.Key + "$ctl02$I"];
                    if (md == "12|#|#")//一项都没选择
                    {
                        tableField.Add(kf.FieldName.Substring(0, kf.FieldName.Length - 5) + "Code");
                        fieldValue.Add("");
                    }
                    else
                    {
                        tableField.Add(kf.FieldName.Substring(0, kf.FieldName.Length - 5) + "Code");
                        md = md.Substring(5, md.Length - 5);
                        md = md.Replace("|4|1|1", ";");
                        md = md.Substring(0, md.Length - 2);
                        fieldValue.Add(md);
                    }
                    tableField.Add(kf.FieldName);
                    fieldValue.Add(Request.Params[kf.Key + "$ctl01"]);
                }
                #endregion
                #region 日期获取的数据需要处理
                else if (kf.Key.ToString().Contains("_DAT"))
                {
                    tableField.Add(kf.FieldName);
                    fieldValue.Add(Request.Params[kf.Key]);
                }
                #endregion
                #region 时间获取的数据需要处理
                else if (kf.Key.ToString().Contains("_TIM"))
                {
                    tableField.Add(kf.FieldName);
                    fieldValue.Add(Request.Params[kf.Key]);
                }
                #endregion
                #region 超链接的数据需要处理
                else if (kf.Key.ToString().Contains("$LINK"))
                {
                    tableField.Add(kf.FieldName);
                    fieldValue.Add(Request.Params[kf.Key + "$ctl02"] + "||||||||||" + Request.Params[kf.Key + "$ctl04"]);
                }
                #endregion
                #region 选择代码的数据需要处理
                else if (kf.Key.ToString().Contains("SLCOD"))
                {
                    string repalce = kf.Key.Replace("_","$");
                    repalce = repalce.Substring(0, repalce.Length - 9);
                    int slcode_idx = repalce.IndexOf("SLCOD") + 5; //panel$SLCOD123$
                    string fieldID = repalce.Substring(slcode_idx, repalce.Length-slcode_idx - 1);
                    repalce += "hidden_sc"+fieldID+"$I";
                    string hidden = kf.Key.Replace(kf.Key, repalce);
                    string hidden_sc = Request.Params[hidden];
                    if (hidden_sc == "12|#|#")
                    {
                        tableField.Add(kf.FieldName);
                        //fieldValue.Add(Request.Params[kf.Key]);
                        if (Request.Params[kf.Key] == null)
                        {
                            string rvalue = kf.Key.Replace("_", "$");
                            rvalue = rvalue.Substring(0, rvalue.Length - 4);
                            fieldValue.Add(Request.Params[rvalue]);
                        }
                        else
                        {
                            fieldValue.Add(Request.Params[kf.Key]);
                        }
                    }
                    else
                    {
                        #region hidden_sc替换                        
                        string flagStr = string.Empty;
                        int number = 20;
                        int charCount = GetHiddenFieldCharCount(hidden_sc);
                        if (hidden_sc.Contains("4|8|1"))
                            flagStr = "4|8|1";
                        else if (hidden_sc.Contains("4|12|1"))
                            flagStr = "4|12|1";
                        else if (hidden_sc.Contains("4|16|1"))
                            flagStr = "4|16|1"; //treelist nav
                        else if (hidden_sc.Contains("4|4|1"))
                            flagStr = "4|4|1";  //gridview
                        else if (hidden_sc.Contains("4|" + number + "|1"))
                            flagStr = "";

                        #region
                        //int idx = hidden_sc.IndexOf(flagStr);
                        //string subStr = hidden_sc.Substring(idx);
                        //subStr = subStr.Replace(flagStr, ";");
                        //subStr = subStr.Replace("#", "");
                        //subStr = subStr.Substring(1);
                        #endregion
                        int idx = hidden_sc.IndexOf("00");
                        string subStr = hidden_sc.Substring(idx);
                        subStr = subStr.Replace("#", "");
                        //subStr = subStr.Substring(1);
                        // 后续处理TreeList(特殊字符)
                        if (subStr.Contains("4|"))//003-001;003-0024|12|1003-002-0014|12|1003-002-0024|16|1003-002-002-001
                            subStr = subStr.Replace("4|", ";");
                        if (subStr.Contains("|1"))//003-001;003-002;12|1003-002-001;12|1003-002-002;16|1003-002-002-001
                            subStr = subStr.Replace("|1","|");                        
                        if (subStr.Contains("|"))
                        {
                            StringBuilder builder = new StringBuilder();
                            string[] _strarr = subStr.Split('|');
                            for (int i = 0; i < _strarr.Length-1; i++)
                            {
                                int index = _strarr[i].LastIndexOf(";");  //003-001;003-002;12|003-002-001;12|003-002-002;16|003-002-002-001                              
                                builder.Append(_strarr[i].Substring(0, index));
                                builder.Append(";");
                            }
                            builder.Append(_strarr[_strarr.Length - 1]);
                            subStr = builder.ToString();
                        }                       

                        #endregion
                        tableField.Add(kf.FieldName.Substring(0, kf.FieldName.Length - 5) + "Code");
                        fieldValue.Add(subStr);
                        tableField.Add(kf.FieldName);
                        //fieldValue.Add(Request.Params[kf.Key]);
                        if (Request.Params[kf.Key] == null)
                        {
                            string rvalue = kf.Key.Replace("_", "$");
                            rvalue = rvalue.Substring(0, rvalue.Length - 4);
                            fieldValue.Add(Request.Params[rvalue]);
                        }
                        else
                        {
                            fieldValue.Add(Request.Params[kf.Key]);
                        }
                    }
                }
                #endregion
                #region 不需要处理的数据，通用
                else
                {
                    tableField.Add(kf.FieldName);
                    fieldValue.Add(Request.Params[kf.Key]);
                }
                #endregion
            }
            SQL.Append(string.Format("UPDATE App_{0} SET ", modelName));
            for (int i = 0; i < tableField.Count; i++)
            {
                SQL.Append(string.Format("{0}='{1}',", tableField[i], fieldValue[i]));
            }
            SQL.Remove(SQL.Length - 1, 1);
            SQL.Append(string.Format(" WHERE {0}Code='{1}'", modelName, userCode));
            //写入数据库
            if (ReturnType.Succuss == SqlHelper.UpDateRecord(SQL.ToString()))
            {
                Response.Write("记录更新成功！");
            }
            #endregion
        }

        private int GetHiddenFieldCharCount(string hfield)
        {
            int m = hfield.Length;
            hfield = hfield.Replace(";", "");
            return m - hfield.Length;
        }
    }
}