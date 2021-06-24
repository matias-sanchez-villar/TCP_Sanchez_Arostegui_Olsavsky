<%@ Page Title="" Language="C#" MasterPageFile="~/MainStructure.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="MedicalTurns.Dashboard" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/bootstrap-grid.css" rel="stylesheet" />
    <link href="Styles/DasboardDef.css" rel="stylesheet" />
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <%--Debe haber un main container que contenga el contenido en cada página aspx para que este centre todo el contenido teniendo en cuenta el navbar lateral--%>
    
    <div class="main-container">

<%--        <div class="container" >
            <div class="row myrow">
                <div class="col mycol"> Column 1</div>
                <div class="col mycol"> Column 2</div>
                <div class="col mycol"> Column 3</div>
                <div class="col mycol"> Column 4</div>
            </div>        

            <div class="row myrow">
                <div class="col-md-8 col-sm-12 mycol"> Column 1</div>
                <div class="col-md-4 col-sm-12 mycol"> Column 2</div>
            </div>        
        
            <div class="row myrow">
                <div class="col mycol"> Column 1</div>
            </div>
        </div>--%>

        <section class="container">
            <div class="row">
                <table class="col-sm-12">
                    <thead>
                        <tr>
                            <th>Nombre</th>
                            <th>N° Matrícula</th>
                            <th>Especialidad</th>
                        </tr>
                    </thead>
                  <% foreach (dominio.Medico item in listaMedicos){ %>

                        <tr>
                            <td><% = item.Apellido %>,<% = item.Nombre %></td>
                            <td><% = item.Matricula %></td>
                            <td><% = item.Especialidad %></td>
                        </tr>

                    <% } %>


                </table>
            </div>
        </section>

    </div>

</asp:Content>
