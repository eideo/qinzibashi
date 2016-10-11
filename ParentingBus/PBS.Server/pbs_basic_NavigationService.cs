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
    public class pbs_basic_NavigationService
    {
        pbs_basic_NavigationDao dao = new pbs_basic_NavigationDao();

        public ResultInfo<bool> AddNavigation(string navigationName, string navigationUrl, DateTime createTime, DateTime updateTime, int creatorId, string remark)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.AddNavigation(navigationName, navigationUrl, createTime, updateTime, creatorId, remark);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = false;
            }
            return result;
        }

        public ResultInfo<bool> UpdateNavigation(string navigationName, string navigationUrl, DateTime createTime, DateTime updateTime, int creatorId, string remark, int navigationId)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.UpdateNavigation(navigationName, navigationUrl, createTime, updateTime, creatorId, remark, navigationId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = false;
            }
            return result;
        }

        public ResultInfo<bool> DeleteNavigation(int navigationId)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.DeleteNavigation(navigationId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = false;
            }
            return result;
        }

        public ResultInfo<pbs_basic_Navigation> GetNavigationModelById(int navigationId)
        {
            ResultInfo<pbs_basic_Navigation> result = new ResultInfo<pbs_basic_Navigation>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetNavigationModelById(navigationId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = null;
            }
            return result;
        }

        public ResultInfo<List<pbs_basic_Navigation>> GetNavigationList()
        {
            ResultInfo<List<pbs_basic_Navigation>> result = new ResultInfo<List<pbs_basic_Navigation>>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetNavigationList();
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
