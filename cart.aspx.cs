using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;
public partial class cart : System.Web.UI.Page
{
    int price = 0;
    int shipingcharges = 100;
    int totalamount = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillgridview();

        }
    }
    public void fillgridview()
    {
        if (Session["cid"] != null)
        {
            emptycart.Visible = false;
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["findfoods"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("getcartproductdetailsbycid", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cid", int.Parse(Session["cid"].ToString()));
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    price = price + (Convert.ToInt32(sdr["total"]));
                }

                totalamount = shipingcharges + price;

                lblprice.Text = price.ToString();
                lblshipcharges.Text = shipingcharges.ToString();
                lbltotalprice.Text = totalamount.ToString();
                lbltotalcartvalue.Text = dt.Rows.Count.ToString();
                gvcartproduct.DataSource = dt;
                gvcartproduct.DataBind();
                con.Close();
            }
            else
            {
                gvcart.Visible = false;
                emptycart.Visible = true;
            }
        }
        else
        {
            gvcart.Visible = false;
        }
    }
    protected void imgbtn_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("productdetail.aspx?id=" + ((ImageButton)sender).AlternateText);

    }
    protected void gvcartproduct_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["findfoods"].ConnectionString);
        con.Open();
        HiddenField dfcartid = (HiddenField)gvcartproduct.Rows[e.RowIndex].FindControl("hiddencartid");
        SqlCommand cmd = new SqlCommand("delete Cart_Details_table where Cart_id=@Cart_id", con);
        cmd.Parameters.AddWithValue("@Cart_id", dfcartid.Value);
        int i = cmd.ExecuteNonQuery();
        if (i > 0)
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Successfully deleted')</script>");
        }
        con.Close();
        fillgridview();
    }

    protected void gvcartproduct_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvcartproduct.EditIndex = e.NewEditIndex;
        fillgridview();
    }
    protected void gvcartproduct_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvcartproduct.EditIndex = -1;
        fillgridview();
    }
    protected void gvcartproduct_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["findfoods"].ConnectionString);
        con.Open();
        HiddenField dfcartid = (HiddenField)gvcartproduct.Rows[e.RowIndex].FindControl("hiddencartid");
        TextBox lblquantity = (TextBox)gvcartproduct.Rows[e.RowIndex].FindControl("txtquantity");
        Label lblprice = (Label)gvcartproduct.Rows[e.RowIndex].FindControl("productprice");
        int totalprice = int.Parse(lblquantity.Text) * int.Parse(lblprice.Text);
        SqlCommand cmd = new SqlCommand("update Cart_Details_table set quantity=@quantity,total=@totalprice where Cart_id=@cartid", con);
        cmd.Parameters.AddWithValue("@quantity", int.Parse(lblquantity.Text));
        cmd.Parameters.AddWithValue("@totalprice", lbltotalprice);
        cmd.Parameters.AddWithValue("@cartid", int.Parse(dfcartid.Value));
        int i = cmd.ExecuteNonQuery();
        if (i > 0)
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Successfully Added')</script>");
        }
        gvcartproduct.EditIndex = -1;
        fillgridview();
    }
    protected void btncontinueshoping_Click(object sender, EventArgs e)
    {
        Response.Redirect("product.aspx");
    }
    protected void btnplaceorder_Click(object sender, EventArgs e)
    {
        Response.Redirect("Payment.aspx?id=" + Session["cid"].ToString() + "&payment=cart&price=" + lblprice.Text + "");
    }
}