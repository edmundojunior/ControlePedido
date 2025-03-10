using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlePedido
{
    public partial class frmPrincipal : Form
    {
        Util func = new Util();
        public frmPrincipal()
        {
            InitializeComponent();
            this.Text = "Controle de Pedidos Ver.: " + func.retornaVersao();
            lblVersao.Text = "Versão: " + func.retornaVersao();
            this.Resize += frmPrincipal_Resize;
            AtualizarData(); // Define a data no formato correto
            IniciarRelogio(); // Inicia o relógio atualizado
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void pedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPedidos frm = new frmPedidos();
            frm.ShowDialog();
        }

        private void bancoDeDadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConfBancoDeDados frm = new frmConfBancoDeDados();
            frm.ShowDialog();
        }

        private void encerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmEstoque frm = new frmEstoque();
            frm.ShowDialog();
        }

        private void peiddosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRelatorio frm = new frmRelatorio();
            frm.ShowDialog();

        }

        private void relatóriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void reset()
        {

        }

        private void estoqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRelatorio frm = new frmRelatorio(true);
            frm.ShowDialog();

        }

        private void configuraçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void frmPrincipal_Resize(object sender, EventArgs e)
        {
            CentralizarImagem();
        }

        private void CentralizarImagem()
        {
            // Garante que o PictureBox esteja centralizado no Form
            pctLogo.Left = (this.ClientSize.Width - pctLogo.Width) / 2;
            pctLogo.Top = (this.ClientSize.Height - pctLogo.Height) / 2;
        }

        private void AtualizarData()
        {
            // Obtém a data atual e formata no estilo desejado
            lblData.Text = DateTime.Now.ToString("dddd, dd 'de' MMM 'de' yyyy ", new CultureInfo("pt-BR"));
        }

        private void IniciarRelogio()
        {
            // Configura um Timer para atualizar a hora a cada segundo
            timer1 = new Timer();
            timer1.Interval = 1000; // Atualiza a cada 1 segundo
            timer1.Tick += (s, e) => lblHora.Text = DateTime.Now.ToString("HH:mm:ss");
            timer1.Start();
        }
    }
}
