<%@ Page Title="" Language="C#" MasterPageFile="~/Medico/M_Structure.Master" AutoEventWireup="true" CodeBehind="M_Dashboard.aspx.cs" Inherits="MedicalTurns.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <body>

        <div class="main-container">

            <section class="table-container">

                <div class="table-title-container">
                    <h3>Turns</h3>
                    <hr />
                </div>


                <table id="data-table2" style="width: 100%;">
                    <thead>
                        <tr>
                            <th>Patient</th>
                            <th>Date</th>
                            <th>Time</th>
                            <th>Actions</th>
                        </tr>
                    </thead>

                    <% foreach (dominio.Turno item in Tlista)
                        { %>
                    <tr>
                        <td><% = item.paciente.Apellido %>, <% = item.paciente.Nombre %></td>
                        <td><% = String.Format("{0:yyyy-MM-dd}", item.Fecha) %></td>
                        <td><% = item.Hora %> </td>
                        <td style="width: 200px;">
                                <a href="M_ModificarTurno.aspx?ID=<% = item.ID %>" style="margin-left: 15px;"><i class="far fa-edit editItem"></i></a>
                                <a href="?IDTurno=<% = item.ID %>"><i class="fas fa-trash-alt removeItem"></i></a>
                        </td>
                    </tr>

                    <% } %>
                </table>

            </section>


        </div>

    </body>

</asp:Content>
