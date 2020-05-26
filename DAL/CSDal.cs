using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class CSDal : BaseDal<CS>, IBaseDal<CS>
    {
        public CSDal(Action<BaseDal<CS>> action) : base(action)
        {
        }
    }
}
