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
    public class pbs_sys_PermissionsDao : DBOperation
    {
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsPermissions(int roleId, string nodeId, int userId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from pbs_sys_Permissions");
            strSql.Append(" where RoleId=@RoleId");
            strSql.Append(" and NodeId=@NodeId");
            strSql.Append(" and UserId=@UserId");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleId", SqlDbType.Int,4),
                    new SqlParameter("@NodeId", SqlDbType.NVarChar,100),
                    new SqlParameter("@UserId", SqlDbType.Int,4)
			};
            parameters[0].Value = roleId;
            parameters[1].Value = nodeId;
            parameters[2].Value = userId;

            return (int)ExecuteScalar(strSql.ToString(), CommandType.Text, parameters) > 0;
        }

        /// <summary>
        /// 获取所有角色列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllRole()
        {
            return ExecuteDataset("select RoleId,RoleName from pbs_sys_Role").Tables[0];
        }

        /// <summary>
        /// 给权限表增加一条数据
        /// </summary>
        public bool AddPermissions(int roleId, string nodeId, int userId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into pbs_sys_Permissions(");
            strSql.Append("RoleId,NodeId,UserId)");
            strSql.Append(" values (");
            strSql.Append("@RoleId,@NodeId,@UserId)");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleId", SqlDbType.Int,4),
					new SqlParameter("@NodeId", SqlDbType.NVarChar,100),
                    new SqlParameter("@UserId", SqlDbType.Int,4)};
            parameters[0].Value = roleId;
            parameters[1].Value = nodeId;
            parameters[2].Value = userId;

            int rows = ExecuteNonQuery(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除权限表一条数据
        /// </summary>
        public bool DeletePermissions(int roleId, int userId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from pbs_sys_Permissions ");
            strSql.Append(" where RoleId=@RoleId ");
            strSql.Append(" and UserId=@UserId");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleId",SqlDbType.Int,4),			
                    new SqlParameter("@UserId", SqlDbType.Int,4)};
            parameters[0].Value = roleId;
            parameters[1].Value = userId;

            int rows = ExecuteNonQuery(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
