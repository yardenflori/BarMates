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
    var formData = new FormData()
    getLoginDetails(formData);

    $.ajax({
        url: 'Default.aspx',
        type: 'POST',
        data: formData,
        cache: false,
        contentType: false,
        processData: false,
        success: function (res) {
            if (res.loginredirectTo != "") {
                redirectAfterLogin(res.loginredirectTo)
            }
            else {
                showError('חלה שגיאה');
            }

        },
    });
}

function getLoginDetails(formData) {
    formData.append('username', document.getElementById('username').value);
    formData.append('password', document.getElementById('password').value);
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