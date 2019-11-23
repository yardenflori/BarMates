<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/materialize.min.css" rel="stylesheet" />
    <link href="css/Login.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
</head>
<body class="main_login login_form">
    <section>
        <form id="general_form">
            <fieldset id="login_fieldset">
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
            </fieldset>
        </form>
    </section>
</body>
<script src="js/jquery-1.11.3.js"></script>
<script src="js/materialize.min.js"></script>
<script src="js/login.js"></script>
</html>
