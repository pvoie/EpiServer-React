define(['domReady!'], function () {

    $('.calculator input').keydown(function (e) {
        // Allow: backspace, delete, tab, escape, enter and .
        if ($.inArray(e.keyCode, [46, 8, 9, 27]) !== -1 ||
            // Allow: Ctrl+A
            (e.keyCode == 65 && e.ctrlKey === true) ||
            // Allow: home, end, left, right
            (e.keyCode >= 35 && e.keyCode <= 39)) {
            // let it happen, don't do anything
            return;
        }
        // Stop the keypress if: 
        // - is shift or enter
        // - not a number or decimal
        // - is second decimal, or
        // - already has 2 decimal places
        var val = this.value;
        if (e.shiftKey || e.keyCode == 13 ||
            ((e.keyCode < 48 || e.keyCode > 57) && (e.keyCode < 96 || e.keyCode > 105) && !(e.keyCode == 110 || e.keyCode == 190)) ||
            //already have a decimal entered
            ((val.indexOf(".") >= 0) && (
            //and trying to enter another decimal (and selected text does not include a decimal)
                (e.keyCode == 110 || e.keyCode == 190 && window.getSelection().toString().indexOf(".") >= 0) ||
            //or trying to enter more than two decimal places
                (val.length - val.indexOf(".") > 2 && val.length - this.selectionStart < 3)
             ))
            ) {
            e.preventDefault();
        }
    });
    $('.calculator input').on('change keyup', function () {
        var val = this.value;
        if (val.indexOf(".") >= 0 && val.length - val.indexOf(".") > 2)
            val = Math.round(val * 100) / 100;
        this.value = val;

        var total = 0;
        $('.calculator input').each(function () {
            total += parseFloat(0 + $(this).val());
        });
        var dollars = Math.floor(total);
        var cents = Math.floor((total * 100 - dollars * 100));
        //add commas to output
        dollars = dollars.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");

        $('.results td .dollars').text(dollars);
        $('.results td .cents').text(cents);
    });
    $('.calculator input').blur(function () {
        if (this.value == '')
            $(this).addClass('faded');
        else {
            if (this.value.startsWith("."))
                this.value = "0" + this.value;
            while (this.value.startsWith("0") && this.value.charAt(1) != ".")
                this.value = this.value.substring(1);
            if (this.value.indexOf(".") < 0) this.value += ".";
            while (this.value.charAt(this.value.length - 3) != ".")
                this.value = this.value += "0";
        }
    });
    $('.calculator input').focus(function () {
        if (this.value != '')
            $(this).removeClass('faded');
    });
});