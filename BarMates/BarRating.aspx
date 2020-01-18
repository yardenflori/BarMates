<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BarRating.aspx.cs" Inherits="BarRating" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="icon" href="images/logo_whiteBackground_withoutBorders.png" type="image/x-icon" />
    <title>דירוג בר BarMates</title>
    <link href="css/materialize.min.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />
    <link href="css/menu.css" rel="stylesheet" />
    <link href="css/barRating.css" rel="stylesheet" />
</head>
<body>
             <!--LOADER-->
    <div id="screen_loader" class="hide">
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
                    <a id="Homepage" href="Homepage.aspx" >ראשי</a>
                    <a id="SearchBar" href="SearchBar.aspx">חיפוש בר</a>
                    <a id="BarRating"  href="BarRating.aspx" class="active">דירוג בר</a>
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
        <div class="card">
            <div class="row">
                <div id="bar_autocomplete_div" class="input-field col">
                    <i class="material-icons prefix">search</i>
                    <input type="text" id="barsAutocomplete" class="autocomplete" placeholder="בחר בר לדירוג" />
                </div>
                 <div id="barname" class="input-field col">
                </div>
            </div>
            <div class="main_content">
                <div class="row">
                    <div class="col hide-on-small-only  s2 pinned">
                        <ul class="section table-of-contents">
                            <li><a class="right_menu" href="#drinks" onclick="setActive('#drinks')">שתיה<i class="material-icons right">local_bar</i></a></li>
                            <li><a class="right_menu" href="#food" onclick="setActive('#food')">אוכל<i class="material-icons right">local_pizza</i></a></li>
                            <li><a class="right_menu" href="#serv" onclick="setActive('#serv')">שירות<i class="material-icons right">room_service</i></a></li>
                            <li><a class="right_menu" href="#age" onclick="setActive('#age')">גיל<i class="material-icons right">date_range</i></a></li>
                            <li><a class="right_menu" href="#envi" onclick="setActive('#envi')">אווירה<i class="material-icons right">mood</i></a></li>
                            <li><a class="right_menu" href="#comp" onclick="setActive('#comp')">חברה<i class="material-icons right">people</i></a></li>
                            <li><a class="right_menu" href="#price" onclick="setActive('#price')">מחיר<i class="material-icons right">attach_money</i></a></li>
                            <li><a class="right_menu" href="#music" onclick="setActive('#music')">מוסיקה<i class="material-icons right">music_note</i></a></li>
                            <li><a class="right_menu" href="#Smoking" onclick="setActive('#Smoking')">עישון<i class="material-icons right">smoking_rooms</i></a></li>
                        </ul>
                    </div>
                    <div id="myDIV" class="col  s10">
                        <div id="drinks" class="mainCriterion scrollspy">
                            <div class="criterion">
                                <p class="criterion_title"><i class="material-icons right">local_bar</i>שתיה</p>
                                <div class="criterion_information"></div>
                            </div>
                        </div>
                        <div id="food" class="mainCriterion scrollspy">
                            <div class="criterion">
                                <p class="criterion_title"><i class="material-icons right">local_pizza</i>אוכל</p>
                                <div class="criterion_information"></div>
                            </div>
                        </div>
                        <div id="serv" class="mainCriterion scrollspy">
                            <div class="criterion">
                                <p class="criterion_title"><i class="material-icons right">room_service</i>שירות</p>
                                <div class="criterion_information"></div>
                            </div>
                        </div>
                        <div id="age" class="mainCriterion scrollspy">
                            <div class="criterion">
                                <p class="criterion_title"><i class="material-icons right">date_range</i>גיל</p>
                                <div class="criterion_information"></div>
                            </div>
                        </div>
                        <div id="envi" class="mainCriterion scrollspy">
                            <div class="criterion">
                                <p class="criterion_title"><i class="material-icons right">mood</i>אווירה</p>
                                <div class="criterion_information"></div>
                            </div>
                        </div>
                        <div id="comp" class="mainCriterion scrollspy">
                            <div class="criterion">
                                <p class="criterion_title"><i class="material-icons right">people</i>חברה</p>
                                <div class="criterion_information"></div>
                            </div>
                        </div>
                        <div id="price" class="mainCriterion scrollspy">
                            <div class="criterion">
                                <p class="criterion_title"><i class="material-icons right">attach_money</i>מחיר</p>
                                <div class="criterion_information"></div>
                            </div>
                        </div>
                        <div id="music" class="mainCriterion scrollspy">
                            <div class="criterion">
                                <p class="criterion_title"><i class="material-icons right">music_note</i>מוסיקה</p>
                                <div class="criterion_information"></div>
                            </div>
                        </div>
                        <div id="Smoking" class="mainCriterion scrollspy">
                            <div class="criterion">
                                <p class="criterion_title"><i class="material-icons right">smoking_rooms</i>עישון</p>
                                <div class="criterion_information"></div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="footer">
                    <a id="savebtn" onclick="saveRate()" class="disabled btn waves-effect waves-light btn-large" name="submit">שמור דירוג</a>
                </div>
            </div>
        </div>
    </main>
    <div id="modal1" class="modal">
        <div class="modal-content">
            <div id="modal_text"></div>
        </div>
        <div class="modal-footer">
            <a onclick="goToHomePage()" class="btn modal-close waves-effect waves-green btn-flat">סיום</a>
        </div>
    </div>
</body>
<script src="js/jquery-1.11.3.js"></script>
<script src="js/materialize.min.js"></script>
<script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyAsbHXRTAYj2YJfZNxms2Sp15zAG_-6Dyc&amp;libraries=places"></script>

<script src="js/menu.js"></script>
<script src="js/barRating.js"></script>
</html>
