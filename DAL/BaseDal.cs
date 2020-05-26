using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Model;
using SqlSugar;

namespace DAL
{
    public  class BaseDal<T> : IBaseDal<T>
        where T : class, new()
    {
        private SqlSugarClient db = null;
        private SimpleClient<T> sdb { get { return new SimpleClient<T>(db); } }

        /// <summary>
        /// 设置访问数据库
        /// </summary>
        /// <param name="action">访问的服务</param>
        public BaseDal(Action<BaseDal<T>> action)
        {
            action(this);
        }

        public void GetMySql()
        {
            this.db= BaseDB.GetMySql();
        }

        public void GetClient()
        { 
            this.db= BaseDB.GetClient();
        }

        public bool Add(T t)
        {
            return sdb.Insert(t);
        }

        public void BeginTran()
        {
            db.Ado.BeginTran();
        }

        public void CommitTran()
        {
            db.Ado.CommitTran();
        }

        public bool Dels(dynamic[] lists)
        {
            return sdb.DeleteByIds(lists);
        }

        public int ExecuteCommand(string sql, params SugarParameter[] parameters)
        {
           return db.Ado.ExecuteCommand(sql, parameters);
        }

        public T Get(dynamic id)
        {
            return sdb.GetById(id);
        }
        //private Expression<Func<T, bool>> defexp = (x => 1 == 1);
        public IList<T> GetPageList(int pageIndex, int pageSize, Expression<Func<T,bool>> func, out int Count)
        {
            PageModel p = new PageModel() { PageIndex = pageIndex, PageSize = pageSize };
            Expression<Func<T, bool>> ex = func;
            IList<T> data = sdb.GetPageList(ex, p);
            Count = sdb.Count(func);
            return data;
        }

        public void RollbackTran()
        {
            db.Ado.RollbackTran();
        }

        public dynamic SqlQueryDynamic(string sql, params SugarParameter[] parameters)
        {
            return db.Ado.SqlQueryDynamic(sql, parameters);
        }

        public bool Update(T t)
        {
            return sdb.Update(t);
        }
    }
}
