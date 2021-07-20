<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/A_Structure.Master" AutoEventWireup="true" CodeBehind="A_ModificarTurno.aspx.cs" Inherits="MedicalTurns.Admin.A_ModificarTurno" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="main-container">

        <div class="form-container">

            <h2>MODIFICAR TURNOS</h2>

            <div class="generic-form row contanier">

                <asp:Label ID="lblEspecialidad" runat="server" Text="Especialidad" CssClass="m-auto col-sm-12 col-md-4 col-lg-3 p-1" readonly></asp:Label>
                <asp:Label ID="lblMedico" runat="server" Text="Medico" CssClass="m-auto col-sm-12 col-md-4 col-lg-3 p-1" readonly></asp:Label>
                <asp:Label ID="lblPaciente" runat="server" Text="Paciente" CssClass="m-auto col-sm-12 col-md-4 col-lg-3 p-1" readonly></asp:Label>

                <asp:Calendar ID="cFecha" CssClass="m-auto col-sm-12 col-md-4 col-lg-3 p-1" placeholder="Fecha turno" runat="server" OnSelectionChanged="cFecha_SelectionChanged"></asp:Calendar>

                <asp:DropDownList ID="ddlHorarios" runat="server" CssClass="m-auto col-sm-12 col-md-4 col-lg-3 p-1" required>
                    <asp:ListItem Text="Horarios" Value="#" />
                </asp:DropDownList>

                <asp:DropDownList ID="ddlEstado" runat="server" CssClass="m-auto col-sm-12 col-md-4 col-lg-3 p-1" required>
                    <asp:ListItem Text="Estado" Value="Agendado" />
                    <asp:ListItem Text="Agendado" Value="Agendado" />
                    <asp:ListItem Text="Cancelado" Value="Cancelado" />
                    <asp:ListItem Text="Asistido" Value="Asistido" />
                    <asp:ListItem Text="Reagendado" Value="Reagendado" />
                    <asp:ListItem Text="Ausente" Value="Ausente" />
                </asp:DropDownList>

                <div class="m-auto col-sm-12 col-md-4 col-lg-3 p-1"></div>

                <asp:Button CssClass="col-sm-8 col-md-4 m-auto mt-3" ID="BtnSubmit" OnClientClick="return" runat="server" Text="Modificar turn" type="submit" OnClick="BtnSubmit_Click" />
            </div>
        </div>

</asp:Content>
