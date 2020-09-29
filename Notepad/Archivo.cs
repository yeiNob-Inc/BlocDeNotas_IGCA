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
        // Este atributo indica el tamaño de la cadena del nombre del archivo.
        private static int tamNombre = "Sin título".Length;
        // Atributo que indica el nombre del archivo actual.
        private static string nombreArchivo = "Sin título";
        // Aquí se guardará el directorio del archivo actual.
        private static string directorio = "";
        // Atributo que indica si se abrió un archivo.
        private static bool archivoAbierto = false;
        // Atributo que indicará si está abierto un archivo existente o no.
        private static bool existeArchivo = false;
        /* Método que abre el cuadro para abrir un archivo,
            y regresa su nombre.*/
        public static void AbrirArchivo(RichTextBox texto)
        {
            OpenFileDialog abrir = new OpenFileDialog();
            // Poner un filtro para el tipo de archivos que se muestran.
            abrir.Filter = "Archivos de texto|*.txt";
            // Se se aceptó abrir un archivo, lo mostrará
            if (abrir.ShowDialog() == DialogResult.OK)
            {
                // Aquí muestra el archivo en la caja de texto.
                texto.Text = File.ReadAllText(abrir.FileName);
                // Aquí guarda el nombre del archivo con su extensión.
                nombreArchivo = abrir.SafeFileName;
                Console.WriteLine("\n -> Nombre del archivo: " + nombreArchivo);
                // Aquí cambiamos el tamaño del nombre restándole su extensión.
                tamNombre = nombreArchivo.Length - 4;
                // Aquí se guarda el directorio con el nombre del archivo.
                directorio = abrir.FileName;
                // Indicar que el archivo actual ya está guardado.
                existeArchivo = true;
                // Indicar que ya hay un archivo abierto.
                archivoAbierto = true;
                //// Cambiamos el título de la ventana.
                //CambiarTitulo(nombreArchivo);
            }
            //return abrir.SafeFileName;
        }
        /* MÉTODO QUE MUESTRA VENTANA DE GUARDAR CAMBIOS SI LOS HAY.
            - Esta es para los siguientes escenarios:
                -> Vamos a abrir un archivo.
                -> Vamos a crear un nuevo archivo.
                -> Vamos a salir del Bloc sin guardar.*/
        public static void HayCambios(bool isTextoCambiado)
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
            SaveFileDialog guardar = new SaveFileDialog();
            // Variable que me dejará sacar el nombre del archivo sin directorio.
            OpenFileDialog abrir = new OpenFileDialog();
            // Esto filtrará el tipo de archivos que salgan en pantalla.
            guardar.Filter = "Archivos de texto|*.txt";
            guardar.FileName = "Sin título.txt"; // Este nombre es el que saldrá al abrir la ventana de guardado.
            // Aquí se abre un cuadro de diálogo.
            // Si presionamos "save" en el cuadro de diálogo, guardar el archivo.
            if (guardar.ShowDialog() == DialogResult.OK)
            {   // Aquí se escribe el contenido al archivo que creamos.
                File.WriteAllText(guardar.FileName, contenido);
                // Si al leer el archivo es igual a la cadena de contenido, mostrar emergente.
                if (File.ReadAllText(guardar.FileName).Equals(contenido))
                {
                    // Asignamos a abrir.FileName el directorio completo del guardado.
                    abrir.FileName = guardar.FileName;
                    // Aquí guarda el nombre del archivo con su extensión con "abrir", que "guardar" no tiene el método.
                    nombreArchivo = abrir.SafeFileName;
                    // Aquí cambiamos el tamaño del nombre restándole su extensión.
                    tamNombre = nombreArchivo.Length - 4;
                    // Aquí se guarda el directorio con el nombre del archivo.
                    directorio = guardar.FileName;
                    // Indicar que el archivo actual ya está guardado.
                    existeArchivo = true;
                    // Indicar que ya hay un archivo abierto.
                    archivoAbierto = true;
                    //// Cambiamos el título de la ventana.
                    //CambiarTitulo(nombreArchivo);
                    MessageBox.Show("Archivo guardado con éxito.");
                }
            }
            else
                MessageBox.Show("No se guardó el archivo. No se presionó el botón de guardar.");
        }
        /* Método que guarda el texto en un archivo que ya está creado.
            Si se trata de uno nuevo, mostrar el GuardarComo, si es uno abierto
            o guardado anteriormente, solo sobreescribirlo.*/
        public static void Guardar(string contenido)
        {
            // Si el archivo ya existe, sobreescribirlo.
            if (existeArchivo) // Aquí no se cambia ningún atributo porque ya existía.
                File.WriteAllText(directorio, contenido);
            else // Si no existe el archivo, llamar a GuardarComo().
                GuardarComo(contenido);
        }
        
        
        // Método que devuelve si hay un archivo abierto actualmente,
        public static bool IsArchivoAbierto()
        {
            return archivoAbierto;
        }
        // Método que regresa el nombre del archivo actual.
        public static string GetNombreArchivo()
        {
            return nombreArchivo;
        }
        // Método que establece que el archivo no existe.
        public static void SetExisteArchivoFalse()
        {
            existeArchivo = false;
        }
        ///* - Método que cambia los atributos de nomreArchivo, directorio, y esos.*/
        //private static void cambiarAtributosArchivo(FileDialog archivo)
        //{
        //    // Aquí guarda el nombre del archivo con su extensión.
        //    nombreArchivo = abrir.SafeFileName;
        //    // Aquí cambiamos el tamaño del nombre restándole su extensión.
        //    tamNombre = nombreArchivo.Length - 4;
        //    // Aquí se guarda el directorio con el nombre del archivo.
        //    directorio = abrir.FileName;
        //    // Indicar que el archivo actual ya está guardado.
        //    existeArchivo = true;
        //    // Indicar que ya hay un archivo abierto.
        //    archivoAbierto = true;
        //    // Cambiamos el título de la ventana.
        //    CambiarTitulo(nombreArchivo);

        //}
    }
}
