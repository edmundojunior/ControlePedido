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
    public partial class frmConfBancoDeDados : frmBase
    {
        public frmConfBancoDeDados()
        {
            InitializeComponent();
            usMenu1.SalvarButtonClicked += Menu_SalvarButtonClicked;
            usMenu1.CancelarButtonClicked += Menu_CancelarButtonClicked;
            usMenu1.CloseButtonClicked += Menu_CloseButtonClicked;
            reset();
        }


        private void Menu_CloseButtonClicked(object sender, EventArgs e)
        {
            Close();
        }
        private void Menu_CancelarButtonClicked(object sender, EventArgs e)
        {
            limpar();
        }


        private void Menu_SalvarButtonClicked(object sender, EventArgs e)
        {
            salvar();
        }

        private void frmConfBancoDeDados_Load(object sender, EventArgs e)
        {

        }

        private void salvar()
        {
            var bco = new BancoDeDados
            {
                server = txtServidor.Text,
                database = txtBancoDeDados.Text,
                user_id = txtLogin.Text,
                password = txtSenha.Text
            };



            if (bco != null)
                if (bco.salvarConfiguracao(bco)) MessageBox.Show("Configuração do Banco de Dados realizada com sucesso!", "Banco de Dados", MessageBoxButtons.OK,
                                                                             MessageBoxIcon.Information);


        }

        private void limpar()
        {
            txtServidor.Text = "";
            txtBancoDeDados.Text = "";
            txtLogin.Text = "";
            txtSenha.Text = "";
        }
        private void reset()
        {
            limpar();

            //Configuração dos botões
            usMenu1.SetButtonVisible("Localizar", false);
            usMenu1.SetButtonVisible("Confirmar", false);
            usMenu1.SetButtonVisible("Primeiro", false);
            usMenu1.SetButtonVisible("Anterior", false);
            usMenu1.SetButtonVisible("Proximo", false);
            usMenu1.SetButtonVisible("Ultimo", false);
            usMenu1.SetButtonVisible("Imprimir", false);
            usMenu1.SetButtonVisible("Filtro", false);
            usMenu1.SetButtonVisible("Executar", false);
            usMenu1.SetButtonVisible("Atualizar", false);

            var bco = new BancoDeDados().lerXMLConfiguracao();

            if (bco != null)
            {
                txtServidor.Text = bco.server;
                txtBancoDeDados.Text = bco.database;
                txtLogin.Text = bco.user_id;
                txtSenha.Text = bco.password;

                txtServidor.Focus();
                
            }
        }
    }
}
