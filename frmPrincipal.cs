using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    }
}
