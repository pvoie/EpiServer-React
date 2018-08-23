define(function () {
    $('.ccContent .hbhBrick.checklist .button.email').on('click', function () {
        var checked = $('.hbhBrick.checklist input[type=checkbox]:checked').siblings();

        if (checked.length == 0)
            alert('Please check the items you need and we will compile a list for you!');

        else {
            var list = "Medicine's to get from Walmart:%0A%0A";
            $(checked).each(function () {
                list += "- " + $(this).text() + "%0A%0A";
            })

            window.location.href = "mailto:?subject=Medicine%20cabinet%20checklist&body=" + list;
        }
    });

    $('.ccContent .hbhBrick.checklist .button.print').on('click', function () {
        printoutChecklist();
    });

    function printoutChecklist() {
        var checked = $('.ccContent .hbhBrick.checklist input[type=checkbox]:checked').siblings();

        if (checked.length == 0)
            alert('Please check the items you need and we will compile a list for you!');

        else {
            var list = "Medicine's to get from Walmart:<br/>";
            $(checked).each(function () {
                list += "- " + $(this).text() + "<br/>";
            })

            var newWindow = window.open();

            newWindow.document.write(list);
            newWindow.print();
        }
    }

});