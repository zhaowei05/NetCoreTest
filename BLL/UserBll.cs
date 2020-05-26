using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class UserBll : BaseBll<Model.M_OPT> ,IBaseBll<Model.M_OPT>
    {
        public UserBll(Action<BaseBll<M_OPT>> action) : base(action)
        {
        }

        public new MessageModel Add(M_OPT t)
        {
            return base.Add(t);
            
        }

        public new MessageModel Dels(dynamic[] lists)
        {
            return base.Dels(lists);
        }

        public new M_OPT Get(long id)
        {
            return base.Get(id);
        }


        public new MessageModel Update(M_OPT t)
        {
            return base.Update(t);
        }
    }
}
