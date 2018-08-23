define(['domReady!'], function () {
    $('.ccContent .faqs .question').on('click', function () {
        $(this).toggleClass('open');
    });

    var activeClass = 'active';
    $('.ccContent .FAQTabs li').on('click', function () {
        if ($(this).hasClass(activeClass))
            return false;

        $('.ccContent .FAQTabs li.active').removeClass(activeClass);
        $('.ccContent .FAQTabs ~ ul.active').removeClass(activeClass);
        var i = $(this).index() + 1;
        $(this).addClass(activeClass);
        $($('.ccContent .hbhBrick.faqs > ul')[i]).addClass(activeClass);
    })

    var h;
    $('.ccContent .faqs > ul:not(.FAQTabs)').each(function () {
        $(this).show();
        $(this).find('.answer').each(function () {
            h = $(this).css('max-height', 'none').height()
            $(this).attr('style', '');
            if (h > 1500)
                $(this).addClass('xlong');
            else if (h > 500)
                $(this).addClass('long');
        });
        $(this).hide();
    });

    $(".ccContent li.faqItem .hbhButton").on("click", function () {
        $($(this).attr("href") + ' .question').click();
    })
});