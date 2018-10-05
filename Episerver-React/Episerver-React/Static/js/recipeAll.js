(function ($) {
    var currentPage = 1,
        $resultsHolder,
        $viewMoreResults;

    function startPage() {
        $resultsHolder = $('#allRecipeItems');
        $viewMoreResults = $('div[data-search="viewMore"]', $resultsHolder);

        showHideMoreItems();
        attachEvents();

        $(window).resize(windowResize);
        windowResize();
    }

    function showHideMoreItems() {
        var hasMoreItems = $('input[data-search="hasMorePages"]', $resultsHolder).val();
        if (hasMoreItems && hasMoreItems !== 'false') {
            $viewMoreResults.show();
        } else {
            $viewMoreResults.hide();
        }
    }

    function attachEvents() {
        var $viewMoreLink = $('a', $viewMoreResults);
        $viewMoreLink.on('click', function (e) {
            e.preventDefault();
            handleViewMoreItems($(this));
        });

        $(".did-you-mean-box .close-box").click(function () {
            $(".did-you-mean-box").hide();
        });
    }

    function handleViewMoreItems($button) {
        var nextPage = currentPage + 1;
        var ajaxLink = buildAjaxPaginationUrl($button.attr('href'), nextPage);

        var resultsPromise = $.ajax({
            url: ajaxLink,
            method: 'GET'
        });
        
        resultsPromise.done(function (data) {
            processAjaxResults($(data));
        }).fail(function () {
            $viewMoreResults.hide();
        }).always(function () {
            currentPage++;
            windowResize();
        });
    }

    function buildAjaxPaginationUrl(ajaxUrl, pageNo) {
        var url = ajaxUrl;

        url += '?page=' + pageNo;

        var filterParam = getQueryParameterValue('filters');
        if (url) {
            url += '&filters=' + filterParam;
        }

        var kwdParam = getQueryParameterValue('q');
        if (kwdParam) {
            url += '&q=' + kwdParam;
        }

        return url;
    }

    function processAjaxResults($ajaxResponse) {
        var hasMoreResults = false;

        if ($ajaxResponse && $ajaxResponse.length) {
            hasMoreResults = $('input[data-search="hasMorePages"]', $ajaxResponse).val();
            var $items = $('[data-search="resultItem"]', $ajaxResponse);
            $('[data-search="itemsHolder"]', $resultsHolder).append($items);
        }

        if (hasMoreResults && hasMoreResults !== 'false') {
            $viewMoreResults.show();
        } else {
            $viewMoreResults.hide();
        }
    }

    function getQueryParameterValue (key) {
        var parameters = new RegExp('[\?&]' + key + '=([^&#]*)').exec(window.location.href);
        if (parameters == null) {
            return '';
        } else {
            return parameters[1] || '';
        }
    }

    function adjustSpacer(wSize) {
        $(".recipe-item").each(function () {
            $(this).removeClass('recipe-margin');
        });
    
        if (wSize > 796) {
            var cnt2 = 0;
            $(".recipe-item").each(function () {
                if (cnt2 < 2) {
                    cnt2++;
                    $(this).addClass('recipe-margin');
                } else {
                    cnt2 = 0;
                }
            });
        } else if (wSize >= 526 && wSize <= 796) {
            var cnt1 = 0;    
            $(".recipe-item").each(function () {
                if (cnt1 < 1) {
                    cnt1++;
                    $(this).addClass('recipe-margin');                
                } else {
                    cnt1 = 0;
                }
            });     
        } else {
            $(".recipe-item").each(function () {
                $(this).removeClass('recipe-margin');
            });
       
        }
    
    }

    function windowResize() {
        if ($(window).width() <= 526) {
            adjustSpacer(526);
        } else if ($(window).width() <= 796) {
            adjustSpacer(796);
        } else {
            adjustSpacer($(window).width());
        }
    }

    $(document).ready(function () {
        startPage();
    });
}($wm));
