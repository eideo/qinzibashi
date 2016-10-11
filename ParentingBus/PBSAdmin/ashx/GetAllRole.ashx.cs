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
    /// GetAllRole 的摘要说明
    /// </summary>
    public class GetAllRole : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Write(GetAllRoles());
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public string GetAllRoles()
        {
            DataTable pm=new DataTable();
            pbs_sys_PermissionsService permissionsService = new pbs_sys_PermissionsService();
            ResultInfo<DataTable> resultAllRole = permissionsService.GetAllRole();
            if (resultAllRole.Result && resultAllRole.Data != null)
            {
                pm = resultAllRole.Data;
            }

            List<MembersRole> membersRoles = new List<MembersRole>();

            if (pm != null)
            {
                foreach (DataRow prow in pm.Rows) //得到行集合
                {
                    MembersRole membersRole = new MembersRole();
                    membersRole.RoleId = prow[0].ToString();
                    membersRole.RoleName = prow[1].ToString();
                    membersRoles.Add(membersRole);
                }
            }


            return Newtonsoft.Json.JsonConvert.SerializeObject(membersRoles);
        }

        public List<MembersRole> GetMembersRole { get; set; }

        public class MembersRole
        {
            public string RoleId;
            public string RoleName;
        }
    }
}