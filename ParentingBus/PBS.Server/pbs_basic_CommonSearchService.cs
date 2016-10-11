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
    public class pbs_basic_CommonSearchService
    {
        pbs_basic_CommonSearchDao dao = new pbs_basic_CommonSearchDao();

        public ResultInfo<bool> AddSearch(string searchNickName, int goodsId, DateTime createTime, DateTime updateTime, int creatorId, string remark)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.AddSearch(searchNickName, goodsId, createTime, updateTime, creatorId, remark);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = false;
            }
            return result;
        }

        public ResultInfo<bool> UpdateSearch(string searchNickName, int goodsId, DateTime createTime, DateTime updateTime, int creatorId, string remark, int searchId)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.UpdateSearch(searchNickName, goodsId, createTime, updateTime, creatorId, remark, searchId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = false;
            }
            return result;
        }

        public ResultInfo<bool> DeleteSearch(int searchId)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.DeleteSearch(searchId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = false;
            }
            return result;
        }

        public ResultInfo<pbs_basic_CommonSearch> GetSearchModelById(int searchId)
        {
            ResultInfo<pbs_basic_CommonSearch> result = new ResultInfo<pbs_basic_CommonSearch>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetSearchModelById(searchId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = null;
            }
            return result;
        }

        public ResultInfo<List<pbs_basic_CommonSearch>> GetSearchList()
        {
            ResultInfo<List<pbs_basic_CommonSearch>> result = new ResultInfo<List<pbs_basic_CommonSearch>>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetSearchList();
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
