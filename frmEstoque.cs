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
    public partial class frmEstoque : frmBase
    {

        Util.FormatacaoGrade formatar = new Util.FormatacaoGrade();
        Estoque estoque = new Estoque();
        List<Estoque> lista = new List<Estoque>();
        filtro.filtrarPedidos filtrarPed = new filtro.filtrarPedidos();



        public int Produto = 0;
        public frmEstoque(int CodProduto = 0)
        {
            InitializeComponent();
            reset();

            usMenu1.LocalizarButtonClicked += UsMenu1_LocalizarButtonClicked;
            usMenu1.CloseButtonClicked += UsMenu1_CloseButtonClicked;
            usMenu1.FiltroButtonClicked += UsMenu1_FiltroButtonClicked;
            usMenu1.CancelarButtonClicked += UsMenu1_CancelarButtonClicked;

            grade.CellFormatting += grade_CellFormatting;
        
            Produto = CodProduto;
            
            //if (Produto > 0) estoque.PreencherGradeEstoque(grade, estoque.retornarEstoqueDisponivel(Produto), lblProduto);
            
        }

        private void UsMenu1_LocalizarButtonClicked(object sender, EventArgs e)
        {

            Cursor.Current = Cursors.WaitCursor;
            lblAviso.Visible = true;
            lblAviso.Refresh();

            reset();
            Gerar_gradeProdutos();

            Cursor.Current = Cursors.Default;
            lblAviso.Visible = false;
            lblAviso.Refresh();
        }
        private void UsMenu1_CancelarButtonClicked(object sender, EventArgs e)
        {
            reset();
        }
        private void UsMenu1_FiltroButtonClicked(object sender, EventArgs e)
        {
            reset();
            
            frmFiltro frm = new frmFiltro();
            frm.ShowDialog();

            if (frm.atribuirFiltro)
            {

                string Metodo = frm.metodo.ToString();
                string campo = frm.campo.ToString();
                string Conteudo = frm.conteudo.ToString();

                Dictionary<string, object> retorno = new Dictionary<string, object>();

                retorno = filtrarPed.filtroProduto(Metodo, campo, Conteudo);

                Gerar_gradeProdutos(retorno);
            }
        }


        private void UsMenu1_CloseButtonClicked(object sender, EventArgs e)
        {
            Close();
        }

        private void grade_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Verifica se estamos na coluna "Total" (substitua "Total" pelo nome correto da coluna ou índice)
            if (grade.Columns[e.ColumnIndex].Name == "Total" && e.Value != null)
            {
                // Converte o valor da célula em número
                if (decimal.TryParse(e.Value.ToString(), out decimal total))
                {
                    // Altera a cor de fundo da célula com base no valor
                    if (total > 0)
                    {
                        e.CellStyle.BackColor = Color.LightGreen; // Verde para valores maiores que 0
                        e.CellStyle.ForeColor = Color.Black; // Texto branco para contraste
                    }
                    else if (total <= 0)
                    {
                        e.CellStyle.BackColor = Color.LightCoral; // Vermelho para valores menores ou iguais a 0
                        e.CellStyle.ForeColor = Color.Black; // Texto branco para contraste
                    }
                }
            }

            if (grade.Columns[e.ColumnIndex].Name == "Disponivel" && e.Value != null)
            {
                // Converte o valor da célula em número
                if (decimal.TryParse(e.Value.ToString(), out decimal total))
                {
                    // Altera a cor de fundo da célula com base no valor
                    if (total > 0)
                    {
                        e.CellStyle.BackColor = Color.LightGreen; // Verde para valores maiores que 0
                        e.CellStyle.ForeColor = Color.Black; // Texto branco para contraste
                    }
                    else if (total <= 0)
                    {
                        e.CellStyle.BackColor = Color.LightCoral; // Vermelho para valores menores ou iguais a 0
                        e.CellStyle.ForeColor = Color.Black; // Texto branco para contraste
                    }
                }
            }

            if (grade.Columns[e.ColumnIndex].Name == "EstoqueAtual" && e.Value != null)
            {
                // Converte o valor da célula em número
                if (decimal.TryParse(e.Value.ToString(), out decimal total))
                {
                    // Altera a cor de fundo da célula com base no valor
                    if (total > 0)
                    {
                        e.CellStyle.BackColor = Color.LightGreen; // Verde para valores maiores que 0
                        e.CellStyle.ForeColor = Color.Black; // Texto branco para contraste
                    }
                    else if (total <= 0)
                    {
                        e.CellStyle.BackColor = Color.LightCoral; // Vermelho para valores menores ou iguais a 0
                        e.CellStyle.ForeColor = Color.Black; // Texto branco para contraste
                    }
                }
            }
        }


        private void frmEstoque_Load(object sender, EventArgs e)
        {

        }

        private void reset()
        {
            //Configuração dos botões
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


            formatar.formatargradeProdutos(gradeProdutos);

            formatar.formatargradeEstoque(grade);
            
        }

        private void Gerar_gradeProdutos(Dictionary<string, object> filtros = null)
        {
            formatar.formatargradeProdutos(gradeProdutos);

            DataTable dt = new DataTable();

            dt = estoque.retornaDadosProduto(filtros);
                
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {


                    gradeProdutos.Rows.Add(row["CD_MATERIAL"].ToString()
                                          ,row["CD_IDENTIFICACAO"].ToString()
                                          , row["DS_MATERIAL_NF"].ToString()
                                          , row["DS_MARCA"].ToString()
                                          , Convert.ToDouble(row["NR_ESTOQUE_DISPONIVEL"]).ToString("N4")
                                          , Convert.ToDouble(row["VL_VENDA"]).ToString("N4")
                                          , Convert.ToDouble(row["VL_CUSTO_REPOSICAO"]).ToString("N4")
                                          , row["CD_CEST"].ToString()

                        );



                }
            }
        }

        private void gradeEstoque()
        {
            formatar.formatargradeEstoque(grade);


            if (gradeProdutos.CurrentRow != null)
            {
                Produto = Convert.ToInt32(gradeProdutos.CurrentRow.Cells["Codigo"].Value);
                estoque.PreencherGradeEstoque(grade, estoque.retornarEstoqueDisponivel(Produto, label1));
            }
            
            
        }

        private void usMenu1_Load(object sender, EventArgs e)
        {

        }
        

        private void grade_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void usBarraTitulo1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmLocalizarPedido frm = new frmLocalizarPedido(1);
            frm.ShowDialog();
            reset();
            
        }

        private void txtProduto_TextChanged(object sender, EventArgs e)
        {

        }

        private void gradeProdutos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void gradeProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            gradeEstoque();
        }

        private void gradeProdutos_SelectionChanged(object sender, EventArgs e)
        {
            gradeEstoque();
        }
    }
}
