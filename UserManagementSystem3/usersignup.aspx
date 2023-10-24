<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="usersignup.aspx.cs" Inherits="UserManagementSystem3.usersignup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
      <div class="row">
         <div class="col-md-8 mx-auto">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <img width="100px" src="imgs/generaluser.png"/>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>User Registration Form</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                   <div class="row">
                     <div class="col-md-6">
                       <label>Full Name:</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="txtuname" runat="server" placeholder="Full Name:"></asp:TextBox>
                        </div>
                     </div>
                        <div class="col-md-6">
                       <label>Date of Birth:</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="txtudob" runat="server" placeholder="Date Of Birth" TextMode="Date"></asp:TextBox>
                        </div>
                     </div>
                  </div>

                    <div class="row">
                     <div class="col-md-6">
                       <label>Contact No.:</label>
                        <div class="form-group">
                           <asp:TextBox Class="form-control" ID="txtcontact" runat="server" placeholder="Contact No.:" TextMode="Number"></asp:TextBox>
                        </div>
                     </div>
                        <div class="col-md-6">
                       <label>Email Id:</label>
                        <div class="form-group">
                           <asp:TextBox Class="form-control" ID="txtuemail" runat="server" placeholder="Email Id" TextMode="Email"></asp:TextBox>
                        </div>
                     </div>
                  </div>

                   <div class="row">
                     <div class="col-md-4">
                       <label>State.:</label>
                        <div class="form-group">
                            <asp:DropDownList class="form-control" ID="ddlustate" runat="server">
                              <asp:ListItem Text="Select" Value="select" />
                              <asp:ListItem Text="Andhra Pradesh" Value="Andhra Pradesh" />
                              <asp:ListItem Text="Arunachal Pradesh" Value="Arunachal Pradesh" />
                              <asp:ListItem Text="Assam" Value="Assam" />
                              <asp:ListItem Text="Bihar" Value="Bihar" />
                              <asp:ListItem Text="Chhattisgarh" Value="Chhattisgarh" />
                              <asp:ListItem Text="Rajasthan" Value="Rajasthan" />
                              <asp:ListItem Text="Goa" Value="Goa" />
                              <asp:ListItem Text="Gujarat" Value="Gujarat" />
                              <asp:ListItem Text="Haryana" Value="Haryana" />
                              <asp:ListItem Text="Himachal Pradesh" Value="Himachal Pradesh" />
                              <asp:ListItem Text="Jammu and Kashmir" Value="Jammu and Kashmir" />
                              <asp:ListItem Text="Jharkhand" Value="Jharkhand" />
                              <asp:ListItem Text="Karnataka" Value="Karnataka" />
                              <asp:ListItem Text="Kerala" Value="Kerala" />
                              <asp:ListItem Text="Madhya Pradesh" Value="Madhya Pradesh" />
                              <asp:ListItem Text="Maharashtra" Value="Maharashtra" />
                              <asp:ListItem Text="Manipur" Value="Manipur" />
                              <asp:ListItem Text="Meghalaya" Value="Meghalaya" />
                              <asp:ListItem Text="Mizoram" Value="Mizoram" />
                              <asp:ListItem Text="Nagaland" Value="Nagaland" />
                              <asp:ListItem Text="Odisha" Value="Odisha" />
                              <asp:ListItem Text="Punjab" Value="Punjab" />
                              <asp:ListItem Text="Rajasthan" Value="Rajasthan" />
                              <asp:ListItem Text="Sikkim" Value="Sikkim" />
                              <asp:ListItem Text="Tamil Nadu" Value="Tamil Nadu" />
                              <asp:ListItem Text="Telangana" Value="Telangana" />
                              <asp:ListItem Text="Tripura" Value="Tripura" />
                              <asp:ListItem Text="Uttar Pradesh" Value="Uttar Pradesh" />
                              <asp:ListItem Text="Uttarakhand" Value="Uttarakhand" />
                              <asp:ListItem Text="West Bengal" Value="West Bengal" />
                           </asp:DropDownList>
                        </div>
                     </div>
                        <div class="col-md-4">
                       <label>City:</label>
                        <div class="form-group">
                           <asp:TextBox Class="form-control" ID="txtucity" runat="server" placeholder="City"></asp:TextBox>
                        </div>
                     </div>
                       <div class="col-md-4">
                       <label>Pincode:</label>
                        <div class="form-group">
                           <asp:TextBox Class="form-control" ID="txtpincode" runat="server" placeholder="Pincode" TextMode="Number"></asp:TextBox>
                        </div>
                     </div>
                  </div>

                   <div class="row">
                     <div class="col">
                       <label>Full Address.:</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="txtufull_address" runat="server" placeholder="Contact No.:" TextMode="MultiLine" Rows="2"></asp:TextBox>
                        </div>
                     </div>                       
                  </div>


                   <div class="row">
                     <div class="col">
                        <center>
                           <span class="badge badge-pill badge-info">Login Credentials</span>
                        </center>
                     </div>
                  </div>
                   <div class="row">
                     <div class="col-md-6">
                       <label>User Id:</label>
                        <div class="form-group">
                           <asp:TextBox Class="form-control" ID="txtuser_id" runat="server" placeholder="User Id"></asp:TextBox>
                        </div>
                     </div>
                        <div class="col-md-6">
                       <label>Password:</label>
                        <div class="form-group">
                           <asp:TextBox Class="form-control" ID="txtpassword" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                        </div>
                     </div>
                  </div>



                  <div class="row">
                     <div class="col">
                        
                        
                        <div class="form-group">
                           <asp:Button class="btn btn-success btn-block btn-lg" ID="btn_User_signup" runat="server" Text="Sign Up" OnClick="btn_User_signup_Click" />
                        </div>
                       
                     </div>
                  </div>
               </div>
            </div>
            <a href="homepage.aspx"><< Back to Home</a><br><br>
         </div>
      </div>
   </div>

</asp:Content>
