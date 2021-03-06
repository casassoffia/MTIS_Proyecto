<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="flujoCoche.aspx.cs" Inherits="flujoBillete.flujoCoche" Async="true"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">


     <form id="form1" runat="server">


     <div class="jumbotron">
        <h1>Reserva el  Coche</h1>
        <p class="lead">Para poder reservar el coche debes introducir los siguientes datos:</p>
        <p class="lead">DNI:</p>
        <p class="lead">
            <asp:TextBox ID="dni" runat="server"></asp:TextBox>
        </p>
        <p class="lead">Fecha de Ida:</p>
        <p class="lead">
            <asp:TextBox ID="fechaInicio" runat="server"></asp:TextBox>
        </p>
        <p class="lead">Fecha de Vuelta</p>
        <p class="lead">
            <asp:TextBox ID="fechaFin" runat="server"></asp:TextBox>
        </p>
        <p class="lead">NºPersonas</p>
        <p class="lead">
            <asp:TextBox ID="numPersonas" runat="server"></asp:TextBox>
        </p>
        <p class="lead">Lugar</p>
        <p class="lead">
            <asp:TextBox ID="lugar" runat="server"></asp:TextBox>
        </p>
        <p class="lead">Precio Mínimo</p>
        <p class="lead">
            <asp:TextBox ID="precioInicio" runat="server"></asp:TextBox>
        </p>
        <p class="lead">Precio Máximo</p>
        <p class="lead">
            <asp:TextBox ID="precioFin" runat="server"></asp:TextBox>
        </p>
         <p class="lead">
             &nbsp;</p>
         </div>

         <p class="lead">
             &nbsp;</p>
         <p>
            <asp:Button ID="reservarCoche" runat="server" Text="Reservar" OnClick="crear" Width="180px" />
        </p>
         <asp:Label ID="lblReserva" runat="server" />
     </form>


</html>
