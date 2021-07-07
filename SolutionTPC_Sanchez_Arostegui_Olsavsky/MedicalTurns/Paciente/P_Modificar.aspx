<%@ Page Title="" Language="C#" MasterPageFile="~/Paciente/P_Structure.Master" AutoEventWireup="true" CodeBehind="P_Modificar.aspx.cs" Inherits="MedicalTurns.P_Modificar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <body>
             <div class="main-container">

                <div class="form-container">
                    <h2>MODIFICAR PACIENTE</h2>

                    <div class="generic-form row contanier">

                        
                        <asp:TextBox CssClass="m-auto col-sm-12 col-md-4 col-lg-3 p-1" ID="Nombre" placeholder="Name" type="text" required MaxLength="100" runat="server" ClientIDMode="Static"></asp:TextBox>
                        <asp:TextBox ID="Apellido" CssClass="m-auto col-sm-12 col-md-4 col-lg-3 p-1" placeholder="Second name" MaxLength="100" type="text" runat="server" required ClientIDMode="Static"></asp:TextBox>
                        <asp:TextBox ID="Nacimiento" CssClass="m-auto col-sm-12 col-md-4 col-lg-3 p-1" placeholder="Birth date" type="date" runat="server" ClientIDMode="Static"></asp:TextBox>
                        <asp:DropDownList ID="Genero" CssClass="m-auto col-sm-12 col-md-4 col-lg-3 p-1" runat="server" ClientIDMode="Static">
                            <asp:ListItem Text="M" Value="M"></asp:ListItem>
                            <asp:ListItem Text="F" Value="F"></asp:ListItem>
                            <asp:ListItem Text="O" Value="O"></asp:ListItem>
                        </asp:DropDownList>

                        <asp:DropDownList ID="ObraSocial" CssClass="m-auto col-sm-12 col-md-4 col-lg-3 p-1" runat="server" ClientIDMode="Static"></asp:DropDownList>
                        <asp:TextBox ID="Email" CssClass="m-auto col-sm-12 col-md-4 col-lg-3 p-1" placeholder="Email" type="email" required MaxLength="250" runat="server" ClientIDMode="Static"></asp:TextBox>
                        <asp:TextBox ID="Domicilio" CssClass="m-auto col-sm-12 col-md-4 col-lg-3 p-1" placeholder="Adress" type="text" MaxLength="250" runat="server" required ClientIDMode="Static"></asp:TextBox>
                        <asp:TextBox ID="Contrasena" CssClass="m-auto col-sm-12 col-md-4 col-lg-3 p-1" placeholder="Contaseña" MaxLength="30" runat="server" ClientIDMode="Static"></asp:TextBox>
                        <asp:TextBox ID="Celular" CssClass="m-auto col-sm-12 col-md-4 col-lg-3 p-1" placeholder="Phone" MaxLength="50" type="number" runat="server" required ClientIDMode="Static"></asp:TextBox>
                        <asp:TextBox ID="Afiliado" CssClass="m-auto col-sm-12 col-md-4 col-lg-3 p-1" placeholder="Credential number" MaxLength="40" type="number" runat="server" required ClientIDMode="Static"></asp:TextBox>

                        <asp:Button ID="BtnModificar" CssClass="col-sm-8 col-md-4 m-auto mt-3" runat="server" Text="Modificar" OnClientClick="return validateForm()" type="submit" OnClick="BtnModificar_Click"/>     

                    </div>
                </div>

            </div>

        </body>

</asp:Content>
