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
    public class SystemController : Controller
    {
        // GET: System
        public ActionResult UserPermissions(string roleCode)
        {
            if (string.IsNullOrEmpty(roleCode))
            {
                roleCode = "1";
            }
            pbs_sys_PermissionsService permissionsService = new pbs_sys_PermissionsService();
            pbs_sys_MenuService mesMenuService = new pbs_sys_MenuService();
            pbs_sys_users userDate = (pbs_sys_users)Session["USER"];
            MenuModels models = new MenuModels();
            models.ParentItemList = new List<ParentItem>();
            if (userDate != null && !string.IsNullOrEmpty(userDate.role.ToString()))
            {
                models.UserId = userDate.id.ToString();
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
                        ResultInfo<bool> resultExistsPi = permissionsService.ExistsPermissions(Utility.Util.ParseHelper.ToInt(roleCode),
                            prow[0].ToString(), Utility.Util.ParseHelper.ToInt(userDate.id));
                        if (resultExistsPi.Result && resultExistsPi.Data)
                        {
                            pi.IsOrNullExists = true;
                        }
                        else
                        {
                            pi.IsOrNullExists = false;
                        }
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
                                ResultInfo<bool> resultExistsbi = permissionsService.ExistsPermissions(Utility.Util.ParseHelper.ToInt(roleCode),
                            brow[0].ToString(), Utility.Util.ParseHelper.ToInt(userDate.id));
                                if (resultExistsbi.Result && resultExistsbi.Data)
                                {
                                    bi.IsOrNullExists = true;
                                }
                                else
                                {
                                    bi.IsOrNullExists = false;
                                }

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
                                        ResultInfo<bool> resultExistsci = permissionsService.ExistsPermissions(Utility.Util.ParseHelper.ToInt(roleCode),
                            crow[0].ToString(), Utility.Util.ParseHelper.ToInt(userDate.id));
                                        if (resultExistsci.Result && resultExistsci.Data)
                                        {
                                            ci.IsOrNullExists = true;
                                        }
                                        else
                                        {
                                            ci.IsOrNullExists = false;
                                        }
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
            models.RoleCode = roleCode;
            return View(models);
        }

        public ActionResult UserManagerList()
        {
            pbsSysUserViewListResult result = new pbsSysUserViewListResult();
            pbs_sys_usersService pbsSysUsersService = new pbs_sys_usersService();
            ResultInfo<List<pbs_sys_usersView>> resultinfo = pbsSysUsersService.GetSysUsersList();
            if (resultinfo.Result && resultinfo.Data != null)
            {
                result.sysUsersViewList = resultinfo.Data;
            }

            return View(result);
        }

        public ActionResult UserManagerAdd(string id)
        {
            pbs_sys_users pbsSysUsers = new pbs_sys_users();
            pbsSysUsers.id = 0;
            pbsSysUsers.loginId = string.Empty;
            pbsSysUsers.userPwd = string.Empty;
            pbsSysUsers.nickName = string.Empty;
            pbsSysUsers.addTime = DateTime.Now;
            pbsSysUsers.remark = string.Empty;
            pbsSysUsers.role = 0;
            pbsSysUsers.address = string.Empty;
            pbsSysUsers.phone = string.Empty;
            pbsSysUsers.email = string.Empty;
            pbsSysUsers.photo = string.Empty;

            pbs_sys_usersService pbsSysUsersService = new pbs_sys_usersService();

            if (!string.IsNullOrEmpty(id))
            {
                int sid = Utility.Util.ParseHelper.ToInt(id);
                ResultInfo<pbs_sys_users> resultItem = pbsSysUsersService.GetModel(sid);
                if (resultItem.Result && resultItem.Data != null)
                {
                    pbsSysUsers.id = resultItem.Data.id;
                    pbsSysUsers.loginId = resultItem.Data.loginId;
                    pbsSysUsers.userPwd = resultItem.Data.userPwd;
                    pbsSysUsers.nickName = resultItem.Data.nickName;
                    pbsSysUsers.addTime = resultItem.Data.addTime;
                    pbsSysUsers.remark = resultItem.Data.remark;
                    pbsSysUsers.role = resultItem.Data.role;
                    pbsSysUsers.address = resultItem.Data.address;
                    pbsSysUsers.phone = resultItem.Data.phone;
                    pbsSysUsers.email = resultItem.Data.email;
                    pbsSysUsers.photo = resultItem.Data.photo;
                }
                ViewBag.PageTitle = "修改管理员";
            }
            else
            {
                ViewBag.PageTitle = "添加管理员";
            }

            ViewData["RoleDt"] = null;
            DataTable rdt = new DataTable();
            pbs_sys_PermissionsService permissionsService = new pbs_sys_PermissionsService();
            ResultInfo<DataTable> resultAllRole = permissionsService.GetAllRole();
            if (resultAllRole.Result && resultAllRole.Data != null)
            {
                rdt = resultAllRole.Data;
                ViewData["RoleDt"] = rdt;
            }

            return View(pbsSysUsers);
        }

        public JsonResult SysUserAddAjax(string loginId, string userPwd, string nickName, string addTime, string remark, string role, string address, string phone, string email, string photo)
        {

            if (string.IsNullOrEmpty(loginId))
            {
                return Json(new ResultModel<bool>(1, "请输入登录名", false), JsonRequestBehavior.AllowGet);
            }

            pbs_sys_usersService pbsSysUsersService = new pbs_sys_usersService();

            ResultInfo<bool> resultIsExist = pbsSysUsersService.IsExistsByLoginId(loginId);
            if (resultIsExist.Result && resultIsExist.Data)
            {
                return Json(new ResultModel<bool>(2, "登录名已存在，请修改", false), JsonRequestBehavior.AllowGet);
            }

            ResultInfo<bool> resultSysUsers = pbsSysUsersService.AddSysUser(loginId, Common.MD5Common.GetMd5Hash(userPwd.Trim()), nickName,
                Utility.Util.ParseHelper.ToDatetime(addTime), remark,
                     Utility.Util.ParseHelper.ToInt(role), address, phone, email, photo);
            if (resultSysUsers.Result && resultSysUsers.Data)
            {
                return Json(new ResultModel<bool>(0, "添加管理员成功", true), JsonRequestBehavior.AllowGet);
            }
            return Json(new ResultModel<bool>(1, "添加管理员失败", false), JsonRequestBehavior.AllowGet);
        }

        public JsonResult SysUserUpdateAjax(string loginId, string userPwd, string nickName, string addTime, string remark, string role, string address, string phone, string email, string photo, string id)
        {
            if (string.IsNullOrEmpty(loginId))
            {
                return Json(new ResultModel<bool>(1, "请输入登录名", false), JsonRequestBehavior.AllowGet);
            }

            pbs_sys_usersService pbsSysUsersService = new pbs_sys_usersService();

            int sid = Utility.Util.ParseHelper.ToInt(id);
            ResultInfo<pbs_sys_users> resultItem = pbsSysUsersService.GetModel(sid);
            if (resultItem.Result && resultItem.Data != null)
            {
                if (loginId != resultItem.Data.loginId)
                {
                    ResultInfo<bool> resultIsExist = pbsSysUsersService.IsExistsByLoginId(loginId);
                    if (resultIsExist.Result && resultIsExist.Data)
                    {
                        return Json(new ResultModel<bool>(2, "登录名已存在，请修改", false), JsonRequestBehavior.AllowGet);
                    }
                }
            }

            ResultInfo<bool> resultSysUsers = pbsSysUsersService.UpdateSysUser(loginId, Common.MD5Common.GetMd5Hash(userPwd.Trim()), nickName,
                Utility.Util.ParseHelper.ToDatetime(addTime), remark,
                     Utility.Util.ParseHelper.ToInt(role), address, phone, email, photo, Utility.Util.ParseHelper.ToInt(id));
            if (resultSysUsers.Result && resultSysUsers.Data)
            {
                return Json(new ResultModel<bool>(0, "修改管理员成功", true), JsonRequestBehavior.AllowGet);
            }
            return Json(new ResultModel<bool>(1, "修改管理员失败", false), JsonRequestBehavior.AllowGet);
        }

        public JsonResult SysUserDeleteAjax(string id)
        {

            if (!string.IsNullOrEmpty(id))
            {
                int sid = Utility.Util.ParseHelper.ToInt(id);
                pbs_sys_usersService pbsSysUsersService = new pbs_sys_usersService();
                ResultInfo<bool> resultDeleteSysUser = pbsSysUsersService.DeleteSysUserById(sid);
                if (resultDeleteSysUser.Result && resultDeleteSysUser.Data)
                {
                    return Json(new ResultModel<bool>(0, "删除管理员成功", true), JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new ResultModel<bool>(1, "删除管理员失败", false), JsonRequestBehavior.AllowGet);
        }

    }
}