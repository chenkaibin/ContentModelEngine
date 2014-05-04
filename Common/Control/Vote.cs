using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.Web.ASPxRatingControl;

namespace ContentModel1._5.Common
{
    public class Vote : ControlBase
    {
        public Vote(ModuleField moduleField)
            : base(moduleField)
        {
        }

        public override System.Web.UI.Control Build()
        {
            base.Build();
            ASPxRatingControl rc = new ASPxRatingControl();
            return rc;
        }
    }
}