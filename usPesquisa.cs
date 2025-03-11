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
    public partial class usPesquisa : UserControl
    {
        public usPesquisa()
        {
            InitializeComponent();
        }

        public int oQuePesquisar = 0;

        public string Texto
        {
            get { return txtResultado.Text; }
            set { txtResultado.Text = value; }
        }

        public event Action<string> PesquisaRealizada;

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            using (frmLocalizarAll formPesquisa = new frmLocalizarAll(oQuePesquisar))
            {
                if (formPesquisa.ShowDialog() == DialogResult.OK)
                {
                    Texto = formPesquisa.Codigo.ToString();
                    PesquisaRealizada?.Invoke(Texto); // Dispara o evento com o resultado
                }
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
