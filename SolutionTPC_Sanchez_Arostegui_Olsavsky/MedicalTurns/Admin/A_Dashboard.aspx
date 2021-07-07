<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/A_Structure.Master" AutoEventWireup="true" CodeBehind="A_Dashboard.aspx.cs" Inherits="MedicalTurns.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>




<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div class="main-container">


        <%-- Banner con recuentos de covid --%>


        <%-- 2 o 4 trajetas con informacion --%>


        <section class="table-container">

            <div class="table-title-container">
                <h3>Doctors</h3>
                <hr />
            </div>

                <table  id="data-table" style="width: 100%;">
                    <thead>
                        <tr>
                            <th>Name</th>
                            <th>Certification number</th>
                            <th>Specialty</th>
                            <th>Actions</th>
                        </tr>
                    </thead>

                  <% foreach (dominio.Medico item in listaMedicos){ %>

                        <tr>
                            <td><% = item.Apellido %>,<% = item.Nombre %></td>
                            <td><% = item.Matricula %></td>
                            <td><% = item.especialidad.Nombre %></td>
                            <td>
                                <a href="A_ModificarMedico.aspx?ID=<% = item.ID %>"><i class="far fa-edit"></i></a>
                                <a href="A_Dashboard.aspx?ID=<% = item.ID %>&eliminarMedico=true"><i class="fas fa-trash-alt"></i></a>
                            </td>
                        </tr>

                    <% } %>

                </table>
        </section>

        <section class="table-container">

            <div class="table-title-container">
                <h3>Patients</h3>
                <hr />
            </div>


                <table  id="data-table2" style="width: 100%;">
                    <thead>
                        <tr>
                            <th>Name</th>
                            <th>Birth date</th>
                            <th>Email</th>
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
                                <a href="A_Dashboard.aspx?ID=<% = item.ID %>&eliminarPaciente=true"><i class="fas fa-trash-alt"></i></a>
                            </td>
                        </tr>

                    <% } %>

                </table>

        </section>

    </div>




</asp:Content>
