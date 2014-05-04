using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContentModel1._5.Common
{
    /// <summary>
    /// 这个类映射于Model表，存储内容模型公共字段信息
    /// </summary>
    public class ModelBase
    {
        /// <summary>
        /// 唯一标志这个表的主键
        /// </summary>
        public int ModelId
        {
            get;
            set;
        }
        /// <summary>
        /// 该模型对应数据表名
        /// </summary>
        public string TableName
        {
            get;
            set;
        }
        /// <summary>
        /// 模型数据表中该行数据所对应的那个数据表中数据所在行的ID
        /// </summary>
        public int ItemId
        {
            get;
            set;
        }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            get;
            set;
        }
        /// <summary>
        /// 副标题
        /// </summary>
        public string SubTitle
        {
            get;
            set;
        }
        /// <summary>
        /// 作者
        /// </summary>
        public string Author
        {
            get;
            set;
        }
        /// <summary>
        /// 点击数
        /// </summary>
        public int Hit
        {
            get;
            set;
        }
        /// <summary>
        /// 天点击数
        /// </summary>
        public int DayHit
        {
            get;
            set;
        }
        /// <summary>
        /// 周点击数
        /// </summary>
        public int WeekHit
        {
            get;
            set;
        }
        /// <summary>
        /// 月点击数
        /// </summary>
        public int MonHit
        {
            get;
            set;
        }
        /// <summary>
        /// 推荐级别
        /// </summary>
        public int EliteLevel
        {
            get;
            set;
        }
        /// <summary>
        /// 投送时间
        /// </summary>
        public DateTime SubTime
        {
            get;
            set;
        }        
        /// <summary>
        /// 录入时间
        /// </summary>
        public DateTime InputTime
        {
            get;
            set;
        }
        /// <summary>
        /// 上次点击时间
        /// </summary>
        public DateTime LastHitTime
        {
            get;
            set;
        }
        /// <summary>
        /// 标题样式
        /// </summary>
        public string TitleStyle
        {
            get;
            set;
        }
        /// <summary>
        /// 标题前缀样式
        /// </summary>
        public string TitlePrefix
        {
            get;
            set;
        }
        /// <summary>
        /// 是否可以评论
        /// </summary>
        public bool CanComment
        {
            get;
            set;
        }
        /// <summary>
        /// 推荐版块
        /// </summary>
        public string RecommendPosition
        {
            get;
            set;
        }
        /// <summary>
        /// 下架时间，已经发表的内容下架的时间
        /// </summary>
        public DateTime DownShelfTime
        {
            get;
            set;
        }
        /// <summary>
        /// 自动退稿时间，没有处理的稿件经过多长的时间自动退稿
        /// </summary>
        public DateTime ContentWaitingTime
        {
            get;
            set;
        }
        /// <summary>
        /// 来源站点编号
        /// </summary>
        public string StartSiteId
        {
            get;
            set;
        }
        /// <summary>
        /// 来源站点名称
        /// </summary>
        public string StartSiteName
        {
            get;
            set;
        }
        /// <summary>
        /// 投送站点编号
        /// </summary>
        public string EndSiteId
        {
            get;
            set;
        }
        /// <summary>
        /// 投送站点名称
        /// </summary>
        public string EndSiteName
        {
            get;
            set;
        }
        /// <summary>
        ///  投送栏目编号
        /// </summary>
        public string ContentChannelId
        {
            get;
            set;
        }
        /// <summary>
        /// 投送栏目名称
        /// </summary>
        public string ContentChannelName
        {
            get;
            set;
        }
    }
}