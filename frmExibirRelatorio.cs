using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using CsvHelper;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.Globalization;
using Path = System.IO.Path;
using ClosedXML.Excel;

namespace ControlePedido
{
    public partial class frmExibirRelatorio : Form
    {
        
        private string caminhoPDF;
        public frmExibirRelatorio(string arqPDF)
        {
            InitializeComponent();
            caminhoPDF = arqPDF;
            webBrowser1.Navigate(arqPDF);         

        }

        private void usBarraTitulo1_Load(object sender, EventArgs e)
        {

        }

        private void Salvarpdf(string caminhoPdf)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf|All files (*.*)|*.*";
            string csvFilePath = "relatorio.pdf";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string novoCaminho = saveFileDialog.FileName;

                // Copiar o PDF gerado para o novo local escolhido
                File.Copy(caminhoPdf, novoCaminho, true);  // O terceiro parâmetro sobrescreve se o arquivo já existir
                MessageBox.Show($"PDF salvo em: {novoCaminho}");
            }

        }

        private void SalvarXlxs(string caminhoPdf)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx|All files (*.*)|*.*";

            string pdfText = ExtractTextFromPdf(caminhoPdf);
            string excelFilePath = "relatorio.xlsx";

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.AddWorksheet("Relatorio");

                // Separa o conteúdo do PDF por linhas e escreve no Excel
                var lines = pdfText.Split('\n');
                for (int i = 0; i < lines.Length; i++)
                {
                    var columns = lines[i].Split(' '); // Ou outra lógica de separação dependendo do seu PDF
                    for (int j = 0; j < columns.Length; j++)
                    {
                        worksheet.Cell(i + 1, j + 1).Value = columns[j];
                    }
                }

                // Salva o arquivo Excel
                workbook.SaveAs(excelFilePath);
            }

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string novoCaminho = saveFileDialog.FileName;

                // Copiar o PDF gerado para o novo local escolhido
                File.Copy(excelFilePath, novoCaminho, true);  // O terceiro parâmetro sobrescreve se o arquivo já existir

                if (File.Exists(excelFilePath)) File.Delete(excelFilePath);


                MessageBox.Show($"Excel salvo em: {novoCaminho}");
            }
        }
        static List<string> ExtractLinesFromPdf(string pdfFilePath)
        {
            var lines = new List<string>();
            using (PdfReader reader = new PdfReader(pdfFilePath))
            {
                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    string pageText = PdfTextExtractor.GetTextFromPage(reader, i);
                    lines.AddRange(pageText.Split('\n')); // Divide o texto em linhas
                }
            }
            return lines;
        }

        private void SalvarCsv(string caminhoPdf)
        {
            // Abrir caixa de diálogo para o usuário escolher o local e nome do arquivo
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Files (*.csv)|*.csv|All files (*.*)|*.*";
            string csvFilePath = "relatorio.csv"; //Path.Combine(Directory.GetCurrentDirectory(), 

            saveFileDialog.FileName = csvFilePath;  // Nome padrão            

            string pdfText = ExtractTextFromPdf(caminhoPdf);

            List<string> lines = ExtractLinesFromPdf(caminhoPdf);


            using (var writer = new StreamWriter(csvFilePath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                foreach (var line in lines)
                {
                    csv.WriteField(line); // Escreve a linha inteira
                    csv.NextRecord();     // Move para a próxima linha
                }
            }
            // Exibir a caixa de diálogo
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string novoCaminho = saveFileDialog.FileName;

                // Copiar o PDF gerado para o novo local escolhido
                File.Copy(csvFilePath, novoCaminho, true);  // O terceiro parâmetro sobrescreve se o arquivo já existir

                if (File.Exists(csvFilePath)) File.Delete(csvFilePath);


                MessageBox.Show($"CSV salvo em: {novoCaminho}");
            }


        }

        static string ExtractTextFromPdf(string pdfFilePath)
        {
            using (PdfReader reader = new PdfReader(pdfFilePath))
            {
                StringWriter sw = new StringWriter();
                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    sw.WriteLine(PdfTextExtractor.GetTextFromPage(reader, i));
                }
                return sw.ToString();
            }
        }

        private void btnPdf_Click(object sender, EventArgs e)
        {
            Salvarpdf(caminhoPDF);
        }

        private void btnCsv_Click(object sender, EventArgs e)
        {
            SalvarCsv(caminhoPDF);
        }

        private void btnXlxs_Click(object sender, EventArgs e)
        {
            SalvarXlxs(caminhoPDF);

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
