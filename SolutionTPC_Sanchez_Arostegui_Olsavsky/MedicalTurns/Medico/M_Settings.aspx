<%@ Page Title="" Language="C#" MasterPageFile="~/Medico/M_Structure.Master" AutoEventWireup="true" CodeBehind="M_Settings.aspx.cs" Inherits="MedicalTurns.M_Settings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <body>

             <div class="main-container">

                <div class="form-container">
                    <h2>SETTINGS</h2>
                    <hr />

                    <div class="generic-form row contanier">

                        <asp:TextBox ID="Email" CssClass="m-auto col-sm-8 p-1" placeholder="Email" type="email" required MaxLength="250" runat="server" ClientIDMode="Static"></asp:TextBox>
                        <asp:TextBox ID="Contrasena" CssClass="m-auto col-sm-8 p-1" placeholder="Current password" MaxLength="30" runat="server" ClientIDMode="Static"></asp:TextBox>
                        <asp:TextBox ID="nuevaContrasena" CssClass="m-auto col-sm-8 p-1" placeholder="New Password" MaxLength="30" runat="server" ClientIDMode="Static"></asp:TextBox>
                        <asp:Button ID="BtnModificar" CssClass="col-sm-8 col-md-4 m-auto mt-3 BtnSubmit" runat="server" Text="Update settings" OnClientClick="return validateForm()" type="submit" />    

                    </div>
                </div>

            </div>

        </body>

</asp:Content>
