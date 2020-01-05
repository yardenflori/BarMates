﻿var globalBars = [];
var bar = new Object;
var barId;
var barName;
var barAddress;
var barPhotoURL;
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
bar.SmokingFree = [
    {
        id: 'SmokingFree',
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

//save rate
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
function saveRate() {
    var error = allDetailsEntered();
    if (error != "") {
        showError(error);
    }
    else{
        fillRateObject();
        saveRateInDB();
    }
}
function saveRateInDB() {
    rate = JSON.stringify({ 'rate': JSON.stringify(rate) });
    $.ajax({
        type: "POST",
        url: 'BarRating.aspx/SaveRate',
        contentType: "application/json; charset=utf-8",
        data: rate,
        dataType: "json",
        success: function (data) {
            if (data.d == true) {
                showError('השמירה בוצעה בהצלחה');
            }
            else {
                showError('חלה שגיאה');
            }
        },
        error: function (errMsg) {
            showError('חלה שגיאה');
        }
    });
}
function fillRateObject() {
    var userBarChoise = $('#barsAutocomplete').val();
    rate = new Object();
    rate.UserName = '';
    rate.BarId = barId; //eyal should change to the ID of the bar from the google api
    rate.date = null;
    fillRegularRate(bar.Food, 'Food');
    fillRegularRate(bar.Drinks, 'Drinks');
    fillRegularRate(bar.Atmosphere, 'Atmosphere');
    fillRegularRate(bar.Music, 'Music');
    fillRegularRate(bar.Company, 'Company');
    rate.SmokingFree = getSmokingFreeRate();
    fillEnumRate(bar.Price, 'Price');
    fillEnumRate(bar.Service, 'Service');
    fillEnumRate(bar.Age, 'Age');

}
function getSmokingFreeRate() {
    var userRate;
    if ($('#SmokingFree').prop("checked") == false) {
        userRate = 7;
    }
    else {
        userRate = $('input[name="SmokingFreegroup"]:checked').val();
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
        var input = $('<input value="' + (-1+i) + '" name="' + criterion.id+'group" type="radio" />');
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
$('.criterion_information').click(function () {
    if ($('#Beer').prop("disabled") == true) {
        showError('יש לבחור בר');
    }
});
function buildEnumCriterion(criterions, criterionType) {
    rowDiv = $('<div class=\"row\"></div>');
    $('#' + criterionType + ' .criterion_information').append(rowDiv);
    createCheckBox(criterions);
    createEnumCriterions(criterions);
    $('#' + criterions.id ).click(function () {
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
    buildMainCriterion(bar.SmokingFree, 'Smoking');
    buildEnumCriterion(bar.Price, 'price');
    buildEnumCriterion(bar.Service, 'serv');
    buildEnumCriterion(bar.Age, 'age');
    $('.main_content input').prop('disabled', true);
}

//initAutocompleteBar
google.maps.event.addDomListener(window, 'load', initialize);
function initialize() {
    var input = document.getElementById('barsAutocomplete');
    var autocomplete = new google.maps.places.Autocomplete(input, { componentRestrictions: { country: 'il' }, types:['establishment'] });
    autocomplete.addListener('place_changed', function () {
        var place = autocomplete.getPlace();
        if (isBar(place) == true) {
            showBarCriterions();
            barId = place.place_id;
            barName = place.name;
            barAddress = place.formatted_address;
            barPhotoURL = place.photos[0].getUrl({ maxWidth: 500, maxHeight: 500 });
            window.open(barPhotoURL);
            console.log(place);
        }
        else {          
            $('.main_content input').prop('disabled', true);
            $('#savebtn').addClass('disabled');
        }
    });
}
function isBar(place) {  
    if (place.types.includes("bar"))
        return true;
    else
        return false;
}
function showBarCriterions() {
    $('.main_content input').prop('disabled', false);
    $('#savebtn').removeClass('disabled');
}

//init scrollSpy
function initScrollSpy() {
    $('.scrollspy').scrollSpy({ scrollOffset:100});//offset for menu
}
$(document).ready(function () {   
    initScrollSpy();
    initCriterions();
});