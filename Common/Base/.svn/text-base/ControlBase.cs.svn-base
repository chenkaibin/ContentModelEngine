using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;

namespace ContentModel1._5.Common
{

    public abstract class ControlBase : IBuilder
    {
        public ControlBase(ModuleField moduleField)
        {
            this.ModuleField = moduleField;
        }

        public ModuleField ModuleField { get; set; }

        public FieldType FieldType
        {
            get
            {
                if (ModuleField != null)
                {
                    return ModuleField.FieldType;
                }
                else
                {
                    return Common.FieldType.None;
                }
            }
        }

        #region IBuilder 成员

        public virtual System.Web.UI.Control Build()
        {
            return null;
        }

        #endregion
    }
}