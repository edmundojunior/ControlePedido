using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml.Drawing.Slicer.Style;
using Org.BouncyCastle.Utilities.IO.Pem;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using static ControlePedido.Impressao;

namespace ControlePedido
{
    public class imprimirRelatorios
    {
        

        public void imprimir(bool ehPedido, DataTable dtRelatorio, DateTime dtInicial, DateTime DtFinal)
        {
            if (ehPedido)
            {
                relatorioPedidos(dtRelatorio, dtInicial, DtFinal);
            }
            else
            {
                relatorioEstoque(dtRelatorio, dtInicial, DtFinal);
            }

        }

        public void relatorioPedidos(DataTable dtRelatorio,DateTime dtInicial, DateTime DtFinal)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            string caminhoPDF = Path.Combine(Directory.GetCurrentDirectory(), "Relatorio_Pedido") + DateTime.Now.ToString("ddMMyyyyhhmmss") + ".pdf";

            Document.Create(container => {

                container.Page(page => {

                    page.Size(PageSizes.A4);
                    page.Margin(20);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(10));

                    //Cabeçalho
                    page.Header().Column(col =>
                    {
                        // Primeira linha (título centralizado)
                        col.Item().Row(row =>
                        {
                            // Coluna do título centralizado
                            row.RelativeItem().AlignCenter().Text(".: Relatório de Pedidos por Clientes :.").Bold().FontSize(16);
                        });

                        // Segunda linha (data no canto direito)
                        col.Item().Row(row =>
                        {
                            // Coluna da data alinhada à direita
                            row.RelativeItem().AlignRight().Text($"Data de Impressão: {DateTime.Now:dd/MM/yyyy HH:mm}").FontSize(7);
                        });

                        col.Item().Height(10);  // Ajuste a altura para o tamanho do espaço que você precisa


                        col.Item().Row(row =>
                        {
                            // Coluna da data alinhada à direita
                            row.RelativeItem().AlignCenter().Text($"Período: {dtInicial.ToString("dd/MM/yyyy")} à {DtFinal.ToString("dd/MM/yyyy")}").Italic().FontSize(7);
                        });

                        col.Item().Height(10);

                        col.Item().Row(row => {

                            string empresa = "Não identificado!";

                            if (dtRelatorio.Rows.Count > 0) empresa = $" Empresa: {dtRelatorio.Rows[0]["CD_EMPRESA"].ToString()} - {dtRelatorio.Rows[0]["DS_EMPRESA"].ToString()}";

                            // Coluna da data alinhada à direita
                            row.RelativeItem().AlignLeft().Text(empresa).FontSize(7);
                        });

                        col.Item().Height(10);

                        // Linha divisória abaixo do cabeçalho
                        col.Item().LineHorizontal(1);
                        col.Item().Height(5);
                        
                        col.Item().LineHorizontal(0);


                    });
                    string NumCliente = "";
                    string NumPedido = "";

                    //Detalhe
                    page.Content().Column(col =>
                    {

                        foreach (DataRow row in dtRelatorio.Rows)
                        {
                            if (NumCliente != row["CD_CLIENTE"].ToString() || NumPedido != row["CD_PEDIDO"].ToString())
                            {
                                NumCliente = row["CD_CLIENTE"].ToString();
                                NumPedido = row["CD_PEDIDO"].ToString();

                                col.Item().Height(5);

                                col.Item().Table(table =>
                                {
                                    table.ColumnsDefinition(columns =>
                                    {
                                        columns.ConstantColumn(22);  // vazio
                                        columns.ConstantColumn(27);   // COdigp
                                        columns.ConstantColumn(230);   // Descrição
                                        columns.ConstantColumn(80);   // Pedidas
                                        columns.ConstantColumn(80);   // Disponiveis
                                        columns.ConstantColumn(80);   // Em Separação



                                    });

                                    table.Header(header =>
                                    {
                                        header.Cell().Text("Filial").Bold().FontSize(8);
                                        header.Cell().Text("Pedido").Bold().FontSize(8);
                                        header.Cell().Text("Cliente").Bold().FontSize(8).AlignCenter();
                                        header.Cell().Text("Vlr.Total").Bold().FontSize(8).AlignRight();
                                        header.Cell().Text("Dt.Emissão").Bold().FontSize(8).AlignRight();
                                        header.Cell().Text("Dt.Entrega").Bold().FontSize(8).AlignRight();
                                    });

                                    // Cabeçalho da tabela
                                    table.Cell().Text(row["CD_FILIAL"].ToString()).FontSize(8).AlignCenter();
                                    table.Cell().Text(row["CD_PEDIDO"].ToString()).FontSize(8);
                                    table.Cell().Text(row["CD_CLIENTE"].ToString() + " " + row["DS_ENTIDADE"].ToString()).FontSize(7);
                                    table.Cell().Text(Convert.ToDouble(row["VL_TOTAL"]).ToString("N2")).FontSize(8).AlignRight();
                                    table.Cell().Text(Convert.ToDateTime(row["DT_EMISSAO"]).ToString("dd/MM/yyyy")).FontSize(8).AlignRight();
                                    table.Cell().Text(Convert.ToDateTime(row["DT_ENTREGA"]).ToString("dd/MM/yyyy")).FontSize(8).AlignRight();

                                });

                                //col.Item().Height(5);

                                col.Item().Table(table2 =>
                                {
                                    table2.ColumnsDefinition(columns =>
                                    {

                                        columns.ConstantColumn(10);   // COdigp
                                        columns.ConstantColumn(30);   // COdigp
                                        columns.ConstantColumn(150);  // vazio
                                        columns.ConstantColumn(70);   // COdigp
                                        columns.ConstantColumn(70);   // Descrição
                                        columns.ConstantColumn(70);   // Pedidas
                                        columns.ConstantColumn(70);   // Disponiveis
                                        columns.ConstantColumn(70);   // Em Separação



                                    });

                                    // Cabeçalho da tabela
                                    table2.Cell().Text("").Bold().FontSize(7);
                                    table2.Cell().Text("Cód.").Bold().FontSize(7);
                                    table2.Cell().Text("Descrição").Bold().FontSize(7).AlignCenter();
                                    table2.Cell().Text("Q.Pedidas").Bold().FontSize(7).AlignRight();
                                    table2.Cell().Text("Q.Disponível").Bold().FontSize(7).AlignRight();
                                    table2.Cell().Text("Em Separação").Bold().FontSize(7).AlignRight();
                                    table2.Cell().Text("Separado").Bold().FontSize(7).AlignRight();
                                    table2.Cell().Text("Total").Bold().FontSize(7).AlignRight();

                                });
                            }

                            //Itens
                            col.Item().Table(tableItens2 =>
                            {
                                tableItens2.ColumnsDefinition(columns =>
                                {

                                    columns.ConstantColumn(10);   // COdigp
                                    columns.ConstantColumn(30);   // COdigp
                                    columns.ConstantColumn(150);  // vazio
                                    columns.ConstantColumn(70);   // COdigp
                                    columns.ConstantColumn(70);   // Descrição
                                    columns.ConstantColumn(70);   // Pedidas
                                    columns.ConstantColumn(70);   // Disponiveis
                                    columns.ConstantColumn(70);   // Em Separação



                                });

                                // Cabeçalho da tabela
                                tableItens2.Cell().Text("").Bold().FontSize(7);
                                tableItens2.Cell().Text(row["CD_MATERIAL"].ToString()).FontSize(7);
                                tableItens2.Cell().Text(row["DS_MATERIAL"].ToString()).FontSize(7);
                                tableItens2.Cell().Text(Convert.ToDouble(row["PEDIDAS"]).ToString("N4")).FontSize(7).AlignRight();
                                tableItens2.Cell().Text(Convert.ToDouble(row["DISPONIVEL"]).ToString("N4")).FontSize(7).AlignRight();
                                tableItens2.Cell().Text(Convert.ToDouble(row["EMSEPARACAO"]).ToString("N4")).FontSize(7).AlignRight();
                                tableItens2.Cell().Text(Convert.ToDouble(row["SEPARADO"]).ToString("N4")).FontSize(7).AlignRight();
                                tableItens2.Cell().Text(Convert.ToDouble(row["TOTAL"]).ToString("N4")).FontSize(7).AlignRight();

                            });


                        }
                    });






                    // RODAPÉ (Número de páginas)
                    page.Footer().AlignRight().Text(x =>
                    {
                        x.Span("Página ").FontSize(5);
                        x.CurrentPageNumber().FontSize(5);
                        x.Span(" de ").FontSize(5);
                        x.TotalPages().FontSize(5);
                    });

                });
            })
                .GeneratePdf(caminhoPDF);

               
            Cursor.Current = Cursors.Default;

            frmExibirRelatorio frm = new frmExibirRelatorio(caminhoPDF);
            frm.ShowDialog();
        }

        public void relatorioEstoque(DataTable dtRelatorio, DateTime dtInicial, DateTime DtFinal)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            string caminhoPDF = Path.Combine(Directory.GetCurrentDirectory(), "Relatorio_Estoque") + DateTime.Now.ToString("ddMMyyyyhhmmss") + ".pdf";

            Document.Create(container => {



                container.Page(page => {

                    page.Size(PageSizes.A4);
                    page.Margin(20);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(10));

                    page.Header().Column(col =>
                    {
                        // Primeira linha (título centralizado)
                        col.Item().Row(row =>
                        {
                            // Coluna do título centralizado
                            row.RelativeItem().AlignCenter().Text(".: Relatório de Estoque :.").Bold().FontSize(16);
                        });

                        // Segunda linha (data no canto direito)
                        col.Item().Row(row =>
                        {
                            // Coluna da data alinhada à direita
                            row.RelativeItem().AlignRight().Text($"Data de Impressão: {DateTime.Now:dd/MM/yyyy HH:mm}").FontSize(7);
                        });

                        col.Item().Height(10);  // Ajuste a altura para o tamanho do espaço que você precisa


                        col.Item().Row(row =>
                        {
                            // Coluna da data alinhada à direita
                            row.RelativeItem().AlignCenter().Text($"Período: {dtInicial.ToString("dd/MM/yyyy")} à {DtFinal.ToString("dd/MM/yyyy")}").Italic().FontSize(7);
                        });

                        col.Item().Height(10);

                        col.Item().Row(row => {

                            string empresa = "Não identificado!";

                            if (dtRelatorio.Rows.Count > 0) empresa = $" Empresa: {dtRelatorio.Rows[0]["CD_EMPRESA"].ToString()} - {dtRelatorio.Rows[0]["DS_EMPRESA"].ToString()}";

                            // Coluna da data alinhada à direita
                            row.RelativeItem().AlignLeft().Text(empresa).FontSize(7);
                        });

                        col.Item().Height(10);



                        // Linha divisória abaixo do cabeçalho
                        col.Item().LineHorizontal(1);
                        col.Item().Height(5);

                        col.Item().LineHorizontal(0);


                    });




                    // RODAPÉ (Número de páginas)
                    page.Footer().AlignRight().Text(x =>
                    {
                        x.Span("Página ").FontSize(5);
                        x.CurrentPageNumber().FontSize(5);
                        x.Span(" de ").FontSize(5);
                        x.TotalPages().FontSize(5);
                    });

                });

                    
            })

            .GeneratePdf(caminhoPDF);


            Cursor.Current = Cursors.Default;

            frmExibirRelatorio frm = new frmExibirRelatorio(caminhoPDF);
            frm.ShowDialog();
        }

        
    }
}
