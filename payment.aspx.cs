using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
public partial class payment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            filldetailsofpayment();
        }
    }




    public void filldetailsofpayment()
    {
        if (Session["cid"] != null)
        {
            if (Request.QueryString["payment"] == "cart")
            {
                SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["findfoods"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("getcartproductdetailsbycid", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cid", int.Parse(Session["cid"].ToString()));
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                lblnoofproducts.Text = dt.Rows.Count.ToString();
                SqlCommand cmd1 = new SqlCommand("select Max(S_no) from Payment_Details_table", con);
                string i = cmd1.ExecuteScalar().ToString();
                if (i == "")
                {
                   lblpaymentid.Text = "pay0001";
                }
                else
                {
                    int j = int.Parse(i);
                    j++;
                    lblpaymentid.Text = "pay0001" + j.ToString();
                }

                lblpriceofproduct.Text = Request.QueryString["price"];
                lblshipingcharges.Text = "100";
                lbltotalprice.Text = ((int.Parse(lblpriceofproduct.Text) + int.Parse(lblshipingcharges.Text))).ToString();
                SqlCommand cmd2 = new SqlCommand("select * from customer_detail_table where cid=@cid", con);
                cmd2.Parameters.AddWithValue("@cid", int.Parse(Session["cid"].ToString()));
                SqlDataReader sdr2 = cmd2.ExecuteReader();
                while (sdr2.Read())
                {
                    lblshipingaddress.Text = sdr2["c_adress"].ToString();
                }
                productdetails.DataSource = dt;
                productdetails.DataBind();
                con.Close();
            }
            else if (Request.QueryString["payment"] == "product")
            {
                SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["findfoods"].ConnectionString);
                con.Open();
                SqlCommand cmd1 = new SqlCommand("select Max(S_no) from Payment_Details_table", con);
                string i = cmd1.ExecuteScalar().ToString();
                if (i == "")
                {
                    lblpaymentid.Text = "pay0001";
                }
                else
                {
                    int j = int.Parse(i);
                    j++;
                    lblpaymentid.Text = "pay0001" + j.ToString();
                }
                lblpriceofproduct.Text = Session["total"].ToString();
                lblshipingcharges.Text = "100";
                lbltotalprice.Text = ((int.Parse(lblpriceofproduct.Text) + int.Parse(lblshipingcharges.Text))).ToString();
                SqlCommand cmd2 = new SqlCommand("select * from customer_detail_table where cid=@cid", con);
                cmd2.Parameters.AddWithValue("@cid", int.Parse(Session["cid"].ToString()));
                SqlDataReader sdr2 = cmd2.ExecuteReader();
                while (sdr2.Read())
                {
                    lblshipingaddress.Text = sdr2["c_adress"].ToString();
                }
                con.Close();
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from product_details_table where product_id='" + int.Parse(Session["product_id"].ToString()) + "'", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                productdetails.DataSource = dt;
                productdetails.DataBind();
                con.Close();
            }
            else
            {
                Response.Redirect("home.aspx");
            }
        }
    }
    protected void btnconfirmandpay_Click(object sender, EventArgs e)
    {
        if (Session["cid"] != null)
        {
            if (Request.QueryString["payment"] == "cart")
            {
                string datetime = DateTime.Now.ToString();
                SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["findfoods"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Cart_Details_table where cid='" + Session["cid"].ToString() + "'", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                int count = 0;
                if (dt.Rows.Count > 0)
                {
                    while (count < dt.Rows.Count)
                    {
                        SqlCommand cmd1 = new SqlCommand("insert into Payment_Details_table values(@paymentid,@cartid,@productid,@price,@shipping,@total, @cid,@datetime,)", con);
                        cmd1.Parameters.AddWithValue("@paymentid", lblpaymentid.Text);
                        cmd1.Parameters.AddWithValue("@cartid", int.Parse(dt.Rows[count]["Cart_id"].ToString()));
                        cmd1.Parameters.AddWithValue("@cid", int.Parse(Session["cid"].ToString()));
                        cmd1.Parameters.AddWithValue("@productid", int.Parse(dt.Rows[count]["product_id"].ToString()));
                        
                        cmd1.Parameters.AddWithValue("@datetime", datetime);
                        cmd1.ExecuteNonQuery();
                        count++;
                    }
                    Session["paymentcart"] = lblpaymentid.Text;
                    Session["datecart"] = datetime;
                    Response.Redirect("orderplacedsuccessfull.aspx?id=" + Session["cid"].ToString() + "&payment=cart");
                }


            }
            else
            {
                string datetime = DateTime.Now.ToString();
                SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["findfoods"].ConnectionString);
                con.Open();
                SqlCommand cmd1 = new SqlCommand("insert into Payment_Details_table values(@paymentid,@cartid,@productid,@price,@shiping,@total,@cid,@datetime)", con);
                cmd1.Parameters.AddWithValue("@paymentid", lblpaymentid.Text);
                cmd1.Parameters.AddWithValue("@productid", Session["productid"].ToString());
                cmd1.Parameters.AddWithValue("@price", Session["price"].ToString());
                cmd1.Parameters.AddWithValue("@shiping", "100");
                cmd1.Parameters.AddWithValue("@total", Session["total"].ToString());
                cmd1.Parameters.AddWithValue("@cid", int.Parse(Session["cid"].ToString()));
                cmd1.Parameters.AddWithValue("@datetime", datetime);
                cmd1.ExecuteNonQuery();
                Session["paymentproduct"] = lblpaymentid.Text;
                Session["dateproduct"] = datetime;
                Response.Redirect("orderplacedsuccessfull.aspx?id=" + Session["cid"].ToString() + "&payment=product");
            }
        }
    }






}