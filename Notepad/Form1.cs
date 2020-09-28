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
        private static string nombreArchivo = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void archivoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //String open;
            //openFileDialog1.ShowDialog();
            //System.IO.StreamReader file = new System.IO.StreamReader(openFileDialog1.FileName);
            //open = file.ReadLine();
            //richTextBox1.Text = open.ToString();

            OpenFileDialog open = new OpenFileDialog();
            // Poner un filtro para el tipo de archivos que se muestran.
            open.Filter = "Archivos de texto|*.txt";
            // Se se aceptó abrir un archivo, lo mostrará
            if (open.ShowDialog() == DialogResult.OK)
                // Aquí muestra el archivo en la caja de texto.
                richTextBox1.Text = File.ReadAllText(open.FileName);

            // Establecer el nombre del archivo arriba.
            this.Text = open.FileName + ".txt: Bloc de Notas";
            // Indicar que ya se abrió un archivo.
            archivoAbierto = true;
        }

        private void guardarComoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "Untitled.txt";
            var save = saveFileDialog1.ShowDialog();
              if(save == DialogResult.OK)
            {
                using (var savefile = new System.IO.StreamWriter(saveFileDialog1.FileName))
                {
                    savefile.WriteLine(saveFileDialog1.FileName);
                }

            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();

            this.Text = "Sin título: Bloc de Notas";
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
    }
}
