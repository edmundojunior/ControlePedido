namespace ControlePedido
{
    partial class frmEstoque
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
            this.lblAviso = new System.Windows.Forms.Label();
            this.grade = new System.Windows.Forms.DataGridView();
            this.clmPedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gradeProdutos = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradeProdutos)).BeginInit();
            this.SuspendLayout();
            // 
            // usBarraTitulo1
            // 
            this.usBarraTitulo1.Size = new System.Drawing.Size(1123, 72);
            this.usBarraTitulo1.valor = "Estoque";
            this.usBarraTitulo1.Load += new System.EventHandler(this.usBarraTitulo1_Load);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 665);
            this.panel1.Size = new System.Drawing.Size(1123, 40);
            // 
            // usMenu1
            // 
            this.usMenu1.Size = new System.Drawing.Size(1123, 34);
            this.usMenu1.Load += new System.EventHandler(this.usMenu1_Load);
            // 
            // lblAviso
            // 
            this.lblAviso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAviso.AutoSize = true;
            this.lblAviso.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAviso.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblAviso.Location = new System.Drawing.Point(854, 20);
            this.lblAviso.Name = "lblAviso";
            this.lblAviso.Size = new System.Drawing.Size(242, 30);
            this.lblAviso.TabIndex = 19;
            this.lblAviso.Text = "Aguarde Processando....";
            this.lblAviso.Visible = false;
            // 
            // grade
            // 
            this.grade.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grade.BackgroundColor = System.Drawing.SystemColors.Control;
            this.grade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grade.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmPedido});
            this.grade.Location = new System.Drawing.Point(13, 383);
            this.grade.Name = "grade";
            this.grade.RowHeadersVisible = false;
            this.grade.RowHeadersWidth = 51;
            this.grade.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grade.Size = new System.Drawing.Size(1097, 250);
            this.grade.TabIndex = 5;
            this.grade.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grade_CellContentClick);
            // 
            // clmPedido
            // 
            this.clmPedido.HeaderText = "Pedido";
            this.clmPedido.MinimumWidth = 6;
            this.clmPedido.Name = "clmPedido";
            this.clmPedido.Width = 125;
            // 
            // gradeProdutos
            // 
            this.gradeProdutos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gradeProdutos.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gradeProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gradeProdutos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1});
            this.gradeProdutos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gradeProdutos.Location = new System.Drawing.Point(13, 112);
            this.gradeProdutos.Name = "gradeProdutos";
            this.gradeProdutos.RowHeadersVisible = false;
            this.gradeProdutos.RowHeadersWidth = 51;
            this.gradeProdutos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gradeProdutos.Size = new System.Drawing.Size(1097, 260);
            this.gradeProdutos.TabIndex = 6;
            this.gradeProdutos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gradeProdutos_CellClick);
            this.gradeProdutos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gradeProdutos_CellContentClick);
            this.gradeProdutos.SelectionChanged += new System.EventHandler(this.gradeProdutos_SelectionChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Pedido";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(946, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // frmEstoque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1123, 705);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblAviso);
            this.Controls.Add(this.gradeProdutos);
            this.Controls.Add(this.grade);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmEstoque";
            this.Load += new System.EventHandler(this.frmEstoque_Load);
            this.Controls.SetChildIndex(this.usBarraTitulo1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.usMenu1, 0);
            this.Controls.SetChildIndex(this.grade, 0);
            this.Controls.SetChildIndex(this.gradeProdutos, 0);
            this.Controls.SetChildIndex(this.lblAviso, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradeProdutos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblAviso;
        private System.Windows.Forms.DataGridView grade;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPedido;
        private System.Windows.Forms.DataGridView gradeProdutos;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.Label label1;
    }
}