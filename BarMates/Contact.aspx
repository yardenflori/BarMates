<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="icon" href="images/logo_whiteBackground_withoutBorders.png" type="image/x-icon" />
    <title>צור קשר BarMates</title>
    <link href="css/materialize.min.css" rel="stylesheet" />
    <link href="css/Login.css" rel="stylesheet" />
    <link href="css/menu.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />
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
                    <a id="Homepage" href="Homepage.aspx">ראשי</a>
                    <a id="SearchBar" href="SearchBar.aspx">חיפוש בר</a>
                    <a id="BarRating" href="BarRating.aspx">דירוג בר</a>
                    <a id="challenges" href="challenges.aspx">אתגרים</a>
                    <a id="leaderboard" href="leaderboard.aspx">המובילים</a>
                    <a id="Contact" href="Contact.aspx" class="active">צור קשר</a>

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
            <div id="contact-title"> פניה חדשה: </div>
            <p style="color: #166678;">
                יש לך רעיון לאתגר מגניב?<br />
                חסרה לך תגית חיפוש או דירוג?<br />
                שתף אותנו!
            </p>
            <div id="contact-div">
                <div class="contect_form">
                    <div class="row">
                        <div class="input-field col s6 flex_row">
                            <input class="input_text_form" id="subject" type="text"/>
                            <label for="subject" class="">נושא הפנייה</label>
                        </div>
                        <div class="input-field col s6 flex_row">
                            <input class="input_text_form" id="client_name" type="text"/>
                            <label for="client_name">שם פרטי ומשפחה</label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="input-field col s6 flex_row">
                            <input class="input_text_form validate" id="email" type="email"/>
                            <label for="email">דואר אלקטרוני</label>
                        </div>
                        <div class="input-field col s6 flex_row">
                            <input class="input_text_form" id="phone" type="tel"/>
                            <label for="phone">טלפון</label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="input-field col s12">
                            <textarea placeholder="איך נוכל לעזור?" id="client_content" class="materialize-textarea"></textarea>
                        </div>
                    </div>
                    <div class="row">
                        <div class=" col s12 input-field center-btn">
                            <a id="sendContact-btn" onclick="sendContactForm()" class="btn waves-effect waves-light btn-large">שלח</a>
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
<script src="js/contact.js"></script>
</html>
