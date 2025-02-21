namespace ControlePedido
{
    partial class frmLocalizarAll
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
            ((System.ComponentModel.ISupportInitialize)(this.grade)).BeginInit();
            this.SuspendLayout();
            // 
            // usBarraTitulo1
            // 
            this.usBarraTitulo1.Size = new System.Drawing.Size(969, 72);
            this.usBarraTitulo1.Load += new System.EventHandler(this.usBarraTitulo1_Load);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 510);
            this.panel1.Size = new System.Drawing.Size(969, 26);
            // 
            // usMenu1
            // 
            this.usMenu1.Size = new System.Drawing.Size(969, 34);
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
            this.grade.Location = new System.Drawing.Point(12, 114);
            this.grade.Name = "grade";
            this.grade.RowHeadersVisible = false;
            this.grade.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grade.Size = new System.Drawing.Size(947, 387);
            this.grade.TabIndex = 4;
            this.grade.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grade_CellContentClick);
            this.grade.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grade_CellDoubleClick);
            // 
            // clmPedido
            // 
            this.clmPedido.HeaderText = "Pedido";
            this.clmPedido.Name = "clmPedido";
            // 
            // frmLocalizarAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 536);
            this.Controls.Add(this.grade);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmLocalizarAll";
            this.Text = "frmLocalizarAll";
            this.Load += new System.EventHandler(this.frmLocalizarAll_Load);
            this.Controls.SetChildIndex(this.usBarraTitulo1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.usMenu1, 0);
            this.Controls.SetChildIndex(this.grade, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grade)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grade;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPedido;
    }
}