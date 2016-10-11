using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using PBS.Model;
using PBS.Server;
using Newtonsoft.Json;
using System.Web.SessionState;

namespace PBSAdmin.ashx
{
    /// <summary>
    /// CheckLogin 的摘要说明
    /// </summary>
    public class CheckLogin : IHttpHandler, IRequiresSessionState
    {
        pbs_sys_users userData = new pbs_sys_users();

        public void ProcessRequest(HttpContext context)
        {
            
            context.Response.Write(CheckLogins(context.Request.QueryString["LoginId"],
                                               context.Request.QueryString["PassWord"],
                                               context.Request.QueryString["Captcha"],
                                               context.Session["Code"].ToString()));
            HttpContext.Current.Session["USER"] = userData;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// 登录验证
        /// </summary>
        /// <returns></returns>
        public string CheckLogins(string loginId, string passWord, string captcha,string sessionCode)
        {
            dynamic result = new ExpandoObject();
            pbs_sys_usersService usersService = new pbs_sys_usersService();

            if (captcha != sessionCode)
            {
                result.Code = "0001";
            }
            else
            {
                ResultInfo<pbs_sys_users> resultUserData = usersService.GetUserInfo(loginId.Trim(),
                    Common.MD5Common.GetMd5Hash(passWord.Trim()));
                if (resultUserData.Result && resultUserData.Data != null)
                {
                    userData = resultUserData.Data;
                    result.Code = "0000";
                }
                else
                {
                    result.Code = "0002";
                }
            }
            return JsonConvert.SerializeObject(result);
        }
    }
}