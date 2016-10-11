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
    public class pbs_basic_CommentDao : DBOperation
    {
        public bool AddComment(int goodsId, int userId,string commentContent, string url1, string url2, string url3, string url4, string url5, int score,DateTime createTime, DateTime updateTime,int creatorId,string remark)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into pbs_basic_Comment(");
            strSql.Append(" GoodsId,UserId,CommentContent,Url1,Url2,Url3,Url4,Url5,Score,CreateTime,UpdateTime,CreatorId,Remark )");
            strSql.Append(" values (");
            strSql.Append(" @GoodsId,@UserId,@CommentContent,@Url1,@Url2,@Url3,@Url4,@Url5,@Score,@CreateTime,@UpdateTime,@CreatorId,@Remark )");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@GoodsId", SqlDbType.Int,4),
                    new SqlParameter("@UserId", SqlDbType.Int,4),
                    new SqlParameter("@CommentContent", SqlDbType.NVarChar,200),
                    new SqlParameter("@Url1", SqlDbType.NVarChar,200),
                    new SqlParameter("@Url2", SqlDbType.NVarChar,200),
                    new SqlParameter("@Url3", SqlDbType.NVarChar,200),
                    new SqlParameter("@Url4", SqlDbType.NVarChar,200),
                    new SqlParameter("@Url5", SqlDbType.NVarChar,200),
                    new SqlParameter("@Score", SqlDbType.Int,4),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@UpdateTime", SqlDbType.DateTime),
                    new SqlParameter("@CreatorId", SqlDbType.Int,4),
                    new SqlParameter("@Remark", SqlDbType.NVarChar,200)};
            parameters[0].Value = goodsId;
            parameters[1].Value = userId;
            parameters[2].Value = commentContent;
            parameters[3].Value = url1;
            parameters[4].Value = url2;
            parameters[5].Value = url3;
            parameters[6].Value = url4;
            parameters[7].Value = url5;
            parameters[8].Value = score;
            parameters[9].Value = createTime;
            parameters[10].Value = updateTime;
            parameters[11].Value = creatorId;
            parameters[12].Value = remark;

            int row = ExecuteNonQuery(strSql.ToString(), parameters);
            if (row > 0)
            {
                return true;

            }
            return false;
        }

        public bool UpdateComment(int goodsId, int userId, string commentContent, string url1, string url2, string url3, string url4, string url5, int score, DateTime createTime, DateTime updateTime, int creatorId, string remark, int commentId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update pbs_basic_Comment set ");
            strSql.Append("UserId=@UserId,");
            strSql.Append("CommentContent=@CommentContent,");
            strSql.Append("Url1=@Url1,");
            strSql.Append("Url2=@Url2,");
            strSql.Append("Url3=@Url3,");
            strSql.Append("Url4=@Url4,");
            strSql.Append("Url5=@Url5,");
            strSql.Append("Score=@Score,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("UpdateTime=@UpdateTime,");
            strSql.Append("CreatorId=@CreatorId,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where CommentId=@CommentId");
            SqlParameter[] parameters = {
                    new SqlParameter("@GoodsId", SqlDbType.Int,4),
                    new SqlParameter("@UserId", SqlDbType.Int,4),
                    new SqlParameter("@CommentContent", SqlDbType.NVarChar,200),
                    new SqlParameter("@Url1", SqlDbType.NVarChar,200),
                    new SqlParameter("@Url2", SqlDbType.NVarChar,200),
                    new SqlParameter("@Url3", SqlDbType.NVarChar,200),
                    new SqlParameter("@Url4", SqlDbType.NVarChar,200),
                    new SqlParameter("@Url5", SqlDbType.NVarChar,200),
                    new SqlParameter("@Score", SqlDbType.Int,4),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@UpdateTime", SqlDbType.DateTime),
                    new SqlParameter("@CreatorId", SqlDbType.Int,4),
                    new SqlParameter("@Remark", SqlDbType.NVarChar,200),
                    new SqlParameter("@CommentId", SqlDbType.Int,4)};
            parameters[0].Value = goodsId;
            parameters[1].Value = userId;
            parameters[2].Value = commentContent;
            parameters[3].Value = url1;
            parameters[4].Value = url2;
            parameters[5].Value = url3;
            parameters[6].Value = url4;
            parameters[7].Value = url5;
            parameters[8].Value = score;
            parameters[9].Value = createTime;
            parameters[10].Value = updateTime;
            parameters[11].Value = creatorId;
            parameters[12].Value = remark;
            parameters[13].Value = commentId;

            int row = ExecuteNonQuery(strSql.ToString(), parameters);
            if (row > 0)
            {
                return true;

            }
            return false;
        }

        public bool DeleteComment(int commentId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from pbs_basic_Comment ");
            strSql.Append(" where CommentId=@CommentId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@CommentId", SqlDbType.Int,20)
                                        };
            parameters[0].Value = commentId;
            return ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }

        public pbs_basic_Comment GetCommentModelById(int commentId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 CommentId,GoodsId,UserId,CommentContent,Url1,Url2,Url3,Url4,Url5,Score,CreateTime,UpdateTime,CreatorId,Remark from pbs_basic_Comment ");
            strSql.Append(" where CommentId=@CommentId");
            SqlParameter[] parameters = {
                    new SqlParameter("@CommentId", SqlDbType.Int,4)
            };
            parameters[0].Value = commentId;

            DataTable ds = ExecuteDataset(strSql.ToString(), parameters).Tables[0];
            IList<pbs_basic_Comment> list = Utility.ModelConvertHelper<pbs_basic_Comment>.ConvertToModel(ds);
            return list.Count > 0 ? list[0] : null;
        }

        public List<pbs_basic_CommentView> GetCommentListByGoodsID(int goodsId)
        {
            List<pbs_basic_CommentView> list = new List<pbs_basic_CommentView>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CommentId,GoodsId,UserId,CommentContent,Url1,Url2,Url3,Url4,Url5,Score,CreateTime,UpdateTime,CreatorId,Remark from pbs_basic_Comment ");
            strSql.Append(" where GoodsId=@GoodsId");
            SqlParameter[] parameters = {
                    new SqlParameter("@GoodsId", SqlDbType.Int,4)
            };
            parameters[0].Value = goodsId;

            DataTable dt = ExecuteDataset(strSql.ToString(), parameters).Tables[0];

            IList<pbs_basic_CommentView> ilist = Utility.ModelConvertHelper<pbs_basic_CommentView>.ConvertToModel(dt);
            list = new List<pbs_basic_CommentView>(ilist);

            return list;
        }

        public List<pbs_basic_CommentView> GetCommentList(int goodsId, int userId)
        {
            List<pbs_basic_CommentView> list = new List<pbs_basic_CommentView>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT a.CommentId,a.GoodsId,a.UserId,a.CommentContent,a.Url1,a.Url2,a.Url3,a.Url4,a.Url5,a.Score,a.CreateTime,a.UpdateTime,a.CreatorId,a.Remark,b.LoginName,b.PhotoUrl ");
            strSql.Append(" FROM pbs_basic_Comment a,pbs_basic_Users b ");
            strSql.Append(" WHERE a.UserId=b.UserId ");

            if (goodsId != -1)
            {
                strSql.Append(" AND a.GoodsId=@GoodsId ");
            }

            if (userId != -1)
            {
                strSql.Append(" AND a.UserId=@UserId ");
            }

            SqlParameter[] parameters ={
                new SqlParameter("@GoodsId",SqlDbType.Int,4),
                new SqlParameter("@UserId",SqlDbType.Int,4)
            };

            parameters[0].Value = goodsId;
            parameters[1].Value = userId;

            DataTable dt = ExecuteDataset(strSql.ToString(), parameters).Tables[0];

            IList<pbs_basic_CommentView> ilist = Utility.ModelConvertHelper<pbs_basic_CommentView>.ConvertToModel(dt);
            list = new List<pbs_basic_CommentView>(ilist);

            return list;
        }

    }
}
