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
    public partial class Form1 : Form
    {
        // Atributo que indica si se abrió un archivo.
        private static bool archivoAbierto = false;
        // Atributo que indica el nombre del archivo actual.
        private static string nombreArchivo = "Sin título: Bloc de Notas";
        // Variable que guarda el texto inicial cuando no se han hecho cambios.
        private string textoInicial = "";
        // Este atributo indica el tamaño de la cadena del nombre del archivo.
        private int tamNombre = "Sin título".Length;
        public Form1()
        {
            InitializeComponent();
        }

        private void archivoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Si se han hecho modificaciones preguntar que si quiere guardar.
            guardarCambios();
            // if(isTextoCambiado())
                // Código de procedimiento aquí.
            OpenFileDialog abrir = new OpenFileDialog();
            // Poner un filtro para el tipo de archivos que se muestran.
            abrir.Filter = "Archivos de texto|*.txt";
            // Se se aceptó abrir un archivo, lo mostrará
            if (abrir.ShowDialog() == DialogResult.OK)
                // Aquí muestra el archivo en la caja de texto.
                richTextBox1.Text = File.ReadAllText(abrir.FileName);

            // Aquí se saca el tamaño del nombre sin la extensión final, por eso le resto 4.
            tamNombre = abrir.SafeFileName.Length - 4;
            // Establecer el nombre del archivo arriba.
            // El SafeFileName regresa el texto sin el directorio.
            this.Text = nombreArchivo = abrir.SafeFileName + ": Bloc de Notas";
            //this.Text = nombreArchivo + ": Bloc de Notas";
            // Como se abrió un archivo, su texto es el inicial.
            textoInicial = richTextBox1.Text;
            // Indicar que ya se abrió un archivo.
            archivoAbierto = true;
        }

        private void guardarComoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "Sin título.txt";
            var save = saveFileDialog1.ShowDialog();
              if(save == DialogResult.OK)
            {
                using (var savefile = new System.IO.StreamWriter(saveFileDialog1.FileName))
                {
                    savefile.WriteLine(saveFileDialog1.FileName);
                }

            }
            // Como se guardó el archivo, entonces el texto inicial es este.
            textoInicial = richTextBox1.Text;
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
        // Método que devuelve si hay un archivo abierto actualmente,
        public static bool isArchivoAbierto()
        {
            return archivoAbierto;
        }
        // Método que regresa el nombre del archivo actual.
        public static string getNombreArchivo()
        {
            return nombreArchivo;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            // Si el texto inicial es diferente al texto actual de la caja de texto, indicarlo.
            if (isTextoCambiado())
                this.Text = "*" + nombreArchivo;
            else // Si la cadena es igual a la inicial, quitar el asterisco.
                this.Text = nombreArchivo;
        }
        // Método que indicará si el texto del archivo ha cambiado o no.
        private bool isTextoCambiado()
        {
            // Si el texto ha cambiado, regresará true.
            return !textoInicial.Equals(richTextBox1.Text);
        }
        /* - Método que preguntará si se quieren guardar los cambios cuando
                se ha modificado el archivo.*/
        private void guardarCambios()
        {
            // Si ha cambiado el texto
            if (isTextoCambiado())
            {   // Si se ha modificado el texto, mostrará la ventana de guardado.
                GuardarComo g = new GuardarComo(nombreArchivo, tamNombre);
                g.ShowDialog();
            }

        }
    }
}
