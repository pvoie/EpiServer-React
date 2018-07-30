function setCookie(name, value, days) {
    var expires = "";
    if (days) {
        var date = new Date();
        date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
        expires = "; expires=" + date.toUTCString();
    }
    document.cookie = name + "=" + (value || "") + expires + "; path=/";
    window.location.href = "PresentationPage/Index";
}

function clearCookie(name) {
    document.cookie = name + '=; Max-Age=-99999999;';
    window.location.href = "PresentationPage/Index";
}

function myFunction() {
    var x = document.getElementById("myTopnav");
    if (x.className === "topnav") {
        x.className += " responsive";
    } else {
        x.className = "topnav";
    }
}

function getProduct() {
    var Name = $("#Name").val();
    var Description = $("#Description").val();
    var Price = $("#Price").val();
    var Image = $("#Image").val();
    // poor man's validation

    return { Name: Name, Description: Description, Price: Price, Image: Image };
}


function sendAjaxRequest(product) {
    
    $.ajax({
        type: 'POST',
        url: '/AProducts/Create',
        //dataType: 'json',
        data: JSON.stringify(product),
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            alert("Your product has been saved");
            window.history.go(-1);
        },
        error: function () {
            alert("Your product has been saved");
            window.history.go(-1);
        }
    });
}

$(document).ready(function () {
    $("#create-product-button").click(function () {
        //e.preventDefault();

        var product = getProduct();
        console.log(product);

        if (product.Price === "" || product.Price === null || product.Name === "" || product.Name === null || product.Description === "" || product.Description === null) {
            
            alert("All the fields are required");
        }
        else
        {
            sendAjaxRequest(product);
        }
        
    });

});
