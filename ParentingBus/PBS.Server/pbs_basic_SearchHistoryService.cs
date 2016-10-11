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
    public class pbs_basic_SearchHistoryService
    {
        pbs_basic_SearchHistoryDao dao = new pbs_basic_SearchHistoryDao();

        public ResultInfo<bool> AddSearchHistory(int searchId, int userId, DateTime createTime, DateTime updateTime, int creatorId, string remark)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.AddSearchHistory(searchId, userId, createTime, updateTime, creatorId, remark);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = false;
            }
            return result;
        }

        public ResultInfo<bool> UpdateSearchHistory(int searchId, int userId, DateTime createTime, DateTime updateTime, int creatorId, string remark, int historyId)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.UpdateSearchHistory(searchId, userId, createTime, updateTime, creatorId, remark, historyId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = false;
            }
            return result;
        }

        public ResultInfo<bool> DeleteSearchHistory(int historyId)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.DeleteSearchHistory(historyId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = false;
            }
            return result;
        }

        public ResultInfo<pbs_basic_SearchHistory> GetSearchHistoryModelById(int historyId)
        {
            ResultInfo<pbs_basic_SearchHistory> result = new ResultInfo<pbs_basic_SearchHistory>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetSearchHistoryModelById(historyId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = null;
            }
            return result;
        }

        public ResultInfo<List<pbs_basic_SearchHistory>> GetSearchHistoryList(int userId)
        {
            ResultInfo<List<pbs_basic_SearchHistory>> result = new ResultInfo<List<pbs_basic_SearchHistory>>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetSearchHistoryList(userId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = null;
            }
            return result;
        }

        public ResultInfo<List<pbs_basic_SearchHistoryView>> GetSearchHistoryViewList(int userId)
        {
            ResultInfo<List<pbs_basic_SearchHistoryView>> result = new ResultInfo<List<pbs_basic_SearchHistoryView>>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetSearchHistoryViewList(userId);
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
