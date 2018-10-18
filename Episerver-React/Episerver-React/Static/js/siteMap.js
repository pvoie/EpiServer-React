function RemoveEmptyLinks() {
    var mapLinks = $(".map-item"), href,i;
    for (var i = 0; i < mapLinks.length; i++) {
        href = mapLinks[i].getAttribute('href');
        if (href.trim().length < 1) {
            mapLinks[i].replaceWith(mapLinks[i].innerText);
        }
    }
}

$(document).ready(function () {
    RemoveEmptyLinks();
});