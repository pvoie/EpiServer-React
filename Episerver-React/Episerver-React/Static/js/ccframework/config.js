var cCenter = {
    //TODO: set this to the correct path for dev instance
    baseURL: '/static/js/ccframework/'
};

requirejs.config({
    //baseUrl: 'static/gen/js/lib', 
    // ^ this is the RequireJS default setting
    // requirejs doesn't use the reset of this variable well at all
    // just adding the default here for reference
    paths: {
        //TODO: set these to the correct paths for dev instance (once we decide where to put files
        //jquery: cCenter.baseURL + 'vendor/jquery-1.11.3.min',
        //jquery: '../lib/jquery/jquery',
        domReady: cCenter.baseURL + 'vendor/requirejs/domReady',

        helpers: cCenter.baseURL + 'base/helpers',
        equalHeights: cCenter.baseURL + 'base/equalHeights',
        variables: cCenter.baseURL + 'base/variables',
        trackers: cCenter.baseURL + 'modules/trackers',
        ads: cCenter.baseURL + 'modules/ads',
        nav: cCenter.baseURL + 'modules/nav',
        finder: cCenter.baseURL + 'modules/finder',
        video: cCenter.baseURL + 'modules/video',
        faqs: cCenter.baseURL + 'modules/faqs',
        calc: cCenter.baseURL + 'modules/calc',
        checklist: cCenter.baseURL + 'modules/checklist',
    },
    shim: {
        brightcove: ['domReady!']
    }
});


require(['domReady!', 'trackers', 'ads', 'helpers'], function () {
    require(['finder','equalHeights']);
});