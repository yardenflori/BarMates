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
                showError('אחד הנתונים שהוזן שגוי');
            }
            else {
                window.location.href = 'Homepage.aspx';
            }
        },
        error: function (errMsg) {
            showError('חלה שגיאה');
            clearInputs();
        }
    });
}




function redirectAfterLogin(redirectTo) {
    if (redirectTo == 'Homepage') {
        clearInputs();
        window.location.href = "Homepage.aspx";
    }
    
    else if (redirectTo == 'incorrectDetails') {
        clearInputs();
        showError("שם משתמש או סיסמה שגויים. נותרו " + loginAttemtLeft + " נסיונות התחברות.");
    }
}


function clearInputs() {
    //clean inputs
    $('#general_form').find('input').each(function () {
        $(this).val('');
    });
}