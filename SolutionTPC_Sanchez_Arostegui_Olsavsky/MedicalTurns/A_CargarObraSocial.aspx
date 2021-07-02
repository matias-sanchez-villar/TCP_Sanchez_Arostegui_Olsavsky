<%@ Page Title="" Language="C#" MasterPageFile="~/A_Structure.Master" AutoEventWireup="true" CodeBehind="A_CargarObraSocial.aspx.cs" Inherits="MedicalTurns.A_CargarObraSocial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


        <body>

           <div class="main-container">

            <h2>CARGAR OBRA SOCIAL</h2>
               <div class="container generic-form">

               <asp:TextBox ID="ObraSocial" placeholder="Obra Social" MaxLength="100" runat="server" required ClientIDMode="Static"></asp:TextBox>
               
                   <asp:Button ID="Button1" runat="server" Text="Button" />
                       
                    
            </div>
          </div>

        </body>
</asp:Content>
