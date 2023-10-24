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
    public partial class usersignup : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["DbUserManagement"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btn_User_signup_Click(object sender, EventArgs e)
        {
            if (CheckUserExists()) 
            {
                Response.Write("<script>alert('User Id already Exists Please Enter Another Id ');</script>");
            }
            else 
            {
                signUpNewUser();
            }
           


        }

        bool CheckUserExists() 
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                //SqlCommand cmd = new SqlCommand("USP_tbl_UserMaster_InsertUser", con);
                SqlCommand cmd = new SqlCommand("SELECT * from tbl_UserMaster where user_id = '"+txtuser_id.Text.Trim()+ "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count>=1)
                {
                    return true;
                }
                else
                {
                    return false;
                }              
                con.Close();
                Response.Write("<script>alert('User Registered Successfully ');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + " ');</script>");
                return false;
            }            
        }
        //User defined  method
        void signUpNewUser() 
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("USP_tbl_UserMaster_InsertUser", con);
                //SqlCommand cmd = new SqlCommand("insert into tbl_UserMaster(uname,udob,contact,uemail,ustate,ucity,pincode,ufull_address,user_id,password,account_status)values(@uname,@udob,@contact,@uemail,@ustate,@ucity,@pincode,@ufull_address,@user_id,@password,@account_status)", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@uname", txtuname.Text.Trim());
                cmd.Parameters.AddWithValue("@udob", txtudob.Text.Trim());
                cmd.Parameters.AddWithValue("@contact", txtcontact.Text.Trim());
                cmd.Parameters.AddWithValue("@uemail", txtuemail.Text.Trim());
                cmd.Parameters.AddWithValue("@ustate", ddlustate.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@ucity", txtucity.Text.Trim());
                cmd.Parameters.AddWithValue("@pincode", txtpincode.Text.Trim());
                cmd.Parameters.AddWithValue("@ufull_address", txtufull_address.Text.Trim());
                cmd.Parameters.AddWithValue("@user_id", txtuser_id.Text.Trim());
                cmd.Parameters.AddWithValue("@password", txtpassword.Text.Trim());
                cmd.Parameters.AddWithValue("@account_status", "Pending");
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('User Registered Successfully ');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + " ');</script>");

            }
        }
    }
}