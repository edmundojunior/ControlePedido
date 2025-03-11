namespace ControlePedido
{
    partial class frmExibirRelatorio
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExibirRelatorio));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPdf = new System.Windows.Forms.Button();
            this.btnCsv = new System.Windows.Forms.Button();
            this.btnXlxs = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.usBarraTitulo1 = new ControlePedido.usBarraTitulo();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.btnPdf);
            this.panel1.Controls.Add(this.btnCsv);
            this.panel1.Controls.Add(this.btnXlxs);
            this.panel1.Controls.Add(this.btnImprimir);
            this.panel1.Controls.Add(this.btnFechar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1336, 36);
            this.panel1.TabIndex = 1;
            // 
            // btnPdf
            // 
            this.btnPdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPdf.FlatAppearance.BorderSize = 0;
            this.btnPdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPdf.Image = global::ControlePedido.Properties.Resources.pdf;
            this.btnPdf.Location = new System.Drawing.Point(11, 6);
            this.btnPdf.Name = "btnPdf";
            this.btnPdf.Size = new System.Drawing.Size(25, 23);
            this.btnPdf.TabIndex = 35;
            this.toolTip1.SetToolTip(this.btnPdf, "Gerar Arquivo .PDF");
            this.btnPdf.UseVisualStyleBackColor = true;
            this.btnPdf.Click += new System.EventHandler(this.btnPdf_Click);
            // 
            // btnCsv
            // 
            this.btnCsv.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCsv.FlatAppearance.BorderSize = 0;
            this.btnCsv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCsv.Image = global::ControlePedido.Properties.Resources.csv24;
            this.btnCsv.Location = new System.Drawing.Point(53, 6);
            this.btnCsv.Name = "btnCsv";
            this.btnCsv.Size = new System.Drawing.Size(25, 23);
            this.btnCsv.TabIndex = 34;
            this.toolTip1.SetToolTip(this.btnCsv, "Gerar Arquivo .csv");
            this.btnCsv.UseVisualStyleBackColor = true;
            this.btnCsv.Click += new System.EventHandler(this.btnCsv_Click);
            // 
            // btnXlxs
            // 
            this.btnXlxs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXlxs.FlatAppearance.BorderSize = 0;
            this.btnXlxs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXlxs.Image = global::ControlePedido.Properties.Resources.xlsx;
            this.btnXlxs.Location = new System.Drawing.Point(91, 6);
            this.btnXlxs.Name = "btnXlxs";
            this.btnXlxs.Size = new System.Drawing.Size(25, 23);
            this.btnXlxs.TabIndex = 33;
            this.toolTip1.SetToolTip(this.btnXlxs, "Gerar Arquivo .xlxs (Excel)");
            this.btnXlxs.UseVisualStyleBackColor = true;
            this.btnXlxs.Click += new System.EventHandler(this.btnXlxs_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimir.FlatAppearance.BorderSize = 0;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.Image = global::ControlePedido.Properties.Resources.print;
            this.btnImprimir.Location = new System.Drawing.Point(146, 6);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(25, 23);
            this.btnImprimir.TabIndex = 31;
            this.btnImprimir.UseVisualStyleBackColor = true;
            // 
            // btnFechar
            // 
            this.btnFechar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFechar.FlatAppearance.BorderSize = 0;
            this.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFechar.Image = global::ControlePedido.Properties.Resources.sair_porta;
            this.btnFechar.Location = new System.Drawing.Point(188, 6);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(25, 23);
            this.btnFechar.TabIndex = 30;
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 108);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(1336, 689);
            this.webBrowser1.TabIndex = 2;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // usBarraTitulo1
            // 
            this.usBarraTitulo1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.usBarraTitulo1.Dock = System.Windows.Forms.DockStyle.Top;
            this.usBarraTitulo1.Location = new System.Drawing.Point(0, 0);
            this.usBarraTitulo1.Name = "usBarraTitulo1";
            this.usBarraTitulo1.Size = new System.Drawing.Size(1336, 72);
            this.usBarraTitulo1.TabIndex = 0;
            this.usBarraTitulo1.valor = "Exibir Relatório";
            this.usBarraTitulo1.Load += new System.EventHandler(this.usBarraTitulo1_Load);
            // 
            // frmExibirRelatorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1336, 797);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.usBarraTitulo1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmExibirRelatorio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exibir Relatório";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private usBarraTitulo usBarraTitulo1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPdf;
        private System.Windows.Forms.Button btnCsv;
        private System.Windows.Forms.Button btnXlxs;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.WebBrowser webBrowser1;
    }
}