using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad
{
    public partial class Buscar : Form
    {
        // Este determinará si se canceló o no la operación.
        private static DialogResult cuadroDialogoValor = DialogResult.OK;
        BlocDeNotas formaPrincipal = null;
        public Buscar(Form formaQueLlama)
        {
            /* De esta forma se puede acceder a los elementos de la forma BlocDeNotas
             - FUENTE: https://stackoverflow.com/questions/1665533/communicate-between-two-windows-forms-in-c-sharp
            */
            formaPrincipal = formaQueLlama as BlocDeNotas;
            InitializeComponent();
        }

        private void btnBuscar_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.formaPrincipal.GetRichTextBox().Text.Contains(txtBuscar.Text))
            {
                // Variable que guarda el índice en donde comienza la cadena para seleccionarla.
                int inicio = this.formaPrincipal.GetRichTextBox().Text.IndexOf(txtBuscar.Text);
                // Inicio de la cadena y su tamaño.
                this.formaPrincipal.GetRichTextBox().Select(inicio, txtBuscar.Text.Length);
                // Ahora reiniciar la posición del inicio de la búsqueda.
                //inicio = this.formaPrincipal.GetRichTextBox().Text.IndexOf(txtBuscar.Text, inicio);
            }
            else // Si no se encuentra el texto, mostrar ese cuadro.
                MessageBox.Show("No se encontró \"" + txtBuscar.Text + "\"");
        }

        private void btnCancelar_MouseUp(object sender, MouseEventArgs e)
        {
            cuadroDialogoValor = DialogResult.Cancel;
            this.Close();
        }
        public static DialogResult GetCuadroDialogoValor()
        {
            return cuadroDialogoValor;
        }
    }
}
