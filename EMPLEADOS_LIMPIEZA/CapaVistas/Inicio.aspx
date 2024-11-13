<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="EMPLEADOS_LIMPIEZA.CapaVistas.Inicio" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página de Inicio</title>
    <link href="../css/Logincss.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Bienvenido al Sistema de Gestión de Empleados</h2>
            <p>Seleccione una de las opciones para gestionar los datos:</p>

            <div class="menu">
                <asp:Button ID="btnEmpleados" runat="server" Text="Gestión de Empleados" OnClick="btnEmpleados_Click" />
                <asp:Button ID="btnTelefonos" runat="server" Text="Gestión de Teléfonos de Empleados" OnClick="btnTelefonos_Click" />
                <asp:Button ID="btnDirecciones" runat="server" Text="Gestión de Direcciones de Empleados" OnClick="btnDirecciones_Click" />
                <asp:Button ID="btnPuestos" runat="server" Text="Gestión de Puestos de Empleados" OnClick="btnPuestos_Click" />
            </div>
        </div>
    </form>
</body>
</html>
