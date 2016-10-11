using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBS.Dao;
using PBS.Model;

namespace PBS.Server
{
    public class pbs_basic_UsersService
    {
        pbs_basic_UsersDao dao = new pbs_basic_UsersDao();

        public ResultInfo<bool> IsExistsByWeiXinCode(string weixinCode)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.IsExistsByWeiXinCode(weixinCode);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = false;
            }
            return result;
        }

        public ResultInfo<bool> AddUsers(string loginName, string pwd, string nickName, string photoUrl, string phone, int babySex, string babyBirthday, string weiXinCode, DateTime createTime, DateTime updateTime, int creatorId, string remark, string myAdress)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.AddUsers(loginName, pwd, nickName, photoUrl, phone, babySex, babyBirthday, weiXinCode, createTime, updateTime, creatorId, remark, myAdress);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = false;
            }
            return result;
        }

        public ResultInfo<bool> UpdateUsers(string loginName, string pwd, string nickName, string photoUrl, string phone, int babySex, string babyBirthday, string weiXinCode, DateTime createTime, DateTime updateTime, int creatorId, string remark, string myAdress, int userId)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.UpdateUsers(loginName, pwd, nickName, photoUrl, phone, babySex, babyBirthday, weiXinCode, createTime, updateTime, creatorId, remark, myAdress, userId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = false;
            }
            return result;
        }

        public ResultInfo<bool> DeleteUsers(int userId)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.DeleteUsers(userId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = false;
            }
            return result;
        }

        public ResultInfo<pbs_basic_Users> GetUsersModelById(int userId)
        {
            ResultInfo<pbs_basic_Users> result = new ResultInfo<pbs_basic_Users>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetUsersModelById(userId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = null;
            }
            return result;
        }

        public ResultInfo<pbs_basic_Users> GetUsersModelByWeiXinCode(string weixinCode)
        {
            ResultInfo<pbs_basic_Users> result = new ResultInfo<pbs_basic_Users>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetUsersModelByWeiXinCode(weixinCode);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = null;
            }
            return result;
        }

        public ResultInfo<List<pbs_basic_Users>> GetUsersList()
        {
            ResultInfo<List<pbs_basic_Users>> result = new ResultInfo<List<pbs_basic_Users>>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetUsersList();
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = null;
            }
            return result;
        }

        public ResultInfo<List<pbs_basic_UsersDetail>> GetUsersDetailList()
        {
            ResultInfo<List<pbs_basic_UsersDetail>> result = new ResultInfo<List<pbs_basic_UsersDetail>>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetUsersDetailList();
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = null;
            }
            return result;
        }

        public ResultInfo<List<pbs_basic_UsersOrderDetail>> GetUsersOrderDetailList(int userId)
        {
            ResultInfo<List<pbs_basic_UsersOrderDetail>> result = new ResultInfo<List<pbs_basic_UsersOrderDetail>>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetUsersOrderDetailList(userId);
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
