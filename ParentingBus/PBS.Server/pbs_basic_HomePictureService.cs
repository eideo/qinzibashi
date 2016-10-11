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
    public class pbs_basic_HomePictureService
    {
        pbs_basic_HomePictureDao dao = new pbs_basic_HomePictureDao();

        public ResultInfo<bool> AddHomePicture(string url, int orderBy, DateTime createTime, DateTime updateTime, int creatorId, string remark, string linkUrl)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.AddHomePicture(url, orderBy, createTime, updateTime, creatorId, remark, linkUrl);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = false;
            }
            return result;
        }

        public ResultInfo<bool> UpdateHomePicture(string url, int orderBy, DateTime createTime, DateTime updateTime, int creatorId, string remark, string linkUrl, int HomePictureId)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.UpdateHomePicture(url, orderBy, createTime, updateTime, creatorId, remark, linkUrl, HomePictureId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = false;
            }
            return result;
        }

        public ResultInfo<bool> DeleteHomePicture(int homePictureId)
        {
            ResultInfo<bool> result = new ResultInfo<bool>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.DeleteHomePicture(homePictureId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = false;
            }
            return result;
        }

        public ResultInfo<pbs_basic_HomePicture> GetHomePictureModelById(int homePictureId)
        {
            ResultInfo<pbs_basic_HomePicture> result = new ResultInfo<pbs_basic_HomePicture>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetHomePictureModelById(homePictureId);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.LogWriterFromFilter(ex);
                result.Result = false;
                result.Data = null;
            }
            return result;
        }

        public ResultInfo<List<pbs_basic_HomePicture>> GetHomePictureList()
        {
            ResultInfo<List<pbs_basic_HomePicture>> result = new ResultInfo<List<pbs_basic_HomePicture>>();
            result.Result = false;
            try
            {
                result.Result = true;
                result.Data = dao.GetHomePictureList();
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
