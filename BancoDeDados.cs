using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Microsoft.Data.SqlClient;
using System.IO;
using System.Data;
using System.Data.SqlTypes;
using System.Diagnostics;
using static ControlePedido.Util;

namespace ControlePedido
{
    public class BancoDeDados
    {
        xml Xml = new xml();
        Criptografia crypto = new Criptografia();

        public BancoDeDados() { }

        public string server { get; set; } = null;
        public string database { get; set; } = null;
        public string user_id { get; set; } = null;
        public string password { get; set; } = null;
        public string port { get; set; } = null;

        #region > SQL SERVER <

        /// <summary>
        /// Manipulação do Banco de Dados Sql Server
        /// </summary>

        public bool testeDeConexao(SqlConnection conn)
        {
            if (conn == null)
            {
                return false;
            }
            else return true;

        }

        public bool salvarConfiguracao(BancoDeDados bcoDados)
        {

            bool retorno = false;

            try
            {

                string arquivoConfg = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "ConfbancoDeDados.xml";

                if (File.Exists(arquivoConfg))
                {
                    //Alteração

                    XElement BcoDados = XElement.Load(arquivoConfg);

                    // Altera o valor da tag desejada
                    foreach (PropertyInfo prop in bcoDados.GetType().GetProperties())
                    {
                        // Obtém o nome e o valor de cada propriedade
                        string nomePropriedade = prop.Name;
                        object valorPropriedade = prop.GetValue(bcoDados);

                        XElement tagToModify = BcoDados.Element(nomePropriedade);
                        if (tagToModify != null)
                        {
                            tagToModify.Value = valorPropriedade.ToString();
                        }

                    }

                    // Salva as alterações
                    BcoDados.Save(arquivoConfg);

                    retorno = true;
                }
                else
                {
                    //Inclusão

                    XElement BcoDados = new XElement("BcoDados",
                                        new XElement("server", bcoDados.server),
                                        new XElement("database", bcoDados.database),
                                        new XElement("user_id", bcoDados.user_id),
                                        new XElement("password", bcoDados.password)
                                        );

                    BcoDados.Save(arquivoConfg);

                    if (File.Exists(arquivoConfg)) retorno = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um problema ao tentar salvar a configuração do Banco de Dados\n" + ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
                retorno = false;
            }

            return retorno;
        }

        public BancoDeDados lerXMLConfiguracao()
        {
            BancoDeDados bcoDados = new BancoDeDados();

            string arquivoConfg = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "ConfbancoDeDados.xml";

            try
            {

                if (File.Exists(arquivoConfg))
                {
                    XElement BcoDados = XElement.Load(arquivoConfg);

                    bcoDados.server = Xml.Ler_XML("server", 1, arquivoConfg);
                    bcoDados.database = Xml.Ler_XML("database", 1, arquivoConfg);
                    bcoDados.user_id = Xml.Ler_XML("user_id", 1, arquivoConfg);
                    bcoDados.password = (Xml.Ler_XML("password", 1, arquivoConfg));
                    //bcoDados.password = crypto.Descriptografar(Xml.Ler_XML("password", 1, arquivoConfg));
                }
                else bcoDados = null;

            }
            catch
            {
                bcoDados = null;
            }

            return bcoDados;
        }

        public void desconectar(SqlConnection conn)
        {
            if (conn.State == System.Data.ConnectionState.Open) conn.Close();
        }

        public string connectionString(BancoDeDados bco)
        {
            string retorno = null;

            if (Debugger.IsAttached)
            {
                retorno = $@"Data Source=localhost;Initial Catalog={bco.database};Integrated Security=True;TrustServerCertificate=True;";
            }
            else
            {
                retorno = $@"Server={bco.server};Database={bco.database};User Id={bco.user_id};Password={bco.password};TrustServerCertificate=True;";

            }

            return retorno;
        }

        public SqlConnection conectar(BancoDeDados bco)
        {
            try
            {

                string connectionString = null;

                if (Debugger.IsAttached)
                {
                    connectionString = $@"Data Source=localhost;Initial Catalog={bco.database};Integrated Security=True;TrustServerCertificate=True;";
                }
                else
                {
                    connectionString = $@"Server={bco.server};Database={bco.database};User Id={bco.user_id};Password={bco.password};TrustServerCertificate=True;";

                }


                //string connectionString = $@"Server={bco.server};Database={bco.database};User Id={bco.user_id};Password={bco.password};TrustServerCertificate=True;";

                SqlConnection connection = new SqlConnection(connectionString);

                if (connection.State == ConnectionState.Open) bco.desconectar(connection);

                connection.Open();

                return connection;

            }
            catch (Exception ex)
            {

                MessageBox.Show("Ocorreu um problema ao conectar no banco\n" + ex.Message, "Importante");
                return null;
            }

        }

        public SqlConnection abrirConexao()
        {
            try
            {

                var bco = new BancoDeDados().lerXMLConfiguracao();

                var cnn = new BancoDeDados().conectar(bco);

                return cnn;

            }
            catch (Exception ex)
            {

                MessageBox.Show("Ocorreu um problema ao conectar no banco\n" + ex.Message, "Importante");
                return null;
            }
        }


        #endregion > SQL SERVER <

    }
}
