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
    public partial class Buscar : Form
    {
        // Este determinará si se canceló o no la operación.
        private static DialogResult cuadroDialogoValor = DialogResult.OK;
        BlocDeNotas formaPrincipal = null;
        int indiceActual, inicio; // Esto indicará el índice actual del cuadro de búsqueda. 
        // Estas cadenas servirán para verificar que no se haya hecho una nueva búsqueda.
        string busquedaInicial, busquedaActual;
        bool nuevaBusqueda = false, primerBusqueda = true;
        public Buscar(Form formaQueLlama)
        {
            /* De esta forma se puede acceder a los elementos de la forma BlocDeNotas
             - FUENTE: https://stackoverflow.com/questions/1665533/communicate-between-two-windows-forms-in-c-sharp
            */
            formaPrincipal = formaQueLlama as BlocDeNotas;
            InitializeComponent();
            indiceActual = inicio = 0; // Reiniciar el índice actual.
            busquedaInicial = busquedaActual = "";
        }
        /* FUENTE: Find text in string with C#
         * https://stackoverflow.com/questions/10709821/find-text-in-string-with-c-sharp
         */
        private void btnBuscar_MouseUp(object sender, MouseEventArgs e)
        {
            //if (primerBusqueda)
            //{   // Si es la primera búsqueda, asignar el texto a la búsqueda inicial.
            //    busquedaInicial = busquedaActual;
            //    primerBusqueda = false;
            //}
            //if (TextoCambio())
            //{ // Reiniciar índices si cambio la búsqueda.
            //    nuevaBusqueda = true;
            //    inicio = indiceActual = 0;
            //    busquedaInicial = busquedaActual;
            //}
            //else // Si el texto no ha cambiado no es una nueva búsqueda.
            //    nuevaBusqueda = false;
            if (this.formaPrincipal.GetRichTextBox().Text.Contains(txtBuscar.Text))
            {
                /* Aquí se verifica si la búsqueda ya sobrepasa los límites de la cadena.
                    - Reiniciaremos los índices de búsqueda para que vuelva a empezar.*/
                // if((indiceActual + txtBuscar.Text.Length) == this.formaPrincipal.GetRichTextBox().Text.Length)
                if (inicio == -1)
                {
                    inicio = indiceActual = 0;
                }
                else
                {
                    // Variable que guarda el índice en donde comienza la cadena para seleccionarla.
                    inicio = this.formaPrincipal.GetRichTextBox().Text.IndexOf(txtBuscar.Text, indiceActual);
                    // Inicio de la cadena y su tamaño.
                    this.formaPrincipal.GetRichTextBox().Select(inicio, txtBuscar.Text.Length);
                    // Mostrar que seleccione la ventana del Bloc para ver la selección.
                    //MessageBox.Show("Presiona la ventana del Bloc de Notas para ver la selección.");
                    // Ahora especificar el índice actual.
                    indiceActual = this.formaPrincipal.GetRichTextBox().Text.LastIndexOf(txtBuscar.Text) - 1;
                }
            }
            else // Si no se encuentra el texto, mostrar ese cuadro.
                MessageBox.Show("No se encontró \"" + txtBuscar.Text + "\"");
        }
        // Método que regresará true si el texto en el cuadro de búsqueda cambió.
        private bool TextoCambio()
        {
            return busquedaActual.Equals(busquedaInicial);
        }
        /* Método que reiniciará los índices de búsqueda cuando se cambie la cadena a buscar.*/
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            busquedaActual = txtBuscar.Text;
            //if(indiceActual == 0 || !busquedaActual.Equals(busquedaInicial))
            //    busquedaInicial = busquedaActual = txtBuscar.Text;
            //if(!busquedaActual.Equals(busquedaInicial))

        }

        private void btnCancelar_MouseUp(object sender, MouseEventArgs e)
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
