using System.Windows.Forms;

namespace Notepad
{
    public partial class Buscar : Form
    {
        BlocDeNotas formaPrincipal = null;
        int indiceActual, inicio; // Esto indicará el índice actual del cuadro de búsqueda.
        public Buscar(Form formaQueLlama)
        {
            /* De esta forma se puede acceder a los elementos de la forma BlocDeNotas
             - FUENTE: https://stackoverflow.com/questions/1665533/communicate-between-two-windows-forms-in-c-sharp

            */
            formaPrincipal = formaQueLlama as BlocDeNotas;
            InitializeComponent();
            indiceActual = inicio = 0; // Reiniciar el índice actual.
        }
        /* FUENTE: Find text in string with C#
         * https://stackoverflow.com/questions/10709821/find-text-in-string-with-c-sharp
         */
        private void btnBuscar_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.formaPrincipal.GetRichTextBox().Text.Contains(txtBuscar.Text))
            {
                // Variable que guarda el índice en donde comienza la cadena para seleccionarla.
                inicio = this.formaPrincipal.GetRichTextBox().Text.IndexOf(txtBuscar.Text, indiceActual);
                // Si el índice del inicio se vuelve -1 por no encontrar la cadena al frente, reiniciarlos.
                if (inicio == -1)
                {
                    // Volver a hacer la búsqueda con el índice reiniciado.
                    inicio = this.formaPrincipal.GetRichTextBox().Text.IndexOf(txtBuscar.Text, indiceActual = 0);
                }
                this.formaPrincipal.GetRichTextBox().Select(inicio, txtBuscar.Text.Length);
                // Mostrar que seleccione la ventana del Bloc para ver la selección.
                MessageBox.Show("Presiona la ventana del Bloc de Notas para ver la selección.");
                // Ahora especificar el índice actual, que es el inicio más el tamaño del texto.
                indiceActual = inicio + txtBuscar.Text.Length;
            }
            else // Si no se encuentra el texto, mostrar ese cuadro.
                MessageBox.Show("No se encontró \"" + txtBuscar.Text + "\"");
        }
        private void btnCancelar_MouseUp(object sender, MouseEventArgs e)
        {
            this.Close();
        }
    }
}
