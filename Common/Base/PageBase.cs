using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContentModel1._5.Common
{
    public abstract class PageBase
    {
        protected List<ModuleField> moduleFieldList = null;
        protected System.Web.UI.Page page = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="moduleFieldList"></param>
        public PageBase(List<ModuleField> moduleFieldList, System.Web.UI.Page page)
        {
            this.moduleFieldList = moduleFieldList;
            this.page = page;
        }
    }
}