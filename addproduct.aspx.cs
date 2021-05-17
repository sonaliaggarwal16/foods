using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
public partial class addproduct : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillgridview();
        }
    }
    protected void btnupload_Click(object sender, EventArgs e)
    {
        if (imageuploader.HasFile)
        {
            string filename = imageuploader.FileName;
            imageuploader.PostedFile.SaveAs(Server.MapPath(".") + "//uploads//" + filename);
            Session["path"] = "~/uploads/" + filename;
            ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('image uploaded successfully')</script>");
            imgproduct.ImageUrl = Session["path"].ToString();

        }
        else
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('please upload image')</script>");
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

    protected void btnaddproduct_Click(object sender, EventArgs e)
    {

        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["findfoods"].ConnectionString);
        con.Open();
        string query = "insert into product_details_table values(@pimgurl,@pname,@pcatagory,@pprice)";
        SqlCommand cmd = new SqlCommand(query, con);
        cmd.Parameters.AddWithValue("@pimgurl", Session["path"].ToString());
        cmd.Parameters.AddWithValue("@pname", txtproductname.Text);
        cmd.Parameters.AddWithValue("@pcatagory", txtpcata.Text);
       
        cmd.Parameters.AddWithValue("@pprice", txtprice.Text);
        int i = cmd.ExecuteNonQuery();
        if (i > 0)
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Data inserted successfully')</script>");
        }
        else
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Data not inserted successfully')</script>");
        }
        fillgridview();
    }
    protected void gvproductdetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvproductdetails.EditIndex = -1;
        fillgridview();
    }
    protected void gvproductdetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["findfoods"].ConnectionString);
        con.Open();
        Label id = (Label)gvproductdetails.Rows[e.RowIndex].FindControl("lblproductid");
        SqlCommand cmd = new SqlCommand("delete product_details_table where product_id=@id", con);
        cmd.Parameters.AddWithValue("@id", int.Parse(id.Text));
        int i = cmd.ExecuteNonQuery();
        if (i > 0)
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Data deleted successfully')</script>");
        }
        else
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('error')</script>");
        }
        fillgridview();

    }
    protected void gvproductdetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["findfoods"].ConnectionString);
        con.Open();
        Label lblid = (Label)gvproductdetails.Rows[e.RowIndex].FindControl("lblproductid");
        FileUpload fuimage = (FileUpload)gvproductdetails.Rows[e.RowIndex].FindControl("fuimageuploadergridview");
        TextBox txtpname = (TextBox)gvproductdetails.Rows[e.RowIndex].FindControl("txtproname");
        TextBox txtprocata = (TextBox)gvproductdetails.Rows[e.RowIndex].FindControl("txtprocata");
        TextBox txtproprice = (TextBox)gvproductdetails.Rows[e.RowIndex].FindControl("txtproprice");
        if (fuimage!=null && fuimage.HasFile)
        {
            string filename = fuimage.FileName;
            fuimage.PostedFile.SaveAs(Server.MapPath("~\\uploads\\") + filename);
            Session["path"] = "~\\uploads\\" + filename;
            SqlCommand cmd = new SqlCommand("update product_details__table set product_img_url=@purl,p_name=@name,p_categor=@pcata,p_price=@price where product_id=@id", con);
            cmd.Parameters.AddWithValue("@id", int.Parse(lblid.Text));
            cmd.Parameters.AddWithValue("@purl", Session["path"].ToString());
            cmd.Parameters.AddWithValue("@name", txtproductname.Text);
            cmd.Parameters.AddWithValue("@pcata", txtpcata.Text);

            cmd.Parameters.AddWithValue("@price", txtprice.Text);
           
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Data updated successfully')</script>");
            }
            else
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('error')</script>");
            }
        }
        else
        {
            SqlCommand cmd = new SqlCommand("update product_details__table set p_name=@name,p_categor=@pcata,p_price=@price where product_id=@id", con);
            cmd.Parameters.AddWithValue("@name", txtproductname.Text);
            cmd.Parameters.AddWithValue("@pcata", txtpcata.Text);
            cmd.Parameters.AddWithValue("@id", int.Parse(lblid.Text));
            cmd.Parameters.AddWithValue("@price", txtprice.Text);
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Data updated successfully')</script>");
            }
            else
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('error')</script>");
            }
        }
        gvproductdetails.EditIndex = -1;
        fillgridview();
    }
    protected void gvproductdetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvproductdetails.EditIndex = e.NewEditIndex;
        fillgridview();
    }
    protected void gvproductdetails_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}