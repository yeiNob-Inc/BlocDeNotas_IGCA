namespace Notepad
{
    partial class GuardarComo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GuardarComo));
            this.txtGuardarCambios = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripGuardar = new System.Windows.Forms.ToolStripButton();
            this.toolStripNoGuardar = new System.Windows.Forms.ToolStripButton();
            this.toolStripCancelar = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtGuardarCambios
            // 
            resources.ApplyResources(this.txtGuardarCambios, "txtGuardarCambios");
            this.txtGuardarCambios.Name = "txtGuardarCambios";
            // 
            // toolStrip1
            // 
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripGuardar,
            this.toolStripNoGuardar,
            this.toolStripCancelar});
            this.toolStrip1.Name = "toolStrip1";
            // 
            // toolStripGuardar
            // 
            this.toolStripGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.toolStripGuardar, "toolStripGuardar");
            this.toolStripGuardar.Name = "toolStripGuardar";
            this.toolStripGuardar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.toolStripGuardar_MouseUp);
            // 
            // toolStripNoGuardar
            // 
            this.toolStripNoGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.toolStripNoGuardar, "toolStripNoGuardar");
            this.toolStripNoGuardar.Name = "toolStripNoGuardar";
            // 
            // toolStripCancelar
            // 
            resources.ApplyResources(this.toolStripCancelar, "toolStripCancelar");
            this.toolStripCancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripCancelar.Name = "toolStripCancelar";
            // 
            // GuardarComo
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtGuardarCambios);
            this.Controls.Add(this.toolStrip1);
            this.MaximizeBox = false;
            this.Name = "GuardarComo";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.TopMost = true;
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtGuardarCambios;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripGuardar;
        private System.Windows.Forms.ToolStripButton toolStripNoGuardar;
        private System.Windows.Forms.ToolStripButton toolStripCancelar;
    }
}