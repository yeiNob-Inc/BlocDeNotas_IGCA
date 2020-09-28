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
    public partial class GuardarComo : Form
    {
        public GuardarComo()
        {
            InitializeComponent();
        }
        public GuardarComo(string nombreArchivo, int tamNombre)
        {
            InitializeComponent();
            // Se saca el nombre original del archivo.
            nombreArchivo = nombreArchivo.Substring(0, tamNombre);
            Size textSize = TextRenderer.MeasureText("¿Quieres guardar los cambios en " + nombreArchivo + "?", this.Font);
            //  ("¿Quieres guardar los cambios en " + nombreArchivo + "?").Length;
            this.Width = textSize.Width;
            //this.Height = textSize.Height;
            txtGuardarCambios.Text = "¿Quieres guardar los cambios en " + nombreArchivo + "?";
        }
    }
}
