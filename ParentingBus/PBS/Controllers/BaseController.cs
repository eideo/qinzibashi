using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PBS.Model;
using PBS.Server;

namespace PBS.Controllers
{
    public class BaseController : Controller
    {
        protected int userid
        {
            get
            {
                int uid = 0;
                pbs_basic_Users users = new pbs_basic_Users();
                if (Session["Users"] != null)
                {
                    users = (pbs_basic_Users)Session["Users"];
                    uid = users.UserId;
                }

                return uid;
                //return 5;
            }
        }

        protected string FromShareUserId
        {
            get
            {
                string result = string.Empty;
                if (Session["FromShareUserId"] != null)
                {
                    result = Session["FromShareUserId"].ToString();
                }
                return result;
            }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpRequestBase bases = (HttpRequestBase)filterContext.HttpContext.Request;
            string url = bases.RawUrl.ToString().ToLower();
            string host = bases.Url.Host;
            url = host + url;
            if (Session["UserOpenId"] != null)
            {
                string userOpenId = Session["UserOpenId"].ToString();
                pbs_basic_UsersService pbsBasicUsersService = new pbs_basic_UsersService();
                ResultInfo<bool> result_IsUser = pbsBasicUsersService.IsExistsByWeiXinCode(userOpenId);
                if (result_IsUser.Result && !result_IsUser.Data)
                {
                    ResultInfo<bool> result_AddUser = pbsBasicUsersService.AddUsers(userOpenId, string.Empty, string.Empty, string.Empty, string.Empty, 0, string.Empty, userOpenId, DateTime.Now, DateTime.Now, 0, string.Empty, string.Empty);
                }

                ResultInfo<pbs_basic_Users> result_Users = pbsBasicUsersService.GetUsersModelByWeiXinCode(userOpenId);
                if (result_Users.Result && result_Users.Data != null)
                {
                    Session["Users"] = result_Users.Data;
                }

            }
            else
            {
                filterContext.Result = new RedirectResult("~/WeiPay/Send.aspx?myReturnUrl=" + url);
            }

            base.OnActionExecuting(filterContext);
        }

    }
}