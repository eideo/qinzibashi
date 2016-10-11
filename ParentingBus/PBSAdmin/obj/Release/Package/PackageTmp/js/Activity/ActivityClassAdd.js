$(document).ready(function () {

    $("#GoodsClassName").on("input propertychange", function () {
        var name = $("#GoodsClassName").val();
        if (name == null || name === "") {
            $(this).next(".help-inline").remove();
            $(this).parents(".control-group").addClass("error");
            $(this).after("<span class='help-inline'>请输入分类名称</span>");
        } else {
            $(this).parents('.control-group').removeClass("error");
            $(this).next(".help-inline").remove();
        }
    });

    $("#saveBtn").on("click", function (e) {
        var name = $("#GoodsClassName").val();
        if (name == null || name === "") {
            $("#GoodsClassName").next(".help-inline").remove();
            $("#GoodsClassName").parents(".control-group").addClass("error");
            $("#GoodsClassName").after("<span class='help-inline'>请输入分类名称</span>");
            return false;
        } else {
            $("#GoodsClassName").parents(".control-group").removeClass("error");
            $("#GoodsClassName").next(".help-inline").remove();
        }

        if (goodsClassId === "0") {
            //增加

            $.ajax({
                type: "POST",
                async: false,
                url: "/Activity/GoodsClassAdd",
                data: { activitysClassName: name, createTime: createTime, updateTime: updateTime, creatorId: creatorId, remark: remark },
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
                url: "/Activity/GoodsClassUpdate",
                data: { activitysClassName: name, createTime: createTime, updateTime: updateTime, creatorId: creatorId, remark: remark, activitysClassId: goodsClassId },
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