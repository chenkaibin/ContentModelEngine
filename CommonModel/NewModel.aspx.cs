using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ContentModel1._5.Common;

namespace ContentModel1._5.CommonModel
{
    public partial class NewModel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Addtable_Click(object sender, EventArgs e)
        {
            string ModelId = TableID.Text;
            string ModelName = TableName.Text;
            if (ReturnType.Succuss == SqlHelper.InsertModel(ModelId))
            {
                Response.Write("添加表成功！");
            }
            //ModelCode是GUID生成的
            string ModelCode = Guid.NewGuid().ToString("N").ToUpper();
            string SQL;
            SQL = string.Format("INSERT INTO Model(ModelCode,ModelName,ModelMeaning) VALUES('{0}','{1}','{2}')", ModelCode, ModelId, ModelName);
            if (ReturnType.Succuss == SqlHelper.InsertRecord(SQL))
            {
                Response.Write("Model记录添加成功！");
            }
        }
    }
}