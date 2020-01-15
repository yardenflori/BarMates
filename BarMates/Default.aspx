<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <link rel="icon" href="images/logo_whiteBackground_withoutBorders.png" type="image/x-icon"/>
 <title>כניסה למערכת BarMates</title>
    <link href="css/materialize.min.css" rel="stylesheet" />
    <link href="css/Login.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet"/>
</head>
<body class="main_login login_form">
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
    <section>
        <form id="general_form">
            <fieldset id="login_fieldset">
                <img id="login_logo" src="images/logo_whiteBackground.png" />
                <h1 class="login_form_title">התחברות למערכת BarMates</h1>
                <div class="row">
                    <div class="input-field">
                        <input id="username" type="text" class="input_no_margin" onkeydown="onkeydown_login()" />
                        <label for="username">שם משתמש</label>
                        <span class="helper-text" data-error="wrong" data-success="right">אותיות באנגלית ומספרים בלבד</span>
                    </div>
                </div>
                <div class="row password-row">
                    <div class="input-field">
                        <input id="password" type="password" class="input_no_margin" onkeydown="onkeydown_login()" />
                        <label for="password">סיסמה</label>
                    </div>
                    <a id="showPassword" class="" href="#">
                        <i class="material-icons">visibility</i>
                    </a>
                    <a id="hidePassword" class="hide-icon" href="#">
                        <i class="material-icons">visibility_off</i>
                    </a>
                </div>
                <div class="row login_submit_btn">
                    <a onclick="loginClick()" class="btn waves-effect waves-light btn-large" name="submit">כניסה</a>
                </div>
                <div class="row reset_div">
                    <a href="NewUser.aspx">משתמש חדש</a>
                </div>
            </fieldset>
        </form>
    </section>
</body>
<script src="js/jquery-1.11.3.js"></script>
<script src="js/materialize.min.js"></script>
<script src="js/login.js"></script>
</html>