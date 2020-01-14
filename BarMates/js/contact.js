//contect from
function clearContactDetails() {
    $('#contact_us_section').find('input').each(function () {
        $(this).val('');
    });
    $('#client_content').val('');
}
function getContactDetails() {
    var contactDetails = new Object();
    contactDetails.subject = document.getElementById('subject').value;
    contactDetails.client_name = document.getElementById('client_name').value;
    contactDetails.email = document.getElementById('email').value;
    contactDetails.phone = document.getElementById('phone').value;
    contactDetails.client_content = document.getElementById('client_content').value;
    return contactDetails;
}
function sendContactForm() {
    var error = getErrorMessage();
    if (error != "") {
        M.toast({ html: error, classes: 'error_toast' });
    }
    else {
        var contactDetails = getContactDetails();
        sendMessage(contactDetails);
    }
}
function isPhoneValid() {
    var phoneNumber = document.getElementById('phone').value;
    var phoneRGEX = /^((\+|00)?972\-?|0)(([23489]|[57]\d)\-?\d{7})$/;
    var phoneResult = phoneRGEX.test(phoneNumber);
    return phoneResult;
}
function isMailValid() {
    return $("#email").hasClass("valid");
}
function getErrorMessage() {
    var errorMessage = "";

    if (document.getElementById('subject').value == "" ||
        document.getElementById('client_name').value == "" ||
        document.getElementById('email').value == "" ||
        document.getElementById('phone').value == "" ||
        document.getElementById('client_content').value == "") {
        errorMessage = "יש להזין את כל הפרטים.";
    }
    else if (isPhoneValid() == false) {
        errorMessage = "יש להזין מספר טלפון תקין.";
    }
    else if (isMailValid() == false) {
        errorMessage = "יש להזין כתובת דואר אלקטרוני תקינה.";
    }
    return errorMessage;
}
function sendMessage(contactDetails) {
    showLoader('עוד רגע...');
    var messageJSON = JSON.stringify(contactDetails);

    var message = JSON.stringify({ 'message': messageJSON });
    $.ajax({
        type: "POST",
        url: 'Contact.aspx/SendContactMessage',
        contentType: "application/json; charset=utf-8",
        data: message,
        dataType: "json",
        success: function (data) {
            hideLoader();
            if (data.d == true) {
                M.toast({ html: "הפניה נשלחה בהצלחה", classes: 'confirm_toast' });
                clearContactDetails();
            }
            else {
                M.toast({ html: 'חלה שגיאה', classes: 'error_toast' });
            }
        },
        error: function (errMsg) {
            hideLoader();
            M.toast({ html: 'חלה שגיאה', classes: 'error_toast' });
        }
    });
}
