//loader
var default_loader_text = "עוד רגע.. טוען נתונים";
function showLoader(loader_text) {
    $('.loader_text').text(loader_text);
    $('#screen_loader').removeClass('hide');

}
function hideLoader() {
    $('#screen_loader').addClass('hide');
}

function logout() {
    $.ajax({
        type: "POST",
        url: 'Default.aspx/Logout',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function () {
            window.location.href = 'Default.aspx';
        },
        error: function () {
            window.location.href = 'Default.aspx';
        }
    });
}
/* Toggle between adding and removing the "responsive" class to topnav when the user clicks on the icon */
function ToggleNav() {
    var x = document.getElementById("myTopnav");
    if (x.className === "topnav") {
        x.className += " active";

    } else {
        x.className = "topnav";
    }
}
function showError(error) {
    M.toast({ html: error, classes: 'error_toast' });
}
function showConfirm(text) {
    M.toast({ html: text, classes: 'confirm_toast' });
}
