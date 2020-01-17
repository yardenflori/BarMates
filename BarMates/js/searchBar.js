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
        name: 'נשנושים'
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
        name: 'נקי מעישון'
    }
];

//enums criterions
bar.Price = new Object();
bar.Price.id = 'Price';
bar.Price.name = 'מחיר';
bar.Price.options = [
    {
        id: 0,
        name: '$'
    },
    {
        id: 1,
        name: '$$'
    },
    {
        id: 2,
        name: '$$$'
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

//enums results criterions
bar.resultsPrice = new Object();
bar.resultsPrice.id = 'Price';
bar.resultsPrice.name = 'מחיר';
bar.resultsPrice.options = [
    {
        id: 'Price0',
        name: 'זול'
    },
    {
        id: 'Price1',
        name: 'סביר'
    },
    {
        id: 'Price2',
        name: 'יקר'
    }
];
bar.resultsService = new Object();
bar.resultsService.id = 'Service';
bar.resultsService.name = 'שירות';
bar.resultsService.options = [
    {
        id: 'Service0',
        name: 'שירות עצמי'
    },
    {
        id: 'Service1',
        name: 'שירות מלא'
    }
];
bar.resultsAge = new Object();
bar.resultsAge.id = 'Age';
bar.resultsAge.name = 'גיל';
bar.resultsAge.options = [
    {
        id: 'Age0',
        name: '18+'
    },
    {
        id: 'Age1',
        name: '21+'
    },
    {
        id: 'Age2',
        name: '24+'
    }
];


var EnumCriterionsArr = [bar.Price, bar.Service, bar.Age];

//------------------results
function showResults() {
    $('#searchDiv').css('display', 'none');
    $('#results').css('display', 'block');
    for (var i = 0; i < barList.length; i++) {
        buildCarouselItem(barList[i].BarId, barList[i].BarName, barList[i].PhotoUrl);
    }
    $('.carousel').carousel({
        onCycleTo: function (el) {
            var barId = $(el).attr('id');
            fillProfileBar(barId);
        }
    });
}
function buildCarouselItem(barId, barName, barPhoto) {
    var divCarouselItem = $('<div id="' + barId + '"class=\"carousel-item card\"></div>');
    var divCarouselImg = $('<div class=\"card-image\"></div>');
    var img = $('<img src=' + barPhoto + '> ');
    var span = $('<span class="card-title"></span>').text(barName);
    divCarouselItem.append(divCarouselImg);
    divCarouselImg.append(img);
    divCarouselImg.append(span);
    $('#carousel').append(divCarouselItem);
}
function showSearch() {
    $('#searchDiv').css('display', 'block');
    $('#results').css('display', 'none');
}
function fillMainCriterion(criterions, criterionProperty, mainCriterionId) {
    var countTrue = 0;
    for (var i = 0; i < criterions.length; i++) {
        if (criterionProperty[criterions[i].id] != undefined && criterionProperty[criterions[i].id] == true) {
            countTrue++;
            $('#Results' + criterions[i].id).attr("checked", true);
            $('#Results' + criterions[i].id + '_div').css('display', 'block');

        }
        else {
            $('#Results' + criterions[i].id + '_div').css('display', 'none');
        }
    }
    if (countTrue == 0) {
        $('#' + mainCriterionId).css('display', 'none');
    }
    else {
        $('#' + mainCriterionId).css('display', 'block');
    }
}
function fillSmokingCriterion(smokingFreeValue) {
    if (smokingFreeValue == true) {
        $('#results_Smoking').css('display', 'block');
        $('#ResultsSmokingFree').attr("checked", true);
        $('#ResultsSmokingFree_div').css('display', 'block');
    }
    else {
        $('#results_Smoking').css('display', 'none');
    }
}
function fillEnumCriterion(options, barValue, mainCriterionId, barPropertyName) {
    var informationExsist = false;
    for (var i = 0; i < options.length; i++) {
        if (options[i].id == barPropertyName +barValue) {
            informationExsist = true;
            $('#Results' + options[i].id).attr("checked", true);
            $('#Results' + options[i].id + '_div').css('display', 'block');
        }
        else {
            $('#Results' + options[i].id + '_div').css('display', 'none');
        }
    }
    if (informationExsist == false) {
        $('#' + mainCriterionId).css('display', 'none');
    }
    else {
        $('#' + mainCriterionId).css('display', 'block');
    }
}
function fillProfileBar(barId) {
    for (var i = 0; i < barList.length; i++) {
        if (barList[i].BarId == barId) {
            $('#results_address .criterion_information').text(barList[i].Address);
            fillMainCriterion(bar.Food, barList[i].Food, 'results_food');
            fillMainCriterion(bar.Drinks, barList[i].Drinks, 'results_drinks');
            fillMainCriterion(bar.Atmosphere, barList[i].Atmosphere, 'results_envi');
            fillMainCriterion(bar.Company, barList[i].Company, 'results_comp');
            fillMainCriterion(bar.Music, barList[i].Music, 'results_music');
            fillSmokingCriterion(barList[i].SmokingFree);
            fillEnumCriterion(bar.resultsPrice.options, barList[i].Price, 'results_price', 'Price');
            fillEnumCriterion(bar.resultsAge.options, barList[i].Age, 'results_age', 'Age');
            fillEnumCriterion(bar.resultsService.options, barList[i].Service, 'results_serv', 'Service');

        }
    }
    $('#profile_bar input[type="checkbox"]').attr('disabled', true);
}
//build search criterions
function createResultsCheckBox(criterion) {
    var colDiv = $('<div id="Results' + criterion.id + '_div' + '"class="col s3"></div>');
    var p = $('<p></p>');
    var lable = $('<label></label>');
    var input = $('<input id="Results' + criterion.id + '" type="checkbox" />')
    var span = $('<span></span>').text(criterion.name);

    colDiv.append(p);
    p.append(lable);
    lable.append(input);
    lable.append(span);

    rowDiv.append(colDiv);
}
function buildResultsMainCriterion(criterions, criterionType) {
    rowDiv = $('<div class=\"row\"></div>');
    $('#' + criterionType + ' .criterion_information').append(rowDiv);
    for (var i = 0; i < criterions.length; i++) {
        createResultsCheckBox(criterions[i]);
    }
}
function initResultsBarCriterions() {
    buildResultsMainCriterion(bar.Drinks, 'results_drinks');
    buildResultsMainCriterion(bar.Food, 'results_food');
    buildResultsMainCriterion(bar.Atmosphere, 'results_envi');
    buildResultsMainCriterion(bar.Company, 'results_comp');
    buildResultsMainCriterion(bar.Music, 'results_music');
    buildResultsMainCriterion(bar.SmokingFree, 'results_Smoking');
    buildResultsMainCriterion(bar.resultsPrice.options, 'results_price');
    buildResultsMainCriterion(bar.resultsService.options, 'results_serv');
    buildResultsMainCriterion(bar.resultsAge.options, 'results_age');
}
//-----------------searchBar
function searchBar() {
    choises = [];//save only true choises
    fillChoises();
    searchBarInDB();
}
function searchBarInDB() {
    showLoader(default_loader_text);
    choises = JSON.stringify({ 'choises': JSON.stringify(choises) });
    $.ajax({
        type: "POST",
        url: 'SearchBar.aspx/SearchBars',
        contentType: "application/json; charset=utf-8",
        data: choises,
        dataType: "json",
        success: function (data) {
            hideLoader();
            barList = JSON.parse(data.d);
            if (barList.length > 0) {
                $('#carousel').empty();//clear carousel
                showResults();
            }
            else {
                showError('לא נמצאו תוצאות');
            }
        },
        error: function (errMsg) {
            hideLoader();
            showError('חלה שגיאה');
        }
    });
}
function fillChoises() {
    //fill Regular Choises
    $('#searchDiv input[type="checkbox"]').each(function () {
        criterion_id = $(this).attr('id');
        criterion_value = $('#' + criterion_id).prop("checked");
        if (criterion_value == true) {
            choises.push({ 'Key': criterion_id, 'Value': 1 });
        }
        else {
            choises.push({ 'Key': criterion_id, 'Value': 0 });
        }
    });
    //fill Enum Choises
    var EnumsType = ['Price', 'Service', 'Age'];
    for (var i = 0; i < EnumsType.length; i++) {
        radioBtnValue = $('input[name="' + EnumsType[i] + 'group"]:checked').val()
        if (radioBtnValue != undefined) {
            choises.push({ 'Key': EnumsType[i], 'Value': radioBtnValue });
        }
        else {
            choises.push({ 'Key': EnumsType[i], 'Value': 7 });
        }
    }


}
//build search criterions
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
function createRadioBtn(criterion) {
    for (var i = 0; i < criterion.options.length; i++) {
        var colDiv = $('<div class="col s3"></div>');
        var p = $('<p></p>');
        var lable = $('<label></label>');
        var input = $('<input value="' + criterion.options[i].id + '" name="' + criterion.id + 'group" type="radio" />');
        var span = $('<span></span>').text(criterion.options[i].name);
        colDiv.append(p);
        p.append(lable);
        lable.append(input);
        lable.append(span);
        rowDiv.append(colDiv);

    }

}
function buildMainCriterion(criterions, criterionType) {
    rowDiv = $('<div class=\"row\"></div>');
    $('#' + criterionType + ' .criterion_information').append(rowDiv);
    for (var i = 0; i < criterions.length; i++) {        
        createCheckBox(criterions[i]);       
    }
}
function buildEnumCriterion(criterions, criterionType) {
    rowDiv = $('<div class=\"row\"></div>');
    $('#' + criterionType + ' .criterion_information').append(rowDiv);
    createRadioBtn(criterions);
}
function initSearchCriterions() {
    buildMainCriterion(bar.Drinks, 'drinks');
    buildMainCriterion(bar.Food, 'food');
    buildMainCriterion(bar.Atmosphere, 'envi');
    buildMainCriterion(bar.Company, 'comp');
    buildMainCriterion(bar.Music, 'music');
    buildMainCriterion(bar.SmokingFree, 'Smoking');
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
    initSearchCriterions();
    initResultsBarCriterions();
});