using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserManagementSystem3
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["role"].Equals(""))
                {
                    btnuserlogin.Visible = true;
                    btnsignup.Visible = true;
                    btnlogout.Visible = false;
                    btnhellouser.Visible = false;
                    btnadminlogin.Visible = true; // admin login
                    LinkButton1.Visible = false;//Admin User Management
                }
                else if (Session["role"].Equals("user")) 
                {
                    btnuserlogin.Visible = false;
                    btnsignup.Visible = false;
                    btnlogout.Visible = true;
                    btnhellouser.Visible = true;
                    btnhellouser.Text = "Hello" + Session["username"].ToString();

                    btnadminlogin.Visible = false; // admin login
                    LinkButton1.Visible = false;//Admin User Management
                }

                else if (Session["role"].Equals("admin"))
                {
                    btnuserlogin.Visible = false;
                    btnsignup.Visible = false;
                    btnlogout.Visible = true;
                    btnhellouser.Visible = true;
                    btnhellouser.Text = "Hello Admin";

                    btnadminlogin.Visible = false; // admin login
                    LinkButton1.Visible = true;//Admin User Management
                }



            }
            catch (Exception ex)
            {

                
            }

        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminlogin.aspx");
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminusermanagement.aspx");
        }

        protected void btnuserlogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("userlogin.aspx");
            
        }

        protected void btnsignup_Click(object sender, EventArgs e)
        {
            Response.Redirect("usersignup.aspx");
        }

        protected void btnlogout_Click(object sender, EventArgs e)
        {
            
            Session["username"] = "";
            Session["fullname"] = "";
            Session["role"] = "";
            Session["status"] = "";

            btnuserlogin.Visible = true;
            btnsignup.Visible = true;
            btnlogout.Visible = false;
            btnhellouser.Visible = false;
            btnadminlogin.Visible = true; // admin login
            LinkButton1.Visible = false;//Admin User Management
            Response.Write("<script>alert('Logout Successfully');</script>");
        }
    }
    }
