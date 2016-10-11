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
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            int tehuiClassId = Utility.Util.ParseHelper.ToInt(System.Configuration.ConfigurationManager.AppSettings["TeHuiActivity"]);
            int benzhouClassId = Utility.Util.ParseHelper.ToInt(System.Configuration.ConfigurationManager.AppSettings["BenZhouActivity"]);
            pbs_basic_GoodsService pbsBasicGoodsService = new pbs_basic_GoodsService();
            ResultInfo<List<pbs_basic_GoodsView>> result_tehui = pbsBasicGoodsService.GetGoodsList(string.Empty, tehuiClassId, -1, -1, -1, 0, -1, -1, -1,-1);
            if (result_tehui.Result && result_tehui.Data != null)
            {
                ViewData["TehuiList"] = result_tehui.Data.OrderByDescending(x => x.GoodsId).Take(3).ToList();
            }

            ResultInfo<List<pbs_basic_GoodsView>> result_benzhou = pbsBasicGoodsService.GetGoodsList(string.Empty, benzhouClassId, -1, -1, -1, 0, -1, -1, -1,-1);
            if (result_benzhou.Result && result_benzhou.Data != null)
            {
                ViewData["BenzhouList"] = result_benzhou.Data.OrderByDescending(x => x.GoodsId).Take(3).ToList();
            }

            pbs_basic_HomePictureService pbsHomePictureService = new pbs_basic_HomePictureService();
            ResultInfo<List<pbs_basic_HomePicture>> result_HomePicture = pbsHomePictureService.GetHomePictureList();
            if (result_HomePicture.Result && result_HomePicture.Data != null)
            {
                ViewData["HomePictureList"] = result_HomePicture.Data;
            }

            return View();
        }


    }
}