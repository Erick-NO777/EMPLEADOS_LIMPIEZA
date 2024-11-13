using System;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EMPLEADOS_LIMPIEZA.CapaVistas
{
    public partial class Empleados : System.Web.UI.Page
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarEmpleados();
            }
        }

        private void CargarEmpleados()
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Empleados", conexion);
                conexion.Open();
                gvEmpleados.DataSource = cmd.ExecuteReader();
                gvEmpleados.DataBind();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Empleados (CedulaEmpleado, NombreEmpleado, FechaNacimiento) VALUES (@Cedula, @Nombre, @Fecha)";
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Cedula", CedulaEmpleado.Text);
                cmd.Parameters.AddWithValue("@Nombre", NombreEmpleado.Text);
                cmd.Parameters.AddWithValue("@Fecha", FechaNacimiento.Text);

                conexion.Open();
                cmd.ExecuteNonQuery();
                CargarEmpleados();
            }
        }

        protected void gvEmpleados_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            gvEmpleados.EditIndex = e.NewEditIndex;
            CargarEmpleados();
        }

        protected void gvEmpleados_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvEmpleados.Rows[e.RowIndex];
            string cedula = ((Label)row.FindControl("CedulaEmpleado")).Text;
            string nombre = ((TextBox)row.FindControl("NombreEmpleado")).Text;
            string fechaNacimiento = ((TextBox)row.FindControl("FechaNacimiento")).Text;

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string query = "UPDATE Empleados SET NombreEmpleado = @Nombre, FechaNacimiento = @Fecha WHERE CedulaEmpleado = @Cedula";
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Fecha", fechaNacimiento);
                cmd.Parameters.AddWithValue("@Cedula", cedula);

                conexion.Open();
                cmd.ExecuteNonQuery();
                gvEmpleados.EditIndex = -1;
                CargarEmpleados();
            }
        }

        protected void gvEmpleados_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            string cedula = gvEmpleados.DataKeys[e.RowIndex].Value.ToString();

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Empleados WHERE CedulaEmpleado = @Cedula";
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Cedula", cedula);

                conexion.Open();
                cmd.ExecuteNonQuery();
                CargarEmpleados();
            }
        }

        protected void gvEmpleados_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            gvEmpleados.EditIndex = -1;
            CargarEmpleados();
        }
    }
}
