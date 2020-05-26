using Model;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BLL
{
    public class BaseBll<T> : IBaseBll<T>
        where T : class, new()
    {
        //protected DAL.IBaseDal<T> dal = new DAL.BaseDal<T>("Sqlserver");
        protected DAL.IBaseDal<T> dal = null;

        public BaseBll(Action<BaseBll<T>> action)
        {
            action(this);
        }

        public  void GetMySql()
        {
            this.dal = new DAL.BaseDal<T>(x=>x.GetMySql());
        }

        public void GetSqlserver()
        {
            this.dal = new DAL.BaseDal<T>(x=>x.GetClient());
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public MessageModel Add(T t)
        {
            if(dal.Add(t))
                return new MessageModel {  res = true, msg = "操作成功" };
            else
                return new MessageModel { res = false, msg = "操作失败" };
        }

        /// <summary>
        /// 开始事务
        /// </summary>
        public void BeginTran()
        {
            dal.BeginTran();
        }

        /// <summary>
        /// 提交数据
        /// </summary>
        public void CommitTran()
        {
            dal.CommitTran();
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public MessageModel Dels(dynamic[] lists)
        {
            if (dal.Dels(lists))
                return new MessageModel { res = true, msg = "操作成功" };
            else
                return new MessageModel { res = false, msg = "操作失败" };
        }

        /// <summary>
        /// 执行sql
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public int ExecuteCommand(string sql, params SugarParameter[] parameters)
        {
           return  dal.ExecuteCommand(sql,parameters);
        }

        /// <summary>
        /// 获取单个
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T Get(dynamic id)
        {
            return dal.Get(id);
        }

        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IList<T> GetPageList(int pageIndex, int pageSize, Expression<Func<T, bool>> func, out int Count)
        {
            
            return dal.GetPageList(pageIndex, pageSize, func,out Count);
        }

        /// <summary>
        /// 回滚事务
        /// </summary>
        public void RollbackTran()
        {
        
            dal.RollbackTran();
        }

        /// <summary>
        /// 执行查询sql 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public dynamic SqlQueryDynamic(string sql, params SugarParameter[] parameters)
        {
            return dal.SqlQueryDynamic(sql, parameters);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public MessageModel Update(T t)
        {
            if (dal.Update(t))
                return new MessageModel { res = true, msg = "操作成功" };
            else
                return new MessageModel { res = false, msg = "操作失败" };
        }
    }
}
