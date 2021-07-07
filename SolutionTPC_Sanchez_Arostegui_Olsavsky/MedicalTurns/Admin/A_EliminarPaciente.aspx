<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/A_Structure.Master" AutoEventWireup="true" CodeBehind="A_EliminarPaciente.aspx.cs" Inherits="MedicalTurns.Admin.A_EliminarPaciente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <body>  

        <asp:Button ID="EliminarPaciente" runat="server" Text="Eliminar" OnClick="EliminarPaciente_Click" />
    </body>
</asp:Content>
