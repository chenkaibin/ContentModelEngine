using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ContentModel1._5.Entities;

namespace ContentModel1._5.CommonModel
{
    public partial class FieldManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string tableName = Request.QueryString["ModelName"];
                string tableCode = Request.QueryString["ModelCode"];
                using (TestDBEntities entities = new TestDBEntities())
                {
                    ASPxGridView1.DataSource = entities.ModelField.Where(s => s.ModelName == tableName).ToList();
                    ASPxGridView1.DataBind();
                }
                ModelNameHidden.Value = tableName;
                using (TestDBEntities entities = new TestDBEntities())
                {
                    Entities.Model model = entities.Model.Where(s => s.ModelName == tableName).FirstOrDefault();
                    ModelCodeHidden.Value = model.ModelCode;
                }
            }
        }
        protected void ASPxGridView1_DataBound(object sender, EventArgs e)
        {

        }
    }
}