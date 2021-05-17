using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class reg : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["findfoods"].ConnectionString);
        con.Open();
        string query = "insert into customer_detail_table values(@name,@email,@password,@contact,@adress)";
        SqlCommand cmd = new SqlCommand(query, con);
        cmd.Parameters.AddWithValue("@name", txtname.Text);
        cmd.Parameters.AddWithValue("@email", txtemail.Text);
        cmd.Parameters.AddWithValue("@password", txtpassword.Text);
        cmd.Parameters.AddWithValue("@contact", txtcontact.Text);
        cmd.Parameters.AddWithValue("@adress", txtadress.Text);

        int i = cmd.ExecuteNonQuery();

        if (i > 0)
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('data inserted successfully')</script>");
            Response.Redirect("newlogin.aspx");
        }
        else
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('data not inserted successfully')</script>");

        }
    }
}