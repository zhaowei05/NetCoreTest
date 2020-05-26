using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// 登录成功返回model
    /// </summary>
    public class JwtTokenResult
    {
        public string access_token { get; set; }
        public string refresh_token { get; set; }
        /// <summary>
        /// 过期时间(单位秒)
        /// </summary>
        public int expires_in { get; set; }
        public string token_type { get; set; }
        public LoginUserModel user { get; set; }
    }
}
