$(document).ready(function () {

    $("#ActivityClassName").on("input propertychange", function () {
        var name = $("#ActivityClassName").val();
        if (name == null || name === "") {
            $(this).next(".help-inline").remove();
            $(this).parents(".control-group").addClass("error");
            $(this).after("<span class='help-inline'>请输入活动筛选分类名称</span>");
        } else {
            $(this).parents('.control-group').removeClass("error");
            $(this).next(".help-inline").remove();
        }
    });

    $("#saveBtn").on("click", function (e) {
        var name = $("#ActivityClassName").val();
        if (name == null || name === "") {
            $("#ActivityClassName").next(".help-inline").remove();
            $("#ActivityClassName").parents(".control-group").addClass("error");
            $("#ActivityClassName").after("<span class='help-inline'>请输入活动筛选分类名称</span>");
            return false;
        } else {
            $("#ActivityClassName").parents(".control-group").removeClass("error");
            $("#ActivityClassName").next(".help-inline").remove();
        }

        if (activityClassId === "0") {
            //增加

            $.ajax({
                type: "POST",
                async: false,
                url: "/Activity/ActivityFilterClassAddAjax",
                data: { activityClassName: name, createTime: createTime, updateTime: updateTime, creatorId: creatorId, remark: remark },
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
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    //失败
                    $.scojs_message(errorThrown, $.scojs_message.TYPE_ERROR);
                }
            });
        } else {
            //修改
            $.ajax({
                type: "POST",
                async: false,
                url: "/Activity/ActivityFilterClassUpdateAjax",
                data: { activityClassName: name, createTime: createTime, updateTime: updateTime, creatorId: creatorId, remark: remark, activityClassId: activityClassId },
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
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    //失败
                    $.scojs_message(errorThrown, $.scojs_message.TYPE_ERROR);
                }
            });
        }

        return false;
    });
})