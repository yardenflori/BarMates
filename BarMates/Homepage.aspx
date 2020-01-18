<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Homepage.aspx.cs" Inherits="Homepage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="icon" href="images/logo_whiteBackground_withoutBorders.png" type="image/x-icon"/>
  <title>ראשי BarMates</title>
    <link href="css/materialize.min.css" rel="stylesheet" />
    <link href="css/menu.css" rel="stylesheet" />
    <link href="css/homepage.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet"/>  
</head>
<body>
             <!--LOADER-->
    <div id="screen_loader">
        <div id="screen_loader_inner">
            <div class="preloader-wrapper active">
                <div class="spinner-layer">
                    <div class="circle-clipper left">
                        <div class="circle"></div>
                    </div>
                    <div class="gap-patch">
                        <div class="circle"></div>
                    </div>
                    <div class="circle-clipper right">
                        <div class="circle"></div>
                    </div>
                </div>
            </div>
            <div class="loader_text"></div>
        </div>
    </div> 
    <header>
        <div id="toolbar">
            <div class="logo_wrapper">
                <img alt="bar mates logo" src="images/logo_menu.png" />
            </div>
            <div class="topnav" id="myTopnav">
                <div class="topnav_inner">
                    <a id="Homepage" href="Homepage.aspx" class="active">ראשי</a>
                    <a id="SearchBar" href="SearchBar.aspx">חיפוש בר</a>
                    <a id="BarRating"  href="BarRating.aspx">דירוג בר</a>
                    <a id="challenges" href="challenges.aspx">אתגרים</a>
                    <a id="leaderboard" href="leaderboard.aspx">המבוסמים</a>
                    <a id="Contact" href="Contact.aspx">צור קשר</a>

                </div>
            </div>
            <a id="iconnav" class="icon" onclick="ToggleNav()">
                <i class="material-icons">menu</i>
            </a>
            <div class="left_header">
                <a onclick="logout()">התנתק</a>
            </div>
        </div>
    </header>
    <main>
        <div class="main card">
            <div id="userStatus" >
                <div id="status-div">
                    <div class="main_title right">
                    <span id="hello_user"></span>                    
                </div>
                <div class="main_title left">
                    <div id="score-div">
                        <span id="score"></span>
                    </div>
                </div>
                </div>
                
                <div id="your_challenges" class="hide">
                <div class="main_title">
                    <span>ההישגים שלך</span>                  
                </div>
                <div>
                      <img id="jerus" class="challenge-img hide" src="images/chall/jerus.jpeg" style="height:114px; width:110px"/>
                    <img id="tlv" class="challenge-img hide" src="images/chall/tlv.jpeg" />
                    <img id="world" class="challenge-img hide" src="images/chall/world.jpeg" />
                </div>

                </div>
            </div>
            <div id="recomendBars" >
                <div class="main_title">
                    <span>ברים מומלצים עבורך</span>
                </div>
                <div id="carousel" class="carousel"></div>
            </div>
            <div id="profile_bar">
                <div class="details">
                     <div id="address" class="mainCriterion">
                        <div class="criterion">
                            <p class="criterion_title"><i class="material-icons right">place</i>כתובת</p>
                            <div class="criterion_information"></div>
                        </div>
                    </div>
                    <div id="drinks" class="mainCriterion">
                        <div class="criterion">
                            <p class="criterion_title"><i class="material-icons right">local_bar</i>שתיה</p>
                            <div class="criterion_information"></div>
                        </div>
                    </div>
                    <div id="food" class="mainCriterion">
                        <div class="criterion">
                            <p class="criterion_title"><i class="material-icons right">local_pizza</i>אוכל</p>
                            <div class="criterion_information"></div>
                        </div>
                    </div>
                    <div id="serv" class="serv mainCriterion">
                        <div class="criterion">
                            <p class="criterion_title"><i class="material-icons right">room_service</i>שירות</p>
                            <div class="criterion_information"></div>
                        </div>
                    </div>
                    <div id="age" class="age mainCriterion">
                        <div class="criterion">
                            <p class="criterion_title"><i class="material-icons right">date_range</i>גיל</p>
                            <div class="criterion_information"></div>
                        </div>
                    </div>
                    <div id="envi" class="mainCriterion">
                        <div class="criterion">
                            <p class="criterion_title"><i class="material-icons right">mood</i>אווירה</p>
                            <div class="criterion_information"></div>
                        </div>
                    </div>
                    <div id="comp" class="mainCriterion">
                        <div class="criterion">
                            <p class="criterion_title"><i class="material-icons right">people</i>חברה</p>
                            <div class="criterion_information"></div>
                        </div>
                    </div>
                    <div id="price" class="price mainCriterion">
                        <div class="criterion">
                            <p class="criterion_title"><i class="material-icons right">attach_money</i>מחיר</p>
                            <div class="criterion_information"></div>
                        </div>
                    </div>
                    <div id="music" class="mainCriterion">
                        <div class="criterion">
                            <p class="criterion_title"><i class="material-icons right">music_note</i>מוסיקה</p>
                            <div class="criterion_information"></div>
                        </div>
                    </div>
                    <div id="Smoking" class="mainCriterion">
                        <div class="criterion">
                            <p class="criterion_title"><i class="material-icons right">smoking_rooms</i>עישון</p>
                            <div class="criterion_information"></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </main>
</body>
<script src="js/jquery-1.11.3.js"></script>
<script src="js/materialize.min.js"></script>
<script src="js/menu.js"></script>
<script src="js/Homepage.js"></script>
</html>
