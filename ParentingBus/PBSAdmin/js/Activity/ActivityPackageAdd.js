$(document).ready(function () {
    $("#GoodsTypeId").select2("val", goodsTypeId);

    $("#GoodsPackageName").on("input propertychange", function () {
        var name = $("#GoodsPackageName").val();
        if (name == null || name === "") {
            $(this).next(".help-inline").remove();
            $(this).parents(".control-group").addClass("error");
            $(this).after("<span class='help-inline'>请输入套餐名称</span>");
        } else {
            $(this).parents('.control-group').removeClass("error");
            $(this).next(".help-inline").remove();
        }
    });

    $("#GoodsPackagePrice").on("input propertychange", function () {
        var name = $("#GoodsPackagePrice").val();
        if (name == null || name === "") {
            $(this).next(".help-inline").remove();
            $(this).parents(".control-group").addClass("error");
            $(this).after("<span class='help-inline'>请输入套餐价格</span>");
        } else {
            $(this).parents('.control-group').removeClass("error");
            $(this).next(".help-inline").remove();
        }
    });

    $("#GoodsClassId").on("change", function () {
        var thisVal = $('#GoodsTypeId').find("option:selected").attr("title");
        if (thisVal === "0") {
            $("#GoodsTypeId").next(".help-inline").remove();
            $("#GoodsTypeId").parents(".control-group").addClass("error");
            $("#GoodsTypeId").after("<span class='help-inline'>请选择活动类型</span>");
        } else {
            $("#GoodsTypeId").parents(".control-group").removeClass("error");
            $("#GoodsTypeId").next(".help-inline").remove();
        }
    });

    $("#saveBtn").on("click", function (e) {
        var goodsPackageName = $("#GoodsPackageName").val();
        if (goodsPackageName == null || goodsPackageName === "") {
            $("#GoodsPackageName").next(".help-inline").remove();
            $("#GoodsPackageName").parents(".control-group").addClass("error");
            $("#GoodsPackageName").after("<span class='help-inline'>请输入套餐名称</span>");
            return false;
        } else {
            $("#GoodsPackageName").parents(".control-group").removeClass("error");
            $("#GoodsPackageName").next(".help-inline").remove();
        }

        var goodsPackagePrice = $("#GoodsPackagePrice").val();
        if (goodsPackagePrice == null || goodsPackagePrice === "") {
            $("#GoodsPackagePrice").next(".help-inline").remove();
            $("#GoodsPackagePrice").parents(".control-group").addClass("error");
            $("#GoodsPackagePrice").after("<span class='help-inline'>请输入套餐价格</span>");
            return false;
        } else {
            $("#GoodsPackagePrice").parents(".control-group").removeClass("error");
            $("#GoodsPackagePrice").next(".help-inline").remove();
        }

        var goodsTypeId = $('#GoodsTypeId').find("option:selected").attr("title");
        if (goodsTypeId === "0") {
            $("#GoodsTypeId").next(".help-inline").remove();
            $("#GoodsTypeId").parents(".control-group").addClass("error");
            $("#GoodsTypeId").after("<span class='help-inline'>请选择活动类型</span>");
            return false;
        } else {
            $("#GoodsTypeId").parents(".control-group").removeClass("error");
            $("#GoodsTypeId").next(".help-inline").remove();
        }


        if (goodsPackageId === "0") {
            //增加

            $.ajax({
                type: "POST",
                async: false,
                url: "/Activity/ActivityPackageAddAjax",
                data: { activitysPackageName: goodsPackageName, activitysPackagePrice: goodsPackagePrice, activitysTypeId: goodsTypeId, createTime: createTime, updateTime: updateTime, creatorId: creatorId, remark: remark },
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
                url: "/Activity/ActivityPackageUpdate",
                data: { activitysPackageName: goodsPackageName, activitysPackagePrice: goodsPackagePrice, activitysTypeId: goodsTypeId, createTime: createTime, updateTime: updateTime, creatorId: creatorId, remark: remark, activitysPackageId: goodsPackageId },
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