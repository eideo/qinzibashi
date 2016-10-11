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

function validateGoodsName() {
    var thisVal = $("#GoodsName").val();
    if (thisVal == null || thisVal === "") {
        $("#GoodsName").next(".help-inline").remove();
        $("#GoodsName").parents(".control-group").addClass("error");
        $("#GoodsName").after("<span class='help-inline'>请输入活动名称</span>");
        return false;
    } else {
        $("#GoodsName").parents('.control-group').removeClass("error");
        $("#GoodsName").next(".help-inline").remove();
        return true;
    }
}

function validateMarketPrice() {
    var thisVal = $("#MarketPrice").val();
    if (thisVal == null || thisVal === "") {
        $("#MarketPrice").next(".help-inline").remove();
        $("#MarketPrice").parents(".control-group").addClass("error");
        $("#MarketPrice").after("<span class='help-inline'>请输入市场价</span>");
        return false;
    }
    else if (!reg1.test(thisVal)) {
        $("#MarketPrice").next(".help-inline").remove();
        $("#MarketPrice").parents(".control-group").addClass("error");
        $("#MarketPrice").after("<span class='help-inline'>价格格式不正确</span>");
        return false;
    }
    else {
        $("#MarketPrice").parents('.control-group').removeClass("error");
        $("#MarketPrice").next(".help-inline").remove();
        return true;
    }
}

function validateSellingPrice() {
    var thisVal = $("#SellingPrice").val();
    if (thisVal == null || thisVal === "") {
        $("#SellingPrice").next(".help-inline").remove();
        $("#SellingPrice").parents(".control-group").addClass("error");
        $("#SellingPrice").after("<span class='help-inline'>请输入销售价</span>");
        return false;
    }
    else if (!reg1.test(thisVal)) {
        $("#SellingPrice").next(".help-inline").remove();
        $("#SellingPrice").parents(".control-group").addClass("error");
        $("#SellingPrice").after("<span class='help-inline'>价格格式不正确</span>");
        return false;
    }
    else {
        $("#SellingPrice").parents('.control-group').removeClass("error");
        $("#SellingPrice").next(".help-inline").remove();
        return true;
    }
}

function validateRemark() {
    var thisVal = $("#Remark").val();
    if (thisVal == null || thisVal === "") {
        $("#Remark").next(".help-inline").remove();
        $("#Remark").parents(".control-group").addClass("error");
        $("#Remark").after("<span class='help-inline'>请输入活动地址</span>");
        return false;
    } else {
        $("#Remark").parents('.control-group').removeClass("error");
        $("#Remark").next(".help-inline").remove();
        return true;
    }
}

function validateGoodsClassId() {
    var thisVal = $('#GoodsClassId').find("option:selected").attr("title");
    if (thisVal === "0") {
        $("#GoodsClassId").next(".help-inline").remove();
        $("#GoodsClassId").parents(".control-group").addClass("error");
        $("#GoodsClassId").after("<span class='help-inline'>请选择首页活动分类</span>");
        return false;
    } else {
        $("#GoodsClassId").parents(".control-group").removeClass("error");
        $("#GoodsClassId").next(".help-inline").remove();
        return true;
    }
}

function validateActivityClassId() {
    var thisVal = $('#ActivityClassId').find("option:selected").attr("title");
    if (thisVal === "0") {
        $("#ActivityClassId").next(".help-inline").remove();
        $("#ActivityClassId").parents(".control-group").addClass("error");
        $("#ActivityClassId").after("<span class='help-inline'>请选择活动筛选分类</span>");
        return false;
    } else {
        $("#ActivityClassId").parents(".control-group").removeClass("error");
        $("#ActivityClassId").next(".help-inline").remove();
        return true;
    }
}

function validateGoodsTypeId() {
    var thisVal = $('#GoodsTypeId').find("option:selected").attr("title");
    if (thisVal === "0") {
        $("#GoodsTypeId").next(".help-inline").remove();
        $("#GoodsTypeId").parents(".control-group").addClass("error");
        $("#GoodsTypeId").after("<span class='help-inline'>请选择活动类型</span>");
        return false;
    } else {
        $("#GoodsTypeId").parents(".control-group").removeClass("error");
        $("#GoodsTypeId").next(".help-inline").remove();
        return true;
    }
}

function validateAgeRangeId() {
    var thisVal = $('#AgeRangeId').find("option:selected").attr("title");
    if (thisVal === "0") {
        $("#AgeRangeId").next(".help-inline").remove();
        $("#AgeRangeId").parents(".control-group").addClass("error");
        $("#AgeRangeId").after("<span class='help-inline'>请选择年龄范围</span>");
        return false;
    } else {
        $("#AgeRangeId").parents(".control-group").removeClass("error");
        $("#AgeRangeId").next(".help-inline").remove();
        return true;
    }
}

function validateRegionId() {
    var thisVal = $('#RegionId').find("option:selected").attr("title");
    if (thisVal === "0") {
        $("#RegionId").next(".help-inline").remove();
        $("#RegionId").parents(".control-group").addClass("error");
        $("#RegionId").after("<span class='help-inline'>请选择区域</span>");
        return false;
    } else {
        $("#RegionId").parents(".control-group").removeClass("error");
        $("#RegionId").next(".help-inline").remove();
        return true;
    }
}

function validateGoodsCount() {
    var thisVal = $("#GoodsCount").val();
    if (thisVal == null || thisVal === "") {
        $("#GoodsCount").next(".help-inline").remove();
        $("#GoodsCount").parents(".control-group").addClass("error");
        $("#GoodsCount").after("<span class='help-inline'>请输入活动名额</span>");
        return false;
    } else {
        $("#GoodsCount").parents('.control-group').removeClass("error");
        $("#GoodsCount").next(".help-inline").remove();
        return true;
    }
}

$(document).ready(function () {

    if (goodsMainImgUrl === "") {
        $("#uploadPreview").attr("src", "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAL4AAACMCAYAAADCxhM7AAAEDElEQVR4Xu3YwU4qAQBDUV35Y3623+Te1XvRZBIkA9Toqj0umcLQ2+sw8Pz+/v7vyR8CYwSeiT+2uLpfBIhPhEkCxJ+cXWnic2CSAPEnZ1ea+ByYJED8ydmVJj4HJgkQf3J2pYnPgUkCxJ+cXWnic2CSAPEnZ1ea+ByYJED8ydmVJj4HJgkQf3J2pYnPgUkCxJ+cXWnic2CSAPEnZ1ea+ByYJED8ydmVJj4HJgkQf3J2pYnPgUkCxJ+cXWnic2CSAPEnZ1ea+ByYJED8ydmVJj4HJgkQf3J2pYnPgUkCxJ+cXWnic2CSAPEnZ1ea+ByYJED8ydmVJj4HJgkQf3J2pYnPgUkCxJ+cXWnic2CSAPEnZ1ea+ByYJED8ydmVJj4HJgkQf3J2pYnPgUkCxJ+cXWnic2CSAPEnZ1ea+ByYJED8ydmVJj4HJgkQf3J2pYnPgUkCxJ+cXWnic2CSAPEnZ1ea+ByYJED8ydmVJj4HJgkQf3J2pYkfOPD29vaVen19/ZY+Hj8evDx+79ijU9463/G8s+O/Od+j99N4nPgPVr0U6kzs47FLGa/FfCTy5Vu4db5r6S//EX9zvkapk07EDyjdu8L+tfifb+feJ8zLy8vTx8fHt08g4gcjXkWIHzD7S/GP17oU+Po2ivjBKL+MED8AmN7jHwI/ugJ/Hj+7cif38J+fMMnrn30nCarORIgfTJ3co//0Hv/ea/71P1pQcS5C/GDyRyJeX4WTK/JPr/hnX4DPvl/c+44QVJ2JEP8Hv+rcuhc/XiL5OfPRPX7ys+TZLz/J82asDooSP4Ak0keA+H2bahQQIH4ASaSPAPH7NtUoIED8AJJIHwHi922qUUCA+AEkkT4CxO/bVKOAAPEDSCJ9BIjft6lGAQHiB5BE+ggQv29TjQICxA8gifQRIH7fphoFBIgfQBLpI0D8vk01CggQP4Ak0keA+H2bahQQIH4ASaSPAPH7NtUoIED8AJJIHwHi922qUUCA+AEkkT4CxO/bVKOAAPEDSCJ9BIjft6lGAQHiB5BE+ggQv29TjQICxA8gifQRIH7fphoFBIgfQBLpI0D8vk01CggQP4Ak0keA+H2bahQQIH4ASaSPAPH7NtUoIED8AJJIHwHi922qUUCA+AEkkT4CxO/bVKOAAPEDSCJ9BIjft6lGAQHiB5BE+ggQv29TjQICxA8gifQRIH7fphoFBIgfQBLpI0D8vk01CggQP4Ak0keA+H2bahQQIH4ASaSPAPH7NtUoIED8AJJIHwHi922qUUCA+AEkkT4CxO/bVKOAAPEDSCJ9BIjft6lGAQHiB5BE+ggQv29TjQICxA8gifQRIH7fphoFBIgfQBLpI0D8vk01CggQP4Ak0keA+H2bahQQ+A+/RfaXeLqcpQAAAABJRU5ErkJggg==");
    } else {
        $("#uploadPreview").attr("src", goodsMainImgUrl);
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

    $("#GoodsClassId").select2("val", goodsClassId);
    $("#GoodsTypeId").select2("val", goodsTypeId);
    $("#AgeRangeId").select2("val", ageRangeId);
    $("#RegionId").select2("val", regionId);
    $("#GoodsStatus").select2("val", goodsStatus);
    $("#IsDisplayHome").select2("val", isDisplayHome);
    $("#ActivityClassId").select2("val", activityFilterClassId);

    $("#GoodsName").on("input propertychange", function () {
        validateGoodsName();
    });

    $("#MarketPrice").on("input propertychange", function () {
        validateMarketPrice();
    });

    $("#SellingPrice").on("input propertychange", function () {
        validateSellingPrice();
    });

    $("#Remark").on("input propertychange", function () {
        validateRemark();
    });

    $("#GoodsClassId").on("change", function () {
        validateGoodsClassId();
    });

    $("#ActivityClassId").on("change", function () {
        validateActivityClassId();
    });

    $("#GoodsTypeId").on("change", function () {
        validateGoodsTypeId();
    });

    $("#AgeRangeId").on("change", function () {
        validateAgeRangeId();
    });

    $("#RegionId").on("change", function () {
        validateRegionId();
    });

    $("#GoodsCount").on("input propertychange", function () {
        validateGoodsCount();
    })

    $("#saveBasicBtn").on("click", function (e) {
        goodsId = $("#GoodsId").val();
        goodsClassId = $('#GoodsClassId').find("option:selected").attr("title");
        goodsTypeId = $('#GoodsTypeId').find("option:selected").attr("title");
        ageRangeId = $('#AgeRangeId').find("option:selected").attr("title");
        regionId = $('#RegionId').find("option:selected").attr("title");
        isDisplayHome = $('#IsDisplayHome').find("option:selected").attr("title");
        goodsStatus = $('#GoodsStatus').find("option:selected").attr("title");
        goodsName = $("#GoodsName").val();
        marketPrice = $("#MarketPrice").val();
        sellingPrice = $("#SellingPrice").val();
        goodsCost = $("#GoodsCost").val();
        goodsDesc = $("#SourceContent1").val();
        goodsDesc = encodeURIComponent(goodsDesc);
        goodsMainImgUrl = $("#hidUploadImgUrl").val();
        visitTime1 = $("#VisitTime1").val();
        visitTime2 = $("#VisitTime2").val();
        visitTime3 = $("#VisitTime3").val();
        visitTime4 = $("#VisitTime4").val();
        visitTime5 = $("#VisitTime5").val();
        longitude = $("#Longitude").val();
        latitude = $("#Latitude").val();
        isDelete = $("#IsDelete").val();
        createTime = $("#CreateTime").val();
        updateTime = $("#UpdateTime").val();
        creatorId = $("#CreatorId").val();
        remark = $("#Remark").val();
        responsiblePerson = $("#ResponsiblePerson").val();
        responsiblePersonProfit = $("#ResponsiblePersonProfit").val();
        goodsCount = $("#GoodsCount").val();
        activityFilterClassId = $('#ActivityClassId').find("option:selected").attr("title");
        platformCost = $("#PlatformCost").val();
        otherCost = $("#OtherCost").val();

        var isGoodsName=validateGoodsName();
        var isMarketPrice = validateMarketPrice();
        var isSellingPrice = validateSellingPrice();
        var isRemark = validateRemark();
        var isGoodsClassId = validateGoodsClassId();
        var isGoodsTypeId = validateGoodsTypeId();
        var isAgeRangeId = validateAgeRangeId();
        var isRegionId = validateRegionId();
        var isGoodsCount = validateGoodsCount();

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

        if (!isGoodsName || !isMarketPrice || !isSellingPrice || !isRemark || !isGoodsClassId || !isGoodsTypeId || !isAgeRangeId || !isRegionId || !isGoodsCount) {
            return false;
        }

        if (goodsId === "0") {
            //增加
            $.ajax({
                type: "POST",
                async: false,
                url: "/Activity/ActivityAddAjax",
                data: {
                    activitysName: goodsName,
                    marketPrice: marketPrice,
                    sellingPrice: sellingPrice,
                    activitysDesc: goodsDesc,
                    activitysClassId: goodsClassId,
                    activitysTypeId: goodsTypeId,
                    ageRangeId: ageRangeId,
                    regionId: regionId,
                    activitysMainImgUrl: imgUrl,
                    visitTime1: visitTime1,
                    visitTime2: visitTime2,
                    visitTime3: visitTime3,
                    visitTime4: visitTime4,
                    visitTime5: visitTime5,
                    longitude: longitude,
                    latitude: latitude,
                    activitysStatus: goodsStatus,
                    isDisplayHome: isDisplayHome,
                    isDelete: isDelete,
                    createTime: createTime,
                    updateTime: updateTime,
                    creatorId: creatorId,
                    remark: remark,
                    responsiblePerson: responsiblePerson,
                    responsiblePersonProfit: responsiblePersonProfit,
                    activitysCount: goodsCount,
                    activitysCost: goodsCost,
                    activityFilterClassId: activityFilterClassId,
                    platformCost: platformCost,
                    otherCost: otherCost
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
                url: "/Activity/ActivityUpdateAjax",
                data: {
                    activitysName: goodsName,
                    marketPrice: marketPrice,
                    sellingPrice: sellingPrice,
                    activitysDesc: goodsDesc,
                    activitysClassId: goodsClassId,
                    activitysTypeId: goodsTypeId,
                    ageRangeId: ageRangeId,
                    regionId: regionId,
                    activitysMainImgUrl: goodsMainImgUrl,
                    visitTime1: visitTime1,
                    visitTime2: visitTime2,
                    visitTime3: visitTime3,
                    visitTime4: visitTime4,
                    visitTime5: visitTime5,
                    longitude: longitude,
                    latitude: latitude,
                    activitysStatus: goodsStatus,
                    isDisplayHome: isDisplayHome,
                    isDelete: isDelete,
                    createTime: createTime,
                    updateTime: updateTime,
                    creatorId: creatorId,
                    remark: remark,
                    responsiblePerson: responsiblePerson,
                    responsiblePersonProfit: responsiblePersonProfit,
                    activitysCount: goodsCount,
                    activitysCost: goodsCost,
                    activityFilterClassId: activityFilterClassId,
                    platformCost: platformCost,
                    otherCost: otherCost,
                    activitysId: goodsId
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
