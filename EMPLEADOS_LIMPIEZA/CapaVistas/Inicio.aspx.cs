using System;
using System.Web.UI;

namespace EMPLEADOS_LIMPIEZA.CapaVistas
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Verificar si el usuario ha iniciado sesión
            if (Session["UsuarioID"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnEmpleados_Click(object sender, EventArgs e)
        {
            Response.Redirect("Empleados.aspx");
        }

        protected void btnTelefonos_Click(object sender, EventArgs e)
        {
            Response.Redirect("TelefonosEmpleado.aspx");
        }

        protected void btnDirecciones_Click(object sender, EventArgs e)
        {
            Response.Redirect("DireccionesEmpleado.aspx");
        }

        protected void btnPuestos_Click(object sender, EventArgs e)
        {
            Response.Redirect("PuestosEmpleado.aspx");
        }
    }
}
