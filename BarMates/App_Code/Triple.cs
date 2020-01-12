using BarMates;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;


public class Triple
{
    public int AllCounts
    {
        get { return (NegCounts + PosCounts + DontCareCounts); }
    }
    public int NegCounts { get; set; }
    public int PosCounts { get; set; }
    public int DontCareCounts { get; set; }

}