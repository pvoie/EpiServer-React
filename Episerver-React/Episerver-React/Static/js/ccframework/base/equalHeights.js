define(['domReady!'], function () {

/* EQUAL HEIGHTS FUNCTIONS - get tallest child and set all to that height */
/*Add class 'equalHeights' to set all children of the element to height of tallest child
  --OR--
  Add class 'equalHeightsItem' to child items of the same parent that should have equal heights (this allows some elements to not be set to equal heights */
function setEqualHeights() {
    var newHeight;
    if ($.fn.equalHeights === undefined) {
        $.fn.equalHeights = function (wrapper, childClass) {

            wrapper = wrapper || this;
            childClass = childClass || '';
            wrapper.each(function () {
                newHeight = 0;
                $el = $(this).children(childClass);
                $el.css("height", "auto");
                $el.each(function () {
                    newHeight = Math.max(newHeight, $(this).outerHeight(true));
                })
                $el.outerHeight(newHeight);
            });
        }
        $.fn.equalHeightsItem = function () {
            this.equalHeights(this.parent(), '.equalHeightsItem');
        }
        $('.equalHeights').equalHeights();
        $('.equalHeightsItem').equalHeightsItem();
    } else {
        $('.equalHeights').equalHeights();
        $('.equalHeightsItem').equalHeightsItem();
    }
}



/* Window.Resize() */
$(window).resize(function () {
    setEqualHeights();
}); // end .resize()


/* Window.load() */
$(document).ready(function () {
    setEqualHeights();
}); // end .load()

});