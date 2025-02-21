using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlePedido
{
    
    public partial class frmMovimentacao : Form
    {
        public List<Pedidos.itemPedido> ListaAlterados = new List<Pedidos.itemPedido>();
        private bool entragar = false;
        private string pedido = string.Empty;
        public bool fechando = false;

        List<Pedidos.itemPedido> ListaPedidos = new List<Pedidos.itemPedido>();

        Util.FormatacaoGrade formatar = new Util.FormatacaoGrade();
        Pedidos ped = new Pedidos();
        
        public frmMovimentacao(bool entragar, string pedido, List<Pedidos.itemPedido> lista = null, int cd_usuario_ = 0)
        {
            InitializeComponent();
            usMenu1.CloseButtonClicked += UsMenu1_CloseButtonClicked;
            usMenu1.ExecutarButtonClicked += UsMenu1_ExecutarButtonClicked;
            usMenu1.CancelarButtonClicked += UsMenu1_CancelarButtonClicked;

            this.entragar = entragar;
            this.pedido = pedido;
            this.ListaPedidos = lista;
            fechando = false;
            reset();
            
         }


        private void UsMenu1_CancelarButtonClicked(object sender, EventArgs e)
        {
            reset();
        }
        private void UsMenu1_ExecutarButtonClicked(object sender, EventArgs e)
        {
            fechando = false;
            Movimentar();
            
        }
        private void UsMenu1_CloseButtonClicked(object sender, EventArgs e)
        {
            
            fechando = true;
            Close();
        }

        private void usBarraTitulo1_Load(object sender, EventArgs e)
        {

        }
        
        private void frmMovimentacao_Load(object sender, EventArgs e)
        {

        }

        private void reset()
        {

            if (entragar)
            {
                pnlProduto.BackColor = Color.LightSteelBlue;
                usBarraTitulo1.valor = "ENTREGAR PRODUTOS";
            }
            else
            {
                pnlProduto.BackColor = Color.Khaki;
                usBarraTitulo1.valor = "DEVOLVER PRODUTOS";
            }

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


            lblPedido.Text = pedido;
            lblCodigo.Text = "";
            lblDescricao.Text = "";
            lblquantidadeOriginal.Text = "0";
            txtIdentificacao.Text = "";
            txtQuantidade.Text = "0";

            formatar.formatargradeMovimentacao(grade);

            //Preencher grade
            PreencherGrade();

            txtQuantidade.Focus();

            txtIdentificacao.Enabled = false;
            txtQuantidade.Enabled = false;

        }

        
        private void PreencherGrade()
        {
            if (ListaPedidos.Count > 0)
            {
                int item = 0;
                grade.Rows.Clear();

                while (item < ListaPedidos.Count)
                {

                    grade.Rows.Add((item + 1).ToString(),
                                          ListaPedidos[item].codItem
                                          , ListaPedidos[item].codIdentific
                                          , ListaPedidos[item].descricao
                                          , ListaPedidos[item].unidade
                                          , Convert.ToDouble(ListaPedidos[item].Quantidade).ToString("N4")
                                          , Convert.ToDouble(ListaPedidos[item].QuantOriginal).ToString("N4")
                                          );


                    item++;
                }

                grade.Refresh();
                
            }
        }

        private void grade_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void grade_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow linhaSelecionada = grade.Rows[e.RowIndex];

                if (linhaSelecionada != null)
                {
                    lblCodigo.Text = linhaSelecionada.Cells["Codigo"].Value.ToString();
                    lblDescricao.Text =  linhaSelecionada.Cells["Produto"].Value.ToString() + " - " + linhaSelecionada.Cells["Unidade"].Value.ToString();
                    txtQuantidade.Text = Convert.ToDouble(linhaSelecionada.Cells["Qtde"].Value).ToString("N4");
                    txtIdentificacao.Text = linhaSelecionada.Cells["CodIdentific"].Value == null ? "" : linhaSelecionada.Cells["CodIdentific"].Value.ToString();
                    lblquantidadeOriginal.Text = Convert.ToDouble(linhaSelecionada.Cells["QtdeOriginal"].Value) == 0 ? "" : Convert.ToDouble(linhaSelecionada.Cells["QtdeOriginal"].Value).ToString("N4");
                    txtIdentificacao.Enabled = true;
                    txtQuantidade.Enabled = true;
                    txtQuantidade.Focus();

                } 

            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            Util.Movimentacao mov = new Util.Movimentacao();

            if (! verificarQuantidade(Convert.ToDouble(txtQuantidade.Text), Convert.ToDouble(lblquantidadeOriginal.Text))) return ;

            mov.AtualizarQuantidade(ListaPedidos, Convert.ToInt32(lblCodigo.Text), Convert.ToDouble(txtQuantidade.Text), txtIdentificacao.Text);
            lblCodigo.Text = "0000";
            lblDescricao.Text = "...";
            txtQuantidade.Text = "";
            txtIdentificacao.Text = "";
            lblquantidadeOriginal.Text = "0";
            PreencherGrade();
        
        }

        private void Movimentar()
        {
            if (ListaPedidos.Count > 0) {
                int item = 0;
                while (item < ListaPedidos.Count)
                {

                    var items = ListaPedidos.FirstOrDefault(i => i.codItem == ListaPedidos[item].codItem);

                    if (items != null)
                    {
                        items.entrega = true; 
                    }

                    item++;
                }

                ListaPedidos.RemoveAll(p => p.Quantidade == 0);

                ListaAlterados = ListaPedidos;
            }
            
            
            Close();
        }

        private void usMenu1_Load(object sender, EventArgs e)
        {

        }

        private bool verificarQuantidade(double valor, double original)
        {
            bool retorno = true;
            
            if (valor == 0 || valor > original)
            {
                MessageBox.Show("Valor não pode zero ou Maior que o valor orginal do pedido", "Aviso Importante");
                txtQuantidade.Text = "0";
                txtQuantidade.Focus();
                retorno = false;
            }

            return retorno;
        }
    }
}
