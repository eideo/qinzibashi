using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using PBS.Server;
using PBSAdmin.Models;
using PBS.Model;

namespace JMWeiXin.ashx
{
    /// <summary>
    /// UpdateUserPermissions 的摘要说明
    /// </summary>
    public class UpdateUserPermissions : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {

            context.Response.Write(UpdateUserPermission(context.Request.QueryString["AllNodeId"], context.Request.QueryString["RoleCode"], context.Request.QueryString["UserId"]));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public bool UpdateUserPermission(string AllNodeId, string RoleCode, string UserId)
        {
            pbs_sys_PermissionsService permissionsService = new pbs_sys_PermissionsService();
            bool result = false;
            if (AllNodeId != null && AllNodeId != "" && RoleCode != null && RoleCode != "" && UserId != null && UserId != "")
            {
                ResultInfo<bool> resultDelete = permissionsService.DeletePermissions(Utility.Util.ParseHelper.ToInt(RoleCode), Utility.Util.ParseHelper.ToInt(UserId));
                if (resultDelete.Result && resultDelete.Data)
                {
                    result = resultDelete.Data;
                }

                string[] ClassList = AllNodeId.Split(',');
                for (int i = 0; i < ClassList.Length - 1; i++)
                {
                    if (ClassList[i] != "")
                    {
                        string NodeId = ClassList[i];
                        ResultInfo<bool> resultAdd = permissionsService.AddPermissions(Utility.Util.ParseHelper.ToInt(RoleCode), NodeId, Utility.Util.ParseHelper.ToInt(UserId));
                        if (resultAdd.Result && resultAdd.Data)
                        {
                            result = resultAdd.Data;
                        }
                    }
                }
            }

            return result;
        }
    }
}