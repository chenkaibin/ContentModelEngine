using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContentModel1._5.Common
{
    public enum FieldType
    {
        /// <summary>
        /// 未指定类型
        /// </summary>
        None,
        /// <summary>
        /// 单行文本
        /// </summary>
        SingleLineText,
        /// <summary>
        /// 多行文本(非HTML）
        /// </summary>
        MultiLineNoHtml,
        /// <summary>
        /// HTML文本
        /// </summary>
        MultiLineHtml,
        /// <summary>
        /// 单选下拉列表框
        /// </summary>
        SingleDropDownList,
        /// <summary>
        /// 多选下拉列表框
        /// </summary>
        MultiDropDownList,
        /// <summary>
        /// 单选按钮
        /// </summary>
        RadioButtonField,
        /// <summary>
        /// 复选按钮
        /// </summary>
        CheckBoxField,
        /// <summary>
        /// 数字
        /// </summary>
        NumberField,
        /// <summary>
        /// 货币
        /// </summary>
        MoneyField,
        /// <summary>
        /// 日期
        /// </summary>
        DateField,
        /// <summary>
        /// 时间
        /// </summary>
        TimeField,
        /// <summary>
        /// 超链接
        /// </summary>
        LinkField,
        /// <summary>
        /// 固定电话号码
        /// </summary>
        PhoneFixed,
        /// <summary>
        /// 移动电话号码
        /// </summary>
        PhoneMobile,
        /// <summary>
        /// 自定义文本
        /// </summary>
        CustomText,
        /// <summary>
        /// 颜色
        /// </summary>
        ColorField,
        /// <summary>
        /// 图片上传
        /// </summary>
        Picture,
        /// <summary>
        /// 多图上传
        /// </summary>
        MultiPicture,
        /// <summary>
        /// 文件上传
        /// </summary>
        Upload,
        /// <summary>
        /// 多文件上传
        /// </summary>
        MultiUpload,
        /// <summary>
        /// 词条选择
        /// </summary>
        ListBox,
        /// <summary>
        /// 代码选择
        /// </summary>
        SelectCode,
        /// <summary>
        /// 机构选择
        /// </summary>
        Org,
        /// <summary>
        /// 用户选择
        /// </summary>
        User,
        /// <summary>
        /// 角色选择
        /// </summary>
        Role,
        /// <summary>
        /// 评分评比
        /// </summary>
        VoteField,
        /// <summary>
        /// 验证码
        /// </summary>
        Captcha
    }
}