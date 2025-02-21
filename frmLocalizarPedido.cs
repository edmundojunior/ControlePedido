using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace ControlePedido
{
    public partial class frmLocalizarPedido : frmBase
    {
        
        Pedidos ped = new Pedidos();
        Pedidos.MovimentacaoPedido mov = new Pedidos.MovimentacaoPedido();

        Util.dataEHora datahora = new Util.dataEHora();
        Util.FormatacaoGrade fomatar = new Util.FormatacaoGrade();
        filtro.filtrarPedidos filtrarPed = new filtro.filtrarPedidos();

        public int codPedido = 0;
        private int _Localizar = 0;
        
        
        private DateTime dtInicial = DateTime.Now;
        private DateTime dtFinal = DateTime.Now;
        private string Metodo = null;
        private string campo = "";
        private string Conteudo = "";
        

        public frmLocalizarPedido(int Localizar)
        {
            InitializeComponent();
            usMenu1.CloseButtonClicked += UsMenu1_CloseButtonClicked;
            usMenu1.FiltroButtonClicked += usMenu1_FiltroButtonClicked;
            usMenu1.PrimeiroButtonClicked += usMenu1_PrimeiroButtonClicked;
            usMenu1.AnteriorButtonClicked += usMenu1_AnteriorButtonClicked;
            usMenu1.ProximoButtonClicked += usMenu1_ProximoButtonClicked;
            usMenu1.UltimoButtonClicked += usMenu1_UltimoButtonClicked;
            usMenu1.CancelarButtonClicked += usMenu1_CancelarButtonClicked;
            usMenu1.LocalizarButtonClicked += usMenu1_LocalizarButtonClicked;
            usMenu1.ConfirmarButtonClicked += usMenu1_ConfirmarButtonClicked;
            _Localizar = Localizar;
            reset();
        }

        private void usMenu1_LocalizarButtonClicked(object sender, EventArgs e)
        {
            reset();
            
            filtrar(true);

            if (grade.Rows.Count >= 2)
            {
                usMenu1.SetButtonEnabled("Confirmar", true);
            }
            else {
                usMenu1.SetButtonEnabled("Confirmar", false);
            }

        }

        private void usMenu1_ConfirmarButtonClicked(object sender, EventArgs e)
        {
            if (grade.CurrentRow != null)
            {
                // Obtém o valor da célula na coluna "CodPedido"
                object codPedidos = grade.CurrentRow.Cells["Codigo"].Value;

                // Verifica se o valor não é nulo
                if (codPedidos != null)
                {
                    codPedido = Convert.ToInt32(codPedidos);

                    Close();
                }
                else
                {
                    MessageBox.Show("Valor inválido", "Aviso");
                }
            }
            else
            {
                MessageBox.Show("Nenhuma linha está selecionada.", "Erro");
            }
        }

        private void usMenu1_CancelarButtonClicked(object sender, EventArgs e)
        {
            reset();
        }
        private void usMenu1_PrimeiroButtonClicked(object sender, EventArgs e)
        {
            
        }

        private void usMenu1_AnteriorButtonClicked(object sender, EventArgs e)
        {

        }

        private void usMenu1_ProximoButtonClicked(object sender, EventArgs e)
        {

        }

        private void usMenu1_UltimoButtonClicked(object sender, EventArgs e)
        {

        }
        private void usMenu1_FiltroButtonClicked(object sender, EventArgs e)
        {
            reset();
            frmFiltro frm = new frmFiltro();
            frm.ShowDialog();

            if (frm.atribuirFiltro)
            {
                dtInicial = frm.dtInicio;
                dtFinal = frm.dtFim;
                Metodo = frm.metodo;
                Conteudo = frm.conteudo;
                campo = frm.campo;
                filtrar(false);
                //filtrar(frm.dtInicio, frm.dtFim, frm.campo, frm.conteudo, frm.metodo);
                if (grade.Rows.Count >= 2)
                {
                    usMenu1.SetButtonEnabled("Confirmar", true);
                }
                else
                {
                    usMenu1.SetButtonEnabled("Confirmar", false);
                }

            }

        }

        private void UsMenu1_CloseButtonClicked(object sender, EventArgs e)
        {
            Close();
        }


        private void frmLocalizarPedido_Load(object sender, EventArgs e)
        {

        }

        private void usBarraTitulo1_Load(object sender, EventArgs e)
        {

        }

        private void grade_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && grade.Rows[e.RowIndex].Cells[0].Value != null)
            {
                // Captura o valor da primeira coluna da linha clicada
                codPedido = Convert.ToInt32(grade.Rows[e.RowIndex].Cells[0].Value);                

                Close();
            }
        }


        private void reset()
        {
            
            usMenu1.SetButtonEnabled("Localizar", true);
            usMenu1.SetButtonEnabled("Confirmar", false);
            usMenu1.SetButtonEnabled("Imprimir", false);
            usMenu1.SetButtonEnabled("Atualizar", false);
            usMenu1.SetButtonEnabled("Filtro", true);
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

            dtInicial = primeiroUltimoDia.PrimeiroDia;
            dtFinal = primeiroUltimoDia.UltimoDia;

            switch (_Localizar)
            {
                case 0://Localizar Pedidos de Venda
                    usBarraTitulo1.valor = "Localizar Pedidos de Venda";
                    fomatar.formatarGradePedidos(grade);
                    break;
                case 1://Localizar Produto
                    usBarraTitulo1.valor = "Localizar Produtos";
                    fomatar.formatargradeProdutos(grade);
                    break;
                default:
                    break;
            }
        }

        private void PedidosDeVenda(bool geral = true)
        {
                      

            Cursor.Current = Cursors.WaitCursor;
            lblAviso.Visible = true;
            lblAviso.Refresh();

            grade.Columns.Clear();

            fomatar.formatarGradePedidos(grade);

            List<Pedidos.itemPedido> lista = new List<Pedidos.itemPedido>();

            Dictionary<string, object> filtros;

            if (geral)
            {
                filtros = null;
            } else filtros = filtrarPed.filtro(dtInicial, dtFinal, Metodo, campo, Conteudo);

            mov.retornaListaPedido(grade , filtros);
            
            Cursor.Current = Cursors.Default;
            lblAviso.Visible = false;
            lblAviso.Refresh();
        }

        private void filtrar(bool geral)
        {
            switch (_Localizar)
            {
                case 0://Localizar Pedidos de Venda
                    PedidosDeVenda(geral);
                    break;
                case 1://Localizar Produto
                    //usBarraTitulo1.valor = "Localizar Produtos";
                    //fomatar.formatargradeProdutos(grade);
                    break;
                default:
                    break;
            }
        }


        private void usMenu1_Load(object sender, EventArgs e)
        {

        }

        private void grade_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void grade_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && grade.Rows[e.RowIndex].Cells[0].Value != null)
            {
                // Captura o valor da primeira coluna da linha clicada
                codPedido = Convert.ToInt32(grade.Rows[e.RowIndex].Cells[0].Value);

                Close();
            }
        }
    }
}
