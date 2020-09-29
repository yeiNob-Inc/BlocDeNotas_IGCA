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
            // Size textSize = TextRenderer.MeasureText("¿Quieres guardar los cambios en " + nombreArchivo + "?", this.Font);
            //  ("¿Quieres guardar los cambios en " + nombreArchivo + "?").Length;
            // this.Width = textSize.Width;
            //this.Height = textSize.Height;
            txtGuardarCambios.Text = "¿Quieres guardar los cambios en " + nombreArchivo + "?";
        }

        private void toolStripGuardar_MouseUp(object sender, MouseEventArgs e)
        {
            cuadroDialogoValor = DialogResult.OK;
            Archivo.Guardar(contenido);
            this.Close();
        }

        private void toolStripNoGuardar_MouseUp(object sender, MouseEventArgs e)
        {
            cuadroDialogoValor = DialogResult.No;
            this.Close();
        }

        // No sé muy bien cómo implementar lo de cancelar.
        private void toolStripCancelar_MouseUp(object sender, MouseEventArgs e)
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
