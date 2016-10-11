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

namespace PBSAdmin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Left()
        {
            pbs_sys_MenuService mesMenuService = new pbs_sys_MenuService();
            pbs_sys_users userDate = (pbs_sys_users)Session["USER"];
            MenuModels models = new MenuModels();
            models.ParentItemList = new List<ParentItem>();
            if (userDate != null && !string.IsNullOrEmpty(userDate.role.ToString()))
            {
                ResultInfo<DataTable> resultPm = mesMenuService.GetThisTreeNodeMenu("#", userDate.role.ToString());
                if (resultPm.Result && resultPm.Data != null)
                {
                    foreach (DataRow prow in resultPm.Data.Rows) //得到行集合
                    {
                        ParentItem pi = new ParentItem();
                        pi.NodeId = prow[0].ToString();
                        pi.NodeName = prow[1].ToString();
                        pi.NodeGroup = prow[2].ToString();
                        pi.ParentId = prow[3].ToString();
                        pi.NodeUrl = prow[4].ToString();
                        pi.BrotherList = new List<BrotherItem>();
                        ResultInfo<DataTable> resultBm = mesMenuService.GetThisTreeNodeMenu(pi.NodeId,
                            userDate.role.ToString());
                        if (resultBm.Result && resultBm.Data != null)
                        {
                            foreach (DataRow brow in resultBm.Data.Rows)
                            {
                                BrotherItem bi = new BrotherItem();
                                bi.NodeId = brow[0].ToString();
                                bi.NodeName = brow[1].ToString();
                                bi.NodeGroup = brow[2].ToString();
                                bi.ParentId = brow[3].ToString();
                                bi.NodeUrl = brow[4].ToString();
                                bi.ChildrenList = new List<ChildrenItem>();
                                ResultInfo<DataTable> resultCm = mesMenuService.GetThisTreeNodeMenu(bi.NodeId,
                                    userDate.role.ToString());
                                if (resultCm.Result && resultCm.Data != null)
                                {
                                    foreach (DataRow crow in resultCm.Data.Rows)
                                    {
                                        ChildrenItem ci = new ChildrenItem();
                                        ci.NodeId = crow[0].ToString();
                                        ci.NodeName = crow[1].ToString();
                                        ci.NodeGroup = crow[2].ToString();
                                        ci.ParentId = crow[3].ToString();
                                        ci.NodeUrl = crow[4].ToString();
                                        bi.ChildrenList.Add(ci);
                                    }
                                }
                                pi.BrotherList.Add(bi);
                            }
                        }

                        models.ParentItemList.Add(pi);
                    }
                }
            }

            return View(models);
        }

        public ActionResult Main()
        {

            return View();
        }

        public ActionResult Foot()
        {

            return View();
        }
    }
}
