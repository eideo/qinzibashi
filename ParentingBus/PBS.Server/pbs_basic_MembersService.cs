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
    public class pbs_basic_MembersService
    {
        pbs_basic_MembersDao dao = new pbs_basic_MembersDao();

        public ResultInfo<bool> AddMembers(string memberName, int sex, int relationType, string birthday, string iDNum, int userId, DateTime createTime, DateTime updateTime, int creatorId, string remark)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.AddMembers(memberName, sex, relationType, birthday, iDNum, userId, createTime, updateTime, creatorId, remark);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = false;
            }
            return result;
        }

        public ResultInfo<bool> UpdateMembers(string memberName, int sex, int relationType, string birthday, string iDNum, int userId, DateTime createTime, DateTime updateTime, int creatorId, string remark, int membersId)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.UpdateMembers(memberName, sex, relationType, birthday, iDNum, userId, createTime, updateTime, creatorId, remark, membersId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = false;
            }
            return result;
        }

        public ResultInfo<bool> DeleteMembers(int MembersId)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.DeleteMembers(MembersId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = false;
            }
            return result;
        }

        public ResultInfo<pbs_basic_Members> GetMembersModelById(int membersId)
        {
            ResultInfo<pbs_basic_Members> result = new ResultInfo<pbs_basic_Members>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetMembersModelById(membersId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = null;
            }
            return result;
        }

        public ResultInfo<List<pbs_basic_Members>> GetMembersList()
        {
            ResultInfo<List<pbs_basic_Members>> result = new ResultInfo<List<pbs_basic_Members>>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetMembersList();
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = null;
            }
            return result;
        }

        public ResultInfo<List<pbs_basic_Members>> GetMembersListByUserId(int userId)
        {
            ResultInfo<List<pbs_basic_Members>> result = new ResultInfo<List<pbs_basic_Members>>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetMembersListByUserId(userId);
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
