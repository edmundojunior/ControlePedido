namespace ControlePedido
{
    partial class frmBase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBase));
            this.usBarraTitulo1 = new ControlePedido.usBarraTitulo();
            this.panel1 = new System.Windows.Forms.Panel();
            this.usMenu1 = new ControlePedido.usMenu();
            this.SuspendLayout();
            // 
            // usBarraTitulo1
            // 
            this.usBarraTitulo1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.usBarraTitulo1.Dock = System.Windows.Forms.DockStyle.Top;
            this.usBarraTitulo1.Location = new System.Drawing.Point(0, 0);
            this.usBarraTitulo1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.usBarraTitulo1.Name = "usBarraTitulo1";
            this.usBarraTitulo1.Size = new System.Drawing.Size(1478, 72);
            this.usBarraTitulo1.TabIndex = 0;
            this.usBarraTitulo1.TabStop = false;
            this.usBarraTitulo1.valor = "";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 734);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1478, 26);
            this.panel1.TabIndex = 2;
            // 
            // usMenu1
            // 
            this.usMenu1.BackColor = System.Drawing.Color.Gainsboro;
            this.usMenu1.Dock = System.Windows.Forms.DockStyle.Top;
            this.usMenu1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usMenu1.Location = new System.Drawing.Point(0, 72);
            this.usMenu1.Name = "usMenu1";
            this.usMenu1.Size = new System.Drawing.Size(1478, 34);
            this.usMenu1.TabIndex = 3;
            this.usMenu1.TabStop = false;
            // 
            // frmBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1478, 760);
            this.Controls.Add(this.usMenu1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.usBarraTitulo1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmBase_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public usBarraTitulo usBarraTitulo1;
        public System.Windows.Forms.Panel panel1;
        public usMenu usMenu1;
    }
}