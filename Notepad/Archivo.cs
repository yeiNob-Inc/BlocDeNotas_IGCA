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
        /* MÉTODO QUE MUESTRA VENTANA DE GUARDAR CAMBIOS SI LO SHAY.*/
        public static void HayCambios(bool isTextoCambiado, string nombreArchivo, int tamNombre)
        {
            // Si ha cambiado el texto
            if (isTextoCambiado)
            {   // Si se ha modificado el texto, mostrará la ventana de guardado.
                GuardarComo g = new GuardarComo(nombreArchivo, tamNombre);
                g.ShowDialog();
            }

        }
        /* Método que mostrará la ventana de guardado.*/
        public static void GuardarComo(string contenido)
        {
            // Aquí se inicializa el cuadro de dialogo para guardar.
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Archivos de texto|*.txt";
            // Aquí se abre un cuadro de diálogo.
            // Si presionamos "save" en el cuadro de diálogo, guardar el archivo.
            if (save.ShowDialog() == DialogResult.OK)
            {   // Aquí se escribe el contenido al archivo que creamos.
                File.WriteAllText(save.FileName, contenido);
                // Si al leer el archivo es igual a la cadena de contenido, mostrar emergente.
                if (File.ReadAllText(save.FileName).Equals(contenido))
                    MessageBox.Show("Archivo guardado con éxito.");
            }
            else
                MessageBox.Show("No se guardó el archivo. No se presionó el botón de guardar.");
        }
        /* Método que guarda el texto en un archivo que ya está creado.
            Si se trata de uno nuevo, mostrar el GuardarComo, si es uno abierto
            o guardado anteriormente, solo sobreescribirlo.*/
        public static void Guardar(bool existeArchivo, string directorio, string contenido)
        {
            // Si el archivo ya existe, sobreescribirlo.
            if (existeArchivo)
                File.WriteAllText(directorio, contenido);
            else // Si no existe el archivo, llamar a GuardarComo().
                GuardarComo(contenido);

        }
    }
}
