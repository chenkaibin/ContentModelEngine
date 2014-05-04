<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ModelManager.aspx.cs" Inherits="ContentModel1._5.CommonModel.ModelManager" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v11.1, Version=11.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CphNavigation" runat="server">
<script src="../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
<script language="javascript" type="text/javascript">
    $(function () {
        //新建模型
        $("#<%=addModel.ClientID %>").bind("click", function () {
            window.location = 'NewModel.aspx';
        });
    });
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CphContent" runat="server">
<br />
<br />
<br />
<table>
    <tr>
        <td>
            <input  id="addModel"  value="新建模型"  type="button" runat="server"/>
        </td>
    </tr>
    <tr>
        <td>
            <dx:ASPxGridView ID="ASPxGridView2" runat="server">
                <Columns>
                    <dx:GridViewDataColumn Caption="数据表名" FieldName="ModelName">
                    </dx:GridViewDataColumn>
                    <dx:GridViewDataColumn Caption="表含义" FieldName="ModelMeaning">
                    </dx:GridViewDataColumn>
                    <dx:GridViewDataButtonEditColumn Caption="操作" >
                        <DataItemTemplate>
                            <a href='FieldManager.aspx?ModelName=<%# Eval("ModelName") %>'>修改模型</a>
                            <a href='ContentManager.aspx?ModelName=<%# Eval("ModelName") %>'>修改内容</a>
                        </DataItemTemplate>
                    </dx:GridViewDataButtonEditColumn>
                </Columns>
                <SettingsBehavior AllowSort="false" />
            </dx:ASPxGridView>
        </td>
    </tr>
</table>
</asp:Content>
