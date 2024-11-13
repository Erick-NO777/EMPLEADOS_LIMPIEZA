using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace EMPLEADOS_LIMPIEZA.CapaVistas
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Comprobación de autenticación o lógica adicional en la carga de la página
        }

        // Maneja el evento de clic del botón de ingreso
        protected void bingresar_Click(object sender, EventArgs e)
        {
            int usuarioId = ValidarUsuario(tusuario.Text, tclave.Text); // Llama al método ValidarUsuario para obtener el ID

            if (usuarioId != -1) // Verifica si el ID es válido
            {
                // Establecer el ID del usuario en la sesión
                Session["UsuarioID"] = usuarioId;

                // Establecer el nombre del usuario en la sesión
                Session["UsuarioNombre"] = tusuario.Text;

                // Redirigir a la página de inicio
                Response.Redirect("Inicio.aspx");
            }
            else
            {
                // Si no se encuentra el usuario, muestra un mensaje de error
                lerror.Text = "Usuario o contraseña incorrectos";
            }
        }

        // Método para validar el usuario en la base de datos
        protected int ValidarUsuario(string usuario, string clave)
        {
            try
            {
                // Obtiene la cadena de conexión desde el archivo de configuración
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();

                    using (SqlCommand comando = new SqlCommand("SELECT IdUsuario FROM Usuarios WHERE Usuario = @Usuario AND Clave = @Clave", conexion))
                    {
                        comando.Parameters.AddWithValue("@Usuario", usuario);
                        comando.Parameters.AddWithValue("@Clave", clave);

                        using (SqlDataReader registro = comando.ExecuteReader())
                        {
                            if (registro.Read())
                            {
                                return Convert.ToInt32(registro["IdUsuario"]);
                            }
                            else
                            {
                                return -1;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lerror.Text = "Ocurrió un error: " + ex.Message;
                return -1;
            }
        }
    }
}
