<%@ Page Title="" Language="C#" MasterPageFile="~/M_Structure.Master" AutoEventWireup="true" CodeBehind="M_Modificar.aspx.cs" Inherits="MedicalTurns.M_Modificar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <body>

           <div class="main-container">

            <h2>MODIFICAR MEDICO</h2>
               <div class="container generic-form">

               <asp:TextBox ID="Nombre" MaxLength="100" runat="server" required ClientIDMode="Static"></asp:TextBox>
               <asp:TextBox ID="Apellido" MaxLength="100" runat="server" required ClientIDMode="Static"></asp:TextBox>
               <asp:TextBox ID="Nacimiento" type="date" runat="server" required ClientIDMode="Static"></asp:TextBox>
               <asp:DropDownList ID="Genero" runat="server" ClientIDMode="Static">
                    <asp:listitem text="M" value="M"></asp:listitem>
                    <asp:listitem text="F" value="F"></asp:listitem>
                    <asp:listitem text="O" value="O"></asp:listitem>
               </asp:DropDownList>

               <asp:DropDownList ID="Especialidad" runat="server" ClientIDMode="Static"></asp:DropDownList>
               <asp:TextBox ID="Email" MaxLength="250" runat="server" required ClientIDMode="Static"></asp:TextBox>
               <asp:TextBox ID="Contrasena" placeholder="Contaseña" MaxLength="30" runat="server" required ClientIDMode="Static"></asp:TextBox>
               <asp:TextBox ID="Domicilio" MaxLength="250" runat="server" required ClientIDMode="Static"></asp:TextBox>
               <asp:TextBox ID="Celular" MaxLength="50" type="number" runat="server" required ClientIDMode="Static"></asp:TextBox>
               <asp:TextBox ID="Matricula" MaxLength="40" type="number" runat="server" required ClientIDMode="Static"></asp:TextBox>
               
         
               <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClientClick="return patientValidations()" type="submit" OnClick="btnModificar_Click"/>   
            </div>
          </div>

     </body>

</asp:Content>
