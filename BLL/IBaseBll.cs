﻿using Model;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BLL
{
    public interface IBaseBll<T>
       where T : class, new()
    {
        /// <summary>
        /// 切换Mysql
        /// </summary>
        void GetMySql();

        /// <summary>
        /// 切换Sqlserver
        /// </summary>
        void GetSqlserver();
        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        IList<T> GetPageList(int pageIndex, int pageSize, Expression<Func<T, bool>> func, out int Count);

        /// <summary>
        /// 获取单个
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T Get(dynamic id);

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        MessageModel Add(T t);

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        MessageModel Update(T t);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        MessageModel Dels(dynamic[] lists);

        /// <summary>
        /// 执行查询sql 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        dynamic SqlQueryDynamic(string sql, params SugarParameter[] parameters);

        /// <summary>
        /// 执行sql
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        int ExecuteCommand(string sql, params SugarParameter[] parameters);

        /// <summary>
        /// 开始事务
        /// </summary>
        void BeginTran();

        /// <summary>
        /// 提交数据
        /// </summary>
        void CommitTran();

        /// <summary>
        /// 回滚事务
        /// </summary>
        void RollbackTran();
    }
}
