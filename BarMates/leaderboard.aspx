<%@ Page Language="C#" AutoEventWireup="true" CodeFile="leaderboard.aspx.cs" Inherits="leaderboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="icon" href="images/logo_whiteBackground_withoutBorders.png" type="image/x-icon" />
    <title>leaderboard BarMates</title>
    <link href="css/materialize.min.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />
    <link href="css/menu.css" rel="stylesheet" />
    <link href="css/leaderboard.css" rel="stylesheet" />
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
                <h2 class="criterion_title">טבלת המובילים</h2>
            </div>
            <div class="container">
                <table class="centered">
                    <thead>
                        <tr>
                            <th></th>
                            <th>שם</th>
                            <th>ניקוד</th>
                        </tr>
                    </thead>

                    <tbody>
                        <tr>
                            <td class="counterCell"></td>
                            <td>Alvin</td>                            
                            <td>$0.87</td>
                        </tr>
                        <tr>
                             <td class="counterCell"></td>
                            <td>Alan</td>
                            <td>$3.76</td>
                        </tr>
                        <tr>
                             <td class="counterCell"></td>
                            <td>Jonathan</td>
                            <td>$7.00</td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </main>



</body>
<script src="js/jquery-1.11.3.js"></script>
<script src="js/materialize.min.js"></script>
<script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyAsbHXRTAYj2YJfZNxms2Sp15zAG_-6Dyc&amp;libraries=places"></script>

<script src="js/menu.js"></script>
<script src="js/leaderboard.js"></script>
</html>
