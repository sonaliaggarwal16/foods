using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;

public partial class product : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            fillgridview();
        }
    }
    public void fillgridview()
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["findfoods"].ConnectionString);
        con.Open();
        SqlCommand cmd = new SqlCommand("select * from product_details_table", con);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);

        gvproductdetails.DataSource = dt;
        gvproductdetails.DataBind();


    }
    protected void imgbtn_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("productdetail.aspx?id=" + ((ImageButton)sender).AlternateText);

    }

    protected void gvproductdetails_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}