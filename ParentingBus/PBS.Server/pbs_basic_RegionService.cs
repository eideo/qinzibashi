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
    public class pbs_basic_RegionService
    {
        private pbs_basic_RegionDao dao = new pbs_basic_RegionDao();

        /// <summary>
        /// 获取所有北京地区列表
        /// </summary>
        /// <returns></returns>
        public ResultInfo<List<pbs_basic_Region>> GetAllRegionList()
        {
            ResultInfo<List<pbs_basic_Region>> result = new ResultInfo<List<pbs_basic_Region>>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetAllRegionList();
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = null;
            }
            return result;
        }

        /// <summary>
        ///  根据父区域编号获取区域列表
        /// </summary>
        /// <param name="parentRegionId">父区域编号</param>
        /// <returns></returns>
        public ResultInfo<List<pbs_basic_Region>> GetThisRegionList(int parentRegionId)
        {
            ResultInfo<List<pbs_basic_Region>> result = new ResultInfo<List<pbs_basic_Region>>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetThisRegionList(parentRegionId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = null;
            }
            return result;
        }

        /// <summary>
        /// 根据区域编号获取区域对象实体
        /// </summary>
        /// <param name="regionId">区域编号</param>
        /// <returns></returns>
        public ResultInfo<pbs_basic_Region> GetRegionModelById(int regionId)
        {
            ResultInfo<pbs_basic_Region> result = new ResultInfo<pbs_basic_Region>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetRegionModelById(regionId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = null;
            }
            return result;
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
        public ResultInfo<bool> AddRegion(string regionName, int parentRegionId, DateTime createTime, DateTime updateTime, int creatorId, string remark)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.AddRegion(regionName, parentRegionId, createTime, updateTime, creatorId, remark);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = false;
            }
            return result;
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
        /// <param name="regionId">优惠券编号</param>
        /// <returns></returns>
        public ResultInfo<bool> UpdateRegion(string regionName, int parentRegionId, DateTime createTime, DateTime updateTime, int creatorId, string remark, int regionId)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.UpdateRegion(regionName, parentRegionId, createTime, updateTime, creatorId, remark, regionId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = false;
            }
            return result;
        }

    }
}
