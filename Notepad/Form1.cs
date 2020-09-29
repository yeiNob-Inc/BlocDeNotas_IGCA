using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Notepad
{
    public partial class BlocDeNotas : Form
    {
        
        
        // Variable que guarda el texto inicial cuando no se han hecho cambios.
        private string textoInicial = "";
        // Atributo que guardará la cadena para el título de la ventana del Bloc.
        private string tituloBloc = "Sin título: Bloc de Notas";

        public BlocDeNotas()
        {
            InitializeComponent();
        }

        private void archivoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Archivo.HayCambios(IsTextoCambiado(), richTextBox1.Text);
            if (GuardarComo.GetCuadroDialogoValor() != DialogResult.Cancel)
            {
                Archivo.AbrirArchivo(richTextBox1);
                CambiarTitulo();
                // Como se abrió un archivo, su texto es el inicial.
                textoInicial = richTextBox1.Text;
            }
        }

        private void guardarComoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Archivo.GuardarComo(richTextBox1.Text);
            if (GuardarComo.GetCuadroDialogoValor() != DialogResult.Cancel)
            {
                CambiarTitulo();
                // Como se guardó el archivo, entonces el texto inicial es este.
                textoInicial = richTextBox1.Text;
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Archivo.HayCambios(IsTextoCambiado(), richTextBox1.Text);
            if (GuardarComo.GetCuadroDialogoValor() != DialogResult.Cancel)
                Environment.Exit(0);
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Archivo.HayCambios(IsTextoCambiado(), richTextBox1.Text);
            if (GuardarComo.GetCuadroDialogoValor() != DialogResult.Cancel)
            {
                richTextBox1.Clear();
                textoInicial = richTextBox1.Text;
                this.Text = tituloBloc = "Sin título: Bloc de Notas";
                Archivo.SetExisteArchivoFalse();
            }
        }

        private void copiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void cortarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void pegarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void fuenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog myFont  = new FontDialog();
            myFont.Font = richTextBox1.Font;
            if (myFont.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Font = myFont.Font;
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            AsteriscoEnTitulo(); //Para poner un asterisco si el texto cambió.
            // this.Text = tituloBloc;
        }
        /* - MÉTODO QUE PONE UN ASTERISCO AL INICIO SI HAY UN CAMBIO EN EL ARCHIVO.*/
        private void AsteriscoEnTitulo()
        {
            // Si el texto inicial es diferente al texto actual de la caja de texto, indicarlo.
            if (IsTextoCambiado())
                this.Text = "*" + CambiarTitulo();
            else // Si la cadena es igual a la inicial, quitar el asterisco.
                this.Text = CambiarTitulo();
        }
        /* - Método que cambia el atributo del título del bloc.*/
        private string CambiarTitulo()
        {
            this.Text = Archivo.GetNombreArchivo() + ": Bloc de notas";
            return tituloBloc = Archivo.GetNombreArchivo() + ": Bloc de notas";
        }
        // Método que indicará si el texto del archivo ha cambiado o no.
        private bool IsTextoCambiado()
        {
            // Si el texto ha cambiado, regresará true.
            return !textoInicial.Equals(richTextBox1.Text);
        }

        // Evento para que cuando se le dé a la "X" y se esté cerrando, se fije si hay cambios.
        private void BlocDeNotas_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Esta no sé cómo evitar que se cierre.
            Archivo.HayCambios(IsTextoCambiado(), richTextBox1.Text);
        }
        /* FUENTE: Find text in string with C#
         * https://stackoverflow.com/questions/10709821/find-text-in-string-with-c-sharp
         */
        private void buscarToolStripMenuItem_MouseUp(object sender, MouseEventArgs e)
        {
            Buscar b = new Buscar(richTextBox1);
            b.ShowDialog();
        }
        /* - Método que preguntará si se quieren guardar los cambios cuando
se ha modificado el archivo.*/

    }
}
