using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Helper;
using PBS.Model;
using Utility;

namespace PBS.Dao
{
    public class pbs_sys_MenuDao : DBOperation
    {
        #region
        /// <summary>
        /// 根据角色编号获取菜单列表
        /// </summary>
        /// <param name="roleId">角色编号</param>
        /// <returns></returns>
        public DataTable GetTreeMenu(string roleId)
        {
            return ExecuteDataset("GetTreeMenu", CommandType.StoredProcedure, new SqlParameter("@RoleID", roleId)).Tables[0];
        }

        /// <summary>
        /// 获取所有菜单
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllTreeMenu()
        {
            return ExecuteDataset("select * from pbs_sys_Menu").Tables[0];
        }

        /// <summary>
        /// 根据角色编号和父节点编号获取当前菜单列表
        /// </summary>
        /// <param name="parentId">父节点编号</param>
        /// <param name="roleId">角色编号</param>
        /// <returns></returns>
        public DataTable GetThisTreeNodeMenu(string parentId, string roleId)
        {
            return ExecuteDataset("GetThisNoteMenu", CommandType.StoredProcedure, new SqlParameter("@ParentId", parentId),
                                                       new SqlParameter("@RoleID", roleId)).Tables[0];
        }

        /// <summary>
        /// 根据父节点编号获取子节点
        /// </summary>
        /// <param name="parentId">父节点编号</param>
        /// <returns></returns>
        public DataTable GetChildNodes(string parentId)
        {
            string sql = "SELECT NodeId,NodeName,NodeGroup,ParentId,NodeUrl FROM pbs_sys_Menu WHERE ParentId=@ParentId";
            DataTable dt = ExecuteDataset(sql, new SqlParameter("@ParentId", parentId)).Tables[0];
            return dt;
        }
        #endregion
    }
}
