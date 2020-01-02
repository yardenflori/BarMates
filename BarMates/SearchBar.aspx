﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchBar.aspx.cs" Inherits="SearchBar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="icon" href="images/logo_whiteBackground_withoutBorders.png" type="image/x-icon"/>
    <title>חיפוש בר BarMates</title>
    <link href="css/materialize.min.css" rel="stylesheet" />
    <link href="css/menu.css" rel="stylesheet" />
    <link href="css/searchBar.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet"/>
</head>
<body>
     <header>
        <div id="toolbar">
            <div class="logo_wrapper">
                <img alt="bar mates logo" src="images/logo_menu.png" />
            </div>
            <div class="topnav" id="myTopnav">
                <div class="topnav_inner">
                    <a onclick="goToHomePage()">ראשי</a>
                    <a class="active" onclick="goToSearchBar()">חיפוש בר</a>
                    <a onclick="goToBarRating()">דירוג בר</a>
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
        <div id="searchDiv" class="card">
                <div class="row">
                <div id="searchTitle_div" class="input-field col">
                    <p>אנא סמן פרמטרים לחיפוש בר:</p>
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
                    <a id="searchbtn" onclick="searchBar()" class="btn waves-effect waves-light btn-large" name="submit">חפש</a>
                </div>
            </div>
            </div>
            <div id="results" class="card">
                <div class="main_title">
                    <span>תוצאות החיפוש</span>
                    <a id="backToSearch" onclick="showSearch()">(חזור לחיפוש)</a>
                </div>
                <div id="carousel" class="carousel"></div>
            </div>

 </main>
</body>
    <script src="js/jquery-1.11.3.js"></script>
<script src="js/materialize.min.js"></script>
<script src="js/menu.js"></script>
<script src="js/searchBar.js"></script>
</html>
