define(['domReady!', 'helpers', 'bc'], function () {
    var ccPlayer;
    $('.ccContent .video-js').each(function () {
        var ccPlayerID = $(this).attr('id');
        videojs(ccPlayerID).ready(function () {
            ccPlayer = this;
            $('#' + ccPlayerID).on(tapClick, function () {
                if (cCenter.isMobileW() && !ccPlayer.paused())
                    ccPlayer.requestFullScreen();
            })
        });
    });
    $('.ccContent .videoThumb').on('click', function () {
        $(this).siblings('.modal-module').addClass('playing');
        ccPlayer.play();
    })
    $('.ccContent .modal-module .modal-close').on('click', function () {
        $(this).closest('.modal-module').removeClass('playing');
        ccPlayer.pause();
    })
});