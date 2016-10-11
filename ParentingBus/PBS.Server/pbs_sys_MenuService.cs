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
    public class pbs_sys_MenuService
    {
        private pbs_sys_MenuDao dao = new pbs_sys_MenuDao();
        /// <summary>
        /// 根据角色编号获取菜单列表
        /// </summary>
        /// <param name="roleId">角色编号</param>
        /// <returns></returns>
        public ResultInfo<DataTable> GetTreeMenu(string roleId)
        {
            ResultInfo<DataTable> result = new ResultInfo<DataTable>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetTreeMenu(roleId);
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
        /// 获取所有菜单
        /// </summary>
        /// <returns></returns>
        public ResultInfo<DataTable> GetAllTreeMenu()
        {
            ResultInfo<DataTable> result = new ResultInfo<DataTable>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetAllTreeMenu();
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
        /// 根据角色编号和父节点编号获取当前菜单列表
        /// </summary>
        /// <param name="parentId">父节点编号</param>
        /// <param name="roleId">角色编号</param>
        /// <returns></returns>
        public ResultInfo<DataTable> GetThisTreeNodeMenu(string parentId, string roleId)
        {
            ResultInfo<DataTable> result = new ResultInfo<DataTable>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetThisTreeNodeMenu(parentId,roleId);
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
        /// 根据父节点编号获取子节点
        /// </summary>
        /// <param name="parentId">父节点编号</param>
        /// <returns></returns>
        public ResultInfo<DataTable> GetChildNodes(string parentId)
        {
            ResultInfo<DataTable> result = new ResultInfo<DataTable>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetChildNodes(parentId);
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
