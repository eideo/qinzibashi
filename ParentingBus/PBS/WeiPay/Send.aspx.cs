using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using WeiPay;
using Newtonsoft.Json;

namespace WeiPayWeb
{
    public partial class Send : System.Web.UI.Page
    {
        private string UserOpenId = ""; //微信用户openid；
        private string MyReturnUrl = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Request["myReturnUrl"]!=null)
                {
                    MyReturnUrl = Request["myReturnUrl"];
                }
                
                //获取当前用户的OpenId，如果可以通过系统获取用户Openid就不用调用该函数
               this.GetUserOpenId();
            }

        }


        /// <summary>
        /// 获取当前用户的微信 OpenId，如果知道用户的OpenId请不要使用该函数
        /// </summary>
        private void GetUserOpenId()
        {

            string code = Request.QueryString["code"];
            if (string.IsNullOrEmpty(code))
            {
                string code_url = string.Format("https://open.weixin.qq.com/connect/oauth2/authorize?appid={0}&redirect_uri={1}&response_type=code&scope=snsapi_userinfo&state=lk#wechat_redirect", PayConfig.AppId, PayConfig.SendUrl + "?myReturnUrl=" + MyReturnUrl);
                Response.Redirect(code_url);
            }
            else
            {
                #region 获取支付用户 OpenID================
                string url = string.Format("https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type=authorization_code", PayConfig.AppId, PayConfig.AppSecret, code);
                string returnStr = HttpUtil.Send("", url);
                var obj = JsonConvert.DeserializeObject<OpenModel>(returnStr);
                url = string.Format("https://api.weixin.qq.com/sns/oauth2/refresh_token?appid={0}&grant_type=refresh_token&refresh_token={1}", PayConfig.AppId, obj.refresh_token);
                returnStr = HttpUtil.Send("", url);
                obj = JsonConvert.DeserializeObject<OpenModel>(returnStr);
                url = string.Format("https://api.weixin.qq.com/sns/userinfo?access_token={0}&openid={1}", obj.access_token, obj.openid);
                returnStr = HttpUtil.Send("", url);
                LogUtil.WriteLog("Send 页面  returnStr：" + returnStr);

               this.UserOpenId = obj.openid;
               Session["UserOpenId"] = this.UserOpenId;
                #endregion
                Response.Redirect("http://"+MyReturnUrl,false);
            }
        }
    }
}
