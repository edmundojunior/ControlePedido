using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastReport;
using FastReport.Data;
using FastReport.Utils;
using System.Data.SqlClient;
using FastReport.Export.PdfSimple;
namespace ControlePedido
{
    public  class relFastReport
    {
        public Report report = new Report();

        public void relPedido()
        {

            BancoDeDados bcDados = new BancoDeDados();

            var bco = new BancoDeDados().lerXMLConfiguracao();

            report.Dictionary.Connections.Add(bcDados.conectarRelatiorio(bco));

            report.Load(@"C:\EDM\ControlePedido\Relatorio\Pedidos.frx");

            DataBand dataBand = report.FindObject("Data1") as DataBand;

            if (dataBand != null && dataBand.DataSource is TableDataSource table)
            {
                table.SelectCommand = @"select 
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
                                        Where PEDIDO.CD_STATUS IN (10,11)
                                        ORDER BY  PEDIDO.CD_CLIENTE, PEDIDO.CD_PEDIDO
                                        ";
            }

            // Se houver um segundo SELECT a ser modificado:
            DataBand dataBand2 = report.FindObject("Data2") as DataBand;
            if (dataBand2 != null && dataBand2.DataSource is TableDataSource table2)
            {
                table2.SelectCommand = @"select 
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
                                        Where PEDIDO.CD_STATUS IN (10,11)
                                        AND ITENSPEDIDO.CD_MATERIAL IS NOT NULL
                                        ORDER BY PEDIDO.CD_PEDIDO, PEDIDO.CD_CLIENTE, ITENSPEDIDO.CD_MATERIAL
                                        ";
            }

            report.Prepare();

            // Criar o exportador PDF simplificado
            PDFSimpleExport pdfExport = new PDFSimpleExport();

            // Definir o caminho do arquivo PDF de saída
            pdfExport.Export(report, @"C:\EDM\ControlePedido\Relatorio\Pedidos.pdf");
        }
    }
}
