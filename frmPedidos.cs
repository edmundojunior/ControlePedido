using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ControlePedido
{
    public partial class frmPedidos : frmBase
    {
        Pedidos ped = new Pedidos();
        Pedidos.MovimentacaoPedido mov = new Pedidos.MovimentacaoPedido();  

        private bool _fechadoPorCodigo = false;

        private string _CodigoUsuario = string.Empty;
        private string _NomeDoUsuario = string.Empty;

        private bool liberar = false;

        Util.FormatacaoGrade formatarGrade = new Util.FormatacaoGrade();
        public frmPedidos(string CodigoUsuario = null, string NomedoUsuario = null)
        {
            InitializeComponent();
            _CodigoUsuario = CodigoUsuario;
            _NomeDoUsuario = NomedoUsuario;            
            reset();
            usMenu1.CloseButtonClicked += UsMenu1_CloseButtonClicked;
            usMenu1.FiltroButtonClicked += UsMenu1_FiltroButtonClicked;
            usMenu1.CancelarButtonClicked += UsMenu1_CancelarButtonClicked;



        }

        private void UsMenu1_CancelarButtonClicked(object sender, EventArgs e)
        {

            reset();
        }
        private void UsMenu1_FiltroButtonClicked(object sender, EventArgs e)
        {
            frmLocalizarPedido frm = new frmLocalizarPedido(0);
            frm.ShowDialog();
        }
        private void UsMenu1_CloseButtonClicked(object sender, EventArgs e)
        {            
            Close();
        }

        private void frmPedidos_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }
        private void frmPedidos_Load(object sender, EventArgs e)
        {
            frmLiberacao frm = new frmLiberacao();
            frm.ShowDialog();

            liberar = frm.liberado;


            if (liberar)
            {
                _CodigoUsuario = frm.codigo;
                _NomeDoUsuario = frm.nome;

                this.Text = $"Controle de Pedidos - Usuário: {_CodigoUsuario} - {_NomeDoUsuario}";
            }
            else
            {
                MessageBox.Show("Acesso não permitido ","Aviso Importante");
                
                this.Close();

            }
        }

        private void reset()
        {
            //Configuração dos botões
            usMenu1.SetButtonEnabled("Localizar", false);
            usMenu1.SetButtonEnabled("Confirmar", false);
            usMenu1.SetButtonEnabled("Imprimir", false);
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

            //ped.listaItemPedidoEntregue.Clear();
            //ped.listaItemPedido.Clear();
            //ped.listaTemp.Clear();
            //ped.listaEntregar.Clear();            

            formatarGrade.formatargrade(grade);
            formatarGrade.formatargradeEntregue(gradeEntregue);

            btnDesmarcarDevolver.Enabled = false;
            btnMarcarDevolver.Enabled = false;
            btnSubir.Enabled = false;
            btnDesmarcar.Enabled = false;
            btnMarcar.Enabled = false;  
            bntEntregar.Enabled = false;

            txtPedido.Text = "";
            lblCliente.Text = "...";           

            txtPedido.Focus();
        }

        private void txtPedido_Enter(object sender, EventArgs e)
        {
            txtPedido.SelectAll();  
        }

        private void txtPedido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtPedido.Text != "")
                {                    
                    listarEntrega();
                    listarEntregues();
                }
            }
        }

        private void listarEntrega()
        {
            Cursor.Current = Cursors.WaitCursor;
            lblAviso.Visible = true;
            lblAviso.Refresh();

            grade.Columns.Clear();

            formatarGrade.formatargrade(grade);

            List<Pedidos.itemPedido> lista = new List<Pedidos.itemPedido>();

            lista = mov.retornaListaEntregar(Convert.ToInt32(txtPedido.Text));

            if (lista.Count > 0)
            {

                btnMarcar.Enabled = true;
                btnDesmarcar.Enabled = true;
                bntEntregar.Enabled = true;

                int item = 0;

                lblCliente.Text = lista[item].nomeCliente;

                while (item < lista.Count)
                {

                    grade.Rows.Add(false,
                                (item + 1).ToString(),
                                lista[item].codItem
                                , lista[item].codIdentific
                                , lista[item].descricao
                                , lista[item].unidade
                                , Convert.ToDouble(lista[item].Quantidade).ToString("N4")
                                , "PD"
                                , Convert.ToDouble(lista[item].QuantOriginal).ToString("N4")
                                );
                    item++;
                }
            }
            else {

                btnMarcar.Enabled = false;
                btnDesmarcar.Enabled = false;
                bntEntregar.Enabled = false;               

            }
            
            Cursor.Current = Cursors.Default;
            lblAviso.Visible = false;
            lblAviso.Refresh();
        }

        private void listarEntregues()
        {
            Cursor.Current = Cursors.WaitCursor;
            lblAviso.Visible = true;
            lblAviso.Refresh();

            gradeEntregue.Columns.Clear();

            formatarGrade.formatargradeEntregue(gradeEntregue);

            
            List<Pedidos.itemPedido> lista = new List<Pedidos.itemPedido>();

            lista = mov.retornaListaEntregue(Convert.ToInt32(txtPedido.Text));

            if (lista.Count > 0)
            {

                btnDesmarcarDevolver.Enabled = true;
                btnMarcarDevolver.Enabled = true;
                btnSubir.Enabled = true;

                int item = 0;

                while (item < lista.Count)
                {

                    gradeEntregue.Rows.Add(false,
                                (item + 1).ToString(),
                                lista[item].codItem                                
                                , lista[item].descricao
                                , lista[item].unidade
                                , Convert.ToDouble(lista[item].Quantidade).ToString("N4")
                                , Convert.ToDateTime(lista[item].dtEntrega).ToString("dd.MM.yyyy")
                                );
                    item++;
                }
            }
            else {
                btnDesmarcarDevolver.Enabled = false;
                btnMarcarDevolver.Enabled = false;
                btnSubir.Enabled = false;
            }


            Cursor.Current = Cursors.Default;
            lblAviso.Visible = false;
            lblAviso.Refresh();
        }
        private void txtPedido_Leave(object sender, EventArgs e)
        {

        }

        private void txtPedido_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtPedido_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnMarcar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in grade.Rows)
            {
                row.Cells["Entregar"].Value = true; // Desmarca o checkbox
                bool isChecked = Convert.ToBoolean(row.Cells["Entregar"].Value);
                
            }
        }

        private void btnDesmarcar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in grade.Rows)
            {
                row.Cells["Entregar"].Value = false; // Desmarca o checkbox

                bool isChecked = Convert.ToBoolean(row.Cells["Entregar"].Value);
                
            }            
        }

        private void produtoSelecionados()
        {
            int items = 0;



            foreach (DataGridViewRow row in grade.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Entregar"].Value) == true)
                {
                    //verificar se a lista ja esta preechida e selecionar um determinado produto


                    ped.listaEntregar.Add(new Pedidos.itemPedido
                    {
                        item = (items + 1),
                        codPedido = Convert.ToInt32(txtPedido.Text),
                        codItem = Convert.ToInt32(row.Cells["Codigo"].Value),
                        codIdentific = row.Cells["CodIdentific"].Value.ToString(),
                        descricao = row.Cells["Produto"].Value.ToString(),
                        unidade = row.Cells["Unidade"].Value.ToString(),
                        Quantidade = Convert.ToDouble(row.Cells["Qtde"].Value),
                        QuantOriginal = Convert.ToDouble(row.Cells["QtdeOriginal"].Value)

                    });


                    items++;
                }
            }
        }
        private void bntEntregar_Click(object sender, EventArgs e)
        {

            produtoSelecionados();

            if (ped.listaEntregar.Count > 0)
            {

                int usuario = 0;
                //bool liberado = false;

                //frmLiberacao frmlib = new frmLiberacao();
                //frmlib.ShowDialog();
                //liberado = frmlib.liberado;

                //if (liberado)
                //{
                    frmMovimentacao frm = new frmMovimentacao(true, txtPedido.Text, ped.listaEntregar, usuario);
                    frm.ShowDialog();

                    if (frm.fechando) return;

                    ped.listaTemp = frm.ListaAlterados;

                    mov.MovimentarEntrega(ped.listaTemp);            


                    listarEntrega();
                    listarEntregues();

                    ped.listaEntregar.Clear();
                //}

            }
            else
            {
                MessageBox.Show("Nenhum produto selecionado!", "Aviso Importante");
            }

        }

        
        private void usBarraTitulo1_Load(object sender, EventArgs e)
        {

        }

        private void produtoDevolver()
        {
            int items = 0;

            ped.listaDevolucao.Clear();

            foreach (DataGridViewRow row in gradeEntregue.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Devolver"].Value) == true)
                {
                    ped.listaDevolucao.Add(new Pedidos.itemPedido
                    {
                        item = (items + 1),
                        codPedido = Convert.ToInt32(txtPedido.Text),
                        codItem = Convert.ToInt32(row.Cells["Codigo"].Value),
                        //codIdentific = row.Cells["Identific"].Value.ToString() == null ? "": row.Cells["Identific"].Value.ToString(),
                        descricao = row.Cells["Produto"].Value.ToString(),
                        unidade = row.Cells["Unidade"].Value.ToString(),
                        Quantidade = Convert.ToDouble(row.Cells["Qtde"].Value),
                        QuantOriginal = Convert.ToDouble(row.Cells["Qtde"].Value),
                        dtEntrega = Convert.ToDateTime(row.Cells["DtEntrega"].Value)


                    });


                    items++;
                }
            }

        }

        private void btnSubir_Click(object sender, EventArgs e)
        {
            produtoDevolver();

            if (ped.listaDevolucao.Count > 0)
            {

                int usuario = 0;
                //bool liberado = false;

                //frmLiberacao frmlib = new frmLiberacao();
                //frmlib.ShowDialog();
                //liberado = frmlib.liberado;

                //if (!liberado)
                //{
                    MessageBox.Show("Usuário não liberado para realizar a Movimentação!", "Aviso Importante");
                //}
                //else
                //{
                    frmMovimentacao frm = new frmMovimentacao(false, txtPedido.Text, ped.listaDevolucao, usuario);
                    frm.ShowDialog();

                    if (frm.fechando) return;

                    ped.listaTemp = frm.ListaAlterados;

                    mov.MovimentarRetorno(ped.listaTemp);


                    listarEntrega();
                    listarEntregues();

                    ped.listaEntregar.Clear();
                //}

            }
            else
            {
                MessageBox.Show("Nenhum produto selecionado!", "Aviso Importante");
            }



            //produtoDevolver();

            //if (ped.listaDevolucao.Count > 0)
            //{
            //    int usuario = 0 ;
            //    bool liberado = false ;

            //    frmLiberacao frmlib = new frmLiberacao();
            //    frmlib.ShowDialog();
            //    liberado = frmlib.liberado;

            //    if (! liberado )
            //    {
            //        MessageBox.Show("Usuário não liberado para realizar a Movimentação!", "Aviso Importante");
            //    }
            //    else
            //    {
            //        frmMovimentacao frm = new frmMovimentacao(false, txtPedido.Text, ped.listaDevolucao, usuario);
            //        frm.fechando = false;
            //        frm.ShowDialog();

            //        if (frm.fechando) return;

            //        ped.listaTemp = frm.ListaAlterados;

            //        preencherGradesDevolvendoProduto();

            //    }



            //}
            //else
            //{
            //    MessageBox.Show("Nenhum produto selecionado!", "Aviso Importante");
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            reset();
            
            frmLocalizarPedido frm = new frmLocalizarPedido(0);
            frm.ShowDialog();

            txtPedido.Text = frm.codPedido.ToString();

            if (txtPedido.Text == (0).ToString()) return; 

            if (txtPedido.Text != "")
            {
                
                listarEntrega();
                listarEntregues();
               
            }
        }

        private void grade_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnMarcarDevolver_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gradeEntregue.Rows)
            {
                row.Cells["Devolver"].Value = true; // Desmarca o checkbox
                bool isChecked = Convert.ToBoolean(row.Cells["Devolver"].Value);

            }
        }

        private void btnDesmarcarDevolver_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gradeEntregue.Rows)
            {
                row.Cells["Devolver"].Value = false; // Desmarca o checkbox

                bool isChecked = Convert.ToBoolean(row.Cells["Devolver"].Value);

            }
        }
    }
}
