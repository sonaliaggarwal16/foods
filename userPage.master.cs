using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["login"] != null)
        {
            lbtncustomer.Visible = true;
            lbtncustomer.Text = Session["login"].ToString();
            lbtnlogout.Visible = true;
            lbtlogin.Visible = false;
        }
        else
        {
            lbtncustomer.Visible = false;
            lbtnlogout.Visible = false;

        }

    }
    protected void lbtnhome_Click(object sender, EventArgs e)
    {
        Response.Redirect("home.aspx");
    }
    protected void lbtncartClick(object sender, EventArgs e)
    {
        Response.Redirect("cart.aspx");
    }
    protected void lbtnregister_Click(object sender, EventArgs e)
    {
        Response.Redirect("reg.aspx");
    }
    protected void lbtnabout_Click(object sender, EventArgs e)
    {
        Response.Redirect("ABOUT US.aspx");
    }
    protected void lbtnlogout_Click(object sender, EventArgs e)
    {
        
        

    }
   
   
    protected void lbtncustomer_Click(object sender, EventArgs e)
    {

    }
  

    protected void lbtnproduct_Click(object sender, EventArgs e)
    {
        Response.Redirect("product.aspx");
    }

    protected void lbtncart_Click(object sender, EventArgs e)
    {
        Response.Redirect("cart.aspx");
    }
    protected void lbtnregister_Click1(object sender, EventArgs e)
    {
        Response.Redirect("reg.aspx");
    }
   
    protected void lbtnaboutus_Click(object sender, EventArgs e)
    {
        Response.Redirect("ABOUT US.aspx");
    }
    protected void lbtlogin_Click(object sender, EventArgs e)
    {
        Response.Redirect("newlogin.aspx");
    }
    protected void lbtnlogout_Click1(object sender, EventArgs e)
    {
        Session.Abandon();
        Session.RemoveAll();
        lbtnlogout.Visible = false;
        lbtncustomer.Visible = false;
    }
}
