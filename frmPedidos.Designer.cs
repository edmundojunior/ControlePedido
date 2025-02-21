namespace ControlePedido
{
    partial class frmPedidos
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
            this.gradeEntregue = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPedido = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lblCliente = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblAviso = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.bntEntregar = new System.Windows.Forms.Button();
            this.btnDesmarcar = new System.Windows.Forms.Button();
            this.btnMarcar = new System.Windows.Forms.Button();
            this.btnMarcarDevolver = new System.Windows.Forms.Button();
            this.btnSubir = new System.Windows.Forms.Button();
            this.btnDesmarcarDevolver = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradeEntregue)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // usBarraTitulo1
            // 
            this.usBarraTitulo1.Size = new System.Drawing.Size(1448, 72);
            this.usBarraTitulo1.valor = "Manutenção de Pedidos";
            this.usBarraTitulo1.Load += new System.EventHandler(this.usBarraTitulo1_Load);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 676);
            this.panel1.Size = new System.Drawing.Size(1448, 50);
            // 
            // usMenu1
            // 
            this.usMenu1.Size = new System.Drawing.Size(1448, 34);
            // 
            // grade
            // 
            this.grade.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grade.BackgroundColor = System.Drawing.SystemColors.Control;
            this.grade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grade.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmPedido});
            this.grade.Location = new System.Drawing.Point(14, 204);
            this.grade.Name = "grade";
            this.grade.RowHeadersVisible = false;
            this.grade.RowHeadersWidth = 51;
            this.grade.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grade.Size = new System.Drawing.Size(1410, 287);
            this.grade.TabIndex = 4;
            this.grade.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grade_CellContentClick);
            // 
            // clmPedido
            // 
            this.clmPedido.HeaderText = "Pedido";
            this.clmPedido.MinimumWidth = 6;
            this.clmPedido.Name = "clmPedido";
            this.clmPedido.Width = 125;
            // 
            // gradeEntregue
            // 
            this.gradeEntregue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gradeEntregue.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gradeEntregue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gradeEntregue.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1});
            this.gradeEntregue.Location = new System.Drawing.Point(14, 527);
            this.gradeEntregue.Name = "gradeEntregue";
            this.gradeEntregue.RowHeadersVisible = false;
            this.gradeEntregue.RowHeadersWidth = 51;
            this.gradeEntregue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gradeEntregue.Size = new System.Drawing.Size(1410, 143);
            this.gradeEntregue.TabIndex = 5;
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
            this.label1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(33, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Pedido:";
            // 
            // txtPedido
            // 
            this.txtPedido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPedido.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPedido.Location = new System.Drawing.Point(80, 17);
            this.txtPedido.Name = "txtPedido";
            this.txtPedido.Size = new System.Drawing.Size(100, 22);
            this.txtPedido.TabIndex = 0;
            this.txtPedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPedido.TextChanged += new System.EventHandler(this.txtPedido_TextChanged);
            this.txtPedido.Enter += new System.EventHandler(this.txtPedido_Enter);
            this.txtPedido.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPedido_KeyDown);
            this.txtPedido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPedido_KeyPress);
            this.txtPedido.Leave += new System.EventHandler(this.txtPedido_Leave);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gainsboro;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(186, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(29, 23);
            this.button1.TabIndex = 8;
            this.button1.TabStop = false;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblCliente.Location = new System.Drawing.Point(224, 22);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(19, 13);
            this.lblCliente.TabIndex = 9;
            this.lblCliente.Text = "....";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Relação de Produtos";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Produtos a Entregar:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 506);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Produtos Entregues:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblAviso);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtPedido);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.lblCliente);
            this.panel2.Location = new System.Drawing.Point(0, 106);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1448, 47);
            this.panel2.TabIndex = 13;
            // 
            // lblAviso
            // 
            this.lblAviso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAviso.AutoSize = true;
            this.lblAviso.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAviso.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblAviso.Location = new System.Drawing.Point(1080, 7);
            this.lblAviso.Name = "lblAviso";
            this.lblAviso.Size = new System.Drawing.Size(242, 30);
            this.lblAviso.TabIndex = 13;
            this.lblAviso.Text = "Aguarde Processando....";
            this.lblAviso.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Filtro:";
            // 
            // bntEntregar
            // 
            this.bntEntregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bntEntregar.BackColor = System.Drawing.Color.Transparent;
            this.bntEntregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bntEntregar.Enabled = false;
            this.bntEntregar.FlatAppearance.BorderSize = 0;
            this.bntEntregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bntEntregar.Image = global::ControlePedido.Properties.Resources.descer1;
            this.bntEntregar.Location = new System.Drawing.Point(1387, 173);
            this.bntEntregar.Name = "bntEntregar";
            this.bntEntregar.Size = new System.Drawing.Size(37, 25);
            this.bntEntregar.TabIndex = 17;
            this.bntEntregar.UseVisualStyleBackColor = false;
            this.bntEntregar.Click += new System.EventHandler(this.bntEntregar_Click);
            // 
            // btnDesmarcar
            // 
            this.btnDesmarcar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDesmarcar.BackColor = System.Drawing.Color.Transparent;
            this.btnDesmarcar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDesmarcar.Enabled = false;
            this.btnDesmarcar.FlatAppearance.BorderSize = 0;
            this.btnDesmarcar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDesmarcar.Image = global::ControlePedido.Properties.Resources.desmarcar;
            this.btnDesmarcar.Location = new System.Drawing.Point(1344, 173);
            this.btnDesmarcar.Name = "btnDesmarcar";
            this.btnDesmarcar.Size = new System.Drawing.Size(37, 25);
            this.btnDesmarcar.TabIndex = 16;
            this.btnDesmarcar.UseVisualStyleBackColor = false;
            this.btnDesmarcar.Click += new System.EventHandler(this.btnDesmarcar_Click);
            // 
            // btnMarcar
            // 
            this.btnMarcar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMarcar.BackColor = System.Drawing.Color.Transparent;
            this.btnMarcar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMarcar.Enabled = false;
            this.btnMarcar.FlatAppearance.BorderSize = 0;
            this.btnMarcar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMarcar.Image = global::ControlePedido.Properties.Resources.marcar1;
            this.btnMarcar.Location = new System.Drawing.Point(1301, 173);
            this.btnMarcar.Name = "btnMarcar";
            this.btnMarcar.Size = new System.Drawing.Size(37, 25);
            this.btnMarcar.TabIndex = 18;
            this.btnMarcar.UseVisualStyleBackColor = false;
            this.btnMarcar.Click += new System.EventHandler(this.btnMarcar_Click);
            // 
            // btnMarcarDevolver
            // 
            this.btnMarcarDevolver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMarcarDevolver.BackColor = System.Drawing.Color.Transparent;
            this.btnMarcarDevolver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMarcarDevolver.Enabled = false;
            this.btnMarcarDevolver.FlatAppearance.BorderSize = 0;
            this.btnMarcarDevolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMarcarDevolver.Image = global::ControlePedido.Properties.Resources.marcar1;
            this.btnMarcarDevolver.Location = new System.Drawing.Point(1285, 497);
            this.btnMarcarDevolver.Name = "btnMarcarDevolver";
            this.btnMarcarDevolver.Size = new System.Drawing.Size(37, 25);
            this.btnMarcarDevolver.TabIndex = 21;
            this.btnMarcarDevolver.UseVisualStyleBackColor = false;
            this.btnMarcarDevolver.Click += new System.EventHandler(this.btnMarcarDevolver_Click);
            // 
            // btnSubir
            // 
            this.btnSubir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubir.BackColor = System.Drawing.Color.Transparent;
            this.btnSubir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubir.Enabled = false;
            this.btnSubir.FlatAppearance.BorderSize = 0;
            this.btnSubir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubir.Image = global::ControlePedido.Properties.Resources.subir;
            this.btnSubir.Location = new System.Drawing.Point(1371, 497);
            this.btnSubir.Name = "btnSubir";
            this.btnSubir.Size = new System.Drawing.Size(37, 25);
            this.btnSubir.TabIndex = 20;
            this.btnSubir.UseVisualStyleBackColor = false;
            this.btnSubir.Click += new System.EventHandler(this.btnSubir_Click);
            // 
            // btnDesmarcarDevolver
            // 
            this.btnDesmarcarDevolver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDesmarcarDevolver.BackColor = System.Drawing.Color.Transparent;
            this.btnDesmarcarDevolver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDesmarcarDevolver.Enabled = false;
            this.btnDesmarcarDevolver.FlatAppearance.BorderSize = 0;
            this.btnDesmarcarDevolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDesmarcarDevolver.Image = global::ControlePedido.Properties.Resources.desmarcar;
            this.btnDesmarcarDevolver.Location = new System.Drawing.Point(1328, 497);
            this.btnDesmarcarDevolver.Name = "btnDesmarcarDevolver";
            this.btnDesmarcarDevolver.Size = new System.Drawing.Size(37, 25);
            this.btnDesmarcarDevolver.TabIndex = 19;
            this.btnDesmarcarDevolver.UseVisualStyleBackColor = false;
            this.btnDesmarcarDevolver.Click += new System.EventHandler(this.btnDesmarcarDevolver_Click);
            // 
            // frmPedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1448, 726);
            this.Controls.Add(this.btnMarcarDevolver);
            this.Controls.Add(this.btnSubir);
            this.Controls.Add(this.btnDesmarcarDevolver);
            this.Controls.Add(this.btnMarcar);
            this.Controls.Add(this.bntEntregar);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnDesmarcar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gradeEntregue);
            this.Controls.Add(this.grade);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmPedidos";
            this.Text = "frmPedidos";
            this.Load += new System.EventHandler(this.frmPedidos_Load);
            this.Controls.SetChildIndex(this.grade, 0);
            this.Controls.SetChildIndex(this.gradeEntregue, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.btnDesmarcar, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.bntEntregar, 0);
            this.Controls.SetChildIndex(this.btnMarcar, 0);
            this.Controls.SetChildIndex(this.btnDesmarcarDevolver, 0);
            this.Controls.SetChildIndex(this.btnSubir, 0);
            this.Controls.SetChildIndex(this.btnMarcarDevolver, 0);
            this.Controls.SetChildIndex(this.usBarraTitulo1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.usMenu1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradeEntregue)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grade;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPedido;
        private System.Windows.Forms.DataGridView gradeEntregue;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPedido;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnMarcar;
        private System.Windows.Forms.Button bntEntregar;
        private System.Windows.Forms.Button btnDesmarcar;
        private System.Windows.Forms.Button btnMarcarDevolver;
        private System.Windows.Forms.Button btnSubir;
        private System.Windows.Forms.Button btnDesmarcarDevolver;
        private System.Windows.Forms.Label lblAviso;
    }
}