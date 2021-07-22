<%@ Page Title="" Language="C#" MasterPageFile="~/Medico/M_Structure.Master" AutoEventWireup="true" CodeBehind="M_Dashboard.aspx.cs" Inherits="MedicalTurns.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <body>

        <div class="main-container">

            <div class="form-container">

                <h2>UPLOAD TURNOS</h2>

                <div class="generic-form row contanier">

                    <asp:DropDownList ID="ddlEspecialidad" AutoPostBack="true" runat="server" CssClass="m-auto col-sm-12 col-md-4 col-lg-3 p-1" OnSelectedIndexChanged="ddlEspecialidad_SelectedIndexChanged" required>
                        <asp:ListItem Text="Specialty" Value="#" />
                    </asp:DropDownList>

                    <asp:DropDownList ID="ddlMedico" runat="server" CssClass="m-auto col-sm-12 col-md-4 col-lg-3 p-1">
                        <asp:ListItem Text="Doctor" Value="#" />
                    </asp:DropDownList>

                    <asp:DropDownList ID="ddlPaciente" runat="server" CssClass="m-auto col-sm-12 col-md-4 col-lg-3 p-1" required>
                        <asp:ListItem Text="Patient" Value="#" />
                    </asp:DropDownList>
                    
                    <asp:Calendar ID="cFecha" Format="dd-MM-yyyy" CssClass="m-auto col-sm-12 col-md-4 col-lg-3 p-1" placeholder="Fecha turno" runat="server" required ClientIDMode="Static" OnSelectionChanged="cFecha_SelectionChanged"></asp:Calendar>
                    
                    <asp:DropDownList ID="ddlHorarios" runat="server" CssClass="m-auto col-sm-12 col-md-4 col-lg-3 p-1" required>
                        <asp:ListItem Text="Horarios" Value="#" />
                    </asp:DropDownList>

                    <div class="m-auto col-sm-12 col-md-4 col-lg-3 p-1"></div>

                    <asp:Button CssClass="col-sm-8 col-md-4 m-auto mt-3" ID="BtnSubmit" OnClientClick="return" runat="server" Text="Add turn" type="submit" OnClick="BtnSubmit_Click" />
                </div>
            </div>

            <section class="table-container">

                <div class="table-title-container">
                    <h3>Turns</h3>
                    <hr />
                </div>


                <table id="data-table2" style="width: 100%;">
                    <thead>
                        <tr>
                            <th>Clinic</th>
                            <th>Patient</th>
                            <th>Date and Time</th>
                            <th>Actions</th>
                        </tr>
                    </thead>

                    <% foreach (dominio.Turno item in Tlista)
                        { %>
                    <tr>
                        <td><% = item.paciente.Apellido %>, <% = item.paciente.Nombre %></td>
                        <td><% = String.Format("{0:yyyy-MM-dd}", item.Fecha) %> <% = item.Hora %> </td>
                        <td style="width: 200px;">
                                <a href="#"><i class="fas fa-info-circle"></i></a>
                                <a href="A_ModificarTurno.aspx?ID=<% = item.ID %>" style="margin-left: 15px;"><i class="far fa-edit editItem"></i></a>
                                <a href="?IDTurno=<% = item.ID %>"><i class="fas fa-trash-alt removeItem"></i></a>
                        </td>
                    </tr>

                    <% } %>
                </table>

            </section>


        </div>

    </body>

</asp:Content>
