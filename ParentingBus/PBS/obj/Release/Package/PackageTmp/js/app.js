/**
 * @description: app
 * @author: lixinwei
 * @version: V1
 * @update: 15/12/7
 */

;(function($){

    //搜索
    $('.ui-searchbar').tap(function(){
        $('.ui-searchbar-wrap').addClass('focus');
        $('.ui-searchbar-input input').focus();
    });
    $('.ui-searchbar-cancel').tap(function(){
        $('.ui-searchbar-wrap').removeClass('focus');
    });


    //input focus事件
    $('.ui-form-item').find('input').on('focus',function(){
        $(this).parent().find('.ui-icon-close').show();
    }).on('blur',function(){
        $(this).parent().find('.ui-icon-close').hide();
    });
    // 清空input值
    $('.ui-icon-close').tap(function(){
        var _this = $(this);
        _this.parent().find('input').val('');
    });

    // 首页silder
    if ($('.ui-slider').length > 0) {
        
        var slider = new fz.Scroll('.ui-slider', {
            role: 'slider',
            indicator: true,
            autoplay: true,
            interval: 3000
        });

        /* 滑动开始前 */
        slider.on('beforeScrollStart', function(from, to) {
            //console.log(from, to);
        });

        /* 滑动结束 */
        slider.on('scrollEnd', function(cruPage) {
            //console.log(curPage);
        });
    }
    if ($('.ui-tab').length > 0) {

        var tab = new fz.Scroll('.ui-tab', {
            role: 'tab'
        });

        //滑动开始前调用
        tab.on('beforeScrollStart', function(from, to) {
            //console.log(from, to);
        });
        //滑动结束时调用
        tab.on('scrollEnd', function(curPage) {
            //console.log(curPage);
        });
    }

    // 加载更多
    function loadMore($el){
        $el.tap(function(){
            var _this = $(this);
            var moreUrl = '';
            var $loading = $('.ui-loading-wrap');

            $loading.css({
                display: '-webkit-box'
            });
            _this.hide();

            setTimeout(function () {
                $loading.css({
                    display: 'none'
                });
                _this.show();

                $.ajax({
                    type: 'GET',
                    url: moreUrl,
                    data: {},
                    contentType: 'application/json',
                    success: function(data){
                        var testData = {
                            "code":0,
                            "data":{
                                "msg": "成功",
                                "content": "我是更多"
                            }
                        };
                        var res = testData || data;
                        var $box = $('.list-conts');
                        var _tpl = '<li class="ui-border-t">'+res.data.content+'</li>';
                        $box.append(_tpl);
                        // Todo

                    },
                    error: function(xhr, type){
                        console.log('Ajax error!');
                    }
                })

            }, 3000)

        })
    }
    loadMore($('#J_more'));
    
    


    //操作成功和失败提示
    var el;
    $("#test1").tap(function(){
        el=$.tips({
            content:'操作成功',
            stayTime:2000,
            type:"success" //info|warn|success
        });
        // 隐藏回调
        el.on("tips:hide",function(){
            //Todo
        })

    });

    $(".J_rec").tap(function(){
        var dia2=$(".ui-dialog").dialog("show");

        dia2.on("dialog:action",function(e){
            console.log(e.index)
        });

    })





})(window.Zepto);






