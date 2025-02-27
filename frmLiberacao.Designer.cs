namespace ControlePedido
{
    partial class frmLiberacao
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
            this.bntSair = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.usBarraTitulo1 = new ControlePedido.usBarraTitulo();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblAviso = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bntSair
            // 
            this.bntSair.BackColor = System.Drawing.Color.IndianRed;
            this.bntSair.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bntSair.Location = new System.Drawing.Point(261, 201);
            this.bntSair.Name = "bntSair";
            this.bntSair.Size = new System.Drawing.Size(101, 42);
            this.bntSair.TabIndex = 0;
            this.bntSair.Text = "Sair";
            this.bntSair.UseVisualStyleBackColor = false;
            this.bntSair.Click += new System.EventHandler(this.bntSair_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Usuário:";
            // 
            // txtLogin
            // 
            this.txtLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLogin.Location = new System.Drawing.Point(24, 102);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(338, 22);
            this.txtLogin.TabIndex = 0;
            this.txtLogin.TextChanged += new System.EventHandler(this.txtLogin_TextChanged);
            this.txtLogin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLogin_KeyDown);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DarkGreen;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(154, 201);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(101, 42);
            this.button2.TabIndex = 3;
            this.button2.Text = "Confirmar";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtSenha
            // 
            this.txtSenha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSenha.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenha.Location = new System.Drawing.Point(24, 151);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.Size = new System.Drawing.Size(201, 25);
            this.txtSenha.TabIndex = 1;
            this.txtSenha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSenha.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSenha_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Senha:";
            // 
            // usBarraTitulo1
            // 
            this.usBarraTitulo1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.usBarraTitulo1.Dock = System.Windows.Forms.DockStyle.Top;
            this.usBarraTitulo1.Location = new System.Drawing.Point(0, 0);
            this.usBarraTitulo1.Name = "usBarraTitulo1";
            this.usBarraTitulo1.Size = new System.Drawing.Size(387, 72);
            this.usBarraTitulo1.TabIndex = 6;
            this.usBarraTitulo1.valor = "Liberar Movimentação";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 263);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(387, 10);
            this.panel1.TabIndex = 7;
            // 
            // lblAviso
            // 
            this.lblAviso.AutoSize = true;
            this.lblAviso.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAviso.ForeColor = System.Drawing.Color.Red;
            this.lblAviso.Location = new System.Drawing.Point(231, 156);
            this.lblAviso.Name = "lblAviso";
            this.lblAviso.Size = new System.Drawing.Size(139, 15);
            this.lblAviso.TabIndex = 8;
            this.lblAviso.Text = "Login ou Senha inválida !";
            this.lblAviso.Visible = false;
            // 
            // frmLiberacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(387, 273);
            this.Controls.Add(this.lblAviso);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.usBarraTitulo1);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bntSair);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLiberacao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLiberacao";
            this.Load += new System.EventHandler(this.frmLiberacao_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bntSair;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Label label2;
        private usBarraTitulo usBarraTitulo1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblAviso;
    }
}