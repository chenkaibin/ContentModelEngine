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
using System.Text;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxCallback;
using DevExpress.Web.ASPxHiddenField;
using System.Collections;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using DevExpress.Web.ASPxTreeList;
using DevExpress.Web.ASPxGridView;
using ContentModel1._5.Entities;
using ContentModel1._5.CommonModel;
using System.Data;

namespace ContentModel1._5.Common
{
    public class SelectCode : ControlBase, INamingContainer
    {
        #region 数据初始化

        public string TargetTableName { set; get; }
        public bool IsTree { set; get; }
        public static string Code = null;
        //public static List<DictionaryItem> _codedetaillist = null; 
        public List<DictionaryItem> _codedetaillist { set; get; }
        public List<ExtendCode> _extcodelist { set; get; }

        ASPxPanel panel = new ASPxPanel();
        ASPxTextBox cstb = new ASPxTextBox();

        ASPxPopupControl clipping = new ASPxPopupControl();
        ASPxButton btnconfirm = new ASPxButton();
        ASPxButton btncancel = new ASPxButton();
        ASPxButton btnmodal = new ASPxButton();

        ASPxCallback callback_sc = new ASPxCallback();//数据交互
        ASPxCallback callback_asyn = new ASPxCallback();//动态更新div_content

        ASPxHiddenField hidden_sc = new ASPxHiddenField();
        public SelectCode(ModuleField moduleField)
            : base(moduleField)
        {
            // 解决static造成的数据冲突问题
            List<DictionaryItem> detailist = new List<DictionaryItem>();
            if (Code != null)
            {
                // 不是Role，Org，User的情况，若为上述情况，则需要保存SelectCode当前值
                if (ModuleField.CodeCat != null)
                {
                    // 若为不同类型的SL（即Nav，TreeList，GridView情况）
                    if (Code.StartsWith(ModuleField.CodeCat))
                    {
                        int len = Code.Length + 4;
                        using (TestDBEntities entity = new TestDBEntities())
                        {
                            detailist = entity.DictionaryItem.Where(pp => pp.DictionaryItemCode.StartsWith(Code) && pp.DictionaryItemCode.Length == len).ToList();
                        }
                        _codedetaillist = detailist;
                    }
                    else
                    {
                        Code = ModuleField.CodeCat;
                        _codedetaillist = null;
                    }
                }
                //若为Role，Org，User的情况，则需要保存SelectCode当前值
                else
                {
                    int len = Code.Length + 4;
                    using (TestDBEntities entity = new TestDBEntities())
                    {
                        detailist = entity.DictionaryItem.Where(pp => pp.DictionaryItemCode.StartsWith(Code) && pp.DictionaryItemCode.Length == len).ToList();
                    }
                    _codedetaillist = detailist;
                }

                //// 用于Nav
                //int len = Code.Length + 4;
                //using (TestDBEntities entity = new TestDBEntities())
                //{
                //    detailist = entity.DictionaryItem.Where(pp => pp.DictionaryItemCode.StartsWith(Code) && pp.DictionaryItemCode.Length == len).ToList();
                //}
                //_codedetaillist = detailist;

                //if (Code.Equals(ModuleField.CodeCat) && ModuleField.CodeCat != null)
                //{
                //    int len = Code.Length + 4;
                //    using (TestDBEntities entity = new TestDBEntities())
                //    {
                //        detailist = entity.DictionaryItem.Where(pp => pp.DictionaryItemCode.StartsWith(Code) && pp.DictionaryItemCode.Length == len).ToList();
                //    }
                //    _codedetaillist = detailist;
                //}
                //else
                //{
                //    Code = null;
                //    _codedetaillist = null;
                //}
            }            
        }

        public override System.Web.UI.Control Build()
        {
            base.Build();

            hidden_sc.ID = "hidden_sc"+ModuleField.FieldID;
            hidden_sc.ClientInstanceName = "hidden_sc" + ModuleField.FieldID;

            #region   codevalue
            cstb.Width = 100;
            cstb.AutoPostBack = false;
            cstb.ClientInstanceName = "cstb"+ModuleField.FieldID;
            cstb.MaxLength = Convert.ToInt16(ModuleField.MaxValue);
            cstb.ValidationSettings.RequiredField.IsRequired = ModuleField.IsRequired;
            cstb.ValidationSettings.RequiredField.ErrorText = ModuleField.ErrorText;
            cstb.Text = ModuleField.CurrentValue == null ? ModuleField.DefaultValue == null ? null : ModuleField.DefaultValue.ToString() : ModuleField.CurrentValue.ToString();
            cstb.NullText = ModuleField.NullText;
            cstb.ReadOnly = true;
            #endregion

            callback_sc.ClientInstanceName = "callback_sc"+ModuleField.FieldID;
            callback_sc.Callback += new CallbackEventHandler(OnCallbackCompleteSC); //处理客户端提交过来的callback请求
            callback_sc.ClientSideEvents.CallbackComplete = "function(s,e) { CallbackSCComplete(s,e,"+ModuleField.FieldID+");}"; //处理完后对客户端的处理
            callback_asyn.ClientInstanceName = "callback_asyn"+ModuleField.FieldID;
            callback_asyn.Callback += new CallbackEventHandler(OnCallbackCompleteAsyn);
            callback_asyn.ClientSideEvents.CallbackComplete = "function(s,e) { CallbackSCCompleteContent(e);}";

            //弹出窗口的初始化
            clipping.CloseAction = CloseAction.CloseButton;
            clipping.Modal = true;
            clipping.PopupHorizontalAlign = PopupHorizontalAlign.WindowCenter;
            clipping.PopupVerticalAlign = PopupVerticalAlign.WindowCenter;
            clipping.ClientInstanceName = "selectcode"+ModuleField.FieldID;
            clipping.HeaderText = "选择代码";
            clipping.AllowDragging = true;
            clipping.EnableAnimation = false;
            clipping.EnableViewState = false;
            clipping.MinWidth = ModuleField.Width;
            clipping.MinHeight = ModuleField.Height;

            clipping = PopupRender(clipping);

            btnmodal.ClientInstanceName = "btnmodal"+ModuleField.FieldID;
            btnmodal.Text = "选择";
            btnmodal.ClientSideEvents.Click = "function(s,e) {ShowPopupWindow("+ModuleField.FieldID+");}";
            btnmodal.AutoPostBack = false;
            btnconfirm.ClientInstanceName = "btnconfirm"+ModuleField.FieldID;
            btnconfirm.Text = "确定";
            btnconfirm.ClientSideEvents.Click = "function(s,e) {  ReturnSelectedCode(e,'" + ModuleField.DisplayFormat + "','" + TargetTableName + "','"+IsTree+"');}";
            btnconfirm.AutoPostBack = false;
            btncancel.ClientInstanceName = "btncancel"+ModuleField.FieldID;
            btncancel.Text = "取消";
            btncancel.ClientSideEvents.Click = "function(s,e) {HidePopupWindow(" + ModuleField.FieldID + ");}"; 
            btncancel.AutoPostBack = false;

            clipping.Controls.Add(new LiteralControl("<table align='center'><tr><td>"));
            clipping.Controls.Add(btnconfirm);
            clipping.Controls.Add(new LiteralControl("</td><td>"));
            clipping.Controls.Add(btncancel);
            clipping.Controls.Add(new LiteralControl("</td><td></td></tr></table>"));

            panel.Controls.Add(new LiteralControl("<table><tr><td>"));
            panel.Controls.Add(cstb);
            panel.Controls.Add(new LiteralControl("</td><td>"));
            panel.Controls.Add(btnmodal);
            panel.Controls.Add(clipping);

            panel.Controls.Add(new LiteralControl("</td><td></td></tr></table>"));
            panel.Controls.Add(callback_sc);
            panel.Controls.Add(callback_asyn);
            panel.Controls.Add(hidden_sc);
            panel.RenderMode = RenderMode.Div;//默认render的模式
            return panel;
        }

        #endregion

        #region 从数据库数据生成弹出框控件

        //popup窗口布局的设置 ,主要是将nav导航，显示这两个panel加入到popup窗口中
        public ASPxPopupControl PopupRender(ASPxPopupControl clipping)
        {
            string _table = "Model";
            string _targetTable = string.Empty;
            _targetTable = GetTargetTableName((int)ModuleField.FieldType);
            TargetTableName = _targetTable;
            string sql = "select * from model where modelname = '" + _targetTable + "'";//ModuleField.TargetModelName+"'";
            DataSet userset = SqlHelper.GetDataBySQL(sql, _table);
            IsTree = (bool)userset.Tables[_table].Rows[0]["IsTree"];

            #region 代码选择
            if (TargetTableName == "Dictionary")//ModuleField.TargetModelName == "Dictionary")
            {
                if (ModuleField.DisplayFormat == CommonField.Nav.ToString())
                {
                    // 如果没有层级结构（istree为false）的话，就不动态加载导航条
                    // nav导航条的变化用js控制
                    Dictionary _codecat = new Dictionary();
                    using (TestDBEntities entity = new TestDBEntities())
                    {
                        _codecat = entity.Dictionary.Where(o => o.DictionaryCode == ModuleField.CodeCat).FirstOrDefault();
                    }
                    IsTree = _codecat.IsTree;
                    Code = ModuleField.CodeCat;

                    if (_codecat.IsTree)
                    {
                        clipping.Controls.Add(LoadNav(ModuleField.CodeCat));
                    }
                    //初始时刻默认将第一层级加载出来
                    clipping.Controls.Add(new LiteralControl("<div id='dyn_content'>"));
                    using (TestDBEntities entity = new TestDBEntities())
                    {
                        if (_codedetaillist == null)
                        {
                            if (_codecat.IsTree)
                            {
                                _codedetaillist = entity.DictionaryItem.Where(oo => oo.DictionaryItemCode.StartsWith(ModuleField.CodeCat) && oo.DictionaryItemCode.Length == 7).ToList();
                            }
                            else
                            {
                                _codedetaillist = entity.DictionaryItem.Where(oo => oo.DictionaryItemCode.StartsWith(ModuleField.CodeCat)).ToList();
                            }
                        }
                        // 默认初始打开第一层结构
                        else
                        {
                            //_codedetaillist = entity.DictionaryItem.Where(oo => oo.DictionaryItemCode.StartsWith(Code)).ToList();
                        }
                    }
                    clipping.Controls.Add(GetDisplayControl(_codedetaillist));
                    clipping.Controls.Add(new LiteralControl("</div><div id='test'></div>"));
                }
                if (ModuleField.DisplayFormat == CommonField.TreeList.ToString())
                {
                    clipping.Controls.Add(LoadTreeList(TargetTableName));
                }

                if (ModuleField.DisplayFormat == CommonField.GridView.ToString())
                {
                    clipping.Controls.Add(new LiteralControl("<div id='dyn_gridview'>"));
                    clipping.Controls.Add(LoadGridView(string.Empty, TargetTableName));
                    clipping.Controls.Add(new LiteralControl("</div>"));
                }
            }

            #endregion

            #region 机构、角色、用户、地区等
            else
            {
                if (IsTree)
                {
                    clipping.Controls.Add(LoadTreeList(TargetTableName));
                }
                else
                {
                    clipping.Controls.Add(new LiteralControl("<div id='dyn_gridview'>"));
                    clipping.Controls.Add(LoadGridView(string.Empty, TargetTableName));
                    clipping.Controls.Add(new LiteralControl("</div>"));
                }
            }
            #endregion

            return clipping;
        }

        public string GetTargetTableName(int fieldtype)
        {
            string target = string.Empty;
            if (fieldtype == 22)
                return "Dictionary";
            if (fieldtype == 23)
                return "Base_Org";
            if (fieldtype == 24)
                return "Base_User";
            if (fieldtype == 25)
                return "Base_Role";
            return target;
        }

        // 直接在函数中将控件布局写好，而参数就是数据库中的code值   http://www.cnblogs.com/Clingingboy/archive/2006/09/04/494737.html
        public System.Web.UI.Control GetDisplayControl(List<DictionaryItem> detaillist)
        {
            // 单选框 true
            if (ModuleField.SingleOrMultiple)
            {
                ASPxPanel panel = new ASPxPanel();
                panel.Controls.Add(new LiteralControl("<table align='center'>"));
                int i = 0;
                foreach (DictionaryItem codedetail in detaillist)
                {
                    i++;
                    ASPxRadioButton rb = new ASPxRadioButton();
                    rb.GroupName = "rbtn";
                    rb.AutoPostBack = false;

                    rb.Text = codedetail.DictionaryItemName;
                    rb.Value = codedetail.DictionaryItemValue;
                    panel.Controls.Add(new LiteralControl("<tr><td>"));
                    panel.Controls.Add(rb);
                    panel.Controls.Add(new LiteralControl("</td></tr>"));
                }
                panel.Controls.Add(new LiteralControl("</table>"));
                return panel;
            }
            // 复选框
            if (!ModuleField.SingleOrMultiple)
            {
                ASPxPanel panel = new ASPxPanel();
                panel.Controls.Add(new LiteralControl("<table align='center'>"));
                int i = 0;
                foreach (DictionaryItem codedetail in detaillist)
                {
                    i++;
                    ASPxCheckBox cb = new ASPxCheckBox();
                    if (IsTree)
                    {
                        //cb.ClientSideEvents.CheckedChanged = "checkchanged";//"function(e,args){checkchanged(e,args);}";
                        //首先判断该节点是否是父节点：如果是的话，就加载hyperlink超链接；反之就不做超链接
                        //if (cb.Checked)
                        if (true)
                        {
                            cb.Text = "";
                            cb.Value = "";
                            string link = "<a onclick=\"navclicked(\'" + codedetail.DictionaryItemCode + "\',\'" + codedetail.DictionaryItemName + "\',2)\">" + codedetail.DictionaryItemName + "</a>";
                            panel.Controls.Add(new LiteralControl("<tr><td>"));
                            panel.Controls.Add(cb);
                            panel.Controls.Add(new LiteralControl(link));
                        }
                    }
                    else
                    {
                        cb.Text = codedetail.DictionaryItemName;
                        cb.Value = codedetail.DictionaryItemValue;
                        panel.Controls.Add(new LiteralControl("<tr><td>"));
                        panel.Controls.Add(cb);
                    }
                    panel.Controls.Add(new LiteralControl("</td></tr>"));
                }
                panel.Controls.Add(new LiteralControl("</table>"));
                return panel;
            }
            return new LiteralControl("");
        }

        #endregion

        #region 动态加载DispalyFormat:GridView,Nav,TreeList

        // 根据code值，循环加载导航条；另外一种处理方式就是：在前台用js动态修改导航条（并不是每中修改都需要前后台的交互）
        public System.Web.UI.Control LoadNav(string code)
        {
            ASPxPanel panel = new ASPxPanel();
            #region 根据code获取nav的初始值
            Dictionary codecat = new Dictionary();
            string _catName = string.Empty;
            using (TestDBEntities entity = new TestDBEntities())
            {
                codecat = entity.Dictionary.Where(pp => pp.DictionaryCode == code).FirstOrDefault();
            }
            _catName = codecat.DictionaryName;
            string nav = "<div id='dyn_nav'><ul id='nav'><li>";
            nav += "<a onclick=\"navclicked(\'" + code + "\',\'" + _catName + "\',1)\">" + _catName + "</a></li><li>";
            panel.Controls.Add(new LiteralControl(nav));
            #endregion
            return panel;
        }

        // 初始加载treelist
        public System.Web.UI.Control LoadTreeList(string target)
        {
            ASPxPanel panel = new ASPxPanel();
            string _targetTable = GetTargetTableName((int)ModuleField.FieldType);
            StringBuilder sql = new StringBuilder();
            if (target == "Dictionary")
            {
                sql.Append("select * from DictionaryItem where 1=1");
                sql.Append(" and DictionaryItemCode like '" + ModuleField.CodeCat + "%'");
            }
            else
            {
                sql.Append("select * from " + _targetTable + " where 1=1");
            }
            DataSet userset = SqlHelper.GetDataBySQL(sql.ToString(), _targetTable);
            List<ExtendCode> extdlist = new List<ExtendCode>();
            for (int i = 0; i < userset.Tables[0].Rows.Count; i++)
            {
                DataRow dr = userset.Tables[0].Rows[i];
                ExtendCode extcode = new ExtendCode();
                extcode.ExtendCodeID = Convert.ToInt32(dr.ItemArray[0].ToString());
                extcode.ExtendCodeCode = dr.ItemArray[1].ToString();
                extcode.ExtendCodeName = dr.ItemArray[2].ToString();
                extcode.ParentID = Convert.ToInt32(dr.ItemArray[5].ToString());
                extdlist.Add(extcode);
            }

            ASPxTreeList treelist = new ASPxTreeList();
            treelist.ClientInstanceName = "treelist" + ModuleField.FieldID;
            treelist.KeyFieldName = "ExtendCodeID";
            treelist.ParentFieldName = "ParentID";
            treelist.SettingsSelection.Enabled = true;
            treelist.SettingsSelection.Recursive = true;
            treelist.SettingsSelection.AllowSelectAll = true;

            treelist.CustomDataCallback += new TreeListCustomDataCallbackEventHandler(treeList_CustomDataCallback); //treelist.GetSelectedNodes();
            treelist.ClientSideEvents.CustomDataCallback = "function(s, e) { CustomDataCallbackComplete(e,"+ModuleField.FieldID+");}";

            TreeListDataColumn datacol = new TreeListDataColumn();
            datacol.FieldName = "ExtendCodeName";
            datacol.VisibleIndex = 0;
            treelist.SettingsBehavior.ExpandCollapseAction = TreeListExpandCollapseAction.NodeDblClick;
            treelist.Columns.Add(datacol);
            panel.Controls.Add(treelist);

            treelist.DataSource = extdlist;
            treelist.DataBound += new EventHandler(treeList_DataBound);//treelist.DataBind();           

            return panel;
        }

        public System.Web.UI.Control LoadGridView(string param, string target)
        {
            ASPxPanel panel = new ASPxPanel();
            string _targetTable = GetTargetTableName((int)ModuleField.FieldType);
            StringBuilder sql = new StringBuilder();
            if (target == "Dictionary")
            {
                sql.Append("select * from DictionaryItem where 1=1");
                sql.Append(" and DictionaryItemCode like '" + ModuleField.CodeCat + "%'");
            }
            else
            {
                sql.Append("select * from " + _targetTable + " where 1=1");
            }
            DataSet userset = SqlHelper.GetDataBySQL(sql.ToString(), _targetTable);
            List<ExtendCode> extdlist = new List<ExtendCode>();
            for (int i = 0; i < userset.Tables[0].Rows.Count; i++)
            {
                DataRow dr = userset.Tables[0].Rows[i];
                ExtendCode extcode = new ExtendCode();
                extcode.ExtendCodeID = Convert.ToInt32(dr.ItemArray[0].ToString());
                extcode.ExtendCodeCode = dr.ItemArray[1].ToString();
                extcode.ExtendCodeName = dr.ItemArray[2].ToString();
                extdlist.Add(extcode);
            }

            ASPxGridView gridview = new ASPxGridView();
            gridview.ClientInstanceName = "gridview" + ModuleField.FieldID;
            gridview.KeyFieldName = "ExtendCodeID";
            gridview.SettingsBehavior.AllowDragDrop = false;
            gridview.SettingsBehavior.AllowGroup = false;
            gridview.Settings.ShowFilterRow = true;
            gridview.Settings.ShowFilterRowMenu = true;

            GridViewCommandColumn headercol = new GridViewCommandColumn();
            headercol.ShowSelectCheckbox = true;
            headercol.VisibleIndex = 0;
            headercol.ClearFilterButton.Visible = true;
            ITemplate template = headercol.HeaderTemplate;
            ASPxCheckBox checkbox = new ASPxCheckBox();

            GridViewDataTextColumn datacol1 = new GridViewDataTextColumn();
            datacol1.FieldName = "ExtendCodeCode";
            datacol1.VisibleIndex = 1;
            GridViewDataTextColumn datacol2 = new GridViewDataTextColumn();
            datacol2.FieldName = "ExtendCodeName";
            datacol2.VisibleIndex = 2;

            gridview.Columns.Add(headercol);
            gridview.Columns.Add(datacol1);
            gridview.Columns.Add(datacol2);
            panel.Controls.Add(gridview);

            gridview.DataSource = extdlist;
            gridview.DataBind();
            return panel;
        }

        #endregion

        #region Callback异步操作

        //异步获取选中值
        protected void OnCallbackCompleteSC(object sender, CallbackEventArgs e)
        {
            string callback_data = e.Parameter.ToString();
            string[] data = callback_data.Split(',');

            List<DictionaryItem> detailist = _codedetaillist;
            List<DictionaryItem> list = new List<DictionaryItem>();
            for (int i = 0; i < data.Length; i++)
            {
                int index = Int32.Parse(data[i]);
                if (index < detailist.Count)
                {
                    list.Add(detailist[index]);
                }
            }
            // 如果是Nav的时候，要做一个级联选择;其它就不做处理
            if (ModuleField.DisplayFormat == CommonField.Nav.ToString())
            {
                list = GetSubList(list);
            }

            List<ExtendCode> codelist = new List<ExtendCode>();
            //数据压缩
            foreach (DictionaryItem detail in list)
            {
                ExtendCode code = new ExtendCode();
                code.ExtendCodeCode = detail.DictionaryItemCode;
                code.ExtendCodeName = detail.DictionaryItemName;
                codelist.Add(code);
            }

            e.Result = JsonConvert.SerializeObject(codelist);
        }

        //异步刷新弹出框content中的内容
        protected void OnCallbackCompleteAsyn(object sender, CallbackEventArgs e)
        {
            string callback_data = e.Parameter.ToString();
            int len = callback_data.Length + 4;
            List<DictionaryItem> detailist = new List<DictionaryItem>();
            using (TestDBEntities entity = new TestDBEntities())
            {
                detailist = entity.DictionaryItem.Where(pp => pp.DictionaryItemCode.StartsWith(callback_data) && pp.DictionaryItemCode.Length == len).ToList();
            }
            _codedetaillist = detailist;
            Code = callback_data;

            System.Web.UI.Control control = GetDisplayControl(_codedetaillist);
            StringWriter text = new System.IO.StringWriter();
            HtmlTextWriter writer = new HtmlTextWriter(text);
            control.RenderControl(writer);
            e.Result = writer.InnerWriter.ToString();
        }

        protected List<DictionaryItem> GetSubList(List<DictionaryItem> list)
        {
            List<DictionaryItem> _list = list;
            foreach (DictionaryItem detail in list)
            {
            }
            return _list;
        }
        #endregion

        #region TreeList操作

        protected void treeList_DataBound(object sender, EventArgs e)
        {
            SetNodeSelectionSettings((ASPxTreeList)sender);
        }

        protected void SetNodeSelectionSettings(ASPxTreeList treeList)
        {
            TreeListNodeIterator iterator = treeList.CreateNodeIterator();
            TreeListNode node;
            while (true)
            {
                node = iterator.GetNext();
                if (node == null)
                    break;
            }
        }

        protected void treeList_CustomDataCallback(object sender, DevExpress.Web.ASPxTreeList.TreeListCustomDataCallbackEventArgs e)
        {
            ASPxTreeList treeList = (ASPxTreeList)sender;
            List<TreeListNode> nodelist = treeList.GetSelectedNodes();
            //数据压缩
            List<ExtendCode> codelist = new List<ExtendCode>();            
            foreach (TreeListNode node in nodelist)
            {
                ExtendCode detail = (ExtendCode)node.DataItem;
                codelist.Add(detail);
            }            
            e.Result = JsonConvert.SerializeObject(codelist);
        }

        #endregion

    }

    #region 扩展类，主要是获取code和name
    public class ExtendCode
    {
        public string ExtendCodeCode { set; get; }
        public string ExtendCodeName { set; get; }
        public string ExtendCodeValue { set; get; }
        public int ExtendCodeID { set; get; }
        public int ParentID { set; get; }
    }
    #endregion
}