<%@ Page Title="" Language="C#" MasterPageFile="~/P_Structure.Master" AutoEventWireup="true" CodeBehind="P_Dashboard.aspx.cs" Inherits="MedicalTurns.Dashboard" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<%--    <link href="Styles/bootstrap-grid.css" rel="stylesheet" />
    <link href="Styles/Generic_dashboard.css" rel="stylesheet" />--%>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <%--Debe haber un main container que contenga el contenido en cada página aspx para que este centre todo el contenido teniendo en cuenta el navbar lateral--%>
   
    
    <%
        ///Listamos paciente
    %>

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
                            <td><% = item.especialidad.Nombre %></td>
                            <td><% = item.Usuario.Email %></td>
                        </tr>

                    <% } %>

                </table>
        </section>

    </div>

</asp:Content>
