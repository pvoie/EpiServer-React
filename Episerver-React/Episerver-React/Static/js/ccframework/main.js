window.onpageshow = function (event) {
    if (event.persisted) {
        window.location.reload();
    }
};

var config = '/static/js/ccframework/config.js';
loadScripts();

function loadScripts() {
    if (typeof require == 'undefined')
        setTimeout(function () { loadScripts() }, 500);
    else {
        require([config], function () {
            require(['ads'], function () {
                setGoogleAdSlots();
                });
        });
    }
}