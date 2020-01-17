function initTable() {
    showLoader('רק רגע...טוען נתונים')
    $.ajax({
        type: "POST",
        url: 'leaderboard.aspx/GetBestScoredUsers',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var leaders = JSON.parse(data.d);
            if (leaders != null && leaders.length > 0) {
                for (var i = 0; i < leaders.length; i++) {
                    var tr = $('<tr></tr>');
                    var td1 = $('<td></td>').text(i + 1);
                    var td2 = $('<td></td>').text(leaders[i].Key);
                    var td3 = $('<td></td>').text(leaders[i].Value);
                    $('#tbody').append(tr);
                    tr.append(td1);
                    tr.append(td2);
                    tr.append(td3);


                }
            }
            hideLoader();
        },
        error: function (errMsg) {
            showError('חלה שגיאה');
        }
    });
}
$(document).ready(function () {
    initTable();

});