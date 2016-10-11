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
    public class pbs_basic_CommentService
    {
        private pbs_basic_CommentDao dao = new pbs_basic_CommentDao();

        public ResultInfo<bool> AddComment(int goodsId, int userId, string commentContent, string url1, string url2, string url3, string url4, string url5, int score, DateTime createTime, DateTime updateTime, int creatorId, string remark)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.AddComment(goodsId, userId, commentContent, url1, url2, url3, url4, url5, score, createTime, updateTime, creatorId, remark);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = false;
            }
            return result;
        }

        public ResultInfo<bool> UpdateComment(int goodsId, int userId, string commentContent, string url1, string url2, string url3, string url4, string url5, int score, DateTime createTime, DateTime updateTime, int creatorId, string remark, int commentId)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.UpdateComment(goodsId, userId, commentContent, url1, url2, url3, url4, url5, score, createTime, updateTime, creatorId, remark,commentId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = false;
            }
            return result;
        }

        public ResultInfo<bool> DeleteComment(int commentId)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.DeleteComment(commentId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = false;
            }
            return result;
        }

        public ResultInfo<pbs_basic_Comment> GetCommentModelById(int commentId)
        {
            ResultInfo<pbs_basic_Comment> result = new ResultInfo<pbs_basic_Comment>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetCommentModelById(commentId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = null;
            }
            return result;
        }

        public ResultInfo<List<pbs_basic_CommentView>> GetCommentListByGoodsID(int goodsId)
        {
            ResultInfo<List<pbs_basic_CommentView>> result = new ResultInfo<List<pbs_basic_CommentView>>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetCommentListByGoodsID(goodsId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = null;
            }
            return result;
        }

        public ResultInfo<List<pbs_basic_CommentView>> GetCommentList(int goodsId, int userId)
        {
            ResultInfo<List<pbs_basic_CommentView>> result = new ResultInfo<List<pbs_basic_CommentView>>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetCommentList(goodsId, userId);
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
