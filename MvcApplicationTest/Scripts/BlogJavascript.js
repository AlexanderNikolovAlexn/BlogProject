/// <reference path="jquery-ui-1.8.20.js" />
function hideButton(id) {
    var insertDiv = "#comments" + id;
    var buttonText = $('div' + insertDiv + ' > a:first-child').text();
    var realText = buttonText.substr(0, buttonText.indexOf('('));
    var commentsCount = buttonText.substr(buttonText.indexOf('('), buttonText.indexOf(')'));
    if (realText == 'Show comments ') {
        $('div' + insertDiv + ' > a:first-child').text('Hide comments ' + commentsCount);
    }
    else {
        var removeDiv = "#commentsInject" + id;
        $('div' + insertDiv + ' > a:first-child').text('Show comments ' + commentsCount);
        $('div' + removeDiv).html('');
    }
}

function clearCommentsForm() {
    $('#commentsForm').reset();
}

function resetForm() {
    $(":input").not(":button, :submit, :reset, :hidden").each(function () {
        this.value = this.defaultValue;
    })
};

//function validateForm() {
//    $("#commentsForm").submit(function (e) {
//        if ($(this).valid()) {
//            $.post('<%= Url.Action("Comment/AddComment")%>', $(this).serialize(), function (data) {
//                $("#dynamicData").html(data);
//                $.validator.unobtrusive.parse($("#dynamicData"));
//            });
//        }
//        e.preventDefault();
//    });
//}

$(document).ready(function () {
    function split(val) {
        return val.split(/;\s*/);
    }

    function appendText(val) {
        $("#listTags").append('<li><span>' + val + '</span></li>');
    }

    $("#postTags").each(function () {
        $(this).keyup(function () {
            var keyInput = this.value;
            if (keyInput.slice(-1) == ";") {
                var postText = $("#postTags").val();
                var postArr = postText.split(/[\s;]+/);
                appendText(postArr[postArr.length - 2]);
                this.value = postText + " ";
            }
        });
        $(this).bind("keydown", function (event) {
            if (event.keyCode === $.ui.keyCode.TAB &&
                    $(this).data("autocomplete").menu.active) {
                event.preventDefault();
            }
        }).autocomplete({
            minLength: 3,
            source: $(this).attr("data-autocomplete"),
            focus: function() {
            //prevent value inserted on focus
                return false;
            },
            select: function (event, ui) {
                var terms = split(this.value);
                // remove the current input
                terms.pop();
                // add the selected item
                terms.push(ui.item.value);
                // add placeholder to get the comma-and-space at the end
                terms.push("");
                this.value = terms.join("; ");
                appendText(ui.item.value);
                return false;
            }
        });
    });
});

//$(document).ready(function () {
//    $("#commentsForm").validate();
//});