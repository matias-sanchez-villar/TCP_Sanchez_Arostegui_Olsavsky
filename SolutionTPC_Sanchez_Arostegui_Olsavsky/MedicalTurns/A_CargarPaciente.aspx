<%@ Page Title="" Language="C#" MasterPageFile="~/A_Structure.Master" AutoEventWireup="true" CodeBehind="A_CargarPaciente.aspx.cs" Inherits="MedicalTurns.A_CargarPaciente" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--aca va el formulario de cargar paciente--%>
     <div class="main-container">
        <body>  
            <h2>CARGAR PACIENTE</h2>

            <form>
              <label for="Nombre">Nombre: </label><br>
              <input type="text" id="Nombre" name="Nombre" value=""><br>
              <label for="Apellido">Apellido: </label><br>
              <input type="text" id="Apellido" name="Apellido" value=""><br>
              <label for="ID">ID: </label><br>
              <input type="text" id="ID" name="ID" value=""><br>
              <label for="IDUsuario">IDUsuario: </label><br>
              <input type="text" id="IDUsuario" name="IDUsuario" value=""><br>
              <label for="IDObraSocial">IDObraSocial: </label><br>
              <input type="text" id="IDObraSocial" name="IDObraSocial" value=""><br>
              <label for="FNacimiento">Fecha de Nacimiento: </label><br>
              <input type="text" id="FNacimiento" name="FNacimiento" value=""><br>
              <label for="Domicilio">Domicilio: </label><br>
              <input type="text" id="Domicilio" name="Domicilio" value=""><br>
              <label for="Celular">Celular: </label><br>
              <input type="text" id="Celular" name="Celular" value=""><br>
              <label for="Genero">Genero: </label><br>
              <input type="text" id="Genero" name="Genero" value=""><br>
              <label for="NroAfiliado">NroAfiliado: </label><br>
              <input type="text" id="NroAfiliado" name="NroAfiliado" value=""><br>

                       
	       </form>

        </body>
        </div>
</asp:Content>
