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
    public partial class adminusermanagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["DbUserManagement"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }
        //Go Button
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            getUserById();

        }
        //Active Button
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            UpdateUserStatusByID("Active");
        }
        //Pending Button
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            UpdateUserStatusByID("Pending");
        }
        //Deactive button
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            UpdateUserStatusByID("Deactive");
        }
        //Delete User Permanantly
        protected void Button2_Click(object sender, EventArgs e)
        {
            deleteUserByID();
        }

        //user Defined Function

        bool CheckIfUserExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                //SqlCommand cmd = new SqlCommand("USP_tbl_UserMaster_InsertUser", con);
                SqlCommand cmd = new SqlCommand("SELECT * from tbl_UserMaster where user_id = '" + TextBox1.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }              
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + " ');</script>");
                return false;
            }
        }


        void getUserById()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("USP_UserMasterGetaDataByID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@user_id", TextBox1.Text.Trim());
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        TextBox2.Text = dr.GetValue(1).ToString();
                        TextBox7.Text = dr.GetValue(11).ToString();
                        TextBox8.Text = dr.GetValue(2).ToString();
                        TextBox3.Text = dr.GetValue(3).ToString();
                        TextBox4.Text = dr.GetValue(4).ToString();
                        TextBox9.Text = dr.GetValue(5).ToString();
                        TextBox10.Text = dr.GetValue(6).ToString();
                        TextBox11.Text = dr.GetValue(7).ToString();
                        TextBox6.Text = dr.GetValue(8).ToString();
                    }


                }
                else
                {
                    Response.Write("<script>alert('Invalid User ID ');</script>");
                }
            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('" + ex.Message + " ');</script>");
            }

        }
        void UpdateUserStatusByID(string status)
        {
            if (CheckIfUserExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("USP_UserMasterUpdateStatusByID", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@user_id", TextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@account_status", status);
                    //SqlCommand cmd = new SqlCommand("UPDATE tbl_UserMaster SET account_status='" + status + "' where user_id='" + TextBox1.Text.Trim() + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();
                    clearForm();
                    Response.Write("<script>alert('User Status Updated');</script>");
                }
                catch (Exception ex)
                {

                    Response.Write("<script>alert('" + ex.Message + " ');</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('Invalid User Id');</script>");
            }
            

        }
        void deleteUserByID()
        {
            if (CheckIfUserExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("USP_UserMasterDeleteUserByID", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@user_id", TextBox1.Text.Trim());
                    cmd.ExecuteNonQuery();
                    GridView1.DataBind();
                    clearForm();
                    Response.Write("<script>alert('User Deleted');</script>");


                }
                catch (Exception ex)
                {

                    Response.Write("<script>alert('" + ex.Message + " ');</script>");
                }
               

            }
            else
            {
                Response.Write("<script>alert('Invalid User Id');</script>");
            }

        }
        void clearForm()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox9.Text = "";
            TextBox10.Text = "";
            TextBox11.Text = "";
            TextBox6.Text = "";
        }
    }
}  