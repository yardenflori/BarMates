function goToProfileBar(barId) {
  
}
function buildCarouselItem(barId, barName) {
    var divCarouselItem = $('<div class=\"carousel-item card\"></div>');
    var divCarouselImg = $('<div class=\"card-image\"></div>');
    var img = $('<img src="images/bar1.jpg" />');
    var span = $('<span class="card-title"></span>').text(barName);
    var divCardAction = $('<div class=\"card-action\"></div>');
    var a = $("<a onclick=\"goToProfileBar('" + barId + "')\">מידע נוסף></a>");
    divCarouselItem.append(divCarouselImg);
    divCarouselItem.append(divCardAction);
    divCarouselImg.append(img);
    divCarouselImg.append(span);
    divCardAction.append(a);
    $('#carousel').append(divCarouselItem);
}
function initCarousel() {
    $.ajax({
        type: "POST",
        url: 'Homepage.aspx/GetUserBars',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var barsFromDb = JSON.parse(data.d);
            globalBars = barsFromDb;
            for (var i = 0; i < globalBars.length; i++) {
                buildCarouselItem(globalBars[i].Key, globalBars[i].Value);
            }
            $('.carousel').carousel();
        },
        error: function (errMsg) {
            showError('חלה שגיאה');
        }
    });

    
}
$(document).ready(function () {
    initCarousel();
    
});