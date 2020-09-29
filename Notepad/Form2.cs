using System.Windows.Forms;

namespace Notepad
{
    public partial class GuardarComo : Form
    {
        private string contenido;
        // Este determinará si se canceló o no la operación.
        private static DialogResult cuadroDialogoValor = DialogResult.OK; 
        public GuardarComo()
        {
            InitializeComponent();
        }
        public GuardarComo(string nombreArchivo, int tamNombre, string contenido)
        {
            InitializeComponent();
            this.contenido = contenido;
            // Se saca el nombre original del archivo.
            nombreArchivo = nombreArchivo.Substring(0, tamNombre);
            txtGuardarCambios.Text = "¿Quieres guardar los cambios en " + nombreArchivo + "?";
        }
        /* Al presionar el botón de guardado hará el procedimiento indicado..*/
        private void toolStripGuardar_MouseUp(object sender, MouseEventArgs e)
        {
            cuadroDialogoValor = DialogResult.OK;
            Archivo.Guardar(contenido);
            this.Close();
        }
        /* Método que hará que la variable estática indique que no se
                quieren guardar los cambios.*/
        private void toolStripNoGuardar_MouseUp(object sender, MouseEventArgs e)
        {
            cuadroDialogoValor = DialogResult.No;
            this.Close();
        }

        /* - Métoo que al cancelar, cambia un atributo estático que
                indicará al programa inicial que no se haga nada.*/
        private void toolStripCancelar_MouseUp(object sender, MouseEventArgs e)
        {
            cuadroDialogoValor = DialogResult.Cancel;
            this.Close();
        }
        /* Para otener el valor de si se aceptó, no se aceptó,
            o se canceló la operación.*/
        public static DialogResult GetCuadroDialogoValor()
        {
            return cuadroDialogoValor;
        }
    }
}
