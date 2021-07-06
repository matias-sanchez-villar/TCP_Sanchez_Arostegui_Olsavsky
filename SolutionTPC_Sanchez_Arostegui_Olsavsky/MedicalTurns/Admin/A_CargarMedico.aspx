<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/A_Structure.Master" AutoEventWireup="true" CodeBehind="A_CargarMedico.aspx.cs" Inherits="MedicalTurns.A_CargarMedico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <body>

         <div class="main-container">

             <div class="form-container">
                 <h2>UPLOAD DOCTOR</h2>

                 <div class="generic-form row contanier">

                     <asp:TextBox ID="TextBox8" CssClass="m-auto col-sm-12 col-md-4 col-lg-3 p-1" placeholder="Name" MaxLength="100" runat="server" required ClientIDMode="Static"></asp:TextBox>
                     <asp:TextBox ID="TextBox9" CssClass="m-auto col-sm-12 col-md-4 col-lg-3 p-1" placeholder="Second name" MaxLength="100" runat="server" required ClientIDMode="Static"></asp:TextBox>
                     <asp:TextBox ID="TextBox10" CssClass="m-auto col-sm-12 col-md-4 col-lg-3 p-1" placeholder="Birth date" type="date" runat="server" required ClientIDMode="Static"></asp:TextBox>
                     <asp:DropDownList ID="DropDownList3" CssClass="m-auto col-sm-12 col-md-4 col-lg-3 p-1" runat="server" ClientIDMode="Static">
                         <asp:ListItem Text="M" Value="M"></asp:ListItem>
                         <asp:ListItem Text="F" Value="F"></asp:ListItem>
                         <asp:ListItem Text="O" Value="O"></asp:ListItem>
                     </asp:DropDownList>

                     <asp:TextBox ID="TextBox11" CssClass="m-auto col-sm-12 col-md-4 col-lg-3 p-1" placeholder="Email" MaxLength="250" runat="server" required ClientIDMode="Static"></asp:TextBox>
                     <asp:TextBox ID="TextBox12" CssClass="m-auto col-sm-12 col-md-4 col-lg-3 p-1" placeholder="Adress" MaxLength="250" runat="server" required ClientIDMode="Static"></asp:TextBox>
                     <asp:TextBox ID="TextBox13" CssClass="m-auto col-sm-12 col-md-4 col-lg-3 p-1" placeholder="Phone" MaxLength="50" type="number" runat="server" required ClientIDMode="Static"></asp:TextBox>
                     <asp:TextBox ID="TextBox14" CssClass="m-auto col-sm-12 col-md-4 col-lg-3 p-1" placeholder="Registration number" MaxLength="40" type="number" runat="server" required ClientIDMode="Static"></asp:TextBox>
                     <div class="m-auto col-sm-12 col-md-4 col-lg-3 p-1"></div>

                     <asp:Button ID="BtnSubmit" CssClass="col-sm-8 col-md-3 mt-3 m-auto" OnClientClick="return patientValidations()" runat="server" Text="Create medic" type="submit" OnClick="BtnSubmit_Click" />


                 </div>
             </div>

         </div>

        </body>
       
</asp:Content> 

