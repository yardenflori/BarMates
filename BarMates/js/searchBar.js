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
function searchBar() {
    choises = [];//save only true choises
    fillChoises();
    searchBarInDB();
}
function searchBarInDB() {
    choises = JSON.stringify({ 'choises': JSON.stringify(choises) });
    $.ajax({
        type: "POST",
        url: 'SearchBar.aspx/SearchBars',
        contentType: "application/json; charset=utf-8",
        data: choises,
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
function fillChoises() {
    //fill Regular Choises
    $('input[type="checkbox"]').each(function () {
        criterion_id = $(this).attr('id');
        criterion_value = $('#' + criterion_id).prop("checked");
        if (criterion_value == true) {
            choises.push({ 'Key': criterion_id, 'Value': 1 });
        }
    });
    //fill Enum Choises
    var EnumsType = ['Price', 'Service', 'Age'];
    for (var i = 0; i < EnumsType.length; i++) {
        radioBtnValue = $('input[name="' + EnumsType[i] + 'group"]:checked').val()
        if (radioBtnValue != undefined) {
            choises.push({ 'Key': EnumsType[i], 'Value': radioBtnValue });
        }
    }
    

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
}
//init scrollSpy
function initScrollSpy() {
    $('.scrollspy').scrollSpy({ scrollOffset: 100 });//offset for menu
}
$(document).ready(function () {
    initScrollSpy();
    initCriterions();
});