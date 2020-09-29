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
        
        
        public BlocDeNotas()
        {
            InitializeComponent();
        }

        private void archivoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Si se han hecho modificaciones preguntar que si quiere guardar.
            Archivo.HayCambios(IsTextoCambiado(), nombreArchivo, tamNombre); ;
            // if(isTextoCambiado())
            // Código de procedimiento aquí.

            nombreArchivo = Archivo.AbrirArchivo(richTextBox1);
            // Aquí se saca el tamaño del nombre sin la extensión final, por eso le resto 4.
            tamNombre = nombreArchivo.Length - 4;
            // Establecer el nombre del archivo arriba.
            // El SafeFileName regresa el texto sin el directorio.
            this.Text = nombreArchivo += ": Bloc de Notas";
            //this.Text = nombreArchivo + ": Bloc de Notas";
            // Como se abrió un archivo, su texto es el inicial.
            textoInicial = richTextBox1.Text;
            // Indicar que ya se abrió un archivo.
            archivoAbierto = existeArchivo = true;
        }

        private void guardarComoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Archivo.GuardarComo(richTextBox1.Text);
            // Como se guardó el archivo, entonces el texto inicial es este.
            textoInicial = richTextBox1.Text;
            existeArchivo = true;
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Archivo.HayCambios(IsTextoCambiado(), );
            Environment.Exit(0);
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();

            this.Text = nombreArchivo = "Sin título: Bloc de Notas";
            // Indicar que ahora mismo no hay un archivo abierto, ya que este es nuevo y no tiene título.
            archivoAbierto = false;
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
            this.Text = Archivo.AsteriscoEnTitulo(IsTextoCambiado());
        }
        // Método que indicará si el texto del archivo ha cambiado o no.
        private bool IsTextoCambiado()
        {
            // Si el texto ha cambiado, regresará true.
            return !textoInicial.Equals(richTextBox1.Text);
        }
        /* - Método que preguntará si se quieren guardar los cambios cuando
                se ha modificado el archivo.*/
        
    }
}
