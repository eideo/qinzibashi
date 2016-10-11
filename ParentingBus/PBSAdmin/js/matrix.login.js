var ready = $(document).ready(function () {

    //var recover = $('#recoverform');
    //var speed = 400;
    var reg1 = /^[a-zA-Z0-9_\u4e00-\u9fa5]{3,16}$/;
    var reg2 = /^[a-z0-9_-]{6,18}$/;
    var reg3 = /^[A-Z0-9]{5}$/;

    $("#loginform").addClass("on");

    $('body').on("keydown", function (event) {
        var key = event.which;
        if (key === 13) {
            event.preventDefault();
            if ($("#loginform").hasClass("on")) {
                $('#btn-login').click();
            }

            if ($("#recoverform").hasClass("on")) {
                $('#btn-info').click();
            }
        }
    });

    $('#to-recover').click(function () {

        $("#loginform").slideUp();
        $("#recoverform").fadeIn();
        $("#loginform").removeClass("on");
        $("#recoverform").addClass("on");
    });
    $('#to-login').click(function () {

        $("#recoverform").hide();
        $("#loginform").fadeIn();
        $("#loginform").addClass("on");
        $("#recoverform").removeClass("on");
    });

    $("#loginName").blur(function () {
        if ($(this).val() === "") {
            tip_OpenDialog("#loginName", "请输入用户名");
        }
        else {
            if (!reg1.test($(this).val())) {
                tip_OpenDialog("#loginName", "帐号格式不正确");
            }
        }
    });
    $("#loginPassword").blur(function() {
        if ($(this).val() === "") {
            tip_OpenDialog("#loginPassword", "请输入密码");
        } else {
            if (!reg2.test($(this).val())) {
                tip_OpenDialog("#loginPassword", "密码格式不正确");
            }
        }
    });
    $("#Captcha").blur(function () {
        if ($(this).val() === "") {
            tip_OpenDialog("#Captcha", "请输入验证码");
        } else {
            if (!reg3.test($(this).val())) {
                tip_OpenDialog("#Captcha", "验证码格式不正确");
            }
        }
    });

    $("#btn-login").on("click", function() {
        var loginId = $.trim($("#loginName").val()), pass = $.trim($("#loginPassword").val()), captcha = $.trim($("#Captcha").val());
        if (loginId === "") {
            tip_OpenDialog("#loginName", "请输入用户名");
            return false;
        }
        if (!reg1.test(loginId)) {
            tip_OpenDialog("#loginName", "帐号格式不正确");
            return false;
        }
        if (pass === "") {
            tip_OpenDialog("#loginPassword", "请输入密码");
            return false;
        }
        if (!reg2.test(pass)) {
            tip_OpenDialog("#loginPassword", "密码格式不正确");
            return false;
        }
        if (captcha  === "") {
            tip_OpenDialog("#Captcha", "请输入验证码");
            return false;
        }
        if (!reg3.test(captcha)) {
            tip_OpenDialog("#Captcha", "验证码格式不正确");
            return false;
        }
        $.ajax({
            type: "POST",
            url: "/ashx/CheckLogin.ashx?LoginId=" + loginId + "&PassWord=" + pass + "&Captcha=" + captcha,
            dataType: 'text',
            async: false,
            success: function(e) {
                var jsonData = $.parseJSON(e);
                if (jsonData.Code === "0000") {
                    window.location.href = "/Home/Index";
                }
                else if (jsonData.Code === "0000") {
                    tip_OpenDialog("#Captcha", "验证码错误");
                    return false;
                } else {
                    tip_OpenDialog("#loginName", "用户名或密码错误");
                    return false;
                }
                return false;
            }
        });
        return false;
    });

    $("#btn-findPwd").on("click", function () {
        alert("找回密码");
    });

    $("#captchaImg").on("click", function() {
        this.src = "/ashx/VerifyCode.ashx?time=" + (new Date()).getTime();
    });
});