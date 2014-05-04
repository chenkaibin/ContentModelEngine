﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxGridView;
using ContentModel1._5.Entities;
using DevExpress.Web.ASPxEditors;
using System.Data;

namespace ContentModel1._5.CommonModel
{
    public partial class ContentManager : System.Web.UI.Page
    {
        public string BindField { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string ModelName = Request.QueryString["ModelName"];   //表名
                List<ContentModel1._5.Entities.ModelField> fields = new List<ContentModel1._5.Entities.ModelField>();
                using (TestDBEntities entities = new TestDBEntities())
                {
                    fields = entities.ModelField.Where(s => s.ModelName == ModelName).ToList();
                }

                using (TestDBEntities entities = new TestDBEntities())
                {
                    Entities.Model model = entities.Model.Where(s => s.ModelName == ModelName).FirstOrDefault();
                    ModelNameHidden.Value = ModelName;
                    ModelCodeHidden.Value = model.ModelCode;//结构表编码
                    BindField = ModelName + "ID";

                }
                // 内容动态生成
                GridViewDataTextColumn dtc = new GridViewDataTextColumn();
                dtc.Caption = ModelName + "ID";
                dtc.FieldName = ModelName + "ID";
                ASPxGridView1.Columns.Add(dtc);
                dtc = new GridViewDataTextColumn();
                dtc.Caption = ModelName + "Code";
                dtc.FieldName = ModelName + "Code";
                ASPxGridView1.Columns.Add(dtc);
                foreach (ContentModel1._5.Entities.ModelField field in fields)
                {
                    GridViewDataTextColumn DTC = new GridViewDataTextColumn();
                    DTC.Caption = field.Nick;
                    DTC.FieldName = field.Name;
                    ASPxGridView1.Columns.Add(DTC);
                    ASPxGridView1.Styles.AlternatingRow.Enabled = DevExpress.Utils.DefaultBoolean.True;
                }
                ASPxGridView1.KeyFieldName = ModelName + "Code";
                DataSet ds = SqlHelper.GetDataByTableName("App_" + ModelName);
                ASPxGridView1.DataSource = ds;
                ASPxGridView1.DataBind();
            }
        }
    }
}