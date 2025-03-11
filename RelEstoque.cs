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
using Org.BouncyCastle.Asn1;

namespace ControlePedido
{
    public class RelEstoque
    {
        public RelEstoque() { }

        public string cd_cliente { get; set; } = null;
        public string ds_cliente { get; set; } = null;

        public string cd_filial { get; set; } = null;
        public string cd_material { get; set; } = null;
        public string ds_material { get; set; } = null;

        public string ds_unidade { get; set; } = null;

        public string cd_identificacao {  get; set; } = null;

       
        public double qtdeEstoque {  get; set; } = 0;

        public double qtdePedido { get; set; } = 0;

        public double qtdeEmSeparacao { get; set; } = 0;
        public double qtdeSeparacao { get; set; } = 0;
        



        public string retornaSQlComFiltro(string sql, Dictionary<string, object> filtros)
        {
            if (filtros != null && filtros.Count > 0)
            {

                foreach (var filtro in filtros)
                {
                    string chave = filtro.Key;
                    object valor = filtro.Value;


                    if (chave == "DataInicio")
                    {
                        if (sql.Contains("WHERE"))
                        {
                            sql += " AND ";
                        }
                        else sql += " WHERE ";
                        
                            sql += " P.DT_EMISSAO " +  " BETWEEN ";                        

                        if (Convert.ToDateTime(valor) is DateTime data)
                        {
                            sql += ($"'{data:dd-MM-yyyy}'");
                        }

                    }
                    else if (chave == "DataFim")
                    {

                        if (Convert.ToDateTime(valor) is DateTime data)
                        {
                            sql += ($" AND '{data:dd-MM-yyyy}'");
                        }
                    }
                    else
                    {
                        if (sql.Contains("WHERE"))
                        {
                            sql += " AND ";
                        }
                        else sql += " WHERE ";

                        sql += chave + " LIKE  '" + valor + "'";
                    }

                }

            }

            return sql;
        }

        public DataTable retornaItens(Dictionary<string, object> filtros)
        {
            DataTable dt = new DataTable();
            var bco = new BancoDeDados().lerXMLConfiguracao();

            string sql = @"SELECT 
                            PI.CD_MATERIAL
                            FROM 
                            TBL_PEDIDOS_ITENS PI
                            LEFT JOIN TBL_MATERIAIS M
                            ON M.CD_MATERIAL = PI.CD_MATERIAL 
                            LEFT JOIN  TBL_PEDIDOS P
                            ON P.CD_PEDIDO = PI.CD_PEDIDO 
                            LEFT JOIN TBL_EMPRESAS E
                            ON E.CD_EMPRESA = P.CD_EMPRESA
                            LEFT JOIN TBL_EMPRESAS_FILIAIS F
                            ON F.CD_FILIAL = P.CD_FILIAL
                            WHERE P.CD_STATUS IN (1,10,11)                              
                            ";

            sql = retornaSQlComFiltro(sql, filtros);

            sql += " GROUP BY PI.CD_MATERIAL ";                           
            sql += " ORDER BY PI.CD_MATERIAL ASC ";

            try
            {
                using (SqlConnection cnn = new BancoDeDados().conectar(bco))
                {
                    if (cnn != null)
                    {
                        using (SqlCommand comando = new SqlCommand(sql, cnn))
                        {
                            comando.CommandTimeout = 120; // Timeout aumentado
                                                          // Executa o comando e preenche o DataTable
                            using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                            {
                                adaptador.Fill(dt);
                            }
                        }
                    }

                    if (cnn.State == ConnectionState.Open) bco.desconectar(cnn);
                }
            }
            catch (Exception ex)
            {

                dt = null;
                MessageBox.Show($"Não foi possível acessar a tabela de PRODUTO\n [ {ex.Message} ]", "Aviso Importante");

            }


            return dt;

        }

        public DataTable retornaItensNosPedidos(Dictionary<string, object> filtros)
        {
            DataTable dt = new DataTable();
            var bco = new BancoDeDados().lerXMLConfiguracao();

            string sql = @"SELECT
                            P.CD_EMPRESA
                            , F.CD_FILIAL
                            ,P.CD_PEDIDO
                            ,P.CD_CLIENTE
                            , C.DS_ENTIDADE
                            ,PI.CD_MATERIAL
                            , SUM(PI.NR_QUANTIDADE ) AS QTDEPEDIDO
                            , SUM(IIF(PIE.NR_QUANTIDADE IS NULL , 0, PIE.NR_QUANTIDADE)) AS EMSEPARACAO
                            , SUM(IIF(PIE2.NR_QUANTIDADE IS NULL , 0, PIE2.NR_QUANTIDADE)) AS SEPARADO
                            FROM 
                            TBL_PEDIDOS_ITENS PI
                            LEFT JOIN  TBL_PEDIDOS P
                            ON P.CD_PEDIDO = PI.CD_PEDIDO 
                            left join TBL_PEDIDOS_ITENS_CONTROLE_ENTREGA PIE
                            ON PIE.CD_MATERIAL = PI.CD_MATERIAL
                            AND PIE.CD_PEDIDO = PI.CD_PEDIDO
                            AND PIE.X_ENTREGUE = 0
                            left join TBL_PEDIDOS_ITENS_CONTROLE_ENTREGA PIE2
                            ON PIE2.CD_MATERIAL = PI.CD_MATERIAL
                            AND PIE2.CD_PEDIDO = PI.CD_PEDIDO
                            AND PIE2.X_ENTREGUE = 1
                            LEFT JOIN TBL_ENTIDADES C
                            ON C.CD_ENTIDADE = P.CD_CLIENTE
                            LEFT JOIN TBL_EMPRESAS E
                            ON E.CD_EMPRESA = P.CD_EMPRESA
                            LEFT JOIN TBL_EMPRESAS_FILIAIS F
                            ON F.CD_FILIAL = P.CD_FILIAL
                            WHERE P.CD_STATUS IN (1,7) 
                            ";
            
            sql = retornaSQlComFiltro(sql, filtros);

            sql += @" GROUP BY P.CD_EMPRESA
                            , F.CD_FILIAL
                            ,P.CD_PEDIDO
                            ,P.CD_CLIENTE
                            , C.DS_ENTIDADE
                            ,PI.CD_MATERIAL
                            ORDER BY PI.CD_MATERIAL ASC  ";

            try
            {
                using (SqlConnection cnn = new BancoDeDados().conectar(bco))
                {
                    if (cnn != null)
                    {
                        using (SqlCommand comando = new SqlCommand(sql, cnn))
                        {
                            comando.CommandTimeout = 120; // Timeout aumentado
                                                          // Executa o comando e preenche o DataTable
                            using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                            {
                                adaptador.Fill(dt);
                            }
                        }
                    }

                    if (cnn.State == ConnectionState.Open) bco.desconectar(cnn);
                }
            }
            catch (Exception ex)
            {

                dt = null;
                MessageBox.Show($"Não foi possível acessar a tabela de PRODUTO\n [ {ex.Message} ]", "Aviso Importante");

            }


            return dt;

        }
        public DataTable retornaProduto(Dictionary<string, object> filtros)
        {
            DataTable dt = new DataTable();
            var bco = new BancoDeDados().lerXMLConfiguracao();

            string sql = @"SELECT 
                        E.CD_EMPRESA
                        , EP.DS_EMPRESA
                        , E.CD_FILIAL
                        , EPF.DS_FILIAL
                        , E.CD_MATERIAL
                        , M.DS_MATERIAL
                        , U.DS_ABREVIATURA
                        , M.CD_IDENTIFICACAO
                        , E.NR_ESTOQUE_DISPONIVEL
                        FROM 
                        TBL_MATERIAIS_ESTOQUE E
                        left join TBL_MATERIAIS M
                        ON M.CD_MATERIAL = E.CD_MATERIAL
                        LEFT JOIN TBL_MATERIAIS_UNIDADE U
                        ON U.CD_UNIDADE = M.CD_UNIDADE
                        LEFT JOIN TBL_EMPRESAS EP
                        ON EP.CD_EMPRESA = E.CD_EMPRESA
                        LEFT JOIN TBL_EMPRESAS_FILIAIS	EPF
                        ON EPF.CD_FILIAL = E.CD_FILIAL";
                        


            sql = retornaSQlComFiltro(sql, filtros);

            sql += " ORDER BY E.CD_MATERIAL";

            try
            {
                using (SqlConnection cnn = new BancoDeDados().conectar(bco))
                {
                    if (cnn != null)
                    {
                        using (SqlCommand comando = new SqlCommand(sql, cnn))
                        {
                            comando.CommandTimeout = 120; // Timeout aumentado
                                                          // Executa o comando e preenche o DataTable
                            using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                            {
                                adaptador.Fill(dt);
                            }
                        }
                    }

                    if (cnn.State == ConnectionState.Open) bco.desconectar(cnn);
                }
            }
            catch (Exception ex)
            {

                dt = null;
                MessageBox.Show($"Não foi possível acessar a tabela de PRODUTO\n [ {ex.Message} ]", "Aviso Importante");

            }


            return dt;


        }
        public DataTable retornaFilial(Dictionary<string, object> filtros)
        {
            DataTable dt = new DataTable();
            var bco = new BancoDeDados().lerXMLConfiguracao();

            string sql = @"SELECT 
                           CD_EMPRESA 
                           ,CD_FILIAL
                           , DS_FILIAL
                           FROM TBL_EMPRESAS_FILIAIS ";

            sql = retornaSQlComFiltro(sql, filtros);

            sql += " ORDER BY CD_EMPRESA ASC";

            try
            {
                using (SqlConnection cnn = new BancoDeDados().conectar(bco))
                {
                    if (cnn != null)
                    {
                        using (SqlCommand comando = new SqlCommand(sql, cnn))
                        {
                            comando.CommandTimeout = 120; // Timeout aumentado
                                                          // Executa o comando e preenche o DataTable
                            using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                            {
                                adaptador.Fill(dt);
                            }
                        }
                    }

                    if (cnn.State == ConnectionState.Open) bco.desconectar(cnn);
                }
            }
            catch (Exception ex)
            {

                dt = null;
                MessageBox.Show($"Não foi possível acessar a tabela de EMPRESA\n [ {ex.Message} ]", "Aviso Importante");

            }


            return dt;


        }

        public DataTable retornaEmpresa(Dictionary<string, object> filtros)
        {
            DataTable dt = new DataTable();
            var bco = new BancoDeDados().lerXMLConfiguracao();

            string sql = @"SELECT 
                           CD_EMPRESA 
                           , DS_EMPRESA
                           FROM TBL_EMPRESAS ";

            sql = retornaSQlComFiltro(sql, filtros);

            sql += " ORDER BY CD_EMPRESA ASC";


            try
            {
                using (SqlConnection cnn = new BancoDeDados().conectar(bco))
                {
                    if (cnn != null)
                    {
                        using (SqlCommand comando = new SqlCommand(sql, cnn))
                        {
                            comando.CommandTimeout = 120; // Timeout aumentado
                                                          // Executa o comando e preenche o DataTable
                            using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                            {
                                adaptador.Fill(dt);
                            }
                        }
                    }

                    if (cnn.State == ConnectionState.Open) bco.desconectar(cnn);
                }
            }
            catch (Exception ex) {

                dt = null;
                MessageBox.Show($"Não foi possível acessar a tabela de EMPRESA\n [ {ex.Message} ]", "Aviso Importante");
                    
            }


            return dt;

        }

        public void impressaoRelatorioEstoque(DateTime dt_inicial, DateTime dt_final,  DataTable dt_Empresa, System.Windows.Forms.Label lblProcesso,  string cd_filial = "1", Dictionary<string, object> filtros = null)
        {
            List<RelEstoque> lista = new List<RelEstoque>();
            List<RelEstoque> listaItens = new List<RelEstoque>();

            string empresa_ = null;

            //DataTable
            DataTable dt_Filial = new DataTable();
            DataTable dt_Produto = new DataTable();
            DataTable dt_Itens = new DataTable();
            DataTable dt_Pedido = new DataTable();
            DataTable dt_EmSeparaca = new DataTable();
            DataTable dt_Separado = new DataTable();

            var filtrosItens = new Dictionary<string, object>();

            foreach (DataRow dr in dt_Empresa.Rows)
            {
                empresa_= dr["CD_EMPRESA"].ToString() + "-" + dr["DS_EMPRESA"].ToString();  
            }

            CustomHeaderFooterEstoque headerFooter = new CustomHeaderFooterEstoque()
            {

                empresa_usada = $"Empresa: {empresa_}",
                PeriodoRelatorio = $"Período: {dt_inicial.ToString("dd/MM/yyyy")} à {dt_inicial.ToString("dd/MM/yyyy")} "

            };

            Document doc = new Document(PageSize.A4, 40, 40, 80, 50); // Ajuste das margens
            string caminhoPDF = Path.Combine(Directory.GetCurrentDirectory(), "Relatorio_Estoque") + DateTime.Now.ToString("ddMMyyyyhhmmss") + ".pdf";
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(caminhoPDF, FileMode.Create));

            writer.PageEvent = headerFooter;


            doc.Open();


            Font fonteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 6, BaseColor.BLACK);
            Font fonteNormal = FontFactory.GetFont(FontFactory.HELVETICA, 6, BaseColor.BLACK);
            Font fonteNormal2 = FontFactory.GetFont(FontFactory.HELVETICA, 5, BaseColor.BLACK);
            Font fonteNegrito = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 6, BaseColor.BLACK);
            Font fonteNegrito2 = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 5, BaseColor.BLACK);


            PdfPTable tabelaItens = new PdfPTable(5);
            tabelaItens.WidthPercentage = 100;
            tabelaItens.SetWidths(new float[] { 3f, 15f, 3f, 3f, 3f });
            int itemProcessado = 0;
            string processo = string.Empty;
            if (dt_Empresa.Rows.Count> 0)
            {
                foreach (DataRow dr in dt_Empresa.Rows)
                {

                    //filtros.Clear();
                    filtros.Add("E.CD_EMPRESA", dr["CD_EMPRESA"]);
                    filtros.Add("F.CD_FILIAL", cd_filial);
                    filtros.Add("DataInicio", dt_inicial);
                    filtros.Add("DataFim", dt_final);

                    dt_Itens = retornaItens(filtros);

                    //dt_Pedido = retornaItensNosPedidos(filtros);

                    if (dt_Itens.Rows.Count > 0)
                    {
                        foreach(DataRow dataRow in dt_Itens.Rows)
                        {
                            
                            
                            filtrosItens.Clear();
                            filtrosItens.Add("E.CD_EMPRESA", dr["CD_EMPRESA"]);
                            filtrosItens.Add("E.CD_FILIAL", cd_filial);
                            filtrosItens.Add("E.CD_MATERIAL", dataRow["CD_MATERIAL"]);
                            
                            dt_Produto = retornaProduto(filtrosItens);

                            if (dt_Produto.Rows.Count > 0)
                            {
                                itemProcessado++;
                                lblProcesso.Text = $"Processado: {itemProcessado} de {dt_Itens.Rows.Count} ";
                                lblProcesso.Refresh();

                                foreach (DataRow drProduto in dt_Produto.Rows)
                                {

                                    lista.Add(new RelEstoque()
                                    {
                                        cd_filial = drProduto["CD_FILIAL"].ToString(),
                                        cd_material = drProduto["CD_MATERIAL"].ToString(),
                                        ds_material = drProduto["DS_MATERIAL"].ToString(),
                                        ds_unidade = drProduto["DS_ABREVIATURA"].ToString(),
                                        cd_identificacao = drProduto["CD_IDENTIFICACAO"].ToString(),
                                        qtdeEstoque = Convert.ToDouble(drProduto["NR_ESTOQUE_DISPONIVEL"])

                                    });

                                    listaItens.Add(new RelEstoque()
                                    {
                                        cd_filial = drProduto["CD_FILIAL"].ToString(),
                                        cd_material = drProduto["CD_MATERIAL"].ToString(),
                                        ds_material = drProduto["DS_MATERIAL"].ToString(),
                                        ds_unidade = drProduto["DS_ABREVIATURA"].ToString(),
                                        cd_identificacao = drProduto["CD_IDENTIFICACAO"].ToString(),
                                        qtdeEstoque = Convert.ToDouble(drProduto["NR_ESTOQUE_DISPONIVEL"])

                                    });
                                }
                            }
                        }
                    }

                    if (lista.Count > 0)
                    {
                        
                        
                        int item = 0;
                        while (item < lista.Count)
                        {
                            //doc.Add(new Paragraph("\n"));

                            PdfPTable tabela = new PdfPTable(10);
                            tabela.WidthPercentage = 100;
                            tabela.SetWidths(new float[] { 2f, 3f, 15f, 2f, 5f, 3f, 3f, 3f, 3f, 3f });
                            tabela.HorizontalAlignment = Element.ALIGN_LEFT;

                            tabela.AddCell(new PdfPCell(new Phrase(lista[item].cd_filial.ToString(), fonteNormal))
                            {
                                HorizontalAlignment = Element.ALIGN_RIGHT,
                                Border = Rectangle.NO_BORDER
                            });


                            tabela.AddCell(new PdfPCell(new Phrase(lista[item].cd_material.ToString(), fonteNormal))
                            {
                                HorizontalAlignment = Element.ALIGN_RIGHT,
                                Border = Rectangle.NO_BORDER
                            });

                            tabela.AddCell(new PdfPCell(new Phrase(lista[item].ds_material.ToString(), fonteNormal))
                            {
                                HorizontalAlignment = Element.ALIGN_LEFT,
                                Border = Rectangle.NO_BORDER
                            });

                            tabela.AddCell(new PdfPCell(new Phrase(lista[item].ds_unidade.ToString(), fonteNormal))
                            {
                                HorizontalAlignment = Element.ALIGN_CENTER,
                                Border = Rectangle.NO_BORDER
                            });

                            tabela.AddCell(new PdfPCell(new Phrase(lista[item].cd_identificacao.ToString(), fonteNormal))
                            {
                                HorizontalAlignment = Element.ALIGN_RIGHT,
                                Border = Rectangle.NO_BORDER
                            });
                            tabela.AddCell(new PdfPCell(new Phrase(Convert.ToDouble(lista[item].qtdeEstoque).ToString("N4"), fonteNormal))
                            {
                                HorizontalAlignment = Element.ALIGN_RIGHT,
                                Border = Rectangle.NO_BORDER
                            }); tabela.AddCell(new PdfPCell(new Phrase("", fonteNegrito)) { Border = Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_RIGHT });
                            tabela.AddCell(new PdfPCell(new Phrase("", fonteNegrito)) { Border = Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_RIGHT });
                            tabela.AddCell(new PdfPCell(new Phrase("", fonteNegrito)) { Border = Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_RIGHT });
                            tabela.AddCell(new PdfPCell(new Phrase("", fonteNegrito)) { Border = Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_RIGHT });


                            double totais = Convert.ToDouble(lista[item].qtdeEstoque);


                            doc.Add(tabela);
                            
                            PdfPTable tabelaEstoque = new PdfPTable(10);
                            tabelaEstoque.WidthPercentage = 100;
                            tabelaEstoque.SetWidths(new float[] { 3f, 3f, 17f,1f, 1f, 3f, 3f, 3f, 3f, 3f });


                            //Cabçalho

                            // Adicionar os títulos das colunas ao cabeçalho
                            tabelaEstoque.AddCell(new PdfPCell(new Phrase("Pedido", fonteNegrito2)) { Border = Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_RIGHT });
                            tabelaEstoque.AddCell(new PdfPCell(new Phrase("Cod", fonteNegrito2)) { Border = Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_RIGHT });
                            tabelaEstoque.AddCell(new PdfPCell(new Phrase("Cliente", fonteNegrito2)) { Border = Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_LEFT });
                            tabelaEstoque.AddCell(new PdfPCell(new Phrase("", fonteNegrito2)) { Border = Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_RIGHT });
                            tabelaEstoque.AddCell(new PdfPCell(new Phrase("", fonteNegrito2)) { Border = Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_RIGHT });
                            tabelaEstoque.AddCell(new PdfPCell(new Phrase("Qtde. Pedido", fonteNegrito2)) { Border = Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_RIGHT });
                            tabelaEstoque.AddCell(new PdfPCell(new Phrase("", fonteNegrito2)) { Border = Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_RIGHT });
                            tabelaEstoque.AddCell(new PdfPCell(new Phrase("Qtde. Separado", fonteNegrito2)) { Border = Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_RIGHT });
                            tabelaEstoque.AddCell(new PdfPCell(new Phrase("", fonteNegrito2)) { Border = Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_RIGHT });
                            tabelaEstoque.AddCell(new PdfPCell(new Phrase("Total", fonteNegrito2)) { Border = Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_RIGHT });

                            

                            //Itens Pedidos
                            filtros.Clear();
                            filtros.Add("E.CD_EMPRESA", dr["CD_EMPRESA"]);
                            filtros.Add("F.CD_FILIAL", cd_filial);
                            filtros.Add("PI.CD_MATERIAL", lista[item].cd_material);

                            dt_Itens = retornaItensNosPedidos(filtros);


                            if (dt_Itens.Rows.Count > 0)
                            {

                                foreach (DataRow drItens in dt_Itens.Rows)
                                {
                                    {
                                        var iProduto = listaItens.FirstOrDefault(i => i.cd_material == drItens["CD_MATERIAL"].ToString());

                                        //var iProduto = lista.FirstOrDefault(i => i.Empresa == Convert.ToInt32(row["CD_EMPRESA"])
                                        //                              && i.Filial == Convert.ToInt32(row["CD_FILIAL"])
                                        //                              && i.Produto == Convert.ToInt32(row["CODIGO"])
                                        //                              );

                                        if (iProduto != null)
                                        {
                                            iProduto.qtdePedido = Convert.ToDouble(drItens["QTDEPEDIDO"]);
                                            iProduto.qtdeEmSeparacao = Convert.ToDouble(drItens["EMSEPARACAO"]);
                                            iProduto.qtdeSeparacao = Convert.ToDouble(drItens["SEPARADO"]);

                                            tabelaEstoque.AddCell(new PdfPCell(new Phrase(drItens["CD_PEDIDO"].ToString(), fonteNormal2))
                                            {
                                                HorizontalAlignment = Element.ALIGN_RIGHT,
                                                Border = Rectangle.NO_BORDER
                                            });

                                            tabelaEstoque.AddCell(new PdfPCell(new Phrase(drItens["CD_CLIENTE"].ToString(), fonteNormal2))
                                            {
                                                HorizontalAlignment = Element.ALIGN_RIGHT,
                                                Border = Rectangle.NO_BORDER
                                            });

                                            tabelaEstoque.AddCell(new PdfPCell(new Phrase(drItens["DS_ENTIDADE"].ToString(), fonteNormal2))
                                            {
                                                HorizontalAlignment = Element.ALIGN_RIGHT,
                                                Border = Rectangle.NO_BORDER
                                            });

                                            tabelaEstoque.AddCell(new PdfPCell(new Phrase("", fonteNormal2))
                                            {
                                                HorizontalAlignment = Element.ALIGN_RIGHT,
                                                Border = Rectangle.NO_BORDER
                                            });

                                            tabelaEstoque.AddCell(new PdfPCell(new Phrase("", fonteNormal2))
                                            {
                                                HorizontalAlignment = Element.ALIGN_LEFT,
                                                Border = Rectangle.NO_BORDER
                                            });

                                            tabelaEstoque.AddCell(new PdfPCell(new Phrase(Convert.ToDouble(drItens["QTDEPEDIDO"]).ToString("N4"), fonteNormal2))
                                            {
                                                HorizontalAlignment = Element.ALIGN_RIGHT,
                                                Border = Rectangle.NO_BORDER
                                            });

                                            tabelaEstoque.AddCell(new PdfPCell(new Phrase(Convert.ToDouble(drItens["EMSEPARACAO"]).ToString("N4"), fonteNormal2))
                                            {
                                                HorizontalAlignment = Element.ALIGN_RIGHT,
                                                Border = Rectangle.NO_BORDER
                                            });

                                            tabelaEstoque.AddCell(new PdfPCell(new Phrase(Convert.ToDouble(drItens["SEPARADO"]).ToString("N4"), fonteNormal2))
                                            {
                                                HorizontalAlignment = Element.ALIGN_RIGHT,
                                                Border = Rectangle.NO_BORDER
                                            });

                                            tabelaEstoque.AddCell(new PdfPCell(new Phrase("", fonteNormal2))
                                            {
                                                HorizontalAlignment = Element.ALIGN_RIGHT,
                                                Border = Rectangle.NO_BORDER
                                            });

                                            totais -= Convert.ToDouble(drItens["QTDEPEDIDO"]);

                                            tabelaEstoque.AddCell(new PdfPCell(new Phrase(totais.ToString("N4"), fonteNegrito2))
                                            {
                                                HorizontalAlignment = Element.ALIGN_RIGHT,
                                                Border = Rectangle.NO_BORDER
                                            });

                                            
                                        }
                                    }
                                }

                                
                            }
                            //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

                            doc.Add(tabelaEstoque);

                            item++;
                        }
                    }

                }
            }            
           

            doc.Close();

            Cursor.Current = Cursors.Default;

            frmExibirRelatorio frm = new frmExibirRelatorio(caminhoPDF);
            frm.ShowDialog();
        }

        public class CustomHeaderFooterEstoque : PdfPageEventHelper
        {
            public string PeriodoRelatorio { get; set; }
            public string empresa_usada { get; set; }            


            private Font fonteRodape = FontFactory.GetFont(FontFactory.HELVETICA, 6, BaseColor.GRAY);
            private Font fonteCabecalho = FontFactory.GetFont(FontFactory.HELVETICA, 12, BaseColor.BLACK);
            private Font fonteNegrito = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 6, BaseColor.BLACK);
            private Font fonteNormal = FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.BLACK);

            public override void OnEndPage(PdfWriter writer, Document document)
            {
                float larguraUtil = document.PageSize.Width - document.LeftMargin - document.RightMargin;

                PdfPTable tabelaCabecalho = new PdfPTable(1);
                tabelaCabecalho.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;
                tabelaCabecalho.DefaultCell.Border = Rectangle.NO_BORDER;

                PdfPCell empresa = new PdfPCell(new Phrase(empresa_usada, fonteNegrito))
                {
                    Border = Rectangle.NO_BORDER,
                    HorizontalAlignment = Element.ALIGN_LEFT
                };
                tabelaCabecalho.AddCell(empresa);

                tabelaCabecalho.WriteSelectedRows(0, -1, document.LeftMargin, document.PageSize.Height - 20, writer.DirectContent);


                tabelaCabecalho.AddCell(new PdfPCell(new Phrase(".: Relatório de Estoque :.", fonteCabecalho))
                {
                    Border = Rectangle.NO_BORDER,
                    HorizontalAlignment = Element.ALIGN_LEFT,
                    PaddingBottom = 10
                });

                tabelaCabecalho.WriteSelectedRows(0, -1, document.LeftMargin, document.PageSize.Height - 20, writer.DirectContent);

                PdfPCell periodo = new PdfPCell(new Phrase(PeriodoRelatorio, fonteNegrito))
                {
                    Border = Rectangle.NO_BORDER,
                    HorizontalAlignment = Element.ALIGN_CENTER
                };
                //tabelaCabecalho.AddCell(periodo);

                tabelaCabecalho.WriteSelectedRows(0, -1, document.LeftMargin, document.PageSize.Height - 20, writer.DirectContent);
                
                // 🟢 TÍTULOS DAS COLUNAS (Mantendo na mesma posição em cada página)
                PdfPTable tabela = new PdfPTable(10);
                tabela.TotalWidth = larguraUtil;
                tabela.SetWidths(new float[] { 2f, 3f, 15f, 2f, 5f,3f, 3f, 3f, 3f, 3f });

                // Adicionar os títulos das colunas ao cabeçalho
                tabela.AddCell(new PdfPCell(new Phrase("Filial", fonteNegrito)) { Border = Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_RIGHT });
                tabela.AddCell(new PdfPCell(new Phrase("Cód.", fonteNegrito)) { Border = Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_RIGHT });
                tabela.AddCell(new PdfPCell(new Phrase("Descrição", fonteNegrito)) { Border = Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_LEFT });
                tabela.AddCell(new PdfPCell(new Phrase("Unid.", fonteNegrito)) { Border = Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_CENTER });
                tabela.AddCell(new PdfPCell(new Phrase("Identific", fonteNegrito)) { Border = Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_RIGHT });
                tabela.AddCell(new PdfPCell(new Phrase("Disponivel", fonteNegrito)) { Border = Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_CENTER });
                tabela.AddCell(new PdfPCell(new Phrase("", fonteNegrito)) { Border = Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_CENTER });
                tabela.AddCell(new PdfPCell(new Phrase("", fonteNegrito)) { Border = Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_CENTER });
                tabela.AddCell(new PdfPCell(new Phrase("", fonteNegrito)) { Border = Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_CENTER });
                tabela.AddCell(new PdfPCell(new Phrase("", fonteNegrito)) { Border = Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_CENTER });

                tabela.WriteSelectedRows(0, -1, document.LeftMargin, document.PageSize.Height - 60, writer.DirectContent);

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

                tabelaRodape.WriteSelectedRows(0, -1, document.LeftMargin, document.BottomMargin - 10, writer.DirectContent);
            }
        }
        
    }
}
