<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/A_Structure.Master" AutoEventWireup="true" CodeBehind="A_EnvioEmail.aspx.cs" Inherits="MedicalTurns.Admin.A_EnvioEmail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-2"></div>
        <div class="col">
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox runat="server" ID="txtEmail" cssclass="form-control"></asp:TextBox>
                
            </div>
            <div class="mb-3">
                <label class="form-label">Asunto</label>
                <asp:TextBox runat="server" ID="txtAsunto" cssclass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Mensaje</label>
                <asp:TextBox runat="server" TextMode="MultiLine" runat="server" ID="txtMensaje" cssclass="form-control"></asp:TextBox>
            </div>
            
        </div>
        <div class="col"></div>
    </div>



</asp:Content>
