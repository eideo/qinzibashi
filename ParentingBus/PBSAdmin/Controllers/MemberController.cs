using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using PBS.Model;
using PBS.Server;
using PBSAdmin.Models;
using Utility;
using Newtonsoft.Json;

namespace PBSAdmin.Controllers
{
    public class MemberController : Controller
    {
        #region 会员
        // GET: Member
        public ActionResult MemberList()
        {
            pbsBasicUsersListResult result = new pbsBasicUsersListResult();
            pbs_basic_UsersService pbsBasicUsersService = new pbs_basic_UsersService();
            ResultInfo<List<pbs_basic_Users>> resultinfo = pbsBasicUsersService.GetUsersList();
            if (resultinfo.Result && resultinfo.Data != null)
            {
                result.List = resultinfo.Data;
            }

            return View(result);
        }

        public ActionResult MemberFamilyList(string userId)
        {
            int uid = Utility.Util.ParseHelper.ToInt(userId);
            pbsBasicMembersListResult result = new pbsBasicMembersListResult();
            pbs_basic_MembersService pbsMembersService = new pbs_basic_MembersService();
            if (!string.IsNullOrEmpty(userId))
            {
                ResultInfo<List<pbs_basic_Members>> resultinfo = pbsMembersService.GetMembersListByUserId(uid);
                if (resultinfo.Result && resultinfo.Data != null)
                {
                    result.List = resultinfo.Data;
                }
            }
            else {
                ResultInfo<List<pbs_basic_Members>> resultinfo = pbsMembersService.GetMembersList();
                if (resultinfo.Result && resultinfo.Data != null)
                {
                    result.List = resultinfo.Data;
                }
            }

            return View(result);
        }

        public ActionResult MemberShareProfitDetailList()
        {
            List<pbs_basic_ShareDetail> list = new List<pbs_basic_ShareDetail>();
            pbs_basic_MyShareProfitService pbsBasicMyShareProfitService = new pbs_basic_MyShareProfitService();
            ResultInfo<List<pbs_basic_ShareDetail>> result_list = pbsBasicMyShareProfitService.GetShareDetailList();
            if (result_list.Result && result_list.Data != null)
            {
                list = result_list.Data;

            }
            ViewData["List"] = list;
            return View();
        }

        public ActionResult MemberShareProfitList(int userId)
        {
            List<pbs_basic_MyShareProfit> pbs_basic_MyShareProfitList = new List<pbs_basic_MyShareProfit>();
            pbs_basic_MyShareProfitService pbsBasicMyShareProfitService = new pbs_basic_MyShareProfitService();
            ResultInfo<List<pbs_basic_MyShareProfit>> result_listMyShareProfitResult = pbsBasicMyShareProfitService.GetMyShareProfitList(userId);
            if (result_listMyShareProfitResult.Result && result_listMyShareProfitResult.Data != null)
            {
                pbs_basic_MyShareProfitList = result_listMyShareProfitResult.Data;

            }
            ViewData["pbs_basic_MyShareProfitList"] = pbs_basic_MyShareProfitList;
            return View();
        }

        public ActionResult MemberDetailList()
        {
            pbsBasicUsersDetailListResult result = new pbsBasicUsersDetailListResult();
            pbs_basic_UsersService pbsBasicUsersService = new pbs_basic_UsersService();
            ResultInfo<List<pbs_basic_UsersDetail>> resultinfo = pbsBasicUsersService.GetUsersDetailList();
            if (resultinfo.Result && resultinfo.Data != null)
            {
                result.List = resultinfo.Data;
            }

            return View(result);
        }

        public ActionResult MemberOrderDetailList(int userId)
        {
            pbsBasicUsersOrderDetailListResult result = new pbsBasicUsersOrderDetailListResult();
            pbs_basic_UsersService pbsBasicUsersService = new pbs_basic_UsersService();
            ResultInfo<List<pbs_basic_UsersOrderDetail>> resultinfo = pbsBasicUsersService.GetUsersOrderDetailList(userId);
            if (resultinfo.Result && resultinfo.Data != null)
            {
                result.List = resultinfo.Data;
            }

            return View(result);
        }

        #endregion
    }
}