$(document).ready(function () {

    $("#GoodsTypeName").on("input propertychange", function () {
        var name = $("#GoodsTypeName").val();
        if (name == null || name === "") {
            $(this).next(".help-inline").remove();
            $(this).parents(".control-group").addClass("error");
            $(this).after("<span class='help-inline'>请输入类型名称</span>");
        } else {
            $(this).parents('.control-group').removeClass("error");
            $(this).next(".help-inline").remove();
        }
    });

    $("#GoodsTypeDesc").on("input propertychange", function () {
        var name = $("#GoodsTypeDesc").val();
        if (name == null || name === "") {
            $(this).next(".help-inline").remove();
            $(this).parents(".control-group").addClass("error");
            $(this).after("<span class='help-inline'>请输入类型描述</span>");
        } else {
            $(this).parents('.control-group').removeClass("error");
            $(this).next(".help-inline").remove();
        }
    });

    $("#GoodsTypePrice").on("input propertychange", function () {
        var name = $("#GoodsTypePrice").val();
        if (name == null || name === "") {
            $(this).next(".help-inline").remove();
            $(this).parents(".control-group").addClass("error");
            $(this).after("<span class='help-inline'>请输入类型价格</span>");
        } else {
            $(this).parents('.control-group').removeClass("error");
            $(this).next(".help-inline").remove();
        }
    });

    $("#saveBtn").on("click", function (e) {
        var goodsTypeName = $("#GoodsTypeName").val();
        if (goodsTypeName == null || goodsTypeName === "") {
            $("#GoodsTypeName").next(".help-inline").remove();
            $("#GoodsTypeName").parents(".control-group").addClass("error");
            $("#GoodsTypeName").after("<span class='help-inline'>请输入分类名称</span>");
            return false;
        } else {
            $("#GoodsTypeName").parents(".control-group").removeClass("error");
            $("#GoodsTypeName").next(".help-inline").remove();
        }

        var goodsTypeDesc = $("#GoodsTypeDesc").val();
        if (goodsTypeDesc == null || goodsTypeDesc === "") {
            $(this).next(".help-inline").remove();
            $(this).parents(".control-group").addClass("error");
            $(this).after("<span class='help-inline'>请输入类型描述</span>");
        } else {
            $(this).parents('.control-group').removeClass("error");
            $(this).next(".help-inline").remove();
        }

        var goodsTypePrice = $("#GoodsTypePrice").val();
        if (goodsTypePrice == null || goodsTypePrice === "") {
            $(this).next(".help-inline").remove();
            $(this).parents(".control-group").addClass("error");
            $(this).after("<span class='help-inline'>请输入类型价格</span>");
        } else {
            $(this).parents('.control-group').removeClass("error");
            $(this).next(".help-inline").remove();
        }


        if (goodsTypeId === "0") {
            //增加

            $.ajax({
                type: "POST",
                async: false,
                url: "/Activity/GoodsTypeAdd",
                data: { activitysTypeName: goodsTypeName, createTime: createTime, updateTime: updateTime, creatorId: creatorId, remark: remark, activitysTypeDesc: goodsTypeDesc, activitysTypePrice: goodsTypePrice },
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
                url: "/Activity/GoodsTypeUpdate",
                data: { activitysTypeName: goodsTypeName, createTime: createTime, updateTime: updateTime, creatorId: creatorId, remark: remark, activitysTypeDesc: goodsTypeDesc, activitysTypePrice: goodsTypePrice, activitysTypeId: goodsTypeId },
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