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
    public class pbs_basic_RegionDao : DBOperation
    {
        /// <summary>
        /// 获取所有北京地区列表
        /// </summary>
        /// <returns></returns>
        public List<pbs_basic_Region> GetAllRegionList()
        {
            List<pbs_basic_Region> list;
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" (select * from pbs_basic_Region where ParentRegionId=110100 or RegionId=110100) ");
            strSql.Append(" UNION ");
            strSql.Append(" (select * from pbs_basic_Region where ParentRegionId in(select a.RegionId from pbs_basic_Region a where ParentRegionId = 110100)) ");

            //strSql.Append(" select * from pbs_basic_Region ");

            DataTable dt = ExecuteDataset(strSql.ToString()).Tables[0];
            IList<pbs_basic_Region> ilist = Utility.ModelConvertHelper<pbs_basic_Region>.ConvertToModel(dt);
            list = new List<pbs_basic_Region>(ilist);
            return list.Count > 0 ? list : null;
        }

        /// <summary>
        ///  根据父区域编号获取区域列表
        /// </summary>
        /// <param name="parentRegionId">父区域编号</param>
        /// <returns></returns>
        public List<pbs_basic_Region> GetThisRegionList(int parentRegionId)
        {
            List<pbs_basic_Region> list;
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select * from pbs_basic_Region");
            strSql.Append(" where ParentRegionId=@parentRegionId");
            SqlParameter[] parameters = {
                    new SqlParameter("@parentRegionId", SqlDbType.Int,4)};
            parameters[0].Value = parentRegionId;
            DataTable dt = ExecuteDataset(strSql.ToString(), parameters).Tables[0];
            IList<pbs_basic_Region> ilist = Utility.ModelConvertHelper<pbs_basic_Region>.ConvertToModel(dt);
            list = new List<pbs_basic_Region>(ilist);

            return list;
        }

        /// <summary>
        /// 根据区域编号获取区域对象实体
        /// </summary>
        /// <param name="regionId">区域编号</param>
        /// <returns></returns>
        public pbs_basic_Region GetRegionModelById(int regionId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT [RegionId],[RegionName],[ParentRegionId],[CreateTime],[UpdateTime],[CreatorId],[Remark] FROM pbs_basic_Region ");
            strSql.Append(" where RegionId=@RegionId");
            SqlParameter[] parameters = {
					new SqlParameter("@RegionId", SqlDbType.Int,4)
			};
            parameters[0].Value = regionId;

            DataTable ds = ExecuteDataset(strSql.ToString(), parameters).Tables[0];
            IList<pbs_basic_Region> list = Utility.ModelConvertHelper<pbs_basic_Region>.ConvertToModel(ds);
            return list.Count > 0 ? list[0] : null;
        }

        /// <summary>
        /// 增加一条区域记录
        /// </summary>
        /// <param name="regionName">区域名称</param>
        /// <param name="parentRegionId">父节点区域id</param>
        /// <param name="createTime">创建时间</param>
        /// <param name="updateTime">修改时间</param>
        /// <param name="creatorId">创建者id</param>
        /// <param name="remark">备注</param>
        /// <returns></returns>
        public bool AddRegion(string regionName, int parentRegionId, DateTime createTime, DateTime updateTime, int creatorId, string remark)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into pbs_basic_Region(");
            strSql.Append("RegionName,ParentRegionId,CreateTime,UpdateTime,CreatorId,Remark)");
            strSql.Append(" values (");
            strSql.Append("@RegionName,@ParentRegionId,@CreateTime,@UpdateTime,@CreatorId,@Remark)");
            SqlParameter[] parameters = {
					new SqlParameter("@RegionName", SqlDbType.NVarChar,200),
                    new SqlParameter("@ParentRegionId", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
                    new SqlParameter("@CreatorId", SqlDbType.Int,4),
                    new SqlParameter("@Remark", SqlDbType.NVarChar,200)
            };
            parameters[0].Value = regionName;
            parameters[1].Value = parentRegionId;
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

        /// <summary>
        /// 修改一条区域记录
        /// </summary>
        /// <param name="regionName">区域名称</param>
        /// <param name="parentRegionId">父节点区域id</param>
        /// <param name="createTime">创建时间</param>
        /// <param name="updateTime">修改时间</param>
        /// <param name="creatorId">创建者id</param>
        /// <param name="remark">备注</param>
        /// <param name="regionId">商品分类编号</param>
        /// <returns></returns>
        public bool UpdateRegion(string regionName, int parentRegionId, DateTime createTime, DateTime updateTime, int creatorId, string remark, int regionId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update pbs_basic_Region set ");
            strSql.Append("RegionName=@RegionName,");
            strSql.Append("ParentRegionId=@ParentRegionId,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("UpdateTime=@UpdateTime,");
            strSql.Append("CreatorId=@CreatorId,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where RegionId=@RegionId ");
            SqlParameter[] parameters = {
					new SqlParameter("@RegionName", SqlDbType.NVarChar,200),
                    new SqlParameter("@ParentRegionId", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@UpdateTime", SqlDbType.DateTime),
                    new SqlParameter("@CreatorId", SqlDbType.Int,4),
                    new SqlParameter("@Remark", SqlDbType.NVarChar,200),
                    new SqlParameter("@RegionId", SqlDbType.Int,4)};
            parameters[0].Value = regionName;
            parameters[1].Value = parentRegionId;
            parameters[2].Value = createTime;
            parameters[3].Value = updateTime;
            parameters[4].Value = creatorId;
            parameters[5].Value = remark;
            parameters[6].Value = regionId;

            int row = ExecuteNonQuery(strSql.ToString(), parameters);
            if (row > 0)
            {
                return true;

            }
            return false;
        }

    }
}
