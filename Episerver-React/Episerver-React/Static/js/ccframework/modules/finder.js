define(['domReady!', 'helpers', 'variables'], function () {

    $('.ccContent .finder a').on('click', function (e) {
        e.preventDefault();
        window.location.href = cCenter.finderLink;
    });
});