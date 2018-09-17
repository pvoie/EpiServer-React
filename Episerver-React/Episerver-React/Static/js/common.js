(function ($) {
    function startCommon() {
        $(".go-back").click(function () {
            window.history.back();
            return false;
        });
    }
    
    $(document).ready(function () {
        startCommon();
    });
}($wm));