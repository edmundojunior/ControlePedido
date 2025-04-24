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
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblAviso = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnDesmarcar = new System.Windows.Forms.Button();
            this.bntEntregar = new System.Windows.Forms.Button();
            this.btnMarcar = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnDesmarcarDevolver = new System.Windows.Forms.Button();
            this.btnSubir = new System.Windows.Forms.Button();
            this.btnMarcarDevolver = new System.Windows.Forms.Button();
            this.btnReabrir = new System.Windows.Forms.Button();
            this.btnEncerrarPedido = new System.Windows.Forms.Button();
            this.lblDadosPedido = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradeEntregue)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
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
            this.panel1.Location = new System.Drawing.Point(0, 666);
            this.panel1.Size = new System.Drawing.Size(1448, 60);
            // 
            // usMenu1
            // 
            this.usMenu1.Size = new System.Drawing.Size(1448, 34);
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
            this.grade.Location = new System.Drawing.Point(10, 159);
            this.grade.Name = "grade";
            this.grade.RowHeadersVisible = false;
            this.grade.RowHeadersWidth = 51;
            this.grade.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grade.Size = new System.Drawing.Size(1423, 227);
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
            this.gradeEntregue.Location = new System.Drawing.Point(12, 46);
            this.gradeEntregue.Name = "gradeEntregue";
            this.gradeEntregue.RowHeadersVisible = false;
            this.gradeEntregue.RowHeadersWidth = 51;
            this.gradeEntregue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gradeEntregue.Size = new System.Drawing.Size(1419, 94);
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
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Pedido:";
            // 
            // txtPedido
            // 
            this.txtPedido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPedido.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPedido.Location = new System.Drawing.Point(59, 8);
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
            this.button1.Location = new System.Drawing.Point(160, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(29, 21);
            this.button1.TabIndex = 8;
            this.button1.TabStop = false;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.lblCliente.Location = new System.Drawing.Point(192, 13);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(19, 13);
            this.lblCliente.TabIndex = 9;
            this.lblCliente.Text = "....";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Relação de Produtos";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Produtos a Entregar:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Produtos Entregues:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblDadosPedido);
            this.panel2.Controls.Add(this.txtPedido);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.lblCliente);
            this.panel2.Location = new System.Drawing.Point(6, 6);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1435, 89);
            this.panel2.TabIndex = 13;
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(1019, 107);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(285, 47);
            this.lblStatus.TabIndex = 13;
            this.lblStatus.Text = "Status do Pedido";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblStatus.Visible = false;
            this.lblStatus.Click += new System.EventHandler(this.lblStatus_Click);
            // 
            // lblAviso
            // 
            this.lblAviso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAviso.AutoSize = true;
            this.lblAviso.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblAviso.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAviso.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblAviso.Location = new System.Drawing.Point(1163, 20);
            this.lblAviso.Name = "lblAviso";
            this.lblAviso.Size = new System.Drawing.Size(242, 30);
            this.lblAviso.TabIndex = 13;
            this.lblAviso.Text = "Aguarde Processando....";
            this.lblAviso.Visible = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.lblStatus);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.grade);
            this.panel3.Controls.Add(this.btnDesmarcar);
            this.panel3.Controls.Add(this.bntEntregar);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.btnMarcar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 106);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1448, 398);
            this.panel3.TabIndex = 22;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
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
            this.btnDesmarcar.Location = new System.Drawing.Point(1353, 125);
            this.btnDesmarcar.Name = "btnDesmarcar";
            this.btnDesmarcar.Size = new System.Drawing.Size(37, 25);
            this.btnDesmarcar.TabIndex = 16;
            this.btnDesmarcar.UseVisualStyleBackColor = false;
            this.btnDesmarcar.Click += new System.EventHandler(this.btnDesmarcar_Click);
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
            this.bntEntregar.Location = new System.Drawing.Point(1396, 125);
            this.bntEntregar.Name = "bntEntregar";
            this.bntEntregar.Size = new System.Drawing.Size(37, 25);
            this.bntEntregar.TabIndex = 17;
            this.bntEntregar.UseVisualStyleBackColor = false;
            this.bntEntregar.Click += new System.EventHandler(this.bntEntregar_Click);
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
            this.btnMarcar.Location = new System.Drawing.Point(1310, 125);
            this.btnMarcar.Name = "btnMarcar";
            this.btnMarcar.Size = new System.Drawing.Size(37, 25);
            this.btnMarcar.TabIndex = 18;
            this.btnMarcar.UseVisualStyleBackColor = false;
            this.btnMarcar.Click += new System.EventHandler(this.btnMarcar_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.btnDesmarcarDevolver);
            this.panel4.Controls.Add(this.btnSubir);
            this.panel4.Controls.Add(this.btnMarcarDevolver);
            this.panel4.Controls.Add(this.gradeEntregue);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 504);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1448, 162);
            this.panel4.TabIndex = 23;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
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
            this.btnDesmarcarDevolver.Location = new System.Drawing.Point(1353, 11);
            this.btnDesmarcarDevolver.Name = "btnDesmarcarDevolver";
            this.btnDesmarcarDevolver.Size = new System.Drawing.Size(37, 25);
            this.btnDesmarcarDevolver.TabIndex = 19;
            this.btnDesmarcarDevolver.UseVisualStyleBackColor = false;
            this.btnDesmarcarDevolver.Click += new System.EventHandler(this.btnDesmarcarDevolver_Click);
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
            this.btnSubir.Location = new System.Drawing.Point(1396, 11);
            this.btnSubir.Name = "btnSubir";
            this.btnSubir.Size = new System.Drawing.Size(37, 25);
            this.btnSubir.TabIndex = 20;
            this.btnSubir.UseVisualStyleBackColor = false;
            this.btnSubir.Click += new System.EventHandler(this.btnSubir_Click);
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
            this.btnMarcarDevolver.Location = new System.Drawing.Point(1310, 11);
            this.btnMarcarDevolver.Name = "btnMarcarDevolver";
            this.btnMarcarDevolver.Size = new System.Drawing.Size(37, 25);
            this.btnMarcarDevolver.TabIndex = 21;
            this.btnMarcarDevolver.UseVisualStyleBackColor = false;
            this.btnMarcarDevolver.Click += new System.EventHandler(this.btnMarcarDevolver_Click);
            // 
            // btnReabrir
            // 
            this.btnReabrir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReabrir.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnReabrir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReabrir.Enabled = false;
            this.btnReabrir.FlatAppearance.BorderSize = 0;
            this.btnReabrir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReabrir.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReabrir.ForeColor = System.Drawing.Color.Black;
            this.btnReabrir.Image = global::ControlePedido.Properties.Resources.chave;
            this.btnReabrir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReabrir.Location = new System.Drawing.Point(1108, 75);
            this.btnReabrir.Name = "btnReabrir";
            this.btnReabrir.Size = new System.Drawing.Size(158, 29);
            this.btnReabrir.TabIndex = 25;
            this.btnReabrir.Text = "Refaturar Pedido ";
            this.btnReabrir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReabrir.UseVisualStyleBackColor = false;
            this.btnReabrir.Visible = false;
            this.btnReabrir.Click += new System.EventHandler(this.btnReabrir_Click);
            // 
            // btnEncerrarPedido
            // 
            this.btnEncerrarPedido.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEncerrarPedido.BackColor = System.Drawing.Color.Firebrick;
            this.btnEncerrarPedido.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEncerrarPedido.Enabled = false;
            this.btnEncerrarPedido.FlatAppearance.BorderSize = 0;
            this.btnEncerrarPedido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEncerrarPedido.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEncerrarPedido.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnEncerrarPedido.Image = global::ControlePedido.Properties.Resources.cadeado;
            this.btnEncerrarPedido.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEncerrarPedido.Location = new System.Drawing.Point(1284, 75);
            this.btnEncerrarPedido.Name = "btnEncerrarPedido";
            this.btnEncerrarPedido.Size = new System.Drawing.Size(158, 29);
            this.btnEncerrarPedido.TabIndex = 24;
            this.btnEncerrarPedido.Text = "Encerrar Pedido ";
            this.btnEncerrarPedido.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEncerrarPedido.UseVisualStyleBackColor = false;
            this.btnEncerrarPedido.Visible = false;
            this.btnEncerrarPedido.Click += new System.EventHandler(this.btnEncerrarPedido_Click);
            // 
            // lblDadosPedido
            // 
            this.lblDadosPedido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.lblDadosPedido.Location = new System.Drawing.Point(60, 38);
            this.lblDadosPedido.Name = "lblDadosPedido";
            this.lblDadosPedido.Size = new System.Drawing.Size(923, 41);
            this.lblDadosPedido.TabIndex = 14;
            this.lblDadosPedido.Text = "....";
            // 
            // frmPedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1448, 726);
            this.Controls.Add(this.btnReabrir);
            this.Controls.Add(this.btnEncerrarPedido);
            this.Controls.Add(this.lblAviso);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmPedidos";
            this.Text = "Controle de Pedidos - Usuário: ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPedidos_FormClosing_1);
            this.Load += new System.EventHandler(this.frmPedidos_Load);
            this.Controls.SetChildIndex(this.usBarraTitulo1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.usMenu1, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.Controls.SetChildIndex(this.panel4, 0);
            this.Controls.SetChildIndex(this.lblAviso, 0);
            this.Controls.SetChildIndex(this.btnEncerrarPedido, 0);
            this.Controls.SetChildIndex(this.btnReabrir, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradeEntregue)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
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
        private System.Windows.Forms.Button btnMarcar;
        private System.Windows.Forms.Button bntEntregar;
        private System.Windows.Forms.Button btnDesmarcar;
        private System.Windows.Forms.Button btnMarcarDevolver;
        private System.Windows.Forms.Button btnSubir;
        private System.Windows.Forms.Button btnDesmarcarDevolver;
        private System.Windows.Forms.Label lblAviso;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnEncerrarPedido;
        private System.Windows.Forms.Button btnReabrir;
        private System.Windows.Forms.Label lblDadosPedido;
    }
}