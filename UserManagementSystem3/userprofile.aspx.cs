using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace UserManagementSystem3
{
    public partial class userprofile : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["DbUserManagement"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["username"].ToString() == "" || Session["username"] == null)
                {
                    Response.Write("<script>alert('Session Expired Login Again');</script>");
                    Response.Redirect("userlogin.aspx");
                }
                else
                {                   
                    if (!Page.IsPostBack)
                    {
                        GetUserData();
                    }

                }
            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('Session Expired Login Again');</script>");
                Response.Redirect("userlogin.aspx");
            }
           
        }

        protected void btnUserupdate_Click(object sender, EventArgs e)
        {
            if (Session["username"].ToString() == "" || Session["username"] == null)
            {
                Response.Write("<script>alert('Session Expired Login Again');</script>");
                Response.Redirect("userlogin.aspx");
            }
            else
            {
                updateUserPersonalDetails();
                GridView1.DataBind();

            }
            
        }

        //User Defined Function

        void updateUserPersonalDetails()
        {
            string password = "";
            if (TextBox10.Text.Trim() == "")
            {
                password = TextBox9.Text.Trim();
            }
            else
            {
                password = TextBox10.Text.Trim();
            }
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("USP_UserUpdatePersonalData", con);
                //SqlCommand cmd = new SqlCommand("update member_master_table set full_name=@full_name, dob=@dob, contact_no=@contact_no, email=@email, state=@state, city=@city, pincode=@pincode, full_address=@full_address, password=@password, account_status=@account_status WHERE member_id='" + Session["username"].ToString().Trim() + "'", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@user_id", Session["username"].ToString());
                cmd.Parameters.AddWithValue("@uname", txtfullname.Text.Trim());
                cmd.Parameters.AddWithValue("@udob", txtdob.Text.Trim());
                cmd.Parameters.AddWithValue("@contact", txtcontact.Text.Trim());
                cmd.Parameters.AddWithValue("@uemail", txtemail.Text.Trim());
                cmd.Parameters.AddWithValue("@ustate", ddlstate.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@ucity", txtcity.Text.Trim());
                cmd.Parameters.AddWithValue("@pincode", txtpincode.Text.Trim());
                cmd.Parameters.AddWithValue("@ufull_address", txtfulladdress.Text.Trim());               
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@account_status", "Pending");

                int result = cmd.ExecuteNonQuery();
                con.Close();
                if (result > 0)
                {

                    Response.Write("<script>alert('Your Details Updated Successfully');</script>");
                    GetUserData();

                }
                else
                {
                    Response.Write("<script>alert('Invaid entry');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }





        void GetUserData() 
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("USP_GetUserDetaByID", con);
                //SqlCommand cmd = new SqlCommand("SELECT * from tbl_UserMaster where user_id = '" + TextBox1.Text.Trim() + "'", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@user_id",Session["username"].ToString());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                txtfullname.Text = dt.Rows[0]["uname"].ToString();
                txtdob.Text = dt.Rows[0]["udob"].ToString();
                txtcontact.Text = dt.Rows[0]["contact"].ToString();
                txtemail.Text = dt.Rows[0]["uemail"].ToString();
                ddlstate.SelectedValue= dt.Rows[0]["ustate"].ToString().Trim();
                txtcity.Text = dt.Rows[0]["ucity"].ToString();
                txtpincode.Text = dt.Rows[0]["pincode"].ToString();
                txtfulladdress.Text = dt.Rows[0]["ufull_address"].ToString();
                TextBox8.Text = dt.Rows[0]["user_id"].ToString();
                TextBox9.Text = dt.Rows[0]["password"].ToString();

                Label1.Text = dt.Rows[0]["account_status"].ToString().Trim();

                if (dt.Rows[0]["account_status"].ToString().Trim() == "active")
                {
                    Label1.Attributes.Add("class", "badge badge-pill badge-success");
                }
                else if (dt.Rows[0]["account_status"].ToString().Trim() == "pending")
                {
                    Label1.Attributes.Add("class", "badge badge-pill badge-warning");
                }
                else if (dt.Rows[0]["account_status"].ToString().Trim() == "deactive")
                {
                    Label1.Attributes.Add("class", "badge badge-pill badge-danger");
                }
                else
                {
                    Label1.Attributes.Add("class", "badge badge-pill badge-info");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + " ');</script>");
               
            }
        }
    }
}