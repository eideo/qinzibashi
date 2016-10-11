$(document).ready(function () {

    $("#AgeRangeName").on("input propertychange", function () {
        var name = $("#AgeRangeName").val();
        if (name == null || name === "") {
            $(this).next(".help-inline").remove();
            $(this).parents(".control-group").addClass("error");
            $(this).after("<span class='help-inline'>请输入年龄范围名称</span>");
        } else {
            $(this).parents('.control-group').removeClass("error");
            $(this).next(".help-inline").remove();
        }
    });

    $("#saveBtn").on("click", function (e) {
        var name = $("#AgeRangeName").val();
        if (name == null || name === "") {
            $("#AgeRangeName").next(".help-inline").remove();
            $("#AgeRangeName").parents(".control-group").addClass("error");
            $("#AgeRangeName").after("<span class='help-inline'>请输入年龄范围名称</span>");
            return false;
        } else {
            $("#AgeRangeName").parents(".control-group").removeClass("error");
            $("#AgeRangeName").next(".help-inline").remove();
        }

        if (ageRangeId === "0") {
            //增加

            $.ajax({
                type: "POST",
                async: false,
                url: "/Activity/AgeRangeAddAjax",
                data: { ageRangeName: name, createTime: createTime, updateTime: updateTime, creatorId: creatorId, remark: remark },
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
                url: "/Activity/AgeRangeUpdate",
                data: { ageRangeName: name, createTime: createTime, updateTime: updateTime, creatorId: creatorId, remark: remark, ageRangeId: ageRangeId },
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