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
        id: 'Price0',
        name: '$'
    },
    {
        id: 'Price1',
        name: '$$'
    },
    {
        id: 'Price2',
        name: '$$$'
    }
];
bar.Service = new Object();
bar.Service.id = 'Service';
bar.Service.name = 'שירות';
bar.Service.options = [
    {
        id: 'Service0',
        name: 'שירות עצמי'
    },
    {
        id: 'Service1',
        name: 'שירות מלא'
    }
];
bar.Age = new Object();
bar.Age.id = 'Age';
bar.Age.name = 'גיל';
bar.Age.options = [
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

function fillMainCriterion(criterions, criterionProperty, mainCriterionId) {
    var countTrue = 0;
    for (var i = 0; i < criterions.length; i++) {
        if (criterionProperty[criterions[i].id] != undefined && criterionProperty[criterions[i].id] == true) {
            countTrue++;
            $('#' + criterions[i].id).attr("checked", true);
            $('#' + criterions[i].id + '_div').css('display', 'block');

        }
        else {
            $('#' + criterions[i].id + '_div').css('display', 'none');
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
        $('#Smoking').css('display', 'block');
        $('#SmokingFree').attr("checked", true);
        $('#SmokingFree_div').css('display', 'block');
    }
    else {
        $('#Smoking').css('display', 'none');
    }  
}
function fillEnumCriterion(options, barValue, mainCriterionId,barPropertyName) {
    var informationExsist = false;
    for (var i = 0; i < options.length; i++) {
        if (options[i].id == barPropertyName+barValue) {
            informationExsist = true;
            $('#' + options[i].id).attr("checked", true);
            $('#' + options[i].id + '_div').css('display', 'block');
        }
        else {
            $('#' + options[i].id + '_div').css('display', 'none');
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
    for (var i = 0; i < globalBars.length; i++) {
        if (globalBars[i].BarId == barId) {
            $('#address .criterion_information').text(globalBars[i].Address);
            fillMainCriterion(bar.Food, globalBars[i].Food, 'food');
            fillMainCriterion(bar.Drinks, globalBars[i].Drinks, 'drinks');
            fillMainCriterion(bar.Atmosphere, globalBars[i].Atmosphere, 'envi');
            fillMainCriterion(bar.Company, globalBars[i].Company, 'comp');
            fillMainCriterion(bar.Music, globalBars[i].Music, 'music');
            fillSmokingCriterion(globalBars[i].SmokingFree);
            fillEnumCriterion(bar.Price.options, globalBars[i].Price, 'price', 'Price');
            fillEnumCriterion(bar.Age.options, globalBars[i].Age, 'age', 'Age');
            fillEnumCriterion(bar.Service.options, globalBars[i].Service, 'serv', 'Service');

        }
    }
    $('input[type="checkbox"]').attr('disabled', true);
}
function createCheckBox(criterion) {
    var colDiv = $('<div id="' + criterion.id+'_div'+'"class="col s3"></div>');
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
function buildMainCriterion(criterions, criterionType) {
    rowDiv = $('<div class=\"row\"></div>');
    $('#' + criterionType + ' .criterion_information').append(rowDiv);
    for (var i = 0; i < criterions.length; i++) {
        createCheckBox(criterions[i]);
    }
}
function initCriterions() {
    buildMainCriterion(bar.Drinks, 'drinks');
    buildMainCriterion(bar.Food, 'food');
    buildMainCriterion(bar.Atmosphere, 'envi');
    buildMainCriterion(bar.Company, 'comp');
    buildMainCriterion(bar.Music, 'music');
    buildMainCriterion(bar.SmokingFree, 'Smoking');
    buildMainCriterion(bar.Price.options, 'price');
    buildMainCriterion(bar.Service.options, 'serv');
    buildMainCriterion(bar.Age.options, 'age');
}


function buildCarouselItem(barId, barName, barPhoto) {
    
    var divCarouselItem = $('<div id="' + barId+'"class=\"carousel-item card\"></div>');
    var divCarouselImg = $('<div class=\"card-image\"></div>');

    var img = $('<img src=' + barPhoto +  '> ');

    var span = $('<span class="card-title"></span>').text(barName);
    divCarouselItem.append(divCarouselImg);
    divCarouselImg.append(img);
    divCarouselImg.append(span);
    $('#carousel').append(divCarouselItem);
}
function initCarousel() {
    showLoader('BarMates, making your happy hour happier')
    $.ajax({
        type: "POST",
        url: 'Homepage.aspx/GetUserBars',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var barsFromDb = JSON.parse(data.d);
            globalBars = barsFromDb;
            for (var i = 0; i < globalBars.length; i++) {
                buildCarouselItem(globalBars[i].BarId, globalBars[i].BarName, globalBars[i].PhotoUrl);
            }
            $('.carousel').carousel({
                onCycleTo: function (el) {
                    var barId = $(el).attr('id');
                    fillProfileBar(barId);
                }
            });
            hideLoader();
        },
        error: function (errMsg) {
            showError('חלה שגיאה');
        }
    });    
}

function initUserStatus() {
    $.ajax({
        type: "POST",
        url: 'Homepage.aspx/GetUserStatus',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var userStatus = JSON.parse(data.d);
            $('#hello_user').text('שלום ' + userStatus.userName);
            $('#score').text(userStatus.score + ' נקודות');

            var challengesList = JSON.parse(userStatus.challenges);
            if (challengesList!=null && challengesList.length > 0) {
                $('#your_challenges').removeClass('hide');
                for (var i = 0; i < challengesList.length; i++) {
                    $('#' + challengesList[i]).removeClass('hide');
                }
            }      
           
        },
        error: function (errMsg) {
            showError('חלה שגיאה');
        }
    });   
}
$(document).ready(function () {
    initUserStatus();
    initCriterions();
    initCarousel();    
});