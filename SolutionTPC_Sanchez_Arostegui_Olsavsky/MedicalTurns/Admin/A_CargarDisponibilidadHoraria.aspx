<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/A_Structure.Master" AutoEventWireup="true" CodeBehind="A_CargarDisponibilidadHoraria.aspx.cs" Inherits="MedicalTurns.Admin.A_CargarDisponibilidadHoraria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <body>

        <div class="main-container">

            <div class="form-container">

                <h2>UPLOAD AVAILABILITY</h2>

                <div class="generic-form row contanier">

                    
                    <asp:DropDownList ID="ddlMedico" runat="server" CssClass="m-auto col-sm-12 col-md-4 col-lg-3 p-1" required>
                        <asp:ListItem Text="Doctor" Value="#" />
                    </asp:DropDownList>


                    <asp:DropDownList id="ddlDia" CssClass="m-auto col-sm-12 col-md-4 col-lg-3 p-1" runat="server">
                        <asp:ListItem Text="Weekday" Value="#" />
                        <asp:ListItem Text="Monday" Value="Monday" />
                        <asp:ListItem Text="Tuesday" Value="Tuesday" />
                        <asp:ListItem Text="Wednesday" Value="Wednesday" />
                        <asp:ListItem Text="Thursday" Value="Thursday" />
                        <asp:ListItem Text="Friday" Value="Friday" />
                        <asp:ListItem Text="Saturday" Value="Saturday" />
                        <asp:ListItem Text="Sunday" Value="Sunday" />
                    </asp:DropDownList>
                    
                    <asp:TextBox TextMode="Time" format="HH:mm" ID="HorarioInicio" CssClass="m-auto col-sm-12 col-md-4 col-lg-3 p-1" placeholder="Horario inicio" type="time" runat="server" ClientIDMode="Static" required></asp:TextBox>
                    <asp:TextBox TextMode="Time" format="HH:mm" ID="HorarioFin" CssClass="m-auto col-sm-12 col-md-4 col-lg-3 p-1" placeholder="Horario Fin" type="time" runat="server" ClientIDMode="Static" required></asp:TextBox>

                    <asp:Button CssClass="col-sm-8 col-md-4 m-auto mt-3" ID="BtnSubmit" OnClientClick="return true" runat="server" Text="ADD AVAILABILITY" type="submit" OnClick="BtnSubmit_Click" />
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
                            <th>Doctor</th>
                            <th>Day</th>
                            <th>DCheck-in time</th>
                            <th>Check-out time</th>
                            <th>Actions</th>
                        </tr>
                    </thead>

                    <% foreach (dominio.DisponibilidadHoraria item in DHlista)
                        { %>
                    <tr>
                        <td><% = item.medicoAux.Nombre %>, <% = item.medicoAux.Apellido %></td>
                        <td><% = item.Dia %></td>
                        <td><% = item.HoraInicio %></td>
                        <td><% = item.HoraFin %></td>
                        <td style="width: 100px;">
                            <a href="?ID=<% = item.ID %>"><i class="fas fa-trash-alt removeItem"></i></a>
                        </td>
                    </tr>

                    <% } %>
                </table>

            </section>


        </div>

    </body>

    <script src="https://code.jquery.com/jquery-3.5.1.js"></script>
    <script src="https://cdn.datatables.net/1.10.25/js/jquery.dataTables.min.js"></script>

    <script>
        $(document).ready(function () {

            $('#data-table4').DataTable({});

        });
    </script>

</asp:Content>
