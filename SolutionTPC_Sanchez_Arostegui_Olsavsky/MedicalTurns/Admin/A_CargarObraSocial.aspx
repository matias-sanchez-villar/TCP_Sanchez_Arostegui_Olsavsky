<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/A_Structure.Master" AutoEventWireup="true" CodeBehind="A_CargarObraSocial.aspx.cs" Inherits="MedicalTurns.A_CargarObraSocial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


        <body>

           <div class="main-container">

            <h2>CARGAR OBRA SOCIAL</h2>
               <div class="container generic-form">

               <asp:TextBox ID="ObraSocial" placeholder="Obra Social" MaxLength="100" runat="server" required ClientIDMode="Static"></asp:TextBox>
               
               <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />

            </div>
          </div>


            <section class="table-container">

                <div class="table-title-container">
                    <h3>Especialidades</h3>
                    <hr />
                </div>

                <table id="data-table" style="width: 100%;">
                    <thead>
                        <tr>
                            <th>Name</th>
                            <th>Actions</th>
                        </tr>
                    </thead>

                    <% foreach (dominio.ObraSocial item in lista)
                        { %>

                    <tr>
                        <td><% = item.Nombre %></td>
                        <td>
                            <a href="A_CargarObraSocial.aspx?ID=<% = item.ID %>"><i class="fas fa-trash-alt"></i></a>
                        </td>
                    </tr>

                    <% } %>
                </table>
            </section>


        </body>
</asp:Content>
