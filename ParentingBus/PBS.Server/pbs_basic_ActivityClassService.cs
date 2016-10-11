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
    public class pbs_basic_ActivityClassService
    {
        private pbs_basic_ActivityClassDao dao = new pbs_basic_ActivityClassDao();

        /// <summary>
        /// 获取所有商品筛选分类列表
        /// </summary>
        /// <returns></returns>
        public ResultInfo<List<pbs_basic_ActivityClass>> GetAllActivityClassList()
        {
            ResultInfo<List<pbs_basic_ActivityClass>> result = new ResultInfo<List<pbs_basic_ActivityClass>>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetAllActivityClassList();
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
        /// 根据商品类别编号获取商品类别对象实体
        /// </summary>
        /// <param name="activityClassId">商品筛选分类编号</param>
        /// <returns></returns>
        public ResultInfo<pbs_basic_ActivityClass> GetActivityClassModelById(int activityClassId)
        {
            ResultInfo<pbs_basic_ActivityClass> result = new ResultInfo<pbs_basic_ActivityClass>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetActivityClassModelById(activityClassId);
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
        /// 增加一条商品筛选分类记录
        /// </summary>
        /// <param name="activityClassName">商品筛选分类名称</param>
        /// <param name="createTime">创建时间</param>
        /// <param name="updateTime">修改时间</param>
        /// <param name="creatorId">创建者id</param>
        /// <param name="remark">备注</param>
        /// <returns></returns>
        public ResultInfo<bool> AddActivityClass(string activityClassName, DateTime createTime, DateTime updateTime, int creatorId, string remark)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.AddActivityClass(activityClassName, createTime, updateTime, creatorId, remark);
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
        /// 修改一条商品筛选分类记录
        /// </summary>
        /// <param name="activityClassName">商品筛选分类名称</param>
        /// <param name="createTime">创建时间</param>
        /// <param name="updateTime">修改时间</param>
        /// <param name="creatorId">创建者id</param>
        /// <param name="remark">备注</param>
        /// <param name="activityClassId">商品筛选分类编号</param>
        /// <returns></returns>
        public ResultInfo<bool> UpdateActivityClass(string activityClassName, DateTime createTime, DateTime updateTime, int creatorId, string remark, int activityClassId)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.UpdateActivityClass(activityClassName, createTime, updateTime, creatorId, remark, activityClassId);
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
        /// 删除一条商品筛选分类记录
        /// </summary>
        /// <param name="activityClassId">商品筛选分类编号</param>
        /// <returns></returns>
        public ResultInfo<bool> DeleteActivityClass(int activityClassId)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.DeleteActivityClass(activityClassId);
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
        /// 根据商品筛选分类名称判断是否存在该分类
        /// </summary>
        /// <param name="activityClassName">商品筛选分类名称</param>
        /// <returns></returns>
        public ResultInfo<bool> IsExistByActivityClassName(string activityClassName)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.IsExistByActivityClassName(activityClassName);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = false;
            }
            return result;
        }

        public ResultInfo<bool> IsExistByActivityClassId(int activityClassId)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.IsExistByActivityClassId(activityClassId);
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
