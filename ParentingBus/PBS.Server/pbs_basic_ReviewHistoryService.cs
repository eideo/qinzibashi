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
    public class pbs_basic_ReviewHistoryService
    {
        pbs_basic_ReviewHistoryDao dao = new pbs_basic_ReviewHistoryDao();

        public ResultInfo<bool> AddReviewHistory(string reviewTitle, string reviewContent, string reviewUrl, DateTime createTime, DateTime updateTime, int creatorId, string remark)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.AddReviewHistory(reviewTitle, reviewContent, reviewUrl, createTime, updateTime, creatorId, remark);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = false;
            }
            return result;
        }

        public ResultInfo<bool> UpdateReviewHistory(string reviewTitle, string reviewContent, string reviewUrl, DateTime createTime, DateTime updateTime, int creatorId, string remark, int reviewId)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.UpdateReviewHistory(reviewTitle, reviewContent, reviewUrl, createTime, updateTime, creatorId, remark, reviewId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = false;
            }
            return result;
        }

        public ResultInfo<bool> DeleteReviewHistory(int reviewId)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.DeleteReviewHistory(reviewId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = false;
            }
            return result;
        }

        public ResultInfo<pbs_basic_ReviewHistory> GetReviewHistoryModelById(int reviewId)
        {
            ResultInfo<pbs_basic_ReviewHistory> result = new ResultInfo<pbs_basic_ReviewHistory>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetReviewHistoryModelById(reviewId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = null;
            }
            return result;
        }

        public ResultInfo<List<pbs_basic_ReviewHistory>> GetReviewHistoryList()
        {
            ResultInfo<List<pbs_basic_ReviewHistory>> result = new ResultInfo<List<pbs_basic_ReviewHistory>>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetReviewHistoryList();
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
