namespace Notepad
{
    partial class Buscar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Buscar));
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.grupoDireccion = new System.Windows.Forms.GroupBox();
            this.radioButtonSubir = new System.Windows.Forms.RadioButton();
            this.radioButtonBajar = new System.Windows.Forms.RadioButton();
            this.grupoDireccion.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(13, 13);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(284, 20);
            this.txtBuscar.TabIndex = 0;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(141, 56);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.Text = "Buscar siguiente";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnBuscar_MouseUp);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(222, 56);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnCancelar_MouseUp);
            // 
            // grupoDireccion
            // 
            this.grupoDireccion.Controls.Add(this.radioButtonBajar);
            this.grupoDireccion.Controls.Add(this.radioButtonSubir);
            this.grupoDireccion.Location = new System.Drawing.Point(13, 39);
            this.grupoDireccion.Name = "grupoDireccion";
            this.grupoDireccion.Size = new System.Drawing.Size(122, 45);
            this.grupoDireccion.TabIndex = 3;
            this.grupoDireccion.TabStop = false;
            this.grupoDireccion.Text = "Direccion";
            this.grupoDireccion.Visible = false;
            // 
            // radioButtonSubir
            // 
            this.radioButtonSubir.AutoSize = true;
            this.radioButtonSubir.Location = new System.Drawing.Point(7, 20);
            this.radioButtonSubir.Name = "radioButtonSubir";
            this.radioButtonSubir.Size = new System.Drawing.Size(49, 17);
            this.radioButtonSubir.TabIndex = 0;
            this.radioButtonSubir.TabStop = true;
            this.radioButtonSubir.Text = "Subir";
            this.radioButtonSubir.UseVisualStyleBackColor = true;
            this.radioButtonSubir.Visible = false;
            // 
            // radioButtonBajar
            // 
            this.radioButtonBajar.AutoSize = true;
            this.radioButtonBajar.Location = new System.Drawing.Point(62, 20);
            this.radioButtonBajar.Name = "radioButtonBajar";
            this.radioButtonBajar.Size = new System.Drawing.Size(49, 17);
            this.radioButtonBajar.TabIndex = 1;
            this.radioButtonBajar.TabStop = true;
            this.radioButtonBajar.Text = "Bajar";
            this.radioButtonBajar.UseVisualStyleBackColor = true;
            this.radioButtonBajar.Visible = false;
            // 
            // Buscar
            // 
            this.AcceptButton = this.btnBuscar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(310, 92);
            this.Controls.Add(this.grupoDireccion);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtBuscar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Buscar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Buscar";
            this.grupoDireccion.ResumeLayout(false);
            this.grupoDireccion.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox grupoDireccion;
        private System.Windows.Forms.RadioButton radioButtonBajar;
        private System.Windows.Forms.RadioButton radioButtonSubir;
    }
}