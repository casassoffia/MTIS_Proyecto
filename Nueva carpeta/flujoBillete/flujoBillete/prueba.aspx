<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="flujo3.aspx.cs" Inherits="ClientePractica4.flujo3" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <h1>Flujo 3</h1>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="button3" Text="NotificarSalaNoValido" OnClick="notificar" runat="server"/>
        </div>
        &nbsp
        <div>
            <asp:Label ID="error" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>