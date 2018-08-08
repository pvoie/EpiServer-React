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


    var Price = $("#Price").val();
    var Name = $("#Name").val();
    var Description = $("#Description").val();
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

//Filter for products

function getFilters() {


    var Gender = $("#selectGender").val();
    var Size = $("#selectSize").val();
    
    return { Gender: Gender, Size: Size };
}


function sendAjaxFilters(filters) {

    $.ajax({
        type: 'get',
        url: '/Products/AdvancedSearch',
        //dataType: 'json',
        data: JSON.stringify(filters),
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            console.log("Your product", data);

            
        },
        error: function () {
            console.log("Your product has been saved");
            
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
            if (product.Price < 0) {
                $('#price-error').text('Price must be greater than 0');
            }
            else {
                sendAjaxRequest(product);
            }
           
        }
        
    });

    $("#filtersForm").hide();

    $("#showFilters").click(function () {

        if ($("#filtersForm").is(':visible')) {
            $("#showFilters").html("Filter your results &#9660;");
            $("#filtersForm").hide();
        }
        else {
            $("#showFilters").html("Filter your results &#9650;");
            $("#filtersForm").show();
        }
                
    });


    if ($("#selectCategory").find(":selected").text() == "Men") {
        $("#selectSizeWomen").prop("disabled", true).hide();
        $("#selectSizeKids").prop("disabled", true).hide();
    }
    //else
    //    if ($("#selectCategory").find(":selected").text() == "Women") {
    //        $("#selectSizeMen").prop("disabled", true).hide();
    //        $("#selectSizeKids").prop("disabled", true).hide();
    //    } else
    //        if ($("#selectCategory").find(":selected").text() == "Kids"){
    //            $("#selectSizeMen").prop("disabled", true).hide();
    //            $("#selectSizeWomen").prop("disabled", true).hide();
    //        }


});
