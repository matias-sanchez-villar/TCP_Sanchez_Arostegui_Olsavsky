<%@ Page Title="" Language="C#"  AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MedicalTurns.Login" %>

<asp:Content ContentPlaceHolderID="head">
    <link href="Styles/bootstrap-grid.css" rel="stylesheet" />
    <link rel="stylesheet" runat="server" href="Styles/Master.css" />
    <link rel="stylesheet" runat="server" href="Styles/Generic_login.css" />
</asp:Content>

<asp:PlaceHolder runat="server" ID="PlaceHolder1">
    <section class="login-container">
        <div class="row">

            <form action="">
                <h1>Mediturns</h1>
                <div class="formcontainer">
                    <div class="container">
                        <label for="uname"><strong>Username</strong></label>
                        <input type="text" placeholder="Enter Username" name="uname" required>

                        <label for="psw"><strong>Password</strong></label>
                        <input type="password" placeholder="Enter Password" name="psw" required>
                    </div>
                    <button type="submit" >Login</button>
                    <div class="container">
                        <span style="text-align: center;"><a href="#">Forgot password?</a></span>
                    </div>
            </form>
        </div>

    </section>
</asp:PlaceHolder>


