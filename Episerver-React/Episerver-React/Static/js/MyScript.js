function startMenu() {
    var el = $('input[type=text], textarea');
    el.focus(function (e) {
        if (e.target.value == e.target.defaultValue)
            e.target.value = '';
    });
    el.blur(function (e) {
        if (e.target.value == '')
            e.target.value = e.target.defaultValue;
    });

    $(".menu-tab-container").click(function () {
        if (isOpen == false) {
            isOpen = true;
            $("#arrowImage").removeClass("down-arrow");
            $("#arrowImage").addClass("up-arrow");
            TweenMax.to($(".drop-target"), .3, { css: { opacity: 1, top: 0 } });
        } else {
            isOpen = false;
            $("#arrowImage").removeClass("up-arrow");
            $("#arrowImage").addClass("down-arrow");
            TweenMax.to($(".drop-target"), .3, { css: { opacity: 0, top: -212 } });
        }
    });
}


$(document).ready(function () {
    //if ($("div:first").val.toString()) {

    //}
    $("div:contains('There is a license error ')").remove();
    startMenu();

   
});