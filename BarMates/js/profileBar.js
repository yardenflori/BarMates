function loadBar(barName) {
    var barName = JSON.stringify({ barName });
    $.ajax({
        type: "POST",
        url: 'ProfileBar.aspx/GetBar',
        contentType: "application/json; charset=utf-8",
        data:barName,
        dataType: "json",
        success: function (data) {
            var bar = JSON.parse(data.d);
          
        },
        error: function (errMsg) {
            showError('חלה שגיאה');
        }
    });

}

$(document).ready(function () {
    loadBar('סעידה בפארק');
});