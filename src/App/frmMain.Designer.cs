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
            this.submenuClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.submenuClientesAlta = new System.Windows.Forms.ToolStripMenuItem();
            this.submenuClientesModificacion = new System.Windows.Forms.ToolStripMenuItem();
            this.submenuClientesBaja = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(904, 24);
            this.mainMenu.TabIndex = 1;
            this.mainMenu.Text = "menuStrip1";
            // 
            // submenuClientes
            // 
            this.submenuClientes.Name = "submenuClientes";
            this.submenuClientes.Size = new System.Drawing.Size(61, 20);
            this.submenuClientes.Text = "Clientes";
            // 
            // submenuClientesAlta
            // 
            this.submenuClientesAlta.Name = "submenuClientesAlta";
            this.submenuClientesAlta.Size = new System.Drawing.Size(180, 22);
            this.submenuClientesAlta.Text = "Alta de Cliente";
            // 
            // submenuClientesModificacion
            // 
            this.submenuClientesModificacion.Name = "submenuClientesModificacion";
            this.submenuClientesModificacion.Size = new System.Drawing.Size(180, 22);
            this.submenuClientesModificacion.Text = "Modificación";
            // 
            // submenuClientesBaja
            // 
            this.submenuClientesBaja.Name = "submenuClientesBaja";
            this.submenuClientesBaja.Size = new System.Drawing.Size(180, 22);
            this.submenuClientesBaja.Text = "Baja";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 347);
            this.Controls.Add(this.mainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mainMenu;
            this.Margin = new System.Windows.Forms.Padding(2);
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
        private System.Windows.Forms.ToolStripMenuItem submenuClientes;
        private System.Windows.Forms.ToolStripMenuItem submenuClientesAlta;
        private System.Windows.Forms.ToolStripMenuItem submenuClientesModificacion;
        private System.Windows.Forms.ToolStripMenuItem submenuClientesBaja;
    }
}

