<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/A_Structure.Master" AutoEventWireup="true" CodeBehind="A_CargarDisponibilidadHoraria.aspx.cs" Inherits="MedicalTurns.Admin.A_CargarDisponibilidadHoraria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <body>

        <div class="main-container">

            <div class="form-container">

                <h2>UPLOAD DISPONIBILIDAD HORARIA</h2>

                <div class="generic-form row contanier">

                    
                    <asp:DropDownList ID="ddlMedico" runat="server" CssClass="m-auto col-sm-12 col-md-4 col-lg-3 p-1" required>
                        <asp:ListItem Text="Doctor" Value="#" />
                    </asp:DropDownList>
                   

                    <asp:TextBox ID="Dia" CssClass="m-auto col-sm-12 col-md-4 col-lg-3 p-1" placeholder="Dia de la semana" MaxLength="100" type="text" runat="server" required ClientIDMode="Static"></asp:TextBox>
                    <asp:TextBox ID="HorarioInicio" CssClass="m-auto col-sm-12 col-md-4 col-lg-3 p-1" placeholder="Horario inicio" type="time" runat="server" ClientIDMode="Static" required></asp:TextBox>
                    <asp:TextBox ID="HorarioFin" CssClass="m-auto col-sm-12 col-md-4 col-lg-3 p-1" placeholder="Horario Fin" type="time" runat="server" ClientIDMode="Static" required></asp:TextBox>
                    <div class="m-auto col-sm-12 col-md-4 col-lg-3 p-1"></div>

                    <asp:Button CssClass="col-sm-8 col-md-4 m-auto mt-3" ID="BtnSubmit" OnClientClick="return" runat="server" Text="Add Day&Time" type="submit" />
                </div>
            </div>

            <section class="table-container">

                <div class="table-title-container">
                    <h3>Horarios</h3>
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
                    <%-- COMENTADO PARA RESOLVER

                    <% foreach (dominio.DisponibilidadHoraria item in DHlista)
                        { %>
                    <tr>
                        <td><% = item.medico.Apellido %>, <% = item.medico.Nombre %></td>
                        <td><% = item.paciente.Apellido %>, <% = item.paciente.Nombre %></td>
                        <td><% = String.Format("{0:yyyy-MM-dd}", item.Fecha) %> <% = item.Hora %> </td>
                        <td style="width: 200px;">
                                <a href="#"><i class="fas fa-info-circle"></i></a>
                                <a href="#" style="margin-left: 15px;"><i class="far fa-edit editItem"></i></a>
                                <a href="#"><i class="fas fa-trash-alt removeItem"></i></a>
                        </td>
                    </tr>

                    <% } %>
                    --%>
                </table>

            </section>


        </div>

    </body>



</asp:Content>
