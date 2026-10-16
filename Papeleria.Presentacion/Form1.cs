using Papeleria.Negocio;

namespace Papeleria.Presentacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // Prueba temporal: se ejecuta una vez al mostrar el formulario.
        protected override async void OnShown(EventArgs e)
        {
            base.OnShown(e);
            try
            {
                string? clave = Environment.GetEnvironmentVariable(
                "PAPELERIA_DB_PASSWORD", EnvironmentVariableTarget.User);
                if (string.IsNullOrEmpty(clave))
                {
                    MessageBox.Show(this,
                    "Falta configurar la variable PAPELERIA_DB_PASSWORD en tu usuario de Windows.",
                    "Configuración pendiente", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    return;
                }
                var negocio = new ConexionNegocio();
                string baseDatos = await negocio.ProbarAsync(clave);
                MessageBox.Show(this, $"Conexión exitosa a {baseDatos}.",
                "Prueba de conexión", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this,
                $"No se pudo conectar. Revisa el servicio PostgreSQL, el puerto y la " +
                $"contraseña.\nTipo de error: {ex.GetType().Name}",
                "Error de conexión", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }
    }
}
