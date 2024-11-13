using System;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EMPLEADOS_LIMPIEZA.CapaVistas
{
    public partial class PuestosEmpleado : System.Web.UI.Page
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPuestosEmpleado();
            }
        }

        private void CargarPuestosEmpleado()
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM PuestosEmpleado", conexion);
                conexion.Open();
                gvPuestosEmpleado.DataSource = cmd.ExecuteReader();
                gvPuestosEmpleado.DataBind();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO PuestosEmpleado (CedulaEmpleado, PuestoDesempenado) VALUES (@Cedula, @Puesto)";
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Cedula", CedulaEmpleado.Text);
                cmd.Parameters.AddWithValue("@Puesto", PuestoDesempenado.Text);

                conexion.Open();
                cmd.ExecuteNonQuery();
                CargarPuestosEmpleado();
            }
        }

        protected void gvPuestosEmpleado_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            gvPuestosEmpleado.EditIndex = e.NewEditIndex;
            CargarPuestosEmpleado();
        }

        protected void gvPuestosEmpleado_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvPuestosEmpleado.Rows[e.RowIndex];
            string idPuesto = ((Label)row.FindControl("IdPuesto")).Text;
            string cedula = ((TextBox)row.FindControl("CedulaEmpleado")).Text;
            string puesto = ((TextBox)row.FindControl("PuestoDesempenado")).Text;

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string query = "UPDATE PuestosEmpleado SET CedulaEmpleado = @Cedula, PuestoDesempenado = @Puesto WHERE IdPuesto = @IdPuesto";
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Cedula", cedula);
                cmd.Parameters.AddWithValue("@Puesto", puesto);
                cmd.Parameters.AddWithValue("@IdPuesto", idPuesto);

                conexion.Open();
                cmd.ExecuteNonQuery();
                gvPuestosEmpleado.EditIndex = -1;
                CargarPuestosEmpleado();
            }
        }

        protected void gvPuestosEmpleado_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            string idPuesto = gvPuestosEmpleado.DataKeys[e.RowIndex].Value.ToString();

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM PuestosEmpleado WHERE IdPuesto = @IdPuesto";
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@IdPuesto", idPuesto);

                conexion.Open();
                cmd.ExecuteNonQuery();
                CargarPuestosEmpleado();
            }
        }

        protected void gvPuestosEmpleado_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            gvPuestosEmpleado.EditIndex = -1;
            CargarPuestosEmpleado();
        }
    }
}
