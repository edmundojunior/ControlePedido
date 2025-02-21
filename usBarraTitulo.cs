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
    public partial class usBarraTitulo : UserControl
    {
        private string _valor;

        public string valor
        {
            get { return _valor; }
            set
            {
                _valor = value;
                lblFuncao.Text = _valor; // Atualiza o texto da Label no UserControl
            }
        }

        public usBarraTitulo()
        {
            InitializeComponent();
        }

        private void usBarraTitulo_Load(object sender, EventArgs e)
        {
            lblFuncao.Text = valor;
        }
    }
}
