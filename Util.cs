using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ControlePedido
{
    public class Util
    {

        public string retornaCaminhoRelatorioPadrao(string nomeRel)
        {
            return Path.Combine(Directory.GetCurrentDirectory(), nomeRel);
        }
        public class FormatacaoGrade
        {
            //Grade Listagem de Pedidos
            public void formatarGradePedidos(System.Windows.Forms.DataGridView grade)
            {
                grade.Columns.Clear();

                grade.Columns.Add("Codigo", "Cód"); //0
                grade.Columns.Add("Filial", "Filial"); //1
                grade.Columns.Add("ST", "ST"); //2
                grade.Columns.Add("Status", "Cód.Status"); //3
                grade.Columns.Add("CodEntidade", "Cód"); //4
                grade.Columns.Add("Cliente", "Cliente"); //5
                grade.Columns.Add("CNPJ", "CNPJ"); //6
                grade.Columns.Add("Cidade", "Cidade"); //7
                grade.Columns.Add("Vendedor", "Vendedor"); //8
                grade.Columns.Add("DtEmissao", "Dt.Emissão"); //9
                grade.Columns.Add("DtEntrega", "Dt.Entrega"); //10
                grade.Columns.Add("Validade", "Validade"); //11
                grade.Columns.Add("Impostos", "Impostos"); //12
                grade.Columns.Add("OrdCompra", "Ord.Compra"); //13
                grade.Columns.Add("Obs", "Observação"); //14


                // Configurando o estilo geral do DataGridView
                grade.EnableHeadersVisualStyles = false; // Permite personalizar o cabeçalho
                grade.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 8, FontStyle.Bold);
                grade.ColumnHeadersDefaultCellStyle.BackColor = Color.NavajoWhite;
                grade.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
                grade.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

                grade.Columns[0].Width = 90; //Selecionar
                grade.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grade.Columns[1].Width = 90; // Item
                grade.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                grade.Columns[2].Width = 90; // Codigo Produto
                grade.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                grade.Columns[3].Width = 150; // Identificação 
                grade.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                grade.Columns[4].Width = 90; // Descrição do Produto
                grade.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grade.Columns[5].Width = 250; // Unidade
                grade.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                grade.Columns[6].Width = 90; //Quantidade
                grade.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grade.Columns[7].Width = 150; //Origem
                grade.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grade.Columns[8].Width = 150; //Origem
                grade.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grade.Columns[9].Width = 150; //Origem
                grade.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grade.Columns[10].Width = 150; //Origem
                grade.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grade.Columns[11].Width = 150; //Origem
                grade.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grade.Columns[12].Width = 150; //Origem
                grade.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grade.Columns[13].Width = 150; //Origem
                grade.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grade.Columns[14].Width = 150; //Origem
                grade.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                //// Configurando as linhas
                grade.DefaultCellStyle.Font = new Font("Segoe UI", 8, FontStyle.Regular);
                grade.DefaultCellStyle.BackColor = Color.White;
                grade.DefaultCellStyle.ForeColor = Color.Black;

                grade.AllowUserToAddRows = false;
            }

            //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=--=-

            public void formatargradeMovimentacao(System.Windows.Forms.DataGridView grade)
            {

                grade.Columns.Clear();

                grade.Columns.Add("Item", "Item");
                grade.Columns.Add("Codigo", "Cód");
                grade.Columns.Add("CodIdentific", "Cód. Identific.");
                grade.Columns.Add("Produto", "Produto");
                grade.Columns.Add("Unidade", "Unid");
                grade.Columns.Add("Qtde", "Qtde.");
                grade.Columns.Add("QtdeOriginal", "Original");


                // Configurando o estilo geral do DataGridView
                grade.EnableHeadersVisualStyles = false; // Permite personalizar o cabeçalho
                grade.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 8, FontStyle.Bold);
                grade.ColumnHeadersDefaultCellStyle.BackColor = Color.NavajoWhite;
                grade.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
                grade.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

                grade.Columns[0].Width = 50; //Item
                grade.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grade.Columns[1].Width = 80; //Codigo
                grade.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grade.Columns[2].Width = 120; // Identificação
                grade.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grade.Columns[3].Width = 390; // Descrição do Produto
                grade.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                grade.Columns[4].Width = 40; // Unidade 
                grade.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grade.Columns[5].Width = 90; // Quantidade
                grade.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grade.Columns[5].Width = 90; // Original
                grade.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


                //// Configurando as linhas
                grade.DefaultCellStyle.Font = new Font("Segoe UI", 8, FontStyle.Regular);
                grade.DefaultCellStyle.BackColor = Color.White;
                grade.DefaultCellStyle.ForeColor = Color.Black;

                grade.AllowUserToAddRows = false;

            }

            public void formatargrade(System.Windows.Forms.DataGridView grade)
            {
                grade.Columns.Clear();

                var colunaCheckbox = new DataGridViewCheckBoxColumn
                {
                    HeaderText = "",
                    Name = "Entregar",
                    Width = 50
                };
                grade.Columns.Add(colunaCheckbox);

                grade.Columns.Add("item", "Item");
                grade.Columns.Add("Codigo", "Cód");
                grade.Columns.Add("CodIdentific", "Cód. Identific.");
                grade.Columns.Add("Produto", "Produto");
                grade.Columns.Add("Unidade", "Unidade");
                grade.Columns.Add("Qtde", "Quantidade");
                grade.Columns.Add("Origem", "Origem");                
                grade.Columns.Add("QtdeOriginal", "Orig.");


                // Configurando o estilo geral do DataGridView
                grade.EnableHeadersVisualStyles = false; // Permite personalizar o cabeçalho
                grade.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 8, FontStyle.Bold);
                grade.ColumnHeadersDefaultCellStyle.BackColor = Color.NavajoWhite;
                grade.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
                grade.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

                grade.Columns[0].Width = 40; //Selecionar
                grade.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grade.Columns[1].Width = 50; // Item
                grade.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grade.Columns[2].Width = 90; // Codigo Produto
                grade.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grade.Columns[3].Width = 120; // Identificação 
                grade.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grade.Columns[4].Width = 700; // Descrição do Produto
                grade.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                grade.Columns[5].Width = 60; // Unidade
                grade.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grade.Columns[6].Width = 100; //Quantidade
                grade.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grade.Columns[7].Width = 100; //Origem
                grade.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;                
                grade.Columns[8].Width = 0; //Origem
                grade.Columns[8].Visible = false;
                grade.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                //// Configurando as linhas
                grade.DefaultCellStyle.Font = new Font("Segoe UI", 8, FontStyle.Regular);
                grade.DefaultCellStyle.BackColor = Color.White;
                grade.DefaultCellStyle.ForeColor = Color.Black;

                grade.AllowUserToAddRows = false;

            }

            public void formatargradeEntregue(System.Windows.Forms.DataGridView grade)
            {
                grade.Columns.Clear();

                var colunaCheckbox = new DataGridViewCheckBoxColumn
                {
                    HeaderText = "",
                    Name = "Devolver",
                    Width = 40
                };
                grade.Columns.Add(colunaCheckbox);

                grade.Columns.Add("item", "Item");
                grade.Columns.Add("Codigo", "Cód");
                grade.Columns.Add("Produto", "Produto");
                grade.Columns.Add("Unidade", "Unidade");
                grade.Columns.Add("Qtde", "Quantidade");
                grade.Columns.Add("DtEntrega", "Dt. Entrega");
                grade.Columns.Add("Identific", "Identific");
                grade.Columns.Add("QtdeOriginal", "Orig.");

                // Configurando o estilo geral do DataGridView
                grade.EnableHeadersVisualStyles = false; // Permite personalizar o cabeçalho
                grade.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 8, FontStyle.Bold);
                grade.ColumnHeadersDefaultCellStyle.BackColor = Color.NavajoWhite;
                grade.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
                grade.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

                grade.Columns[0].Width = 40; //Selecionar
                grade.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grade.Columns[1].Width = 50; // Item
                grade.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grade.Columns[2].Width = 90; // Codigo Produto
                grade.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grade.Columns[3].Width = 800; // Descrição do Produto
                grade.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                grade.Columns[4].Width = 50; // Unidade
                grade.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grade.Columns[5].Width = 100; //Quantidade
                grade.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grade.Columns[6].Width = 150;
                grade.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grade.Columns[7].Width = 0;
                grade.Columns[7].Visible = false;
                grade.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grade.Columns[8].Width = 0;
                grade.Columns[8].Visible = false;
                grade.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                //// Configurando as linhas
                grade.DefaultCellStyle.Font = new Font("Segoe UI", 8, FontStyle.Regular);
                grade.DefaultCellStyle.BackColor = Color.White;
                grade.DefaultCellStyle.ForeColor = Color.Black;

                grade.AllowUserToAddRows = false;

            }

            public void formatargradeProduto(System.Windows.Forms.DataGridView grade)
            {
                grade.Columns.Clear();
                               
                grade.Columns.Add("Codigo", "Código"); //0
                grade.Columns.Add("CodIdentific", "Cód. Identific."); //1
                grade.Columns.Add("Descricao", "Descrição"); //2
                grade.Columns.Add("Unidade", "Unid");//3
                grade.Columns.Add("OPProducao", "O.P. Produção");//4
                grade.Columns.Add("Orc", "Orçamento");//5
                grade.Columns.Add("Servico", "Or. Serviço");//6
                grade.Columns.Add("Pedidos", "Pedidos");//7
                grade.Columns.Add("EmSeparacao", "Em Separação");                                       //
                grade.Columns.Add("Separado", "Separado");//8
                grade.Columns.Add("Disponivel", "Disponível");//9
                grade.Columns.Add("SolicTransf", "Solic Transferencia");//10
                grade.Columns.Add("Total", "Total");//11
                grade.Columns.Add("Almoxarifado", "Almox.Ded.");//12


                // Configurando o estilo geral do DataGridView
                grade.EnableHeadersVisualStyles = false; // Permite personalizar o cabeçalho
                grade.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 8, FontStyle.Bold);
                grade.ColumnHeadersDefaultCellStyle.BackColor = Color.NavajoWhite;
                grade.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
                grade.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

                grade.Columns[0].Width = 300; //Selecionar
                grade.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                grade.Columns[1].Width = 70; // Item
                grade.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grade.Columns[2].Width = 70; // Codigo Produto
                grade.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grade.Columns[3].Width = 70; // Identificação 
                grade.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grade.Columns[4].Width = 70; // Descrição do Produto
                grade.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grade.Columns[5].Width = 70; // Unidade
                grade.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;               
                grade.Columns[6].Width = 70; //Quantidade
                grade.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grade.Columns[7].Width = 70; //Origem
                grade.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grade.Columns[8].Width = 70; //Quantidade
                grade.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grade.Columns[9].Width = 70; //Origem
                grade.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grade.Columns[10].Width = 70; //Quantidade
                grade.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grade.Columns[11].Width = 70; //Origem
                grade.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grade.Columns[12].Width = 70; //Quantidade
                grade.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grade.Columns[13].Width = 70; //Quantidade
                grade.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                //// Configurando as linhas
                grade.DefaultCellStyle.Font = new Font("Segoe UI", 7, FontStyle.Regular);
                grade.DefaultCellStyle.BackColor = Color.White;
                grade.DefaultCellStyle.ForeColor = Color.Black;

                grade.AllowUserToAddRows = false;

            }

            public void formatargradeEstoque(System.Windows.Forms.DataGridView grade)
            {
                grade.Columns.Clear();

                grade.Columns.Add("Filial", "Filial"); //0
                grade.Columns.Add("CodIdentific", "Cód. Identific."); //1
                grade.Columns.Add("OdCompra", "Ordem Compra"); //2
                grade.Columns.Add("OPConsumo", "O.P. Consumo");//3
                grade.Columns.Add("OPProducao", "O.P. Produção");//4
                grade.Columns.Add("Orc", "Orçamento");//5
                grade.Columns.Add("Servico", "Or. Serviço");//6
                grade.Columns.Add("Pedidos", "Pedidos");//7
                grade.Columns.Add("EmSeparacao", "Em Separação");//9
                grade.Columns.Add("Separado", "Separado");//10
                grade.Columns.Add("Disponivel", "Disponível");//11
                grade.Columns.Add("Total", "Total");//12
                grade.Columns.Add("Almoxarifado", "Almox.Ded.");//13



                // Configurando o estilo geral do DataGridView
                grade.EnableHeadersVisualStyles = false; // Permite personalizar o cabeçalho
                grade.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 8, FontStyle.Bold);
                grade.ColumnHeadersDefaultCellStyle.BackColor = Color.NavajoWhite;
                grade.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
                grade.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

                grade.Columns[0].Width = 300; //Filial
                grade.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                grade.Columns[1].Width = 70; // Cod.Identificação
                grade.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grade.Columns[2].Width = 70; // Ordem de Compra
                grade.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grade.Columns[3].Width = 70; // Consumo
                grade.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grade.Columns[4].Width = 70; // Producao
                grade.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grade.Columns[5].Width = 0; // Orcamento
                grade.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grade.Columns[5].Visible = false;
                grade.Columns[6].Width = 70; //Serviço
                grade.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grade.Columns[7].Width = 70; //Pedidos
                grade.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grade.Columns[8].Width = 70; //Em Separação
                grade.Columns[8].Visible = false;
                grade.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grade.Columns[9].Width = 70; //Separado
                grade.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                
                grade.Columns[10].Width = 70; //Requisição
                grade.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grade.Columns[11].Width = 70; //Estoque Total
                grade.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grade.Columns[12].Width = 70; //Disponivel
                grade.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //grade.Columns[13].Width = 70; //Solitação Transf.
                //grade.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //grade.Columns[14].Width = 70; //Total
                //grade.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                
                //// Configurando as linhas
                grade.DefaultCellStyle.Font = new Font("Segoe UI", 7, FontStyle.Regular);
                grade.DefaultCellStyle.BackColor = Color.White;
                grade.DefaultCellStyle.ForeColor = Color.Black;

                grade.AllowUserToAddRows = false;

            }

            public void formatargradeProdutos(System.Windows.Forms.DataGridView grade)
            {
                grade.Columns.Clear();

                grade.Columns.Add("Codigo", "Cód.:"); //0
                grade.Columns.Add("CodIdentific", "Cód. Identific."); //1
                grade.Columns.Add("Produto", "Material NF"); //2
                grade.Columns.Add("Marca", "Marca");//3
                grade.Columns.Add("Estoque", "Estoque");//4
                grade.Columns.Add("Unitario", "Valor Venda");//5
                grade.Columns.Add("Reposicao", "Vlr.Custo Reposição");//6
                grade.Columns.Add("CEST", "CEST");//7
                

                // Configurando o estilo geral do DataGridView
                grade.EnableHeadersVisualStyles = false; // Permite personalizar o cabeçalho
                grade.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 8, FontStyle.Bold);
                grade.ColumnHeadersDefaultCellStyle.BackColor = Color.NavajoWhite;
                grade.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
                grade.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

                grade.Columns[0].Width = 80; //Filial
                grade.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grade.Columns[1].Width = 80; // Cod.Identificação
                grade.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grade.Columns[2].Width = 300; // Ordem de Compra
                grade.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                grade.Columns[3].Width = 150; // Consumo
                grade.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grade.Columns[4].Width = 120; // Producao
                grade.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grade.Columns[5].Width = 120; // Orcamento
                grade.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grade.Columns[6].Width = 120; // Orcamento
                grade.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grade.Columns[7].Width = 90; // Orcamento
                grade.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                //// Configurando as linhas
                grade.DefaultCellStyle.Font = new Font("Segoe UI", 7, FontStyle.Regular);
                grade.DefaultCellStyle.BackColor = Color.White;
                grade.DefaultCellStyle.ForeColor = Color.Black;

                grade.AllowUserToAddRows = false;

            }

        }

        public class Movimentacao
        {
            public void AtualizarQuantidade(List<Pedidos.itemPedido> lista, int codigo, double NovaQuantidade, string Identificacao)
            {
                var item = lista.FirstOrDefault(i => i.codItem == codigo);

                if (item != null)
                {
                    item.Quantidade = NovaQuantidade;
                    item.codIdentific = Identificacao;
                }
            }

            public void compararLista(List<Pedidos.itemPedido> listaTemporaria,
                                      List<Pedidos.itemPedido> listaProdutos)
            {
                int produto = 0;
                int items = 0;
                if (listaTemporaria.Count > 0)
                {
                    while (produto < listaTemporaria.Count)
                    {
                        var item = listaProdutos.FirstOrDefault(i => i.codItem == listaTemporaria[produto].codItem);

                        if (item != null)
                        {
                            item.Quantidade = item.Quantidade + listaTemporaria[produto].Quantidade;
                            item.item = items++;

                        } else
                        {
                            listaProdutos.Add(new Pedidos.itemPedido
                            {
                                item = (items ++),
                                codPedido = Convert.ToInt32(listaTemporaria[produto].codPedido),
                                codItem = Convert.ToInt32(listaTemporaria[produto].codItem),
                                codIdentific = listaTemporaria[produto].codIdentific,
                                descricao = listaTemporaria[produto].descricao,
                                unidade = listaTemporaria[produto].unidade,
                                Quantidade = Convert.ToDouble(listaTemporaria[produto].Quantidade)

                            });
                        }
                            
                        produto++;
                    }                    
                }
            }

            public void movimentarProdutos(List<Pedidos.itemPedido> listaEntregar,
                                    List<Pedidos.itemPedido> listaEntregue)
            {
                int produto = 0;

                if (listaEntregue.Count > 0)
                {
                    while (produto < listaEntregue.Count)
                    {

                        var item = listaEntregar.FirstOrDefault(i => i.codItem == listaEntregue[produto].codItem);

                        if (item != null)
                        {
                            if (item.Quantidade == listaEntregue[produto].Quantidade)
                            {
                                listaEntregar.Remove(item);
                            }
                            else
                            {
                                if (item.Quantidade > listaEntregue[produto].Quantidade)
                                {
                                    item.Quantidade = item.Quantidade - listaEntregue[produto].Quantidade;
                                }
                            }
                        }

                        produto++;
                    }


                }

            }

        }

 
        public class dataEHora
        {
            public (DateTime PrimeiroDia, DateTime UltimoDia) ObterPrimeiroEUltimoDiaDoMes()
            {
                DateTime dataAtual = DateTime.Now;

                // Extrair o mês
                int mes = dataAtual.Month;

                // Extrair o ano
                int ano = dataAtual.Year;

                // Primeiro dia do mês
                DateTime primeiroDia = new DateTime(ano, mes, 1);

                // Último dia do mês
                DateTime ultimoDia = primeiroDia.AddMonths(1).AddDays(-1);

                return (primeiroDia, ultimoDia);
            }
        }
        public class Formatar
        {
            public void FormatarGrade(System.Windows.Forms.DataGridView grade,
                                      Dictionary<int, (string Titulo, int Largura, DataGridViewContentAlignment Alinhamento)> configuracaoColunas)
            {
                grade.Rows.Clear();

                // Configurando o estilo geral do DataGridView
                grade.EnableHeadersVisualStyles = false; // Permite personalizar o cabeçalho
                grade.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 8, FontStyle.Bold);
                grade.ColumnHeadersDefaultCellStyle.BackColor = Color.NavajoWhite;
                grade.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
                grade.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

                // Configurando as linhas
                grade.DefaultCellStyle.Font = new Font("Segoe UI", 8, FontStyle.Regular);
                grade.DefaultCellStyle.BackColor = Color.White;
                grade.DefaultCellStyle.ForeColor = Color.Black;

                // Configurando colunas com base no dicionário
                foreach (var colConfig in configuracaoColunas)
                {
                    int colunaIndex = colConfig.Key;
                    string titulo = colConfig.Value.Titulo;
                    int largura = colConfig.Value.Largura;
                    DataGridViewContentAlignment alinhamento = colConfig.Value.Alinhamento;

                    // Adiciona ou atualiza a configuração da coluna
                    if (colunaIndex < grade.Columns.Count)
                    {
                        grade.Columns[colunaIndex].HeaderText = titulo;
                        grade.Columns[colunaIndex].Width = largura;
                        grade.Columns[colunaIndex].DefaultCellStyle.Alignment = alinhamento;
                    }
                    else
                    {
                        // Adiciona uma nova coluna se não existir
                        DataGridViewColumn coluna = new DataGridViewTextBoxColumn
                        {
                            HeaderText = titulo,
                            Width = largura,
                            DefaultCellStyle = { Alignment = alinhamento }
                        };
                        grade.Columns.Add(coluna);
                    }
                }

                // Configurando a linha do título (cabeçalho)
                if (grade.Rows.Count > 0)
                {
                    grade.Rows[0].DefaultCellStyle.BackColor = Color.NavajoWhite;
                    grade.Rows[0].DefaultCellStyle.Font = new Font("Arial", 8, FontStyle.Bold);
                    grade.Rows[0].DefaultCellStyle.ForeColor = Color.Black;
                }

                // Configurando as linhas de dados (da linha 1 em diante)
                for (int i = 1; i < grade.Rows.Count; i++)
                {
                    grade.Rows[i].DefaultCellStyle.BackColor = Color.White;
                    grade.Rows[i].DefaultCellStyle.Font = new Font("Segoe UI", 8);
                    grade.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                }
            }

            public void PreencherGrade(
                                        DataGridView grade,
                                        List<Dictionary<int, object>> dados,
                                        Dictionary<int, (string Titulo, int Largura, DataGridViewContentAlignment Alinhamento)> configuracaoColunas)
            {
                // Configura o DataGridView usando a função já definida
                FormatarGrade(grade, configuracaoColunas);

                // Limpa linhas existentes antes de adicionar novas
                grade.Rows.Clear();

                // Adiciona os dados linha por linha
                foreach (var linha in dados)
                {
                    // Cria uma nova linha e preenche com os valores da lista
                    var novaLinha = new object[grade.Columns.Count];
                    foreach (var coluna in linha)
                    {
                        if (coluna.Key < grade.Columns.Count) // Certifica-se de que o índice é válido
                        {
                            novaLinha[coluna.Key] = coluna.Value;
                        }
                    }
                    grade.Rows.Add(novaLinha);
                }
            }
        }


        public string retornaVersao()
        {
                        
            var version = Assembly.GetExecutingAssembly().GetName().Version;

            return version.ToString();
        }


        public class Criptografia
        {
            private static readonly byte[] Key = Encoding.UTF8.GetBytes("AY2DExGHIzKLMNOJkPejutlOEMAOEoiX"); // Deve ter 16, 24 ou 32 bytes
            private static readonly byte[] IV = Encoding.UTF8.GetBytes("23GEJIRNDSKD234W"); // Deve ter 16 bytes

            public string Criptografar(string textoPlano)
            {
                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = Key;
                    aesAlg.IV = IV;

                    ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                    using (MemoryStream msEncrypt = new MemoryStream())
                    {
                        using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(textoPlano);
                        }

                        byte[] encrypted = msEncrypt.ToArray();
                        return Convert.ToBase64String(encrypted);
                    }
                }
            }

            public string Descriptografar(string textoCriptografado)
            {
                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = Key;
                    aesAlg.IV = IV;

                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                    using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(textoCriptografado)))
                    {
                        using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            public string ConverterArquivoParaBase64(string caminhoArquivo)
            {
                byte[] arquivoBytes = File.ReadAllBytes(caminhoArquivo);
                return Convert.ToBase64String(arquivoBytes);
            }

            public string ConverterBase64ParaArquivo(string base64String, string caminhoDestino)
            {
                if (File.Exists(caminhoDestino)) File.Delete(caminhoDestino);


                byte[] arquivoBytes = Convert.FromBase64String(base64String);
                File.WriteAllBytes(caminhoDestino, arquivoBytes);

                return caminhoDestino;

            }

            public string GerarHashMD5(string texto)
            {
                using (MD5 md5 = MD5.Create())
                {
                    byte[] inputBytes = Encoding.UTF8.GetBytes(texto);
                    byte[] hashBytes = md5.ComputeHash(inputBytes);

                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < hashBytes.Length; i++)
                    {
                        sb.Append(hashBytes[i].ToString("x2"));
                    }

                    return sb.ToString();
                }
            }

        }
    }

    public class xml
    {
        public string Ler_XML(string tag, int ocorrencia, string arquivo)
        {
            int num = 0;
            int num2 = 0;
            int length = 0;
            int num3 = 0;
            string text = string.Empty;
            string empty;
            try
            {
                empty = string.Empty;
                if (File.Exists(arquivo))
                {
                    StreamReader streamReader = new StreamReader(arquivo);
                    for (string text2 = streamReader.ReadLine(); text2 != null; text2 = streamReader.ReadLine())
                    {
                        text = text + text2 + '\r';
                    }
                    for (int i = 1; i <= ocorrencia; i++)
                    {
                        num = text.IndexOf("<" + tag + ">", num + 1);
                        num2 = text.IndexOf("</" + tag + ">", num2 + 1);
                        num3 = num + ("</" + tag + ">").Length;
                        length = num2 - (num + ("<" + tag + ">").Length);
                    }
                    empty = text.Substring(num3 - 1, length);
                    streamReader.Close();
                    return empty;
                }
            }
            catch
            {
                empty = string.Empty;
            }
            return empty;
        }

        public string Ler_XML_String(string tag, int ocorrencia, string linha)
        {

            string text = string.Empty;
            string empty;
            try
            {

                empty = string.Empty;
                int pontoInicial = 0;
                int pontoFinal = 0;
                int rodou = 0;

                //Verificar se a tag informada existe
                if (linha.Contains("<" + tag + ">"))
                {

                    while (ocorrencia > rodou)
                    {
                        if (pontoInicial > 0)
                        {
                            linha = linha.Substring(pontoFinal + ("</" + tag + ">").Length, linha.Length - (pontoFinal + ("</" + tag + ">").Length));

                        }

                        pontoInicial = linha.IndexOf("<" + tag + ">") + ("<" + tag + ">").Length;
                        pontoFinal = linha.IndexOf("</" + tag + ">");

                        empty = linha.Substring((pontoInicial), pontoFinal - pontoInicial);

                        rodou++;
                    }
                }
                else
                {
                    empty = string.Empty;
                }

            }
            catch
            {
                empty = string.Empty;
            }
            return empty;
        }

        public string Ler_XML_XmlNode(XmlNode notaFiscalNode, string tag, int ocorrencia = 1)
        {
            string empty = string.Empty;
            int count = 0;

            // Percorre os nós filhos do nó atual para encontrar a tag desejada
            foreach (XmlNode childNode in notaFiscalNode.ChildNodes)
            {
                if (childNode.Name.Equals(tag, StringComparison.OrdinalIgnoreCase))
                {
                    count++;

                    // Se for a ocorrência desejada, armazena o conteúdo
                    if (count == ocorrencia)
                    {
                        empty = childNode.InnerText;
                        break;
                    }
                }
            }

            return empty;
        }
    }
}
