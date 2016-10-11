using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using PBS.Model;
using PBS.Server;
using Utility;
using Newtonsoft.Json;

namespace PBS.Controllers
{
    public class UserController : BaseController
    {
        // GET: User

        public ActionResult Index()
        {
            pbs_basic_Users users = new pbs_basic_Users();
            pbs_basic_UsersService pbsBasicUsersService = new pbs_basic_UsersService();
            ResultInfo<pbs_basic_Users> result_Users = pbsBasicUsersService.GetUsersModelById(userid);
            if (result_Users.Result && result_Users.Data != null)
            {
                users = result_Users.Data;
                ViewData["Users"] = users;
            }

            return View();
        }

        public ActionResult UserCenter()
        {
            string dadName = string.Empty;
            string mumName = string.Empty;
            pbs_basic_Users users = new pbs_basic_Users();
            pbs_basic_UsersService pbsBasicUsersService = new pbs_basic_UsersService();
            ResultInfo<pbs_basic_Users> result_Users = pbsBasicUsersService.GetUsersModelById(userid);
            if (result_Users.Result && result_Users.Data != null)
            {
                users = result_Users.Data;
                ViewData["Users"] = users;
            }
            else {
                ViewData["Users"] = new pbs_basic_Users();
            }

            List<pbs_basic_Members> listMembers = new List<pbs_basic_Members>();
            pbs_basic_MembersService pbsBasicMembersService = new pbs_basic_MembersService();
            ResultInfo<List<pbs_basic_Members>> result_Members = pbsBasicMembersService.GetMembersListByUserId(userid);
            if (result_Members.Result && result_Members.Data != null && result_Members.Data.Count > 0)
            {
                listMembers = result_Members.Data;
                if (listMembers.Where(p => p.RelationType == 0).FirstOrDefault()!=null)
                {
                    dadName = listMembers.Where(p => p.RelationType == 0).FirstOrDefault().MemberName;
                }
                else {
                    dadName = string.Empty;
                }

                if (listMembers.Where(p => p.RelationType == 1).FirstOrDefault() != null)
                {
                    mumName = listMembers.Where(p => p.RelationType == 1).FirstOrDefault().MemberName;
                }
                else
                {
                    mumName = string.Empty;
                }

            }

            ViewData["DadName"] = dadName;
            ViewData["MumName"] = mumName;

            #region 区域下拉列表
            ViewData["RegionList"] = null;
            pbsBasicRegionParentSelect pbsRegionParentselect = new pbsBasicRegionParentSelect();
            pbsRegionParentselect.regionParentList = new List<pbs_basic_Region>();
            pbs_basic_RegionService pbsBasicRegionService = new pbs_basic_RegionService();
            ResultInfo<List<pbs_basic_Region>> resultParentItem = pbsBasicRegionService.GetThisRegionList(110100);
            if (resultParentItem.Result && resultParentItem.Data != null && resultParentItem.Data.Count > 0)
            {
                foreach (pbs_basic_Region itemParent in resultParentItem.Data) //得到行集合
                {
                    pbs_basic_Region regionParent = new pbs_basic_Region();
                    regionParent.RegionId = itemParent.RegionId;
                    regionParent.RegionName = itemParent.RegionName;
                    regionParent.ParentRegionId = itemParent.ParentRegionId;
                    regionParent.CreateTime = itemParent.CreateTime;
                    regionParent.UpdateTime = itemParent.UpdateTime;
                    regionParent.CreatorId = itemParent.CreatorId;
                    regionParent.Remark = itemParent.Remark;
                    regionParent.regionChildrenList = new List<pbs_basic_RegionChildren>();
                    ResultInfo<List<pbs_basic_Region>> resultChildernItem = pbsBasicRegionService.GetThisRegionList(regionParent.RegionId);
                    if (resultChildernItem.Result && resultChildernItem.Data != null && resultChildernItem.Data.Count > 0)
                    {
                        foreach (pbs_basic_Region itemChildren in resultChildernItem.Data) //得到行集合
                        {
                            pbs_basic_RegionChildren regionChildern = new pbs_basic_RegionChildren();
                            regionChildern.RegionId = itemChildren.RegionId;
                            regionChildern.RegionName = itemChildren.RegionName;
                            regionChildern.ParentRegionId = itemChildren.ParentRegionId;
                            regionChildern.CreateTime = itemChildren.CreateTime;
                            regionChildern.UpdateTime = itemChildren.UpdateTime;
                            regionChildern.CreatorId = itemChildren.CreatorId;
                            regionChildern.Remark = itemChildren.Remark;
                            regionParent.regionChildrenList.Add(regionChildern);
                        }
                    }
                    pbsRegionParentselect.regionParentList.Add(regionParent);
                }
            }

            ViewData["RegionList"] = pbsRegionParentselect.regionParentList;
            #endregion

            return View();
        }

        public JsonResult UpdateUserAjax(string nickName, string photoUrl, string babySex, string phone, string babyBirthday, string dadName, string mumName, string myAdress)
        {
            bool flag = false;
            pbs_basic_Users users = new pbs_basic_Users();
            List<pbs_basic_Members> listMembers = new List<pbs_basic_Members>();
            pbs_basic_Members dadMember = new pbs_basic_Members();
            pbs_basic_Members mumMember = new pbs_basic_Members();
            pbs_basic_UsersService pbsBasicUsersService = new pbs_basic_UsersService();
            pbs_basic_MembersService pbsBasicMembersService = new pbs_basic_MembersService();
            ResultInfo<pbs_basic_Users> result_Users = pbsBasicUsersService.GetUsersModelById(userid);
            if (result_Users.Result && result_Users.Data != null)
            {
                users = result_Users.Data;
                users.PhotoUrl = photoUrl;
                users.NickName = nickName;
                users.BabySex = Utility.Util.ParseHelper.ToInt(babySex);
                users.Phone = phone;
                users.BabyBirthday = babyBirthday;
                users.MyAdress = myAdress;
                ResultInfo<bool> result_UpdateUsers = pbsBasicUsersService.UpdateUsers(users.LoginName, users.Pwd, users.NickName, users.PhotoUrl, users.Phone, users.BabySex, users.BabyBirthday, users.WeiXinCode, users.CreateTime, users.UpdateTime, users.UserId, users.Remark, users.MyAdress, users.UserId);
                if (result_UpdateUsers.Result && result_UpdateUsers.Data)
                {
                    ResultInfo<List<pbs_basic_Members>> result_Members = pbsBasicMembersService.GetMembersListByUserId(userid);
                    if (result_Members.Result && result_Members.Data != null)
                    {
                        listMembers = result_Members.Data;
                        if (listMembers.Where(p => p.RelationType == 0).FirstOrDefault()!=null) {
                            dadMember = listMembers.Where(p => p.RelationType == 0).FirstOrDefault();
                        }

                        if (listMembers.Where(p => p.RelationType == 1).FirstOrDefault() != null) {
                            mumMember = listMembers.Where(p => p.RelationType == 1).FirstOrDefault();
                        }

                        dadMember.MemberName = dadName;
                        mumMember.MemberName = mumName;

                        if (dadMember!=null&&dadMember.MembersId>0) {
                            ResultInfo<bool> result_DadMemberUpdate = pbsBasicMembersService.UpdateMembers(dadMember.MemberName, dadMember.Sex, dadMember.RelationType, dadMember.Birthday, dadMember.IDNum, dadMember.UserId, dadMember.CreateTime, dadMember.UpdateTime, dadMember.CreatorId, dadMember.Remark, dadMember.MembersId);
                            if (result_DadMemberUpdate.Result && result_DadMemberUpdate.Data)
                            {
                                flag = true;
                            }
                        }

                        if (mumMember != null && mumMember.MembersId > 0)
                        {
                            ResultInfo<bool> result_MumMemberUpdate = pbsBasicMembersService.UpdateMembers(mumMember.MemberName, mumMember.Sex, mumMember.RelationType, mumMember.Birthday, mumMember.IDNum, mumMember.UserId, mumMember.CreateTime, mumMember.UpdateTime, mumMember.CreatorId, mumMember.Remark, mumMember.MembersId);
                            if (result_MumMemberUpdate.Result && result_MumMemberUpdate.Data)
                            {
                                flag = true;
                            }
                        }

                        if (flag)
                        {
                            return Json(new ResultModel<bool>(0, "修改成功", true), JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        dadMember.MemberName = dadName;
                        dadMember.Sex = 0;
                        dadMember.RelationType = 0;
                        dadMember.Birthday = string.Empty;
                        dadMember.IDNum = string.Empty;
                        dadMember.UserId = userid;
                        dadMember.CreateTime = DateTime.Now;
                        dadMember.UpdateTime= DateTime.Now;
                        dadMember.CreatorId = 0;
                        dadMember.Remark = string.Empty;
                        mumMember.MemberName = mumName;
                        mumMember.Sex = 0;
                        mumMember.RelationType = 0;
                        mumMember.Birthday = string.Empty;
                        mumMember.IDNum = string.Empty;
                        mumMember.UserId = userid;
                        mumMember.CreateTime = DateTime.Now;
                        mumMember.UpdateTime = DateTime.Now;
                        mumMember.CreatorId = 0;
                        mumMember.Remark = string.Empty;

                        ResultInfo<bool> result_DadMemberUpdate = pbsBasicMembersService.AddMembers(dadMember.MemberName, dadMember.Sex, dadMember.RelationType, dadMember.Birthday, dadMember.IDNum, dadMember.UserId, dadMember.CreateTime, dadMember.UpdateTime, dadMember.CreatorId, dadMember.Remark);
                        ResultInfo<bool> result_MumMemberUpdate = pbsBasicMembersService.AddMembers(mumMember.MemberName, mumMember.Sex, mumMember.RelationType, mumMember.Birthday, mumMember.IDNum, mumMember.UserId, mumMember.CreateTime, mumMember.UpdateTime, mumMember.CreatorId, mumMember.Remark);
                        if (result_DadMemberUpdate.Result && result_DadMemberUpdate.Data && result_MumMemberUpdate.Result && result_MumMemberUpdate.Data)
                        {
                            return Json(new ResultModel<bool>(0, "修改成功", true), JsonRequestBehavior.AllowGet);
                        }
                    }
                }
            }
            return Json(new ResultModel<bool>(1, "修改失败", true), JsonRequestBehavior.AllowGet);
        }

        public ActionResult MyOrder()
        {
            List<pbs_basic_OrderView> listAllOrder = new List<pbs_basic_OrderView>();
            List<pbs_basic_OrderView> listDFKOrder = new List<pbs_basic_OrderView>();
            List<pbs_basic_OrderView> listYFKOrder = new List<pbs_basic_OrderView>();
            List<pbs_basic_OrderView> listTKZOrder = new List<pbs_basic_OrderView>();
            List<pbs_basic_OrderView> listYWCOrder = new List<pbs_basic_OrderView>();
            pbs_basic_OrderService pbsBasicOrderService = new pbs_basic_OrderService();

            //全部
            ResultInfo<List<pbs_basic_OrderView>> result_listAllOrder = pbsBasicOrderService.GetOrderViewListByUserId(userid);
            if (result_listAllOrder.Result && result_listAllOrder.Data != null)
            {
                listAllOrder = result_listAllOrder.Data;

                foreach (var item in listAllOrder)
                {
                    if (item.OrderStatus==2&& item.VisitTime<DateTime.Now)
                    {
                       pbsBasicOrderService.UpdateOrders(3, item.OrderId);
                    }
                }

            }

            //待付款
            ResultInfo<List<pbs_basic_OrderView>> result_listDFKOrder = pbsBasicOrderService.GetOrderViewListByUserIdAndStatus(userid, 1);
            if (result_listDFKOrder.Result && result_listDFKOrder.Data != null)
            {
                listDFKOrder = result_listDFKOrder.Data;
            }

            //已付款
            ResultInfo<List<pbs_basic_OrderView>> result_listYFKOrder = pbsBasicOrderService.GetOrderViewListByUserIdAndStatus(userid, 2);
            if (result_listYFKOrder.Result && result_listYFKOrder.Data != null)
            {
                listYFKOrder = result_listYFKOrder.Data;
            }

            //已完成
            ResultInfo<List<pbs_basic_OrderView>> result_listYWCOrder = pbsBasicOrderService.GetOrderViewListByUserIdAndStatus(userid, 3);
            if (result_listYWCOrder.Result && result_listYWCOrder.Data != null)
            {
                listYWCOrder = result_listYWCOrder.Data;
            }

            //退款中
            ResultInfo<List<pbs_basic_OrderView>> result_listTKZOrder = pbsBasicOrderService.GetOrderViewListByUserIdAndStatus(userid, 4);
            if (result_listTKZOrder.Result && result_listTKZOrder.Data != null)
            {
                listTKZOrder = result_listTKZOrder.Data;
            }

            ViewData["ListAllOrder"] = listAllOrder;
            ViewData["ListDFKOrder"] = listDFKOrder;
            ViewData["ListYFKOrder"] = listYFKOrder;
            ViewData["ListTKZOrder"] = listTKZOrder;
            ViewData["ListYWCOrder"] = listYWCOrder;
            return View();
        }

        public JsonResult OrderDeleteAjax(string orderId)
        {
            if (!string.IsNullOrEmpty(orderId))
            {
                int oid = Utility.Util.ParseHelper.ToInt(orderId);
                pbs_basic_OrderService pbsBasicOrderService = new pbs_basic_OrderService();
                ResultInfo<bool> resultDeleteOrder = pbsBasicOrderService.DeleteOrder(oid);
                if (resultDeleteOrder.Result && resultDeleteOrder.Data)
                {
                    return Json(new ResultModel<bool>(0, "删除订单成功", true), JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new ResultModel<bool>(1, "删除订单失败", false), JsonRequestBehavior.AllowGet);
        }

        public ActionResult MyMembers()
        {
            List<pbs_basic_Members> listMembers = new List<pbs_basic_Members>();
            pbs_basic_MembersService pbsBasicMembersService = new pbs_basic_MembersService();
            ResultInfo<List<pbs_basic_Members>> result_Members = pbsBasicMembersService.GetMembersListByUserId(userid);
            if (result_Members.Result && result_Members.Data != null)
            {
                listMembers = result_Members.Data;
            }
            ViewData["ListMembers"] = listMembers;

            return View();
        }

        public ActionResult MyMembersDetail(string Id)
        {
            int mid = Utility.Util.ParseHelper.ToInt(Id);
            pbs_basic_Members members = new pbs_basic_Members();
            pbs_basic_MembersService pbsBasicMembersService = new pbs_basic_MembersService();
            ResultInfo<pbs_basic_Members> result_Members = pbsBasicMembersService.GetMembersModelById(mid);
            if (result_Members.Result && result_Members.Data != null)
            {
                members = result_Members.Data;
            }
            ViewData["Members"] = members;

            if (!string.IsNullOrEmpty(Id))
            {
                ViewData["ThisTitle"] = "修改成员信息";
            }
            else
            {
                ViewData["ThisTitle"] = "添加成员信息";
            }
            return View();
        }

        public JsonResult AddMembersAjax(string memberName, string sex, string relationType, string birthday, string iDNum)
        {
            pbs_basic_MembersService pbsBasicMembersService = new pbs_basic_MembersService();

            ResultInfo<bool> result_AddMembers = pbsBasicMembersService.AddMembers(memberName, Utility.Util.ParseHelper.ToInt(sex), Utility.Util.ParseHelper.ToInt(relationType), birthday, iDNum, userid, DateTime.Now, DateTime.Now, 0, string.Empty);
            if (result_AddMembers.Result && result_AddMembers.Data)
            {
                return Json(new ResultModel<bool>(0, "添加成功", true), JsonRequestBehavior.AllowGet);
            }

            return Json(new ResultModel<bool>(1, "添加失败", true), JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateMembersAjax(string memberName, string sex, string relationType, string birthday, string iDNum, string membersId)
        {
            int mid = Utility.Util.ParseHelper.ToInt(membersId);
            pbs_basic_Members members = new pbs_basic_Members();
            pbs_basic_MembersService pbsBasicMembersService = new pbs_basic_MembersService();

            ResultInfo<pbs_basic_Members> result_Members = pbsBasicMembersService.GetMembersModelById(mid);
            if (result_Members.Result && result_Members.Data != null)
            {
                members = result_Members.Data;
                members.MemberName = memberName;
                members.Sex = Utility.Util.ParseHelper.ToInt(sex);
                members.RelationType = Utility.Util.ParseHelper.ToInt(relationType);
                members.Birthday = birthday;
                members.IDNum = iDNum;
                members.UpdateTime = DateTime.Now;

                ResultInfo<bool> result_UpdateMembers = pbsBasicMembersService.UpdateMembers(members.MemberName, members.Sex, members.RelationType, members.Birthday, members.IDNum, userid, members.CreateTime, members.UpdateTime, 0, string.Empty, mid);
                if (result_UpdateMembers.Result && result_UpdateMembers.Data)
                {
                    return Json(new ResultModel<bool>(0, "修改成功", true), JsonRequestBehavior.AllowGet);
                }

            }
            return Json(new ResultModel<bool>(1, "修改失败", true), JsonRequestBehavior.AllowGet);

        }

        public ActionResult MyVoucher()
        {
            List<pbs_basic_MyVoucherView> listMyVoucher = new List<pbs_basic_MyVoucherView>();
            pbs_basic_MyVoucherService pbsBasicMyVoucherService = new pbs_basic_MyVoucherService();
            ResultInfo<List<pbs_basic_MyVoucherView>> result_listMyVoucher = pbsBasicMyVoucherService.GetMyVoucherViewList(userid);
            if (result_listMyVoucher.Result && result_listMyVoucher.Data != null)
            {
                listMyVoucher = result_listMyVoucher.Data;
            }

            ViewData["ListMyVoucher"] = listMyVoucher;

            return View();
        }

        public ActionResult MyGrowthProcess()
        {
            List<pbs_basic_OrderViewRN> listOrderViewRN = new List<pbs_basic_OrderViewRN>();
            pbs_basic_OrderService pbsBasicOrderService = new pbs_basic_OrderService();

            ResultInfo<List<pbs_basic_OrderViewRN>> result_listOrderViewRN = pbsBasicOrderService.GetOrderViewRNListByUserId(userid);
            if (result_listOrderViewRN.Result && result_listOrderViewRN.Data != null)
            {
                listOrderViewRN = result_listOrderViewRN.Data;

            }
            ViewData["ListOrderViewRN"] = listOrderViewRN;
            return View();
        }

        public ActionResult MyShareProfit()
        {
            decimal myShareProfit = 0m;
            List<pbs_basic_MyShareProfit> pbs_basic_MyShareProfitList = new List<pbs_basic_MyShareProfit>();
            pbs_basic_MyShareProfitService pbsBasicMyShareProfitService = new pbs_basic_MyShareProfitService();
            ResultInfo<List<pbs_basic_MyShareProfit>> result_listMyShareProfitResult = pbsBasicMyShareProfitService.GetMyShareProfitList(userid);
            if (result_listMyShareProfitResult.Result && result_listMyShareProfitResult.Data != null)
            {
                pbs_basic_MyShareProfitList = result_listMyShareProfitResult.Data;

            }

            ResultInfo<decimal> result_GetMyShareProfitByUserId = pbsBasicMyShareProfitService.GetMyShareProfitByUserId(userid);
            if (result_GetMyShareProfitByUserId.Result && result_GetMyShareProfitByUserId.Data != 0)
            {
                myShareProfit = result_GetMyShareProfitByUserId.Data;

            }

            ViewData["MyShareProfit"] = myShareProfit;
            ViewData["pbs_basic_MyShareProfitList"] = pbs_basic_MyShareProfitList;

            return View(pbs_basic_MyShareProfitList);
        }

        public ActionResult ApplyMoney(string orderId)
        {
            pbs_basic_OrderView pbsBasicOrderView = new pbs_basic_OrderView();
            pbs_basic_OrderService pbsBasicOrderService = new pbs_basic_OrderService();
            int oId = Utility.Util.ParseHelper.ToInt(orderId);
            ResultInfo<pbs_basic_OrderView> result_orderView = pbsBasicOrderService.GetOrderModelViewById(oId);
            if (result_orderView.Result && result_orderView.Data != null)
            {
                pbsBasicOrderView = result_orderView.Data;
            }

            pbs_basic_GoodsPackageService pbsBasicGoodsPackageService = new pbs_basic_GoodsPackageService();
            ResultInfo<pbs_basic_GoodsPackage> resultGoodsPackage = pbsBasicGoodsPackageService.GetGoodsPackageModelById(pbsBasicOrderView.GoodsPackageId);
            if (resultGoodsPackage.Result && resultGoodsPackage.Data != null)
            {
                ViewData["GoodsPackageName"] = resultGoodsPackage.Data.GoodsPackageName;
            }
            else
            {
                ViewData["GoodsPackageName"] = "无";
            }

            ViewData["pbsBasicOrderView"] = pbsBasicOrderView;
            return View();
        }

        public JsonResult ApplyMoneyAjax(string orderId,string reason)
        {
            int oId = Utility.Util.ParseHelper.ToInt(orderId);
            pbs_basic_OrderRefundService pbsBasicOrderRefundService = new pbs_basic_OrderRefundService();
            pbs_basic_OrderService pbsBasicOrderService = new pbs_basic_OrderService();
            ResultInfo<bool> result_AddOrderRefun = pbsBasicOrderRefundService.AddOrderRefund(oId, userid, reason, DateTime.Now, DateTime.Now, 0, string.Empty);
            if (result_AddOrderRefun.Result && result_AddOrderRefun.Data)
            {
                ResultInfo<bool> result_UpdateOrder = pbsBasicOrderService.UpdateOrders(4, oId);
                if (result_AddOrderRefun.Result && result_AddOrderRefun.Data)
                {
                    return Json(new ResultModel<bool>(0, "退款已申请", true), JsonRequestBehavior.AllowGet);
                }
            }

            return Json(new ResultModel<bool>(1, "申请退款失败", true), JsonRequestBehavior.AllowGet);
        }

        public ActionResult AssessOrder(string orderId)
        {
            pbs_basic_OrderView pbsBasicOrderView = new pbs_basic_OrderView();
            pbs_basic_OrderService pbsBasicOrderService = new pbs_basic_OrderService();
            int oId = Utility.Util.ParseHelper.ToInt(orderId);
            ResultInfo<pbs_basic_OrderView> result_orderView = pbsBasicOrderService.GetOrderModelViewById(oId);
            if (result_orderView.Result && result_orderView.Data != null)
            {
                pbsBasicOrderView = result_orderView.Data;
            }

            ViewData["pbsBasicOrderView"] = pbsBasicOrderView;
            return View();
        }

        public JsonResult AssessOrderAjax(string goodsId, string commentContents,string url1,string score,string oId)
        {
            int gId = Utility.Util.ParseHelper.ToInt(goodsId);
            int scoreThis= Utility.Util.ParseHelper.ToInt(score);
            pbs_basic_CommentService pbsBasicCommentService = new pbs_basic_CommentService();
            pbs_basic_OrderService pbsBasicOrderService = new pbs_basic_OrderService();

            ResultInfo<bool> result_AddComment = pbsBasicCommentService.AddComment(gId, userid, commentContents, url1, string.Empty, string.Empty, string.Empty, string.Empty, scoreThis, DateTime.Now, DateTime.Now, 0, string.Empty);
            if (result_AddComment.Result && result_AddComment.Data)
            {
                ResultInfo<bool> result_UpdateOrder = pbsBasicOrderService.UpdateOrders(6, Utility.Util.ParseHelper.ToInt(oId));
                if (result_UpdateOrder.Result && result_UpdateOrder.Data)
                {
                    return Json(new ResultModel<bool>(0, "评论成功", true), JsonRequestBehavior.AllowGet);
                }
            }

            return Json(new ResultModel<bool>(1, "评论失败", true), JsonRequestBehavior.AllowGet);
        }

        public ActionResult MyCollection()
        {
            pbs_basic_MyCollectionService pbsBasicMyCollectionService = new pbs_basic_MyCollectionService();
            List<pbs_basic_MyCollectionView> myCollectionViewList = new List<pbs_basic_MyCollectionView>();
            ResultInfo<List<pbs_basic_MyCollectionView>> result_MyCollectionViewList = pbsBasicMyCollectionService.GetMyCollectionViewListByUserId(userid);
            if (result_MyCollectionViewList.Result && result_MyCollectionViewList.Data != null)
            {
                myCollectionViewList = result_MyCollectionViewList.Data.ToList();
            }

            ViewData["MyCollectionViewList"] = myCollectionViewList;
            return View();
        }

    }
}