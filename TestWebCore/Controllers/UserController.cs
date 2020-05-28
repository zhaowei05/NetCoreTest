using System;
using System.Collections.Generic;
using BLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Model;
using Newtonsoft.Json;
using ToKen;

namespace TestWebCore.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [AllowAnonymous]
        public object Login(LoginUserModel userModel)
        {
            if (userModel.userid == "admin" && userModel.userpwd == "123")
            {
                var tokenModel = new TokenModel
                {
                    Uid = userModel.userid,
                    Uname = userModel.realname,
                    UNickname = "",
                    Phone = "001",
                    Sub = "Admin",
                    Icon = ""
                };
                var access_token = RayPIToken.IssueJWT(tokenModel, new TimeSpan(0, 30, 00), new TimeSpan(0, 30, 00));

                //JwtConfig jwtConfig = new JwtConfig();

                //GenerateJwt _generateJwt = new GenerateJwt(jwtConfig);
                //var claims = new LoginUserModel()
                //{
                //    userid = userModel.userid.ToString(),
                //    username = userModel.username,
                //    realname = userModel.realname,
                //    roles = string.Join(";", userModel.roles),
                //    permissions = string.Join(";", userModel.permissions),
                //    normalPermissions = string.Join(";", userModel.normalPermissions),
                //};
                //var refreshToken = Guid.NewGuid().ToString();
                ////refreshToken设置15天过期
                ////await RedisHelper.SetAsync(refreshToken, claims, 60 * 60 * 24 * 15);
                //var jwtTokenResult = _generateJwt.GenerateEncodedTokenAsync(userModel.userid.ToString(), claims);
                //jwtTokenResult.refresh_token = refreshToken;

                return access_token;
            }

            return null;
        }

        [HttpGet]
        [Authorize(Policy = "Admin")]
        public object Yz(string access_token)
        {
            var jwtArr = access_token.Split('.');
            var dic = JsonConvert.DeserializeObject<Dictionary<string, string>>(Base64UrlEncoder.Decode(jwtArr[1]));
            //解析Claims
            //var reqUser = new LoginUserModel
            //{
            //    userid = dic["userid"],
            //    username = dic["username"],
            //    realname = dic["realname"],
            //    roles = dic["roles"],
            //    permissions = dic["permissions"],
            //    normalPermissions = dic["normalPermissions"],
            //};
            return dic;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Hq()
        {
            dynamic d = null;
            IBaseBll<CS> bll1 = new CSBll(x =>
            {
                x.GetMySql();
                d = x.GetPageList(1, 10, x => true, out var count);
            });
            //IList<Model.CS> list = bll1.GetPageList(1, 5);
            //var dt= bll1.SqlQueryDynamic("select * from CS ", null);

            return d;
        }

        [HttpGet]
        [AllowAnonymous]
        public object Hq2()
        {
            IList<M_OPT> list = null;
            IBaseBll<M_OPT> bll = new UserBll(x =>
                {
                    x.GetSqlserver();
                    list = x.GetPageList(1, 5, x => true, out var count);
                }
            );
            return list;
        }
    }
}