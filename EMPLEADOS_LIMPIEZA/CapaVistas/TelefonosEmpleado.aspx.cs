using System;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EMPLEADOS_LIMPIEZA.CapaVistas
{
    public partial class TelefonosEmpleado : System.Web.UI.Page
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTelefonosEmpleado();
            }
        }

        private void CargarTelefonosEmpleado()
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM TelefonosEmpleado", conexion);
                conexion.Open();
                gvTelefonosEmpleado.DataSource = cmd.ExecuteReader();
                gvTelefonosEmpleado.DataBind();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO TelefonosEmpleado (CedulaEmpleado, NumeroTelefono) VALUES (@Cedula, @Numero)";
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Cedula", CedulaEmpleado.Text);
                cmd.Parameters.AddWithValue("@Numero", NumeroTelefono.Text);

                conexion.Open();
                cmd.ExecuteNonQuery();
                CargarTelefonosEmpleado();
            }
        }

        protected void gvTelefonosEmpleado_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            gvTelefonosEmpleado.EditIndex = e.NewEditIndex;
            CargarTelefonosEmpleado();
        }

        protected void gvTelefonosEmpleado_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvTelefonosEmpleado.Rows[e.RowIndex];
            string idTelefono = ((Label)row.FindControl("IdTelefono")).Text;
            string cedula = ((TextBox)row.FindControl("CedulaEmpleado")).Text;
            string numero = ((TextBox)row.FindControl("NumeroTelefono")).Text;

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string query = "UPDATE TelefonosEmpleado SET CedulaEmpleado = @Cedula, NumeroTelefono = @Numero WHERE IdTelefono = @IdTelefono";
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Cedula", cedula);
                cmd.Parameters.AddWithValue("@Numero", numero);
                cmd.Parameters.AddWithValue("@IdTelefono", idTelefono);

                conexion.Open();
                cmd.ExecuteNonQuery();
                gvTelefonosEmpleado.EditIndex = -1;
                CargarTelefonosEmpleado();
            }
        }

        protected void gvTelefonosEmpleado_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            string idTelefono = gvTelefonosEmpleado.DataKeys[e.RowIndex].Value.ToString();

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM TelefonosEmpleado WHERE IdTelefono = @IdTelefono";
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@IdTelefono", idTelefono);

                conexion.Open();
                cmd.ExecuteNonQuery();
                CargarTelefonosEmpleado();
            }
        }

        protected void gvTelefonosEmpleado_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            gvTelefonosEmpleado.EditIndex = -1;
            CargarTelefonosEmpleado();
        }
    }
}
