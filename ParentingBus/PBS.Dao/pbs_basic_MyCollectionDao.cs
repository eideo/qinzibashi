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
    public class pbs_basic_MyCollectionDao : DBOperation
    {
        public bool AddMyCollection(int userId,int goodsId, DateTime createTime, DateTime updateTime, int creatorId, string remark)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into pbs_basic_MyCollection(");
            strSql.Append("UserId,GoodsId,CreateTime,UpdateTime,CreatorId,Remark)");
            strSql.Append(" values (");
            strSql.Append("@UserId,@GoodsId,@CreateTime,@UpdateTime,@CreatorId,@Remark)");
            SqlParameter[] parameters = {
                    new SqlParameter("@userId", SqlDbType.Int,4),
                    new SqlParameter("@GoodsId", SqlDbType.Int,4),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@UpdateTime", SqlDbType.DateTime),
                    new SqlParameter("@CreatorId", SqlDbType.Int,4),
                    new SqlParameter("@Remark", SqlDbType.NVarChar,200)
            };
            parameters[0].Value = userId;
            parameters[1].Value = goodsId;
            parameters[2].Value = createTime;
            parameters[3].Value = updateTime;
            parameters[4].Value = creatorId;
            parameters[5].Value = remark;

            int row = ExecuteNonQuery(strSql.ToString(), parameters);
            if (row > 0)
            {
                return true;

            }
            return false;
        }

        public List<pbs_basic_MyCollectionView> GetMyCollectionViewListByUserId(int userId)
        {
            List<pbs_basic_MyCollectionView> list = new List<pbs_basic_MyCollectionView>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select a.UserId,a.GoodsId,b.GoodsName,b.GoodsMainImgUrl,b.VisitTime1,b.VisitTime2,b.VisitTime3,b.VisitTime4,b.VisitTime5,b.MarketPrice,b.SellingPrice,b.Remark as GoodsAdress ");
            strSql.Append(" from [dbo].[pbs_basic_MyCollection] a,[dbo].[pbs_basic_Goods] b where a.GoodsId=b.GoodsId and a.UserId=@userId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@userId", SqlDbType.Int,4)
            };
            parameters[0].Value = userId;

            DataTable dt = ExecuteDataset(strSql.ToString(), parameters).Tables[0];
            IList<pbs_basic_MyCollectionView> ilist = Utility.ModelConvertHelper<pbs_basic_MyCollectionView>.ConvertToModel(dt);
            list = new List<pbs_basic_MyCollectionView>(ilist);
            return list;
        }

    }
}
