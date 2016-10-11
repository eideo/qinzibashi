using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace PBSAdmin.ashx
{
    /// <summary>
    /// UploadImg 的摘要说明
    /// </summary>
    public class UploadImg : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Write(UpLoad(context.Request.Files));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public string UpLoad(HttpFileCollection files)
        {
            dynamic result = new ExpandoObject();
            if (files.Count > 0)
            {
                string newDateTimeName = DateTime.Now.ToString("yyyyMMddhhmmss");
                string savePath = HttpContext.Current.Server.MapPath("~/upload/image/");
                string fileName = System.IO.Path.GetFileName(files[0].FileName);

                string fileNameFormat =
                    fileName.Substring(fileName.LastIndexOf(".", StringComparison.Ordinal) + 1).ToLower();
                string newfilename = newDateTimeName + "." + fileNameFormat;
                files[0].SaveAs(savePath + newfilename);

                string imgurl = "/upload/image/" + newfilename;
                result.Code = "0000";
                result.Msg = "上传图片成功";
                result.Url = imgurl;
            }
            else
            {
                result.Code = "0001";
                result.Msg = "上传图片失败";
                result.Url = string.Empty;
            }

            return JsonConvert.SerializeObject(result);
        }
    }
}