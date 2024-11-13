<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PuestosEmpleado.aspx.cs" Inherits="EMPLEADOS_LIMPIEZA.CapaVistas.PuestosEmpleado" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gestión de Puestos de Empleados</title>
    <link href="../css/Logincss.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <h2>Gestión de Puestos de Empleados</h2>

        <asp:Label Text="Cédula Empleado:" AssociatedControlID="CedulaEmpleado" runat="server" />
        <asp:TextBox ID="CedulaEmpleado" runat="server" />

        <asp:Label Text="Puesto Desempeñado:" AssociatedControlID="PuestoDesempenado" runat="server" />
        <asp:TextBox ID="PuestoDesempenado" runat="server" />

        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
        <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" />
        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />

        <asp:GridView ID="gvPuestosEmpleado" runat="server" AutoGenerateColumns="False" 
            OnRowEditing="gvPuestosEmpleado_RowEditing" OnRowDeleting="gvPuestosEmpleado_RowDeleting" 
            OnRowCancelingEdit="gvPuestosEmpleado_RowCancelingEdit" OnRowUpdating="gvPuestosEmpleado_RowUpdating">
            <Columns>
                <asp:BoundField DataField="IdPuesto" HeaderText="ID Puesto" ReadOnly="True" />
                <asp:BoundField DataField="CedulaEmpleado" HeaderText="Cédula Empleado" />
                <asp:BoundField DataField="PuestoDesempenado" HeaderText="Puesto Desempeñado" />
                <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
