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
    // poor man's validation

    return { Name: Name, Description: Description, Price: Price };
}


function sendAjaxRequest(product) {
    
    $.ajax({
        type: 'POST',
        url: '/Products/Create',
        //dataType: 'json',
        data: JSON.stringify(product),
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            alert("Your product has been saved");
            window.history.go(-1);
        },
        error: function () {
            alert("Something went wrong");
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
