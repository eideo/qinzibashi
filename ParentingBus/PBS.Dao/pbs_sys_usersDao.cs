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
    public class pbs_sys_usersDao : DBOperation
    {
        #region  Method

        /// <summary>
        /// 根据用户编号判断用户是否存在
        /// </summary>
        /// <param name="userid">用户编号</param>
        /// <returns></returns>
        public bool IsExistsByUserId(int userid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from pbs_sys_users");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = userid;

            return (int)ExecuteScalar(strSql.ToString(), CommandType.Text, parameters) > 0;
        }

        public bool IsExistsByLoginId(string loginId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from pbs_sys_users");
            strSql.Append(" where loginId=@loginId");
            SqlParameter[] parameters = {
                    new SqlParameter("@loginId", SqlDbType.NVarChar,50)
            };
            parameters[0].Value = loginId;

            return (int)ExecuteScalar(strSql.ToString(), CommandType.Text, parameters) > 0;
        }

        public bool AddSysUser(string loginId,string userPwd, string nickName, DateTime addTime, string remark, int role, string address, string phone, string email, string photo )
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into pbs_sys_users(");
            strSql.Append("loginId,userPwd,nickName,addTime,remark,role,address,phone,email,photo)");
            strSql.Append(" values (");
            strSql.Append("@loginId,@userPwd,@nickName,@addTime,@remark,@role,@address,@phone,@email,@photo)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@loginId", SqlDbType.NVarChar,50),
                    new SqlParameter("@userPwd", SqlDbType.NVarChar,50),
                    new SqlParameter("@nickName", SqlDbType.NVarChar,50),
                    new SqlParameter("@addTime", SqlDbType.DateTime),
                    new SqlParameter("@remark", SqlDbType.NVarChar,100),
                    new SqlParameter("@role", SqlDbType.Int,4),
                    new SqlParameter("@address", SqlDbType.NVarChar,100),
                    new SqlParameter("@phone", SqlDbType.NVarChar,50),
                    new SqlParameter("@email", SqlDbType.NVarChar,50),
                    new SqlParameter("@photo", SqlDbType.NVarChar,50)};
            parameters[0].Value = loginId;
            parameters[1].Value = userPwd;
            parameters[2].Value = nickName;
            parameters[3].Value = addTime;
            parameters[4].Value = remark;
            parameters[5].Value = role;
            parameters[6].Value = address;
            parameters[7].Value = phone;
            parameters[8].Value = email;
            parameters[9].Value = photo;

            int row = ExecuteNonQuery(strSql.ToString(), parameters);
            if (row > 0)
            {
                return true;

            }
            return false;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateSysUser(string loginId, string userPwd, string nickName, DateTime addTime, string remark, int role, string address, string phone, string email, string photo,int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update pbs_sys_users set ");
            strSql.Append("loginId=@loginId,");
            strSql.Append("userPwd=@userPwd,");
            strSql.Append("nickName=@nickName,");
            strSql.Append("addTime=@addTime,");
            strSql.Append("remark=@remark,");
            strSql.Append("role=@role,");
            strSql.Append("address=@address,");
            strSql.Append("phone=@phone,");
            strSql.Append("email=@email,");
            strSql.Append("photo=@photo");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
                    new SqlParameter("@loginId", SqlDbType.NVarChar,50),
                    new SqlParameter("@userPwd", SqlDbType.NVarChar,50),
                    new SqlParameter("@nickName", SqlDbType.NVarChar,50),
                    new SqlParameter("@addTime", SqlDbType.DateTime),
                    new SqlParameter("@remark", SqlDbType.NVarChar,100),
                    new SqlParameter("@role", SqlDbType.Int,4),
                    new SqlParameter("@address", SqlDbType.NVarChar,100),
                    new SqlParameter("@phone", SqlDbType.NVarChar,50),
                    new SqlParameter("@email", SqlDbType.NVarChar,50),
                    new SqlParameter("@photo", SqlDbType.NVarChar,50),
                    new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = loginId;
            parameters[1].Value = userPwd;
            parameters[2].Value = nickName;
            parameters[3].Value = addTime;
            parameters[4].Value = remark;
            parameters[5].Value = role;
            parameters[6].Value = address;
            parameters[7].Value = phone;
            parameters[8].Value = email;
            parameters[9].Value = photo;
            parameters[10].Value = id;

            int row = ExecuteNonQuery(strSql.ToString(), parameters);
            if (row > 0)
            {
                return true;

            }
            return false;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteSysUserById(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from pbs_sys_users ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = id;

            int row = ExecuteNonQuery(strSql.ToString(), parameters);
            if (row > 0)
            {
                return true;

            }
            return false;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public pbs_sys_users GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,loginId,userPwd,nickName,addTime,remark,role,address,phone,email,photo from pbs_sys_users ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            DataTable ds = ExecuteDataset(strSql.ToString(), parameters).Tables[0];
            IList<pbs_sys_users> list = Utility.ModelConvertHelper<pbs_sys_users>.ConvertToModel(ds);
            return list.Count > 0 ? list[0] : null;
        }

        /// <summary>
        /// 根据用户名和密码得到一个用户实体
        /// </summary>
        /// <param name="loginId">用户名</param>
        /// <param name="passWord">密码</param>
        /// <returns></returns>
        public pbs_sys_users GetUserInfo(string loginId, string passWord)
        {
            string sql = "select * from dbo.pbs_sys_users where loginId=@loginId and userPwd=@passWord";
            DataTable ds = ExecuteDataset(sql, new SqlParameter("@loginId", loginId), new SqlParameter("@passWord", passWord)).Tables[0];
            IList<pbs_sys_users> list = ModelConvertHelper<pbs_sys_users>.ConvertToModel(ds);
            if (list.Count > 0)
                return list[0];
            else
            {
                return null;
            }
        }

        public List<pbs_sys_usersView> GetSysUsersList()
        {
            List<pbs_sys_usersView> list = new List<pbs_sys_usersView>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT a.id, a.loginId, a.userPwd, a.nickName, addTime, a.remark, a.role, a.address, a.phone, a.email, a.photo,b.RoleName ");
            strSql.Append(" FROM dbo.pbs_sys_users a,pbs_sys_Role b ");
            strSql.Append(" where a.role=b.RoleId ");
            DataTable dt = ExecuteDataset(strSql.ToString()).Tables[0];
            IList<pbs_sys_usersView> ilist = Utility.ModelConvertHelper<pbs_sys_usersView>.ConvertToModel(dt);
            list = new List<pbs_sys_usersView>(ilist);
            return list;
        }

        #endregion  Method
    }
}
