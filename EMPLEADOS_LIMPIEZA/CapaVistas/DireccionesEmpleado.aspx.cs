using System;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EMPLEADOS_LIMPIEZA.CapaVistas
{
    public partial class DireccionesEmpleado : System.Web.UI.Page
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDireccionesEmpleado();
            }
        }

        private void CargarDireccionesEmpleado()
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM DireccionesEmpleado", conexion);
                conexion.Open();
                gvDireccionesEmpleado.DataSource = cmd.ExecuteReader();
                gvDireccionesEmpleado.DataBind();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO DireccionesEmpleado (CedulaEmpleado, Direccion) VALUES (@Cedula, @Direccion)";
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Cedula", CedulaEmpleado.Text);
                cmd.Parameters.AddWithValue("@Direccion", Direccion.Text);

                conexion.Open();
                cmd.ExecuteNonQuery();
                CargarDireccionesEmpleado();
            }
        }

        protected void gvDireccionesEmpleado_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            gvDireccionesEmpleado.EditIndex = e.NewEditIndex;
            CargarDireccionesEmpleado();
        }

        protected void gvDireccionesEmpleado_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvDireccionesEmpleado.Rows[e.RowIndex];
            string idDireccion = ((Label)row.FindControl("IdDireccion")).Text;
            string cedula = ((TextBox)row.FindControl("CedulaEmpleado")).Text;
            string direccion = ((TextBox)row.FindControl("Direccion")).Text;

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string query = "UPDATE DireccionesEmpleado SET CedulaEmpleado = @Cedula, Direccion = @Direccion WHERE IdDireccion = @IdDireccion";
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Cedula", cedula);
                cmd.Parameters.AddWithValue("@Direccion", direccion);
                cmd.Parameters.AddWithValue("@IdDireccion", idDireccion);

                conexion.Open();
                cmd.ExecuteNonQuery();
                gvDireccionesEmpleado.EditIndex = -1;
                CargarDireccionesEmpleado();
            }
        }

        protected void gvDireccionesEmpleado_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            string idDireccion = gvDireccionesEmpleado.DataKeys[e.RowIndex].Value.ToString();

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM DireccionesEmpleado WHERE IdDireccion = @IdDireccion";
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@IdDireccion", idDireccion);

                conexion.Open();
                cmd.ExecuteNonQuery();
                CargarDireccionesEmpleado();
            }
        }

        protected void gvDireccionesEmpleado_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            gvDireccionesEmpleado.EditIndex = -1;
            CargarDireccionesEmpleado();
        }
    }
}
