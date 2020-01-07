<%@ Page Language="C#" AutoEventWireup="true" CodeFile="challenges.aspx.cs" Inherits="challenges" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="icon" href="images/logo_whiteBackground_withoutBorders.png" type="image/x-icon" />
    <title>אתגרים BarMates</title>
    <link href="css/materialize.min.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />
    <link href="css/menu.css" rel="stylesheet" />
    <link href="css/challenge.css" rel="stylesheet" />
</head>
<body>
    <header>
        <div id="toolbar">
            <div class="logo_wrapper">
                <img alt="bar mates logo" src="images/logo_menu.png" />
            </div>
            <div class="topnav" id="myTopnav">
                <div class="topnav_inner">
                    <a id="Homepage" href="Homepage.aspx">ראשי</a>
                    <a id="SearchBar" href="SearchBar.aspx">חיפוש בר</a>
                    <a id="BarRating" href="BarRating.aspx">דירוג בר</a>
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
                <div class="col">
                     <h3>אתגרי תל אביב</h3>
                </div>
                
            </div>
            <div class="row">
                <div class="column">
                    <ul class="collapsible">
                        <li>
                            <div class="collapsible-header">
                                <img src="images/dizi/ilka.jpg" />
                            </div>
                            <div class="collapsible-body"><span>כתובת: דיזינגוף</span></div>
                        </li>
                    </ul>
                </div>
                <div class="column">
                    <ul class="collapsible">
                        <li>
                            <div class="collapsible-header">
                                <img src="images/dizi/dizi.jpg" />
                            </div>
                            <div class="collapsible-body"><span>כתובת: דיזינגוף</span></div>
                        </li>
                    </ul>
                </div>
                <div class="column">
                    <ul class="collapsible">
                        <li>
                            <div class="collapsible-header">
                                <img src="images/dizi/mila.jpg" />
                            </div>
                            <div class="collapsible-body"><span>כתובת: דיזינגוף</span></div>
                        </li>
                    </ul>
                </div>
                <div class="column">
                    <ul class="collapsible">
                        <li>
                            <div class="collapsible-header">
                                <img src="images/dizi/simta.jpg" />
                            </div>
                            <div class="collapsible-body"><span>כתובת: דיזינגוף</span></div>
                        </li>
                    </ul>
                </div>
                <div class="column">
                    <ul class="collapsible">
                        <li>
                            <div class="collapsible-header">
                                <img src="images/dizi/zina.jpg" />
                            </div>
                            <div class="collapsible-body"><span>כתובת: דיזינגוף</span></div>
                        </li>
                    </ul>
                </div>
                <div class="column">
                    <ul class="collapsible">
                        <li>
                            <div class="collapsible-header">
                                <img src="images/dizi/rutina.png" />
                            </div>
                            <div class="collapsible-body" dir="rtl"><span>כתובת: דיזינגוף</span></div>
                        </li>
                    </ul>
                </div>
                <div class="column">
                    <ul class="collapsible">
                        <li>
                            <div class="collapsible-header">
                                <img src="images/dizi/consier.png" />
                            </div>
                            <div class="collapsible-body"><span>כתובת: דיזינגוף</span></div>
                        </li>
                    </ul>
                </div>
            </div>
        </div>

    </main>
</body>
<script src="js/jquery-1.11.3.js"></script>
<script src="js/materialize.min.js"></script>

<script src="js/menu.js"></script>
<script src="js/challenge.js"></script>
</html>
