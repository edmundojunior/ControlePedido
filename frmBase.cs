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
    public partial class frmBase : Form
    {
        public frmBase()
        {
            InitializeComponent();

            //this.KeyPreview = true;
            //this.KeyDown += new KeyEventHandler(Form_KeyDown);
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            // Verifica se a tecla pressionada é Enter
            if (e.KeyCode == Keys.Enter)
            {
                // Move o foco para o próximo controle
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
                e.Handled = true; // Indica que o evento foi tratado
                e.SuppressKeyPress = true; // Evita o som do Enter no sistema
            }
        }

        private void frmBase_Load(object sender, EventArgs e)
        {

        }
    }
}
