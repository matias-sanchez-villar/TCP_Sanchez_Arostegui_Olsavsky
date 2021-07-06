<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/A_Structure.Master" AutoEventWireup="true" CodeBehind="A_Dashboard.aspx.cs" Inherits="MedicalTurns.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>




<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div class="main-container">


        <%-- Banner con recuentos de covid --%>


        <%-- 2 o 4 trajetas con informacion --%>


        <section class="container table-container">
                <table  id="data-table" style="width: 100%;">
                    <thead>
                        <tr>
                            <th>Nombre</th>
                            <th>N° Matrícula</th>
                            <th>ID Especialidad</th>
                            <th>Mail</th>
                        </tr>
                    </thead>

                  <% foreach (dominio.Medico item in listaMedicos){ %>

                        <tr>
                            <td><% = item.Apellido %>,<% = item.Nombre %></td>
                            <td><% = item.Matricula %></td>
                            <td><% = item.especialidad.Nombre %></td>
                            <td><% = item.Usuario.Email %></td>
                        </tr>

                    <% } %>

                </table>
        </section>

        <section class="container table-container">

                <table  id="data-table2" style="width: 100%;">
                    <thead>
                        <tr>
                            <th>Nombre</th>
                            <th>N° Matrícula</th>
                            <th>ID Especialidad</th>
                            <th>Actions</th>
                        </tr>
                    </thead>

                  <% foreach (dominio.Paciente item in listaPaciente){ %>

                        <tr>
                            <td><% = item.Apellido %>,<% = item.Nombre %></td>
                            <td><% = String.Format("{0:yyyy-MM-dd}", item.FechaNacimiento) %></td>
                            <td><% = item.Usuario.Email %></td>
                            <td>
                                <a href="A_ModificarPaciente.aspx?ID=<% = item.ID %>"><i class="far fa-edit"></i></a>
                                <a href="A_EliminarPaciente.aspx?ID=<% = item.ID %>"><i class="fas fa-trash-alt"></i></a>

                            </td>
                        </tr>

                    <% } %>

                </table>

        </section>

    </div>




</asp:Content>
