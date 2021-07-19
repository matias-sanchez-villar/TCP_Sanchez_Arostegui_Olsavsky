<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="LoginDef.aspx.cs" Inherits="MedicalTurns.LoginDef" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
            <link href="Styles/bootstrap-grid.css" rel="stylesheet" />
        <link rel="stylesheet" runat="server" href="Styles/Master.css" />
        <link rel="stylesheet" runat="server" href="Styles/Generic_login.css" />
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <section class="login-container">
        <div class="column">

            <div class="form">

                <div class="image-container">
                    <img src="Assets/Doctor.svg" />
                </div>

                <h1>Mediturns</h1>
                <div class="formcontainer">
                    <div class="container">
                        <label for="uname"><strong>Username</strong></label>
                        <asp:TextBox ID="emailInput" runat="server" type="text" placeholder="Enter Username" name="uname" required></asp:TextBox>

                        <label for="psw"><strong>Password</strong></label>
                        <asp:TextBox ID="passwordInput" runat="server" type="password" placeholder="Enter Password" name="psw" required></asp:TextBox>

                    </div>

                    <asp:Button cssClass="btn-submit" id="submitButton" runat="server" Text="Login" OnClick="submitButton_Click" />


                    <div class="container">
                        <span style="text-align: center;"><a href="#">Forgot password?</a></span>
                    </div>
            </div>
        </div>
    </section>


</asp:Content>
