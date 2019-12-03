function onkeydown_register(event) {
    event = event || window.event;
    if (event.keyCode == 13) {
        registerClick();
    }
}
function registerClick() {
    var error = register_allDetailsEntered();
    if (error != "") {
        showError(error);
    }
    else {
        ajaxRegister();
    }
}
function register_allDetailsEntered() {
    var error = "";
    var username = document.getElementById('username').value;
    var password = document.getElementById('password').value;
    var age = $('#age').val();

    if (username == "" || password == "" || age == null){
        error = "יש להזין את כל הפרטים";
    }
    return error;
}
function showError(error) {
    M.toast({ html: error, classes: 'error_toast' });
}

function ajaxRegister() {
    var userJson = new Object();
    userJson.userName = document.getElementById('username').value;
    userJson.password = document.getElementById('password').value;
    userJson.age = ($('select#age').val());
    userJson = JSON.stringify(userJson);
    var user = JSON.stringify({ 'userDetailsString': userJson });
    $.ajax({
        type: "POST",
        url: 'NewUser.aspx/Register',
        contentType: "application/json; charset=utf-8",
        data: user,
        dataType: "json",
        success: function (data) {
            clearInputs();
            if (data.d == 'Homepage') {
                window.location.href = 'Homepage.aspx';
            }
            else if (data.d == 'usernameAlreadyExists'){
                clearInputs();
                showError("אנא בחר שם משתמש אחר");
            }
            else if (data.d == 'iLlegal') {
                clearInputs();
                showError("שם המשתמש או הסיסמה לא תקינים");
            }
            else  {
                clearInputs();
                showError('חלה שגיאה');
            }
        },
        error: function (errMsg) {
            showError('חלה שגיאה');
            clearInputs();
        }
    });
}

function redirectAfterRegister(redirectTo) {
    if (redirectTo == 'Homepage') {
        clearInputs();
        window.location.href = "Homepage.aspx";
    }
    else if (redirectTo == 'usernameAlreadyExists') {
        clearInputs();
        showError("אנא בחר שם משתמש אחר");
    }
}
function clearInputs() {
    //clean inputs
    $('#general_form').find('input').each(function () {
        $(this).val('');
    });
    $('#age').val(0);

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

function initAgeSelect() {
        var selectField = document.getElementById("age");
    selectField.options.length = 0;
    selectField.options[selectField.length] = new Option("לחץ לבחירה", "0");
    selectField.options[0].disabled = true;
    for (var i = 12; i <= 99; i++) {
        $('#age').val(i);
        selectField.options[selectField.length] = new Option(i, i);
    }
    $("#age").val(0).formSelect();

}
$(document).ready(function () {
    initAgeSelect();
});