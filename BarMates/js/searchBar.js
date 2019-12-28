var barList;
var bar = new Object;
//regular criterions
bar.Food = [
    {
        id: 'Burger',
        name: 'המבורגר'
    },
    {
        id: 'Pizza',
        name: 'פיצה'
    },
    {
        id: 'Sushi',
        name: 'סושי'
    },
    {
        id: 'Snacks',
        name: 'חטיפים'
    },
    {
        id: 'Vegan',
        name: 'צמחוני'
    },
    {
        id: 'Kosher',
        name: 'כשר'
    },
    {
        id: 'Irish',
        name: 'אירי'
    }
]
bar.Drinks = [
    {
        id: 'Beer',
        name: 'בירה'
    },
    {
        id: 'Wine',
        name: 'יין'
    },
    {
        id: 'Cocktail',
        name: 'קוקטייל'
    },
    {
        id: 'BeveragePackages',
        name: 'מסלולי שתיה'
    },
    {
        id: 'Jin',
        name: 'גין'
    },
    {
        id: 'Whiskey',
        name: 'ויסקי'
    },
    {
        id: 'WideRangeOfBeverages',
        name: 'מגון רחב של משקאות'
    }
]
bar.Atmosphere = [
    {
        id: 'Irish',
        name: 'אירי'
    },
    {
        id: 'Chill',
        name: 'רגוע'
    },
    {
        id: 'Party',
        name: 'מסיבה'
    },
    {
        id: 'Dance',
        name: 'ריקודים'
    },
    {
        id: 'Sport',
        name: 'ספורטיבי'
    },
    {
        id: 'Shisha',
        name: 'בר נרגילה'
    }]
bar.Company = [
    {
        id: 'Dating',
        name: 'דייטים'
    },
    {
        id: 'Friends',
        name: 'חבר׳ה'
    },
    {
        id: 'KidsFriendly',
        name: 'מתאים לילדים'
    },
    {
        id: 'PetsFriendly',
        name: 'מתאים לבע״ח'
    },
    {
        id: 'Colleagues',
        name: 'קולגות'
    }]
bar.Music = [
    {
        id: 'Pop',
        name: 'פופ'
    },
    {
        id: 'Jazz',
        name: 'ג\'אז'
    },
    {
        id: 'Mizrahit',
        name: 'מזרחית'
    },
    {
        id: 'Greek',
        name: 'יוונית'
    },
    {
        id: 'Trance',
        name: 'טראנס'
    },
    {
        id: 'Mainstream',
        name: 'מיינסטרים'
    },
    {
        id: 'Israeli',
        name: 'ישראלית'
    },
    {
        id: 'LiveMusic',
        name: 'הופעות חיות'
    },
    {
        id: 'Reggaeton',
        name: 'רגאטון'
    },
    {
        id: 'OpenMic',
        name: 'קריוקי'
    }
    ,
    {
        id: 'StandUp',
        name: 'סטנד-אפ'
    }
]
var RegulaeCriterionsArr = [bar.Drinks, bar.Food, bar.Atmosphere, bar.Company, bar.Music];
var options = ['לא אהבתי', 'לא אכפת לי', 'אהבתי'];
bar.Smoking = [
    {
        id: 'Smoking',
        name: 'עישון'
    }
];

//enums criterions
bar.Price = new Object();
bar.Price.id = 'Price';
bar.Price.name = 'מחיר';
bar.Price.options = [
    {
        id: 0,
        name: 'זול'
    },
    {
        id: 1,
        name: 'סביר'
    },
    {
        id: 2,
        name: 'יקר'
    }
];
bar.Service = new Object();
bar.Service.id = 'Service';
bar.Service.name = 'שירות';
bar.Service.options = [
    {
        id: 0,
        name: 'שירות עצמי'
    },
    {
        id: 1,
        name: 'שירות מלא'
    }
];
bar.Age = new Object();
bar.Age.id = 'Age';
bar.Age.name = 'גיל';
bar.Age.options = [
    {
        id: 0,
        name: '18+'
    },
    {
        id: 1,
        name: '21+'
    },
    {
        id: 2,
        name: '24+'
    }
];
var EnumCriterionsArr = [bar.Price, bar.Service, bar.Age];
function goToProfileBar(barId) {
    
}
//show results
function showResults() {
    $('#searchDiv').css('display', 'none');
    $('#results').css('display', 'block');
    for (var i = 0; i < barList.length; i++) {
        buildCarouselItem(barList[i].Key, barList[i].Value);
    }
    $('.carousel').carousel();
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
function showSearch() {
    $('#searchDiv').css('display', 'block');
    $('#results').css('display', 'none');
}
//searchBar
function allDetailsEntered() {
    var error = EnteredRegulaeCriterions();
    if (error == '') {
        error = EnteredEnumCriterions();
    }
    return error;
}
function EnteredRegulaeCriterions() {
    var error = '';
    for (var j = 0; j < RegulaeCriterionsArr.length; j++) {
        var regulaeCriterion = RegulaeCriterionsArr[j];
        for (var i = 0; i < regulaeCriterion.length; i++) {
            var subCriterion = regulaeCriterion[i];
            if ($('#' + subCriterion.id).prop("checked") == true) {
                var userRate = $('input[name="' + subCriterion.id + 'group"]:checked').val();
                if ((-1 <= userRate && userRate <= 1) == false) {
                    error = 'יש לבחור ' + subCriterion.name;
                }
            }
        }
    }

    return error;
}
function EnteredEnumCriterions() {
    var error = '';
    for (var j = 0; j < EnumCriterionsArr.length; j++) {
        var enumCriterion = EnumCriterionsArr[j];
        if ($('#' + enumCriterion.id).prop("checked") == true) {
            var userRate = $('input[name="' + enumCriterion.id + 'group"]:checked').val();
            if ((-1 <= userRate && userRate <= 1) == false) {
                error = 'יש לבחור ' + enumCriterion.name;
            }
        }
    }
    return error;
}
function searchBar() {
    var error = allDetailsEntered();
    if (error != "") {
        showError(error);
    }
    else {
        fillRateObject();
        searchBarInDB();
    }
}
function searchBarInDB() {
    rate = JSON.stringify({ 'rate': JSON.stringify(rate) });
    $.ajax({
        type: "POST",
        url: 'SearchBar.aspx/SearchBars',
        contentType: "application/json; charset=utf-8",
        data: rate,
        dataType: "json",
        success: function (data) {
            barList = JSON.parse(data.d);
            if (barList.length > 0) {
                showResults();
            }
            else {
                showError('לא נמצאו תוצאות');
            }
        },
        error: function (errMsg) {
            showError('חלה שגיאה');
        }
    });
}
function fillRateObject() {
    rate = new Object();
    rate.UserName = '';
    rate.BarId = 0;
    rate.date = null;
    fillRegularRate(bar.Food, 'Food');
    fillRegularRate(bar.Drinks, 'Drinks');
    fillRegularRate(bar.Atmosphere, 'Atmosphere');
    fillRegularRate(bar.Music, 'Music');
    fillRegularRate(bar.Company, 'Company');
    rate.SmokingFree = getSmokingRate();
    fillEnumRate(bar.Price, 'Price');
    fillEnumRate(bar.Service, 'Service');
    fillEnumRate(bar.Age, 'Age');

}
function getSmokingRate() {
    var userRate;
    if ($('#Smoking').prop("checked") == false) {
        userRate = 7;
    }
    else {
        userRate = $('input[name="Smokinggroup"]:checked').val();
        if ((-1 <= userRate && userRate <= 1) == false) {
            userRate = 0;
        }
    }
    return userRate;
}
function fillRegularRate(criterions, criterionType) {
    rate[criterionType] = new Object();

    for (var i = 0; i < criterions.length; i++) {
        var userRate;
        if ($('#' + criterions[i].id).prop("checked") == false) {
            userRate = 7;
        }
        else {
            userRate = $('input[name="' + criterions[i].id + 'group"]:checked').val();
            if ((-1 <= userRate && userRate <= 1) == false) {
                userRate = 0;
            }
        }
        rate[criterionType][criterions[i].id] = parseInt(userRate);
    }
}
function fillEnumRate(enumCriterion, criterionType) {
    rate[criterionType];
    var userRate;
    if ($('#' + criterionType).prop("checked") == false) {
        userRate = 7;
    }
    else {
        userRate = $('input[name="' + criterionType + 'group"]:checked').val();
    }
    rate[criterionType] = userRate;
}
//build criterions
function createCheckBox(criterion) {
    var colDiv = $('<div class="col s3"></div>');
    var p = $('<p></p>');
    var lable = $('<label></label>');
    var input = $('<input id="' + criterion.id + '" type="checkbox" />')
    var span = $('<span></span>').text(criterion.name);

    colDiv.append(p);
    p.append(lable);
    lable.append(input);
    lable.append(span);

    rowDiv.append(colDiv);
}
function createEnumCriterions(criterion) {
    var div1 = $('<div id="' + criterion.id + '_options" class="col s9 options"></div>');
    var optionWidth = 12 / criterion.options.length;
    for (var i = 0; i < criterion.options.length; i++) {
        var div2 = $('<div class="col s' + optionWidth + '"></div>');
        var p = $('<p></p>');
        var lable = $('<label></label>');
        var input = $('<input value="' + criterion.options[i].id + '" name="' + criterion.id + 'group" type="radio" />');
        var span = $('<span></span>').text(criterion.options[i].name);
        div1.append(div2);
        div2.append(p);
        p.append(lable);
        lable.append(input);
        lable.append(span);
    }

    rowDiv.append(div1);
}
function createCriterions(criterion) {
    var div1 = $('<div id="' + criterion.id + '_options" class="col s9 options"></div>');
    var optionWidth = 12 / options.length;
    for (var i = 0; i < options.length; i++) {
        var div2 = $('<div class="col s' + optionWidth + '"></div>');
        var p = $('<p></p>');
        var lable = $('<label></label>');
        var input = $('<input value="' + (-1 + i) + '" name="' + criterion.id + 'group" type="radio" />');
        var span = $('<span></span>').text(options[i]);
        div1.append(div2);
        div2.append(p);
        p.append(lable);
        lable.append(input);
        lable.append(span);
    }

    rowDiv.append(div1);
}
function showRadioButtonOptions(id) {
    if ($('#' + id).prop("checked") == true) {
        $('#' + id + '_options').css('display', 'block');//showOptions
    }
    else if ($('#' + id).prop("checked") == false) {
        $('#' + id + '_options').css('display', 'none');//hideOptions
    }
}
function buildMainCriterion(criterions, criterionType) {
    for (var i = 0; i < criterions.length; i++) {
        rowDiv = $('<div class=\"row\"></div>');
        $('#' + criterionType + ' .criterion_information').append(rowDiv);
        createCheckBox(criterions[i]);
        createCriterions(criterions[i]);
        $('#' + criterions[i].id).click(function () {
            var id = $(this).attr('id');
            showRadioButtonOptions(id);
        });
    }
}
function buildEnumCriterion(criterions, criterionType) {
    rowDiv = $('<div class=\"row\"></div>');
    $('#' + criterionType + ' .criterion_information').append(rowDiv);
    createCheckBox(criterions);
    createEnumCriterions(criterions);
    $('#' + criterions.id).click(function () {
        var id = $(this).attr('id');
        showRadioButtonOptions(id);
    });

}
function initCriterions() {
    buildMainCriterion(bar.Drinks, 'drinks');
    buildMainCriterion(bar.Food, 'food');
    buildMainCriterion(bar.Atmosphere, 'envi');
    buildMainCriterion(bar.Company, 'comp');
    buildMainCriterion(bar.Music, 'music');
    buildMainCriterion(bar.Smoking, 'smoking');
    buildEnumCriterion(bar.Price, 'price');
    buildEnumCriterion(bar.Service, 'serv');
    buildEnumCriterion(bar.Age, 'age');
}
//init scrollSpy
function initScrollSpy() {
    $('.scrollspy').scrollSpy({ scrollOffset: 100 });//offset for menu
}
$(document).ready(function () {
    initScrollSpy();
    initCriterions();
});