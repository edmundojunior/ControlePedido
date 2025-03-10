using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
namespace ControlePedido
{
    public class Usuarios
    {
        public bool retornaAutorizacao(string ds_login, string ds_senha)
        {
            bool retorno = false;

            DataTable retornado = new DataTable();

            var bco = new BancoDeDados().lerXMLConfiguracao();

            try
            {
                string sql = String.Format("Select * from TBL_USUARIOS where DS_LOGIN = '{0}' AND DS_SENHA = '{1}'", ds_login, ds_senha);

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
                                adaptador.Fill(retornado);
                            }
                        }
                    }

                    if (cnn.State == ConnectionState.Open) bco.desconectar(cnn);
                }

                if (retornado.Rows.Count > 0)
                {
                    foreach (DataRow row in retornado.Rows) {
                        retorno = Convert.ToBoolean(row["X_AUTORIZA_ENTREGA_PRODUTOS"]);                   
                    }
                }
                else
                {
                    retorno = false;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "[PERMISSÕES] Aviso Importante ");
                retorno = false;
            }

            return retorno;
        }

        public (bool, string, string) retornaPermissao(string ds_login, string ds_senha)
        {
            bool retorno = false;
            string codigo = string.Empty;
            string nome = string.Empty;

            DataTable retornado = new DataTable();

            var bco = new BancoDeDados().lerXMLConfiguracao();

            try 
            {
                string sql= String.Format("Select * from TBL_USUARIOS where DS_LOGIN = '{0}' AND DS_SENHA = '{1}'", ds_login, ds_senha);

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
                                adaptador.Fill(retornado);
                            }
                        }
                    }

                    if (cnn.State == ConnectionState.Open) bco.desconectar(cnn);
                }

                if (retornado.Rows.Count > 0)
                {
                    retorno = true;
                    foreach (DataRow row in retornado.Rows) { 
                        codigo = row["CD_CODUSUARIO"].ToString();
                        nome = row["DS_USUARIO"].ToString();
                    
                    }
                }
                else
                {
                    retorno = false;
                    codigo = "";
                    nome = "";
                }
            }
            catch(Exception ex) 
            {

                MessageBox.Show(ex.Message, "[PERMISSÕES] Aviso Importante ");
                retorno = false;
            }

            return (retorno,codigo,nome);
        } 
    }
}
