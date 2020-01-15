//loader
var default_loader_text = "עוד רגע.. טוען נתונים";
function showLoader(loader_text) {
    $('.loader_text').text(loader_text);
    $('#screen_loader').removeClass('hide');

}
function hideLoader() {
    $('#screen_loader').addClass('hide');
}


function onkeydown_login(event) {
    event = event || window.event;
    if (event.keyCode == 13) {
        loginClick();
    }
}

function loginClick() {
    var error = login_allDetailsEntered();
    if (error != "") {
        showError(error);
    }
    else {
        ajaxLogin();
    }
}

function login_allDetailsEntered() {
    var error = "";
    var username = document.getElementById('username').value;
    var password = document.getElementById('password').value;

    if (username == "" || password == "" || username.length < 5 || password.length < 5) {
        error = "יש להזין את כל הפרטים";
    }
    return error;

}

function showError(error) {
    M.toast({ html: error, classes: 'error_toast' });
}

function ajaxLogin() {
    showLoader('עוד רגע... מתחבר');
    var userJson = new Object();
    userJson.userName = document.getElementById('username').value;
    userJson.password = document.getElementById('password').value;
    userJson = JSON.stringify(userJson);
    var user = JSON.stringify({ 'userDetailsString': userJson });
    $.ajax({
        type: "POST",
        url: 'Default.aspx/Login',
        contentType: "application/json; charset=utf-8",
        data: user,
        dataType: "json",
        success: function (data) {
            clearInputs();
            if (data.d == false) {
                hideLoader();
                showError('אחד הנתונים שהוזן שגוי');
            }
            else {
                window.location.href = 'Homepage.aspx';
            }
        },
        error: function (errMsg) {
            hideLoader();
            showError('חלה שגיאה');
            clearInputs();
        }
    });
}


function clearInputs() {
    //clean inputs
    $('#general_form').find('input').each(function () {
        $(this).val('');
    });
}

//On hide password button click
$('#hidePassword').click(function () {
    $(this).addClass("hide-icon");
    $('#showPassword').removeClass("hide-icon");
    $('#password').attr("type", "password")
});
//On show password button click
$('#showPassword').click(function () {
    $(this).addClass("hide-icon");
    $('#hidePassword').removeClass("hide-icon");
    $('#password').attr("type", "text")
});