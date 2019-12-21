<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProfileBar.aspx.cs" Inherits="ProfileBar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="icon" href="images/logo_whiteBackground_withoutBorders.png" type="image/x-icon"/>
    <title>פרופיל בר BarMates</title>
    <link href="css/materialize.min.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />
    <link href="css/menu.css" rel="stylesheet" />

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
        <div class="card"></div>

 </main>
</body>
    <script src="js/jquery-1.11.3.js"></script>
<script src="js/materialize.min.js"></script>
<script src="js/menu.js"></script>
<script src="js/profileBar.js"></script>
</html>
