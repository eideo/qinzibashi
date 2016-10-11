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
using System.Dynamic;

namespace PBSAdmin.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult OrderList()
        {
            List<pbs_basic_OrderView> pbsBasicOrderViewList = new List<pbs_basic_OrderView>();
            pbs_basic_OrderService pbsBasicOrderService = new pbs_basic_OrderService();
            ResultInfo<List<pbs_basic_OrderView>> resultinfo = pbsBasicOrderService.GetOrderViewList();
            if (resultinfo.Result && resultinfo.Data != null)
            {
                pbsBasicOrderViewList = resultinfo.Data;
            }

            ViewData["pbsBasicOrderViewList"] = pbsBasicOrderViewList;

            return View();
        }

        public JsonResult ExportExcelAjax(string startTime, string endTime)
        {
            dynamic result = new ExpandoObject();
            result.Code = "0001";
            result.Msg = "error";
            result.Url = string.Empty;

            pbs_basic_OrderService pbsBasicOrderService = new pbs_basic_OrderService();
            ResultInfo<List<pbs_basic_OrderView>> resultinfo = new ResultInfo<List<pbs_basic_OrderView>>();
            if (!string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
            {
                resultinfo = pbsBasicOrderService.GetOrderViewList(startTime, endTime);
            }
            else
            {
                resultinfo = pbsBasicOrderService.GetOrderViewList();
            }
            if (resultinfo.Result && resultinfo.Data != null)
            {
                List<pbs_basic_OrderViewExport> list = new List<pbs_basic_OrderViewExport>();
                foreach (var item in resultinfo.Data)
                {
                    pbs_basic_OrderViewExport pbsBasicOrderViewExport = new pbs_basic_OrderViewExport();
                    pbsBasicOrderViewExport.OrderId = item.OrderId.ToString();
                    pbsBasicOrderViewExport.GoodsId = item.GoodsId.ToString();
                    pbsBasicOrderViewExport.GoodsName = item.GoodsName.ToString();
                    pbsBasicOrderViewExport.Count = item.Count.ToString();
                    pbsBasicOrderViewExport.VisitTime = item.VisitTime.ToString();
                    pbsBasicOrderViewExport.UserId = item.UserId.ToString();
                    pbsBasicOrderViewExport.OrderPrice = item.OrderPrice.ToString();
                    pbsBasicOrderViewExport.OrderStatus = item.OrderStatus.ToString();
                    pbsBasicOrderViewExport.CreateTime = item.CreateTime;
                    list.Add(pbsBasicOrderViewExport);
                }

                string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
                string savePath = Server.MapPath("~/Content/export/") + fileName;
                ExportExcelHelper.ExportExcel(savePath, ParseHelper.ToDataTable(list));

                result.Code = "0000";
                result.Msg = "ok";
                result.Url = "/Content/export/" + fileName;
            }

            return Json(JsonConvert.SerializeObject(result), JsonRequestBehavior.AllowGet);
        }
    }
}