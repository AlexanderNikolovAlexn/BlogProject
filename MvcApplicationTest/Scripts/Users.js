//Ajax
function SendAjax(urlMethod, jsonData) {
    jQuery.support.cors = true;
    $.ajax({
        type: "GET",
        contentType: "application/json; charset=utf-8",
        url: urlMethod,
        dataType: "json",
        success: function (msg) {
            // Do something interesting here.
            if (msg != null) {
                ReturnGetListUsers(msg);
            }
        },
        error: function (xhr, status, error) {
            // Boil the ASP.NET AJAX error down to JSON.
            var err = eval("(" + xhr.responseText + ")");

            // Display the specific error raised by the server
            alert(err.Message);
        }
    });
}

function getUsersJson(url) {
    $.getJSON(url, function (data) {
        ReturnGetListUsers(data);
    });
}

//Stripe the rows
function StripeRows(list) {
    $(list).find('li').removeClass('evenRow');
    $(list).find('li:even').addClass('evenRow');
}

//This fires when the DOM is ready
//So this starts the ball rolling...
$(document).ready(function () {
    GetListUsers();
});

function GetListUsers() {
    //Via Ajax request(Web Services)
    var urlMethod = "api/UserAPI";
    var jsonData = '{}';
    SendAjax(urlMethod, jsonData);

    //Via Json request
    //var urlMethod = "/User/GetAllUsers/";
    //getUsersJson(urlMethod);
}

function ReturnGetListUsers(msg) {
    var listItems = "";

    $.each(msg, function (key, val) {
        listItems += "<li>" +
            "<span class='c1'>" + val.UserName + "</span>" +
            "<span class='c2'>" + val.FirstName + "</span>" +
            "<span class='c2'>" + val.LastName + "</span>" +
            "<span class='c3'>" + val.Email + "</span>" +
            "<span class='c4'>" + val.Status + "</span>" +
            "</li>";
    }
    );

    $("#listUsers").html(listItems);
    StripeRows('#listUsers');
}

