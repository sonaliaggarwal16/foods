using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Web.Configuration;
public partial class orderplacedsuccessfull : System.Web.UI.Page
{
    StringBuilder htmlTable = new StringBuilder();
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillgridview();
        }
    }

    public void fillgridview()
    {
        string cid = Request.QueryString["id"];
        string payment = Request.QueryString["payment"];
        if (cid != null && cid != "")
        {
            if (payment == "cart")
            {
                SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["findfoods"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("getpaymentdetailsbyidanddate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@payment", Session["paymentcart"].ToString());
                cmd.Parameters.AddWithValue("@cid", int.Parse(cid));
                cmd.Parameters.AddWithValue("@date", Session["datecart"].ToString());
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                lblpaymentid.Text = dt.Rows[0]["Payment_Id"].ToString();
                lblnoofproducts.Text = dt.Rows.Count.ToString();
                SqlDataReader sdr = cmd.ExecuteReader();
                int price = 0;
                while (sdr.Read())
                {
                    price = price + (int.Parse(sdr["total"].ToString()));
                }
                lblprice.Text = price.ToString();
                lblshipingprice.Text = "100";
                lbltotalprice.Text = (price + 100).ToString();
                gvpaymentdetails.DataSource = dt;
                gvpaymentdetails.DataBind();
            }
            else if (payment == "product")
            {
                SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["findfoods"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("getpaymentproductdetailsbyidanddate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@payment", Session["paymentproduct"].ToString());
                cmd.Parameters.AddWithValue("@cid", int.Parse(cid));
                cmd.Parameters.AddWithValue("@date", Session["dateproduct"].ToString());
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                lblpaymentid.Text = dt.Rows[0]["Payment_Id"].ToString();
                lblnoofproducts.Text = dt.Rows.Count.ToString();
                SqlDataReader sdr = cmd.ExecuteReader();
                int price = 0;
                while (sdr.Read())
                {
                    price = price + (int.Parse(sdr["total"].ToString()));
                }
                lblprice.Text = price.ToString();
                lblshipingprice.Text = "100";
                lbltotalprice.Text = (price + 100).ToString();
                gvpaymentdetails.DataSource = dt;
                gvpaymentdetails.DataBind();
            }

            else if (payment == "product")
            {
                SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["findfoods"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("getpaymentproductdetailsbyidanddate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@payment", Session["paymentproduct"].ToString());
                cmd.Parameters.AddWithValue("@cid", int.Parse(cid));
                cmd.Parameters.AddWithValue("@date", Session["dateproduct"].ToString());
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                lblpaymentid.Text = dt.Rows[0]["Payment_Id"].ToString();
                lblnoofproducts.Text = dt.Rows.Count.ToString();
                SqlDataReader sdr = cmd.ExecuteReader();
                int price = 0;
                while (sdr.Read())
                {
                    price = price + (int.Parse(sdr["total"].ToString()));
                }
                lblprice.Text = price.ToString();
                lblshipingprice.Text = "100";
                lbltotalprice.Text = (price + 100).ToString();
                gvpaymentdetails.DataSource = dt;
                gvpaymentdetails.DataBind();
            }
            else
            {
                Response.Redirect("home.aspx");
            }

        }
    }
}