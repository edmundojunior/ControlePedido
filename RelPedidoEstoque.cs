using DocumentFormat.OpenXml.Bibliography;
using System.Data.SqlClient;
using FastReport;
using FastReport.Data;
using FastReport.Export.PdfSimple;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ControlePedido.Impressao;
using System.Data;
using DocumentFormat.OpenXml.Office2010.PowerPoint;
using iText.StyledXmlParser.Jsoup.Nodes;
using Microsoft.Data;
using Microsoft.Data.SqlClient;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Element = iTextSharp.text.Element;
using Document = iTextSharp.text.Document;
using DocumentFormat.OpenXml.Spreadsheet;
using Font = iTextSharp.text.Font;
using PdfSharp.Pdf;
using System.Windows.Media.Media3D;
using System.Security.RightsManagement;
using Org.BouncyCastle.Asn1;
using SqlCommand = Microsoft.Data.SqlClient.SqlCommand;
using SqlDataAdapter = Microsoft.Data.SqlClient.SqlDataAdapter;
using SqlConnection = System.Data.SqlClient.SqlConnection;

namespace ControlePedido
{
    public class RelPedidoEstoque
    {
        
        public BancoDeDados bcdDados = new BancoDeDados();
        public MsSqlDataConnection conexao = new MsSqlDataConnection();
        public Util caminho = new Util();

        public class Pedido
        {
            public string cd_pedido { get; set; }
            public string cd_cliente { get; set; }
            public string ds_cliente { get; set; }
            public DateTime? dt_emissao {  get; set; }
            public DateTime? dt_entrega { get; set; }
            public List<Item> Itens { get; set; }


        }

        public class Item
        {
            public string cd_pedido { get; set; }
            public string cd_filial { get; set; }
            public string cd_material { get; set; }
            public string ds_material { get; set; }

            public double nr_qtdepedida { get; set; }
            public double nr_emseparacao { get; set; }
            public double nr_separado { get; set; }

        }



        public void GerarRelatorio()
        {
            string relPedidos = caminho.retornaCaminhoRelatorioPadrao(@"Relatorio\PedidoVenda.frx");
            string arqPedidosPdf = caminho.retornaCaminhoRelatorioPadrao(@"Relatorio\RelatorioPedidos.PDF");

            DataTable dt = new DataTable();
            var bco = new BancoDeDados().lerXMLConfiguracao();
            

            string sqlPedido = @"select 
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
                                Where PEDIDO.CD_STATUS IN (1,10,11)
                                ORDER BY  PEDIDO.CD_CLIENTE, PEDIDO.CD_PEDIDO
                                ";

                try
            {
                //using (SqlConnection cnn = new BancoDeDados().conectar(bco))
                //{
                //    if (cnn != null)
                //    {
                //        using (SqlCommand comando = new SqlCommand(sqlPedido, cnn))
                //        {
                //            comando.CommandTimeout = 120; // Timeout aumentado
                //                                          // Executa o comando e preenche o DataTable
                //            using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                //            {
                //                adaptador.Fill(dt);
                //            }
                //        }
                //    }

                //    if (cnn.State == ConnectionState.Open) bco.desconectar(cnn);
                //}
            }
            catch (Exception ex)
            {

                dt = null;
                MessageBox.Show($"Não foi possível acessar a tabela de PRODUTO\n [ {ex.Message} ]", "Aviso Importante");

            }


            string sqlItens = @"select 
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
                                Where PEDIDO.CD_STATUS IN (1,10,11)
                                AND ITENSPEDIDO.CD_MATERIAL IS NOT NULL
                                ORDER BY PEDIDO.CD_PEDIDO, PEDIDO.CD_CLIENTE, ITENSPEDIDO.CD_MATERIAL
                                ";


            


            
        }


        

    }
}
