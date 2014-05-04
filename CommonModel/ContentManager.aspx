<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ContentManager.aspx.cs" Inherits="ContentModel1._5.CommonModel.ContentManager" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v11.1, Version=11.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CphNavigation" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CphContent" runat="server">
    <script type="text/jscript" src="../Scripts/jquery-1.4.1.js"></script>
<script language="javascript" type="text/javascript">
    $(function () {
        //新建记录
        $("#<%=addRecord.ClientID %>").bind("click", function () {
            var tablename = $("#<%=ModelNameHidden.ClientID %>").val();
            window.location = 'DynamicPage.aspx?ModelName=' + tablename;
        });
    });

</script>
    <br />
<br />
<br />
<table>
 <tr>
    <td>
        <input  id="addRecord"  value="新建记录"  type="button" runat="server"/>
    </td>
 </tr>
 <tr>
    <td colspan="2">
        <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False">
            <Columns>
                <dx:GridViewDataHyperLinkColumn Caption="修改内容">
                    <DataItemTemplate>
                        <a href="DynamicPage.aspx?ModelName=<%# Request.QueryString["ModelName"] %>&&EditMode=Edit&&tableCode=<%# Container.KeyValue %>" title="点击查看详细">修改</a>
                    </DataItemTemplate>
                </dx:GridViewDataHyperLinkColumn>
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
