﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("admin home.aspx");
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        
            Response.Redirect("admin login.aspx");

    }


    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        Response.Redirect("addproduct.aspx");
    }
}
