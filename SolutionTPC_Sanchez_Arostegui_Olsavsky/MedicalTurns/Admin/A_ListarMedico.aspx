<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/A_Structure.Master" AutoEventWireup="true" CodeBehind="A_ListarMedico.aspx.cs" Inherits="MedicalTurns.A_ListarMedico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="container">
                <table  id="data-table" style="width: 100%;">
                    <thead>
                        <tr>
                            <th>Nombre</th>
                            <th>N° Matrícula</th>
                            <th>ID Especialidad</th>
                            <th>Mail</th>
                        </tr>
                    </thead>

                  <% foreach (dominio.Medico item in lista){ %>

                        <tr>
                            <td><% = item.Apellido %>,<% = item.Nombre %></td>
                            <td><% = String.Format("{0:yyyy-MM-dd}", item.FechaNacimiento) %></td>
                            <td><% = item.Usuario.Email %></td>
                            <td><a href="A_Modificar.aspx?ID=<% = item.ID %>">Modificar</a></td>
                        </tr>

                    <% } %>

                </table>
        </section>

</asp:Content>
