
$(document).ready(function () {
    try {

        $('.main-content-change[data-cycle*="true"]')
            .cycle({ fx: 'fade' })
         .css('width', '').css('height', ''); //fix the inline hight and with that cycle plugin adds
    }
    catch (e) {
    }

    $(".nano").nanoScroller();

});