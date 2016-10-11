<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WeiPay.aspx.cs" Inherits="WeiPayWeb.WeiPay" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>确认订单</title>
    <meta name="author" content="Eilvein:eilvein.com">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <meta name="viewport" content="width=device-width,initial-scale=1.0,maximum-scale=1.0,user-scalable=no,minimal-ui">
    <meta name="format-detection" content="telephone=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black" />
    <link href="../../css/app.css" rel="stylesheet" />
    <style type="text/css">
        .thisRight {
            float: right; border: 0; text-align: right;
        }
        .m_right {
            line-height: 1.5em !important;
}
    </style>
</head>
<body>
    <header class="ui-header ui-header-positive ui-border-b" id="header" style="color: #fff">
    <i class="ui-icon-return" onclick="goBack()" style="color:#fff"></i>
    <h1>确认订单</h1>
    <a id="submitBtn" onclick="submitAll()" href="javascript:void(0)" style="position: absolute;right: 1em;top: 0; color:#fff">完成</a>
    </header>

    <div class="user-order">
    <form id="registerForm" action="#" runat="server">
        <div class="order-item">
            <div class="order-title">
                <h2 class="ui-nowrap">
                    <asp:Label runat="server" ID="GoodsName"/>
                </h2>
            </div>
            <div class="order-tips">
                <em>活动时间：<asp:Label runat="server" ID="VisitTime"></asp:Label></em>
            </div>
        </div>
        <div class="order-item clearfix">
            <div class="quantity-box">
                <table>
                    <tr>
                        <td style="padding-right:1em">套餐：<asp:Label runat="server" ID="GoodsTypeName"></asp:Label></td>
                        <td style="padding-right:1em">数量：<asp:Label runat="server" ID="Count"/></td>
                        <td style="padding-right:1em">出行人:<asp:Label runat="server" ID="MemberName"/></td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="order-item" style="border: 0">
            <h4 class="ui-nowrap">联系人信息</h4>
        </div>
        <div class="order-item clearfix">
            <label>姓名</label>
            <div class="quantity-box order-item-right">
                <asp:TextBox runat="server" ID="UserName" placeholder="姓名" CssClass="NickName thisRight"/>
            </div>
        </div>
        <div class="order-item clearfix">
            <label>手机号</label>
            <div class="quantity-box order-item-right">
                <asp:TextBox runat="server" ID="Phone" placeholder="手机号" CssClass="Phone thisRight"></asp:TextBox>
            </div>
        </div>
        <div class="order-item" style="border: 0">
            <h4 class="ui-nowrap">优惠券</h4>
        </div>
        <div class="order-item clearfix">
            <label>已选择</label>
                <div class="quantity-box order-item-right">
                    <a href="/Activity/ChoseVoucher?orderPrice=<%= orderPrice %>">
                        <asp:Label runat="server" ID="VoucherName"/>
                        <img alt="" src="../../image/next_icon.png" style="width: 1.1em;height: 1.1em" /></a>
                </div>
           <%-- @if (voucherId == "0")
            {
                <label>已选择</label>
                <div class="quantity-box order-item-right">
                    <a href="/User/ChoseVoucher?voucherId=@voucherId"><img alt="" src="~/image/next_icon.png" style="width: 1.1em;height: 1.1em" /></a>
                </div>
            }
            else
            {
                <label>已选择</label>
                <div class="quantity-box order-item-right">
                    <a href="/Activity/ChoseVoucher?voucherId=@voucherId">减：@voucherName 元</a>
                </div>
            }--%>
        </div>
        <div class="order-item" style="border: 0">
            <h4 class="ui-nowrap">支付方式</h4>
        </div>
        <div class="order-item" style="border: 0;height:3em;line-height:3em">
            <div style="float:left"><img alt="" src="../../image/wx_icon.png" style="width:3em;height:3em" /></div>
            <div style="float:right">
                <img alt="" src="../../image/r_icon.png" />
            </div>
        </div>
    </form>
</div>
<div class="mod-box footer_bottom">
    <div class="mod-bd">
        <ul class="ui-one" style="padding: 0">
            <li>
                <div class="list_content content_Padding" style="height: 1.5em">
                    <div class="m_left">
                        <div class="m_left_content">
                            <span>合计:</span>
                            <span class="sellPrice">
                                <asp:Label runat="server" ID="SellingPrice"></asp:Label>
                            </span>
                            <span>元</span>
                        </div>
                    </div>
                    <div class="m_right">
                        <a href="javascript:void(0)" class="buy_btn" onclick="SavePay()">
                            去支付
                        </a>
                    </div>
                </div>
            </li>
        </ul>
    </div>
</div>
    <script type="text/javascript" src="../../js/jquery.1.7.2.min.js"></script>
    <script type="text/javascript">

        function SavePay() {
            WeixinJSBridge.invoke('getBrandWCPayRequest', {
                "appId": "<%= WeiPay.PayConfig.AppId %>", //公众号名称，由商户传入
               "timeStamp": "<%= TimeStamp %>", //时间戳
               "nonceStr": "<%= NonceStr %>", //随机串
               "package": "<%= Package %>", //扩展包
               "signType": "MD5", //微信签名方式:1.sha1
               "paySign": "<%= PaySign %>" //微信签名
           },
        function (res) {
            if (res.err_msg == "get_brand_wcpay_request:ok") {
                var billNo = '<%= OrderSN %>';
                var myOrderId='<%= MyOrderSN %>';
                $.ajax({
                    type: "POST",
                    url: "http://www.qinzibashi.com/Activity/BuyAjax",
                    data: { "billNo": billNo },
                    success: function (data) {
                        window.location.href = "http://www.qinzibashi.com/Activity/PaySuccess?billNo=" + myOrderId;
                    },
                    error: function (e) {
                        window.location.href = "http://www.qinzibashi.com/Activity/PayError";
                    }
                });

            } else if (res.err_msg == "get_brand_wcpay_request:cancel") {
                alert("用户取消支付!");
                window.location.href = "http://www.qinzibashi.com";
            } else {
                //alert(res.err_msg);
                alert("支付失败!");
            }
            // 使用以上方式判断前端返回,微信团队郑重提示：res.err_msg将在用户支付成功后返回ok，但并不保证它绝对可靠。
            //因此微信团队建议，当收到ok返回时，向商户后台询问是否收到交易成功的通知，若收到通知，前端展示交易成功的界面；若此时未收到通知，商户后台主动调用查询订单接口，查询订单的当前状态，并反馈给前端展示相应的界面。
        });
    }
        function goBack() {
            history.back();
        }
</script>
</body>
</html>
