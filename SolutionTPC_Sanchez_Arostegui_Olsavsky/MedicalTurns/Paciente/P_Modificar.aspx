<%@ Page Title="" Language="C#" MasterPageFile="~/Paciente/P_Structure.Master" AutoEventWireup="true" CodeBehind="P_Modificar.aspx.cs" Inherits="MedicalTurns.P_Modificar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <body>

    
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

                <asp:Button ID="btnModificar" runat="server" Text="Modificar" class="m-auto col-sm-12 col-md-4 col-lg-3 p-1" OnClick="btnModificar_Click"/>

                
            </div>
        </div>

 </div>

</body>

</asp:Content>
