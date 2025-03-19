using DocumentFormat.OpenXml.Office2010.PowerPoint;
using iText.StyledXmlParser.Jsoup.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Element = iTextSharp.text.Element;
using Document = iTextSharp.text.Document;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Spreadsheet;
using Font = iTextSharp.text.Font;
using static ControlePedido.Impressao;
using PdfSharp.Pdf;
using System.Windows.Media.Media3D;
using System.Security.RightsManagement;

namespace ControlePedido
{
    public class Impressao
    {

        Estoque estoque = new Estoque();

        public string periodo_relatorio = string.Empty;
        public class Pedido
        {
            public int codPedido { get; set; } = 0;
            public int codEmpresa { get; set; } = 0;
            public string Empresa { get; set; } = null;
            public int codFilial { get; set; } = 0;
            public string Filial { get; set; } = null;
            public int codCliente { get; set; } = 0;
            public string Cliente { get; set; } = null;
            public DateTime dt_Emissao { get; set; } = DateTime.Now;
            public DateTime dt_entrega { get; set; } = DateTime.Now;
        }

        public class Itens
        {
            public int codPedido { get; set; } = 0;
            public int codFilial { get; set; } = 0;
            public int codProduto { get; set; } = 0;
            public string descricaoProduto { get; set; } = null;
            public double quantidade { get; set; } = 0;

            public double emseparacao { get; set; } = 0;
            public double separado { get; set; } = 0;

        }
       

        public void impressaoRelEstoque(List<Estoque> listaEstoque, DateTime dtInicial, DateTime dtFinal)
        {
            if (listaEstoque == null)
            {
                return;
            }

            try
            {



                CustomHeaderFooterEstoque headerFooter = new CustomHeaderFooterEstoque()
                {

                    PeriodoRelatorio = $"Período: {dtInicial.ToString("dd/MM/yyyy")} à {dtFinal.ToString("dd/MM/yyyy")} "

                };


                Document doc = new Document(PageSize.A4, 50, 50, 80, 50); // Ajuste das margens
                string caminhoPDF = Path.Combine(Directory.GetCurrentDirectory(), "Relatorio_Pedidos") + DateTime.Now.ToString("ddMMyyyyhhmmss") + ".pdf";
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(caminhoPDF, FileMode.Create));

                writer.PageEvent = headerFooter; 


                doc.Open();


                Font fonteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 6, BaseColor.BLACK);
                Font fonteNormal = FontFactory.GetFont(FontFactory.HELVETICA, 6, BaseColor.BLACK);
                Font fonteNegrito = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 6, BaseColor.BLACK);
                PdfPTable tabelaEstoque = new PdfPTable(8);
                tabelaEstoque.WidthPercentage = 100;
                tabelaEstoque.SetWidths(new float[] { 3f, 15, 6f, 3f, 3f, 3f, 3f, 3f });

                foreach (var lista in listaEstoque)
                {                    

                    tabelaEstoque.AddCell(new PdfPCell(new Phrase(lista.Produto.ToString(), fonteNormal))
                    {
                        HorizontalAlignment = Element.ALIGN_RIGHT,
                        Border = Rectangle.NO_BORDER
                    });

                    tabelaEstoque.AddCell(new PdfPCell(new Phrase(lista.DescricaoProduto, fonteNormal))
                    {
                        Border = Rectangle.NO_BORDER
                    });

                    tabelaEstoque.AddCell(new PdfPCell(new Phrase(lista.CodIdentificao.ToString(), fonteNormal))
                    {
                        HorizontalAlignment = Element.ALIGN_RIGHT,
                        Border = Rectangle.NO_BORDER
                    });

                    tabelaEstoque.AddCell(new PdfPCell(new Phrase(lista.Pedidos.ToString("N3"), fonteNormal))
                    {
                        HorizontalAlignment = Element.ALIGN_RIGHT,
                        Border = Rectangle.NO_BORDER
                    });


                    tabelaEstoque.AddCell(new PdfPCell(new Phrase((lista.EstoqueAtual - (lista.EmSeparacao + lista.EmSeparacao)).ToString("N3"), fonteNormal))
                    {
                        HorizontalAlignment = Element.ALIGN_RIGHT,
                        Border = Rectangle.NO_BORDER
                    });

                    tabelaEstoque.AddCell(new PdfPCell(new Phrase(lista.EmSeparacao.ToString("N3"), fonteNormal))
                    {
                        HorizontalAlignment = Element.ALIGN_RIGHT,
                        Border = Rectangle.NO_BORDER
                    });

                    tabelaEstoque.AddCell(new PdfPCell(new Phrase(lista.Separado.ToString("N3"), fonteNormal))
                    {
                        HorizontalAlignment = Element.ALIGN_RIGHT,
                        Border = Rectangle.NO_BORDER
                    });

                    tabelaEstoque.AddCell(new PdfPCell(new Phrase((lista.EstoqueAtual + lista.Pedidos).ToString("N3"), fonteNegrito))
                    {
                        HorizontalAlignment = Element.ALIGN_RIGHT,
                        Border = Rectangle.NO_BORDER
                    });

                }

                doc.Add(tabelaEstoque);

                doc.Close();

                Cursor.Current = Cursors.Default;

                frmExibirRelatorio frm = new frmExibirRelatorio(caminhoPDF);
                frm.ShowDialog();



            } catch (Exception ex) {

                MessageBox.Show(ex.Message, "[RELATORIO ESTOQUE] - Aviso Importante");
                return;
            }
        }

        public void impressaoRelatorio(List<Pedido> listaPedido, List<Itens> ListaItem, DateTime dtInicial, DateTime dtFinal)
        {

            if (listaPedido == null)
            {
                return;
            }
            
            try
            {

                 

                CustomHeaderFooter headerFooter = new CustomHeaderFooter
                {
                    empresa_sendo_usada = listaPedido[0].Empresa,
                    PeriodoRelatorio = $"Período: {dtInicial.ToString("dd/MM/yyyy")} à {dtFinal.ToString("dd/MM/yyyy")}"
                };


                Document doc = new Document(PageSize.A4, 50, 50, 80, 50); // Ajuste das margens
                string caminhoPDF = Path.Combine(Directory.GetCurrentDirectory(), "Relatorio_Pedidos")  + DateTime.Now.ToString("ddMMyyyyhhmmss") + ".pdf";
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(caminhoPDF, FileMode.Create));


                // Adicionar evento para cabeçalho e rodapé
                //writer.PageEvent = new CustomHeaderFooter();
                writer.PageEvent = headerFooter;


                doc.Open();
               

                Font fonteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8, BaseColor.BLACK);
                Font fonteNormal = FontFactory.GetFont(FontFactory.HELVETICA, 7, BaseColor.BLACK);
                Font fonteNegrito = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 7, BaseColor.BLACK);

                
                

                foreach (Pedido capaPedido in listaPedido)
                {
                    doc.Add(new Paragraph("\n")); // Três linhas em branco

                    int pedidoId = capaPedido.codPedido;
                    string cliente = capaPedido.codCliente + " - " +  capaPedido.Cliente;
                    DateTime dataPedido = capaPedido.dt_Emissao;
                    DateTime dataEntrega = capaPedido.dt_entrega;

                    // Adicionar cabeçalho do pedido
                    //doc.Add(new Paragraph($"Pedido Nº: {pedidoId}", fonteTitulo));
                    doc.Add(new Paragraph($"Cliente: {cliente} " , fonteNormal));
                    doc.Add(new Paragraph($"Data do Pedido: {dataPedido:dd/MM/yyyy}  Data do Entrega: {dataEntrega:dd/MM/yyyy}", fonteNormal));
                    //doc.Add(new Paragraph(" "));

                    // Criar tabela para os itens do pedido
                    PdfPTable tabela = new PdfPTable(6);
                    tabela.WidthPercentage = 100;
                    tabela.SetWidths(new float[] { 2f, 3f, 10f, 5f, 5f, 5f });

                    tabela.AddCell(new PdfPCell(new Phrase("Filial", fonteNegrito))                    {
                        
                        Border = Rectangle.NO_BORDER
                    });

                    tabela.AddCell(new PdfPCell(new Phrase("Pedido", fonteNegrito))
                    {

                        Border = Rectangle.NO_BORDER
                    });

                    tabela.AddCell(new PdfPCell(new Phrase("Produto", fonteNegrito))
                    {

                        Border = Rectangle.NO_BORDER
                    });

                    tabela.AddCell(new PdfPCell(new Phrase("Qt.Pedido", fonteNegrito))
                    {
                        HorizontalAlignment = Element.ALIGN_RIGHT,
                        Border = Rectangle.NO_BORDER
                    });

                    tabela.AddCell(new PdfPCell(new Phrase("Em Separação", fonteNegrito))
                    {
                        HorizontalAlignment = Element.ALIGN_RIGHT,
                        Border = Rectangle.NO_BORDER
                    });

                    tabela.AddCell(new PdfPCell(new Phrase("Separado", fonteNegrito))
                    {
                        HorizontalAlignment = Element.ALIGN_RIGHT,
                        Border = Rectangle.NO_BORDER
                    });

                    
                    var resultados = ListaItem.Where(x => x.codPedido == capaPedido.codPedido).ToList();

                    foreach (Itens itensDoPedido in resultados)
                    {


                        tabela.AddCell(new PdfPCell(new Phrase(itensDoPedido.codFilial.ToString(), fonteNormal))
                        {

                            Border = Rectangle.NO_BORDER
                        });
                        tabela.AddCell(new PdfPCell(new Phrase(itensDoPedido.codPedido.ToString(), fonteNormal))
                        {

                            Border = Rectangle.NO_BORDER
                        });
                        tabela.AddCell(new PdfPCell(new Phrase(itensDoPedido.codProduto.ToString() + " " + itensDoPedido.descricaoProduto, fonteNormal))
                        {

                            Border = Rectangle.NO_BORDER
                        });
                        tabela.AddCell(new PdfPCell(new Phrase(itensDoPedido.quantidade.ToString("N4"), fonteNormal))
                        {
                            HorizontalAlignment = Element.ALIGN_RIGHT,
                            Border = Rectangle.NO_BORDER
                        });
                        tabela.AddCell(new PdfPCell(new Phrase(itensDoPedido.emseparacao.ToString("N4"), fonteNormal))
                        {
                            HorizontalAlignment = Element.ALIGN_RIGHT,
                            Border = Rectangle.NO_BORDER
                        });
                        tabela.AddCell(new PdfPCell(new Phrase(itensDoPedido.separado.ToString("N4"), fonteNormal))
                        {
                            HorizontalAlignment = Element.ALIGN_RIGHT,
                            Border = Rectangle.NO_BORDER
                        });
                        

                    }

                    doc.Add(tabela);
                }
                
                doc.Close();

                Cursor.Current = Cursors.Default;
                
                frmExibirRelatorio frm = new frmExibirRelatorio(caminhoPDF);             frm.ShowDialog();

                
                
            }
            catch (Exception ex) {

                MessageBox.Show(ex.Message, "[Gerando Relatorio] - Aviso Importante");

            }
        }

        
        public (List<Pedido>, List<Itens>) RetornarListas(Dictionary<string, object> filtroPedido, Dictionary<string, object> filtrosItens, bool dtemissao = true )
        {
            
            List<Pedido> listaPedido = new List<Pedido>();
            List<Itens> listaItens = new List<Itens>();

            string pedidosListados = string.Empty;

            DataTable retornado = new DataTable();
            DataTable retornadoItens = new DataTable();

            var bco = new BancoDeDados().lerXMLConfiguracao();

            try
            {


                //Criar SQL
                // - Peiddo
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
                                    left join TBL_PEDIDOS_ITENS I ON
                                    I.CD_PEDIDO = PEDIDO.CD_PEDIDO
                                    LEFT JOIN  TBL_EMPRESAS EMPRESA 
                                    ON EMPRESA.CD_EMPRESA = PEDIDO.CD_EMPRESA
                                    LEFT JOIN TBL_EMPRESAS_FILIAIS FILIAL
                                    ON FILIAL.CD_FILIAL = PEDIDO.CD_FILIAL
                                    LEFT JOIN TBL_ENTIDADES CLIENTE
                                    ON CLIENTE.CD_ENTIDADE = PEDIDO.CD_CLIENTE
                                    AND CLIENTE.X_CLIENTE = 1
                                    LEFT JOIN TBL_ENDERECO_CIDADES CIDADE
                                    ON CIDADE.CD_CIDADE = CLIENTE.CD_CIDADE                                   
                                ";


                if (filtroPedido != null && filtroPedido.Count > 0)
                {

                    foreach (var filtro in filtroPedido)
                    {
                        string chave = filtro.Key;
                        object valor = filtro.Value;


                        if (chave == "DataInicio")
                        {
                            if (sqlPedido.Contains("WHERE"))
                            {
                                sqlPedido += " AND ";
                            }
                            else sqlPedido += " WHERE ";

                            if (dtemissao)
                            {
                                sqlPedido += " PEDIDO.DT_EMISSAO BETWEEN ";
                            }
                            else
                            {
                                sqlPedido += " PEDIDO.DT_ENTREGA BETWEEN ";
                            }

                            if (Convert.ToDateTime(valor) is DateTime data)
                            {
                                sqlPedido += ($"'{data:dd-MM-yyyy}'");
                            }

                        }
                        else if (chave == "DataFim")
                        {

                            if (Convert.ToDateTime(valor) is DateTime data)
                            {
                                sqlPedido += ($" AND '{data:dd-MM-yyyy}'");
                            }
                        }
                        else
                        {
                            if (sqlPedido.Contains("WHERE"))
                            {
                                sqlPedido += " AND ";
                            }
                            else sqlPedido += " WHERE ";


                            if (chave.Contains("CD_FILIAL"))
                            {
                                sqlPedido += chave + " IN  (" + valor + ")";
                            }
                            else
                            {
                                sqlPedido += chave + " LIKE  '" + valor + "'";
                            }
                            
                        }

                    }

                }
                // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
                sqlPedido += @" GROUP BY PEDIDO.CD_PEDIDO
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
                                , PEDIDO.CD_FRETE";

                sqlPedido += " ORDER BY  CLIENTE.CD_ENTIDADE, PEDIDO.CD_PEDIDO";

                //Itens
                string sqlItens = @"select 
                                    PEDIDO.CD_PEDIDO
                                    ,PEDIDO.CD_FILIAL
                                    , ITENSPEDIDO.CD_MATERIAL
                                    , MATERIAIS.DS_MATERIAL
                                    , MATERIAIS.CD_MARCA
                                    , MATERIAIS.CD_SUBGRUPO
                                    , MATERIAIS.CD_TIPO_EMBALAGEM
                                    , MATERIAIS.CD_FORNECEDOR
                                    , MATERIAIS.CD_TIPO
                                    , SUM(ITENSPEDIDO.NR_QUANTIDADE) AS QUANTPEDIDA
                                    , SUM(IIF(PEDIDO.CD_STATUS = 10,(IIF(CONTROLEENTREGA.NR_QUANTIDADE IS NULL, 0 , CONTROLEENTREGA.NR_QUANTIDADE)) ,0)) AS EMSEPARACAO                               
                                    , SUM(IIF(PEDIDO.CD_STATUS = 11,(IIF(CONTROLEENTREGA2.NR_QUANTIDADE IS NULL, 0 , CONTROLEENTREGA2.NR_QUANTIDADE)) ,0)) AS SEPARADO
                                    from TBL_PEDIDOS PEDIDO
                                    LEFT JOIN TBL_PEDIDOS_ITENS ITENSPEDIDO ON
                                    ITENSPEDIDO.CD_PEDIDO = PEDIDO.CD_PEDIDO
                                    LEFT JOIN TBL_MATERIAIS MATERIAIS ON 
                                    MATERIAIS.CD_MATERIAL = ITENSPEDIDO.CD_MATERIAL
                                    LEFT JOIN TBL_PEDIDOS_ITENS_CONTROLE_ENTREGA CONTROLEENTREGA
                                    ON CONTROLEENTREGA.CD_PEDIDO = PEDIDO.CD_PEDIDO
                                    AND CONTROLEENTREGA.CD_MATERIAL = ITENSPEDIDO.CD_MATERIAL
                                    AND CONTROLEENTREGA.X_ENTREGUE = 1
                                    LEFT JOIN TBL_PEDIDOS_ITENS_CONTROLE_ENTREGA CONTROLEENTREGA2
                                    ON CONTROLEENTREGA2.CD_PEDIDO = PEDIDO.CD_PEDIDO
                                    AND CONTROLEENTREGA2.CD_MATERIAL = ITENSPEDIDO.CD_MATERIAL
                                    AND CONTROLEENTREGA2.X_ENTREGUE = 1								
                                    LEFT JOIN TBL_EMPRESAS_FILIAIS FILIAL
                                    ON FILIAL.CD_FILIAL = PEDIDO.CD_FILIAL
                                    WHERE  ITENSPEDIDO.CD_MATERIAL IS NOT NULL
                                 ";

                if (filtrosItens != null && filtrosItens.Count > 0)
                {

                    foreach (var filtro in filtrosItens)
                    {
                        string chave = filtro.Key;
                        object valor = filtro.Value;

                        if (chave == "DataInicio")
                        {
                            if (sqlItens.Contains("WHERE"))
                            {
                                sqlItens += " AND ";
                            }
                            else sqlItens += " WHERE ";

                            if (dtemissao)
                            {
                                sqlItens += " PEDIDO.DT_EMISSAO BETWEEN ";
                            }
                            else
                            {
                                sqlItens += " PEDIDO.DT_ENTREGA BETWEEN ";
                            }

                            if (Convert.ToDateTime(valor) is DateTime data)
                            {
                                sqlItens += ($"'{data:dd-MM-yyyy}'");
                            }

                        }
                        else if (chave == "DataFim")
                        {

                            if (Convert.ToDateTime(valor) is DateTime data)
                            {
                                sqlItens += ($" AND '{data:dd-MM-yyyy}'");
                            }
                        }else
                        {
                            if (sqlItens.Contains("WHERE"))
                            {
                                sqlItens += " AND ";
                            }
                            else sqlItens += " WHERE ";

                            if (chave.Contains("CD_FILIAL"))
                            {
                                sqlItens += chave + " IN  (" + valor + ")";
                            }
                            else {
                                sqlItens += chave + " LIKE  '" + valor + "'";
                            }
                            
                        }

                        
                        

                    }

                }

                // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

                try
                {

                    using (SqlConnection cnn = new BancoDeDados().conectar(bco))
                    {
                        if (cnn != null)
                        {
                            using (SqlCommand comando = new SqlCommand(sqlPedido, cnn))
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

                    if (retornado.Rows.Count > 0)
                    {

                        foreach (DataRow row in retornado.Rows)
                        {

                            listaPedido.Add(new Pedido
                            {
                                codPedido = Convert.ToInt32(row["CD_PEDIDO"]),
                                codEmpresa = Convert.ToInt32(row["CD_EMPRESA"]),
                                Empresa = row["DS_EMPRESA"].ToString(),
                                codFilial = Convert.ToInt32(row["CD_FILIAL"]),
                                Filial = row["DS_FILIAL"].ToString(),
                                codCliente = Convert.ToInt32(row["CD_ENTIDADE"]),
                                Cliente = row["DS_ENTIDADE"].ToString(),
                                dt_Emissao = Convert.ToDateTime(row["DT_EMISSAO"]),
                                dt_entrega = Convert.ToDateTime(row["DT_ENTREGA"])
                            }
                            );


                            if (!string.IsNullOrEmpty(pedidosListados))
                                pedidosListados += ","; // Adiciona a vírgula antes dos próximos valores

                            pedidosListados += row["CD_PEDIDO"].ToString();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Não foi encontrado nenhuma informação de acordo com o filtro selecioando!");
                        return (null, null);
                    }


                    sqlItens += @"GROUP BY PEDIDO.CD_PEDIDO
                                    ,PEDIDO.CD_FILIAL
                                    , ITENSPEDIDO.CD_MATERIAL
                                    , MATERIAIS.DS_MATERIAL
                                    , MATERIAIS.CD_MARCA
                                    , MATERIAIS.CD_SUBGRUPO
                                    , MATERIAIS.CD_TIPO_EMBALAGEM
                                    , MATERIAIS.CD_FORNECEDOR
                                    , MATERIAIS.CD_TIPO";

                    sqlItens += " ORDER BY PEDIDO.CD_PEDIDO, ITENSPEDIDO.CD_MATERIAL";

                    //sqlItens = String.Format(sqlItens, pedidosListados);

                    using (SqlConnection cnn = new BancoDeDados().conectar(bco))
                    {
                        if (cnn != null)
                        {
                            using (SqlCommand comando = new SqlCommand(sqlItens, cnn))
                            {
                                comando.CommandTimeout = 120; // Timeout aumentado
                                                              // Executa o comando e preenche o DataTable
                                using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                                {
                                    adaptador.Fill(retornadoItens);
                                }
                            }
                        }

                        if (cnn.State == ConnectionState.Open) bco.desconectar(cnn);
                    }

                    if (retornadoItens.Rows.Count > 0)
                    {

                        foreach (DataRow row in retornadoItens.Rows)
                        {

                            listaItens.Add(new Itens
                            {
                                codPedido = Convert.ToInt32(row["CD_PEDIDO"]),
                                codFilial = Convert.ToInt32(row["CD_FILIAL"]),
                                codProduto = Convert.ToInt32(row["CD_MATERIAL"]),
                                descricaoProduto = row["DS_MATERIAL"].ToString(),
                                quantidade = Convert.ToDouble(row["QUANTPEDIDA"]),
                                emseparacao = Convert.ToDouble(row["EMSEPARACAO"]),
                                separado = Convert.ToDouble(row["SEPARADO"]),

                            }
                            );


                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "[Obtendo os dados] - Aviso Importante");
                    listaPedido.Clear();
                    listaItens.Clear();
                }

                
                



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "[Montando SQL] - Aviso Importante");
                listaPedido.Clear();
                listaItens.Clear();
            }


            return (listaPedido, listaItens);           

            
        }


        // Classe para adicionar cabeçalho e rodapé personalizados
        public class CustomHeaderFooter : PdfPageEventHelper
        {

            public string empresa_sendo_usada { get; set; }
            public string PeriodoRelatorio { get; set; }

            private Font fonteRodape = FontFactory.GetFont(FontFactory.HELVETICA, 8, BaseColor.GRAY);
            private Font fonteCabecalho = FontFactory.GetFont(FontFactory.HELVETICA, 9, BaseColor.BLACK);
            private Font fontePeriodo = FontFactory.GetFont(FontFactory.HELVETICA, 8, BaseColor.BLACK);
            private Font fonteEmpresa = FontFactory.GetFont(FontFactory.HELVETICA, 8, BaseColor.BLACK);            

            public override void OnEndPage(PdfWriter writer, Document document)
            {
                PdfPTable tabelaCabecalho = new PdfPTable(1);
                tabelaCabecalho.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;
                tabelaCabecalho.DefaultCell.Border = Rectangle.NO_BORDER;

                PdfPCell empresa = new PdfPCell(new Phrase(empresa_sendo_usada, fonteEmpresa))
                {
                    Border = Rectangle.NO_BORDER,
                    HorizontalAlignment = Element.ALIGN_LEFT
                };
                tabelaCabecalho.AddCell(empresa);

                tabelaCabecalho.WriteSelectedRows(0, -1, document.LeftMargin, document.PageSize.Height - 20, writer.DirectContent);


                tabelaCabecalho.AddCell(new PdfPCell(new Phrase(".: Relatório de Pedidos por CLIENTES :.", fonteCabecalho))
                {
                    Border = Rectangle.NO_BORDER,
                    HorizontalAlignment = Element.ALIGN_LEFT,
                    PaddingBottom = 10
                });                

                tabelaCabecalho.WriteSelectedRows(0, -1, document.LeftMargin, document.PageSize.Height - 20, writer.DirectContent);

                PdfPCell periodo = new PdfPCell(new Phrase(PeriodoRelatorio, fontePeriodo))
                {
                    Border = Rectangle.NO_BORDER,
                    HorizontalAlignment = Element.ALIGN_CENTER
                };
                tabelaCabecalho.AddCell(periodo);

                tabelaCabecalho.WriteSelectedRows(0, -1, document.LeftMargin, document.PageSize.Height - 20, writer.DirectContent);
                            

                tabelaCabecalho.WriteSelectedRows(0, -1, document.LeftMargin, document.PageSize.Height - 20, writer.DirectContent);

                PdfPTable tabelaRodape = new PdfPTable(2);
                tabelaRodape.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;
                tabelaRodape.DefaultCell.Border = Rectangle.NO_BORDER;

                tabelaRodape.AddCell(new PdfPCell(new Phrase($"Emitido em: {DateTime.Now:dd/MM/yyyy HH:mm}", fonteRodape))
                {
                    Border = Rectangle.NO_BORDER,
                    HorizontalAlignment = Element.ALIGN_LEFT
                });

                tabelaRodape.AddCell(new PdfPCell(new Phrase($"Página {writer.PageNumber}", fonteRodape))
                {
                    Border = Rectangle.NO_BORDER,
                    HorizontalAlignment = Element.ALIGN_RIGHT
                });

                tabelaRodape.WriteSelectedRows(0, -1, document.LeftMargin, document.BottomMargin - 10, writer.DirectContent);
            }
        }

        public class CustomHeaderFooterEstoque : PdfPageEventHelper
        {
            public string PeriodoRelatorio { get; set; }

            private Font fonteRodape = FontFactory.GetFont(FontFactory.HELVETICA, 8, BaseColor.GRAY);
            private Font fonteCabecalho = FontFactory.GetFont(FontFactory.HELVETICA, 14, BaseColor.BLACK);
            private Font fonteNegrito = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 6, BaseColor.BLACK);
            private Font fonteNormal = FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.BLACK);

            public override void OnEndPage(PdfWriter writer, Document document)
            {
                PdfContentByte cb = writer.DirectContent;

                float larguraUtil = document.PageSize.Width - document.LeftMargin - document.RightMargin;

                
                // 🟢 CABEÇALHO
                PdfPTable tabelaCabecalho = new PdfPTable(1);
                tabelaCabecalho.TotalWidth = larguraUtil;
                tabelaCabecalho.DefaultCell.Border = Rectangle.NO_BORDER;

                tabelaCabecalho.AddCell(new PdfPCell(new Phrase(".: Relatório de Estoque :.", fonteCabecalho))
                {
                    Colspan = 6, // Faz com que o título ocupe todas as colunas
                    Border = Rectangle.NO_BORDER,
                    HorizontalAlignment = Element.ALIGN_LEFT,
                    PaddingBottom = 10

                    //Border = Rectangle.NO_BORDER,
                    //HorizontalAlignment = Element.ALIGN_CENTER,
                    //PaddingBottom = 5
                });

                tabelaCabecalho.WriteSelectedRows(0, -1, document.LeftMargin, document.PageSize.Height - 10, cb);

                PdfPTable tabelaPeridodo = new PdfPTable(1);
                tabelaPeridodo.TotalWidth = larguraUtil;
                tabelaPeridodo.DefaultCell.Border = Rectangle.NO_BORDER;

                PdfPCell periodo = new PdfPCell(new Phrase(PeriodoRelatorio, fonteNormal))
                {
                    Border = Rectangle.NO_BORDER,
                    HorizontalAlignment = Element.ALIGN_CENTER
                };
                tabelaPeridodo.AddCell(periodo);

                tabelaPeridodo.WriteSelectedRows(0, -1, document.LeftMargin, document.PageSize.Height - 20, writer.DirectContent);


                // 🟢 TÍTULOS DAS COLUNAS (Mantendo na mesma posição em cada página)
                PdfPTable tabela = new PdfPTable(8);
                tabela.TotalWidth = larguraUtil;
                tabela.SetWidths(new float[] { 3f, 15f, 6f, 3f, 3f, 3f, 3f, 3f });


                

                // Adicionar os títulos das colunas ao cabeçalho
                tabela.AddCell(new PdfPCell(new Phrase("Cód.", fonteNegrito)) { Border = Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_LEFT });
                tabela.AddCell(new PdfPCell(new Phrase("Descrição", fonteNegrito)) { Border = Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_LEFT });
                tabela.AddCell(new PdfPCell(new Phrase("Identific", fonteNegrito)) { Border = Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_RIGHT });
                tabela.AddCell(new PdfPCell(new Phrase("Pedido", fonteNegrito)) { Border = Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_RIGHT });
                tabela.AddCell(new PdfPCell(new Phrase("Disponível", fonteNegrito)) { Border = Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_RIGHT });
                tabela.AddCell(new PdfPCell(new Phrase("Em Separação", fonteNegrito)) { Border = Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_RIGHT });
                tabela.AddCell(new PdfPCell(new Phrase("Separado", fonteNegrito)) { Border = Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_RIGHT });
                tabela.AddCell(new PdfPCell(new Phrase("Total", fonteNegrito)) { Border = Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_RIGHT });

                tabela.WriteSelectedRows(0, -1, document.LeftMargin, document.PageSize.Height - 60, cb);

                // 🟢 RODAPÉ 
                PdfPTable tabelaRodape = new PdfPTable(2);
                tabelaRodape.TotalWidth = larguraUtil;
                tabelaRodape.DefaultCell.Border = Rectangle.NO_BORDER;

                tabelaRodape.AddCell(new PdfPCell(new Phrase($"Emitido em: {DateTime.Now:dd/MM/yyyy HH:mm}", fonteRodape))
                {
                    Border = Rectangle.NO_BORDER,
                    HorizontalAlignment = Element.ALIGN_LEFT
                });

                tabelaRodape.AddCell(new PdfPCell(new Phrase($"Página {writer.PageNumber}", fonteRodape))
                {
                    Border = Rectangle.NO_BORDER,
                    HorizontalAlignment = Element.ALIGN_RIGHT
                });

                tabelaRodape.WriteSelectedRows(0, -1, document.LeftMargin, document.BottomMargin - 10, cb);
            }
        }
    }
}
