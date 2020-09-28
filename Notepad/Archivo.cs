using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; // Para los archivos.

/* Clase que manejará lo que tiene que ver con archivos.
 - Será abstracta, ya que no necesitaremos instanciarla.
 - Los métodos serán estáticos por lo mismo.*/

namespace Notepad
{
    abstract class Archivo
    {
        /* Método que abre el cuadro para abrir un archivo,
            y regresa su nombre.*/
        public static string AbrirArchivo(RichTextBox texto)
        {
            OpenFileDialog abrir = new OpenFileDialog();
            // Poner un filtro para el tipo de archivos que se muestran.
            abrir.Filter = "Archivos de texto|*.txt";
            // Se se aceptó abrir un archivo, lo mostrará
            if (abrir.ShowDialog() == DialogResult.OK)
                // Aquí muestra el archivo en la caja de texto.
                texto.Text = File.ReadAllText(abrir.FileName);

            return abrir.SafeFileName;
        }
    }
}
