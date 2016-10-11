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
    public class ContentController : Controller
    {
        // GET: Content

        #region 往期回顾
        public ActionResult ReviewList()
        {
            pbsBasicReviewHistoryListResult result = new pbsBasicReviewHistoryListResult();
            pbs_basic_ReviewHistoryService pbsReviewHistoryService = new pbs_basic_ReviewHistoryService();
            ResultInfo<List<pbs_basic_ReviewHistory>> resultinfo = pbsReviewHistoryService.GetReviewHistoryList();
            if (resultinfo.Result && resultinfo.Data != null)
            {
                result.List = resultinfo.Data;
            }

            return View(result);
        }

        public ActionResult ReviewAdd(string reviewId)
        {
            pbs_basic_ReviewHistory pbsReviewHistory = new pbs_basic_ReviewHistory();
            pbsReviewHistory.ReviewId = 0;
            pbsReviewHistory.ReviewTitle=string.Empty;
            pbsReviewHistory.ReviewContent = string.Empty;
            pbsReviewHistory.ReviewUrl= string.Empty;
            pbsReviewHistory.CreateTime = DateTime.Now;
            pbsReviewHistory.UpdateTime = DateTime.Now;
            pbsReviewHistory.CreatorId = 0;
            pbsReviewHistory.Remark = string.Empty;

            pbs_basic_ReviewHistoryService pbsReviewHistoryService = new pbs_basic_ReviewHistoryService();

            if (!string.IsNullOrEmpty(reviewId))
            {
                int rid = Utility.Util.ParseHelper.ToInt(reviewId);
                ResultInfo<pbs_basic_ReviewHistory> resultItem = pbsReviewHistoryService.GetReviewHistoryModelById(rid);
                if (resultItem.Result && resultItem.Data != null)
                {
                    pbsReviewHistory.ReviewId = resultItem.Data.ReviewId;
                    pbsReviewHistory.ReviewTitle = resultItem.Data.ReviewTitle;
                    pbsReviewHistory.ReviewContent = resultItem.Data.ReviewContent;
                    pbsReviewHistory.ReviewUrl = resultItem.Data.ReviewUrl;
                    pbsReviewHistory.CreateTime = resultItem.Data.CreateTime;
                    pbsReviewHistory.UpdateTime = resultItem.Data.UpdateTime;
                    pbsReviewHistory.CreatorId = resultItem.Data.CreatorId;
                    pbsReviewHistory.Remark = resultItem.Data.Remark;
                }
                ViewBag.PageTitle = "修改往期回顾";
            }
            else
            {
                ViewBag.PageTitle = "添加往期回顾";
            }

            return View(pbsReviewHistory);
        }

        public JsonResult ReviewAddAjax(string reviewTitle, string reviewContent, string reviewUrl, string createTime, string updateTime, string creatorId, string remark)
        {
            reviewContent = HttpUtility.UrlDecode(reviewContent);
            if (string.IsNullOrEmpty(reviewTitle))
            {
                return Json(new ResultModel<bool>(1, "请输入往期回顾标题", false), JsonRequestBehavior.AllowGet);
            }

            if (string.IsNullOrEmpty(reviewContent))
            {
                return Json(new ResultModel<bool>(2, "请输入往期回顾内容", false), JsonRequestBehavior.AllowGet);
            }

            if (string.IsNullOrEmpty(reviewUrl))
            {
                return Json(new ResultModel<bool>(3, "请选择图片文件", false), JsonRequestBehavior.AllowGet);
            }

            pbs_basic_ReviewHistoryService pbsReviewHistoryService = new pbs_basic_ReviewHistoryService();

            ResultInfo<bool> resultAddReviewHistory = pbsReviewHistoryService.AddReviewHistory(reviewTitle, reviewContent, reviewUrl,
                Utility.Util.ParseHelper.ToDatetime(createTime), Utility.Util.ParseHelper.ToDatetime(updateTime),
                     Utility.Util.ParseHelper.ToInt(creatorId), remark);
            if (resultAddReviewHistory.Result && resultAddReviewHistory.Data)
            {
                return Json(new ResultModel<bool>(0, "添加往期回顾成功", true), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new ResultModel<bool>(8, "添加往期回顾失败", false), JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult ReviewUpdateAjax(string reviewTitle, string reviewContent, string reviewUrl, string createTime, string updateTime, string creatorId, string remark, string reviewId)
        {
            reviewContent = HttpUtility.UrlDecode(reviewContent);
            if (string.IsNullOrEmpty(reviewTitle))
            {
                return Json(new ResultModel<bool>(1, "请输入往期回顾标题", false), JsonRequestBehavior.AllowGet);
            }

            if (string.IsNullOrEmpty(reviewContent))
            {
                return Json(new ResultModel<bool>(2, "请输入往期回顾内容", false), JsonRequestBehavior.AllowGet);
            }

            if (string.IsNullOrEmpty(reviewUrl))
            {
                return Json(new ResultModel<bool>(3, "请选择图片文件", false), JsonRequestBehavior.AllowGet);
            }

            pbs_basic_ReviewHistoryService pbsReviewHistoryService = new pbs_basic_ReviewHistoryService();

            if (!string.IsNullOrEmpty(reviewId))
            {
                int rid = Utility.Util.ParseHelper.ToInt(reviewId);

                ResultInfo<bool> resultEditReview = pbsReviewHistoryService.UpdateReviewHistory(reviewTitle, reviewContent, reviewUrl,
                Utility.Util.ParseHelper.ToDatetime(createTime), Utility.Util.ParseHelper.ToDatetime(updateTime),
                     Utility.Util.ParseHelper.ToInt(creatorId), remark, rid);
                if (resultEditReview.Result && resultEditReview.Data)
                {
                    return Json(new ResultModel<bool>(0, "修改往期回顾成功", true), JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new ResultModel<bool>(8, "修改往期回顾失败", false), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ReviewDeleteAjax(string reviewId)
        {
            if (!string.IsNullOrEmpty(reviewId))
            {
                int rid = Utility.Util.ParseHelper.ToInt(reviewId);
                pbs_basic_ReviewHistoryService pbsReviewHistoryService = new pbs_basic_ReviewHistoryService();
                ResultInfo<bool> resultDeleteReview = pbsReviewHistoryService.DeleteReviewHistory(rid);
                if (resultDeleteReview.Result && resultDeleteReview.Data)
                {
                    return Json(new ResultModel<bool>(0, "删除往期回顾成功", true), JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new ResultModel<bool>(1, "删除往期回顾失败", false), JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 导航栏
        public ActionResult NavigationList()
        {
            pbsBasicNavigationListResult result = new pbsBasicNavigationListResult();
            pbs_basic_NavigationService pbsNavigationService = new pbs_basic_NavigationService();
            ResultInfo<List<pbs_basic_Navigation>> resultinfo = pbsNavigationService.GetNavigationList();
            if (resultinfo.Result && resultinfo.Data != null)
            {
                result.List = resultinfo.Data;
            }

            return View(result);
        }

        public ActionResult NavigationAdd(string navigationId)
        {
            pbs_basic_Navigation pbsNavigation = new pbs_basic_Navigation();
            pbsNavigation.NavigationId = 0;
            pbsNavigation.NavigationName = string.Empty;
            pbsNavigation.NavigationUrl = string.Empty;
            pbsNavigation.CreateTime = DateTime.Now;
            pbsNavigation.UpdateTime = DateTime.Now;
            pbsNavigation.CreatorId = 0;
            pbsNavigation.Remark = string.Empty;

            pbs_basic_NavigationService pbsNavigationService = new pbs_basic_NavigationService();

            if (!string.IsNullOrEmpty(navigationId))
            {
                int nid = Utility.Util.ParseHelper.ToInt(navigationId);
                ResultInfo<pbs_basic_Navigation> resultItem = pbsNavigationService.GetNavigationModelById(nid);
                if (resultItem.Result && resultItem.Data != null)
                {
                    pbsNavigation.NavigationId = resultItem.Data.NavigationId;
                    pbsNavigation.NavigationName = resultItem.Data.NavigationName;
                    pbsNavigation.NavigationUrl = resultItem.Data.NavigationUrl;
                    pbsNavigation.CreateTime = resultItem.Data.CreateTime;
                    pbsNavigation.UpdateTime = resultItem.Data.UpdateTime;
                    pbsNavigation.CreatorId = resultItem.Data.CreatorId;
                    pbsNavigation.Remark = resultItem.Data.Remark;
                }
                ViewBag.PageTitle = "修改导航栏";
            }
            else
            {
                ViewBag.PageTitle = "添加导航栏";
            }

            return View(pbsNavigation);
        }

        public JsonResult NavigationAddAjax(string navigationName, string navigationUrl, string createTime, string updateTime, string creatorId, string remark)
        {
            if (string.IsNullOrEmpty(navigationName))
            {
                return Json(new ResultModel<bool>(1, "请输入导航栏标题", false), JsonRequestBehavior.AllowGet);
            }

            if (string.IsNullOrEmpty(navigationUrl))
            {
                return Json(new ResultModel<bool>(3, "请选择图片文件", false), JsonRequestBehavior.AllowGet);
            }

            pbs_basic_NavigationService pbsNavigationService = new pbs_basic_NavigationService();

            ResultInfo<bool> resultAddNavigation = pbsNavigationService.AddNavigation(navigationName, navigationUrl,
                Utility.Util.ParseHelper.ToDatetime(createTime), Utility.Util.ParseHelper.ToDatetime(updateTime),
                     Utility.Util.ParseHelper.ToInt(creatorId), remark);
            if (resultAddNavigation.Result && resultAddNavigation.Data)
            {
                return Json(new ResultModel<bool>(0, "添加导航栏成功", true), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new ResultModel<bool>(8, "添加导航栏失败", false), JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult NavigationUpdateAjax(string navigationName, string navigationUrl, string createTime, string updateTime, string creatorId, string remark, string navigationId)
        {
            if (string.IsNullOrEmpty(navigationName))
            {
                return Json(new ResultModel<bool>(1, "请输入导航栏标题", false), JsonRequestBehavior.AllowGet);
            }

            if (string.IsNullOrEmpty(navigationUrl))
            {
                return Json(new ResultModel<bool>(3, "请选择图片文件", false), JsonRequestBehavior.AllowGet);
            }

            pbs_basic_NavigationService pbsNavigationService = new pbs_basic_NavigationService();

            if (!string.IsNullOrEmpty(navigationId))
            {
                int nid = Utility.Util.ParseHelper.ToInt(navigationId);

                ResultInfo<bool> resultEditNavigation = pbsNavigationService.UpdateNavigation(navigationName, navigationUrl,
                Utility.Util.ParseHelper.ToDatetime(createTime), Utility.Util.ParseHelper.ToDatetime(updateTime),
                     Utility.Util.ParseHelper.ToInt(creatorId), remark, nid);
                if (resultEditNavigation.Result && resultEditNavigation.Data)
                {
                    return Json(new ResultModel<bool>(0, "修改导航栏成功", true), JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new ResultModel<bool>(8, "修改导航栏失败", false), JsonRequestBehavior.AllowGet);
        }

        public JsonResult NavigationDeleteAjax(string navigationId)
        {
            if (!string.IsNullOrEmpty(navigationId))
            {
                int nid = Utility.Util.ParseHelper.ToInt(navigationId);
                pbs_basic_NavigationService pbsNavigationService = new pbs_basic_NavigationService();
                ResultInfo<bool> resultDeleteNavigation = pbsNavigationService.DeleteNavigation(nid);
                if (resultDeleteNavigation.Result && resultDeleteNavigation.Data)
                {
                    return Json(new ResultModel<bool>(0, "删除导航栏成功", true), JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new ResultModel<bool>(1, "删除导航栏失败", false), JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 首页轮播图
        public ActionResult HomePictureList()
        {
            pbsBasicHomePictureListResult result = new pbsBasicHomePictureListResult();
            pbs_basic_HomePictureService pbsHomePictureService = new pbs_basic_HomePictureService();
            ResultInfo<List<pbs_basic_HomePicture>> resultinfo = pbsHomePictureService.GetHomePictureList();
            if (resultinfo.Result && resultinfo.Data != null)
            {
                result.List = resultinfo.Data;
            }

            return View(result);
        }

        public ActionResult HomePictureAdd(string homePictureId)
        {
            pbs_basic_HomePicture pbsHomePicture = new pbs_basic_HomePicture();
            pbsHomePicture.HomePictureId = 0;
            pbsHomePicture.Url = string.Empty;
            pbsHomePicture.OrderBy = 0;
            pbsHomePicture.CreateTime = DateTime.Now;
            pbsHomePicture.UpdateTime = DateTime.Now;
            pbsHomePicture.CreatorId = 0;
            pbsHomePicture.Remark = string.Empty;
            pbsHomePicture.LinkUrl = string.Empty;

            pbs_basic_HomePictureService pbsHomePictureService = new pbs_basic_HomePictureService();

            if (!string.IsNullOrEmpty(homePictureId))
            {
                int hid = Utility.Util.ParseHelper.ToInt(homePictureId);
                ResultInfo<pbs_basic_HomePicture> resultItem = pbsHomePictureService.GetHomePictureModelById(hid);
                if (resultItem.Result && resultItem.Data != null)
                {
                    pbsHomePicture.HomePictureId = resultItem.Data.HomePictureId;
                    pbsHomePicture.Url = resultItem.Data.Url;
                    pbsHomePicture.OrderBy = resultItem.Data.OrderBy;
                    pbsHomePicture.CreateTime = resultItem.Data.CreateTime;
                    pbsHomePicture.UpdateTime = resultItem.Data.UpdateTime;
                    pbsHomePicture.CreatorId = resultItem.Data.CreatorId;
                    pbsHomePicture.Remark = resultItem.Data.Remark;
                    pbsHomePicture.LinkUrl = resultItem.Data.LinkUrl;
                }
                ViewBag.PageTitle = "修改首页轮播图";
            }
            else
            {
                ViewBag.PageTitle = "添加首页轮播图";
            }

            return View(pbsHomePicture);
        }

        public JsonResult HomePictureAddAjax(string url, string orderBy, string createTime, string updateTime, string creatorId, string remark,string linkUrl)
        {
            if (string.IsNullOrEmpty(url))
            {
                return Json(new ResultModel<bool>(1, "请选择图片文件", false), JsonRequestBehavior.AllowGet);
            }

            if (string.IsNullOrEmpty(orderBy))
            {
                return Json(new ResultModel<bool>(2, "请输入首页轮播图排序", false), JsonRequestBehavior.AllowGet);
            }

            pbs_basic_HomePictureService pbsHomePictureService = new pbs_basic_HomePictureService();

            ResultInfo<bool> resultAddHomePicture = pbsHomePictureService.AddHomePicture(url, Utility.Util.ParseHelper.ToInt(orderBy),
                Utility.Util.ParseHelper.ToDatetime(createTime), Utility.Util.ParseHelper.ToDatetime(updateTime),
                     Utility.Util.ParseHelper.ToInt(creatorId), remark, linkUrl);
            if (resultAddHomePicture.Result && resultAddHomePicture.Data)
            {
                return Json(new ResultModel<bool>(0, "添加首页轮播图成功", true), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new ResultModel<bool>(8, "添加首页轮播图失败", false), JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult HomePictureUpdateAjax(string url, string orderBy, string createTime, string updateTime, string creatorId, string remark, string linkUrl, string homePictureId)
        {
            if (string.IsNullOrEmpty(url))
            {
                return Json(new ResultModel<bool>(1, "请选择图片文件", false), JsonRequestBehavior.AllowGet);
            }

            if (string.IsNullOrEmpty(orderBy))
            {
                return Json(new ResultModel<bool>(2, "请输入首页轮播图排序", false), JsonRequestBehavior.AllowGet);
            }

            pbs_basic_HomePictureService pbsHomePictureService = new pbs_basic_HomePictureService();

            if (!string.IsNullOrEmpty(homePictureId))
            {
                int hid = Utility.Util.ParseHelper.ToInt(homePictureId);

                ResultInfo<bool> resultEditHomePicture = pbsHomePictureService.UpdateHomePicture(url, Utility.Util.ParseHelper.ToInt(orderBy),
                Utility.Util.ParseHelper.ToDatetime(createTime), Utility.Util.ParseHelper.ToDatetime(updateTime),
                     Utility.Util.ParseHelper.ToInt(creatorId), remark, linkUrl, hid);
                if (resultEditHomePicture.Result && resultEditHomePicture.Data)
                {
                    return Json(new ResultModel<bool>(0, "修改首页轮播图成功", true), JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new ResultModel<bool>(8, "修改首页轮播图失败", false), JsonRequestBehavior.AllowGet);
        }

        public JsonResult HomePictureDeleteAjax(string homePictureId)
        {
            if (!string.IsNullOrEmpty(homePictureId))
            {
                int hid = Utility.Util.ParseHelper.ToInt(homePictureId);
                pbs_basic_HomePictureService pbsHomePictureService = new pbs_basic_HomePictureService();
                ResultInfo<bool> resultDeleteHomePicture = pbsHomePictureService.DeleteHomePicture(hid);
                if (resultDeleteHomePicture.Result && resultDeleteHomePicture.Data)
                {
                    return Json(new ResultModel<bool>(0, "删除首页轮播图成功", true), JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new ResultModel<bool>(1, "删除首页轮播图失败", false), JsonRequestBehavior.AllowGet);
        }
        #endregion

    }
}