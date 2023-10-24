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
    public partial class adminlogin : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["DbUserManagement"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnadminlogin_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("USP_tbl_Admin", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AdminUserId", txtadminid.Text.Trim());
                cmd.Parameters.AddWithValue("@AdminPass", txtAdminpassword.Text.Trim());
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Response.Write("<script>alert('Admin Login Successfully');</script>");
                        Session["username"] = dr.GetValue(0).ToString();
                        Session["fullname"] = dr.GetValue(2).ToString();
                        Session["role"] = "admin";
                        //Session["status"] = dr.GetValue(11).ToString();
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

                Response.Write("<script>alert('" + ex.Message + " ');</script>");
            }
        }
    }
}