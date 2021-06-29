<%@ Page Title="" Language="C#" MasterPageFile="~/MainStructure.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="MedicalTurns.Dashboard" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/bootstrap-grid.css" rel="stylesheet" />
    <link href="Styles/DasboardDef.css" rel="stylesheet" />
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <%--Debe haber un main container que contenga el contenido en cada página aspx para que este centre todo el contenido teniendo en cuenta el navbar lateral--%>
   
    
    <%
        ///Listamos paciente
    %>

    <div class="main-container">

        <section class="container">
                <table  id="data-table" style="width: 100%;">
                    <thead>
                        <tr>
                            <th>Nombre</th>
                            <th>N° Matrícula</th>
                            <th>ID Especialidad</th>
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
        </section>

    </div>

    <%
        ///Listamos paciente
    %>

    <div class="main-container">

        <section class="container">
                <table  style="width: 100%;">
                    <thead>
                        <tr>
                            <th>Nombre</th>
                            <th>N° Matrícula</th>
                            <th>ID Especialidad</th>
                        </tr>
                    </thead>

                  <% foreach (dominio.Paciente item in listaPaciente){ %>

                        <tr>
                            <td><% = item.Apellido %>,<% = item.Nombre %></td>
                            <td><% = item.ObraSocial %></td>
                            <td><% = item.NroAfiliado %></td>
                            <td><% = item.Usuario.Email %></td>
                        </tr>

                    <% } %>

                </table>
        </section>

    </div>

</asp:Content>
