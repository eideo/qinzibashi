function validateSRPrice() {
    var thisVal = $("#SRPrice").val();
    if (thisVal == null || thisVal === "") {
        $("#SRPrice").next(".help-inline").remove();
        $("#SRPrice").parents(".control-group").addClass("error");
        $("#SRPrice").after("<span class='help-inline'>请输入优惠券满价格</span>");
    } else {
        $("#SRPrice").parents('.control-group').removeClass("error");
        $("#SRPrice").next(".help-inline").remove();
    }
}

function validateVoucherPrice() {
    var thisVal = $("#VoucherPrice").val();
    if (thisVal == null || thisVal === "") {
        $("#VoucherPrice").next(".help-inline").remove();
        $("#VoucherPrice").parents(".control-group").addClass("error");
        $("#VoucherPrice").after("<span class='help-inline'>请输入优惠券减价格</span>");
    } else {
        $("#VoucherPrice").parents('.control-group').removeClass("error");
        $("#VoucherPrice").next(".help-inline").remove();
    }
}

function validateUseRole() {
    var thisVal = $("#UseRole").val();
    if (thisVal == null || thisVal === "") {
        $("#UseRole").next(".help-inline").remove();
        $("#UseRole").parents(".control-group").addClass("error");
        $("#UseRole").after("<span class='help-inline'>请输入优惠券使用规则</span>");
    } else {
        $("#UseRole").parents('.control-group').removeClass("error");
        $("#UseRole").next(".help-inline").remove();
    }
}

function validateUseStartTime() {
    var thisVal = $("#UseStartTime").val();
    if (thisVal == null || thisVal === "") {
        $("#UseStartTime").next(".help-inline").remove();
        $("#UseStartTime").parents(".control-group").addClass("error");
        $("#UseStartTime").after("<span class='help-inline'>请输入使用开始时间</span>");
    } else {
        $("#UseStartTime").parents('.control-group').removeClass("error");
        $("#UseStartTime").next(".help-inline").remove();
    }
}

function validateUseEndTime() {
    var thisVal = $("#UseEndTime").val();
    if (thisVal == null || thisVal === "") {
        $("#UseEndTime").next(".help-inline").remove();
        $("#UseEndTime").parents(".control-group").addClass("error");
        $("#UseStartTime").after("<span class='help-inline'>请输入使用结束时间</span>");
    } else {
        $("#UseEndTime").parents('.control-group').removeClass("error");
        $("#UseEndTime").next(".help-inline").remove();
    }
}

function validateVoucherCount() {
    var thisVal = $("#VoucherCount").val();
    if (thisVal == null || thisVal === "") {
        $("#VoucherCount").next(".help-inline").remove();
        $("#VoucherCount").parents(".control-group").addClass("error");
        $("#VoucherCount").after("<span class='help-inline'>请输入优惠数量</span>");
    } else {
        $("#VoucherCount").parents('.control-group').removeClass("error");
        $("#VoucherCount").next(".help-inline").remove();
    }
}

$(document).ready(function () {

    $("#VoucherType").select2("val", voucherType);
    if (voucherType == "1")
    {
        var html = '<div class="control-group" id="ADD1">';
        html += '<label class="control-label">满：</label>';
        html += '<div class="controls">';
        html += '<input id="SRPrice" type="text" class="span11" placeholder="满" value="' + sRPrice + '">';
        html += '</div>';
        html += '</div>';
        html += '<div class="control-group" id="ADD2">';
        html += '<label class="control-label">减：</label>';
        html += '<div class="controls">';
        html += '<input id="VoucherPrice" type="text" class="span11" placeholder="减" value="' + voucherPrice + '">';
        html += '</div>';
        html += '</div>';
        $("#VoucherType").parent(".controls").parent(".control-group").after(html);
    }
    else
    {
        var html = '<div class="control-group" id="ADD1" style="display:none">';
        html += '<label class="control-label">满：</label>';
        html += '<div class="controls">';
        html += '<input id="SRPrice" type="text" class="span11" placeholder="满" value="' + sRPrice + '">';
        html += '</div>';
        html += '</div>';
        html += '<div class="control-group" id="ADD2">';
        html += '<label class="control-label">扣减：</label>';
        html += '<div class="controls">';
        html += '<input id="VoucherPrice" type="text" class="span11" placeholder="减" value="' + voucherPrice + '">';
        html += '</div>';
        html += '</div>';
        $("#VoucherType").parent(".controls").parent(".control-group").after(html);
    }

    $("#VoucherType").on("change", function ()
    {
        $("#ADD1").remove();
        $("#ADD2").remove();
        var thisVal = $('#VoucherType').find("option:selected").attr("title");
        if (thisVal == "1") {
            var html = '<div class="control-group" id="ADD1">';
            html += '<label class="control-label">满：</label>';
            html += '<div class="controls">';
            html += '<input id="SRPrice" type="text" class="span11" placeholder="满" value="' + sRPrice + '">';
            html += '</div>';
            html += '</div>';
            html += '<div class="control-group" id="ADD2">';
            html += '<label class="control-label">减：</label>';
            html += '<div class="controls">';
            html += '<input id="VoucherPrice" type="text" class="span11" placeholder="减" value="' + voucherPrice + '">';
            html += '</div>';
            html += '</div>';
            $("#VoucherType").parent(".controls").parent(".control-group").after(html);
        }
        else {
            var html = '<div class="control-group" id="ADD1" style="display:none">';
            html += '<label class="control-label">满：</label>';
            html += '<div class="controls">';
            html += '<input id="SRPrice" type="text" class="span11" placeholder="满" value="' + sRPrice + '">';
            html += '</div>';
            html += '</div>';
            html += '<div class="control-group" id="ADD2">';
            html += '<label class="control-label">扣减：</label>';
            html += '<div class="controls">';
            html += '<input id="VoucherPrice" type="text" class="span11" placeholder="减" value="' + voucherPrice + '">';
            html += '</div>';
            html += '</div>';
            $("#VoucherType").parent(".controls").parent(".control-group").after(html);
        }
    });


    if (useStartTime == "0001/1/1 0:00:00" || useStartTime == "") {
        $("#UseStartTime").val("");
    } else {
        $("#UseStartTime").val(useStartTime);
    }

    if (useEndTime == "0001/1/1 0:00:00" || useEndTime == "") {
        $("#UseEndTime").val("");
    } else {
        $("#UseEndTime").val(useEndTime);
    }

    $("#VoucherStatus").select2("val", voucherStatus);

    $("#SRPrice").on("input propertychange", function () {
        validateSRPrice();
    });

    $("#VoucherPrice").on("input propertychange", function () {
        validateVoucherPrice();
    });

    $("#UseStartTime").on("input propertychange", function () {
        $(".UseStartTime").datetimepicker('remove');
        validateUseStartTime();
    });

    $("#UseEndTime").on("input propertychange", function () {
        $(".UseEndTime").datetimepicker('remove');
        validateUseEndTime();
    });

    $("#UseRole").on("input propertychange", function () {
        validateUseRole();
    });

    $("#VoucherCount").on("input propertychange", function () {
        validateVoucherCount();
    });

    $("#saveBtn").on("click", function (e) {
        voucherType = $('#VoucherType').find("option:selected").attr("title");
        sRPrice = $("#SRPrice").val();
        voucherPrice = $("#VoucherPrice").val();
        useRole = $("#UseRole").val();
        useStartTime = $("#UseStartTime").val();
        useEndTime = $("#UseEndTime").val();
        voucherStatus = $('#VoucherStatus').find("option:selected").attr("title");
        voucherCount = $("#VoucherCount").val();
        
        validateSRPrice();
        validateVoucherPrice();
        validateUseRole();
        validateUseStartTime();
        validateUseEndTime();
        validateVoucherCount();

        if (voucherId === "0") {
            //增加

            $.ajax({
                type: "POST",
                async: false,
                url: "/Activity/VoucherAddAjax",
                data: { voucherPrice: voucherPrice, useRole: useRole, voucherType: voucherType, sRPrice: sRPrice, useStartTime: useStartTime, useEndTime: useEndTime, voucherStatus: voucherStatus, createTime: createTime, updateTime: updateTime, creatorId: creatorId, remark: remark, voucherCount: voucherCount },
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
                url: "/Activity/VoucherUpdateAjax",
                data: { voucherPrice: voucherPrice, useRole: useRole, voucherType: voucherType, sRPrice: sRPrice, useStartTime: useStartTime, useEndTime: useEndTime, voucherStatus: voucherStatus, createTime: createTime, updateTime: updateTime, creatorId: creatorId, remark: remark, voucherCount: voucherCount, voucherId: voucherId },
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