﻿using BarMates;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Homepage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (DBController.GetUserName() == null)
        {
            Response.Redirect("Default.aspx");
        }

    }
    [WebMethod]
    public static string GetUserBars()
    {
        //צריך להחזיר את רשימת הברים המומלצים של היוזר
        string[] bars = { "סעידה בפארק", "מזג", "ברוני" };

        return JsonConvert.SerializeObject(bars);
    }

}