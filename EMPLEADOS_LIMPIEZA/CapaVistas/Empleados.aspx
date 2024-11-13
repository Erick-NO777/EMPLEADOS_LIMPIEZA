<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Empleados.aspx.cs" Inherits="EMPLEADOS_LIMPIEZA.CapaVistas.Empleados" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gestión de Empleados</title>
    <link href="../css/Logincss.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <h2>Gestión de Empleados</h2>

        <asp:Label Text="Cédula:" AssociatedControlID="CedulaEmpleado" runat="server" />
        <asp:TextBox ID="CedulaEmpleado" runat="server" />

        <asp:Label Text="Nombre:" AssociatedControlID="NombreEmpleado" runat="server" />
        <asp:TextBox ID="NombreEmpleado" runat="server" />

        <asp:Label Text="Fecha de Nacimiento:" AssociatedControlID="FechaNacimiento" runat="server" />
        <asp:TextBox ID="FechaNacimiento" runat="server" TextMode="Date" />

        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
        <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" />
        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />

        <asp:GridView ID="gvEmpleados" runat="server" AutoGenerateColumns="False" OnRowEditing="gvEmpleados_RowEditing"
            OnRowDeleting="gvEmpleados_RowDeleting" OnRowCancelingEdit="gvEmpleados_RowCancelingEdit"
            OnRowUpdating="gvEmpleados_RowUpdating">
            <Columns>
                <asp:BoundField DataField="CedulaEmpleado" HeaderText="Cédula" ReadOnly="True" />
                <asp:BoundField DataField="NombreEmpleado" HeaderText="Nombre" />
                <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha de Nacimiento" />
                <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
