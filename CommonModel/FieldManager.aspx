<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FieldManager.aspx.cs" Inherits="ContentModel1._5.CommonModel.FieldManager" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v11.1, Version=11.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CphNavigation" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CphContent" runat="server">
<script type="text/jscript" src="../Scripts/jquery-1.4.1.js"></script>
<script language="javascript" type="text/javascript">
    $(function () {
        //新建字段
        $("#<%=addFeild.ClientID %>").bind("click", function () {
            var tablename = $("#<%=ModelNameHidden.ClientID %>").val();
            var tablecode = $("#<%=ModelCodeHidden.ClientID %>").val();
            window.location = "Field.aspx?ModelName=" + tablename + "&&ModelCode=" + tablecode;
        });
    });
</script>
    <br />
<br />
<br />
<table>
 <tr>
    <td>
        <input  id="addFeild"  value="新建字段"  type="button" runat="server"/>
    </td>
 </tr>
 <tr>
    <td colspan="2">
        <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" 
            ondatabound="ASPxGridView1_DataBound">
        <Columns>
            <dx:GridViewDataTextColumn Caption="字段名" Name="字段名" VisibleIndex="0" FieldName="Name" >
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="字段别名" Name="字段别名" VisibleIndex="1" FieldName="Nick" >
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="字段提示" Name="字段提示" VisibleIndex="1" FieldName="Tooltip" >
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="字段描述" Name="字段描述" VisibleIndex="1" FieldName="Remark" >
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="错误文本" Name="错误文本" VisibleIndex="1" FieldName="ErrorText" >
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Null文本" Name="Null文本" VisibleIndex="1" FieldName="NullText" >
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="字段宽度" Name="字段宽度" VisibleIndex="1" FieldName="Width" >
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="字段高度" Name="字段高度" VisibleIndex="1" FieldName="Height" >
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="字段最大长度" Name="字段最大长度" VisibleIndex="1" FieldName="MaxLength" >
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="字段分组编码" Name="字段分组编码" VisibleIndex="1" FieldName="GroupCode" >
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="字段分组名称" Name="字段分组名称" VisibleIndex="1" FieldName="GroupName" >
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="字段显示顺序" Name="字段显示顺序" VisibleIndex="1" FieldName="DisplayOrder" >
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="是否必填" Name="是否必填" VisibleIndex="1" FieldName="IsRequired" >
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="是否被搜索" Name="是否被搜索" VisibleIndex="1" FieldName="IsAllowSearch" >
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="是否只读" Name="是否只读" VisibleIndex="1" FieldName="IsReadOnly" >
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="是否可见" Name="是否可见" VisibleIndex="1" FieldName="IsVisible" >
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataButtonEditColumn Caption="操作" >
                <DataItemTemplate>
                   <a href='Field.aspx?EditMode=Edit&&FieldCode=<%# Eval("Code") %>'>修改</a>
                </DataItemTemplate>
            </dx:GridViewDataButtonEditColumn>
        </Columns>
        <SettingsPager PageSize="20"/>
        <Styles>
        <AlternatingRow Enabled="True"/>
        </Styles>
        <SettingsBehavior AllowSort="false" />
    </dx:ASPxGridView>
    </td>
 </tr>
</table>
<asp:HiddenField  runat="server" ID="ModelNameHidden"/>
<asp:HiddenField  runat="server" ID="ModelCodeHidden"/>
</asp:Content>
