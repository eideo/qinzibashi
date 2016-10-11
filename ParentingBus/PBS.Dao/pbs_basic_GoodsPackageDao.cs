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
    public class pbs_basic_GoodsPackageDao : DBOperation
    {
        public List<pbs_basic_GoodsPackageView> GetAllGoodsPackageList()
        {
            List<pbs_basic_GoodsPackageView> list = new List<pbs_basic_GoodsPackageView>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select a.GoodsPackageId,a.GoodsPackageName,a.GoodsPackagePrice,a.GoodsTypeId,a.CreateTime,a.UpdateTime,a.CreatorId,a.Remark,b.GoodsTypeName from pbs_basic_GoodsPackage a,pbs_basic_GoodsType b ");
            strSql.Append(" where a.GoodsTypeId=b.GoodsTypeId ");
            DataTable dt = ExecuteDataset(strSql.ToString()).Tables[0];
            IList<pbs_basic_GoodsPackageView> ilist = Utility.ModelConvertHelper<pbs_basic_GoodsPackageView>.ConvertToModel(dt);
            list = new List<pbs_basic_GoodsPackageView>(ilist);
            return list;
        }

        public List<pbs_basic_GoodsPackage> GetAllGoodsPackageListByGoodsTypeId(int goodsTypeId)
        {
            List<pbs_basic_GoodsPackage> list = new List<pbs_basic_GoodsPackage>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select [GoodsPackageId],[GoodsPackageName],[GoodsPackagePrice],[GoodsTypeId],[CreateTime],[UpdateTime],[CreatorId],[Remark] from [dbo].[pbs_basic_GoodsPackage] ");
            strSql.Append(" where GoodsTypeId=@GoodsTypeId");

            SqlParameter[] parameters = {
                    new SqlParameter("@GoodsTypeId", SqlDbType.Int,4)
            };
            parameters[0].Value = goodsTypeId;
            DataTable dt = ExecuteDataset(strSql.ToString(), parameters).Tables[0];
            IList<pbs_basic_GoodsPackage> ilist = Utility.ModelConvertHelper<pbs_basic_GoodsPackage>.ConvertToModel(dt);
            list = new List<pbs_basic_GoodsPackage>(ilist);
            return list;
        }

        public pbs_basic_GoodsPackage GetGoodsPackageModelById(int goodsPackageId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT [GoodsPackageId],[GoodsPackageName],[GoodsPackagePrice],[GoodsTypeId],[CreateTime],[UpdateTime],[CreatorId],[Remark] FROM pbs_basic_GoodsPackage ");
            strSql.Append(" where GoodsPackageId=@GoodsPackageId");
            SqlParameter[] parameters = {
                    new SqlParameter("@GoodsPackageId", SqlDbType.Int,4)
            };
            parameters[0].Value = goodsPackageId;

            DataTable ds = ExecuteDataset(strSql.ToString(), parameters).Tables[0];
            IList<pbs_basic_GoodsPackage> list = Utility.ModelConvertHelper<pbs_basic_GoodsPackage>.ConvertToModel(ds);
            return list.Count > 0 ? list[0] : null;
        }

        public bool AddGoodsPackage(string goodsPackageName,decimal goodsPackagePrice, int goodsTypeId, DateTime createTime, DateTime updateTime, int creatorId, string remark)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into pbs_basic_GoodsPackage(");
            strSql.Append("GoodsPackageName,GoodsPackagePrice,GoodsTypeId,CreateTime,UpdateTime,CreatorId,Remark)");
            strSql.Append(" values (");
            strSql.Append("@GoodsPackageName,@GoodsPackagePrice,@GoodsTypeId,@CreateTime,@UpdateTime,@CreatorId,@Remark)");
            SqlParameter[] parameters = {
                    new SqlParameter("@GoodsPackageName", SqlDbType.NVarChar,200),
                    new SqlParameter("@GoodsPackagePrice", SqlDbType.Decimal,9),
                    new SqlParameter("@GoodsTypeId", SqlDbType.Int,4),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@UpdateTime", SqlDbType.DateTime),
                    new SqlParameter("@CreatorId", SqlDbType.Int,4),
                    new SqlParameter("@Remark", SqlDbType.NVarChar,200)
            };
            parameters[0].Value = goodsPackageName;
            parameters[1].Value = goodsPackagePrice;
            parameters[2].Value = goodsTypeId;
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

        public bool UpdateGoodsPackage(string goodsPackageName, decimal goodsPackagePrice, int goodsTypeId, DateTime createTime, DateTime updateTime, int creatorId, string remark, int goodsPackageId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update pbs_basic_GoodsPackage set ");
            strSql.Append("GoodsPackageName=@GoodsPackageName,");
            strSql.Append("GoodsPackagePrice=@GoodsPackagePrice,");
            strSql.Append("GoodsTypeId=@GoodsTypeId,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("UpdateTime=@UpdateTime,");
            strSql.Append("CreatorId=@CreatorId,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where GoodsPackageId=@GoodsPackageId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@GoodsPackageName", SqlDbType.NVarChar,200),
                    new SqlParameter("@GoodsPackagePrice", SqlDbType.Decimal,9),
                    new SqlParameter("@GoodsTypeId", SqlDbType.Int,4),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@UpdateTime", SqlDbType.DateTime),
                    new SqlParameter("@CreatorId", SqlDbType.Int,4),
                    new SqlParameter("@Remark", SqlDbType.NVarChar,200),
                    new SqlParameter("@GoodsPackageId", SqlDbType.Int,4)};
            parameters[0].Value = goodsPackageName;
            parameters[1].Value = goodsPackagePrice;
            parameters[2].Value = goodsTypeId;
            parameters[3].Value = createTime;
            parameters[4].Value = updateTime;
            parameters[5].Value = creatorId;
            parameters[6].Value = remark;
            parameters[7].Value = goodsPackageId;

            int row = ExecuteNonQuery(strSql.ToString(), parameters);
            if (row > 0)
            {
                return true;

            }
            return false;
        }

        public bool DeleteGoodsPackage(int goodsPackageId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from pbs_basic_GoodsPackage ");
            strSql.Append(" where GoodsPackageId=@GoodsPackageId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@GoodsPackageId", SqlDbType.Int,20)
                                        };
            parameters[0].Value = goodsPackageId;
            return ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }

        public bool IsExistByGoodsPackageName(string goodsPackageName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select COUNT(GoodsPackageId) from pbs_basic_GoodsPackage ");
            strSql.Append(" where GoodsPackageName=@GoodsPackageName ");
            SqlParameter[] parameters = {
                    new SqlParameter("@GoodsPackageName", SqlDbType.NVarChar,255)
                                        };
            parameters[0].Value = goodsPackageName;
            return ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }

        public bool IsExistByGoodsPackageId(int goodsPackageId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select COUNT(GoodsPackageId) from pbs_basic_GoodsPackage ");
            strSql.Append(" where GoodsPackageId=@GoodsPackageId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@GoodsPackageId", SqlDbType.Int,20)
                                        };
            parameters[0].Value = goodsPackageId;
            return (int)ExecuteScalar(strSql.ToString(), CommandType.Text, parameters) > 0;
        }
    }
}
