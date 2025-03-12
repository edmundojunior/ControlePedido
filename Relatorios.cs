using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using FastReport;
using FastReport.Export.PdfSimple;
using FastReport.Data;
using FastReport.Utils;



namespace ControlePedido
{
    public class Relatorios
    {
        Util caminho = new Util();

        
        public void imprimir(Dictionary<string, object> filtros = null, Dictionary<string, object> filtrosItens = null, bool estoque = false, bool dtemissao = true)
        {

            BancoDeDados dadosBanco = new BancoDeDados();


            DataTable retornoPedido = new DataTable();
            DataTable retornoItens = new DataTable();
            var bco = new BancoDeDados().lerXMLConfiguracao();

            Report report = new Report();

            string relPedidos = caminho.retornaCaminhoRelatorioPadrao(@"Relatorio\Pedidos.frx");
            string relestoque = caminho.retornaCaminhoRelatorioPadrao(@"Relatorio\Estoque.frx");
            string arqPedidosPdf = caminho.retornaCaminhoRelatorioPadrao(@"Relatorio\RelatorioPedidos_" + DateTime.Now.ToString("ddMMyyyy_HHmmss"));
            string arqestoquePdf = caminho.retornaCaminhoRelatorioPadrao(@"Relatorio\RelatorioEstoque_" + DateTime.Now.ToString("ddMMyyyy_HHmmss"));

            var sql = sqlPedidoEItens(filtros, filtrosItens, dtemissao);

            string sqlPedido = sql.Item1;
            string sqlItens = sql.Item2;


            if (estoque)
            {

            }else
            {

                using (SqlConnection cnn = new BancoDeDados().conectar(bco))
                {
                    if (cnn != null)
                    {
                        using (SqlCommand comando = new SqlCommand(sqlPedido, cnn))
                        {
                            using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                            {
                                adaptador.Fill(retornoPedido);
                            }
                        }
                    }
                }

                using (SqlConnection cnn = new BancoDeDados().conectar(bco))
                {
                    if (cnn != null)
                    {
                        using (SqlCommand comando = new SqlCommand(sqlItens, cnn))
                        {
                            using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                            {
                                adaptador.Fill(retornoItens);
                            }
                        }
                    }
                    
                }

                MsSqlDataConnection sqlConnection = new MsSqlDataConnection
                {
                    ConnectionString = dadosBanco.connectionString(bco)
                };

                sqlConnection.CreateAllTables();
                // Adicionar a conexão ao relatório
                report.Dictionary.Connections.Add(sqlConnection);


                if (!File.Exists(relPedidos))
                {
                    MessageBox.Show("Arquivo de relatório não encontrado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                report.Load(relPedidos);

                report.RegisterData(retornoPedido, "Pedido");
                report.RegisterData(retornoItens, "Itens");

                DataBand dataBandPedidos = report.FindObject("DataBandPedidos") as DataBand;
                if (dataBandPedidos != null)
                    dataBandPedidos.DataSource = report.GetDataSource("Pedido");

                DataBand dataBandItens = report.FindObject("DataBandItens") as DataBand;
                if (dataBandItens != null)
                    dataBandItens.DataSource = report.GetDataSource("Itens");

                // 6️⃣ Preparar e Exibir o Relatório
                report.Prepare();

                using (PDFSimpleExport export = new PDFSimpleExport())
                {
                    report.Export(export, arqPedidosPdf);
                }

                frmExibirRelatorio frm = new frmExibirRelatorio(arqPedidosPdf);
                frm.ShowDialog();

                report.Dictionary.Connections.Clear();
            }

        }

        public (string, string) sqlPedidoEItens(Dictionary<string, object> filtros = null
                                                , Dictionary<string, object> filtrosItens = null
                                                , bool dtemissao = true)
        {
            string retornoPedido = string.Empty;
            string retornoItens = string.Empty;
            string pedidos = string.Empty;

            

            var bco = new BancoDeDados().lerXMLConfiguracao();

            DataTable retornado = new DataTable();

            try
            {
                retornoPedido = @"select 
                                    PEDIDO.CD_PEDIDO
                                    , PEDIDO.CD_EMPRESA
                                    , EMPRESA.DS_EMPRESA
                                    , PEDIDO.CD_FILIAL
                                    , FILIAL.DS_FILIAL
                                    , CLIENTE.CD_ENTIDADE
                                    , CLIENTE.DS_ENTIDADE
                                    , CLIENTE.CD_REGIAO
                                    , CLIENTE.CD_CIDADE
                                    , CIDADE.DS_UF
                                    , PEDIDO.DT_EMISSAO
                                    , PEDIDO.DT_ENTREGA
                                    , PEDIDO.CD_TIPO_PEDIDO
                                    , PEDIDO.CD_CARTEIRA
                                    , PEDIDO.CD_FORMA_PAGAMENTO
                                    , CLIENTE.CD_CLASSIFICACAO
                                    , PEDIDO.CD_VENDEDOR
                                    , PEDIDO.CD_OBRA
                                    , PEDIDO.CD_TRANSPORTADOR
                                    , PEDIDO.CD_FRETE
                                    from TBL_PEDIDOS PEDIDO
                                    LEFT JOIN  TBL_EMPRESAS EMPRESA 
                                    ON EMPRESA.CD_EMPRESA = PEDIDO.CD_EMPRESA
                                    LEFT JOIN TBL_EMPRESAS_FILIAIS FILIAL
                                    ON FILIAL.CD_FILIAL = PEDIDO.CD_FILIAL
                                    LEFT JOIN TBL_ENTIDADES CLIENTE
                                    ON CLIENTE.CD_ENTIDADE = PEDIDO.CD_CLIENTE
                                    AND CLIENTE.X_CLIENTE = 1
                                    LEFT JOIN TBL_ENDERECO_CIDADES CIDADE
                                    ON CIDADE.CD_CIDADE = CLIENTE.CD_CIDADE                                    
                                    ORDER BY  PEDIDO.CD_CLIENTE, PEDIDO.CD_PEDIDO
                                ";

                                             

                if (filtros != null && filtros.Count > 0) {

                    foreach (var filtro in filtros)
                    {
                        string chave = filtro.Key;
                        object valor = filtro.Value;


                        if (chave == "DataInicio")
                        {
                            if (retornoPedido.Contains("WHERE"))
                            {
                                retornoPedido += " AND ";
                            }
                            else retornoPedido += " WHERE ";

                            if (dtemissao)
                            {
                                retornoPedido += " PEDIDO.DT_EMISSAO BETWEEN ";
                            }
                            else
                            {
                                retornoPedido += " PEDIDO.DT_ENTREGA BETWEEN ";
                            }

                            if (valor is DateTime data)
                            {
                                retornoPedido += ($"'{data:dd-MM-yyyy}'");
                            }

                        }
                        else if (chave == "DataFim")
                        {

                            if (valor is DateTime data)
                            {
                                retornoPedido += ($" AND '{data:dd-MM-yyyy}'");
                            }
                        }
                        else
                        {
                        if (retornoPedido.Contains("WHERE"))
                            {
                                retornoPedido += " AND ";
                            }
                            else retornoPedido += " WHERE ";

                            retornoPedido += chave + " LIKE  '" + valor + "'";
                        }

                    }

                }             

                using (SqlConnection cnn = new BancoDeDados().conectar(bco))
                {
                    if (cnn != null)
                    {
                        using (SqlCommand comando = new SqlCommand(retornoPedido, cnn))
                        {
                            comando.CommandTimeout = 120; // Timeout aumentado
                                                          // Executa o comando e preenche o DataTable
                            using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                            {
                                adaptador.Fill(retornado);
                            }
                        }
                    }

                    if (cnn.State == ConnectionState.Open) bco.desconectar(cnn);
                }

                foreach (DataRow row in retornado.Rows)
                {
                    if (!string.IsNullOrEmpty(pedidos))
                        pedidos += ","; // Adiciona a vírgula antes dos próximos valores

                    pedidos += row["CD_PEDIDO"].ToString();
                }

                retornoItens = String.Format(@"select 
                                                PEDIDO.CD_PEDIDO
                                                , ITENSPEDIDO.CD_MATERIAL
                                                , MATERIAIS.DS_MATERIAL
                                                , MATERIAIS.CD_MARCA
                                                , MATERIAIS.CD_SUBGRUPO
                                                , MATERIAIS.CD_TIPO_EMBALAGEM
                                                , MATERIAIS.CD_FORNECEDOR
                                                , MATERIAIS.CD_TIPO
                                                , ITENSPEDIDO.NR_QUANTIDADE AS QUANTPEDIDA
                                                , IIF(CONTROLEENTREGA.NR_QUANTIDADE IS NULL, 0 , CONTROLEENTREGA.NR_QUANTIDADE)  AS EMSEPARACAO
                                                , IIF(CONTROLEENTREGA2.NR_QUANTIDADE IS NULL , 0 , CONTROLEENTREGA2.NR_QUANTIDADE) AS SEPARADO
                                                from TBL_PEDIDOS PEDIDO
                                                LEFT JOIN TBL_PEDIDOS_ITENS ITENSPEDIDO ON
                                                ITENSPEDIDO.CD_PEDIDO = PEDIDO.CD_PEDIDO
                                                LEFT JOIN TBL_MATERIAIS MATERIAIS ON 
                                                MATERIAIS.CD_MATERIAL = ITENSPEDIDO.CD_MATERIAL
                                                LEFT JOIN TBL_PEDIDOS_ITENS_CONTROLE_ENTREGA CONTROLEENTREGA
                                                ON CONTROLEENTREGA.CD_PEDIDO = PEDIDO.CD_PEDIDO
                                                AND CONTROLEENTREGA.CD_MATERIAL = ITENSPEDIDO.CD_MATERIAL
                                                AND CONTROLEENTREGA.X_ENTREGUE = 0
                                                LEFT JOIN TBL_PEDIDOS_ITENS_CONTROLE_ENTREGA CONTROLEENTREGA2
                                                ON CONTROLEENTREGA2.CD_PEDIDO = PEDIDO.CD_PEDIDO
                                                AND CONTROLEENTREGA2.CD_MATERIAL = ITENSPEDIDO.CD_MATERIAL
                                                AND CONTROLEENTREGA2.X_ENTREGUE = 1
                                                Where PEDIDO.CD_PEDIDO IN ({0})
                                                AND ITENSPEDIDO.CD_MATERIAL IS NOT NULL
                                                ORDER BY PEDIDO.CD_PEDIDO, PEDIDO.CD_CLIENTE, ITENSPEDIDO.CD_MATERIAL
                                ", pedidos);


                if (filtrosItens != null && filtrosItens.Count > 0)
                {

                    foreach (var filtro in filtros)
                    {
                        string chave = filtro.Key;
                        object valor = filtro.Value;


                        if (chave == "DataInicio")
                        {
                            if (retornoItens.Contains("WHERE"))
                            {
                                retornoItens += " AND ";
                            }
                            else retornoItens += " WHERE ";

                            if (dtemissao)
                            {
                                retornoItens += " PEDIDO.DT_EMISSAO BETWEEN ";
                            }
                            else
                            {
                                retornoItens += " PEDIDO.DT_ENTREGA BETWEEN ";
                            }

                            if (valor is DateTime data)
                            {
                                retornoItens += ($"'{data:dd-MM-yyyy}'");
                            }

                        }
                        else if (chave == "DataFim")
                        {

                            if (valor is DateTime data)
                            {
                                retornoItens += ($" AND '{data:dd-MM-yyyy}'");
                            }
                        }
                        else
                        {
                            if (retornoItens.Contains("WHERE"))
                            {
                                retornoItens += " AND ";
                            }
                            else retornoItens += " WHERE ";

                            retornoItens += chave + " LIKE  '" + valor + "'";
                        }

                    }

                }

                

                using (SqlConnection cnn = new BancoDeDados().conectar(bco))
                {
                    if (cnn != null)
                    {
                        using (SqlCommand comando = new SqlCommand(retornoItens, cnn))
                        {
                            comando.CommandTimeout = 120; // Timeout aumentado
                                                          // Executa o comando e preenche o DataTable
                            using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                            {
                                adaptador.Fill(retornado);
                            }
                        }
                    }

                    if (cnn.State == ConnectionState.Open) bco.desconectar(cnn);
                }

                if (retornado.Rows.Count < 0)
                {
                    retornoPedido = null;
                    retornoItens = null;
                }


            }
            catch (Exception ex)
            {
                retornoPedido = null;
                retornoItens = null;

                MessageBox.Show("Gerando SQL Pedidos/Itens\n" + ex.Message, "Aviso Importante");

            }

            return (retornoPedido, retornoItens);
        }

        public string sqlEstoque(Dictionary<string, object> filtros = null)
        {
            string retorno = string.Empty;

            try
            {

            }
            catch (Exception ex)
            {
                retorno = null;
                

                MessageBox.Show("Gerando SQL Estoque\n" + ex.Message, "Aviso Importante");

            }

            return retorno;
        }

        


    }
}
