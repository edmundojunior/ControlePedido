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
    public partial class frmFiltro : frmBase
    {
        public DateTime dtInicio;
        public DateTime dtFim;
        public string campo;
        public string metodo;
        public string conteudo;
        public bool atribuirFiltro = false ;
        public int filtrar_dados =  0 ;

        Util.dataEHora datahora = new Util.dataEHora();

        public frmFiltro(int FiltrarDados = 0)
        {
            InitializeComponent();

            usMenu1.CloseButtonClicked += UsMenu1_CloseButtonClicked;
            usMenu1.ExecutarButtonClicked += usMenu1_ExecutarButtonClicked;
            usMenu1.CancelarButtonClicked += usMenu1_CancelarButtonClicked;
            filtrar_dados = FiltrarDados;
            reset(); 

        }

        private void usMenu1_ExecutarButtonClicked(object sender, EventArgs e)
        {
            EncerrarFiltro();
            Close();
        }        

        private void usMenu1_CancelarButtonClicked(object sender, EventArgs e)
        {
            reset();
        }

       
        private void UsMenu1_CloseButtonClicked(object sender, EventArgs e)
        {
            atribuirFiltro = false;
            Close();
        }

        private void frmFiltro_Load(object sender, EventArgs e)
        {

        }

        private void EncerrarFiltro()
        {
            dtInicio = dtInicial.Value;
            dtFim = dtFinal.Value;
            campo = cmbCampo.Text;
            metodo = cmbMetodo.Text;
            conteudo = txtConteudo.Text;
            atribuirFiltro = true;
        }
        private void reset()
        {
            var primeiroUltimoDia = datahora.ObterPrimeiroEUltimoDiaDoMes();

            dtInicial.Value = primeiroUltimoDia.PrimeiroDia;
            dtFinal.Value = primeiroUltimoDia.UltimoDia;

            dtInicio = dtInicial.Value;
            dtFim = dtFinal.Value;
            campo = "";
            metodo = "";
            conteudo = "";

            preencherComboCampo();
            preencherComboMetodo();

            usMenu1.SetButtonEnabled("Localizar", false);
            usMenu1.SetButtonEnabled("Confirmar", false);
            usMenu1.SetButtonEnabled("Imprimir", false);
            usMenu1.SetButtonEnabled("Atualizar", false);
            usMenu1.SetButtonEnabled("Filtro", false);
            usMenu1.SetButtonEnabled("Salvar", false);
            usMenu1.SetButtonEnabled("Novo", false);
            usMenu1.SetButtonEnabled("Editar", false);
            usMenu1.SetButtonEnabled("Excluir", false);
            usMenu1.SetButtonEnabled("Executar", true);
            usMenu1.SetButtonEnabled("Primeiro", false);
            usMenu1.SetButtonEnabled("Anterior", false);
            usMenu1.SetButtonEnabled("Proximo", false);
            usMenu1.SetButtonEnabled("Ultimo", false);

            if (filtrar_dados == 2)
            {
                groupData.Enabled = false;
            }

        }

        private void preencherComboCampo()
        {
            cmbCampo.Items.Clear();

            cmbCampo.Items.Add("CÓDIGO");

            if (filtrar_dados == 0 )
            {
                cmbCampo.Items.Add("VENDEDOR");
                cmbCampo.Items.Add("CLIENTE");
                cmbCampo.Items.Add("STATUS");
                cmbCampo.Items.Add("CIDADE");
                cmbCampo.Items.Add("DATA EMISSÃO");
                cmbCampo.Items.Add("CNPJ CLIENTE");
                cmbCampo.Items.Add("OBSERVAÇÕES");
                cmbCampo.Items.Add("OBSERVAÇOES INTERNAS");
                cmbCampo.Items.Add("NR. ORDEM DE COMPRA");
                cmbCampo.Items.Add("CLASSIFICAÇÃO PEDIDO");
                cmbCampo.Items.Add("CLASSIFICAÇÃO CLIENTE");
                cmbCampo.Items.Add("PESO BRUTO");
                cmbCampo.Items.Add("PESO LIQUIDO");
                cmbCampo.Items.Add("CÓDIGO CLIENTE");

            } else if (filtrar_dados == 1)
            {
                cmbCampo.Items.Add("IDENTIFICAÇÃO");
                cmbCampo.Items.Add("DESCRIÇÃO DO PRODUTO");
                cmbCampo.Items.Add("MARCA");
                cmbCampo.Items.Add("CEST");
            }
            else if (filtrar_dados == 2)
            {
                cmbCampo.Items.Add("CÓDIGO");
                cmbCampo.Items.Add("DESCRIÇÃO");
                cmbCampo.Items.Add("ESTADO");
                cmbCampo.Items.Add("CEP");

            }



            if (cmbCampo.Items.Count > 0) cmbCampo.SelectedIndex = 0;
        }

        private void preencherComboMetodo()
        {

            cmbMetodo.Items.Clear();
            cmbMetodo.Items.Add("INICIADO EM");
            cmbMetodo.Items.Add("CONTENDO");

            if (cmbMetodo.Items.Count > 0) cmbMetodo.SelectedIndex = 0;
        }

        private void usBarraTitulo1_Load(object sender, EventArgs e)
        {

        }

        private void usMenu1_Load(object sender, EventArgs e)
        {

        }
    }
}
