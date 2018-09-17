(function ($) {
    function startPage() {
        configureLandingCtas();
    }

    function configureLandingCtas() {
        var $allCtas = $('.landingCtas > a');
        if ($allCtas.length) {
            $allCtas.each(function (index) {
                processSingleCta($(this));
            });
        }
    }

    function processSingleCta($ctaItem) {
        if ($ctaItem.data('processed')) {
            return;
        }
        var ctaType = $ctaItem.data('cta');
        switch (ctaType) {
            case 'half-width':
                processHalfWidthItem($ctaItem);
                break;
            case 'two-thirds':
                processTwoThirdsWidthItem($ctaItem);
                break;
            case 'third-width':
                processThirdWidthItem($ctaItem);
                break;
            default:
                addCtaRowSeparator($ctaItem);
                break;
        }
    }

    function processHalfWidthItem($ctaItem) {
        var $nextItem = $ctaItem.next('[data-cta="half-width"]');
        if ($nextItem.length) {
            markItemAsProcessed($nextItem);
            addCtaRowSeparator($nextItem);
        } else {
            // single half item on row
            addCtaRowSeparator($ctaItem);
        }
        markItemAsProcessed($ctaItem);
    }

    function processThirdWidthItem($ctaItem) {
        var $nextItem = $ctaItem.next();
        if ($nextItem.length) {
            var nextCtaType = $nextItem.data('cta');
            switch (nextCtaType) {
                case 'third-width':
                    var $thirdItem = $nextItem.next('[data-cta="third-width"]');
                    if ($thirdItem.length) {
                        addCtaRowSeparator($thirdItem);
                        markItemAsProcessed($thirdItem);
                    } else {
                        addCtaRowSeparator($nextItem);
                    }
                    markItemAsProcessed($nextItem);
                    break;
                case 'two-thirds':
                    $ctaItem.css({
                        'height': $nextItem.outerHeight()                        
                    });
                    $nextItem.addClass('last-in-row');
                    addCtaRowSeparator($nextItem);
                    markItemAsProcessed($nextItem);
                    break;
            }
        }

        markItemAsProcessed($ctaItem);
    }

    function processTwoThirdsWidthItem($ctaItem) {
        var $nextItem = $ctaItem.next('[data-cta="third-width"]');
        if ($nextItem.length) {
            $nextItem.css({
                'height': $ctaItem.outerHeight()
            }).addClass('last-in-row');
            markItemAsProcessed($nextItem);
            addCtaRowSeparator($nextItem);
        } else {
            // single half item on row
            addCtaRowSeparator($ctaItem);
        }
        markItemAsProcessed($ctaItem);
    }

    function addCtaRowSeparator($ctaItem) {
        $ctaItem.after('<div class="row-sep"></div>');
    }

    function markItemAsProcessed($ctaItem) {
        $ctaItem.data({
            'processed': 'true'
        }).attr({
            'processed': 'true'
        });
    }

    $(document).ready(function () {
        startPage();
    });
}($wm));