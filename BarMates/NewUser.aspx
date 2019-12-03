﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewUser.aspx.cs" Inherits="NewUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>משתמש חדש BarMates</title>
    <link href="css/materialize.min.css" rel="stylesheet" />
    <link href="css/Login.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet"/></head>
<body class="main_login login_form">
       <section>
        <form id="general_form">
            <fieldset id="login_fieldset">
                <h1 class="login_form_title">משתמש חדש BarMates</h1>
                <div class="row">
                    <div class="input-field">
                        <input id="username" type="text" class="input_no_margin" onkeydown="onkeydown_register()" />
                        <label for="username">שם משתמש</label>
                        <span class="helper-text">יש לבחור שם משתמש באורך 6 עד 15 תווים המכיל לפחות אות אחת באנגלית ולפחות ספרה אחת</span>
                    </div>
                </div>
                <div class="row password-row">
                    <div class="input-field">
                        <input id="password" type="password" class="input_no_margin" onkeydown="onkeydown_register()" />
                        <label for="password">סיסמה</label>
                        <span class="helper-text">יש לבחור סיסמה באורך 6 עד 15 תווים המכיל לפחות אות אחת באנגלית ולפחות ספרה אחת</span>
                    </div>
                    <a id="showPassword" class="" href="#">
                        <i class="material-icons">visibility</i>
                    </a>
                    <a id="hidePassword" class="hide-icon" href="#">
                        <i class="material-icons">visibility_off</i>
                    </a>
                </div>
                <div class="row">
                    <div class="input-field col s4">
                        <select id="age"></select>
                        <label>גיל</label>
                    </div>
                </div>
                <div class="row login_submit_btn">
                    <a onclick="registerClick()" class="btn waves-effect waves-light btn-large" name="submit">הרשם</a>
                </div>
            </fieldset>
        </form>
    </section>
</body>
<script src="js/jquery-1.11.3.js"></script>
<script src="js/materialize.min.js"></script>
<script src="js/newUser.js"></script>
</html>
