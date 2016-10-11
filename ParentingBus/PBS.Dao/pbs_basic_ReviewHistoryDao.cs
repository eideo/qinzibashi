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
    public class pbs_basic_ReviewHistoryDao : DBOperation
    {
        public bool AddReviewHistory(string reviewTitle, string reviewContent, string reviewUrl, DateTime createTime, DateTime updateTime, int creatorId, string remark)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into pbs_basic_ReviewHistory(");
            strSql.Append(" ReviewTitle,ReviewContent,ReviewUrl,CreateTime,UpdateTime,CreatorId,Remark )");
            strSql.Append(" values (");
            strSql.Append(" @ReviewTitle,@ReviewContent,@ReviewUrl,@CreateTime,@UpdateTime,@CreatorId,@Remark )");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@ReviewTitle", SqlDbType.NVarChar,200),
                    new SqlParameter("@ReviewContent", SqlDbType.NVarChar,-1),
                    new SqlParameter("@ReviewUrl", SqlDbType.NVarChar,200),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@UpdateTime", SqlDbType.DateTime),
                    new SqlParameter("@CreatorId", SqlDbType.Int,4),
                    new SqlParameter("@Remark", SqlDbType.NVarChar,200)};
            parameters[0].Value = reviewTitle;
            parameters[1].Value = reviewContent;
            parameters[2].Value = reviewUrl;
            parameters[3].Value = createTime;
            parameters[4].Value = updateTime;
            parameters[5].Value = creatorId;
            parameters[6].Value = remark;

            int row = ExecuteNonQuery(strSql.ToString(), parameters);
            if (row > 0)
            {
                return true;

            }
            return false;
        }

        public bool UpdateReviewHistory(string reviewTitle, string reviewContent, string reviewUrl, DateTime createTime, DateTime updateTime, int creatorId, string remark, int reviewId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update pbs_basic_ReviewHistory set ");
            strSql.Append("ReviewTitle=@ReviewTitle,");
            strSql.Append("ReviewContent=@ReviewContent,");
            strSql.Append("ReviewUrl=@ReviewUrl,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("UpdateTime=@UpdateTime,");
            strSql.Append("CreatorId=@CreatorId,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where ReviewId=@ReviewId");
            SqlParameter[] parameters = {
                    new SqlParameter("@ReviewTitle", SqlDbType.NVarChar,200),
                    new SqlParameter("@ReviewContent", SqlDbType.NVarChar,-1),
                    new SqlParameter("@ReviewUrl", SqlDbType.NVarChar,200),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@UpdateTime", SqlDbType.DateTime),
                    new SqlParameter("@CreatorId", SqlDbType.Int,4),
                    new SqlParameter("@Remark", SqlDbType.NVarChar,200),
                    new SqlParameter("@ReviewId", SqlDbType.Int,4)};
            parameters[0].Value = reviewTitle;
            parameters[1].Value = reviewContent;
            parameters[2].Value = reviewUrl;
            parameters[3].Value = createTime;
            parameters[4].Value = updateTime;
            parameters[5].Value = creatorId;
            parameters[6].Value = remark;
            parameters[7].Value = reviewId;

            int row = ExecuteNonQuery(strSql.ToString(), parameters);
            if (row > 0)
            {
                return true;

            }
            return false;
        }

        public bool DeleteReviewHistory(int reviewId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from pbs_basic_ReviewHistory ");
            strSql.Append(" where ReviewId=@ReviewId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ReviewId", SqlDbType.Int,20)
                                        };
            parameters[0].Value = reviewId;
            return ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }

        public pbs_basic_ReviewHistory GetReviewHistoryModelById(int reviewId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ReviewId,ReviewTitle,ReviewContent,ReviewUrl,CreateTime,UpdateTime,CreatorId,Remark from pbs_basic_ReviewHistory ");
            strSql.Append(" where ReviewId=@ReviewId");
            SqlParameter[] parameters = {
                    new SqlParameter("@ReviewId", SqlDbType.Int,4)
            };
            parameters[0].Value = reviewId;

            DataTable ds = ExecuteDataset(strSql.ToString(), parameters).Tables[0];
            IList<pbs_basic_ReviewHistory> list = Utility.ModelConvertHelper<pbs_basic_ReviewHistory>.ConvertToModel(ds);
            return list.Count > 0 ? list[0] : null;
        }

        public List<pbs_basic_ReviewHistory> GetReviewHistoryList()
        {
            List<pbs_basic_ReviewHistory> list = new List<pbs_basic_ReviewHistory>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ReviewId,ReviewTitle,ReviewContent,ReviewUrl,CreateTime,UpdateTime,CreatorId,Remark ");
            strSql.Append(" FROM pbs_basic_ReviewHistory ");
            DataTable dt = ExecuteDataset(strSql.ToString()).Tables[0];
            IList<pbs_basic_ReviewHistory> ilist = Utility.ModelConvertHelper<pbs_basic_ReviewHistory>.ConvertToModel(dt);
            list = new List<pbs_basic_ReviewHistory>(ilist);
            return list;
        }
    }
}
