<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Encuesta.aspx.cs" Inherits="Examen3.Encuesta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      
    <div class="container text-center">
        Nombre: <asp:TextBox ID="tNombre" class="form-control" runat="server" required="true"></asp:TextBox>
         Edad: <asp:TextBox ID="tEdad" class="form-control" runat="server" type="number" min="18" max="50" required="true"></asp:TextBox>
         Correo: <asp:TextBox ID="tCorreo" class="form-control" runat="server" type="email" required="true"></asp:TextBox>
         Partido Politico: <asp:DropDownList ID="ddPartido" class="form-select" runat="server" required="true"/>
       
    </div>
    <div class="container text-center">

        <asp:Button ID="bAgregar" runat="server" Text="Agregar" OnClick="bAgregar_Click" />
          
    </div>
     

</asp:Content>
