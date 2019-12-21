var globalBars = [];
var bar = new Object;
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
bar.Service = [
    {
        id: 'SelfService',
        name: 'שירות עצמי'
    },
    {
        id: 'FullService',
        name: 'שירות מלא'
    }
];
bar.Age = [
    {
        id: 'EighteenPlus',
        name: '18+'
    },
    {
        id: 'TwentyOnePlus',
        name: '21+'
    },
    {
        id: 'TwentyFourPlus',
        name: '24+'
    }
];
bar.Atmosphere = [
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
bar.Price = [
    {
        id: 'PriceLow',
        name: 'זול'
    },
    {
        id: 'PriceMed',
        name: 'סביר'
    },
    {
        id: 'PriceHigh',
        name: 'יקר'
    }
];
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
bar.Smoking = [
    {
        id: 'Smoking',
        name: 'עישון'
    }
];
var options = ['אהבתי', 'לא אהבתי', 'לא אכפת לי'];
//save rate
function saveRate() {
    var barToSave = new Object();
    //    var d = $('input[name="group1"]:checked').val();
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
function createCriterions(criterion) {
    var div1 = $('<div id="' + criterion.id + '_options" class="col s9 options"></div>');
    var optionWidth = 12 / options.length;
    for (var i = 0; i < options.length; i++) {
        var div2 = $('<div class="col s' + optionWidth + '"></div>');
        var p = $('<p></p>');
        var lable = $('<label></label>');
        var input = $('<input value="' + i + '" name="' + criterion.id+'group" type="radio" />');
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
function initCriterions() {
    buildMainCriterion(bar.Drinks, 'drinks');
    buildMainCriterion(bar.Food, 'food');
    buildMainCriterion(bar.Service, 'serv');
    buildMainCriterion(bar.Age, 'age');
    buildMainCriterion(bar.Atmosphere, 'envi');
    buildMainCriterion(bar.Company, 'comp');
    buildMainCriterion(bar.Price, 'price');
    buildMainCriterion(bar.Music, 'music');
    buildMainCriterion(bar.Smoking, 'smoking');

    $('.main_content input').prop('disabled', true);
}
//init bar list
function initAutocompleteBar() {
    $.ajax({
        type: "POST",
        url: 'BarRating.aspx/GetBars',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var barsFromDb = JSON.parse(data.d);
            globalBars = barsFromDb;
            var BarsToAutocomplete = [];
            for (var i = 0; i < barsFromDb.length; i++) {
                BarsToAutocomplete[barsFromDb[i]] = null;//BarsToAutocomplete["סעידה בפארק"] = null;
            }
            $('#barsAutocomplete').autocomplete({
                data: BarsToAutocomplete,
                onAutocomplete: showBarCriterions,
            });
        },
        error: function (errMsg) {
            showError('חלה שגיאה');
        }
    });
    
}
function checkIfChoseBar() {
    var barName = $('#barsAutocomplete').val();
    if ($.inArray(barName, globalBars) > -1) {
        $('.main_content input').prop('disabled', false);
        $('#savebtn').removeClass('disabled');


    }
    else {
        $('.main_content input').prop('disabled', true);
        $('#savebtn').addClass('disabled');

    }
}
function showBarCriterions() {
    //when user chose bar
    var barName = $('#barsAutocomplete').val();
    if ($.inArray(barName, globalBars) > -1) {
        $('.main_content input').prop('disabled', false);
        $('#savebtn').removeClass('disabled');
    }
}
//init scrollSpy
function initScrollSpy() {
    $('.scrollspy').scrollSpy({ scrollOffset:100});//offset for menu
}
$(document).ready(function () {
    initAutocompleteBar();
    initScrollSpy();
    initCriterions();
});