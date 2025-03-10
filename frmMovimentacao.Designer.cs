namespace ControlePedido
{
    partial class frmMovimentacao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMovimentacao));
            this.pnlProduto = new System.Windows.Forms.Panel();
            this.lblquantidadeOriginal = new System.Windows.Forms.Label();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.lblPedido = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.txtIdentificacao = new System.Windows.Forms.TextBox();
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grade = new System.Windows.Forms.DataGridView();
            this.usMenu1 = new ControlePedido.usMenu();
            this.usBarraTitulo1 = new ControlePedido.usBarraTitulo();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlProduto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grade)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlProduto
            // 
            this.pnlProduto.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pnlProduto.Controls.Add(this.lblquantidadeOriginal);
            this.pnlProduto.Controls.Add(this.btnConfirmar);
            this.pnlProduto.Controls.Add(this.lblPedido);
            this.pnlProduto.Controls.Add(this.label5);
            this.pnlProduto.Controls.Add(this.lblDescricao);
            this.pnlProduto.Controls.Add(this.txtIdentificacao);
            this.pnlProduto.Controls.Add(this.txtQuantidade);
            this.pnlProduto.Controls.Add(this.label4);
            this.pnlProduto.Controls.Add(this.label3);
            this.pnlProduto.Controls.Add(this.lblCodigo);
            this.pnlProduto.Controls.Add(this.label1);
            this.pnlProduto.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlProduto.Location = new System.Drawing.Point(0, 106);
            this.pnlProduto.Name = "pnlProduto";
            this.pnlProduto.Size = new System.Drawing.Size(811, 81);
            this.pnlProduto.TabIndex = 2;
            // 
            // lblquantidadeOriginal
            // 
            this.lblquantidadeOriginal.AutoSize = true;
            this.lblquantidadeOriginal.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblquantidadeOriginal.Location = new System.Drawing.Point(750, 56);
            this.lblquantidadeOriginal.Name = "lblquantidadeOriginal";
            this.lblquantidadeOriginal.Size = new System.Drawing.Size(49, 20);
            this.lblquantidadeOriginal.TabIndex = 10;
            this.lblquantidadeOriginal.Text = "00000";
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmar.Location = new System.Drawing.Point(565, 55);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmar.TabIndex = 9;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // lblPedido
            // 
            this.lblPedido.AutoSize = true;
            this.lblPedido.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPedido.Location = new System.Drawing.Point(92, 3);
            this.lblPedido.Name = "lblPedido";
            this.lblPedido.Size = new System.Drawing.Size(49, 20);
            this.lblPedido.TabIndex = 8;
            this.lblPedido.Text = "00000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Pedido:";
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(163, 35);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(16, 13);
            this.lblDescricao.TabIndex = 6;
            this.lblDescricao.Text = "...";
            // 
            // txtIdentificacao
            // 
            this.txtIdentificacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdentificacao.Enabled = false;
            this.txtIdentificacao.Location = new System.Drawing.Point(254, 54);
            this.txtIdentificacao.Name = "txtIdentificacao";
            this.txtIdentificacao.Size = new System.Drawing.Size(297, 22);
            this.txtIdentificacao.TabIndex = 5;
            this.txtIdentificacao.Visible = false;
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQuantidade.Enabled = false;
            this.txtQuantidade.Location = new System.Drawing.Point(89, 54);
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(65, 22);
            this.txtQuantidade.TabIndex = 4;
            this.txtQuantidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(161, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Rastreabilidade";
            this.label4.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Quantidade:";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(114, 35);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(37, 13);
            this.lblCodigo.TabIndex = 1;
            this.lblCodigo.Text = "00000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Produto:";
            // 
            // grade
            // 
            this.grade.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.grade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grade.Location = new System.Drawing.Point(5, 195);
            this.grade.Name = "grade";
            this.grade.RowHeadersVisible = false;
            this.grade.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grade.Size = new System.Drawing.Size(798, 204);
            this.grade.TabIndex = 3;
            this.grade.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grade_CellClick);
            this.grade.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grade_CellContentClick);
            // 
            // usMenu1
            // 
            this.usMenu1.BackColor = System.Drawing.Color.Gainsboro;
            this.usMenu1.Dock = System.Windows.Forms.DockStyle.Top;
            this.usMenu1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usMenu1.Location = new System.Drawing.Point(0, 72);
            this.usMenu1.Name = "usMenu1";
            this.usMenu1.Size = new System.Drawing.Size(811, 34);
            this.usMenu1.TabIndex = 1;
            this.usMenu1.Load += new System.EventHandler(this.usMenu1_Load);
            // 
            // usBarraTitulo1
            // 
            this.usBarraTitulo1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.usBarraTitulo1.Dock = System.Windows.Forms.DockStyle.Top;
            this.usBarraTitulo1.Location = new System.Drawing.Point(0, 0);
            this.usBarraTitulo1.Name = "usBarraTitulo1";
            this.usBarraTitulo1.Size = new System.Drawing.Size(811, 72);
            this.usBarraTitulo1.TabIndex = 0;
            this.usBarraTitulo1.valor = "Entregar / Retornar";
            this.usBarraTitulo1.Load += new System.EventHandler(this.usBarraTitulo1_Load);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 402);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(512, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Caso queira desconsiderar um produto lançado erroneamente altere sua quantidade p" +
    "ara 0 (zero) ";
            this.label2.Visible = false;
            // 
            // frmMovimentacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 424);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.grade);
            this.Controls.Add(this.pnlProduto);
            this.Controls.Add(this.usMenu1);
            this.Controls.Add(this.usBarraTitulo1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMovimentacao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Movimentação Produtos";
            this.Load += new System.EventHandler(this.frmMovimentacao_Load);
            this.pnlProduto.ResumeLayout(false);
            this.pnlProduto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grade)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private usBarraTitulo usBarraTitulo1;
        private usMenu usMenu1;
        private System.Windows.Forms.Panel pnlProduto;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.TextBox txtIdentificacao;
        private System.Windows.Forms.TextBox txtQuantidade;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView grade;
        private System.Windows.Forms.Label lblPedido;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Label lblquantidadeOriginal;
        private System.Windows.Forms.Label label2;
    }
}