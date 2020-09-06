$(document).ready(function () {

    $('#fullpage').fullpage({
        //options here
        anchors: ['mailshop'],
        menu: '#myMenu',
        controlArrows: false
    });

    $('#fullpage').attr('style', 'height: calc(100% - 140px);position: relative;touch-action: none;transform: translate3d(0px, 0px, 0px);');

    //methods
    $.fn.fullpage.setAllowScrolling(false);

});