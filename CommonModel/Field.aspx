﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Field.aspx.cs" Inherits="ContentModel1._5.CommonModel.Field" %>

<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v11.1, Version=11.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v11.1, Version=11.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxUploadControl" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<%@ Register assembly="DevExpress.Web.ASPxSpellChecker.v11.1, Version=11.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxSpellChecker" tagprefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
    <script language="javascript" type="text/javascript">
        function GoBack() {
            var modelName = $("#<%=ModelNameHidden.ClientID %>").val();
            window.location = 'FieldManager.aspx?ModelName=' + modelName;
        }
    </script>
<body>
    <form id="form1" runat="server"> 
        <table cellpadding="2" cellspacing="1" border="1" width="100%" style="color:Maroon">
        <%--添加字段--%>
        <tr>
            <td colspan="2" align="center">
                <dx:ASPxLabel ID="LblTitle" runat="server" Text="添加字段" Font-Bold="true">
                </dx:ASPxLabel>
            </td>
        </tr>
        <%--字段名称--%>
        <tr>
            <td>
                <strong>字段名称：</strong>
            </td>
            <td align="left">
                <dx:ASPxTextBox ID="TxtFieldName" runat="server" Width="200px" MaxLength="20" ValidationSettings-RequiredField-ErrorText="该字段不能为空！" ValidationSettings-RequiredField-IsRequired="true">
                    <ValidationSettings>
                        <RegularExpression ErrorText="格式不正确！" ValidationExpression="(?!_)(?!.*?_$)[a-zA-Z_]{1}\w{2,19}" />
                    </ValidationSettings>
                </dx:ASPxTextBox>
                <span style="color: Blue">注：字段名由字母、数字、下划线组成，6-20位数，并且仅能字母开头，不以下划线结尾。 例如：Content</span>
            </td>
        </tr>
        <%--字段别名--%>
        <tr>
            <td>
                <strong>字段别名：</strong>
            </td>
            <td align="left">
                <dx:ASPxTextBox ID="TxtFieldAliax" runat="server" Width="200px">
                </dx:ASPxTextBox>
                <br />
                <span style="color: blue">例如：文章内容</span>
            </td>
        </tr>
        <%--字段提示--%>
        <tr>
            <td>
                <strong>字段提示：</strong>
            </td>
            <td align="left">
                <dx:ASPxTextBox ID="TxtTips" runat="server" Width="200px">
                </dx:ASPxTextBox>
                <span style="color: blue">对于字段的提示信息</span>
            </td>
        </tr>
        <%--字段描述--%>
        <tr>
            <td>
                <strong>字段描述：</strong>
            </td>
            <td align="left">
                <dx:ASPxMemo ID="TxtDescription" runat="server" Height="100px" Width="200px">
                </dx:ASPxMemo>
                <span style="color: blue">对于字段的详细描述</span>
            </td>
        </tr>
        <%--是否必填--%>
        <tr>
            <td>
                <strong>是否必填：</strong>
            </td>
            <td align="left">
                <dx:ASPxRadioButtonList ID="RadlEnableNull" runat="server" RepeatDirection="Horizontal">
                    <Items>
                        <dx:ListEditItem Value="1" Text="是" />
                        <dx:ListEditItem Value="0" Text="否" Selected="true" />
                    </Items>
                </dx:ASPxRadioButtonList>
            </td>
        </tr>
        <%--是否在搜索表单显示--%>
        <tr>
            <td>
                <strong>是否在搜索表单显示：</strong>
            </td>
            <td align="left">
                <dx:ASPxRadioButtonList ID="RadlEnableShowOnSearchForm" runat="server" RepeatDirection="Horizontal">
                    <Items>
                        <dx:ListEditItem Value="1" Text="是" Selected="true" />
                        <dx:ListEditItem Value="0" Text="否" />
                    </Items>
                </dx:ASPxRadioButtonList>
            </td>
        </tr>
        <%--是否可见--%>
        <tr>
            <td>
                <strong>是否可显示：</strong><br />
                不显示的字段将不会出现在添加页面
            </td>
            <td align="left">
                <dx:ASPxRadioButtonList ID="RadDisabled" runat="server" RepeatDirection="Horizontal">
                    <Items>
                        <dx:ListEditItem Value="1" Text="是" Selected="true" />
                        <dx:ListEditItem Value="0" Text="否" />
                    </Items>
                </dx:ASPxRadioButtonList>
            </td>
        </tr>
        <%--是否只读--%>
        <tr>
            <td>
                <strong>是否只读：</strong><br />
                只读字段将不可编辑
            </td>
            <td align="left">
                <dx:ASPxRadioButtonList ID="IsReadOnly" runat="server" RepeatDirection="Horizontal">
                    <Items>
                        <dx:ListEditItem Value="1" Text="是" />
                        <dx:ListEditItem Value="0" Text="否" Selected="true" />
                    </Items>
                </dx:ASPxRadioButtonList>
            </td>
        </tr>
        <%--字段类型，radiobutton选项--%>
        <tr>
            <td>
                <strong>此字段的类型：</strong>
            </td>
            <td align="left">
                <%--各种字段选项--%>
                <table>
                    <tr>
                        <td colspan="3">
                            <strong>基本字段</strong>
                        </td>
                    </tr><%--基本字段，目前5行--%>
                    <tr>
                        <td>
                            <dx:ASPxRadioButton ID="RadTextType" runat="server" Text="单行文本" AutoPostBack="true" GroupName="RadFieldType" OnCheckedChanged="RadlFieldType_SelectedIndexChanged">
                            </dx:ASPxRadioButton>
                        </td>
                        <td>
                            <dx:ASPxRadioButton ID="RadMultipleTextType" runat="server" Text="多行文本（不支持HTML）" AutoPostBack="true" GroupName="RadFieldType" OnCheckedChanged="RadlFieldType_SelectedIndexChanged">
                            </dx:ASPxRadioButton>
                        </td>
                        <td>
                            <dx:ASPxRadioButton ID="RadMultipleHtmlTextType" runat="server" Text="多行文本（支持HTML）" AutoPostBack="true" GroupName="RadFieldType" OnCheckedChanged="RadlFieldType_SelectedIndexChanged">
                            </dx:ASPxRadioButton>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <dx:ASPxRadioButton ID="PnlRadioType" runat="server" Text="选项" AutoPostBack="true" GroupName="RadFieldType" OnCheckedChanged="RadlFieldType_SelectedIndexChanged">
                            </dx:ASPxRadioButton>
                        </td>
                        <td>
                            <dx:ASPxRadioButton ID="RadNumberType" runat="server" Text="数字" AutoPostBack="true" GroupName="RadFieldType" OnCheckedChanged="RadlFieldType_SelectedIndexChanged">
                            </dx:ASPxRadioButton>
                        </td>
                        <td>
                            <dx:ASPxRadioButton ID="RadMoneyType" runat="server" Text="货币" AutoPostBack="true" GroupName="RadFieldType" OnCheckedChanged="RadlFieldType_SelectedIndexChanged">
                            </dx:ASPxRadioButton>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <dx:ASPxRadioButton ID="RadDateType" runat="server" Text="日期" AutoPostBack="true" GroupName="RadFieldType" OnCheckedChanged="RadlFieldType_SelectedIndexChanged">
                            </dx:ASPxRadioButton>
                        </td>
                        <td>
                            <dx:ASPxRadioButton ID="RadTimeType" runat="server" Text="时间" AutoPostBack="true" GroupName="RadFieldType" OnCheckedChanged="RadlFieldType_SelectedIndexChanged">
                            </dx:ASPxRadioButton>
                        </td>
                        <td>
                            <dx:ASPxRadioButton ID="RadHyperLinkType" runat="server" Text="超链接" AutoPostBack="true" GroupName="RadFieldType" OnCheckedChanged="RadlFieldType_SelectedIndexChanged">
                            </dx:ASPxRadioButton>                            
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <dx:ASPxRadioButton ID="RadMobilephoneType" runat="server" Text="移动电话号码" AutoPostBack="true" GroupName="RadFieldType" OnCheckedChanged="RadlFieldType_SelectedIndexChanged">
                            </dx:ASPxRadioButton>
                        </td>
                        <td>
                            <dx:ASPxRadioButton ID="RadTelephoneType" runat="server" Text="固定电话号码" AutoPostBack="true" GroupName="RadFieldType" OnCheckedChanged="RadlFieldType_SelectedIndexChanged">
                            </dx:ASPxRadioButton>                            
                        </td>
                        <td>
                            <dx:ASPxRadioButton ID="RadColorType" runat="server" Text="颜色代码" AutoPostBack="true" GroupName="RadFieldType" OnCheckedChanged="RadlFieldType_SelectedIndexChanged">
                            </dx:ASPxRadioButton>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <dx:ASPxRadioButton ID="RadUserTextType" runat="server" Text="自定义文本" AutoPostBack="true" GroupName="RadFieldType" OnCheckedChanged="RadlFieldType_SelectedIndexChanged">
                            </dx:ASPxRadioButton>
                        </td>
                        <td>
                            <dx:ASPxRadioButton ID="RadTableField" runat="server" Text="表字段" AutoPostBack="true" GroupName="RadFieldType" OnCheckedChanged="RadlFieldType_SelectedIndexChanged">
                            </dx:ASPxRadioButton>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <strong>系统预定义字段</strong>
                        </td>
                    </tr><%--系统复杂预定义字段，目前5行,其中一行为空，以后需要再添加--%>
                    <tr>
                        <td>
                            <dx:ASPxRadioButton ID="RadPictureType" runat="server" Text="图片" AutoPostBack="true" GroupName="RadFieldType" OnCheckedChanged="RadlFieldType_SelectedIndexChanged">
                            </dx:ASPxRadioButton>
                        </td>
                        <td>
                            <dx:ASPxRadioButton ID="RadMultiPictureType" runat="server" Text="多图片" AutoPostBack="true" GroupName="RadFieldType" OnCheckedChanged="RadlFieldType_SelectedIndexChanged">
                            </dx:ASPxRadioButton>
                        </td>
                        <td>
                            <dx:ASPxRadioButton ID="RadFileType" runat="server" Text="文件" AutoPostBack="true" GroupName="RadFieldType" OnCheckedChanged="RadlFieldType_SelectedIndexChanged">
                            </dx:ASPxRadioButton>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <dx:ASPxRadioButton ID="RadMultiFileType" runat="server" Text="多文件" AutoPostBack="true" GroupName="RadFieldType" OnCheckedChanged="RadlFieldType_SelectedIndexChanged">
                            </dx:ASPxRadioButton>
                        </td>
                        <td>
                            <dx:ASPxRadioButton ID="RadRegionType" runat="server" Text="行政区划" AutoPostBack="true" GroupName="RadFieldType" OnCheckedChanged="RadlFieldType_SelectedIndexChanged">
                            </dx:ASPxRadioButton>
                        </td>
                        <td>
                            <dx:ASPxRadioButton ID="RadWordsType" runat="server" Text="词条" AutoPostBack="true" GroupName="RadFieldType" OnCheckedChanged="RadlFieldType_SelectedIndexChanged">
                            </dx:ASPxRadioButton>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <dx:ASPxRadioButton ID="RadCaptchaType" runat="server" Text="验证码" AutoPostBack="true" GroupName="RadFieldType" OnCheckedChanged="RadlFieldType_SelectedIndexChanged">
                            </dx:ASPxRadioButton>
                        </td>
                        <td>
                            <dx:ASPxRadioButton ID="RadSelectUserType" runat="server" Text="选择用户" AutoPostBack="true" GroupName="RadFieldType" OnCheckedChanged="RadlFieldType_SelectedIndexChanged">
                            </dx:ASPxRadioButton>
                        </td>
                        <td>
                            <dx:ASPxRadioButton ID="RadSelectRegionType" runat="server" Text="选择机构" AutoPostBack="true" GroupName="RadFieldType" OnCheckedChanged="RadlFieldType_SelectedIndexChanged">
                            </dx:ASPxRadioButton>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <dx:ASPxRadioButton ID="RadSelectRoleType" runat="server" Text="选择角色" AutoPostBack="true" GroupName="RadFieldType" OnCheckedChanged="RadlFieldType_SelectedIndexChanged">
                            </dx:ASPxRadioButton>
                        </td>
                        <td>
                            <dx:ASPxRadioButton ID="RadSelectCodeType" runat="server" Text="选择代码" AutoPostBack="true" GroupName="RadFieldType" OnCheckedChanged="RadlFieldType_SelectedIndexChanged">
                            </dx:ASPxRadioButton>
                        </td>
                        <td>
                            <dx:ASPxRadioButton ID="RadVoteCtrlType" runat="server" Text="评分控件" AutoPostBack="true" GroupName="RadFieldType" OnCheckedChanged="RadlFieldType_SelectedIndexChanged">
                            </dx:ASPxRadioButton>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <%--单行文本--%>
        <tbody id="PnlText" visible="false" runat="server">
            <tr>
                <td>
                    <strong>控件宽度：</strong>
                </td>
                <td align="left">
                    <dx:ASPxSpinEdit ID="PnlTextWidth" runat="server" Width="200px" Number="200" ValidationSettings-RequiredField-IsRequired="true" ValidationSettings-RequiredField-ErrorText="宽度不能为空！" DisplayFormatString="#px" MinValue="0" MaxValue="1000">
                    </dx:ASPxSpinEdit>
                    <span style="color: Blue">单位：px &nbsp;例如：200px，范围0-1000</span>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>控件高度：</strong>
                </td>
                <td align="left">
                    <dx:ASPxSpinEdit ID="PnlTextHeight" runat="server" Width="200px" Number="21" ValidationSettings-RequiredField-IsRequired="true" ValidationSettings-RequiredField-ErrorText="高度不能为空！" DisplayFormatString="#px" MinValue="0" MaxValue="1000">
                    </dx:ASPxSpinEdit>
                    <span style="color: Blue">单位：px &nbsp;例如：21px，范围0-1000</span>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>最大输入长度：</strong>
                </td>
                <td align="left">
                    <dx:ASPxSpinEdit ID="TxtTextMaxLength" runat="server" Width="200px" Number="20" ValidationSettings-RequiredField-IsRequired="true" ValidationSettings-RequiredField-ErrorText="请输入最大允许长度！" MinValue="0" MaxValue="100">
                    </dx:ASPxSpinEdit>                    
                    <span style="color: Blue">单位：个&nbsp;例如：20，范围0-100</span>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>为必填项时出错提示：</strong>
                </td>
                <td align="left">
                    <dx:ASPxTextBox  ID="PnlTextErrorText" runat="server" Width="200px"></dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>无输入内容时显示文本（灰色显示）：</strong>
                </td>
                <td align="left">
                     <dx:ASPxTextBox  ID="PnlTextNullText" runat="server" Width="200px"></dx:ASPxTextBox> 
                </td>
            </tr>
            <tr>
                <td>
                    <strong>默认值：</strong>
                </td>
                <td align="left">
                    <dx:ASPxTextBox  ID="TxtTextDefaultValue" runat="server"  Width="200px"></dx:ASPxTextBox>
                </td>
            </tr>
        </tbody>
        <%--多行文本（不支持HTML）--%>
        <tbody id="PnlMultiText" visible="false" runat="server">
            <tr>
                <td>
                    <strong>控件宽度：</strong>
                </td>
                <td align="left">
                    <dx:ASPxSpinEdit ID="TxtMultiTextWidth" runat="server" Width="200px" Number="200" ValidationSettings-RequiredField-IsRequired="true" ValidationSettings-RequiredField-ErrorText="宽度不能为空！" DisplayFormatString="#px" MinValue="0" MaxValue="1000">
                    </dx:ASPxSpinEdit>
                    <span style="color: Blue">px &nbsp;例如：200px</span>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>控件高度：</strong>
                </td>
                <td align="left">
                    <dx:ASPxSpinEdit ID="TxtMultiTextHeight" runat="server" Width="200px" Number="100" ValidationSettings-RequiredField-IsRequired="true" ValidationSettings-RequiredField-ErrorText="高度不能为空！" DisplayFormatString="#px" MinValue="0" MaxValue="1000">
                    </dx:ASPxSpinEdit>
                    <span style="color: Blue">px &nbsp;例如：100px</span>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>为必填项时出错提示：</strong>
                </td>
                <td align="left">
                 <dx:ASPxTextBox  ID="PnlMultiTextErrorText" runat="server" Width="200px" ></dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>无输入内容时显示文本（灰色显示）：</strong>
                </td>
                <td align="left">
                 <dx:ASPxTextBox  ID="PnlMultiTextNullText" runat="server" Width="200px" ></dx:ASPxTextBox> 
                </td>
            </tr>
            <tr>
                <td>
                    <strong>默认值：</strong>
                </td>
                <td align="left">
                    <dx:ASPxMemo  ID="TxtMultiDefault" Height="100px" runat="server"  Width="200px" ></dx:ASPxMemo>
                </td>
            </tr>
        </tbody>
        <%--多行文本（支持HTML）--%>
        <tbody id="PnlEditor" visible="false" runat="server">
            <tr>
                <td>
                    <strong>编辑器窗口大小：</strong>
                </td>
                <td align="left">
                    控件宽
                    <dx:ASPxSpinEdit  ID="TxtEditorWidth" Number="500" runat="server" Width="200" ValidationSettings-RequiredField-IsRequired="true" ValidationSettings-RequiredField-ErrorText="宽度不能为空！" DisplayFormatString="#px" MinValue="0" MaxValue="1000"></dx:ASPxSpinEdit>
                    <span style="color: Blue">px&nbsp;例如：500px</span>
                    <br />
                    控件高
                    <dx:ASPxSpinEdit  ID="TxtEditorHight" Number="300" runat="server" Width="200" ValidationSettings-RequiredField-IsRequired="true" ValidationSettings-RequiredField-ErrorText="宽度不能为空！" DisplayFormatString="#px" MinValue="0" MaxValue="1000"></dx:ASPxSpinEdit>
                    <span style="color: Blue">px&nbsp;例如：300px</span>
                    <br />
                </td>
            </tr>
            <tr>
                <td>
                    <strong>为必填项时出错提示：</strong>
                </td>
                <td align="left">
                 <dx:ASPxTextBox  ID="PnlEditorErrorText" runat="server" Width="200" ></dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>默认值：</strong>
                </td>
                <td align="left">
                    <dx:ASPxHtmlEditor ID="PnlEditorDefault" runat="server" Height="300" Width="500">
                    </dx:ASPxHtmlEditor>
                </td>
            </tr>
        </tbody>
        <%--选项--%>
        <tbody id="PnlRadio" visible="false" runat="server">
            <tr>
                <td>
                    <strong>选项模式：</strong>
                </td>
                <td align="left">
                    <dx:ASPxRadioButtonList ID="RadlChoiceType" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="RadlChoiceType_SelectedIndexChanged" AutoPostBack="true" ValidationSettings-RequiredField-IsRequired="true" ValidationSettings-RequiredField-ErrorText="选项显示方式必填！">
                        <Items>
                            <dx:ListEditItem Text="单选下拉列表框" Value="1" />
                            <dx:ListEditItem Text="多选下拉列表框" Value="2" />
                            <dx:ListEditItem Text="单选按钮控件" Value="3" />
                            <dx:ListEditItem Text="复选按钮控件" Value="4" />
                        </Items>
                    </dx:ASPxRadioButtonList>
                </td>
            </tr>
            <tr id="PnlRadioWidthTd" runat="server">
                <td>
                    <strong>列表框控件宽度：</strong>
                </td>
                <td align="left">
                    <dx:ASPxSpinEdit ID="PnlRadioWidth" runat="server" Width="200px" Number="200" ValidationSettings-RequiredField-IsRequired="true" ValidationSettings-RequiredField-ErrorText="宽度不能为空！" DisplayFormatString="#px" MinValue="0" MaxValue="1000">
                    </dx:ASPxSpinEdit>
                    <span style="color: Blue">单位：px &nbsp;例如：200px，范围0-1000</span>
                </td>
            </tr>
            <tr id="PnlRadioHeightTd" runat="server">
                <td>
                    <strong>列表框控件高度：</strong>
                </td>
                <td align="left">
                    <dx:ASPxSpinEdit ID="PnlRadioHeight" runat="server" Width="200px" Number="21" ValidationSettings-RequiredField-IsRequired="true" ValidationSettings-RequiredField-ErrorText="高度不能为空！" DisplayFormatString="#px" MinValue="0" MaxValue="1000">
                    </dx:ASPxSpinEdit>
                    <span style="color: Blue">单位：px &nbsp;例如：21px，范围0-1000</span>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>所用的代码分类：</strong>
                </td>
                <td align="left">
                    <dx:ASPxComboBox ID="RadlChoiceCode" runat="server" Width="170px" DropDownWidth="550" DropDownStyle="DropDownList" 
                    ValueType="System.String" TextFormatString="{0}" ValueField="DictionaryID" IncrementalFilteringMode="Contains" 
                    CallbackPageSize="30" ValidationSettings-RequiredField-IsRequired="true" ValidationSettings-RequiredField-ErrorText="代码分类必填！">
                    <Columns>
                        <dx:ListBoxColumn FieldName="DictionaryCode" Width="30px" />
                        <dx:ListBoxColumn FieldName="DictionaryValue" Width="80px" />
                        <dx:ListBoxColumn FieldName="DictionaryName" Width="50px" />  
                    </Columns>
                </dx:ASPxComboBox>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>为必填项时出错提示：</strong>
                </td>
                <td align="left">
                 <dx:ASPxTextBox  ID="PnlRadioErrorTip" runat="server" Width="200" ></dx:ASPxTextBox>
                </td>
            </tr>
        </tbody>
        <%--数字--%>
        <tbody id="PnlNumber" visible="false" runat="server">
            <tr>
                <td>
                    <strong>控件宽度：</strong>
                </td>
                <td align="left">
                    <dx:ASPxSpinEdit ID="PnlNumberWidth" runat="server" Width="200px" Number="200" ValidationSettings-RequiredField-IsRequired="true" ValidationSettings-RequiredField-ErrorText="宽度不能为空！" DisplayFormatString="#px" MinValue="0" MaxValue="1000">
                    </dx:ASPxSpinEdit>
                    <span style="color: Blue">单位：px &nbsp;例如：200px，范围0-1000</span>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>控件高度：</strong>
                </td>
                <td align="left">
                    <dx:ASPxSpinEdit ID="PnlNumberHeight" runat="server" Width="200px" Number="21" ValidationSettings-RequiredField-IsRequired="true" ValidationSettings-RequiredField-ErrorText="高度不能为空！" DisplayFormatString="#px" MinValue="0" MaxValue="1000">
                    </dx:ASPxSpinEdit>
                    <span style="color: Blue">单位：px &nbsp;例如：21px，范围0-1000</span>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>最大输入长度：</strong>
                </td>
                <td align="left">
                    <dx:ASPxSpinEdit ID="PnlNumberMaxLength" runat="server" Width="200px" Number="10" ValidationSettings-RequiredField-IsRequired="true" ValidationSettings-RequiredField-ErrorText="请输入最大允许长度！" MinValue="0" MaxValue="100">
                    </dx:ASPxSpinEdit>                    
                    <span style="color: Blue">单位：个&nbsp;例如：10，范围0-100</span>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>最小值：</strong>
                </td>
                <td align="left">
                    <dx:ASPxSpinEdit  ID="TxtNumberMinValue" runat="server" Width="200" MinValue="0" MaxValue="1000" ValidationSettings-RequiredField-IsRequired="true" ValidationSettings-RequiredField-ErrorText="请输入最小值！">
                    </dx:ASPxSpinEdit>
                    <span style="color: Blue">数字可输入的最小值</span>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>最大值：</strong>
                </td>
                <td align="left">
                    <dx:ASPxSpinEdit  ID="TxtNumberMaxValue" runat="server" Width="200" MinValue="0" MaxValue="1000" ValidationSettings-RequiredField-IsRequired="true" ValidationSettings-RequiredField-ErrorText="请输入最大值！">
                    </dx:ASPxSpinEdit>
                    <span style="color: Blue">数字可输入的最大值，不能小于最小值</span>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>显示格式：</strong>
                </td>
                <td align="left">
                    <dx:ASPxComboBox ID="TxtNumberDisplayFormat" runat="server" Width="170px" DropDownWidth="500" DropDownStyle="DropDownList" 
                    ValueType="System.String" TextFormatString="{0}" ValueField="DictionaryItemID" IncrementalFilteringMode="Contains" 
                    CallbackPageSize="30" ValidationSettings-RequiredField-IsRequired="true" ValidationSettings-RequiredField-ErrorText="数字格式必填！">
                        <Columns>
                            <dx:ListBoxColumn FieldName="DictionaryItemValue" Width="80px" />
                            <dx:ListBoxColumn FieldName="DictionaryItemName" Width="80px" /> 
                            <dx:ListBoxColumn FieldName="DictionaryItemCode" Width="50px" />      
                        </Columns>
                    </dx:ASPxComboBox>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>为必填项时出错提示：</strong>
                </td>
                <td align="left">
                    <dx:ASPxTextBox  ID="PnlNumberErrorText" runat="server"  width="200">
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>输入框无内容显示文本：</strong>
                </td>
                <td align="left">
                 <dx:ASPxTextBox  ID="PnlNumberNullText" runat="server"  Width="200" ></dx:ASPxTextBox> 
                </td>
            </tr>
            <tr>
                <td>
                    <strong>默认值：</strong>
                </td>
                <td align="left">
                    <dx:ASPxSpinEdit  ID="TxtNumberDefaultValue" runat="server"  Width="200"></dx:ASPxSpinEdit>
                </td>
            </tr>
        </tbody>
        <%--货币--%>
        <tbody id="PnlCurrency" visible="false" runat="server">
            <tr>
                <td>
                    <strong>控件宽度：</strong>
                </td>
                <td align="left">
                    <dx:ASPxSpinEdit ID="PnlCurrencyWidth" runat="server" Width="200px" Number="200" ValidationSettings-RequiredField-IsRequired="true" ValidationSettings-RequiredField-ErrorText="宽度不能为空！" DisplayFormatString="#px" MinValue="0" MaxValue="1000">
                    </dx:ASPxSpinEdit>
                    <span style="color: Blue">单位 px &nbsp;例如：200px 范围 0-1000</span>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>控件高度：</strong>
                </td>
                <td align="left">
                <dx:ASPxSpinEdit  ID="PnlCurrencyHeight" Number="21" runat="server" width="200" ValidationSettings-RequiredField-IsRequired="true" ValidationSettings-RequiredField-ErrorText="高度不能为空！" DisplayFormatString="#px" MinValue="0" MaxValue="1000" >
                </dx:ASPxSpinEdit>
                <span style="color: Blue">单位 px &nbsp;例如：21px 范围 0-1000</span>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>最大输入长度：</strong>
                </td>
                <td align="left">
                    <dx:ASPxSpinEdit  ID="PnlCurrencyMaxLength" Number="10" runat="server"  width="200" ValidationSettings-RequiredField-IsRequired="true" ValidationSettings-RequiredField-ErrorText="最大长度不能为空！" MinValue="0" MaxValue="100">
                    </dx:ASPxSpinEdit>
                    <span style="color: Blue">单位 个&nbsp;例如：10 范围0-100</span>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>最小值：</strong>
                </td>
                <td align="left">
                    <dx:ASPxSpinEdit  ID="TxtCurrencyMin" runat="server" width="200" MinValue="0" MaxValue="1000" ValidationSettings-RequiredField-IsRequired="true" ValidationSettings-RequiredField-ErrorText="请输入最小值！">
                    </dx:ASPxSpinEdit>
                    <span style="color: Blue">货币可输入的最小值</span>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>最大值：</strong>
                </td>
                <td align="left">
                    <dx:ASPxSpinEdit  ID="TxtCurrencyMax" runat="server" width="200" MinValue="0" MaxValue="1000" ValidationSettings-RequiredField-IsRequired="true" ValidationSettings-RequiredField-ErrorText="请输入最大值！">
                    </dx:ASPxSpinEdit>
                    <span style="color: Blue">货币可输入的最大值，不能小于最小值</span>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>显示格式：</strong>
                </td>
                <td align="left">
                    <dx:ASPxComboBox ID="PnlCurrencyDisplayFormat" runat="server" Width="170px" DropDownWidth="500" DropDownStyle="DropDownList" 
                    ValueType="System.String" TextFormatString="{0}" ValueField="DictionaryItemID" IncrementalFilteringMode="Contains" 
                    CallbackPageSize="30" ValidationSettings-RequiredField-IsRequired="true" ValidationSettings-RequiredField-ErrorText="货币格式必填！">
                        <Columns>
                            <dx:ListBoxColumn FieldName="DictionaryItemValue" Width="80px" />
                            <dx:ListBoxColumn FieldName="DictionaryItemName" Width="80px" /> 
                            <dx:ListBoxColumn FieldName="DictionaryItemCode" Width="50px" />      
                        </Columns>
                    </dx:ASPxComboBox>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>为必填项时出错提示：</strong>
                </td>
                <td align="left">
                 <dx:ASPxTextBox  ID="PnlCurrencyErrorText" runat="server"  width="200" ></dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>输入框无内容显示文本：</strong>
                </td>
                <td align="left">
                 <dx:ASPxTextBox  ID="PnlCurrencyNullText" runat="server"  width="200" ></dx:ASPxTextBox> 
                </td>
            </tr>
            <tr>
                <td>
                    <strong>默认值：</strong>
                </td>
                <td align="left">
                    <dx:ASPxSpinEdit  ID="TxtCurrencyDefaultValue" runat="server" width="200"></dx:ASPxSpinEdit>
                </td>
            </tr>
        </tbody>
        <%--日期--%>
        <tbody id="PnlDate" visible="false" runat="server">
            <tr>
                <td>
                    <strong>控件宽度：</strong>
                </td>
                <td align="left">
                    <dx:ASPxSpinEdit ID="PnlDateWidth" runat="server" Width="200px" Number="200" ValidationSettings-RequiredField-IsRequired="true" ValidationSettings-RequiredField-ErrorText="宽度不能为空！" DisplayFormatString="#px" MinValue="0" MaxValue="1000">
                    </dx:ASPxSpinEdit>
                    <span style="color: Blue">单位 px &nbsp;例如：200px 范围 0-1000</span>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>控件高度：</strong>
                </td>
                <td align="left">
                <dx:ASPxSpinEdit  ID="PnlDateHeight" Number="21" runat="server" width="200" ValidationSettings-RequiredField-IsRequired="true" ValidationSettings-RequiredField-ErrorText="高度不能为空！" DisplayFormatString="#px" MinValue="0" MaxValue="1000" >
                </dx:ASPxSpinEdit>
                <span style="color: Blue">单位 px &nbsp;例如：21px 范围 0-1000</span>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>日期显示格式：</strong>
                </td>
                <td align="left">
                    <dx:ASPxComboBox ID="PnlDateDisplayFormat" runat="server" Width="170px" DropDownWidth="500" DropDownStyle="DropDownList" 
                    ValueType="System.String" TextFormatString="{0}" ValueField="DictionaryItemID" IncrementalFilteringMode="Contains" 
                    CallbackPageSize="30" ValidationSettings-RequiredField-IsRequired="true" ValidationSettings-RequiredField-ErrorText="日期显示格式必填！" 
                    OnTextChanged="DateDisplayFormatChanged" AutoPostBack="true">
                        <Columns>
                            <dx:ListBoxColumn FieldName="DictionaryItemValue" Width="80px" />
                            <dx:ListBoxColumn FieldName="DictionaryItemName" Width="80px" /> 
                            <dx:ListBoxColumn FieldName="DictionaryItemCode" Width="50px" />      
                        </Columns>
                    </dx:ASPxComboBox>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>为必填项时出错提示：</strong>
                </td>
                <td align="left">
                    <dx:ASPxTextBox  ID="PnlDateErrorText" runat="server" width="200">
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>输入框无内容显示文本：</strong>
                </td>
                <td align="left">
                    <dx:ASPxTextBox  ID="PnlDateNullText" runat="server" width="200">
                    </dx:ASPxTextBox> 
                </td>
            </tr>
            <tr>
                <td>
                    <strong>默认值：</strong>
                </td>
                <td align="left">
                    <dx:ASPxDateEdit ID="RadlDateDefaultType" runat="server">
                    </dx:ASPxDateEdit>
                </td>
            </tr>
        </tbody>
        <%--时间--%>
        <tbody id="PnlTime" visible="false" runat="server">
            <tr>
                <td>
                    <strong>控件宽度：</strong>
                </td>
                <td align="left">
                    <dx:ASPxSpinEdit ID="PnlTimeWidth" runat="server" Width="200px" Number="200" ValidationSettings-RequiredField-IsRequired="true" ValidationSettings-RequiredField-ErrorText="宽度不能为空！" DisplayFormatString="#px" MinValue="0" MaxValue="1000">
                    </dx:ASPxSpinEdit>
                    <span style="color: Blue">单位 px &nbsp;例如：200px 范围 0-1000</span>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>控件高度：</strong>
                </td>
                <td align="left">
                <dx:ASPxSpinEdit  ID="PnlTimeHeight" Number="21" runat="server" width="200" ValidationSettings-RequiredField-IsRequired="true" ValidationSettings-RequiredField-ErrorText="高度不能为空！" DisplayFormatString="#px" MinValue="0" MaxValue="1000" >
                </dx:ASPxSpinEdit>
                <span style="color: Blue">单位 px &nbsp;例如：21px 范围 0-1000</span>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>时间显示格式：</strong>
                </td>
                <td align="left">
                    <dx:ASPxComboBox ID="PnlTimeDisplayFormat" runat="server" Width="170px" DropDownWidth="500" DropDownStyle="DropDownList" 
                    ValueType="System.String" TextFormatString="{0}" ValueField="DictionaryItemID" IncrementalFilteringMode="Contains" 
                    CallbackPageSize="30" ValidationSettings-RequiredField-IsRequired="true" ValidationSettings-RequiredField-ErrorText="时间显示格式必填！" 
                    OnTextChanged="TimeDisplayFormatChanged" AutoPostBack="true">
                        <Columns>
                            <dx:ListBoxColumn FieldName="DictionaryItemValue" Width="80px" />
                            <dx:ListBoxColumn FieldName="DictionaryItemName" Width="80px" /> 
                            <dx:ListBoxColumn FieldName="DictionaryItemCode" Width="50px" />      
                        </Columns>
                    </dx:ASPxComboBox>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>为必填项时出错提示：</strong>
                </td>
                <td align="left">
                    <dx:ASPxTextBox  ID="PnlTimeErrorText" runat="server" width="200" >
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>默认值：</strong>
                </td>
                <td align="left">
                    <dx:ASPxTimeEdit ID="RadlTimeDefaultType" runat="server">
                    </dx:ASPxTimeEdit>
                </td>
            </tr>
        </tbody>
        <%--超链接--%>
        <tbody id="PnlURL" visible="false" runat="server">
            <tr>
                <td>
                    <strong>控件宽度：</strong>
                </td>
                <td align="left">
                    <dx:ASPxSpinEdit ID="PnlURLWidth" runat="server" Width="200px" Number="200" ValidationSettings-RequiredField-IsRequired="true" ValidationSettings-RequiredField-ErrorText="宽度不能为空！" DisplayFormatString="#px" MinValue="0" MaxValue="1000">
                    </dx:ASPxSpinEdit>
                    <span style="color: Blue">单位：px &nbsp;例如：200px，范围0-1000</span>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>控件高度：</strong>
                </td>
                <td align="left">
                    <dx:ASPxSpinEdit ID="PnlURLHeight" runat="server" Width="200px" Number="21" ValidationSettings-RequiredField-IsRequired="true" ValidationSettings-RequiredField-ErrorText="高度不能为空！" DisplayFormatString="#px" MinValue="0" MaxValue="1000">
                    </dx:ASPxSpinEdit>
                    <span style="color: Blue">单位：px &nbsp;例如：21px，范围0-1000</span>
                </td>
            </tr>
        </tbody>
        <%--移动电话--%>
        <tbody id="PnlPhoneMobile" visible="false" runat="server">
            <tr>
                <td>
                    <strong>控件宽度：</strong>
                </td>
                <td align="left">
                    <dx:ASPxSpinEdit ID="PnlPhoneMobileWidth" runat="server" Width="200px" Number="200" ValidationSettings-RequiredField-IsRequired="true" ValidationSettings-RequiredField-ErrorText="宽度不能为空！" DisplayFormatString="#px" MinValue="0" MaxValue="1000">
                    </dx:ASPxSpinEdit>
                    <span style="color: Blue">单位：px &nbsp;例如：200px，范围0-1000</span>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>控件高度：</strong>
                </td>
                <td align="left">
                    <dx:ASPxSpinEdit ID="PnlPhoneMobileHeight" runat="server" Width="200px" Number="21" ValidationSettings-RequiredField-IsRequired="true" ValidationSettings-RequiredField-ErrorText="高度不能为空！" DisplayFormatString="#px" MinValue="0" MaxValue="1000">
                    </dx:ASPxSpinEdit>
                    <span style="color: Blue">单位：px &nbsp;例如：21px，范围0-1000</span>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>为必填项时出错提示：</strong>
                </td>
                <td align="left">
                    <dx:ASPxTextBox  ID="PnlPhoneMobileErrorText" runat="server" Width="200px">
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>默认值：</strong>
                </td>
                <td align="left">
                    <dx:ASPxTextBox  ID="PnlPhoneMobileDefaultText" runat="server"  Width="200px" MaskSettings-Mask="(999)9999-9999" MaskSettings-IncludeLiterals="None">
                    </dx:ASPxTextBox>
                    <span style="color: Blue">例如：(138)8888-8888</span>
                </td>
            </tr>
        </tbody>
        <%--固定电话--%>
        <tbody id="PnlPhoneFixed" visible="false" runat="server">
            <tr>
                <td>
                    <strong>控件宽度：</strong>
                </td>
                <td align="left">
                    <dx:ASPxSpinEdit ID="PnlPhoneFixedWidth" runat="server" Width="200px" Number="200" ValidationSettings-RequiredField-IsRequired="true" ValidationSettings-RequiredField-ErrorText="宽度不能为空！" DisplayFormatString="#px" MinValue="0" MaxValue="1000">
                    </dx:ASPxSpinEdit>
                    <span style="color: Blue">单位：px &nbsp;例如：200px，范围0-1000</span>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>控件高度：</strong>
                </td>
                <td align="left">
                    <dx:ASPxSpinEdit ID="PnlPhoneFixedHeight" runat="server" Width="200px" Number="21" ValidationSettings-RequiredField-IsRequired="true" ValidationSettings-RequiredField-ErrorText="高度不能为空！" DisplayFormatString="#px" MinValue="0" MaxValue="1000">
                    </dx:ASPxSpinEdit>
                    <span style="color: Blue">单位：px &nbsp;例如：21px，范围0-1000</span>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>为必填项时出错提示：</strong>
                </td>
                <td align="left">
                    <dx:ASPxTextBox  ID="PnlPhoneFixedErrorText" runat="server" Width="200px"></dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>默认值：</strong>
                </td>
                <td align="left">
                    <dx:ASPxTextBox  ID="PnlPhoneFixedDefault" runat="server"  Width="200px" MaskSettings-Mask="(9999)-99999999" MaskSettings-IncludeLiterals="None">
                    </dx:ASPxTextBox>                
                    <span style="color: Blue">例如：(0000)-00000000或( 000)-00000000，即(区号)-号码</span>
                </td>
            </tr>
        </tbody>
        <%--颜色--%>
        <tbody id="PnlColor" visible="false" runat="server">            
            <tr>
                <td>
                    <strong>宽度：</strong>
                </td>
                <td align="left">
                    <dx:ASPxSpinEdit ID="PnlColorWidth" runat="server" Width="200px" Number="200" ValidationSettings-RequiredField-IsRequired="true" ValidationSettings-RequiredField-ErrorText="宽度不能为空！" DisplayFormatString="#px" MinValue="0" MaxValue="1000">
                    </dx:ASPxSpinEdit>
                    <span style="color: Blue">单位：px &nbsp;例如：200px，范围0-1000</span>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>高度：</strong>
                </td>
                <td align="left">
                    <dx:ASPxSpinEdit ID="PnlColorHeight" runat="server" Width="200px" Number="21" ValidationSettings-RequiredField-IsRequired="true" ValidationSettings-RequiredField-ErrorText="高度不能为空！" DisplayFormatString="#px" MinValue="0" MaxValue="1000">
                    </dx:ASPxSpinEdit>
                    <span style="color: Blue">单位：px &nbsp;例如：21px，范围0-1000</span>
                </td>
            </tr>    
            
            <tr>
                <td>
                    <strong>为必填项时出错提示：</strong>
                </td>
                <td align="left">
                    <dx:ASPxTextBox  ID="PnlColorErrorText" runat="server"  width="200">
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>输入框无内容显示文本：</strong>
                </td>
                <td align="left">
                 <dx:ASPxTextBox  ID="PnlColorNullText" runat="server"  Width="200" ></dx:ASPxTextBox> 
                </td>
            </tr>
            <tr>
                <td>
                    <strong>默认值：</strong>
                </td>
                <td align="left">
                    <dx:ASPxColorEdit ID="PnlColorDefaultValue" runat="server"  Width="200"></dx:ASPxColorEdit>
                </td>
            </tr>
        </tbody>      
        <%--自定义文本--%>
        <tbody id="PnlCustomized" visible="false" runat="server">
            
            <tr>
                <td>
                    <strong>宽度：</strong>
                </td>
                <td align="left">
                    <dx:ASPxSpinEdit ID="PnlCustomizedWidth" runat="server" Width="200px" Number="200" ValidationSettings-RequiredField-IsRequired="true" ValidationSettings-RequiredField-ErrorText="宽度不能为空！" DisplayFormatString="#px" MinValue="0" MaxValue="1000">
                    </dx:ASPxSpinEdit>
                    <span style="color: Blue">单位：px &nbsp;例如：200px，范围0-1000</span>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>高度：</strong>
                </td>
                <td align="left">
                    <dx:ASPxSpinEdit ID="PnlCustomizedHeight" runat="server" Width="200px" Number="21" ValidationSettings-RequiredField-IsRequired="true" ValidationSettings-RequiredField-ErrorText="高度不能为空！" DisplayFormatString="#px" MinValue="0" MaxValue="1000">
                    </dx:ASPxSpinEdit>
                    <span style="color: Blue">单位：px &nbsp;例如：21px，范围0-1000</span>
                </td>
            </tr>    
            
            <tr>
                <td>
                    <strong>显示格式：</strong>
                </td>
                <td align="left">
                    <dx:ASPxComboBox ID="PnlCustomizedDisplayFormat" runat="server" Width="170px" DropDownWidth="500" DropDownStyle="DropDownList" 
                    ValueType="System.String" TextFormatString="{0}" ValueField="DictionaryItemID" IncrementalFilteringMode="Contains" 
                    CallbackPageSize="30" ValidationSettings-RequiredField-IsRequired="true" ValidationSettings-RequiredField-ErrorText="数字格式必填！">
                        <Columns>
                            <dx:ListBoxColumn FieldName="DictionaryItemValue" Width="80px" />
                            <dx:ListBoxColumn FieldName="DictionaryItemName" Width="80px" /> 
                            <dx:ListBoxColumn FieldName="DictionaryItemCode" Width="50px" />      
                        </Columns>
                    </dx:ASPxComboBox>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>为必填项时出错提示：</strong>
                </td>
                <td align="left">
                    <dx:ASPxTextBox  ID="PnlCustomizedErrorText" runat="server"  width="200">
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>输入框无内容显示文本：</strong>
                </td>
                <td align="left">
                 <dx:ASPxTextBox  ID="PnlCustomizedNullText" runat="server"  Width="200" ></dx:ASPxTextBox> 
                </td>
            </tr>
            <tr>
                <td>
                    <strong>默认值：</strong>
                </td>
                <td align="left">
                    <dx:ASPxTextBox ID="PnlCustomizedDefaultValue" runat="server"  Width="200"></dx:ASPxTextBox>
                </td>
            </tr>
        </tbody>
        <%--表字段--%>
        <tbody id="PnlTableField" runat="server" visible="false">
            <tr>
                <td>
                    <strong>关联表：</strong>
                </td>
                <td>
                    <dx:ASPxComboBox ID="TableFieldtable" runat="server" AutoPostBack="true" OnTextChanged="TableTextChanged" TextFormatString="{0}" ValueField="ModelCode">
                        <Columns>
                            <dx:ListBoxColumn FieldName="ModelName" />
                            <dx:ListBoxColumn FieldName="ModelMeaning" />
                        </Columns>
                    </dx:ASPxComboBox>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>关联字段：</strong>
                </td>
                <td>
                    <dx:ASPxComboBox ID="TableFieldfield" runat="server" TextFormatString="{0}" ValueField="Code">
                        <Columns>
                            <dx:ListBoxColumn FieldName="Name" />
                            <dx:ListBoxColumn FieldName="Nick" />
                        </Columns>
                    </dx:ASPxComboBox>
                </td>
            </tr>
        </tbody>
        <%--图片--%>
        <tbody id="PnlPicture" visible="false" runat="server">
            <tr>
                <td>
                    <strong>图片最大宽度：</strong>
                </td>
                <td align="left">
                    <dx:ASPxSpinEdit ID="PnlImageWidth" runat="server" Width="200px" Number="500" ValidationSettings-RequiredField-IsRequired="true" ValidationSettings-RequiredField-ErrorText="最大宽度不能为空！" DisplayFormatString="#px" MinValue="0" MaxValue="1000">
                    </dx:ASPxSpinEdit>
                    <span style="color: Blue">单位：px &nbsp;例如：500px，范围0-1000</span>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>图片最大高度：</strong>
                </td>
                <td align="left">
                    <dx:ASPxSpinEdit ID="PnlImageHeight" runat="server" Width="200px" Number="500" ValidationSettings-RequiredField-IsRequired="true" ValidationSettings-RequiredField-ErrorText="最大高度不能为空！" DisplayFormatString="#px" MinValue="0" MaxValue="1000">
                    </dx:ASPxSpinEdit>
                    <span style="color: Blue">单位：px &nbsp;例如：500px，范围0-1000</span>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>允许的图片大小：</strong>
                </td>
                <td align="left">
                    <dx:ASPxSpinEdit ID="TxtImageSize" runat="server" Width="200px" Number="5" ValidationSettings-RequiredField-IsRequired="true" ValidationSettings-RequiredField-ErrorText="允许的图片大小不能为空！" MinValue="0" MaxValue="10">
                    </dx:ASPxSpinEdit>
                    <span style="color: Blue">单位：MB&nbsp;例如：5，范围0-10</span>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>图片是否加水印：</strong>
                </td>
                <td align="left">
                    <dx:ASPxRadioButtonList ID="PnlImageRadlHasWm" runat="server" RepeatDirection="Horizontal" ValidationSettings-RequiredField-IsRequired="true" ValidationSettings-RequiredField-ErrorText="请选择是否加水印！">
                        <Items>
                            <dx:ListEditItem Text="是" Value="1" />
                            <dx:ListEditItem Text="否" Value="0" />
                        </Items>
                    </dx:ASPxRadioButtonList>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>图片水印类型：</strong>
                </td>
                <td align="left">
                    <dx:ASPxRadioButtonList ID="PnlImageRadWmStyle" runat="server" RepeatDirection="Horizontal" ValidationSettings-RequiredField-IsRequired="true" ValidationSettings-RequiredField-ErrorText="请选择水印类型！">
                        <Items>
                            <dx:ListEditItem Text="文字" Value="1" />
                            <dx:ListEditItem Text="图片" Value="0" />
                        </Items>
                    </dx:ASPxRadioButtonList>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>图片类型：</strong>
                </td>
                <td align="left">
                    <script type="text/javascript">
                    // <![CDATA[
                        var textSeparator = ";";
                        function PictureOnListBoxSelectionChanged(listBox, args) {
                            if (args.index == 0)
                                args.isSelected ? listBox.SelectAll() : listBox.UnselectAll();
                            UpdateSelectAllItemState1();
                            UpdateText1();
                        }
                        function UpdateSelectAllItemState1() {
                            IsAllSelected1() ? PictureListBox.SelectIndices([0]) : PictureListBox.UnselectIndices([0]);
                        }
                        function IsAllSelected1() {
                            for (var i = 1; i < PictureListBox.GetItemCount(); i++)
                                if (!PictureListBox.GetItem(i).selected)
                                    return false;
                            return true;
                        }
                        function UpdateText1() {
                            var selectedItems = PictureListBox.GetSelectedItems();
                            PictureComboBox.SetText(GetSelectedItemsText1(selectedItems));
                        }
                        function PictureSynchronizeListBoxValues(dropDown, args) {
                            PictureListBox.UnselectAll();
                            var texts = dropDown.GetText().split(textSeparator);
                            var values = GetValuesByTexts1(texts);
                            PictureListBox.SelectValues(values);
                            UpdateSelectAllItemState1();
                            UpdateText1(); // for remove non-existing texts
                        }
                        function GetSelectedItemsText1(items) {
                            var texts = [];
                            for (var i = 0; i < items.length; i++)
                                if (items[i].index != 0)
                                    texts.push(items[i].text);
                            return texts.join(textSeparator);
                        }
                        function GetValuesByTexts1(texts) {
                            var actualValues = [];
                            var item;
                            for (var i = 0; i < texts.length; i++) {
                                item = PictureListBox.FindItemByText(texts[i]);
                                if (item != null)
                                    actualValues.push(item.value);
                            }
                            return actualValues;
                        }
                        // ]]>
                        </script>
                    <dx:ASPxDropDownEdit ID="PictureStyle" ClientInstanceName="PictureComboBox" runat="server" Width="200" ValidationSettings-RequiredField-IsRequired="true" ValidationSettings-RequiredField-ErrorText="请选择图片类型！">
                        <DropDownWindowTemplate>
                            <dx:ASPxListBox ID="PictureStyleList" ClientInstanceName="PictureListBox" runat="server" Width="100%" SelectionMode="CheckColumn">
                                <Items>
                                    <dx:ListEditItem Text="(全选)" />
                                    <dx:ListEditItem Text=".jpg" Value="1" />
                                    <dx:ListEditItem Text=".jpeg" Value="2" />
                                    <dx:ListEditItem Text=".jpe" Value="3" />
                                    <dx:ListEditItem Text=".gif" Value="4" />
                                </Items>
                                <ClientSideEvents SelectedIndexChanged="PictureOnListBoxSelectionChanged" />
                            </dx:ASPxListBox>
                            <table style="width: 100%">
                                <tr>
                                    <td align="right">
                                        <dx:ASPxButton ID="PictureStyleButton" AutoPostBack="False" runat="server" Text="关闭">
                                            <ClientSideEvents Click="function(s, e){ PictureComboBox.HideDropDown(); }" />
                                        </dx:ASPxButton>
                                    </td>
                                </tr>
                            </table>
                        </DropDownWindowTemplate>
                        <ClientSideEvents TextChanged="PictureSynchronizeListBoxValues" DropDown="PictureSynchronizeListBoxValues" />
                    </dx:ASPxDropDownEdit>
                </td>
            </tr>
        </tbody>
        <%--多图片--%>
        <tbody id="PnlMultiPicture" visible="false" runat="server">
            <tr>
                <td>
                    <strong>图片最大宽度：</strong>
                </td>
                <td align="left">
                    <dx:ASPxSpinEdit ID="PnlMultipleImageWidth" runat="server" Width="200px" Number="500" ValidationSettings-RequiredField-IsRequired="true" ValidationSettings-RequiredField-ErrorText="最大宽度不能为空！" DisplayFormatString="#px" MinValue="0" MaxValue="1000">
                    </dx:ASPxSpinEdit>
                    <span style="color: Blue">单位：px &nbsp;例如：500px，范围0-1000</span>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>图片最大高度：</strong>
                </td>
                <td align="left">
                    <dx:ASPxSpinEdit ID="PnlMultipleImageHeight" runat="server" Width="200px" Number="500" ValidationSettings-RequiredField-IsRequired="true" ValidationSettings-RequiredField-ErrorText="最大高度不能为空！" DisplayFormatString="#px" MinValue="0" MaxValue="1000">
                    </dx:ASPxSpinEdit>
                    <span style="color: Blue">单位：px &nbsp;例如：500px，范围0-1000</span>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>允许的图片大小：</strong>
                </td>
                <td align="left">
                    <dx:ASPxSpinEdit ID="PnlMultipleImageMaxSize" runat="server" Width="200px" Number="5" ValidationSettings-RequiredField-IsRequired="true" ValidationSettings-RequiredField-ErrorText="允许的图片大小不能为空！" MinValue="0" MaxValue="10">
                    </dx:ASPxSpinEdit>
                    <span style="color: Blue">单位：MB&nbsp;例如：5，范围0-10</span>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>图片是否加水印：</strong>
                </td>
                <td align="left">
                    <dx:ASPxRadioButtonList ID="PnlMultipleImageHasWm" runat="server" RepeatDirection="Horizontal" ValidationSettings-RequiredField-IsRequired="true" ValidationSettings-RequiredField-ErrorText="请选择是否加水印！">
                        <Items>
                            <dx:ListEditItem Text="是" Value="1" />
                            <dx:ListEditItem Text="否" Value="0" />
                        </Items>
                    </dx:ASPxRadioButtonList>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>图片水印类型：</strong>
                </td>
                <td align="left">
                    <dx:ASPxRadioButtonList ID="PnlMultipleImageWmStyle" runat="server" RepeatDirection="Horizontal" ValidationSettings-RequiredField-IsRequired="true" ValidationSettings-RequiredField-ErrorText="请选择水印类型！">
                        <Items>
                            <dx:ListEditItem Text="文字" Value="1" />
                            <dx:ListEditItem Text="图片" Value="0" />
                        </Items>
                    </dx:ASPxRadioButtonList>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>图片类型：</strong>
                </td>
                <td align="left">
                    <script type="text/javascript">
                    // <![CDATA[
                        var textSeparator = ";";
                        function MultiPictureOnListBoxSelectionChanged(listBox, args) {
                            if (args.index == 0)
                                args.isSelected ? listBox.SelectAll() : listBox.UnselectAll();
                            UpdateSelectAllItemStaten();
                            UpdateTextn();
                        }
                        function UpdateSelectAllItemStaten() {
                            IsAllSelectedn() ? MultiPictureListBox.SelectIndices([0]) : MultiPictureListBox.UnselectIndices([0]);
                        }
                        function IsAllSelectedn() {
                            for (var i = 1; i < MultiPictureListBox.GetItemCount(); i++)
                                if (!MultiPictureListBox.GetItem(i).selected)
                                    return false;
                            return true;
                        }
                        function UpdateTextn() {
                            var selectedItems = MultiPictureListBox.GetSelectedItems();
                            MultiPictureComboBox.SetText(GetSelectedItemsTextn(selectedItems));
                        }
                        function MultiPictureSynchronizeListBoxValues(dropDown, args) {
                            MultiPictureListBox.UnselectAll();
                            var texts = dropDown.GetText().split(textSeparator);
                            var values = GetValuesByTextsn(texts);
                            MultiPictureListBox.SelectValues(values);
                            UpdateSelectAllItemStaten();
                            UpdateTextn(); // for remove non-existing texts
                        }
                        function GetSelectedItemsTextn(items) {
                            var texts = [];
                            for (var i = 0; i < items.length; i++)
                                if (items[i].index != 0)
                                    texts.push(items[i].text);
                            return texts.join(textSeparator);
                        }
                        function GetValuesByTextsn(texts) {
                            var actualValues = [];
                            var item;
                            for (var i = 0; i < texts.length; i++) {
                                item = MultiPictureListBox.FindItemByText(texts[i]);
                                if (item != null)
                                    actualValues.push(item.value);
                            }
                            return actualValues;
                        }
                        // ]]>
                        </script>
                    <dx:ASPxDropDownEdit ID="MultiPictureStyle" ClientInstanceName="MultiPictureComboBox" runat="server" Width="200" ValidationSettings-RequiredField-IsRequired="true" ValidationSettings-RequiredField-ErrorText="请选择图片类型！">
                        <DropDownWindowTemplate>
                            <dx:ASPxListBox ID="MultiPictureStyleList" ClientInstanceName="MultiPictureListBox" runat="server" Width="100%" SelectionMode="CheckColumn">
                                <Items>
                                    <dx:ListEditItem Text="(全选)" />
                                    <dx:ListEditItem Text=".jpg" Value="1" />
                                    <dx:ListEditItem Text=".jpeg" Value="2" />
                                    <dx:ListEditItem Text=".jpe" Value="3" />
                                    <dx:ListEditItem Text=".gif" Value="4" />
                                </Items>
                                <ClientSideEvents SelectedIndexChanged="MultiPictureOnListBoxSelectionChanged" />
                            </dx:ASPxListBox>
                            <table style="width: 100%">
                                <tr>
                                    <td align="right">
                                        <dx:ASPxButton ID="MultiPictureStyleButton" AutoPostBack="False" runat="server" Text="关闭">
                                            <ClientSideEvents Click="function(s, e){ MultiPictureComboBox.HideDropDown(); }" />
                                        </dx:ASPxButton>
                                    </td>
                                </tr>
                            </table>
                        </DropDownWindowTemplate>
                        <ClientSideEvents TextChanged="MultiPictureSynchronizeListBoxValues" DropDown="MultiPictureSynchronizeListBoxValues" />
                    </dx:ASPxDropDownEdit>
                </td>
            </tr>
        </tbody>
        <%--文件--%>
        <tbody id="PnlFile" visible="false" runat="server">
            <tr>
                <td>
                    <strong>允许的文件大小：</strong>
                </td>
                <td align="left">
                    <dx:ASPxSpinEdit ID="TxtFileSize" runat="server" Width="200px" Number="5" ValidationSettings-RequiredField-IsRequired="true" ValidationSettings-RequiredField-ErrorText="允许的文件大小不能为空！" MinValue="0" MaxValue="10">
                    </dx:ASPxSpinEdit>
                    <span style="color: Blue">单位：MB&nbsp;例如：5，范围0-10</span>
                </td>
            </tr>
        </tbody>
        <%--多文件--%>
        <tbody id="PnlMultiFile" visible="false" runat="server">
            <tr>
                <td>
                    <strong>允许的文件大小：</strong>
                </td>
                <td align="left">
                    <dx:ASPxSpinEdit ID="TxtFilesSize" runat="server" Width="200px" Number="5" ValidationSettings-RequiredField-IsRequired="true" ValidationSettings-RequiredField-ErrorText="允许的文件大小不能为空！" MinValue="0" MaxValue="10">
                    </dx:ASPxSpinEdit>
                    <span style="color: Blue">单位：MB&nbsp;例如：5，范围0-10</span>
                </td>
            </tr>
        </tbody>
        <%--行政区划--%>
        <tbody id="PnlRegion" runat="server" visible="false">
            <tr>
                <td>
                
                </td>
            </tr>
        </tbody>
        <%--词条--%>
        <tbody id="PnlKeyword" visible="false" runat="server">
            <tr>
                <td>

                </td>
            </tr>
        </tbody>
        <%--验证码--%>
        <tbody id="PnlCaptcha" visible="false" runat="server">
            <tr>
                <td>

                </td>
            </tr>
        </tbody>
        <%--选择用户--%>
        <tbody id="PnlSelectUser" visible="false" runat="server">
            <tr>
                <td>
                
                </td>
            </tr>
        </tbody>
        <%--选择机构--%>
        <tbody id="PnlSelectDepartment" visible="false" runat="server">
            <tr>
                <td>
                
                </td>
            </tr>
        </tbody>
        <%--选择角色--%>
        <tbody id="PnlSelectRole" visible="false" runat="server">
            <tr>
                <td>
                
                </td>
            </tr>
        </tbody>



































        <%--选择代码--%>
        <tbody id="PnlSelectCode" visible="false" runat="server">
            <tr>
                <td>
                    <strong>为必填项时出错提示：</strong>
                </td>
                <td align="left">
                 <dx:ASPxTextBox  ID="PnlSelectCodeErrorText" runat="server" Width="200" ></dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>无输入内容时显示文本（灰色显示）：</strong>
                </td>
                <td align="left">
                 <dx:ASPxTextBox  ID="PnlSelectCodeNullText" runat="server" Width="200px" ></dx:ASPxTextBox> 
                </td>
            </tr>
            <tr>
                <td>
                    <strong>选择代码分类：</strong>
                </td>
                <td align="left">
                <!--规则库应用-->
                <dx:ASPxComboBox ID="PnlCode" runat="server" Width="170px" DropDownWidth="550" DropDownStyle="DropDownList" 
                    ValueType="System.String" TextFormatString="{0}" ValueField="DictionaryID" IncrementalFilteringMode="Contains" 
                    CallbackPageSize="30" ValidationSettings-RequiredField-IsRequired="true" ValidationSettings-RequiredField-ErrorText="代码分类必填！">
                    <Columns>
                        <dx:ListBoxColumn FieldName="DictionaryCode" Width="30px" />
                        <dx:ListBoxColumn FieldName="DictionaryValue" Width="80px" />
                        <dx:ListBoxColumn FieldName="DictionaryName" Width="50px" />  
                    </Columns>
                </dx:ASPxComboBox>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>显示选项：</strong>
                </td>
                <td align="left">
                    <dx:ASPxRadioButtonList ID="SingleOrMultiple" runat="server" RepeatDirection="Horizontal" ValidationSettings-RequiredField-IsRequired="true" ValidationSettings-RequiredField-ErrorText="请选择显示模式！">
                        <Items>
                            <dx:ListEditItem Text="单选" Value="1" />
                            <dx:ListEditItem Text="复选" Value="0" />
                        </Items>
                    </dx:ASPxRadioButtonList>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>显示模式：</strong>
                </td>
                <td align="left">
                    <dx:ASPxRadioButtonList ID="DisplayFormat" runat="server" RepeatDirection="Horizontal" ValidationSettings-RequiredField-IsRequired="true" ValidationSettings-RequiredField-ErrorText="请选择显示模式！">
                        <Items>
                            <dx:ListEditItem Text="GridView" Value="GridView" />
                            <dx:ListEditItem Text="TreeList" Value="TreeList" />
                            <dx:ListEditItem Text="Nav" Value="Nav" />
                        </Items>
                    </dx:ASPxRadioButtonList>
                </td>
            </tr>
        </tbody>
























        <%--评分控件--%>
        <tbody id="PnlVote" visible="false" runat="server">
            <tr>
                <td>

                </td>
            </tr>
        </tbody>
        <%--保存提交按钮--%>
            <tr>
                <td colspan="2">
                    <table>
                        <tr>
                            <td>
                                <dx:ASPxButton ID="EBtnSubmit" Text="保存字段" OnClick="SaveButtion_Click" runat="server" Enabled="false">
                                </dx:ASPxButton>
                            </td>
                            <td>
                                <dx:ASPxButton ID="BtnCancel" Text="返字回段管理" runat="server">
                                    <ClientSideEvents Click="function btncButtion(s,e){GoBack();}"/>
                                </dx:ASPxButton>
                            </td>
                        </tr>
                    </table>
                <asp:HiddenField ID="HdnFieldLevel" runat="server" />
                <asp:HiddenField ID="HdnFieldType" runat="server" />
                <asp:HiddenField ID="HdnOrderId" runat="server" />
                <asp:HiddenField ID="HdnDisabled" runat="server" />
            </td>
        </tr>
    </table>    
     <asp:HiddenField ID="hfKeyFieldList" runat="server" />
     <asp:HiddenField ID="ModelNameHidden" runat="server" />
     <asp:HiddenField ID="EditModeHidden" runat = "server" />
    </form>
</body>
</html>
