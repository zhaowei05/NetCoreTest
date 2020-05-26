using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class UserDal : BaseDal<Model.M_OPT>, IBaseDal<M_OPT>
    {
        public UserDal(Action<BaseDal<M_OPT>> action) : base(action)
        {
        }

        public new bool Add(M_OPT t)
        {
           return base.Add(t);
        }

        public new bool Dels(dynamic[] lists)
        {
            return base.Dels(lists);
        }

        public new M_OPT Get(long id)
        {
            return base.Get(id);
        }

        //public new IList<M_OPT> GetPageList(int pageIndex, int pageSize)
        //{
        //    return base.GetPageList(pageIndex, pageSize);
        //}

        public new bool Update(M_OPT t)
        {
            return base.Update(t);
        }
    }
}
