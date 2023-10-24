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
    public partial class userlogin : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["DbUserManagement"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }       
        protected void btnuserlogin_Click(object sender, EventArgs e)
        {
            // Response.Write("<script>alert('User logdin ');</script>");

            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("USP_UserLogin", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@user_id", txtuser_id.Text.Trim());
                cmd.Parameters.AddWithValue("@password", txtpassword.Text.Trim());
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Response.Write("<script>alert('User Login Successfully');</script>");
                        Session["username"] = dr.GetValue(9).ToString();
                        Session["fullname"]= dr.GetValue(1).ToString();
                        Session["role"] = "user";
                        Session["status"]= dr.GetValue(11).ToString();
                    }
                    Response.Redirect("homepage.aspx");

                }
                else
                {
                    Response.Write("<script>alert('Invalid Credentials ');</script>");
                }
            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('"+ex.Message+" ');</script>");
            }
        }
    }
}