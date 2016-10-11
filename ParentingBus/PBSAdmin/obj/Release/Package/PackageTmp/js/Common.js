function goPage(newURL) {

    // if url is empty, skip the menu dividers and reset the menu selection to default
    if (newURL != "") {

        // if url is "-", it is this page -- reset the menu:
        if (newURL == "-") {
            resetMenu();
        }
            // else, send page to designated URL            
        else {
            document.location.href = newURL;
        }
    }
}

// resets the menu selection upon entry to this page:
function resetMenu() {
    document.gomenu.selector.selectedIndex = 2;
}

function logout(obj) {
    $(obj).scojs_confirm({
        content: "您确定要退出吗?",
        action: "/Account/Logout"
    });
}

function Gohome(obj) {
    $("#sidebar ul li").removeClass("open");
    $("#sidebar ul li").find("ul").css("display", "none");
    $(obj).attr("href", "/Home/Main");
    //$.ajax({ url: "/Home/Main", async: false });
}

//$(document).ready(function() {
//    $("#example").dataTable({
//        "bAutoWidth": false, //自适应宽度
//        "aaSorting": [[1, "asc"]],
//        "sPaginationType": "full_numbers",
//        "bRetrieve": true,
//        "oLanguage": {
//            "sProcessing": "处理中...",
//            "sLengthMenu": "显示 _MENU_ 项结果",
//            "sZeroRecords": "没有匹配结果",
//            "sInfo": "显示第 _START_ 至 _END_ 项结果，共 _TOTAL_ 项",
//            "sInfoEmpty": "显示第 0 至 0 项结果，共 0 项",
//            "sInfoFiltered": "(由 _MAX_ 项结果过滤)",
//            "sInfoPostFix": "",
//            "sSearch": "搜索:",
//            "sUrl": "",
//            "sEmptyTable": "表中数据为空",
//            "sLoadingRecords": "载入中...",
//            "sInfoThousands": ",",
//            "oPaginate": {
//                "sFirst": "首页",
//                "sPrevious": "上页",
//                "sNext": "下页",
//                "sLast": "末页"
//            },
//            "oAria": {
//                "sSortAscending": ": 以升序排列此列",
//                "sSortDescending": ": 以降序排列此列"
//            }
//        }

//    });
//});
//$(document).ready(function() {
//    var data = [
//    [
//        "Tiger Nixon",
//        "System Architect",
//        "Edinburgh",
//        "5421"
//    ],
//    [
//        "Garrett Winters",
//        "Director",
//        "Edinburgh",
//        "8422"
//    ]
//    ];

//    $('#example').DataTable({
//        data: data,
//        "bRetrieve": true
//    });
//});
