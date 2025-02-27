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
    public class RelEstoque
    {
        public RelEstoque() { }

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
                        
                            sql += chave +  " BETWEEN ";                        

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

        public void impressaoRelatorioEstoque(DateTime dt_inicial, DateTime dt_final,  DataTable dt_Empresa)
        {

            string empresa_ = null;

            //DataTable
            DataTable dt_Filial = new DataTable();

            var filtros = new Dictionary<string, object>();

            foreach (DataRow dr in dt_Empresa.Rows)
            {
                empresa_= dr["CD_EMPRESA"].ToString() + "-" + dr["DS_EMPRESA"].ToString();  
            }

            CustomHeaderFooterEstoque headerFooter = new CustomHeaderFooterEstoque()
            {

                empresa_usada = $"Empresa: {empresa_}",
                PeriodoRelatorio = $"Período: {dt_inicial.ToString("dd/MM/yyyy")} à {dt_inicial.ToString("dd/MM/yyyy")} "

            };

            Document doc = new Document(PageSize.A4, 50, 50, 80, 50); // Ajuste das margens
            string caminhoPDF = Path.Combine(Directory.GetCurrentDirectory(), "Relatorio_Estoque") + DateTime.Now.ToString("ddMMyyyyhhmmss") + ".pdf";
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(caminhoPDF, FileMode.Create));

            writer.PageEvent = headerFooter;


            doc.Open();


            Font fonteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 6, BaseColor.BLACK);
            Font fonteNormal = FontFactory.GetFont(FontFactory.HELVETICA, 6, BaseColor.BLACK);
            Font fonteNegrito = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 6, BaseColor.BLACK);
            PdfPTable tabelaEstoque = new PdfPTable(8);
            tabelaEstoque.WidthPercentage = 100;
            tabelaEstoque.SetWidths(new float[] { 3f, 15, 6f, 3f, 3f, 3f, 3f, 3f });


            foreach (DataRow dr in dt_Empresa.Rows)
            {
                filtros.Add("CD_EMPRESA", dr["CD_EMPRESA"]);
                dt_Filial = retornaFilial(filtros);

                if (dt_Filial.Rows.Count > 0)
                {
                    foreach(DataRow drFilial in dt_Filial.Rows)
                    {
                        tabelaEstoque.AddCell(new PdfPCell(new Phrase(drFilial["CD_FILIAL"].ToString() +"-" + drFilial["DS_FILIAL"].ToString(), fonteNegrito))
                        {
                            HorizontalAlignment = Element.ALIGN_RIGHT,
                            Border = Rectangle.NO_BORDER
                        });
                    }
                }

            }

            doc.Add(tabelaEstoque);

            doc.Close();

            Cursor.Current = Cursors.Default;

            frmExibirRelatorio frm = new frmExibirRelatorio(caminhoPDF);
            frm.ShowDialog();
        }

        public class CustomHeaderFooterEstoque : PdfPageEventHelper
        {
            public string PeriodoRelatorio { get; set; }
            public string empresa_usada { get; set; }

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

                PdfPCell empresa = new PdfPCell(new Phrase(empresa_usada, fonteNormal))
                {
                    Border = Rectangle.NO_BORDER,
                    HorizontalAlignment = Element.ALIGN_LEFT
                };
                tabelaCabecalho.AddCell(empresa);

                tabelaCabecalho.WriteSelectedRows(0, -1, document.LeftMargin, document.PageSize.Height - 20, writer.DirectContent);


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

        //private Dictionary<string, object> retornaFiltro()
        //{
        //    var filtros = new Dictionary<string, object>();
                                    
        //    filtros.Add("DataFim", dataFinal.Value.ToString());
            





        //    return filtros;

        //}
    }
}
