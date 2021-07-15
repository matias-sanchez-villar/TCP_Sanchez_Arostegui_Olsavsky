<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login_admin.aspx.cs" Inherits="MedicalTurns.Login_admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Mediturns | Login</title>

    <link href="Styles/bootstrap-grid.css" rel="stylesheet" />
    <link rel="stylesheet" runat="server" href="Styles/Master.css" />
    <link rel="stylesheet" runat="server" href="Styles/Generic_login.css" />
</head>
<body>
    <form id="form1" runat="server">

        <h1>Mediturns</h1>
        <div class="formcontainer">
            <div class="container">
                <label for="uname"><strong>Username</strong></label>
                <input type="text" placeholder="Enter Username" name="uname" required>

                <label for="psw"><strong>Password</strong></label>
                <input type="password" placeholder="Enter Password" name="psw" required>
            </div>

            <asp:Button ID="Button1" runat="server" Text="Login" type="submit" />

            <div class="container">
                <span style="text-align: center;"><a href="#">Forgot password?</a></span>
            </div>

    </form>
</body>
</html>
