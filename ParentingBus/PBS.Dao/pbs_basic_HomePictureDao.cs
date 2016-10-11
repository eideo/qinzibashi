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
    public class pbs_basic_HomePictureDao : DBOperation
    {
        public bool AddHomePicture(string url, int orderBy, DateTime createTime, DateTime updateTime, int creatorId, string remark,string linkUrl)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into pbs_basic_HomePicture(");
            strSql.Append(" Url,OrderBy,CreateTime,UpdateTime,CreatorId,Remark,LinkUrl )");
            strSql.Append(" values (");
            strSql.Append(" @Url,@OrderBy,@CreateTime,@UpdateTime,@CreatorId,@Remark,@LinkUrl )");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@Url", SqlDbType.NVarChar,200),
                    new SqlParameter("@OrderBy", SqlDbType.Int,4),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@UpdateTime", SqlDbType.DateTime),
                    new SqlParameter("@CreatorId", SqlDbType.Int,4),
                    new SqlParameter("@Remark", SqlDbType.NVarChar,200),
                    new SqlParameter("@LinkUrl", SqlDbType.NVarChar,200)};
            parameters[0].Value = url;
            parameters[1].Value = orderBy;
            parameters[2].Value = createTime;
            parameters[3].Value = updateTime;
            parameters[4].Value = creatorId;
            parameters[5].Value = remark;
            parameters[6].Value = linkUrl;

            int row = ExecuteNonQuery(strSql.ToString(), parameters);
            if (row > 0)
            {
                return true;

            }
            return false;
        }

        public bool UpdateHomePicture(string url, int orderBy, DateTime createTime, DateTime updateTime, int creatorId, string remark, string linkUrl, int homePictureId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update pbs_basic_HomePicture set ");
            strSql.Append("Url=@Url,");
            strSql.Append("OrderBy=@OrderBy,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("UpdateTime=@UpdateTime,");
            strSql.Append("CreatorId=@CreatorId,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("LinkUrl=@LinkUrl");
            strSql.Append(" where HomePictureId=@HomePictureId");
            SqlParameter[] parameters = {
                    new SqlParameter("@Url", SqlDbType.NVarChar,200),
                    new SqlParameter("@OrderBy", SqlDbType.Int,4),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@UpdateTime", SqlDbType.DateTime),
                    new SqlParameter("@CreatorId", SqlDbType.Int,4),
                    new SqlParameter("@Remark", SqlDbType.NVarChar,200),
                    new SqlParameter("@LinkUrl", SqlDbType.NVarChar,200),
                    new SqlParameter("@HomePictureId", SqlDbType.Int,4)};
            parameters[0].Value = url;
            parameters[1].Value = orderBy;
            parameters[2].Value = createTime;
            parameters[3].Value = updateTime;
            parameters[4].Value = creatorId;
            parameters[5].Value = remark;
            parameters[6].Value = linkUrl;
            parameters[7].Value = homePictureId;

            int row = ExecuteNonQuery(strSql.ToString(), parameters);
            if (row > 0)
            {
                return true;

            }
            return false;
        }

        public bool DeleteHomePicture(int homePictureId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from pbs_basic_HomePicture ");
            strSql.Append(" where HomePictureId=@HomePictureId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@HomePictureId", SqlDbType.Int,20)
                                        };
            parameters[0].Value = homePictureId;
            return ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }

        public pbs_basic_HomePicture GetHomePictureModelById(int homePictureId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 HomePictureId,Url,OrderBy,CreateTime,UpdateTime,CreatorId,Remark,LinkUrl from pbs_basic_HomePicture ");
            strSql.Append(" where HomePictureId=@HomePictureId");
            SqlParameter[] parameters = {
                    new SqlParameter("@HomePictureId", SqlDbType.Int,4)
            };
            parameters[0].Value = homePictureId;

            DataTable ds = ExecuteDataset(strSql.ToString(), parameters).Tables[0];
            IList<pbs_basic_HomePicture> list = Utility.ModelConvertHelper<pbs_basic_HomePicture>.ConvertToModel(ds);
            return list.Count > 0 ? list[0] : null;
        }

        public List<pbs_basic_HomePicture> GetHomePictureList()
        {
            List<pbs_basic_HomePicture> list = new List<pbs_basic_HomePicture>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT HomePictureId,Url,OrderBy,CreateTime,UpdateTime,CreatorId,Remark,LinkUrl ");
            strSql.Append(" FROM pbs_basic_HomePicture ");
            DataTable dt = ExecuteDataset(strSql.ToString()).Tables[0];
            IList<pbs_basic_HomePicture> ilist = Utility.ModelConvertHelper<pbs_basic_HomePicture>.ConvertToModel(dt);
            list = new List<pbs_basic_HomePicture>(ilist);
            return list;
        }
    }
}
