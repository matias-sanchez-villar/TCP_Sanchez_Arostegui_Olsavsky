<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/A_Structure.Master" AutoEventWireup="true" CodeBehind="A_CargarTurno.aspx.cs" Inherits="MedicalTurns.A_CargarTurno1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <body>

        <div class="main-container">

            <div class="form-container">

                <h2>UPLOAD PATIENT</h2>

                <div class="generic-form row contanier">

                    <asp:TextBox ID="Medico" CssClass="m-auto col-sm-12 col-md-4 col-lg-3 p-1" placeholder="Email Medico" type="text" required MaxLength="100" runat="server" ClientIDMode="Static"></asp:TextBox>
                    <asp:TextBox ID="Paciente" CssClass="m-auto col-sm-12 col-md-4 col-lg-3 p-1" placeholder="Email Paciente" MaxLength="100" type="text" runat="server" required ClientIDMode="Static"></asp:TextBox>
                    <asp:TextBox ID="Fecha" CssClass="m-auto col-sm-12 col-md-4 col-lg-3 p-1" placeholder="Fecha turno" type="date" runat="server" ClientIDMode="Static"></asp:TextBox>
                    <asp:TextBox ID="Horarios" CssClass="m-auto col-sm-12 col-md-4 col-lg-3 p-1" placeholder="Horarios" type="date" runat="server" ClientIDMode="Static"></asp:TextBox>

                    <asp:Button CssClass="col-sm-8 col-md-4 m-auto mt-3" ID="btnAgregar" OnClientClick="return validateForm()" runat="server" Text="Create Turno" type="submit" />
                </div>
            </div>

            <section class="table-container">

                <div class="table-title-container">
                    <h3>Patients</h3>
                    <hr />
                </div>


                <table id="data-table2" style="width: 100%;">
                    <thead>
                        <tr>
                            <th>Medico</th>
                            <th>Paciente</th>
                            <th>Fecha</th>
                            <th>Actions</th>
                        </tr>
                    </thead>

                    <% foreach (dominio.Turno item in lista)
                        { %>
                    <tr>
                        <td><% = item.medico.Apellido %>, <% = item.medico.Nombre %></td>
                        <td><% = item.paciente.Apellido %>, <% = item.paciente.Nombre %></td>
                        <td><% = item.FechaHora %></td>
                        <td>
                            <a href="#">Detalle</a>
                        </td>
                    </tr>

                    <% } %>
                </table>

            </section>


        </div>

    </body>

</asp:Content>
