<%@ Page Title="" Language="C#" MasterPageFile="~/P_Structure.Master" AutoEventWireup="true" CodeBehind="P_Modificar.aspx.cs" Inherits="MedicalTurns.P_Modificar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <body>

           <div class="main-container">

            <h2>MODIFICAR PACIENTE</h2>
               <div class="container generic-form">

               <asp:TextBox ID="Nombre" MaxLength="100" runat="server" required ClientIDMode="Static"></asp:TextBox>
               <asp:TextBox ID="Apellido" MaxLength="100" runat="server" required ClientIDMode="Static"></asp:TextBox>
               <asp:TextBox ID="Nacimiento" type="date" runat="server" required ClientIDMode="Static"></asp:TextBox>
               <asp:DropDownList ID="Genero" runat="server" ClientIDMode="Static">
                    <asp:listitem text="M" value="M"></asp:listitem>
                    <asp:listitem text="F" value="F"></asp:listitem>
                    <asp:listitem text="O" value="O"></asp:listitem>
               </asp:DropDownList>
                
               <asp:DropDownList ID="ObraSocial" runat="server" ClientIDMode="Static"></asp:DropDownList>
               <asp:TextBox ID="Email" MaxLength="250" runat="server" required ClientIDMode="Static"></asp:TextBox>
               <asp:TextBox ID="Contrasena" placeholder="Contaseña" MaxLength="30" runat="server" required ClientIDMode="Static"></asp:TextBox>
               <asp:TextBox ID="Domicilio" MaxLength="250" runat="server" required ClientIDMode="Static"></asp:TextBox>
               <asp:TextBox ID="Celular" MaxLength="50" type="number" runat="server" required ClientIDMode="Static"></asp:TextBox>
               <asp:TextBox ID="Afiliado" MaxLength="40" type="number" runat="server" required ClientIDMode="Static"></asp:TextBox>
               
               <asp:Button ID="BtnModificar" runat="server" Text="Modificar" OnClientClick="return patientValidations()" type="submit" OnClick="BtnModificar_Click"/>     
            </div>
          </div>

        </body>

</asp:Content>
