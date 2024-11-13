<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TelefonosEmpleado.aspx.cs" Inherits="EMPLEADOS_LIMPIEZA.CapaVistas.TelefonosEmpleado" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gestión de Teléfonos de Empleados</title>
    <link href="../css/Logincss.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <h2>Gestión de Teléfonos de Empleados</h2>

        <asp:Label Text="Cédula Empleado:" AssociatedControlID="CedulaEmpleado" runat="server" />
        <asp:TextBox ID="CedulaEmpleado" runat="server" />

        <asp:Label Text="Número de Teléfono:" AssociatedControlID="NumeroTelefono" runat="server" />
        <asp:TextBox ID="NumeroTelefono" runat="server" />

        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
        <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" />
        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />

        <asp:GridView ID="gvTelefonosEmpleado" runat="server" AutoGenerateColumns="False" 
            OnRowEditing="gvTelefonosEmpleado_RowEditing" OnRowDeleting="gvTelefonosEmpleado_RowDeleting" 
            OnRowCancelingEdit="gvTelefonosEmpleado_RowCancelingEdit" OnRowUpdating="gvTelefonosEmpleado_RowUpdating">
            <Columns>
                <asp:BoundField DataField="IdTelefono" HeaderText="ID Teléfono" ReadOnly="True" />
                <asp:BoundField DataField="CedulaEmpleado" HeaderText="Cédula Empleado" />
                <asp:BoundField DataField="NumeroTelefono" HeaderText="Número de Teléfono" />
                <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
