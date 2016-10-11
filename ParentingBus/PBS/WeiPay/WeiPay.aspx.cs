using System;
using System.Web.UI;
using System.Xml;

using Newtonsoft.Json;
using PBS.Model;
using PBS.Server;
using WeiPay;

namespace WeiPayWeb
{
    /**
     * 
     * 作用：微信支付核心页面，该页面获取用户的支付信息显示网页上。
     *          通过其它配置参数和支付参数调用微信支付Api获取相关其它数据。
     *          通过点击页面“确认支付”按钮来发起支付操作
     * 作者：zhr
     * 编写日期：2014-12-25
     * 备注：请注意相关支付数据、配置信息的正确
     * 
     * */
    public partial class WeiPay : System.Web.UI.Page
    {
        //页面输出 不用操作
        public static string Code = "";     //微信端传来的code
        public static string PrepayId = ""; //预支付ID
        public static string Sign = "";     //为了获取预支付ID的签名
        public static string PaySign = "";  //进行支付需要的签名
        public static string Package = "";  //进行支付需要的包
        public static string TimeStamp = ""; //时间戳 程序生成 无需填写
        public static string NonceStr = ""; //随机字符串  程序生成 无需填写

        //支付相关参数 ，以下参数请从需要支付的页面通过get方式传递过来
        protected string OrderSN = ""; //商户自己订单号
        protected string Body = ""; //商品描述
        protected string TotalFee = "";  //总支付金额，单位为：分，不能有小数
        protected string Attach = ""; //用户自定义参数，原样返回
        protected string UserOpenId = "";//微信用户openid
        protected string MyOrderSN = "";

        public string orderPrice = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            string orderId = "23";
            string voucherId = string.Empty;
            if (Session["OrderID"] != null)
            {
                orderId = Session["OrderID"].ToString();
            }

            if (Session["VoucherId"] != null)
            {
                voucherId = Session["VoucherId"].ToString();
            }

            this.BindData(orderId, voucherId);

            LogUtil.WriteLog("============ 单次支付开始 ===============");
            LogUtil.WriteLog(string.Format("传递支付参数：OrderSN={0}、Body={1}、TotalFee={2}、Attach={3}、UserOpenId={4}",
            this.OrderSN, this.Body, this.TotalFee, this.Attach, this.UserOpenId));

            #region 支付操作============================
            #region 基本参数===========================
            //时间戳 
            TimeStamp = TenpayUtil.getTimestamp();
            //随机字符串 
            NonceStr = TenpayUtil.getNoncestr();

            //创建支付应答对象
            var packageReqHandler = new RequestHandler(Context);
            //初始化
            packageReqHandler.init();

            //设置package订单参数  具体参数列表请参考官方pdf文档，请勿随意设置
            packageReqHandler.setParameter("body", this.Body); //商品信息 127字符
            packageReqHandler.setParameter("appid", PayConfig.AppId);
            packageReqHandler.setParameter("mch_id", PayConfig.MchId);
            packageReqHandler.setParameter("nonce_str", NonceStr.ToLower());
            packageReqHandler.setParameter("notify_url", PayConfig.NotifyUrl);
            packageReqHandler.setParameter("openid", this.UserOpenId);
            packageReqHandler.setParameter("out_trade_no", this.OrderSN); //商家订单号
            packageReqHandler.setParameter("spbill_create_ip", Page.Request.UserHostAddress); //用户的公网ip，不是商户服务器IP
            packageReqHandler.setParameter("total_fee", this.TotalFee); //商品金额,以分为单位(money * 100).ToString()
            packageReqHandler.setParameter("trade_type", "JSAPI");
            if (!string.IsNullOrEmpty(this.Attach))
                packageReqHandler.setParameter("attach", this.Attach);//自定义参数 127字符

            #endregion

            #region sign===============================
            Sign = packageReqHandler.CreateMd5Sign("key", PayConfig.AppKey);
            LogUtil.WriteLog("WeiPay 页面  sign：" + Sign);
            #endregion

            #region 获取package包======================
            packageReqHandler.setParameter("sign", Sign);

            string data = packageReqHandler.parseXML();
            LogUtil.WriteLog("WeiPay 页面  package（XML）：" + data);

            string prepayXml = HttpUtil.Send(data, "https://api.mch.weixin.qq.com/pay/unifiedorder");
            LogUtil.WriteLog("WeiPay 页面  package（Back_XML）：" + prepayXml);

            //获取预支付ID
            var xdoc = new XmlDocument();
            xdoc.LoadXml(prepayXml);
            XmlNode xn = xdoc.SelectSingleNode("xml");
            XmlNodeList xnl = xn.ChildNodes;
            if (xnl.Count > 7)
            {
                PrepayId = xnl[7].InnerText;
                Package = string.Format("prepay_id={0}", PrepayId);
            }
            #endregion

            #region 设置支付参数 输出页面  该部分参数请勿随意修改 ==============
            var paySignReqHandler = new RequestHandler(Context);
            paySignReqHandler.setParameter("appId", PayConfig.AppId);
            paySignReqHandler.setParameter("timeStamp", TimeStamp);
            paySignReqHandler.setParameter("nonceStr", NonceStr);
            paySignReqHandler.setParameter("package", Package);
            paySignReqHandler.setParameter("signType", "MD5");
            PaySign = paySignReqHandler.CreateMd5Sign("key", PayConfig.AppKey);

            LogUtil.WriteLog("WeiPay 页面  paySign：" + PaySign);

            LogUtil.WriteLog("商户订单号：" + MyOrderSN);
            #endregion
            #endregion
        }


        /// <summary>
        /// 获取传递的支付参数，并绑定页面上
        /// </summary>
        private void BindData(string orderId, string voucherId)
        {
            //pbs_basic_Users userDate = (pbs_basic_Users)Session["Users"];
            //int userid = userDate.UserId;
            //int userid = 5;
            int oId = Utility.Util.ParseHelper.ToInt(orderId);
            int vId = Utility.Util.ParseHelper.ToInt(voucherId);
            string voucherName = string.Empty;
            decimal voucherPrice = 0m;
            pbs_basic_GoodsView pbsBasicGoodsView = new pbs_basic_GoodsView();
            pbs_basic_Order order = new pbs_basic_Order();
            pbs_basic_Members members = new pbs_basic_Members();
            pbs_basic_Voucher voucher = new pbs_basic_Voucher();
            pbs_basic_MembersService pbsBasicMembersService = new pbs_basic_MembersService();
            pbs_basic_OrderService pbsBasicOrderService = new pbs_basic_OrderService();
            pbs_basic_GoodsService pbsBasicGoodsService = new pbs_basic_GoodsService();
            pbs_basic_VoucherService pbsBasicVoucherService = new pbs_basic_VoucherService();

            ResultInfo<pbs_basic_Order> result_order = pbsBasicOrderService.GetOrderModelById(oId);
            if (result_order.Result && result_order.Data != null)
            {
                order = result_order.Data;
                ResultInfo<pbs_basic_GoodsView> result_GoodsView = pbsBasicGoodsService.GetGoodsModelViewById(order.GoodsId);
                if (result_GoodsView.Result && result_GoodsView.Data != null)
                {
                    pbsBasicGoodsView = result_GoodsView.Data;
                }

                ResultInfo<pbs_basic_Members> result_Member = pbsBasicMembersService.GetMembersModelById(Utility.Util.ParseHelper.ToInt(order.OrderMemberId));
                if (result_Member.Result && result_Member.Data != null)
                {
                    members = result_Member.Data;
                }

                if (vId != 0)
                {
                    ResultInfo<pbs_basic_Voucher> result_Voucher = pbsBasicVoucherService.GetVoucherModelById(vId);
                    if (result_Voucher.Result && result_Voucher.Data != null)
                    {
                        voucherPrice = result_Voucher.Data.VoucherPrice;
                        voucherName = result_Voucher.Data.VoucherPrice.ToString();
                    }

                    //更新订单优惠券
                    ResultInfo<bool> result_UpdateOrderVoucher = pbsBasicOrderService.UpdateOrderVoucher(vId, oId);

                }

            }

            this.OrderSN = DateTime.Now.ToString("yyyyMMddHHmmss")+"_"+orderId;
            this.MyOrderSN = orderId;
            this.Body = pbsBasicGoodsView.GoodsName;
            this.TotalFee = (Convert.ToInt32((pbsBasicGoodsView.SellingPrice - voucherPrice)*100)).ToString();
            if (Session["UserOpenId"]!=null)
            {
                this.UserOpenId = Session["UserOpenId"].ToString();
            }

            GoodsName.Text=pbsBasicGoodsView.GoodsName;
            VisitTime.Text = Utility.Util.ParseHelper.ToDatetime(order.VisitTime).ToString("yyyy-MM-dd");
            GoodsTypeName.Text = pbsBasicGoodsView.GoodsTypeName;
            Count.Text = order.Count.ToString();
            MemberName.Text = members.MemberName;
            UserName.Text = order.UserName;
            Phone.Text = order.Phone;
            SellingPrice.Text = ((pbsBasicGoodsView.SellingPrice - voucherPrice)).ToString();
            VoucherName.Text = voucherName;

            this.orderPrice = pbsBasicGoodsView.SellingPrice.ToString();
        }

    }



}
