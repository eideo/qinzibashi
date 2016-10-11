$(document).ready(function () {

    $("#ParentRegionId").select2("val", parentRegionId);

    $("#RegionName").on("input propertychange", function () {
        var name = $("#RegionName").val();
        if (name == null || name === "") {
            $(this).next(".help-inline").remove();
            $(this).parents(".control-group").addClass("error");
            $(this).after("<span class='help-inline'>请输入区域名称</span>");
        } else {
            $(this).parents('.control-group').removeClass("error");
            $(this).next(".help-inline").remove();
        }
    });


    $("#saveBtn").on("click", function (e) {
        parentRegionId = $('#ParentRegionId').find("option:selected").attr("title");
        var name = $("#RegionName").val();
        if (name == null || name === "") {
            $("#RegionName").next(".help-inline").remove();
            $("#RegionName").parents(".control-group").addClass("error");
            $("#RegionName").after("<span class='help-inline'>请输入区域名称</span>");
            return false;
        } else {
            $("#RegionName").parents(".control-group").removeClass("error");
            $("#RegionName").next(".help-inline").remove();
        }

        //修改
        $.ajax({
            type: "POST",
            async: false,
            url: "/Activity/RegionUpdate",
            data: { regionName: name,parentRegionId:parentRegionId,createTime:createTime,updateTime:updateTime,creatorId:creatorId,remark:remark, regionId: regionId },
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

        return false;
    });
})