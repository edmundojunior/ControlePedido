using DocumentFormat.OpenXml.Spreadsheet;
using FastReport.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ControlePedido.Util;

namespace ControlePedido
{
    public partial class frmRelatorio : frmBase
    {

        Util.dataEHora datahora = new Util.dataEHora();
        Util.FormatacaoGrade fomatar = new Util.FormatacaoGrade();
        filtro.filtrarPedidos filtrarPed = new filtro.filtrarPedidos();
        Estoque estoque = new Estoque();

        private DateTime dtInicial = DateTime.Now;
        private DateTime dtFinal = DateTime.Now;
        private bool _estoque = false;
        public frmRelatorio(bool estoque = false)
        {
            InitializeComponent();
            _estoque = estoque;

            usMenu1.CloseButtonClicked += UsMenu1_CloseButtonClicked;
            usMenu1.CancelarButtonClicked += usMenu1_CancelarButtonClicked;
            usMenu1.ImprimirButtonClicked += usMenu1_ImprimirButtonClicked;
            reset();
        }

        private void usMenu1_CancelarButtonClicked(object sender, EventArgs e)
        {
            reset();
        }

        private void UsMenu1_CloseButtonClicked(object sender, EventArgs e)
        {
            Close();
        }

        private void usMenu1_ImprimirButtonClicked(object sender, EventArgs e)
        {
            if (_estoque)
            {
                imprimirEstoque();
            }
            else
            {
                imprimirPedido();
            }
            
        }
        private void frmRelatorio_Load(object sender, EventArgs e)
        {

        }

        private void usBarraTitulo1_Load(object sender, EventArgs e)
        {

        }

        private void imprimirEstoque()
        {
            var filtros = new Dictionary<string, object>();

            Cursor.Current = Cursors.WaitCursor;
            lblAviso.Visible = true;
            lblAviso.Refresh();
            RelEstoque rel_estoque = new RelEstoque();

            Impressao impressao = new Impressao();
            //var listas = estoque.retornarEstoqueRelatorio(retornaFiltroEstoque(), chkEmSeparacao.Checked, chkSeparado.Checked, lbltotais);

            DateTime dt_inicial = DateTime.Now;
            DateTime dt_final = DateTime.Now;

            if (chkDatas.Checked)
            {
                dt_inicial = dataInicial.Value;
                dt_final = dataFinal.Value;

            }

            DataTable dt = new DataTable();


            //filtros
            if (!string.IsNullOrWhiteSpace(txtEmpresa.Text))
                filtros.Add("CD_EMPRESA", txtEmpresa.Text);


            //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

            dt = rel_estoque.retornaEmpresa(filtros);

            filtros.Clear();

            //FILTROS
            if (!string.IsNullOrWhiteSpace(txtProduto.Text))
                filtros.Add("PI.CD_MATERIAL", txtProduto.Text);

            if (!string.IsNullOrWhiteSpace(txtMarca.Text))
                filtros.Add("M.CD_MARCA", txtMarca.Text);

            if (!string.IsNullOrWhiteSpace(txtSubGrupo.Text))
                filtros.Add("M.CD_SUBGRUPO", txtSubGrupo.Text);

            if (!string.IsNullOrWhiteSpace(txtTipoEmbalagem.Text))
                filtros.Add("M.CD_TIPO_EMBALAGEM", txtTipoEmbalagem.Text);

            if (!string.IsNullOrWhiteSpace(txtFornecedor.Text))
                filtros.Add("M.CD_FORNECEDOR", txtFornecedor.Text);

            if (!string.IsNullOrWhiteSpace(txtTipoProduto.Text))
                filtros.Add("M.CD_TIPO", txtTipoProduto.Text);

            if (!string.IsNullOrWhiteSpace(txtTipoPedido.Text))
                filtros.Add("P.CD_TIPO_PEDIDO", txtTipoPedido.Text);

            if (!string.IsNullOrWhiteSpace(txtCliente.Text))
                filtros.Add("P.CD_CLIENTE", txtCliente.Text);

            //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

            string filial = !chkFilial.Checked ? "" : txtFilial.Text;

            rel_estoque.impressaoRelatorioEstoque(dt_inicial, dt_final,   dt, lbltotais , filial, filtros);

            //impressao.impressaoRelEstoque(listas, dt_inicial, dt_final);

            Cursor.Current = Cursors.Default;
            lblAviso.Visible = false;
            lblAviso.Refresh();
        }


        private void imprimirPedido()
        {
            Cursor.Current = Cursors.WaitCursor;
            lblAviso.Visible = true;
            lblAviso.Refresh();  

            Impressao impressao = new Impressao();
            var listas = impressao.RetornarListas(retornaFiltroPedido(),retornaFiltroProduto(), true);

            DateTime dt_inicial = DateTime.Now;
            DateTime dt_final = DateTime.Now;

            if (chkDatas.Checked)
            {
                dt_inicial = dataInicial.Value;
                dt_final = dataFinal.Value;

            }

            impressao.impressaoRelatorio(listas.Item1, listas.Item2, dt_inicial, dt_final);

            Cursor.Current = Cursors.Default;
            lblAviso.Visible = false;
            lblAviso.Refresh();

        }
        
        private void reset()
        {
            usMenu1.SetButtonEnabled("Localizar", false);
            usMenu1.SetButtonEnabled("Confirmar", false);
            usMenu1.SetButtonEnabled("Imprimir", true);
            usMenu1.SetButtonEnabled("Atualizar", false);
            usMenu1.SetButtonEnabled("Filtro", false);
            usMenu1.SetButtonEnabled("Salvar", false);
            usMenu1.SetButtonEnabled("Novo", false);
            usMenu1.SetButtonEnabled("Editar", false);
            usMenu1.SetButtonEnabled("Excluir", false);
            usMenu1.SetButtonEnabled("Executar", false);
            usMenu1.SetButtonEnabled("Primeiro", false);
            usMenu1.SetButtonEnabled("Anterior", false);
            usMenu1.SetButtonEnabled("Proximo", false);
            usMenu1.SetButtonEnabled("Ultimo", false);

            var primeiroUltimoDia = datahora.ObterPrimeiroEUltimoDiaDoMes();

            //dataInicial.Value = primeiroUltimoDia.PrimeiroDia;
            //dataFinal.Value = primeiroUltimoDia.UltimoDia;

            dataInicial.Value = Convert.ToDateTime("01/01/2021");
            dataFinal.Value = Convert.ToDateTime("31/12/2030");

            txtEmpresa.Text = "";
            txtFilial.Text = "";
            txtFormaPagto.Text = "";
            txtFrete.Text = "";
            txtCliente.Text = "";
            txtCampanha.Text = "";
            txtCarteira.Text = "";
            txtCidade.Text = "";
            txtClassEntiade.Text = "";
            txtTipoEmbalagem.Text = "";
            txtTipoEntidade.Text = "";
            txtTipoPedido.Text = "";
            txtTransporte.Text = "";
            txtTipoProduto.Text = "";
            txtProduto.Text = "";
            txtRegiao.Text = "";
            txtServico.Text = "";
            txtSubGrupo.Text = "";
            txtIndicadorVenda.Text = "";
            txtObra.Text = "";
            txtMarca.Text = "";
            txtGrupoProduto.Text = "";
            txtSubGrupo.Text = "";
            txtVendedor.Text = "";
            txtStatus.Text = "";

            var filtros = new Dictionary<string, object>();

            
            RelEstoque impressao = new RelEstoque();
          
            DataTable dt = new DataTable();

                     
            filtros.Add("CD_EMPRESA", "1");


            dt = impressao.retornaEmpresa(filtros);

            foreach (DataRow dr in dt.Rows)
            {

                txtEmpresa.Text = dr["CD_EMPRESA"].ToString();
                lblEmpresa.Text = dr["DS_EMPRESA"].ToString();

            }

            filtros.Clear();
            filtros.Add("CD_EMPRESA", "1");
            filtros.Add("CD_FILIAL", "1");

            dt = impressao.retornaFilial(filtros);

            foreach (DataRow dr in dt.Rows)
            {
                txtFilial.Text = dr["CD_FILIAL"].ToString();
                lblFilial.Text = dr["DS_FILIAL"].ToString();

            }

            txtFilial.Enabled = chkFilial.Checked;
            btnFilial.Enabled = chkFilial.Checked;

            groupData.Enabled = chkDatas.Checked;

            if (_estoque)
            {
                usBarraTitulo1.valor = "Estoque ";
                groupPedido.Enabled = false; 
                groupData.Enabled = true;
                chkDatas.Checked = true;
                chkDatas.Enabled = true;
                groupEstoqque.Enabled = true;
                
            }
            else {
                usBarraTitulo1.valor = "Pedidos ";
                groupPedido.Enabled = true;
                groupData.Enabled = true;
                chkDatas.Checked = true;
                chkDatas.Enabled = true;
                groupEstoqque.Enabled = false;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btmEmpresa_Click(object sender, EventArgs e)
        {
            frmLocalizarAll frm = new frmLocalizarAll(0);
            frm.ShowDialog();
            txtEmpresa.Text = frm.Codigo.ToString();
            lblEmpresa.Text = frm.descricao.ToString();

        }

        private void btnFilial_Click(object sender, EventArgs e)
        {
            frmLocalizarAll frm = new frmLocalizarAll(1);
            frm.ShowDialog();
            txtFilial.Text = frm.Codigo.ToString();
            lblFilial.Text = frm.descricao.ToString();

        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            frmLocalizarAll frm = new frmLocalizarAll(2);
            frm.ShowDialog();
            txtCliente.Text = frm.Codigo.ToString();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            frmLocalizarAll frm = new frmLocalizarAll(5);
            frm.ShowDialog();
            txtRegiao.Text = frm.Codigo.ToString();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            frmLocalizarAll frm = new frmLocalizarAll(3);
            frm.ShowDialog();
            txtVendedor.Text = frm.Codigo.ToString();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            frmLocalizarAll frm = new frmLocalizarAll(4);
            frm.ShowDialog();
            txtTransporte.Text = frm.Codigo.ToString();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            frmLocalizarAll frm = new frmLocalizarAll(6);
            frm.ShowDialog();
            txtCarteira.Text = frm.Codigo.ToString();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            frmLocalizarAll frm = new frmLocalizarAll(7);
            frm.ShowDialog();
            txtFormaPagto.Text = frm.Codigo.ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            frmLocalizarAll frm = new frmLocalizarAll(8);
            frm.ShowDialog();
            txtProduto.Text = frm.Codigo.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            frmLocalizarAll frm = new frmLocalizarAll(12);
            frm.ShowDialog();
            txtSubGrupo.Text = frm.Codigo.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            frmLocalizarAll frm = new frmLocalizarAll(9);
            frm.ShowDialog();
            txtServico.Text = frm.Codigo.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmLocalizarAll frm = new frmLocalizarAll(10);
            frm.ShowDialog();
            txtCidade.Text = frm.Codigo.ToString();
        }

        private void chkDatas_CheckedChanged(object sender, EventArgs e)
        {
            groupData.Enabled = chkDatas.Checked;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmLocalizarAll frm = new frmLocalizarAll(11);
            frm.ShowDialog();
            txtEstado.Text = frm.EstadoSelecionado;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmLocalizarAll frm = new frmLocalizarAll(12);
            frm.ShowDialog();
            txtGrupoProduto.Text = frm.Codigo.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmLocalizarAll frm = new frmLocalizarAll(14);
            frm.ShowDialog();
            txtMarca.Text = frm.Codigo.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmLocalizarAll frm = new frmLocalizarAll(15);
            frm.ShowDialog();
            txtTipoProduto.Text = frm.Codigo.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmLocalizarAll frm = new frmLocalizarAll(16);
            frm.ShowDialog();
            txtTipoEntidade.Text = frm.Codigo.ToString();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            frmLocalizarAll frm = new frmLocalizarAll(17);
            frm.ShowDialog();
            txtClassEntiade.Text = frm.Codigo.ToString();
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            frmLocalizarAll frm = new frmLocalizarAll(17);
            frm.ShowDialog();
            txtStatus.Text = frm.Codigo.ToString();
        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }

        private void txtStatus_TextChanged(object sender, EventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)
        {
            frmLocalizarAll frm = new frmLocalizarAll(19);
            frm.ShowDialog();
            txtTipoPedido.Text = frm.Codigo.ToString();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            frmLocalizarAll frm = new frmLocalizarAll(20);
            frm.ShowDialog();
            txtFornecedor.Text = frm.Codigo.ToString();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            frmLocalizarAll frm = new frmLocalizarAll(21);
            frm.ShowDialog();
            txtTipoEmbalagem.Text = frm.Codigo.ToString();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            frmLocalizarAll frm = new frmLocalizarAll(22);
            frm.ShowDialog();
            txtIndicadorVenda.Text = frm.Codigo.ToString();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            frmLocalizarAll frm = new frmLocalizarAll(23);
            frm.ShowDialog();
            txtObra.Text = frm.Codigo.ToString();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            frmLocalizarAll frm = new frmLocalizarAll(24);
            frm.ShowDialog();
            txtFrete.Text = frm.Codigo.ToString();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            frmLocalizarAll frm = new frmLocalizarAll(25);
            frm.ShowDialog();
            txtCampanha.Text = frm.Codigo.ToString();
        }

        private Dictionary<string, object> retornaFiltroPedido()
        {
            var filtros = new Dictionary<string, object>();

            //Data 

            if (chkDatas.Checked)
            {
                if (!string.IsNullOrWhiteSpace(dataInicial.Value.ToString()))
                    filtros.Add("DataInicio", dataInicial.Value.ToString());

                if (!string.IsNullOrWhiteSpace(dataFinal.Value.ToString()))
                    filtros.Add("DataFim", dataFinal.Value.ToString());
            }

            if (!string.IsNullOrWhiteSpace(txtEmpresa.Text))
                filtros.Add("PEDIDO.CD_EMPRESA", txtEmpresa.Text);

            if (!string.IsNullOrWhiteSpace(txtFilial.Text) && chkFilial.Checked)
                filtros.Add("PEDIDO.CD_FILIAL", txtFilial.Text);

            if (!string.IsNullOrWhiteSpace(txtCliente.Text))
                filtros.Add("PEDIDO.CD_CLIENTE", txtCliente.Text);

            if (!string.IsNullOrWhiteSpace(txtTipoPedido.Text))
                filtros.Add("PEDIDO.CD_TIPO_PEDIDO", txtTipoPedido.Text);

            if (!string.IsNullOrWhiteSpace(txtRegiao.Text))
                filtros.Add("CLIENTE.CD_REGIAO", txtRegiao.Text);

            if (!string.IsNullOrWhiteSpace(txtRegiao.Text))
                filtros.Add("CLIENTE.CD_REGIAO", txtRegiao.Text);

            if (!string.IsNullOrWhiteSpace(txtCidade.Text))
                filtros.Add("CLIENTE.CD_CIDADE", txtCidade.Text);

            if (!string.IsNullOrWhiteSpace(txtEstado.Text))
                filtros.Add("CIDADE.DS_UF", txtEstado.Text);

            if (!string.IsNullOrWhiteSpace(txtCarteira.Text))
                filtros.Add("PEDIDO.CD_CARTEIRA", txtCarteira.Text);

            if (!string.IsNullOrWhiteSpace(txtFormaPagto.Text))
                filtros.Add("PEDIDO.CD_FORMA_PAGAMENTO", txtFormaPagto.Text);

            if (!string.IsNullOrWhiteSpace(txtClassEntiade.Text))
                filtros.Add("CLIENTE.CD_CLASSIFICACAO", txtClassEntiade.Text);

            if (!string.IsNullOrWhiteSpace(txtVendedor.Text))
                filtros.Add("PEDIDO.CD_VENDEDOR", txtVendedor.Text);

            if (!string.IsNullOrWhiteSpace(txtVendedor.Text))
                filtros.Add("PEDIDO.CD_VENDEDOR", txtVendedor.Text);

            if (!string.IsNullOrWhiteSpace(txtObra.Text))
                filtros.Add("PEDIDO.CD_OBRA", txtObra.Text);

            if (!string.IsNullOrWhiteSpace(txtTransporte.Text))
                filtros.Add("PEDIDO.CD_TRANSPORTADOR", txtTransporte.Text);

            if (!string.IsNullOrWhiteSpace(txtFrete.Text))
                filtros.Add("PEDIDO.CD_TRANSPORTADOR", txtTransporte.Text);

            if (!string.IsNullOrWhiteSpace(txtProduto.Text))
                filtros.Add("I.CD_MATERIAL", txtProduto.Text);

            return filtros;

        }

        private Dictionary<string, object> retornaFiltroProduto()
        {
            var filtros = new Dictionary<string, object>();

            if (chkDatas.Checked)
            {
                if (!string.IsNullOrWhiteSpace(dataInicial.Value.ToString()))
                    filtros.Add("DataInicio", dataInicial.Value.ToString());

                if (!string.IsNullOrWhiteSpace(dataFinal.Value.ToString()))
                    filtros.Add("DataFim", dataFinal.Value.ToString());
            }

            if (!string.IsNullOrWhiteSpace(txtProduto.Text))
                filtros.Add("ITENSPEDIDO.CD_MATERIAL", txtProduto.Text);

            if (!string.IsNullOrWhiteSpace(txtServico.Text) && !string.IsNullOrWhiteSpace(txtProduto.Text))
                filtros.Add("ITENSPEDIDO.CD_MATERIAL", txtServico.Text);

            if (!string.IsNullOrWhiteSpace(txtMarca.Text))
                filtros.Add("MATERIAIS.CD_MARCA", txtMarca.Text);

            if (!string.IsNullOrWhiteSpace(txtSubGrupo.Text))
                filtros.Add("MATERIAIS.CD_SUBGRUPO", txtSubGrupo.Text);

            if (!string.IsNullOrWhiteSpace(txtTipoEmbalagem.Text))
                filtros.Add("MATERIAIS.CD_TIPO_EMBALAGEM", txtTipoEmbalagem.Text);

            if (!string.IsNullOrWhiteSpace(txtFornecedor.Text))
                filtros.Add("MATERIAIS.CD_FORNECEDOR", txtFornecedor.Text);

            if (!string.IsNullOrWhiteSpace(txtTipoProduto.Text))
                filtros.Add("MATERIAIS.CD_TIPO", txtTipoProduto.Text);

             
            return filtros;

        }

        private Dictionary<string, object> retornaFiltroEstoque()
        {
            var filtros = new Dictionary<string, object>();

            if (chkDatas.Checked)
            {
                if (!string.IsNullOrWhiteSpace(dataInicial.Value.ToString()))
                    filtros.Add("DataInicio", dataInicial.Value.ToString());

                if (!string.IsNullOrWhiteSpace(dataFinal.Value.ToString()))
                    filtros.Add("DataFim", dataFinal.Value.ToString());
            }

            if (!string.IsNullOrWhiteSpace(txtProduto.Text))
                filtros.Add("CODIGO", txtProduto.Text);

           
            


            return filtros;

        }


        private void usMenu1_Load(object sender, EventArgs e)
        {

        }

        private void chkFilial_CheckedChanged(object sender, EventArgs e)
        {
            txtFilial.Enabled = chkFilial.Checked;
            btnFilial.Enabled = chkFilial.Checked;

        }
    }
}
