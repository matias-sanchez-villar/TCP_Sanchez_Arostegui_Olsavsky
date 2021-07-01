<%@ Page Title="" Language="C#" MasterPageFile="~/A_Structure.Master" AutoEventWireup="true" CodeBehind="A_CargarPaciente.aspx.cs" Inherits="MedicalTurns.A_CargarPaciente" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <body>

           <div class="main-container">

            <h2>CARGAR PACIENTE</h2>
               <div class="container generic-form">

               <asp:TextBox ID="Nombre" placeholder="Name" MaxLength="100" runat="server" required ClientIDMode="Static"></asp:TextBox>
               <asp:TextBox ID="Apellido" placeholder="Second name" MaxLength="100" runat="server" required ClientIDMode="Static"></asp:TextBox>
               <asp:TextBox ID="Nacimiento" placeholder="Birth date" type="date" runat="server" required ClientIDMode="Static"></asp:TextBox>
               <asp:DropDownList ID="Genero" runat="server" ClientIDMode="Static">
                    <asp:listitem text="M" value="M"></asp:listitem>
                    <asp:listitem text="F" value="F"></asp:listitem>
                    <asp:listitem text="O" value="O"></asp:listitem>
               </asp:DropDownList>

               <asp:DropDownList ID="ObraSocial" runat="server" ClientIDMode="Static"></asp:DropDownList>
               <asp:TextBox ID="Email" placeholder="Email" MaxLength="250" runat="server" required ClientIDMode="Static"></asp:TextBox>
               <asp:TextBox ID="Domicilio" placeholder="Adress" MaxLength="250" runat="server" required ClientIDMode="Static"></asp:TextBox>
               <asp:TextBox ID="Celular" placeholder="Phone" MaxLength="50" type="number" runat="server" required ClientIDMode="Static"></asp:TextBox>
               <asp:TextBox ID="Afiliado" placeholder="Credential number" MaxLength="40" type="number" runat="server" required ClientIDMode="Static"></asp:TextBox>
               
         
               <asp:Button ID="BtnSubmit" OnClientClick="return patientValidations()" runat="server" Text="Create patient" type="submit" OnClick="BtnSubmit_Click" />        
            </div>
          </div>

        </body>
       
</asp:Content>
