<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewModel.aspx.cs" Inherits="ContentModel1._5.CommonModel.NewModel" %>

<%@ Register assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <div>
        <table cellpadding="2" cellspacing="1" border="1" width="100%" style="color:Maroon">
            <tr>
                <td>
                    <dx:ASPxLabel ID="TableIDLb" runat="server" Text="表名">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxTextBox ID="TableID" runat="server" Width="170px" ValidationSettings-RequiredField-ErrorText="该字段不能为空！" ValidationSettings-RequiredField-IsRequired="true">
                        <ValidationSettings>
                            <RegularExpression ErrorText="格式不正确！" ValidationExpression="(?!_)(?!.*?_$)[a-zA-Z_]{1}\w{2,19}" />
                        </ValidationSettings>
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <dx:ASPxLabel ID="TableNameLb" runat="server" Text="表含义">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxTextBox ID="TableName" runat="server" Width="170px" ValidationSettings-RequiredField-ErrorText="该字段不能为空！" ValidationSettings-RequiredField-IsRequired="true">
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <dx:ASPxButton ID="Addtable" runat="server" Text="添加" onclick="Addtable_Click">
                    </dx:ASPxButton>
                </td>
            </tr>
        </table>    
    </div>
    </form>
</body>
</html>
