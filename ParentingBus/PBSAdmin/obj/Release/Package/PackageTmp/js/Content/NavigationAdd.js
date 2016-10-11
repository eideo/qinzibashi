function validateNavigationName() {
    var thisVal = $("#NavigationName").val();
    if (thisVal == null || thisVal === "") {
        $("#NavigationName").next(".help-inline").remove();
        $("#NavigationName").parents(".control-group").addClass("error");
        $("#NavigationName").after("<span class='help-inline'>请输入导航栏标题</span>");
    } else {
        $("#NavigationName").parents('.control-group').removeClass("error");
        $("#NavigationName").next(".help-inline").remove();
    }
}

function validateNavigationUrl() {
    var thisVal = $("#NavigationUrl").val();
    if (thisVal == null || thisVal === "") {
        $("#NavigationUrl").next(".help-inline").remove();
        $("#NavigationUrl").parents(".control-group").addClass("error");
        $("#NavigationUrl").after("<span class='help-inline'>请输入跳转链接</span>");
    } else {
        $("#NavigationUrl").parents('.control-group').removeClass("error");
        $("#NavigationUrl").next(".help-inline").remove();
    }
}

$(document).ready(function () {

    $("#NavigationName").on("input propertychange", function () {
        validateNavigationName();
    });

    $("#NavigationUrl").on("input propertychange", function () {
        validateNavigationUrl();
    });

    $("#saveBtn").on("click", function (e) {
        navigationName = $("#NavigationName").val();
        navigationUrl = $("#NavigationUrl").val();

        validateNavigationName();
        validateNavigationUrl();


        //string ReviewTitle, string ReviewContent, string ReviewUrl

        if (navigationId === "0") {
            //增加
            $.ajax({
                type: "POST",
                async: false,
                url: "/Content/NavigationAddAjax",
                data: {
                    navigationName: navigationName,
                    navigationUrl: navigationUrl,
                    createTime: createTime,
                    updateTime: updateTime,
                    creatorId: creatorId,
                    remark: remark
                },
                success: function (data) {
                    if (data.Status === 0) {
                        //成功
                        e.preventDefault();
                        $.scojs_message(data.Message, $.scojs_message.TYPE_OK);
                    } else {
                        //失败
                        $.scojs_message(data.Message, $.scojs_message.TYPE_ERROR);
                        return false;
                    }
                    return false;
                },
                error: function (xmlHttpRequest, textStatus, errorThrown) {
                    //失败
                    $.scojs_message(errorThrown, $.scojs_message.TYPE_ERROR);
                }
            });



        } else {
            //修改
            $.ajax({
                type: "POST",
                async: false,
                url: "/Content/NavigationUpdateAjax",
                data: {
                    navigationName: navigationName,
                    navigationUrl: navigationUrl,
                    createTime: createTime,
                    updateTime: updateTime,
                    creatorId: creatorId,
                    remark: remark,
                    navigationId: navigationId
                },
                success: function (data) {
                    if (data.Status === 0) {
                        //成功
                        e.preventDefault();
                        $.scojs_message(data.Message, $.scojs_message.TYPE_OK);
                    } else {
                        //失败
                        $.scojs_message(data.Message, $.scojs_message.TYPE_ERROR);
                        return false;
                    }
                    return false;
                },
                error: function (xmlHttpRequest, textStatus, errorThrown) {
                    //失败
                    $.scojs_message(errorThrown, $.scojs_message.TYPE_ERROR);
                }
            });
        }

        return false;
    });

    $("#uploadBtn").click(function () {
        $("#uploadPreview").next(".MarkDiv").remove();
        var upImg = $("#uploadImage").val();
        if (upImg == null || upImg === "") {
            $("#uploadBtn").next(".help-inline").remove();
            $("#uploadBtn").parents(".control-group").addClass("error");
            $("#uploadBtn").after("<span class='help-inline'>请选择图片文件</span>");
            return false;
        } else {
            $("#uploadBtn").parents(".control-group").removeClass("error");
            $("#uploadBtn").next(".help-inline").remove();
        }
        ajaxFileUpload();
        return false;
    });
});

function ajaxFileUpload() {
    $.ajaxFileUpload
    (
        {
            url: '/ashx/UploadImg.ashx', //用于文件上传的服务器端请求地址
            secureuri: false, //一般设置为false
            fileElementId: 'uploadImage', //文件上传空间的id属性  <input type="file" id="file" name="file" />
            dataType: 'json', //返回值类型 一般设置为json
            success: function (data) //服务器成功响应处理函数
            {
                if (data != null && data.Code === "0000") {
                    $("#uploadPreview").attr("src", data.Url);
                    $("#hidUploadImgUrl").val(data.Url);
                    //$("#uploadPreview").after("<div class='MarkDiv'><i></i></div>");
                    $("#uploadBtn").next(".help-inline").remove();
                    $("#uploadBtn").parents(".control-group").addClass("success");
                    $("#uploadBtn").after("<span class='help-inline'>上传图片成功</span>");

                } else {
                    $("#uploadBtn").next(".help-inline").remove();
                    $("#uploadBtn").parents(".control-group").addClass("error");
                    $("#uploadBtn").after("<span class='help-inline'>上传图片失败</span>");
                }

            },
            error: function () //服务器响应失败处理函数
            {
                $("#uploadBtn").next(".help-inline").remove();
                $("#uploadBtn").parents(".control-group").addClass("error");
                $("#uploadBtn").after("<span class='help-inline'>上传图片失败</span>");
            }
        }
    );
    return false;
}
