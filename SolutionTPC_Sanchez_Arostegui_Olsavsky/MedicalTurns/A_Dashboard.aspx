<%@ Page Title="" Language="C#" MasterPageFile="~/A_Structure.Master" AutoEventWireup="true" CodeBehind="A_Dashboard.aspx.cs" Inherits="MedicalTurns.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>




<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div class="main-container">


        <%-- Banner con recuentos de covid --%>


        <%-- 2 o 4 trajetas con informacion --%>

        <%-- Traer turnos del paciente --%>
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

                  <% foreach (dominio.Medico item in listaMedicos){ %>

                        <tr>
                            <td><% = item.Apellido %>,<% = item.Nombre %></td>
                            <td><% = item.Matricula %></td>
                            <td><% = item.Especialidad %></td>
                            <td><% = item.Usuario.Email %></td>
                        </tr>

                    <% } %>

                </table>

            <asp:Button ID="Button1" runat="server" Text="Cargar médico" />

        </section>

    </div>




</asp:Content>
