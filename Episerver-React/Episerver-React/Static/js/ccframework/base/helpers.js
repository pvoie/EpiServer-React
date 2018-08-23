// Get query string parameter
function getQueryStringParam(name) {
    name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
    var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
        results = regex.exec(location.search);
    return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
}

// Standardize tap/click event: set to tap for touch devices
var tapClick = $.support.touch ? "tap" : "click";

// Can be used to kill loop if running too long
function killProcess(start, now, timeout) {
    if (typeof timeout === 'undefined')
        timeout = 3000;
    if (now.getTime() - start.getTime() >= timeout)
        return true;
    else
        return false;
}

// Add startsWith for IE
if (!String.prototype.startsWith) {
    String.prototype.startsWith = function (str) {
        return this.lastIndexOf(str, 0) === 0;
    };
}

// Add Support for Placeholder text on IE
jQuery(function () {
    jQuery.support.placeholder = false;
    webkit_type = document.createElement('input');
    if ('placeholder' in webkit_type) jQuery.support.placeholder = true;
});
$(function () {

    if (!$.support.placeholder) {

        var active = document.activeElement;

        $(':text, textarea, :password').focus(function () {

            if (($(this).attr('placeholder')) && ($(this).attr('placeholder').length > 0) && ($(this).attr('placeholder') != '') && $(this).val() == $(this).attr('placeholder')) {
                $(this).val('').removeClass('hasPlaceholder');
            }
        }).blur(function () {
            if (($(this).attr('placeholder')) && ($(this).attr('placeholder').length > 0) && ($(this).attr('placeholder') != '') && ($(this).val() == '' || $(this).val() == $(this).attr('placeholder'))) {
                $(this).val($(this).attr('placeholder')).addClass('hasPlaceholder');
            }
        });

        $(':text, textarea, :password').blur();
        $(active).focus();
        $('form').submit(function () {
            $(this).find('.hasPlaceholder').each(function () { $(this).val(''); });
        });
    }
});