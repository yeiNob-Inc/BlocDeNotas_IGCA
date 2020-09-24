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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void archivoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String open;
            openFileDialog1.ShowDialog();
            System.IO.StreamReader file = new System.IO.StreamReader(openFileDialog1.FileName);
            open = file.ReadLine();
            richTextBox1.Text = open.ToString();

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
    }
}
