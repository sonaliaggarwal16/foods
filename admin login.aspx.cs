using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;

public partial class admin_login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
   

    protected void btnlogin_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["findfoods"].ConnectionString);
        con.Open();
        string query = "select *from admin_login_table where admin_name= @name and admin_password=@password";
        SqlCommand cmd = new SqlCommand(query, con);
        cmd.Parameters.AddWithValue("@name", Txtusername.Text);
        cmd.Parameters.AddWithValue("@password", Txtpassword.Text);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('welcome ')</script>");
            Session["adminlogin"] = Txtusername.Text;
            Session["admin_id"] = dt.Rows[0]["admin_id"].ToString();
            Response.Redirect("admin home.aspx");
        }
        else
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('invalid admin name and password')</script>");
        }
    }
}