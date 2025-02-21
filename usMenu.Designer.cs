namespace ControlePedido
{
    partial class usMenu
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnrefresh = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnFiltro = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnExecutar = new System.Windows.Forms.Button();
            this.btnUltimo = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnProximo = new System.Windows.Forms.Button();
            this.btnLocalizar = new System.Windows.Forms.Button();
            this.btnPrimeiro = new System.Windows.Forms.Button();
            this.btnAnterior = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // toolTip1
            // 
            this.toolTip1.BackColor = System.Drawing.Color.Beige;
            this.toolTip1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "Controle de Pedidos";
            // 
            // btnDelete
            // 
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Image = global::ControlePedido.Properties.Resources.lixo;
            this.btnDelete.Location = new System.Drawing.Point(401, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(25, 23);
            this.btnDelete.TabIndex = 32;
            this.toolTip1.SetToolTip(this.btnDelete, "Excluir Registro");
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnEditar
            // 
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Image = global::ControlePedido.Properties.Resources.edit;
            this.btnEditar.Location = new System.Drawing.Point(370, 4);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(25, 23);
            this.btnEditar.TabIndex = 31;
            this.toolTip1.SetToolTip(this.btnEditar, "Editar Registro");
            this.btnEditar.UseVisualStyleBackColor = true;
            // 
            // btnNovo
            // 
            this.btnNovo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNovo.FlatAppearance.BorderSize = 0;
            this.btnNovo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovo.Image = global::ControlePedido.Properties.Resources.Novo;
            this.btnNovo.Location = new System.Drawing.Point(339, 4);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(25, 23);
            this.btnNovo.TabIndex = 30;
            this.toolTip1.SetToolTip(this.btnNovo, "Novo Registro");
            this.btnNovo.UseVisualStyleBackColor = true;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimir.FlatAppearance.BorderSize = 0;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.Image = global::ControlePedido.Properties.Resources.print;
            this.btnImprimir.Location = new System.Drawing.Point(560, 4);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(25, 23);
            this.btnImprimir.TabIndex = 29;
            this.toolTip1.SetToolTip(this.btnImprimir, "Imprimir Relatórios");
            this.btnImprimir.UseVisualStyleBackColor = true;
            // 
            // btnrefresh
            // 
            this.btnrefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnrefresh.FlatAppearance.BorderSize = 0;
            this.btnrefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnrefresh.Image = global::ControlePedido.Properties.Resources.refresh;
            this.btnrefresh.Location = new System.Drawing.Point(294, 4);
            this.btnrefresh.Name = "btnrefresh";
            this.btnrefresh.Size = new System.Drawing.Size(25, 23);
            this.btnrefresh.TabIndex = 28;
            this.toolTip1.SetToolTip(this.btnrefresh, "Atualizar");
            this.btnrefresh.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Image = global::ControlePedido.Properties.Resources.cancel24;
            this.btnCancelar.Location = new System.Drawing.Point(482, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(25, 23);
            this.btnCancelar.TabIndex = 27;
            this.toolTip1.SetToolTip(this.btnCancelar, "Cancelar a Edição");
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalvar.FlatAppearance.BorderSize = 0;
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Image = global::ControlePedido.Properties.Resources.save22;
            this.btnSalvar.Location = new System.Drawing.Point(451, 4);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(25, 23);
            this.btnSalvar.TabIndex = 26;
            this.toolTip1.SetToolTip(this.btnSalvar, "Salvar Registro");
            this.btnSalvar.UseVisualStyleBackColor = true;
            // 
            // btnFiltro
            // 
            this.btnFiltro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFiltro.FlatAppearance.BorderSize = 0;
            this.btnFiltro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltro.Image = global::ControlePedido.Properties.Resources.filtro48;
            this.btnFiltro.Location = new System.Drawing.Point(212, 4);
            this.btnFiltro.Name = "btnFiltro";
            this.btnFiltro.Size = new System.Drawing.Size(25, 23);
            this.btnFiltro.TabIndex = 25;
            this.toolTip1.SetToolTip(this.btnFiltro, "Outros Filtros");
            this.btnFiltro.UseVisualStyleBackColor = true;
            // 
            // btnFechar
            // 
            this.btnFechar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFechar.FlatAppearance.BorderSize = 0;
            this.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFechar.Image = global::ControlePedido.Properties.Resources.sair_porta;
            this.btnFechar.Location = new System.Drawing.Point(602, 4);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(25, 23);
            this.btnFechar.TabIndex = 24;
            this.toolTip1.SetToolTip(this.btnFechar, "Encerrar ");
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnExecutar
            // 
            this.btnExecutar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExecutar.FlatAppearance.BorderSize = 0;
            this.btnExecutar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExecutar.Image = global::ControlePedido.Properties.Resources.play;
            this.btnExecutar.Location = new System.Drawing.Point(260, 4);
            this.btnExecutar.Name = "btnExecutar";
            this.btnExecutar.Size = new System.Drawing.Size(25, 23);
            this.btnExecutar.TabIndex = 20;
            this.toolTip1.SetToolTip(this.btnExecutar, "Executar");
            this.btnExecutar.UseVisualStyleBackColor = true;
            // 
            // btnUltimo
            // 
            this.btnUltimo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUltimo.FlatAppearance.BorderSize = 0;
            this.btnUltimo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUltimo.Image = global::ControlePedido.Properties.Resources.setadireita;
            this.btnUltimo.Location = new System.Drawing.Point(168, 4);
            this.btnUltimo.Name = "btnUltimo";
            this.btnUltimo.Size = new System.Drawing.Size(25, 23);
            this.btnUltimo.TabIndex = 15;
            this.toolTip1.SetToolTip(this.btnUltimo, "Último");
            this.btnUltimo.UseVisualStyleBackColor = true;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmar.FlatAppearance.BorderSize = 0;
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Image = global::ControlePedido.Properties.Resources.tick20_2;
            this.btnConfirmar.Location = new System.Drawing.Point(45, 4);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(28, 23);
            this.btnConfirmar.TabIndex = 16;
            this.toolTip1.SetToolTip(this.btnConfirmar, "Confirmar Seleção");
            this.btnConfirmar.UseVisualStyleBackColor = true;
            // 
            // btnProximo
            // 
            this.btnProximo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProximo.FlatAppearance.BorderSize = 0;
            this.btnProximo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProximo.Image = global::ControlePedido.Properties.Resources.setadireita1;
            this.btnProximo.Location = new System.Drawing.Point(138, 4);
            this.btnProximo.Name = "btnProximo";
            this.btnProximo.Size = new System.Drawing.Size(25, 23);
            this.btnProximo.TabIndex = 14;
            this.toolTip1.SetToolTip(this.btnProximo, "Próximo");
            this.btnProximo.UseVisualStyleBackColor = true;
            this.btnProximo.Click += new System.EventHandler(this.btnProximo_Click);
            // 
            // btnLocalizar
            // 
            this.btnLocalizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLocalizar.FlatAppearance.BorderSize = 0;
            this.btnLocalizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLocalizar.Image = global::ControlePedido.Properties.Resources.lupa;
            this.btnLocalizar.Location = new System.Drawing.Point(7, 4);
            this.btnLocalizar.Name = "btnLocalizar";
            this.btnLocalizar.Size = new System.Drawing.Size(28, 23);
            this.btnLocalizar.TabIndex = 17;
            this.toolTip1.SetToolTip(this.btnLocalizar, "Localizar");
            this.btnLocalizar.UseVisualStyleBackColor = true;
            // 
            // btnPrimeiro
            // 
            this.btnPrimeiro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrimeiro.FlatAppearance.BorderSize = 0;
            this.btnPrimeiro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrimeiro.Image = global::ControlePedido.Properties.Resources.setaesquerda;
            this.btnPrimeiro.Location = new System.Drawing.Point(78, 4);
            this.btnPrimeiro.Name = "btnPrimeiro";
            this.btnPrimeiro.Size = new System.Drawing.Size(25, 23);
            this.btnPrimeiro.TabIndex = 13;
            this.toolTip1.SetToolTip(this.btnPrimeiro, "Primeiro");
            this.btnPrimeiro.UseVisualStyleBackColor = true;
            // 
            // btnAnterior
            // 
            this.btnAnterior.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAnterior.FlatAppearance.BorderSize = 0;
            this.btnAnterior.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnterior.Image = global::ControlePedido.Properties.Resources.setaesquerdaa1;
            this.btnAnterior.Location = new System.Drawing.Point(108, 4);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(25, 23);
            this.btnAnterior.TabIndex = 11;
            this.toolTip1.SetToolTip(this.btnAnterior, "Anterior");
            this.btnAnterior.UseVisualStyleBackColor = true;
            // 
            // usMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnrefresh);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnFiltro);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnExecutar);
            this.Controls.Add(this.btnUltimo);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnProximo);
            this.Controls.Add(this.btnLocalizar);
            this.Controls.Add(this.btnPrimeiro);
            this.Controls.Add(this.btnAnterior);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "usMenu";
            this.Size = new System.Drawing.Size(1131, 34);
            this.Load += new System.EventHandler(this.usMenu_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnUltimo;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnProximo;
        private System.Windows.Forms.Button btnLocalizar;
        private System.Windows.Forms.Button btnPrimeiro;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnExecutar;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnFiltro;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnrefresh;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnDelete;
    }
}
