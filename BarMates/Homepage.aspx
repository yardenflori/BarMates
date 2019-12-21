﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Homepage.aspx.cs" Inherits="Homepage" %>

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
    <header>
        <div id="toolbar">
            <div class="logo_wrapper">
                <img alt="bar mates logo" src="images/logo_menu.png" />
            </div>
            <div class="topnav" id="myTopnav">
                <div class="topnav_inner">
                    <a class="active" onclick="goToHomePage()">ראשי</a>
                    <a onclick="goToSearchBar()">חיפוש בר</a>
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
        <div class="main card">
            <div class="main_title">
                <span>ברים מומלצים עבורך</span>
            </div>
            <div id="carousel" class="carousel"></div>
        </div>
    </main>
</body>
<script src="js/jquery-1.11.3.js"></script>
<script src="js/materialize.min.js"></script>
<script src="js/menu.js"></script>
<script src="js/Homepage.js"></script>
</html>
