using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class CSBll : BaseBll<Model.CS>, IBaseBll<Model.CS>
    {
        public CSBll(Action<BaseBll<CS>> action) : base(action)
        {

        }
    }
}
