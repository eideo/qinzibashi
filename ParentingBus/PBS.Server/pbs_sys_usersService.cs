using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBS.Dao;
using PBS.Model;

namespace PBS.Server
{
    public class pbs_sys_usersService
    {
        pbs_sys_usersDao dao = new pbs_sys_usersDao();
        /// <summary>
        /// 根据用户编号判断用户是否存在
        /// </summary>
        /// <param name="userid">用户编号</param>
        /// <returns></returns>
        public ResultInfo<bool> IsExistsByUserId(int userid)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.IsExistsByUserId(userid);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = false;
            }
            return result;
        }

        public ResultInfo<bool> IsExistsByLoginId(string loginId)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.IsExistsByLoginId(loginId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = false;
            }
            return result;
        }

        public ResultInfo<bool> AddSysUser(string loginId, string userPwd, string nickName, DateTime addTime, string remark, int role, string address, string phone, string email, string photo)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.AddSysUser(loginId, userPwd, nickName, addTime, remark, role, address, phone, email, photo);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = false;
            }
            return result;
        }

        public ResultInfo<bool> UpdateSysUser(string loginId, string userPwd, string nickName, DateTime addTime, string remark, int role, string address, string phone, string email, string photo, int id)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.UpdateSysUser(loginId, userPwd, nickName, addTime, remark, role, address, phone, email, photo, id);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = false;
            }
            return result;
        }

        public ResultInfo<bool> DeleteSysUserById(int id)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.DeleteSysUserById(id);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = false;
            }
            return result;
        }

        /// <summary>
        /// 根据用户名和密码得到一个用户实体
        /// </summary>
        /// <param name="loginId">用户名</param>
        /// <param name="passWord">密码</param>
        /// <returns></returns>
        public ResultInfo<pbs_sys_users> GetUserInfo(string loginId, string passWord)
        {
            ResultInfo<pbs_sys_users> result = new ResultInfo<pbs_sys_users>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetUserInfo(loginId, passWord);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = null;
            }
            return result;
        }

        public ResultInfo<pbs_sys_users> GetModel(int id)
        {
            ResultInfo<pbs_sys_users> result = new ResultInfo<pbs_sys_users>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetModel(id);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = null;
            }
            return result;
        }

        public ResultInfo<List<pbs_sys_usersView>> GetSysUsersList()
        { 
            ResultInfo<List<pbs_sys_usersView>> result = new ResultInfo<List<pbs_sys_usersView>>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetSysUsersList();
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = null;
            }
            return result;
        }

    }
}
