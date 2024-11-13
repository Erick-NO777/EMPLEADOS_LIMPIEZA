<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DireccionesEmpleado.aspx.cs" Inherits="EMPLEADOS_LIMPIEZA.CapaVistas.DireccionesEmpleado" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gestión de Direcciones de Empleados</title>
    <link href="../css/Logincss.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <h2>Gestión de Direcciones de Empleados</h2>

        <asp:Label Text="Cédula Empleado:" AssociatedControlID="CedulaEmpleado" runat="server" />
        <asp:TextBox ID="CedulaEmpleado" runat="server" />

        <asp:Label Text="Dirección:" AssociatedControlID="Direccion" runat="server" />
        <asp:TextBox ID="Direccion" runat="server" />

        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
        <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" />
        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />

        <asp:GridView ID="gvDireccionesEmpleado" runat="server" AutoGenerateColumns="False" 
            OnRowEditing="gvDireccionesEmpleado_RowEditing" OnRowDeleting="gvDireccionesEmpleado_RowDeleting" 
            OnRowCancelingEdit="gvDireccionesEmpleado_RowCancelingEdit" OnRowUpdating="gvDireccionesEmpleado_RowUpdating">
            <Columns>
                <asp:BoundField DataField="IdDireccion" HeaderText="ID Dirección" ReadOnly="True" />
                <asp:BoundField DataField="CedulaEmpleado" HeaderText="Cédula Empleado" />
                <asp:BoundField DataField="Direccion" HeaderText="Dirección" />
                <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
