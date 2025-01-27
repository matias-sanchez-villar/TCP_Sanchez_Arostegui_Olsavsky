﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/A_Structure.Master" AutoEventWireup="true" CodeBehind="A_CargarObraSocial.aspx.cs" Inherits="MedicalTurns.A_CargarObraSocial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


        <body>

            <div class="main-container">

                <h2>UPLOAD MEDICAL SUPPORT</h2>
                <div class="container generic-form">

                    <asp:TextBox ID="ObraSocial" placeholder="Clinical support" MaxLength="100" runat="server" required ClientIDMode="Static"></asp:TextBox>

                    <asp:Button ID="btnAgregar" CssClass="BtnSubmit" OnClientClick="alert('Medical support successfully uploaded.')" runat="server" Text="ADD" OnClick="btnAgregar_Click"  />

                </div>



                <section class="table-container">

                    <div class="table-title-container">
                        <h3>Medical supports</h3>
                        <hr />
                    </div>

                    <table id="data-table" style="width: 100%;">
                        <thead>
                            <tr>
                                <th>Name</th>
                                <th>Actions</th>
                            </tr>
                        </thead>

                        <% foreach (dominio.ObraSocial item in lista)
                            { %>

                        <tr>
                            <td><% = item.Nombre %></td>
                            <td>
                                <a href="A_CargarObraSocial.aspx?ID=<% = item.ID %>" OnClientClick="alert('Medical support successfully deleted.')"><i class="far fa-edit"></i></a>
                            </td>
                        </tr>

                        <% } %>
                    </table>
                </section>


            </div>


        </body>
</asp:Content>
