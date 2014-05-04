using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ContentModel1._5.Entities;

namespace ContentModel1._5.CommonModel
{
    public partial class ModelManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                using(TestDBEntities entities = new TestDBEntities())
                {
                    ASPxGridView2.DataSource = entities.Model.Where(oo=>oo.IsSystem == false).ToList();
                    ASPxGridView2.DataBind();
                }                
            }
        }

        protected void ASPxGridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ModifyModel")
            {
                string url = string.Format("FieldManager.aspx?ModelName={0}", e.CommandArgument);
                Response.Redirect(url);
            }
            else if (e.CommandName == "ModifyRecord")
            {
                string url = string.Format("ContentManager.aspx?ModelName={0}", e.CommandArgument);
                Response.Redirect(url);
            }
        }

        protected void ASPxGridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

            }
        }
    }
}