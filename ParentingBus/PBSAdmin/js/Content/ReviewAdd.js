oFReader = new FileReader(), rFilter = /^(?:image\/bmp|image\/cis\-cod|image\/gif|image\/ief|image\/jpeg|image\/jpeg|image\/jpeg|image\/pipeg|image\/png|image\/svg\+xml|image\/tiff|image\/x\-cmu\-raster|image\/x\-cmx|image\/x\-icon|image\/x\-portable\-anymap|image\/x\-portable\-bitmap|image\/x\-portable\-graymap|image\/x\-portable\-pixmap|image\/x\-rgb|image\/x\-xbitmap|image\/x\-xpixmap|image\/x\-xwindowdump)$/i;

oFReader.onload = function (oFrEvent) {
    document.getElementById("uploadPreview").src = oFrEvent.target.result;
};

function loadImageFile() {
    $("#uploadPreview").next(".MarkDiv").remove();
    if (document.getElementById("uploadImage").files.length === 0) {
        $("#uploadBtn").next(".help-inline").remove();
        $("#uploadBtn").parents(".control-group").addClass("error");
        $("#uploadBtn").after("<span class='help-inline'>请选择图片文件</span>");
        return false;
    } else {
        $("#uploadBtn").parents(".control-group").removeClass("error");
        $("#uploadBtn").next(".help-inline").remove();
    }
    var oFile = document.getElementById("uploadImage").files[0];
    if (!rFilter.test(oFile.type)) {
        $("#uploadBtn").next(".help-inline").remove();
        $("#uploadBtn").parents(".control-group").addClass("error");
        $("#uploadBtn").after("<span class='help-inline'>只能选择图片文件</span>");
        return false;
    }
    else if (oFile.size > 1024 * 1024) {
        $("#uploadBtn").next(".help-inline").remove();
        $("#uploadBtn").parents(".control-group").addClass("error");
        $("#uploadBtn").after("<span class='help-inline'>图片大小最多上传1M</span>");
        return false;
    } else {
        $("#uploadBtn").parents(".control-group").removeClass("error");
        $("#uploadBtn").next(".help-inline").remove();
    }
    oFReader.readAsDataURL(oFile);
    return false;
}

function validateReviewTitle() {
    var thisVal = $("#ReviewTitle").val();
    if (thisVal == null || thisVal === "") {
        $("#ReviewTitle").next(".help-inline").remove();
        $("#ReviewTitle").parents(".control-group").addClass("error");
        $("#ReviewTitle").after("<span class='help-inline'>往期回归标题</span>");
    } else {
        $("#ReviewTitle").parents('.control-group').removeClass("error");
        $("#ReviewTitle").next(".help-inline").remove();
    }
}

$(document).ready(function () {

    if (reviewUrl === "") {
        $("#uploadPreview").attr("src", "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAL4AAACMCAYAAADCxhM7AAAEDElEQVR4Xu3YwU4qAQBDUV35Y3623+Te1XvRZBIkA9Toqj0umcLQ2+sw8Pz+/v7vyR8CYwSeiT+2uLpfBIhPhEkCxJ+cXWnic2CSAPEnZ1ea+ByYJED8ydmVJj4HJgkQf3J2pYnPgUkCxJ+cXWnic2CSAPEnZ1ea+ByYJED8ydmVJj4HJgkQf3J2pYnPgUkCxJ+cXWnic2CSAPEnZ1ea+ByYJED8ydmVJj4HJgkQf3J2pYnPgUkCxJ+cXWnic2CSAPEnZ1ea+ByYJED8ydmVJj4HJgkQf3J2pYnPgUkCxJ+cXWnic2CSAPEnZ1ea+ByYJED8ydmVJj4HJgkQf3J2pYnPgUkCxJ+cXWnic2CSAPEnZ1ea+ByYJED8ydmVJj4HJgkQf3J2pYnPgUkCxJ+cXWnic2CSAPEnZ1ea+ByYJED8ydmVJj4HJgkQf3J2pYnPgUkCxJ+cXWnic2CSAPEnZ1ea+ByYJED8ydmVJj4HJgkQf3J2pYkfOPD29vaVen19/ZY+Hj8evDx+79ijU9463/G8s+O/Od+j99N4nPgPVr0U6kzs47FLGa/FfCTy5Vu4db5r6S//EX9zvkapk07EDyjdu8L+tfifb+feJ8zLy8vTx8fHt08g4gcjXkWIHzD7S/GP17oU+Po2ivjBKL+MED8AmN7jHwI/ugJ/Hj+7cif38J+fMMnrn30nCarORIgfTJ3co//0Hv/ea/71P1pQcS5C/GDyRyJeX4WTK/JPr/hnX4DPvl/c+44QVJ2JEP8Hv+rcuhc/XiL5OfPRPX7ys+TZLz/J82asDooSP4Ak0keA+H2bahQQIH4ASaSPAPH7NtUoIED8AJJIHwHi922qUUCA+AEkkT4CxO/bVKOAAPEDSCJ9BIjft6lGAQHiB5BE+ggQv29TjQICxA8gifQRIH7fphoFBIgfQBLpI0D8vk01CggQP4Ak0keA+H2bahQQIH4ASaSPAPH7NtUoIED8AJJIHwHi922qUUCA+AEkkT4CxO/bVKOAAPEDSCJ9BIjft6lGAQHiB5BE+ggQv29TjQICxA8gifQRIH7fphoFBIgfQBLpI0D8vk01CggQP4Ak0keA+H2bahQQIH4ASaSPAPH7NtUoIED8AJJIHwHi922qUUCA+AEkkT4CxO/bVKOAAPEDSCJ9BIjft6lGAQHiB5BE+ggQv29TjQICxA8gifQRIH7fphoFBIgfQBLpI0D8vk01CggQP4Ak0keA+H2bahQQIH4ASaSPAPH7NtUoIED8AJJIHwHi922qUUCA+AEkkT4CxO/bVKOAAPEDSCJ9BIjft6lGAQHiB5BE+ggQv29TjQICxA8gifQRIH7fphoFBIgfQBLpI0D8vk01CggQP4Ak0keA+H2bahQQ+A+/RfaXeLqcpQAAAABJRU5ErkJggg==");
    } else {
        $("#uploadPreview").attr("src", reviewUrl);
    }

    var sourceContent = $("#SourceContent").val();
    if (sourceContent !== "") {
        $("#editor").html(sourceContent);
        $("#SourceContent1").val(sourceContent);
    }

    $("#editor").keyup(function () {
        var soureContentVal = $(this).html();
        $("#SourceContent1").val(soureContentVal);
    });

    $("#ReviewTitle").on("input propertychange", function () {
        validateReviewTitle();
    });

    $("#saveBtn").on("click", function (e) {
        reviewTitle = $("#ReviewTitle").val();
        reviewContent = $("#SourceContent1").val();
        reviewContent = encodeURIComponent(reviewContent);
        reviewUrl = $("#hidUploadImgUrl").val();

        validateReviewTitle();

        var imgUrl = $("#hidUploadImgUrl").val();
        if (imgUrl == null || imgUrl === "") {
            $("#uploadBtn").next(".help-inline").remove();
            $("#uploadBtn").parents(".control-group").addClass("error");
            $("#uploadBtn").after("<span class='help-inline'>请选择图片文件</span>");
            return false;
        } else {
            $("#uploadBtn").parents(".control-group").removeClass("error");
            $("#uploadBtn").next(".help-inline").remove();
        }

        if (reviewId === "0") {
            //增加
            $.ajax({
                type: "POST",
                async: false,
                url: "/Content/ReviewAddAjax",
                data: {
                    reviewTitle: reviewTitle,
                    reviewContent: reviewContent,
                    reviewUrl: reviewUrl,
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
                url: "/Content/ReviewUpdateAjax",
                data: {
                    reviewTitle: reviewTitle,
                    reviewContent: reviewContent,
                    reviewUrl: reviewUrl,
                    createTime: createTime,
                    updateTime: updateTime,
                    creatorId: creatorId,
                    remark: remark,
                    reviewId: reviewId
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
