namespace ControlePedido
{
    partial class frmLocalizarPedido
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
            this.grade = new System.Windows.Forms.DataGridView();
            this.clmPedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblAviso = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grade)).BeginInit();
            this.SuspendLayout();
            // 
            // usBarraTitulo1
            // 
            this.usBarraTitulo1.Size = new System.Drawing.Size(1426, 72);
            this.usBarraTitulo1.valor = "Localizar Pedidos";
            this.usBarraTitulo1.Load += new System.EventHandler(this.usBarraTitulo1_Load);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 761);
            this.panel1.Size = new System.Drawing.Size(1426, 26);
            // 
            // usMenu1
            // 
            this.usMenu1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usMenu1.Dock = System.Windows.Forms.DockStyle.None;
            this.usMenu1.Size = new System.Drawing.Size(1426, 34);
            this.usMenu1.Load += new System.EventHandler(this.usMenu1_Load);
            // 
            // grade
            // 
            this.grade.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grade.BackgroundColor = System.Drawing.SystemColors.Control;
            this.grade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grade.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmPedido});
            this.grade.Location = new System.Drawing.Point(12, 112);
            this.grade.Name = "grade";
            this.grade.RowHeadersVisible = false;
            this.grade.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grade.Size = new System.Drawing.Size(1402, 594);
            this.grade.TabIndex = 2;
            this.grade.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grade_CellContentClick);
            this.grade.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grade_CellDoubleClick);
            // 
            // clmPedido
            // 
            this.clmPedido.HeaderText = "Pedido";
            this.clmPedido.Name = "clmPedido";
            // 
            // lblAviso
            // 
            this.lblAviso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAviso.AutoSize = true;
            this.lblAviso.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAviso.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblAviso.Location = new System.Drawing.Point(1148, 18);
            this.lblAviso.Name = "lblAviso";
            this.lblAviso.Size = new System.Drawing.Size(242, 30);
            this.lblAviso.TabIndex = 14;
            this.lblAviso.Text = "Aguarde Processando....";
            this.lblAviso.Visible = false;
            // 
            // frmLocalizarPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1426, 787);
            this.Controls.Add(this.lblAviso);
            this.Controls.Add(this.grade);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmLocalizarPedido";
            this.Text = "frmLocalizarPedido";
            this.Load += new System.EventHandler(this.frmLocalizarPedido_Load);
            this.Controls.SetChildIndex(this.usMenu1, 0);
            this.Controls.SetChildIndex(this.usBarraTitulo1, 0);
            this.Controls.SetChildIndex(this.grade, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.lblAviso, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grade)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grade;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPedido;
        private System.Windows.Forms.Label lblAviso;
    }
}