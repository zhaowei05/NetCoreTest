﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// 令牌类
    /// </summary>
    public class TokenModel
    {
        public TokenModel()
        {
            this.Uid = "";
        }
        /// <summary>
        /// 用户Id
        /// </summary>
        public string Uid { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string Uname { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string UNickname { get; set; }
        /// <summary>
        /// 身份
        /// </summary>
        public string Sub { get; set; }
    }
}
