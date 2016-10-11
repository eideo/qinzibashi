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
    public class pbs_basic_AgeRangeService
    {
        private pbs_basic_AgeRangeDao dao = new pbs_basic_AgeRangeDao();

        /// <summary>
        /// 获取所有年龄范围列表
        /// </summary>
        /// <returns></returns>
        public ResultInfo<List<pbs_basic_AgeRange>> GetAllAgeRangeList()
        {
            ResultInfo<List<pbs_basic_AgeRange>> result = new ResultInfo<List<pbs_basic_AgeRange>>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetAllAgeRangeList();
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
        /// 根据年龄范围编号获取年龄范围对象实体
        /// </summary>
        /// <param name="ageRangeId">年龄范围编号</param>
        /// <returns></returns>
        public ResultInfo<pbs_basic_AgeRange> GetAgeRangeModelById(int ageRangeId)
        {
            ResultInfo<pbs_basic_AgeRange> result = new ResultInfo<pbs_basic_AgeRange>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetAgeRangeModelById(ageRangeId);
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
        /// 增加一条年龄范围记录
        /// </summary>
        /// <param name="ageRangeName">年龄范围名称</param>
        /// <param name="createTime">创建时间</param>
        /// <param name="updateTime">修改时间</param>
        /// <param name="creatorId">创建者id</param>
        /// <param name="remark">备注</param>
        /// <returns></returns>
        public ResultInfo<bool> AddAgeRange(string ageRangeName, DateTime createTime, DateTime updateTime, int creatorId, string remark)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.AddAgeRange(ageRangeName, createTime, updateTime, creatorId, remark);
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
        /// 修改一条年龄范围记录
        /// </summary>
        /// <param name="ageRangeName">年龄范围名称</param>
        /// <param name="createTime">创建时间</param>
        /// <param name="updateTime">修改时间</param>
        /// <param name="creatorId">创建者id</param>
        /// <param name="remark">备注</param>
        /// <param name="ageRangeId">年龄范围编号</param>
        /// <returns></returns>
        public ResultInfo<bool> UpdateAgeRange(string ageRangeName, DateTime createTime, DateTime updateTime, int creatorId, string remark, int ageRangeId)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.UpdateAgeRange(ageRangeName, createTime, updateTime, creatorId, remark, ageRangeId);
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
        /// 删除一条年龄范围记录
        /// </summary>
        /// <param name="ageRangeId">年龄范围编号</param>
        /// <returns></returns>
        public ResultInfo<bool> DeleteAgeRange(int ageRangeId)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.DeleteAgeRange(ageRangeId);
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
        /// 根据年龄范围名称判断是否存在该分类
        /// </summary>
        /// <param name="ageRangeName">年龄范围名称</param>
        /// <returns></returns>
        public ResultInfo<bool> IsExistByAgeRangeName(string ageRangeName)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.IsExistByAgeRangeName(ageRangeName);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = false;
            }
            return result;
        }

        public ResultInfo<bool> IsExistByAgeRangeId(int ageRangeId)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.IsExistByAgeRangeId(ageRangeId);
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
