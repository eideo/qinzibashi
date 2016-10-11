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
using WeiPay;

namespace PBS.Controllers
{
    public class ActivityController : BaseController
    {
        // GET: Activity
        public ActionResult Activity(string Id, string fromShareUserId)
        {
            pbs_basic_GoodsView pbsBasicGoodsView = new pbs_basic_GoodsView();
            int gid = Utility.Util.ParseHelper.ToInt(Id);
            pbs_basic_GoodsService pbsBasicGoodsService = new pbs_basic_GoodsService();
            ResultInfo<pbs_basic_GoodsView> result = pbsBasicGoodsService.GetGoodsModelViewById(gid);
            if (result.Result && result.Data != null)
            {
                pbsBasicGoodsView = result.Data;
            }

            if (!string.IsNullOrEmpty(fromShareUserId) && fromShareUserId!="0")
            {
                if (fromShareUserId.Contains(userid.ToString()))
                {
                    fromShareUserId = fromShareUserId.Replace(userid.ToString() + ",", "");
                }

                Session["FromShareUserId"] = fromShareUserId;
            }
            else
            {
                Session["FromShareUserId"] = userid+",";
            }
            string link= System.Configuration.ConfigurationManager.AppSettings["PhotoPicSourceHostUrl"].ToString() + "/Activity/Activity?Id=" + Id + "&fromShareUserId=" + Session["FromShareUserId"].ToString();
            ViewData["Link"] = link;

            #region 微信分享
            string token = string.Empty;
            string ticket = string.Empty;
            string timestamp = string.Empty;
            string nonceStr = string.Empty;
            string signature = string.Empty;
            if (Session["Token"] != null && Session["TokenTime"] != null)
            {
                DateTime dt1 = DateTime.Now;
                DateTime dt2 = Utility.Util.ParseHelper.ToDatetime(Session["TokenTime"].ToString());
                TimeSpan ts = dt1 - dt2;
                string tsSen = ts.Seconds.ToString();
                if (Utility.Util.ParseHelper.ToInt(tsSen) < 7200)
                {
                    token = Session["Token"].ToString();
                    ticket = Session["Ticket"].ToString();
                    timestamp = Session["TimeStamp"].ToString();
                    nonceStr = Session["NonceStr"].ToString();
                    signature = JSSDKHelper.GetSignature(ticket, nonceStr, timestamp, Request.Url.AbsoluteUri);
                    LogUtil.WriteLog("tsSen：" + tsSen);
                    LogUtil.WriteLog("Session Token：" + token);
                    LogUtil.WriteLog("Session Ticket：" + ticket);
                    LogUtil.WriteLog("Session TimeStamp：" + timestamp);
                    LogUtil.WriteLog("Session NonceStr：" + nonceStr);
                    LogUtil.WriteLog("Session SigNature：" + signature);
                }
            }
            if (string.IsNullOrEmpty(token))
            {
                #region 获取token
                string token_url = string.Format("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}", PayConfig.AppId, PayConfig.AppSecret);
                string returnToken = HttpUtil.Send("", token_url);
                var tokenModel = JsonConvert.DeserializeObject<tokenModel>(returnToken);
                token = tokenModel.access_token;
                #endregion

                #region 获取ticket
                string ticket_url = string.Format("https://api.weixin.qq.com/cgi-bin/ticket/getticket?access_token={0}&type=jsapi", token);
                string returnTicket = HttpUtil.Send("", ticket_url);
                var ticketModel = JsonConvert.DeserializeObject<ticketModel>(returnTicket);
                ticket = ticketModel.ticket;
                #endregion

                //获取时间戳
                timestamp = JSSDKHelper.GetTimestamp();
                //获取随机码
                nonceStr = JSSDKHelper.GetNoncestr();
                //获取签名
                signature = JSSDKHelper.GetSignature(ticket, nonceStr, timestamp, Request.Url.AbsoluteUri);
                Session["Token"] = token;
                Session["TokenTime"] = DateTime.Now;
                Session["Ticket"] = ticket;
                Session["TimeStamp"] = timestamp;
                Session["NonceStr"] = nonceStr;

                LogUtil.WriteLog("First Ticket：" + ticket);
                LogUtil.WriteLog("First TimeStamp：" + timestamp);
                LogUtil.WriteLog("First NonceStr：" + nonceStr);
                LogUtil.WriteLog("First SigNature：" + signature);
                LogUtil.WriteLog("Request Url：" + Request.Url.AbsoluteUri);
            }

            ViewData["AppId"] = PayConfig.AppId;
            ViewData["Timestamp"] = timestamp;
            ViewData["NonceStr"] = nonceStr;
            ViewData["Signature"] = signature;

            #endregion

            return View(pbsBasicGoodsView);
        }

        public ActionResult ActivityDetail(string Id)
        {
            ViewData["Goods"] = null;
            ViewData["ListComment"] = null;
            pbs_basic_Goods pbsBasicGoods = new pbs_basic_Goods();
            int gid = Utility.Util.ParseHelper.ToInt(Id);
            pbs_basic_GoodsService pbsBasicGoodsService = new pbs_basic_GoodsService();
            ResultInfo<pbs_basic_Goods> result_Goods = pbsBasicGoodsService.GetGoodsModelById(gid);
            if (result_Goods.Result && result_Goods.Data != null)
            {
                pbsBasicGoods = result_Goods.Data;
                ViewData["Goods"] = pbsBasicGoods;
            }

            List<pbs_basic_CommentView> listComment = new List<pbs_basic_CommentView>();
            pbs_basic_CommentService pbsBasicCommentService = new pbs_basic_CommentService();
            ResultInfo<List<pbs_basic_CommentView>> resultCommentList = pbsBasicCommentService.GetCommentListByGoodsID(gid);

            if (resultCommentList.Result && resultCommentList.Data != null)
            {
                listComment = resultCommentList.Data;
                ViewData["ListComment"] = listComment;
            }

            return View();
        }

        public ActionResult ActivitySearch()
        {
            List<pbs_basic_CommonSearch> listCommonSearch = new List<pbs_basic_CommonSearch>();
            pbs_basic_CommonSearchService pbsBasicCommonSearchService = new pbs_basic_CommonSearchService();
            ResultInfo<List<pbs_basic_CommonSearch>> result_CommenSearch = pbsBasicCommonSearchService.GetSearchList();
            if (result_CommenSearch.Result && result_CommenSearch.Data != null)
            {
                listCommonSearch = result_CommenSearch.Data;
                ViewData["ListCommonSearch"] = listCommonSearch;
            }

            List<pbs_basic_SearchHistoryView> listSearchHistoryView = new List<pbs_basic_SearchHistoryView>();
            pbs_basic_SearchHistoryService pbsBasicSearchHistoryService = new pbs_basic_SearchHistoryService();
            ResultInfo<List<pbs_basic_SearchHistoryView>> result_SearchHistroyView = pbsBasicSearchHistoryService.GetSearchHistoryViewList(userid);
            if (result_SearchHistroyView.Result && result_SearchHistroyView.Data != null)
            {
                listSearchHistoryView = result_SearchHistroyView.Data;
                ViewData["ListSearchHistory"] = listSearchHistoryView;
            }

            return View();
        }

        public ActionResult ActivityAll(string activityClassId, string ageRangeId, string regionId, string keyWords)
        {
            #region 北京地区列表
            pbsBasicRegionListResult resultBeijing = new pbsBasicRegionListResult();
            pbs_basic_RegionService pbsBasicRegionService = new pbs_basic_RegionService();
            ResultInfo<List<pbs_basic_Region>> resultinfo_beijing = pbsBasicRegionService.GetThisRegionList(110100);
            if (resultinfo_beijing.Result && resultinfo_beijing.Data != null)
            {
                resultBeijing.List = resultinfo_beijing.Data;
            }
            ViewData["ListBeijingRegion"] = resultBeijing.List;
            #endregion

            #region 年龄范围
            pbsBasicAgeRangeListResult resultAge = new pbsBasicAgeRangeListResult();
            pbs_basic_AgeRangeService pbsBasicAgeRangeService = new pbs_basic_AgeRangeService();
            ResultInfo<List<pbs_basic_AgeRange>> resultinfo_age = pbsBasicAgeRangeService.GetAllAgeRangeList();
            if (resultinfo_age.Result && resultinfo_age.Data != null)
            {
                resultAge.List = resultinfo_age.Data;
            }
            ViewData["ListAge"] = resultAge.List;
            #endregion

            //#region 活动类型
            //pbsBasicGoodsTypeListResult resultType = new pbsBasicGoodsTypeListResult();
            //pbs_basic_GoodsTypeService pbsBasicGoodsTypeService = new pbs_basic_GoodsTypeService();
            //ResultInfo<List<pbs_basic_GoodsType>> resultinfo_type = pbsBasicGoodsTypeService.GetAllGoodTypeList();
            //if (resultinfo_type.Result && resultinfo_type.Data != null)
            //{
            //    resultType.List = resultinfo_type.Data;
            //}
            //ViewData["ListType"] = resultType.List;
            //#endregion

            #region 活动筛选分类
            pbsBasicActivityClassListResult resultFilter = new pbsBasicActivityClassListResult();
            pbs_basic_ActivityClassService pbsBasicActivityClassService = new pbs_basic_ActivityClassService();
            ResultInfo<List<pbs_basic_ActivityClass>> resultinfo_filrerClass = pbsBasicActivityClassService.GetAllActivityClassList();
            if (resultinfo_filrerClass.Result && resultinfo_filrerClass.Data != null)
            {
                resultFilter.List = resultinfo_filrerClass.Data;
            }
            ViewData["ListFilterClass"] = resultFilter.List;
            #endregion

            //int tid = Utility.Util.ParseHelper.ToInt(goodsTypeId);
            int fid = Utility.Util.ParseHelper.ToInt(activityClassId);
            int aid = Utility.Util.ParseHelper.ToInt(ageRangeId);
            int rid = Utility.Util.ParseHelper.ToInt(regionId);

            if (fid == 0)
            {
                fid = -1;
            }
            if (aid == 0)
            {
                aid = -1;
            }
            if (rid == 0)
            {
                rid = -1;
            }

            List<pbs_basic_GoodsView> listGoods = new List<pbs_basic_GoodsView>();
            pbs_basic_GoodsService pbsBasicGoodsService = new pbs_basic_GoodsService();
            ResultInfo<List<pbs_basic_GoodsView>> result_activity = pbsBasicGoodsService.GetGoodsList(keyWords, -1, -1, aid, rid, 0, -1, -1, -1, fid);
            if (result_activity.Result && result_activity.Data != null)
            {
                listGoods = result_activity.Data.ToList();
            }

            ViewData["ListGoods"] = listGoods;

            return View();
        }

        public JsonResult GetAreaByParentId(string parentId)
        {

            int pid = Utility.Util.ParseHelper.ToInt(parentId);
            pbsBasicRegionListResult resultBeijing = new pbsBasicRegionListResult();
            pbs_basic_RegionService pbsBasicRegionService = new pbs_basic_RegionService();
            ResultInfo<List<pbs_basic_Region>> resultinfo_beijing = pbsBasicRegionService.GetThisRegionList(pid);
            if (resultinfo_beijing.Result && resultinfo_beijing.Data != null)
            {
                resultBeijing.List = resultinfo_beijing.Data;
            }

            return Json(resultBeijing.List, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ActivityWeek()
        {
            int benzhouClassId = Utility.Util.ParseHelper.ToInt(System.Configuration.ConfigurationManager.AppSettings["BenZhouActivity"]);
            List<pbs_basic_GoodsView> list = new List<pbs_basic_GoodsView>();
            pbs_basic_GoodsService pbsBasicGoodsService = new pbs_basic_GoodsService();
            ResultInfo<List<pbs_basic_GoodsView>> result_benzhou = pbsBasicGoodsService.GetGoodsList(string.Empty, benzhouClassId, -1, -1, -1, 0, -1, -1, -1, -1);
            if (result_benzhou.Result && result_benzhou.Data != null)
            {
                list = result_benzhou.Data.OrderByDescending(x => x.GoodsId).ToList();
            }
            ViewData["BenzhouList"] = list;
            return View();
        }

        public ActionResult ActivitySchedule()
        {
            List<pbs_basic_GoodsView> list = new List<pbs_basic_GoodsView>();
            pbs_basic_GoodsService pbsBasicGoodsService = new pbs_basic_GoodsService();
            ResultInfo<List<pbs_basic_GoodsView>> result_dangqi = pbsBasicGoodsService.GetGoodsList(string.Empty, -1, -1, -1, -1, 0, -1, -1, -1, -1);
            if (result_dangqi.Result && result_dangqi.Data != null)
            {
                list = result_dangqi.Data.OrderByDescending(x => x.GoodsId).ToList();
            }
            ViewData["DangqiList"] = list;
            return View();
        }

        public ActionResult ActivityBenefit()
        {
            int tehuiClassId = Utility.Util.ParseHelper.ToInt(System.Configuration.ConfigurationManager.AppSettings["TeHuiActivity"]);
            List<pbs_basic_GoodsView> list = new List<pbs_basic_GoodsView>();
            pbs_basic_GoodsService pbsBasicGoodsService = new pbs_basic_GoodsService();
            ResultInfo<List<pbs_basic_GoodsView>> result_tehui = pbsBasicGoodsService.GetGoodsList(string.Empty, tehuiClassId, -1, -1, -1, 0, -1, -1, -1, -1);
            if (result_tehui.Result && result_tehui.Data != null)
            {
                list = result_tehui.Data.OrderByDescending(x => x.GoodsId).ToList();
            }
            ViewData["TehuiList"] = list;
            return View();
        }

        public ActionResult ActivityGroupPurchase()
        {
            int tuanGouClassId = Utility.Util.ParseHelper.ToInt(System.Configuration.ConfigurationManager.AppSettings["TuanGouActivity"]);
            List<pbs_basic_GoodsView> list = new List<pbs_basic_GoodsView>();
            pbs_basic_GoodsService pbsBasicGoodsService = new pbs_basic_GoodsService();
            ResultInfo<List<pbs_basic_GoodsView>> result_tuangou = pbsBasicGoodsService.GetGoodsList(string.Empty, tuanGouClassId, -1, -1, -1, 0, -1, -1, -1, -1);
            if (result_tuangou.Result && result_tuangou.Data != null)
            {
                list = result_tuangou.Data.OrderByDescending(x => x.GoodsId).ToList();
            }
            ViewData["TuangouList"] = list;
            return View();
        }

        public ActionResult ActivityReviewHistory()
        {
            List<pbs_basic_ReviewHistory> listReviewHistory = new List<pbs_basic_ReviewHistory>();
            pbs_basic_ReviewHistoryService pbsBasicReviewHistoryService = new pbs_basic_ReviewHistoryService();
            ResultInfo<List<pbs_basic_ReviewHistory>> result_ReviewHistroy = pbsBasicReviewHistoryService.GetReviewHistoryList();
            if (result_ReviewHistroy.Result && result_ReviewHistroy.Data != null)
            {
                listReviewHistory = result_ReviewHistroy.Data;
            }

            ViewData["ReviewHistoryList"] = listReviewHistory;
            return View();
        }

        public ActionResult ActivityReviewHistoryDetail(string Id)
        {
            int rid = Utility.Util.ParseHelper.ToInt(Id);
            pbs_basic_ReviewHistory ReviewHistory = new pbs_basic_ReviewHistory();
            pbs_basic_ReviewHistoryService pbsBasicReviewHistoryService = new pbs_basic_ReviewHistoryService();
            ResultInfo<pbs_basic_ReviewHistory> result_ReviewHistroy = pbsBasicReviewHistoryService.GetReviewHistoryModelById(rid);
            if (result_ReviewHistroy.Result && result_ReviewHistroy.Data != null)
            {
                ReviewHistory = result_ReviewHistroy.Data;
            }

            ViewData["ReviewHistory"] = ReviewHistory;
            return View();
        }

        public ActionResult Order(string Id, string memberId)
        {
            int mid = 0;
            //商品信息
            pbs_basic_GoodsView pbsBasicGoodsView = new pbs_basic_GoodsView();
            int gid = Utility.Util.ParseHelper.ToInt(Id);
            pbs_basic_GoodsService pbsBasicGoodsService = new pbs_basic_GoodsService();
            ResultInfo<pbs_basic_GoodsView> result = pbsBasicGoodsService.GetGoodsModelViewById(gid);
            if (result.Result && result.Data != null)
            {
                pbsBasicGoodsView = result.Data;
                ViewData["GoodsView"] = pbsBasicGoodsView;
            }

            //套餐信息
            List<pbs_basic_GoodsPackage> goodsPackageList = new List<pbs_basic_GoodsPackage>();
            pbs_basic_GoodsPackageService pbsBasicGoodsPackageService = new pbs_basic_GoodsPackageService();
            ResultInfo<List<pbs_basic_GoodsPackage>> resultGoodsPackageViewList = pbsBasicGoodsPackageService.GetAllGoodsPackageListByGoodsTypeId(pbsBasicGoodsView.GoodsTypeId);
            if (resultGoodsPackageViewList.Result && resultGoodsPackageViewList.Data != null)
            {
                goodsPackageList = resultGoodsPackageViewList.Data;
                ViewData["GoodsPackageList"] = goodsPackageList;
            }

            //用户和成员信息
            pbs_basic_Users users = new pbs_basic_Users();
            pbs_basic_UsersService pbsBasicUsersService = new pbs_basic_UsersService();
            ResultInfo<pbs_basic_Users> result_Users = pbsBasicUsersService.GetUsersModelById(userid);
            if (result_Users.Result && result_Users.Data != null)
            {
                users = result_Users.Data;
                ViewData["Users"] = users;
            }

            //List<pbs_basic_Members> listMembers = new List<pbs_basic_Members>();
            //pbs_basic_MembersService pbsBasicMembersService = new pbs_basic_MembersService();
            //ResultInfo<List<pbs_basic_Members>> result_Members = pbsBasicMembersService.GetMembersListByUserId(userid);
            //if (result_Members.Result && result_Members.Data != null)
            //{
            //    listMembers = result_Members.Data;
            //    ViewData["Members"] = listMembers;
            //}
            if (!string.IsNullOrWhiteSpace(memberId))
            {
                mid = Utility.Util.ParseHelper.ToInt(memberId);
            }
            pbs_basic_Members members = new pbs_basic_Members();
            pbs_basic_MembersService pbsBasicMembersService = new pbs_basic_MembersService();
            ResultInfo<pbs_basic_Members> result_Members = pbsBasicMembersService.GetMembersModelById(mid);
            if (result_Members.Result && result_Members.Data != null)
            {
                members = result_Members.Data;
                ViewData["Members"] = members;
            }

            ViewData["MemberId"] = mid;

            return View();
        }

        public JsonResult AddOrderAjax(string goodsId, string count, string visitTime, string orderMemberId, string orderPrice, string voucherId, string userName, string phone, string goodsPackageId)
        {
            string orderId = string.Empty;
            if (Utility.Util.ParseHelper.ToInt(count) == 0)
            {
                count = "1";
            }

            int gid = Utility.Util.ParseHelper.ToInt(goodsId);
            pbs_basic_OrderService pbsBasicOrderService = new pbs_basic_OrderService();
            pbs_basic_OrderMemberService pbsBasicOrderMemberService = new pbs_basic_OrderMemberService();

            ResultInfo<bool> result_AddOrder = pbsBasicOrderService.AddOrder(gid, Utility.Util.ParseHelper.ToInt(count), Utility.Util.ParseHelper.ToDatetime(visitTime), userid,
                Utility.Util.ParseHelper.ToInt(orderMemberId), Utility.Util.ParseHelper.ToDecimal(orderPrice), Utility.Util.ParseHelper.ToInt(voucherId), Utility.Util.ParseHelper.ToInt(OrderEnum.OrderStatu.待付款),
                DateTime.Now, DateTime.Now, 1, string.Empty, userName, phone, Utility.Util.ParseHelper.ToInt(goodsPackageId), ref orderId);
            if (result_AddOrder.Result && result_AddOrder.Data)
            {
                ResultInfo<bool> result_AddOrderMember = pbsBasicOrderMemberService.AddOrderMember(Utility.Util.ParseHelper.ToInt(orderMemberId), DateTime.Now, DateTime.Now, 0, Utility.Util.ParseHelper.ToInt(orderId), string.Empty);
                if (result_AddOrderMember.Result && result_AddOrderMember.Data)
                {
                    Session["OrderID"] = orderId;
                    return Json(new ResultModel<bool>(0, orderId, true), JsonRequestBehavior.AllowGet);
                }
            }

            return Json(new ResultModel<bool>(1, "添加订单失败", true), JsonRequestBehavior.AllowGet);
        }

        public ActionResult ActivityPosition(string Id)
        {
            pbs_basic_GoodsView pbsBasicGoodsView = new pbs_basic_GoodsView();
            int gid = Utility.Util.ParseHelper.ToInt(Id);
            pbs_basic_GoodsService pbsBasicGoodsService = new pbs_basic_GoodsService();
            ResultInfo<pbs_basic_GoodsView> result = pbsBasicGoodsService.GetGoodsModelViewById(gid);
            if (result.Result && result.Data != null)
            {
                pbsBasicGoodsView = result.Data;
            }
            return View(pbsBasicGoodsView);
        }

        public ActionResult ChoseMember(string Id, string memberId)
        {
            int gid = 0;
            List<pbs_basic_Members> listMembers = new List<pbs_basic_Members>();
            pbs_basic_MembersService pbsBasicMembersService = new pbs_basic_MembersService();
            ResultInfo<List<pbs_basic_Members>> result_Members = pbsBasicMembersService.GetMembersListByUserId(userid);
            if (result_Members.Result && result_Members.Data != null)
            {
                listMembers = result_Members.Data;
            }

            if (!string.IsNullOrWhiteSpace(Id))
            {
                gid = Utility.Util.ParseHelper.ToInt(Id);
            }

            ViewData["GoodsId"] = gid;
            ViewData["ChoseMemberId"] = memberId;
            ViewData["ListMembers"] = listMembers;
            return View();
        }

        public ActionResult ChoseVoucher(string orderPrice)
        {
            List<pbs_basic_MyVoucherView> listMyVoucher = new List<pbs_basic_MyVoucherView>();
            pbs_basic_MyVoucherService pbsBasicMyVoucherService = new pbs_basic_MyVoucherService();
            ResultInfo<List<pbs_basic_MyVoucherView>> result_listMyVoucher = pbsBasicMyVoucherService.GetMyVoucherViewList(userid);
            if (result_listMyVoucher.Result && result_listMyVoucher.Data != null)
            {
                listMyVoucher = result_listMyVoucher.Data;
            }

            ViewData["ListMyVoucher"] = listMyVoucher;
            ViewData["OrderPrice"] = orderPrice;

            return View();
        }

        public JsonResult ChoseVoucherAjax(string vid,string orderPrice)
        {
            decimal oPrice = Utility.Util.ParseHelper.ToDecimal(orderPrice);
            if (!string.IsNullOrEmpty(vid))
            {
                pbs_basic_VoucherService pbsBasicVoucherService = new pbs_basic_VoucherService();
                ResultInfo<pbs_basic_Voucher> result_Voucher = pbsBasicVoucherService.GetVoucherModelById(Utility.Util.ParseHelper.ToInt(vid));
                if (result_Voucher.Result && result_Voucher.Data != null)
                {
                    if (result_Voucher.Data.VoucherType == 1)
                    {
                        if (result_Voucher.Data.SRPrice <= oPrice)
                        {
                            Session["VoucherId"] = vid;
                            return Json(new ResultModel<bool>(0, vid, true), JsonRequestBehavior.AllowGet);
                        }
                    }
                    else if (result_Voucher.Data.VoucherType == 2)
                    {
                        if (result_Voucher.Data.VoucherPrice < oPrice)
                        {
                            Session["VoucherId"] = vid;
                            return Json(new ResultModel<bool>(0, vid, true), JsonRequestBehavior.AllowGet);
                        }
                    }
                } 
            }

            return Json(new ResultModel<bool>(1, "不符合规则,选择优惠券失败", true), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Buy(string orderId, string voucherId)
        {
            int oId = Utility.Util.ParseHelper.ToInt(orderId);
            int vId = Utility.Util.ParseHelper.ToInt(voucherId);
            string voucherName = string.Empty;
            pbs_basic_GoodsView pbsBasicGoodsView = new pbs_basic_GoodsView();
            pbs_basic_Order order = new pbs_basic_Order();
            pbs_basic_Members members = new pbs_basic_Members();
            pbs_basic_Voucher voucher = new pbs_basic_Voucher();
            //pbs_basic_OrderMember orderMember = new pbs_basic_OrderMember();
            pbs_basic_MembersService pbsBasicMembersService = new pbs_basic_MembersService();
            pbs_basic_OrderService pbsBasicOrderService = new pbs_basic_OrderService();
            pbs_basic_GoodsService pbsBasicGoodsService = new pbs_basic_GoodsService();
            pbs_basic_VoucherService pbsBasicVoucherService = new pbs_basic_VoucherService();
            //pbs_basic_OrderMemberService pbsBasicOrderMemberService = new pbs_basic_OrderMemberService();


            ResultInfo<pbs_basic_Order> result_order = pbsBasicOrderService.GetOrderModelById(oId);
            if (result_order.Result && result_order.Data != null)
            {
                order = result_order.Data;
                ResultInfo<pbs_basic_GoodsView> result_GoodsView = pbsBasicGoodsService.GetGoodsModelViewById(order.GoodsId);
                if (result_GoodsView.Result && result_GoodsView.Data != null)
                {
                    pbsBasicGoodsView = result_GoodsView.Data;
                }

                ResultInfo<pbs_basic_Members> result_Member = pbsBasicMembersService.GetMembersModelById(Utility.Util.ParseHelper.ToInt(order.OrderMemberId));
                if (result_Member.Result && result_Member.Data != null)
                {
                    members = result_Member.Data;
                }

                if (vId != 0)
                {
                    ResultInfo<pbs_basic_Voucher> result_Voucher = pbsBasicVoucherService.GetVoucherModelById(vId);
                    if (result_Voucher.Result && result_Voucher.Data != null)
                    {
                        voucherName = result_Voucher.Data.VoucherPrice.ToString();
                    }
                }

            }

            ViewData["GoodsView"] = pbsBasicGoodsView;
            ViewData["Order"] = order;
            ViewData["Members"] = members;
            ViewData["VoucherId"] = vId;
            ViewData["VoucherName"] = voucherName;
            return View();
        }

        public JsonResult BuyAjax(string orderId, string price, string voucherId)
        {
            int oId = Utility.Util.ParseHelper.ToInt(orderId);

            pbs_basic_OrderService pbsBasicOrderService = new pbs_basic_OrderService();

            ResultInfo<bool> result_UpdateOrder = pbsBasicOrderService.UpdateOrders(2, Utility.Util.ParseHelper.ToDecimal(price), Utility.Util.ParseHelper.ToInt(voucherId), oId);
            if (result_UpdateOrder.Result && result_UpdateOrder.Data)
            {
                return Json(new ResultModel<bool>(0, "购买成功", true), JsonRequestBehavior.AllowGet);
            }

            return Json(new ResultModel<bool>(1, "购买失败", true), JsonRequestBehavior.AllowGet);
        }

        public ActionResult PaySuccess(string billNo)
        {
            if (!string.IsNullOrEmpty(billNo))
            {
                int oId = Utility.Util.ParseHelper.ToInt(billNo);
                int gid = 0;
                decimal orderPrice = 0;
                string goodsMainImgUrl = string.Empty;
                string goodsName = string.Empty;
                pbs_basic_Order order = new pbs_basic_Order();
                pbs_basic_OrderService pbsBasicOrderService = new pbs_basic_OrderService();
                pbs_basic_GoodsService pbsBasicGoodsService = new pbs_basic_GoodsService();
                pbs_basic_MyVoucherService pbsBasicMyVoucherService = new pbs_basic_MyVoucherService();
                pbs_basic_VoucherService pbsBasicVoucherService = new pbs_basic_VoucherService();

                ResultInfo<bool> result_UpdateOrder = pbsBasicOrderService.UpdateOrders(2, oId);
                if (result_UpdateOrder.Result && result_UpdateOrder.Data)
                {
                    ResultInfo<pbs_basic_Order> result_order = pbsBasicOrderService.GetOrderModelById(oId);
                    if (result_order.Result && result_order.Data != null)
                    {
                        gid = result_order.Data.GoodsId;
                        orderPrice = result_order.Data.OrderPrice;
                        ResultInfo<pbs_basic_GoodsView> result = pbsBasicGoodsService.GetGoodsModelViewById(gid);
                        if (result.Result && result.Data != null)
                        {
                            goodsMainImgUrl = result.Data.GoodsMainImgUrl;
                            goodsName = result.Data.GoodsName;
                        }

                        //减少活动数量
                        ResultInfo<bool> result_updateGoodsCount = pbsBasicGoodsService.UpdateGoodsCountMinus(result_order.Data.GoodsId);

                        //更新优惠券使用
                        ResultInfo<bool> result_UpdateMyVoucherIsUsed = pbsBasicMyVoucherService.UpdateMyVoucherIsUsed(1, result_order.Data.VoucherId);

                        if (result_order.Data.VoucherId != 0)
                        {
                            ResultInfo<pbs_basic_Voucher> result_Voucher = pbsBasicVoucherService.GetVoucherModelById(result_order.Data.VoucherId);
                            if (result_Voucher.Result && result_Voucher.Data != null)
                            {
                                orderPrice = orderPrice- result_Voucher.Data.VoucherPrice;

                                //更新订单价格
                                ResultInfo<bool> result_UpdateOrderPrice = pbsBasicOrderService.UpdateOrderPrice(orderPrice, oId);
                            }

                        }

                    }
                }

                ViewData["OrderPrice"] = orderPrice;

                #region 分销
                if (!string.IsNullOrEmpty(FromShareUserId))
                {
                    FXMethod(gid, oId, orderPrice);
                }
                #endregion

                //#region 微信分享
                //string token = string.Empty;
                //string ticket = string.Empty;
                //string timestamp = string.Empty;
                //string nonceStr = string.Empty;
                //string signature = string.Empty;
                //if (Session["Token"] != null && Session["TokenTime"] != null)
                //{
                //    DateTime dt1 = DateTime.Now;
                //    DateTime dt2 = Utility.Util.ParseHelper.ToDatetime(Session["TokenTime"].ToString());
                //    TimeSpan ts = dt1 - dt2;
                //    string tsSen = ts.Seconds.ToString();
                //    if (Utility.Util.ParseHelper.ToInt(tsSen) < 7200)
                //    {
                //        token = Session["Token"].ToString();
                //        ticket = Session["Ticket"].ToString();
                //        timestamp = Session["TimeStamp"].ToString();
                //        nonceStr = Session["NonceStr"].ToString();
                //        //signature = Session["SigNature"].ToString();
                //        signature = JSSDKHelper.GetSignature(ticket, nonceStr, timestamp, Request.Url.AbsoluteUri);
                //        LogUtil.WriteLog("tsSen：" + tsSen);
                //        LogUtil.WriteLog("Session Token：" + token);
                //        LogUtil.WriteLog("Session Ticket：" + ticket);
                //        LogUtil.WriteLog("Session TimeStamp：" + timestamp);
                //        LogUtil.WriteLog("Session NonceStr：" + nonceStr);
                //        LogUtil.WriteLog("Session SigNature：" + signature);
                //    }
                //}
                //if (string.IsNullOrEmpty(token))
                //{
                //    #region 获取token
                //    string token_url = string.Format("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}", PayConfig.AppId, PayConfig.AppSecret);
                //    string returnToken = HttpUtil.Send("", token_url);
                //    var tokenModel = JsonConvert.DeserializeObject<tokenModel>(returnToken);
                //    token = tokenModel.access_token;
                //    #endregion

                //    #region 获取ticket
                //    string ticket_url = string.Format("https://api.weixin.qq.com/cgi-bin/ticket/getticket?access_token={0}&type=jsapi", token);
                //    string returnTicket = HttpUtil.Send("", ticket_url);
                //    var ticketModel = JsonConvert.DeserializeObject<ticketModel>(returnTicket);
                //    ticket = ticketModel.ticket;
                //    #endregion

                //    //获取时间戳
                //    timestamp = JSSDKHelper.GetTimestamp();
                //    //获取随机码
                //    nonceStr = JSSDKHelper.GetNoncestr();
                //    //获取签名
                //    signature = JSSDKHelper.GetSignature(ticket, nonceStr, timestamp, Request.Url.AbsoluteUri);
                //    Session["Token"] = token;
                //    Session["TokenTime"] = DateTime.Now;
                //    Session["Ticket"] = ticket;
                //    Session["TimeStamp"] = timestamp;
                //    Session["NonceStr"] = nonceStr;
                //    //Session["SigNature"] = signature;

                //    LogUtil.WriteLog("First Ticket：" + ticket);
                //    LogUtil.WriteLog("First TimeStamp：" + timestamp);
                //    LogUtil.WriteLog("First NonceStr：" + nonceStr);
                //    LogUtil.WriteLog("First SigNature：" + signature);
                //    LogUtil.WriteLog("Request Url：" + Request.Url.AbsoluteUri);
                //}

                //ViewData["AppId"] = PayConfig.AppId;
                //ViewData["Timestamp"] = timestamp;
                //ViewData["NonceStr"] = nonceStr;
                //ViewData["Signature"] = signature;

                //#endregion

            }
            return View();
        }

        public ActionResult PayError()
        {
            return View();
        }

        public JsonResult AddMyCollectionAjax(string goodsId)
        {
            int gid = Utility.Util.ParseHelper.ToInt(goodsId);
            pbs_basic_MyCollectionService pbsBasicMyCollectionService = new pbs_basic_MyCollectionService();
            ResultInfo<bool> result_AddMyCollection = pbsBasicMyCollectionService.AddMyCollection(userid, gid, DateTime.Now, DateTime.Now, 0, string.Empty);
            if (result_AddMyCollection.Result && result_AddMyCollection.Data)
            {
                return Json(new ResultModel<bool>(0, "添加收藏成功", true), JsonRequestBehavior.AllowGet);
            }

            return Json(new ResultModel<bool>(1, "添加收藏失败", true), JsonRequestBehavior.AllowGet);
        }

        public ActionResult TestShare()
        {
            #region 微信分享
            string token = string.Empty;
            string ticket = string.Empty;
            string timestamp = string.Empty;
            string nonceStr = string.Empty;
            string signature = string.Empty;
            if (Session["Token"] != null && Session["TokenTime"] != null)
            {
                DateTime dt1 = DateTime.Now;
                DateTime dt2 = Utility.Util.ParseHelper.ToDatetime(Session["TokenTime"].ToString());
                TimeSpan ts = dt1 - dt2;
                string tsSen = ts.Seconds.ToString();
                if (Utility.Util.ParseHelper.ToInt(tsSen) < 7200)
                {
                    token = Session["Token"].ToString();
                    ticket = Session["Ticket"].ToString();
                    timestamp = Session["TimeStamp"].ToString();
                    nonceStr = Session["NonceStr"].ToString();
                    //signature = Session["SigNature"].ToString();
                    signature = JSSDKHelper.GetSignature(ticket, nonceStr, timestamp, Request.Url.AbsoluteUri);
                    LogUtil.WriteLog("tsSen：" + tsSen);
                    LogUtil.WriteLog("Session Token：" + token);
                    LogUtil.WriteLog("Session Ticket：" + ticket);
                    LogUtil.WriteLog("Session TimeStamp：" + timestamp);
                    LogUtil.WriteLog("Session NonceStr：" + nonceStr);
                    LogUtil.WriteLog("Session SigNature：" + signature);
                }
            }
            if (string.IsNullOrEmpty(token))
            {
                #region 获取token
                string token_url = string.Format("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}", PayConfig.AppId, PayConfig.AppSecret);
                string returnToken = HttpUtil.Send("", token_url);
                var tokenModel = JsonConvert.DeserializeObject<tokenModel>(returnToken);
                token = tokenModel.access_token;
                #endregion

                #region 获取ticket
                string ticket_url = string.Format("https://api.weixin.qq.com/cgi-bin/ticket/getticket?access_token={0}&type=jsapi", token);
                string returnTicket = HttpUtil.Send("", ticket_url);
                var ticketModel = JsonConvert.DeserializeObject<ticketModel>(returnTicket);
                ticket = ticketModel.ticket;
                #endregion

                //获取时间戳
                timestamp = JSSDKHelper.GetTimestamp();
                //获取随机码
                nonceStr = JSSDKHelper.GetNoncestr();
                //获取签名
                signature = JSSDKHelper.GetSignature(ticket, nonceStr, timestamp, Request.Url.AbsoluteUri);
                Session["Token"] = token;
                Session["TokenTime"] = DateTime.Now;
                Session["Ticket"] = ticket;
                Session["TimeStamp"] = timestamp;
                Session["NonceStr"] = nonceStr;
                //Session["SigNature"] = signature;

                LogUtil.WriteLog("First Ticket：" + ticket);
                LogUtil.WriteLog("First TimeStamp：" + timestamp);
                LogUtil.WriteLog("First NonceStr：" + nonceStr);
                LogUtil.WriteLog("First SigNature：" + signature);
            }

            ViewData["AppId"] = PayConfig.AppId;
            ViewData["Timestamp"] = timestamp;
            ViewData["NonceStr"] = nonceStr;
            ViewData["Signature"] = signature;

            #endregion
            return View();
        }

        public ActionResult UserNotice()
        {
            return View();
        }

        public ActionResult ChoseMyMembersDetail(string Id)
        {
            int gid = 0;
            if (!string.IsNullOrWhiteSpace(Id))
            {
                gid = Utility.Util.ParseHelper.ToInt(Id);
            }

            pbs_basic_Members members = new pbs_basic_Members();
            ViewData["Members"] = members;

            ViewData["GoodsId"] = gid;
            ViewData["ThisTitle"] = "添加成员信息";
            return View();
        }

        #region 分销
        private void FXMethod(int gid,int oid,decimal orderPrice)
        {
            //string[] fromShareOrderIds = FromShareOrderId.Split(',');
            string[] fromShareUserIds = FromShareUserId.TrimEnd(',').Split(',');

            pbs_basic_DistributionChannelsService pbsBasicDistributionChannelsService = new pbs_basic_DistributionChannelsService();
            //获取分销级别百分比
            ResultInfo<pbs_basic_DistributionChannels> resultinfoDC = pbsBasicDistributionChannelsService.GetDCModelById(1);
            if (resultinfoDC.Result && resultinfoDC.Data != null)
            {
                decimal profit1 = Utility.Util.ParseHelper.ToDecimal(orderPrice) * resultinfoDC.Data.DC1 * 0.01m;
                decimal profit2 = Utility.Util.ParseHelper.ToDecimal(orderPrice) * resultinfoDC.Data.DC2 * 0.01m;
                decimal profit3 = Utility.Util.ParseHelper.ToDecimal(orderPrice) * resultinfoDC.Data.DC3 * 0.01m;

                if (fromShareUserIds.Count() == 1)
                {
                    FX1(gid, oid,fromShareUserIds, profit1);
                }
                else if (fromShareUserIds.Count() == 2)
                {
                    FX2(gid, oid, fromShareUserIds, profit1, profit2);
                }
                else if (fromShareUserIds.Count() == 3)
                {
                    FX3(gid, oid, fromShareUserIds, profit1, profit2, profit3);
                }
                else
                {

                }
            }
        }

        private void FX1(int gid,int oid, string[] fromShareUserIds, decimal profit1)
        {
            string shareId = string.Empty;
            pbs_basic_MyShareProfitService pbsBasicMyShareProfitService = new pbs_basic_MyShareProfitService();
            ResultInfo<bool> resultIsExistByFromShareOrderId1 = pbsBasicMyShareProfitService.IsExistByFromShareOrderIdAndShareLevel(Utility.Util.ParseHelper.ToInt(Utility.Util.ParseHelper.ToInt(fromShareUserIds[0])),1);
            if (resultIsExistByFromShareOrderId1.Result && !resultIsExistByFromShareOrderId1.Data)
            {
                //一级分销
                ResultInfo<bool> resultAddMyShareProfit1 = pbsBasicMyShareProfitService.AddMyShareProfit(
                    Utility.Util.ParseHelper.ToInt(gid), 1, profit1, Utility.Util.ParseHelper.ToInt(fromShareUserIds[0]), 
                    0, oid, DateTime.Now, DateTime.Now, 0, string.Empty, ref shareId);
            }  
        }

        private void FX2(int gid, int oid, string[] fromShareUserIds, decimal profit1, decimal profit2)
        {
            string shareId = string.Empty;
            pbs_basic_MyShareProfitService pbsBasicMyShareProfitService = new pbs_basic_MyShareProfitService();
            ResultInfo<bool> resultIsExistByFromShareOrderId1 = pbsBasicMyShareProfitService.IsExistByFromShareOrderIdAndShareLevel(Utility.Util.ParseHelper.ToInt(Utility.Util.ParseHelper.ToInt(fromShareUserIds[0])),2);
            if (resultIsExistByFromShareOrderId1.Result && !resultIsExistByFromShareOrderId1.Data)
            {
                //二级级分销
                ResultInfo<bool> resultAddMyShareProfit1 = pbsBasicMyShareProfitService.AddMyShareProfit(
                    Utility.Util.ParseHelper.ToInt(gid), 2, profit2, Utility.Util.ParseHelper.ToInt(fromShareUserIds[0]),
                    0, oid, DateTime.Now, DateTime.Now, 0, string.Empty, ref shareId);
            }

            ResultInfo<bool> resultIsExistByFromShareOrderId2 = pbsBasicMyShareProfitService.IsExistByFromShareOrderIdAndShareLevel(Utility.Util.ParseHelper.ToInt(Utility.Util.ParseHelper.ToInt(fromShareUserIds[1])),1);
            if (resultIsExistByFromShareOrderId2.Result && !resultIsExistByFromShareOrderId2.Data)
            {
                //一级分销
                ResultInfo<bool> resultAddMyShareProfit2 = pbsBasicMyShareProfitService.AddMyShareProfit(
                    Utility.Util.ParseHelper.ToInt(gid), 1, profit1, Utility.Util.ParseHelper.ToInt(fromShareUserIds[1]),
                    0, oid, DateTime.Now, DateTime.Now, 0, string.Empty, ref shareId);
            }
        }

        private void FX3(int gid, int oid, string[] fromShareUserIds, decimal profit1, decimal profit2, decimal profit3)
        {
            string shareId = string.Empty;
            pbs_basic_MyShareProfitService pbsBasicMyShareProfitService = new pbs_basic_MyShareProfitService();

            ResultInfo<bool> resultIsExistByFromShareOrderId1 = pbsBasicMyShareProfitService.IsExistByFromShareOrderIdAndShareLevel(Utility.Util.ParseHelper.ToInt(Utility.Util.ParseHelper.ToInt(fromShareUserIds[0])),3);
            if (resultIsExistByFromShareOrderId1.Result && !resultIsExistByFromShareOrderId1.Data)
            {
                //三级级分销
                ResultInfo<bool> resultAddMyShareProfit1 = pbsBasicMyShareProfitService.AddMyShareProfit(
                    Utility.Util.ParseHelper.ToInt(gid), 3, profit3, Utility.Util.ParseHelper.ToInt(fromShareUserIds[0]),
                    0, oid, DateTime.Now, DateTime.Now, 0, string.Empty, ref shareId);
            }

            ResultInfo<bool> resultIsExistByFromShareOrderId2 = pbsBasicMyShareProfitService.IsExistByFromShareOrderIdAndShareLevel(Utility.Util.ParseHelper.ToInt(Utility.Util.ParseHelper.ToInt(fromShareUserIds[0])),2);
            if (resultIsExistByFromShareOrderId2.Result && !resultIsExistByFromShareOrderId2.Data)
            {
                //二级级分销
                ResultInfo<bool> resultAddMyShareProfit2 = pbsBasicMyShareProfitService.AddMyShareProfit(
                    Utility.Util.ParseHelper.ToInt(gid), 2, profit2, Utility.Util.ParseHelper.ToInt(fromShareUserIds[1]),
                    0, oid, DateTime.Now, DateTime.Now, 0, string.Empty, ref shareId);
            }

            ResultInfo<bool> resultIsExistByFromShareOrderId3 = pbsBasicMyShareProfitService.IsExistByFromShareOrderIdAndShareLevel(Utility.Util.ParseHelper.ToInt(Utility.Util.ParseHelper.ToInt(fromShareUserIds[1])),1);
            if (resultIsExistByFromShareOrderId3.Result && !resultIsExistByFromShareOrderId3.Data)
            {
                //一级分销
                ResultInfo<bool> resultAddMyShareProfit3 = pbsBasicMyShareProfitService.AddMyShareProfit(
                    Utility.Util.ParseHelper.ToInt(gid), 1, profit1, Utility.Util.ParseHelper.ToInt(fromShareUserIds[2]),
                    0, oid, DateTime.Now, DateTime.Now, 0, string.Empty, ref shareId);
            }
        }

        #endregion

    }
}