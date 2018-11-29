namespace PalcoNet
{
    partial class frmMain
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.mainMenuClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenuClientesAlta = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenuClientesModificacion = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenuClientesBaja = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainMenuClientes});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.mainMenu.Size = new System.Drawing.Size(1356, 35);
            this.mainMenu.TabIndex = 3;
            this.mainMenu.Text = "menuStrip1";
            // 
            // mainMenuClientes
            // 
            this.mainMenuClientes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainMenuClientesAlta,
            this.mainMenuClientesModificacion,
            this.mainMenuClientesBaja});
            this.mainMenuClientes.Name = "mainMenuClientes";
            this.mainMenuClientes.Size = new System.Drawing.Size(85, 29);
            this.mainMenuClientes.Text = "Clientes";
            // 
            // mainMenuClientesAlta
            // 
            this.mainMenuClientesAlta.Name = "mainMenuClientesAlta";
            this.mainMenuClientesAlta.Size = new System.Drawing.Size(252, 30);
            this.mainMenuClientesAlta.Text = "Alta";
            // 
            // mainMenuClientesModificacion
            // 
            this.mainMenuClientesModificacion.Name = "mainMenuClientesModificacion";
            this.mainMenuClientesModificacion.Size = new System.Drawing.Size(252, 30);
            this.mainMenuClientesModificacion.Text = "Modificación";
            this.mainMenuClientesModificacion.Click += new System.EventHandler(this.mainMenuClientesModificacion_Click);
            // 
            // mainMenuClientesBaja
            // 
            this.mainMenuClientesBaja.Name = "mainMenuClientesBaja";
            this.mainMenuClientesBaja.Size = new System.Drawing.Size(252, 30);
            this.mainMenuClientesBaja.Text = "Baja";
            this.mainMenuClientesBaja.Click += new System.EventHandler(this.mainMenuClientesBaja_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1356, 534);
            this.Controls.Add(this.mainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Palco";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem mainMenuClientes;
        private System.Windows.Forms.ToolStripMenuItem mainMenuClientesAlta;
        private System.Windows.Forms.ToolStripMenuItem mainMenuClientesModificacion;
        private System.Windows.Forms.ToolStripMenuItem mainMenuClientesBaja;
    }
}

