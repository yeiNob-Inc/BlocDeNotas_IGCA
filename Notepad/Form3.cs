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
        RichTextBox contenido;
        public Buscar(RichTextBox contenido)
        {
            InitializeComponent();
            this.contenido = contenido;
        }

        private void btnBuscar_MouseUp(object sender, MouseEventArgs e)
        {
            if (contenido.Text.Contains(txtBuscar.Text))
            {
                // Variable que guarda el índice en donde comienza la cadena para seleccionarla.
                int inicio = contenido.Text.IndexOf(contenido.Text);
                // Inicio de la cadena y su tamaño.
                contenido.Select(inicio, txtBuscar.Text.Length);
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
