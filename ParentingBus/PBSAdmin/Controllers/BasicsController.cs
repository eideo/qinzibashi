using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PBSAdmin.Controllers
{
    public class BasicsController : Controller
    {
        //
        // GET: /Basics/

        public ActionResult ShopList()
        {
            return View();
        }

    }
}
