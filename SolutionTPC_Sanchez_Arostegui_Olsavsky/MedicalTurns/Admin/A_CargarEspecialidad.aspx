<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/A_Structure.Master" AutoEventWireup="true" CodeBehind="A_CargarEspecialidad.aspx.cs" Inherits="MedicalTurns.A_CargarEspecialidad" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



        <body>

            <div class="main-container">

                <h2>CARGAR ESPECIALIDAD</h2>
                <div class="container generic-form">

                    <asp:TextBox ID="Especialidad" placeholder="Especialidad" MaxLength="100" runat="server" required ClientIDMode="Static"></asp:TextBox>

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

                           <% foreach (dominio.Especialidad item in lista)
                               { %>

                                   <tr>
                                       <td><% = item.Nombre %></td>
                                       <td>
                                            <a href="A_CargarEspecialidad.aspx?ID=<% = item.ID %>"><i class="far fa-edit"></i></a>
                                       </td>
                                   </tr>

                           <% } %>
                       </table>
                   </section>

        </body>
</asp:Content>