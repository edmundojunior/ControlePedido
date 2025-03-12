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
    public class Pedidos
    {
        public class itemPedido
        {
            public itemPedido() { }

            public int item { get; set; } = 0;
            public int codPedido { get; set; } = 0;
            public int codItem { get; set; } = 0;
            public int Cd_Id_Item { get; set; } = 0;
            public string codIdentific { get; set; } = null;
            public string descricao { get; set; } = null;
            public int usuario { get; set; } = 0;
            public int usuarioEntregou { get; set; } = 0;
            public string unidade { get; set; } = null;
            public double Quantidade { get; set; } = 0;
            public double QuantOriginal { get; set; } = 0;
            public double vlrUnitario { get; set; } = 0;
            public double vlrTotal { get; set; } = 0;
            public bool entrega { get; set; } = false;
            public string origem { get; set; } = "PD";
            public DateTime dtEntrega { get; set; } = DateTime.Now;
            public int CodCliente { get; set; } = 0;
            public string nomeCliente { get; set; } = null;
            public int CD_EMPRESA { get; set; } = 0;
            public int CD_FILIAL { get; set; } = 0;
            public int CD_STATUS { get; set; } = 0;
            public string DS_STATUS { get; set; } = null;
        }

        BancoDeDados bco = new BancoDeDados();

        public List<Pedidos.itemPedido> listaItemsAEntregar = new List<Pedidos.itemPedido>();
        public List<itemPedido> listaDevolucao = new List<itemPedido>();
        public List<itemPedido> listaTemp = new List<itemPedido>();
        public List<itemPedido> listaEntregar = new List<itemPedido>();

        public class MovimentacaoPedido
        {
            private DataTable RetornaPedidoEntregues(Dictionary<string, object> filtros = null)
            {
                DataTable retornado = new DataTable();

                var bco = new BancoDeDados().lerXMLConfiguracao();

                try
                {
                    string sql = " SELECT CD_ID " +
                                 "       ,CD_PEDIDO " +
                                 "       ,CD_ITEM " +
                                 "       ,CD_ID_ITEM " +
                                 "       ,CD_MATERIAL " +
                                 "       ,CD_USUARIO " +
                                 "       ,DS_MATERIAL " +
                                 "       ,DS_UNIDADE " +
                                 "       ,NR_QUANTIDADE " +
                                 "       ,VL_UNITARIO " +
                                 "       ,VL_TOTAL " +
                                 "       ,X_ENTREGUE " +
                                 "       ,DT_ENTREGA " +
                                 "       ,CD_USUARIO_ENTREGOU " +
                                 "       ,CD_IDENTIFICACAO " +
                                 "   FROM TBL_PEDIDOS_ITENS_CONTROLE_ENTREGA " +
                                 " WHERE X_ENTREGUE = 1";

                    try
                    {
                        foreach (var filtro in filtros)
                        {
                            string chave = filtro.Key;
                            object valor = filtro.Value;

                            if (sql.Contains("WHERE"))
                            {
                                sql += " AND ";
                            }
                            else sql += " WHERE ";

                            sql += chave + " = " + valor;

                        }

                        using (SqlConnection cnn = new BancoDeDados().conectar(bco))
                        {
                            if (cnn != null)
                            {
                                using (SqlCommand comando = new SqlCommand(sql, cnn))
                                {
                                    // Executa o comando e preenche o DataTable
                                    using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                                    {
                                        adaptador.Fill(retornado);
                                    }
                                }
                            }

                            if (cnn.State == ConnectionState.Open) bco.desconectar(cnn);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Aviso Importante");
                        retornado = null;
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Não foi possível encontrar dados de Entrega" + ex.Message, "Aviso Importante");
                    retornado = null;
                }

                return retornado;

            }

            private DataTable RetornaPedido(Dictionary<string, object> filtros = null, bool geral = true)
            {
                DataTable retornado = new DataTable();

                var bco = new BancoDeDados().lerXMLConfiguracao();

                string statusNao = string.Empty;

                try
                {
                    string sql = "select " +
                                " PED.CD_PEDIDO AS CODIGO " +
                                " , CL.CD_FILIAL AS FILIAL " +
                                " , ST.CD_STATUS AS CODSTATUS " +
                                " , ST.DS_STATUS AS STATUS " +
                                " , CL.CD_ENTIDADE AS CODCLIENTE " +
                                " , CL.DS_ENTIDADE AS CLIENTE " +
                                " , CL.NR_CPFCNPJ AS CNPJ " +
                                " , CID.DS_CIDADE AS CIDADE " +
                                " , VEN.DS_ENTIDADE AS VENDEDOR " +
                                " , PED.DT_EMISSAO AS DTEMISSAO " +
                                " , PED.DT_ENTREGA AS DTENTREGA " +
                                " , PED.DS_VALIDADE AS VALIDADE " +
                                " , PED.DS_IMPOSTOS AS IMPOSTOS " +
                                " , PED.DS_OBS AS OBSERVACAO " +
                                " , PED.DS_OBS_INTERNA AS OBSINTERNA " +
                                " from TBL_PEDIDOS PED " +
                                " left join TBL_STATUS_GLOBAL ST ON ST.CD_STATUS = PED.CD_STATUS " +
                                " left join TBL_ENTIDADES CL ON CL.CD_ENTIDADE = PED.CD_CLIENTE " +
                                " left join TBL_ENDERECO_CIDADES CID ON CID.CD_CIDADE = CL.CD_CIDADE " +
                                " left join TBL_ENTIDADES VEN ON VEN.CD_ENTIDADE = PED.CD_VENDEDOR ";


                    try
                    {
                        if (filtros != null && filtros.Count > 0)
                        {
                            statusNao = geral ? " PED.CD_STATUS IN (1, 10 ,11) " : " PED.CD_STATUS NOT IN (4,5)";

                            if (!geral)
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

                                        sql += " PED.DT_EMISSAO BETWEEN ";

                                        if (valor is DateTime data)
                                        {
                                            sql += ($"'{data:dd-MM-yyyy}'");
                                        }

                                    }
                                    else if (chave == "DataFim")
                                    {

                                        if (valor is DateTime data)
                                        {
                                            sql += ($" AND '{data:dd-MM-yyyy}'");
                                        }
                                    }
                                    else if (chave == "PED.DS_STATUS")
                                    {
                                        statusNao = "";

                                        if (sql.Contains("WHERE"))
                                        {
                                            sql += " AND ";
                                        }
                                        else sql += " WHERE ";

                                        sql += chave + " LIKE  " + valor;
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
                        }



                        statusNao = geral ? " PED.CD_STATUS IN (1, 10 ,11) " : " PED.CD_STATUS NOT IN (4,5)";

                        if (statusNao != "")
                        {
                            if (sql.Contains("WHERE"))
                            {
                                sql += " AND ";
                            }
                            else sql += " WHERE ";

                            sql += statusNao;
                        }

                        sql += " ORDER BY PED.CD_PEDIDO ASC ";

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

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Aviso Importante");
                        retornado = null;
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Não foi possível encontrar os dados do Pedido \n" + ex.Message, "Aviso Importante");
                    retornado = null;

                }

                return retornado;

            }

            private DataTable RetornaPedidoEntregar(Dictionary<string, object> filtros = null, bool geral = true)
            {
                DataTable retornado = new DataTable();

                var bco = new BancoDeDados().lerXMLConfiguracao();

                string statusNao = string.Empty;

                try
                {
                    string sql = "  select P.CD_PEDIDO " +
                                    "   , PIT.CD_ID  " +
                                    "   , PIT.CD_MATERIAL " +
                                    "   , M.CD_IDENTIFICACAO  " +
                                    "   , M.DS_MATERIAL  " +
                                    "   , MU.DS_ABREVIATURA  " +
                                    "   , PIT.NR_QUANTIDADE AS NR_QUANTIDADE  " +
                                    "   , PIT.VL_UNITARIO  " +
                                    "   , P.DT_ENTREGA   " +
                                    "   , P.CD_EMPRESA   " +
                                    "   , P.CD_FILIAL   " +
                                    "   , PIT.CD_USUARIO  " +
                                    "   , PIT.VL_TOTAL  " +
                                    "   , M.CD_IDENTIFICACAO " +
                                    "   , iif(TIPCE.NR_QUANTIDADE IS NULL, 0, TIPCE.NR_QUANTIDADE)  AS QTDEENTREGUE " +
                                    "   , P.CD_CLIENTE " +
                                    "   , E.DS_ENTIDADE " +
                                    "   , P.CD_STATUS " +
                                    "   from TBL_PEDIDOS P " +
                                    "   left join  TBL_PEDIDOS_ITENS PIT  ON PIT.CD_PEDIDO = P.CD_PEDIDO " +
                                    "   left join TBL_MATERIAIS M ON M.CD_MATERIAL = PIT.CD_MATERIAL " +
                                    "   left join TBL_MATERIAIS_UNIDADE MU ON MU.CD_UNIDADE = M.CD_UNIDADE " +
                                    "   left join TBL_PEDIDOS_ITENS_CONTROLE_ENTREGA TIPCE " +
                                    "   ON TIPCE.CD_PEDIDO = P.CD_PEDIDO  " +
                                    "   AND TIPCE.CD_MATERIAL = PIT.CD_MATERIAL " +
                                    "   AND TIPCE.X_ENTREGUE = 1    " +
                                    "   left join TBL_ENTIDADES E ON E.CD_ENTIDADE = P.CD_CLIENTE  " +
                                    "   WHERE PIT.CD_ID IS NOT NULL ";

                    try
                    {
                        foreach (var filtro in filtros)
                        {
                            string chave = filtro.Key;
                            object valor = filtro.Value;

                            if (sql.Contains("WHERE"))
                            {
                                sql += " AND ";
                            }
                            else sql += " WHERE ";

                            sql += chave + " = " + valor;

                        }

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

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Aviso Importante");
                        retornado = null;
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Não foi possível encontrar os dados do Pedido \n" + ex.Message, "Aviso Importante");
                    retornado = null;

                }

                return retornado;

            }

            public List<Pedidos.itemPedido> retornaListaEntregar(int CodPedido)
            {

                var filtros = new Dictionary<string, object>
                    {
                        { "P.CD_PEDIDO", CodPedido },

                };

                DataTable dtPedido = RetornaPedidoEntregar(filtros);

                List<Pedidos.itemPedido> retorno = new List<Pedidos.itemPedido>();
                int i = 0;

                try
                {

                    if (dtPedido.Rows.Count > 0)
                    {
                        foreach (DataRow row in dtPedido.Rows)
                        {

                            if ((Convert.ToDouble(row["NR_QUANTIDADE"]) - Convert.ToDouble(row["QTDEENTREGUE"])) > 0)
                            {
                                retorno.Add(new Pedidos.itemPedido
                                {
                                    item = i++,
                                    codPedido = Convert.ToInt32(row["CD_PEDIDO"]),
                                    codItem = Convert.ToInt32(row["CD_MATERIAL"]),
                                    codIdentific = row["CD_IDENTIFICACAO"].ToString(),
                                    descricao = row["DS_MATERIAL"].ToString(),
                                    unidade = row["DS_ABREVIATURA"].ToString(),
                                    Quantidade = Convert.ToDouble(row["NR_QUANTIDADE"]) - Convert.ToDouble(row["QTDEENTREGUE"]),
                                    QuantOriginal = Convert.ToDouble(row["NR_QUANTIDADE"]),
                                    origem = "PD",
                                    vlrUnitario = Convert.ToDouble(row["VL_UNITARIO"]),
                                    vlrTotal = Convert.ToDouble(row["VL_TOTAL"]),
                                    usuario = Convert.ToInt32(row["CD_USUARIO"]),
                                    Cd_Id_Item = Convert.ToInt32(row["CD_ID"]),
                                    CodCliente = Convert.ToInt32(row["CD_CLIENTE"]),
                                    nomeCliente = row["DS_ENTIDADE"].ToString(),

                                });
                            }


                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Problema ao listar os dados do Pedido\n" + ex.Message, "Aviso Importante");
                    retorno.Clear();
                }

                return retorno;

            }

            public void retornaListaPedido(System.Windows.Forms.DataGridView grade,
                                                               Dictionary<string, object> filtros = null)
            {



                DataTable dtPedido = RetornaPedido(filtros);

                List<Pedidos.itemPedido> retorno = new List<Pedidos.itemPedido>();

                int Pedido = 0;
                int ItemDoPedido = 0;
                try
                {

                    if (dtPedido.Rows.Count > 0)
                    {
                        foreach (DataRow row in dtPedido.Rows)
                        {

                            int rowIndex = grade.Rows.Add(); // Adiciona uma nova linha e obtém o índice
                            for (int colIndex = 0; colIndex < dtPedido.Columns.Count; colIndex++)
                            {
                                grade.Rows[rowIndex].Cells[colIndex].Value = row[colIndex];
                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Problema ao listar os dados do Pedido {Pedido} Item: {ItemDoPedido}\n" + ex.Message, "Aviso Importante");
                    retorno.Clear();
                }



            }

            public List<Pedidos.itemPedido> retornaListaEntregue(int CodPedido)
            {

                var filtros = new Dictionary<string, object>
                    {
                        { "CD_PEDIDO", CodPedido },

                };

                DataTable dtPedido = RetornaPedidoEntregues(filtros);

                List<Pedidos.itemPedido> retorno = new List<Pedidos.itemPedido>();
                int i = 0;

                try
                {

                    if (dtPedido.Rows.Count > 0)
                    {
                        foreach (DataRow row in dtPedido.Rows)
                        {
                            retorno.Add(new Pedidos.itemPedido
                            {
                                item = i++,
                                codPedido = Convert.ToInt32(row["CD_PEDIDO"]),
                                codItem = Convert.ToInt32(row["CD_MATERIAL"]),
                                codIdentific = row["CD_IDENTIFICACAO"].ToString(),
                                descricao = row["DS_MATERIAL"].ToString(),
                                unidade = row["DS_UNIDADE"].ToString(),
                                Quantidade = Convert.ToDouble(row["NR_QUANTIDADE"]),
                                QuantOriginal = Convert.ToDouble(row["NR_QUANTIDADE"]),
                                origem = "PD",
                                vlrUnitario = Convert.ToDouble(row["VL_UNITARIO"]),
                                vlrTotal = Convert.ToDouble(row["VL_TOTAL"]),
                                usuario = Convert.ToInt32(row["CD_USUARIO"]),
                                Cd_Id_Item = Convert.ToInt32(row["CD_ID"])

                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Problema ao listar os dados do Pedido: \n" + ex.Message, "Aviso Importante");
                    retorno.Clear();
                }

                return retorno;

            }

            public DataTable retornarPedidosControle(int CodPedido, int CodProduto)
            {

                DataTable retorno = new DataTable();
                var bco = new BancoDeDados().lerXMLConfiguracao();

                string sqlSelect = String.Format("Select * from TBL_PEDIDOS_ITENS_CONTROLE_ENTREGA " +
                                                " where CD_PEDIDO = {0} " +
                                                " and CD_MATERIAL = {1} ", CodPedido.ToString(),
                                                CodProduto.ToString());


                try
                {
                    using (SqlConnection cnn = new BancoDeDados().conectar(bco))
                    {
                        if (cnn != null)
                        {
                            using (SqlCommand comando = new SqlCommand(sqlSelect, cnn))
                            {
                                using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                                {
                                    adaptador.Fill(retorno);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Aviso Importante 1");
                    retorno = null;
                }

                return retorno;

            }
            public void MovimentarEntrega(List<Pedidos.itemPedido> lista)
            {

                Cursor.Current = Cursors.WaitCursor;

                int item = 0;
                string sql = string.Empty;
                int PedidoAtual = 0;

                try
                {
                    DataTable retorno = new DataTable();

                    if (lista.Count > 0)
                    {
                        while (item < lista.Count)
                        {
                            retorno = retornarPedidosControle(lista[item].codPedido, lista[item].codItem);

                            PedidoAtual = lista[item].codPedido;

                            if (retorno.Rows.Count > 0)
                            {
                                foreach (var row in retorno.Rows)
                                {
                                    //Update
                                    double quantidade = lista[item].Quantidade;

                                    sql = String.Format("Update TBL_PEDIDOS_ITENS_CONTROLE_ENTREGA  SET " +
                                                                    " NR_QUANTIDADE = NR_QUANTIDADE + " + quantidade.ToString("N4").Replace(".", "").Replace(",", ".") +
                                                                    " , X_ENTREGUE = 1 " +
                                                                    " WHERE CD_PEDIDO = {0} " +
                                                                    " AND CD_MATERIAL = {1}  " ,
                                                                    lista[item].codPedido.ToString(),
                                                                    lista[item].codItem.ToString());


                                }
                            }
                            else
                            {
                                //Insert
                                sql = String.Format("INSERT INTO TBL_PEDIDOS_ITENS_CONTROLE_ENTREGA( " +
                                                                              " CD_PEDIDO " +
                                                                              " ,CD_ITEM " +
                                                                              " ,CD_ID_ITEM " +
                                                                              " ,CD_MATERIAL " +
                                                                              " ,CD_USUARIO " +
                                                                              " ,DS_MATERIAL " +
                                                                              " ,DS_UNIDADE " +
                                                                              " ,NR_QUANTIDADE " +
                                                                              " ,VL_UNITARIO " +
                                                                              " ,VL_TOTAL " +
                                                                              " ,X_ENTREGUE " +
                                                                              " ,DT_ENTREGA " +
                                                                              " ,CD_USUARIO_ENTREGOU " +
                                                                              " ,CD_IDENTIFICACAO) VALUES " +
                                                                              " ( {0} " +
                                                                              " , {1} " +
                                                                              " , {2} " +
                                                                              " , {3} " +
                                                                              " , {4} " +
                                                                              " , '{5}' " +
                                                                              " , '{6}' " +
                                                                              " , {7} " +
                                                                              " , {8} " +
                                                                              " , {9} " +
                                                                              " , {10} " +
                                                                              " , '{11}' " +
                                                                              " , {12} " +
                                                                              " , '{13}' " +
                                                                              " )", lista[item].codPedido.ToString()
                                                                              , (item + 1).ToString()
                                                                              , lista[item].Cd_Id_Item.ToString()
                                                                              , lista[item].codItem.ToString()
                                                                              , lista[item].usuario.ToString()
                                                                              , lista[item].descricao.ToString()
                                                                              , lista[item].unidade.ToString()
                                                                              , lista[item].Quantidade.ToString("N4").Replace(".", "").Replace(",", ".")
                                                                              , lista[item].vlrUnitario.ToString("N4").Replace(".", "").Replace(",", ".")
                                                                              , lista[item].vlrTotal.ToString("N4").Replace(".", "").Replace(",", ".")
                                                                              , lista[item].entrega == false ? "0" : "1"
                                                                              , lista[item].dtEntrega.ToString("dd.MM.yyyy")
                                                                              , lista[item].usuarioEntregou.ToString()
                                                                              , lista[item].codIdentific.ToString()
                                                                              );
                            }



                            var bco = new BancoDeDados().lerXMLConfiguracao();

                            using (SqlConnection cnn = new BancoDeDados().conectar(bco))
                            {
                                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                                {
                                    cmd.ExecuteNonQuery();
                                }

                                if (cnn.State == ConnectionState.Open) bco.desconectar(cnn);
                            }

                            item++;
                        }

                        Pedidos ped1 = new Pedidos();
                        ped1.atualizarStatusPedido(PedidoAtual,ped1.retornoCodigoStatus(), false);

                    }
                    else
                    {
                        MessageBox.Show("Não possui informação para entrega", "Aviso");
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Aviso Importante Geral");
                }

                Cursor.Current = Cursors.Default;
            }


            public void MovimentarRetorno(List<Pedidos.itemPedido> lista)
            {

                Cursor.Current = Cursors.WaitCursor;

                int item = 0;
                string sql = string.Empty;
                int PedidoAtual = 0;

                try
                {
                    DataTable retorno = new DataTable();

                    if (lista.Count > 0)
                    {
                        while (item < lista.Count)
                        {
                            retorno = retornarPedidosControle(lista[item].codPedido, lista[item].codItem);

                            PedidoAtual = lista[item].codPedido;

                            if (retorno.Rows.Count > 0)
                            {
                                foreach (DataRow row in retorno.Rows)
                                {
                                    //Update
                                    double quantidade = lista[item].Quantidade;
                                    double qtde = Convert.ToDouble(row["NR_QUANTIDADE"]);

                                    if (quantidade == qtde)
                                    {
                                        sql = String.Format("Update TBL_PEDIDOS_ITENS_CONTROLE_ENTREGA  SET " +
                                                            " NR_QUANTIDADE = NR_QUANTIDADE - " + quantidade.ToString("N4").Replace(".", "").Replace(",", ".") +
                                                            " , X_ENTREGUE = 0 " +
                                                            " WHERE CD_PEDIDO = {0} " +
                                                            " AND CD_MATERIAL = {1}  " +
                                                            " AND CD_ID_ITEM = {2} AND X_ENTREGUE = 1",
                                                            lista[item].codPedido.ToString(),
                                                            lista[item].codItem.ToString(),
                                                            lista[item].Cd_Id_Item.ToString());
                                    }
                                    else
                                    {
                                        sql = String.Format("Update TBL_PEDIDOS_ITENS_CONTROLE_ENTREGA  SET " +
                                                            " NR_QUANTIDADE = NR_QUANTIDADE - " + quantidade.ToString("N4").Replace(".", "").Replace(",", ".") +
                                                            " , X_ENTREGUE = 1 " +
                                                            " WHERE CD_PEDIDO = {0} " +
                                                            " AND CD_MATERIAL = {1}  " +
                                                            " AND CD_ID_ITEM = {2} AND X_ENTREGUE = 1",
                                                            lista[item].codPedido.ToString(),
                                                            lista[item].codItem.ToString(),
                                                            lista[item].Cd_Id_Item.ToString());
                                    }
                                }
                            }
                            
                            var bco = new BancoDeDados().lerXMLConfiguracao();

                            using (SqlConnection cnn = new BancoDeDados().conectar(bco))
                            {
                                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                                {
                                    cmd.ExecuteNonQuery();
                                }

                                if (cnn.State == ConnectionState.Open) bco.desconectar(cnn);
                            }

                            item++;
                        }

                        Pedidos ped1 = new Pedidos();

                        ped1.atualizarStatusPedido(PedidoAtual, ped1.retornoCodigoStatus(), true);

                    }
                    else
                    {
                        MessageBox.Show("Não possui informação para entrega", "Aviso");
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Aviso Importante Geral");
                }

                Cursor.Current = Cursors.Default;
            }
        }

        public void atualizarStatusPedido(int Pedido, int Status, bool retornoProduto = false)
        {
            var bco = new BancoDeDados().lerXMLConfiguracao();
            DataTable retornado = new DataTable();
            double valorEntregar = 0;
            double valorEntregue = 0;

            string sqlr = String.Format(" SELECT TPI.CD_PEDIDO " +
                                        " ,SUM(TPI.NR_QUANTIDADE) as QTDE_ENTREGAR " +
                                        " ,SUM(iif(TPICE.NR_QUANTIDADE IS NULL, 0 , TPICE.NR_QUANTIDADE)) AS QTDE_ENTREGUE " +
                                        " FROM TBL_PEDIDOS_ITENS TPI  " +
                                        " LEFT JOIN TBL_PEDIDOS_ITENS_CONTROLE_ENTREGA TPICE ON " +
                                        " TPICE.CD_PEDIDO = TPI.CD_PEDIDO " +
                                        " where TPI.CD_PEDIDO = {0} " +                                        
                                        " GROUP BY TPI.CD_PEDIDO "  , Pedido);


            using (SqlConnection cnn = new BancoDeDados().conectar(bco))
            {
                using (SqlCommand comando = new SqlCommand(sqlr, cnn))
                {
                    comando.CommandTimeout = 120; // Timeout aumentado
                                                  // Executa o comando e preenche o DataTable
                    using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                    {
                        adaptador.Fill(retornado);
                    }
                }

                if (retornado.Rows.Count > 0)
                {
                    foreach(DataRow row in retornado.Rows)
                    {
                        valorEntregar = Convert.ToDouble(row["QTDE_ENTREGAR"]);
                        valorEntregue = Convert.ToDouble(row["QTDE_ENTREGUE"]);
                    }
                }

                if (cnn.State == ConnectionState.Open) bco.desconectar(cnn);
            }
            
            if (valorEntregue == 0)
            {
                Status = 1;
            }
            else if ((valorEntregar - valorEntregue) == 0)
            {
                 Status = retornoCodigoStatus("SEPARADO");                
            }
            else
            {
                Status = retornoCodigoStatus("EM SEPARAÇÃO");
            }
                        
            string sql = String.Format("update TBL_PEDIDOS set  " +
                         " CD_STATUS = {0} " +
                         " WHERE CD_PEDIDO = {1} ", Status, Pedido); 
                        
            
            using (SqlConnection cnn = new BancoDeDados().conectar(bco))
            {
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cmd.ExecuteNonQuery();
                }

                if (cnn.State == ConnectionState.Open) bco.desconectar(cnn);
            }

        }

        public bool retornaPendenciaPedido(int Pedido, bool retornoProduto = false)
        {
            DataTable retornado = new DataTable();
             
            bool retorno = false;
                        
            string sql = String.Format(" SELECT TPI.CD_PEDIDO\r\n,SUM(TPI.NR_QUANTIDADE - iif(TPICE.NR_QUANTIDADE IS NULL, 0 , TPICE.NR_QUANTIDADE)) AS NR_QUANTIDADE      \r\nFROM TBL_PEDIDOS_ITENS TPI \r\nLEFT JOIN TBL_PEDIDOS_ITENS_CONTROLE_ENTREGA TPICE ON\r\nTPICE.CD_PEDIDO = TPI.CD_PEDIDO\r\nwhere TPI.CD_PEDIDO = {0}\r\nAND TPICE.X_ENTREGUE = 1  \r\nGROUP BY TPI.CD_PEDIDO ", Pedido);

            if (retornoProduto)
            {
                sql = String.Format("SELECT TPI.CD_PEDIDO\r\n,SUM(TPI.NR_QUANTIDADE) AS NR_QUANTIDADE      \r\nFROM TBL_PEDIDOS_ITENS_CONTROLE_ENTREGA TPI \r\nwhere TPI.CD_PEDIDO = {0}\r\nGROUP BY TPI.CD_PEDIDO ", Pedido);
            }

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
                        if (Convert.ToDouble(row["NR_QUANTIDADE"]) == 0)
                        {
                            retorno = true;
                        }
                    } 
                }
            }            

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "[FECHAMENTO PEDIDO] - Importante");
                retorno = false;
            }

            return retorno;

        }
        public int retornoCodigoStatus(string status = "SEPARADO")
        {
            int retorno = 0;
            DataTable retornado = new DataTable();

            var bco = new BancoDeDados().lerXMLConfiguracao();

            try
            {
                string sql = String.Format("Select CD_STATUS from TBL_STATUS_GLOBAL where DS_STATUS = '{0}'", status);

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
                    foreach (DataRow row in retornado.Rows)
                    {

                        retorno = Convert.ToInt32(row["CD_STATUS"]);                        
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "[STATUS GLOBAL] - Importante");
                retorno = 0;
            }

            return retorno;
            
        }
    }
}
