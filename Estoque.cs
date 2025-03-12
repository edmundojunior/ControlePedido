using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Logging;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace ControlePedido
{
    
    public class Estoque
    {
        
        public int Empresa { get; set; } = 0;
        public string RazaoEmpresa { get; set; } = null;
        public int Filial { get; set; } = 0;
        public string RazaoFilial { get; set; } = null;
        public int Produto { get; set; } = 0;
        public string DescricaoProduto { get; set; } = null;
        public string CodIdentificao { get; set; } = null;
        public double OrdemCompra { get; set; } = 0;
        public double OrdemProducao { get; set; } = 0;
        public double OrdemProducaoConsumo { get; set; } = 0;
        public double Orcamento { get; set; } = 0;
        public double OrdemServico { get; set; } = 0;
        public double Pedidos { get; set; } = 0;
        public double Requisicao { get; set; } = 0;
        public double EstoqueAtual { get; set; } = 0;
        public double Separado { get; set; } = 0;
        public double Disponivel { get; set; } = 0; 
        public double Almoxarifado { get; set; } = 0;
        public double EmSeparacao { get; set; } = 0;
        public double Transferencia { get; set; } = 0;


        List<Estoque> lista_estoque = new List<Estoque>();

        private DataTable dadosEstoque(string sql, Dictionary<string, object> filtroEstoque,  bool Ehemseparacao, bool Ehseparado, int qualEstoque = 0)
        {
            var bco = new BancoDeDados().lerXMLConfiguracao();

            DataTable retornado = new DataTable();

            if (filtroEstoque != null && filtroEstoque.Count > 0)
            {

                foreach (var filtro in filtroEstoque)
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

                            sql += " TP.DT_EMISSAO BETWEEN ";


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
                    }else
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

            switch (qualEstoque)
            {
                case 0:
                    sql += "    GROUP BY TME.CD_EMPRESA, TME.CD_FILIAL, TEF.DS_FILIAL, TME.CD_MATERIAL, TM.DS_MATERIAL, TM.CD_IDENTIFICACAO ";
                    break;

                case 2:
                    sql += "    GROUP BY TPI.CD_PEDIDO, TP.CD_EMPRESA, TP.CD_FILIAL, TEF.DS_FILIAL, TPI.CD_MATERIAL, TM.DS_MATERIAL ";
                    break;

                case 8:
                    if (Ehemseparacao) sql += "     GROUP BY TP.CD_EMPRESA, TP.CD_FILIAL, TEF.DS_FILIAL, TIPCE.CD_MATERIAL, TM.DS_MATERIAL ";
                    break;

                case 9:
                    if (Ehseparado) sql += "     GROUP BY TP.CD_EMPRESA, TP.CD_FILIAL, TEF.DS_FILIAL, TIPCE.CD_MATERIAL, TM.DS_MATERIAL ";
                    break;
            }
            

            if (qualEstoque == 8 || qualEstoque == 9)
            {
                if (!Ehseparado || !Ehemseparacao)
                {
                    sql = "";
                }
            }

            if (sql != "")
            {
                using (SqlConnection cnn = new BancoDeDados().conectar(bco))
                {
                    if (cnn != null)
                    {
                        using (SqlCommand comando = new SqlCommand(sql, cnn))
                        {
                            comando.CommandTimeout = 600;

                            using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                            {
                                adaptador.Fill(retornado);
                            }
                        }
                    }

                    if (cnn.State == ConnectionState.Open) bco.desconectar(cnn);
                }
            }
            

            return retornado;

        } 
        private DataTable dados(string sql)
        {
            var bco = new BancoDeDados().lerXMLConfiguracao();

            DataTable retornado = new DataTable();

            using (SqlConnection cnn = new BancoDeDados().conectar(bco))
            {
                if (cnn != null)
                {
                    using (SqlCommand comando = new SqlCommand(sql, cnn))
                    {
                        using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                        {
                            adaptador.Fill(retornado);
                        }
                    }
                }

                if (cnn.State == ConnectionState.Open) bco.desconectar(cnn);
            }

            return retornado;

        }

        private List<Estoque> preenchendoALista(DataTable retornado, int qualEstoque, System.Windows.Forms.Label contar)
        {
            //Legenda:
            //0 - Estoque Atual
            //1 - Ordem de Compra
            //2 - Pedidos
            //3 - Almoxarifado
            //4 - Ordem de Produção Consumo
            //5 - Ordem Produção
            //6 - Orçamento
            //7 - Ordem de Serviço
            //8 - Separado
            //9 - EmSeparacao
            int rodado = 0;
            contar.Text = $" Processados: {0} de { retornado.Rows.Count }";
            contar.Refresh();

            foreach (DataRow row in retornado.Rows)
            {

                rodado ++;
                contar.Text = $" Processados: {rodado} de {retornado.Rows.Count}";
                contar.Refresh();



                var item = lista_estoque.FirstOrDefault(i => i.Empresa == Convert.ToInt32(row["CD_EMPRESA"])
                                                          && i.Filial == Convert.ToInt32(row["CD_FILIAL"])
                                                          && i.Produto == Convert.ToInt32(row["CODIGO"])
                                                          );

                if (item != null)
                {
                    switch(qualEstoque)
                    {
                        case 0:
                            item.EstoqueAtual = Convert.ToDouble(row["EstoqueAtual"]);
                            break;
                        case 1:
                            item.OrdemCompra = Convert.ToDouble(row["OrdemCompra"]);
                            break;
                        case 2:
                            item.Pedidos = Convert.ToDouble(row["Pedidos"]);
                            break;
                        case 3:
                            item.Almoxarifado = Convert.ToDouble(row["Almoxarifado"]);
                            break;
                        case 4:
                            item.OrdemProducaoConsumo = Convert.ToDouble(row["OrdemProducaoConsumo"]);
                            break;
                        case 5:
                            item.OrdemProducao = Convert.ToDouble(row["OrdemProducao"]);
                            break;
                        case 6:
                            item.Orcamento = Convert.ToDouble(row["Orcamento"]);
                            break;
                        case 7:
                            item.OrdemServico = Convert.ToDouble(row["OrdemServico"]);
                            break;
                        case 8:
                            item.Separado = Convert.ToDouble(row["Separado"]);
                            break;
                        case 9:
                            item.EmSeparacao = Convert.ToDouble(row["EmSeparacao"]);
                            break;
                        default:
                            MessageBox.Show("Estoque informado não encontrado");
                            break;

                    }
                }
                else
                {

                    
                                           

                        lista_estoque.Add(new Estoque
                        {
                            Empresa = Convert.IsDBNull(row["CD_EMPRESA"])  ? 0 : Convert.ToInt32(row["CD_EMPRESA"]),
                            Filial = Convert.IsDBNull(row["CD_FILIAL"]) ? 0 :  Convert.ToInt32(row["CD_FILIAL"]),
                            RazaoFilial = Convert.IsDBNull(row["DS_FILIAL"]) ? "" : row["DS_FILIAL"].ToString(),
                            Produto = Convert.ToInt32(row["CODIGO"]),
                            DescricaoProduto = row["Descricao"].ToString(),
                            CodIdentificao = row["Idenfiticadao"].ToString(),
                            OrdemCompra = Convert.ToDouble(row["OrdemCompra"]),
                            OrdemProducao = Convert.ToDouble(row["OrdemProducao"]),
                            OrdemProducaoConsumo = Convert.ToDouble(row["OrdemProducaoConsumo"]),
                            Orcamento = Convert.ToDouble(row["Orcamento"]),
                            OrdemServico = Convert.ToDouble(row["OrdemServico"]),
                            Pedidos = Convert.ToDouble(row["Pedidos"]),
                            EmSeparacao = Convert.ToDouble(row["EmSeparacao"]),
                            Separado = Convert.ToDouble(row["Separado"]),
                            Requisicao = Convert.ToDouble(row["Requisicao"]),
                            EstoqueAtual = Convert.ToDouble(row["EstoqueAtual"]),                        
                            Disponivel = Convert.ToDouble(row["Disponivel"]),
                            Transferencia = Convert.ToDouble(0),
                            Almoxarifado = Convert.ToDouble(row["Almoxarifado"])

                        });

                    
                }
            }

            lista_estoque = lista_estoque.OrderBy(e => e.Filial).ToList();

            return lista_estoque;
        }

        public List<Estoque> retornarEstoqueRelatorio(Dictionary<string, object> filtroEstoque, bool Ehemseparacao, bool Ehseparado, System.Windows.Forms.Label contar)
        {

            lista_estoque.Clear();

            DataTable retornado = new DataTable();

            string sql = string.Empty;
            

            string sqlPedidos = string.Empty;
            string sqlEstoqueAtual = string.Empty;
            string sqlSeparado = string.Empty;
            string sqlEmSeparacao = string.Empty;
            string sqlDisponivel = string.Empty;

            try
            {


                sqlPedidos = (" SELECT " +
                            " 		TP.CD_EMPRESA," +
                            " 		TP.CD_FILIAL, " +
                            " 		TEF.DS_FILIAL, " +
                            " 		TPI.CD_MATERIAL as CODIGO," +                            
                            " 		TM.DS_MATERIAL AS Descricao, " +
                            "  		'' as Idenfiticadao, " +
                            " 		SUM(0) AS OrdemCompra " +
                            "  		,0 AS OrdemProducao " +
                            "        ,0 AS OrdemProducaoConsumo " +
                            "  		,0 AS Orcamento " +
                            "  		,0 AS OrdemServico " +
                            "  		,sum(TPI.NR_QUANTIDADE) as Pedidos " +
                            "  		,0 AS Requisicao " +
                            "  		,0 AS EstoqueAtual " +
                            "  		,0 AS Separado " +
                            "  		,0 AS Disponivel " +
                            "  		,0 AS Almoxarifado 	" +
                            "  		,0 AS EmSeparacao" +
                            "  	FROM TBL_PEDIDOS_ITENS TPI " +
                            " 	LEFT JOIN TBL_MATERIAIS TM ON TPI.CD_MATERIAL = TM.CD_MATERIAL " +
                            "  	LEFT JOIN TBL_PEDIDOS TP ON  TP.CD_PEDIDO = TPI.CD_PEDIDO " +
                            "  	LEFT JOIN TBL_EMPRESAS_FILIAIS TEF ON TEF.CD_FILIAL = TP.CD_FILIAL" +
                            " 	AND TP.CD_EMPRESA IS NOT NULL ");


                sqlEstoqueAtual = (" SELECT " +
                                        "        TME.CD_EMPRESA, " +
                                        "        TME.CD_FILIAL,  " +
                                        "        TEF.DS_FILIAL,  " +
                                        "        TME.CD_MATERIAL as CODIGO, " +
                                        "  		TM.DS_MATERIAL AS Descricao, " +
                                        "  		TM.CD_IDENTIFICACAO as Idenfiticadao, " +
                                        "  		SUM(0) AS OrdemCompra  " +
                                        "  		,0 AS OrdemProducao " +
                                        "        ,0 AS OrdemProducaoConsumo " +
                                        "  		,0 AS Orcamento " +
                                        "  		,0 AS OrdemServico " +
                                        "  		,0 AS Pedidos " +
                                        "  		,0 AS Requisicao " +
                                        "  		,SUM(TME.NR_ESTOQUE_DISPONIVEL) AS EstoqueAtual " +
                                        "  		,0 AS Separado " +
                                        "  		,0 AS Disponivel " +
                                        "  		,0 AS Almoxarifado " +
                                        "  		,0 AS EmSeparacao " +
                                        "     FROM TBL_MATERIAIS_ESTOQUE TME " +
                                        "  	LEFT JOIN TBL_EMPRESAS_FILIAIS TEF ON TEF.CD_FILIAL = TME.CD_FILIAL  " +
                                        "  	LEFT JOIN TBL_MATERIAIS TM ON TME.CD_MATERIAL = TM.CD_MATERIAL " +
                                        " 	LEFT JOIN TBL_PEDIDOS_ITENS ITENS ON " +
                                        " 	ITENS.CD_MATERIAL = TME.CD_MATERIAL " +
                                        " 	LEFT JOIN TBL_PEDIDOS TP ON " +
                                        " 	TP.CD_PEDIDO = ITENS.CD_PEDIDO " +
                                        " WHERE TME.NR_ESTOQUE_DISPONIVEL <> 0 "
                                        );

                                             

                if (Ehemseparacao)
                {
                    sqlEmSeparacao = (" SELECT " +
                                        "  TP.CD_EMPRESA, " +
                                        "  TP.CD_FILIAL, " +
                                        "  TEF.DS_FILIAL, " +
                                        "  TIPCE.CD_MATERIAL  as CODIGO " +
                                        "  ,TM.DS_MATERIAL AS Descricao " +
                                        "  , '' As Idenfiticadao " +
                                        "  ,0 AS OrdemCompra " +
                                        "  ,0 AS OrdemProducao  " +
                                        "  ,0 AS OrdemProducaoConsumo " +
                                        "  ,0 AS Orcamento  " +
                                        "  ,0 AS OrdemServico " +
                                        "  ,0 AS Pedidos  " +
                                        "  ,0 AS Requisicao " +
                                        "  ,0 AS EstoqueAtual " +
                                        "  ,0 AS Separado  " +
                                        "  ,0 AS Disponivel  " +
                                        "  ,0 AS Almoxarifado " +
                                        "  , 0 AS Separacao " +
                                        "  ,SUM(TIPCE.NR_QUANTIDADE) AS EmSeparacao " +
                                        "  FROM TBL_PEDIDOS_ITENS_CONTROLE_ENTREGA TIPCE " +
                                        "  LEFT JOIN TBL_MATERIAIS TM ON TIPCE.CD_MATERIAL = TM.CD_MATERIAL  " +
                                        "  LEFT JOIN TBL_PEDIDOS TP " +
                                        "  ON TIPCE.CD_PEDIDO = TP.CD_PEDIDO " +                                        
                                        "  LEFT JOIN TBL_EMPRESAS TE ON TE.CD_EMPRESA = TP.CD_EMPRESA " +
                                        "  LEFT JOIN TBL_EMPRESAS_FILIAIS TEF ON TEF.CD_FILIAL = TP.CD_FILIAL " +
                                        "  WHERE TP.CD_STATUS = 7 " +
                                        "  AND TP.CD_EMPRESA is not null " +
                                        "  AND TIPCE.X_ENTREGUE = 0 ");
                }

                if (Ehseparado) { 
                sqlSeparado = (" SELECT " +
                                "  TP.CD_EMPRESA, " +
                                "  TP.CD_FILIAL, " +
                                "  TEF.DS_FILIAL, " +
                                "  TIPCE.CD_MATERIAL  as CODIGO " +
                                "  ,TM.DS_MATERIAL AS Descricao " +
                                "  , '' As Idenfiticadao " +
                                "  ,0 AS OrdemCompra " +
                                "  ,0 AS OrdemProducao  " +
                                "  ,0 AS OrdemProducaoConsumo " +
                                "  ,0 AS Orcamento  " +
                                "  ,0 AS OrdemServico " +
                                "  ,0 AS Pedidos  " +
                                "  ,0 AS Requisicao " +
                                "  ,0 AS EstoqueAtual " +
                                "  ,0 AS EmSeparacao  " +
                                "  ,0 AS Disponivel  " +
                                "  ,0 AS Almoxarifado " +
                                "  ,SUM(TIPCE.NR_QUANTIDADE) AS Separado " +
                                "  FROM TBL_PEDIDOS_ITENS_CONTROLE_ENTREGA TIPCE " +
                                "  LEFT JOIN TBL_MATERIAIS TM ON TIPCE.CD_MATERIAL = TM.CD_MATERIAL  " +
                                "  LEFT JOIN TBL_PEDIDOS TP " +
                                "  ON TIPCE.CD_PEDIDO = TP.CD_PEDIDO " +
                                "  LEFT JOIN TBL_EMPRESAS TE ON TE.CD_EMPRESA = TP.CD_EMPRESA " +
                                "  LEFT JOIN TBL_EMPRESAS_FILIAIS TEF ON TEF.CD_FILIAL = TP.CD_FILIAL " +
                                "  WHERE TP.CD_STATUS = 7 " +
                                "  AND TP.CD_EMPRESA is not null " +
                                "  AND TIPCE.X_ENTREGUE = 1 " 
                                );

                }
                

                lista_estoque = preenchendoALista(dadosEstoque(sqlPedidos, filtroEstoque, Ehemseparacao, Ehseparado,2), 2, contar);
                                
                lista_estoque = preenchendoALista(dadosEstoque(sqlSeparado, filtroEstoque, Ehemseparacao, Ehseparado,8), 8, contar);

                //lista_estoque = preenchendoALista(dadosEstoque(sqlEmSeparacao, filtroEstoque, Ehemseparacao, Ehseparado,9), 9, contar);

                lista_estoque = preenchendoALista(dadosEstoque(sqlEstoqueAtual, filtroEstoque, Ehemseparacao, Ehseparado, 0), 0, contar);

            }
            catch (Exception ex)
            {

                MessageBox.Show("Não foi possível encontrar o estoque do produto solicitado!" + ex.Message, "Aviso Importante");
                lista_estoque.Clear();

            }

            return lista_estoque;

        }



        public List<Estoque> retornarEstoqueDisponivel(int CodProduto, System.Windows.Forms.Label contar)
        {

            lista_estoque.Clear();

            DataTable retornado = new DataTable();            

            string sql = string.Empty;

            if (CodProduto == 0) return lista_estoque ;           

            string sqlOrdemCompra = string.Empty;            
            string sqlOrdemProducao = string.Empty;
            string sqlOrdemProducaoConsumo = string.Empty;
            string sqlOrcamento = string.Empty;
            string sqlOrdemServico = string.Empty;
            string sqlPedidos = string.Empty;
            string sqlRequisicao = string.Empty; 
            string sqlEstoqueAtual = string.Empty;
            string sqlSeparado = string.Empty;
            string sqlEmSeparacao = string.Empty;
            string sqlDisponivel = string.Empty;
            string sqlAlmoxarifado = string.Empty;

            try
            {

                sqlEstoqueAtual = String.Format(" SELECT " +
                                                "       TME.CD_EMPRESA, " +
                                                "       TME.CD_FILIAL,  " +
                                                "       TEF.DS_FILIAL,  " +
                                                "       TME.CD_MATERIAL AS CODIGO , " +
                                                " 		TM.DS_MATERIAL AS Descricao, " +
                                                " 		TM.CD_IDENTIFICACAO as Idenfiticadao, " +
                                                " 		SUM(0) AS OrdemCompra  " +
                                                " 		,0 AS OrdemProducao " +
                                                "       ,0 AS OrdemProducaoConsumo " +
                                                " 		,0 AS Orcamento " +
                                                " 		,0 AS OrdemServico " +
                                                " 		,0 AS Pedidos " +
                                                " 		,0 AS Requisicao " +
                                                " 		,SUM(TME.NR_ESTOQUE_DISPONIVEL) AS EstoqueAtual " +
                                                " 		,0 AS Separado " +
                                                " 		,0 AS Disponivel " +
                                                " 		,0 AS Almoxarifado " +
                                                " 		,0 AS EmSeparacao " +
                                                "    FROM TBL_MATERIAIS_ESTOQUE TME	 " +
                                                " 	LEFT JOIN TBL_EMPRESAS_FILIAIS TEF ON TEF.CD_FILIAL = TME.CD_FILIAL  " +
                                                " 	LEFT JOIN TBL_MATERIAIS TM ON TME.CD_MATERIAL = TM.CD_MATERIAL " +
                                                " 	WHERE TME.CD_MATERIAL = {0} " +
                                                "    GROUP BY TME.CD_EMPRESA, TME.CD_FILIAL, TEF.DS_FILIAL, TME.CD_MATERIAL, TM.DS_MATERIAL, TM.CD_IDENTIFICACAO ", CodProduto);


                sqlOrdemCompra = String.Format( " SELECT " +
                                                " 	TCOC.CD_EMPRESA,  " +
                                                " 	TCOC.CD_FILIAL,  " +
                                                " 	TEF.DS_FILIAL,  " +
                                                " 	TCOCI.CD_MATERIAL AS CODIGO,  " +
                                                "   '' AS Descricao, " +
                                                "   '' as Idenfiticadao, " +
                                                " 	SUM(TCOCI.NR_QUANTIDADE) AS OrdemCompra   " +
                                                " 	,0 AS OrdemProducao " +
                                                "   ,0 AS OrdemProducaoConsumo " +
                                                " 	,0 AS Orcamento " +
                                                " 	,0 AS OrdemServico " +
                                                " 	,0 AS Pedidos " +
                                                " 	,0 AS Requisicao " +
                                                " 	,0 AS EstoqueAtual " +
                                                " 	,0 AS Separado " +
                                                " 	,0 AS Disponivel " +
                                                " 	,0 AS Almoxarifado " +
                                                " 	,0 AS EmSeparacao " +
                                                " FROM TBL_COMPRAS_ORDEM_COMPRA_ITENS TCOCI " +
                                                " LEFT JOIN TBL_COMPRAS_ORDEM_COMPRA TCOC ON TCOC.CD_ORDEM_COMPRA = TCOCI.CD_ORDEM_COMPRA " +
                                                " LEFT JOIN TBL_EMPRESAS_FILIAIS TEF ON TEF.CD_FILIAL = TCOC.CD_FILIAL " +
                                                " WHERE CD_MATERIAL = {0} " +
                                                " GROUP BY TCOC.CD_EMPRESA, TCOC.CD_FILIAL, TEF.DS_FILIAL, TCOCI.CD_MATERIAL ", CodProduto);


                sqlPedidos = String.Format( " SELECT " +
                                            "		TP.CD_EMPRESA,  " +
                                            "		TP.CD_FILIAL,  " +
                                            "		TEF.DS_FILIAL,  " +
                                            "		TPI.CD_MATERIAL AS CODIGO,  " +
                                            "		'' AS Descricao,  " +
                                            " 		'' as Idenfiticadao,  " +
                                            "		SUM(0) AS OrdemCompra    " +
                                            " 		,0 AS OrdemProducao  " +
                                            "       ,0 AS OrdemProducaoConsumo " +
                                            " 		,0 AS Orcamento  " +
                                            " 		,0 AS OrdemServico  " +
                                            " 		,sum(TPI.NR_QUANTIDADE) as Pedidos " +
                                            " 		,0 AS Requisicao  " +
                                            " 		,0 AS EstoqueAtual  " +
                                            " 		,0 AS Separado  " +
                                            " 		,0 AS Disponivel  " +
                                            " 		,0 AS Almoxarifado 	 " +
                                            " 		,0 AS EmSeparacao " +
                                            " 	FROM TBL_PEDIDOS_ITENS TPI   " +
                                            " 	LEFT JOIN TBL_PEDIDOS TP ON  TP.CD_PEDIDO = TPI.CD_PEDIDO  " +
                                            " 	LEFT JOIN TBL_EMPRESAS_FILIAIS TEF ON TEF.CD_FILIAL = TP.CD_FILIAL	 " +
                                            "	WHERE TPI.CD_MATERIAL = {0} " +
                                            "	AND TP.CD_EMPRESA IS NOT NULL " +
                                            " 	GROUP BY TP.CD_EMPRESA, TP.CD_FILIAL, TEF.DS_FILIAL, TPI.CD_MATERIAL ", CodProduto);


                sqlAlmoxarifado = string.Format(" SELECT " +
                                                "  	TMA.CD_EMPRESA, " +
                                                "  	TMA.CD_FILIAL,   " +
                                                "  	TEF.DS_FILIAL,   " +
                                                "  	TMEA.CD_MATERIAL AS CODIGO " +
                                                " 	,'' AS Descricao  " +
                                                "  	, '' As Idenfiticadao " +
                                                "  	,0 AS OrdemCompra    " +
                                                "  	,0 AS OrdemProducao  " +
                                                "   ,0 AS OrdemProducaoConsumo " +
                                                "  	,0 AS Orcamento  " +
                                                "  	,0 AS OrdemServico  " +
                                                "  	,0 AS Pedidos  " +
                                                "  	,0 AS Requisicao  " +
                                                "  	,0 AS EstoqueAtual  " +
                                                "  	,0 AS Separado  " +
                                                "  	,0 AS Disponivel  " +
                                                " 		,0 AS EmSeparacao " +
                                                "  	,SUM(TMEA.NR_ESTOQUE) AS Almoxarifado  " +
                                                "  FROM TBL_MATERIAIS_ESTOQUE_ALMOXARIFADO TMEA " +
                                                "  LEFT JOIN TBL_MATERIAIS_ALMOXARIFADO TMA  " +
                                                "  ON TMA.CD_ALMOXARIFADO = TMEA.CD_ALMOXARIFADO  " +
                                                "  LEFT JOIN TBL_EMPRESAS TE ON TE.CD_EMPRESA = TMA.CD_EMPRESA " +
                                                "  LEFT JOIN TBL_EMPRESAS_FILIAIS TEF ON TEF.CD_FILIAL = TMA.CD_FILIAL   " +
                                                "  whERE CD_MATERIAL = {0} " +
                                                "  GROUP BY TMA.CD_EMPRESA, TMA.CD_FILIAL,TEF.DS_FILIAL, TMEA.CD_MATERIAL ", CodProduto);

                sqlOrdemProducaoConsumo = String.Format(" SELECT " +
                                                        " 	TOPR.CD_EMPRESA, " +
                                                        " 	TOPR.CD_FILIAL,   " +
                                                        " 	TEF.DS_FILIAL,   " +
                                                        " 	TOPC.CD_MATERIAL AS CODIGO " +
                                                        " 	,'' AS Descricao  " +
                                                        " 	, '' As Idenfiticadao " +
                                                        " 	,0 AS OrdemCompra  " +
                                                        " 	,0 AS OrdemProducao " +
                                                        " 	,sum(TOPC.NR_QUANTIDADE_APONTADA) AS OrdemProducaoConsumo " +
                                                        " 	,0 AS Orcamento  " +
                                                        " 	,0 AS OrdemServico  " +
                                                        " 	,0 AS Pedidos  " +
                                                        " 	,0 AS Requisicao  " +
                                                        " 	,0 AS EstoqueAtual  " +
                                                        " 	,0 AS Separado  " +
                                                        " 	,0 AS Disponivel  " +
                                                        " 	,0 AS Almoxarifado  " +
                                                        " 		,0 AS EmSeparacao " +
                                                        " FROM TBL_ORDEM_PRODUCAO_CONSUMO TOPC " +
                                                        " LEFT JOIN TBL_ORDEM_PRODUCAO TOPR  " +
                                                        " ON TOPR.CD_ENTRADA = TOPC.CD_ENTRADA  " +
                                                        " AND TOPR.CD_STATUS = 1 " +
                                                        " LEFT JOIN TBL_EMPRESAS TE ON TE.CD_EMPRESA = TOPR.CD_EMPRESA " +
                                                        " LEFT JOIN TBL_EMPRESAS_FILIAIS TEF ON TEF.CD_FILIAL = TOPR.CD_FILIAL " +
                                                        " whERE CD_MATERIAL = {0} " +
                                                        " AND TOPR.CD_EMPRESA is not null " +
                                                        " GROUP BY TOPR.CD_EMPRESA, TOPR.CD_FILIAL,TEF.DS_FILIAL, TOPC.CD_MATERIAL ", CodProduto);


                sqlOrdemProducao = String.Format(" SELECT " +
                                                " 	TOPR.CD_EMPRESA, " +
                                                " 	TOPR.CD_FILIAL,   " +
                                                " 	TEF.DS_FILIAL,   " +
                                                " 	TOPC.CD_MATERIAL AS CODIGO " +
                                                " 	,'' AS Descricao  " +
                                                " 	, '' As Idenfiticadao " +
                                                " 	,0 AS OrdemCompra  " +
                                                " 	,SUM(NR_QUANTIDADE_PRODUZIDA) AS OrdemProducao" +
                                                " 	,0 AS OrdemProducaoConsumo " +
                                                " 	,0 AS Orcamento  " +
                                                " 	,0 AS OrdemServico  " +
                                                " 	,0 AS Pedidos  " +
                                                " 	,0 AS Requisicao  " +
                                                " 	,0 AS EstoqueAtual  " +
                                                " 	,0 AS Separado  " +
                                                " 	,0 AS Disponivel  " +
                                                " 	,0 AS Almoxarifado  " +
                                                " 		,0 AS EmSeparacao " +
                                                " FROM TBL_ORDEM_PRODUCAO_PRODUTO_PRODUZIDO TOPC " +
                                                " LEFT JOIN TBL_ORDEM_PRODUCAO TOPR  " +
                                                " ON TOPR.CD_ENTRADA = TOPC.CD_ENTRADA  " +
                                                " AND TOPR.CD_STATUS = 1 " +
                                                " LEFT JOIN TBL_EMPRESAS TE ON TE.CD_EMPRESA = TOPR.CD_EMPRESA " +
                                                " LEFT JOIN TBL_EMPRESAS_FILIAIS TEF ON TEF.CD_FILIAL = TOPR.CD_FILIAL " +
                                                " whERE CD_MATERIAL = {0} " +
                                                " AND TOPR.CD_EMPRESA is not null " +
                                                " GROUP BY TOPR.CD_EMPRESA, TOPR.CD_FILIAL,TEF.DS_FILIAL, TOPC.CD_MATERIAL "
                                                , CodProduto);

                sqlOrcamento = String.Format(" SELECT " +
                                            " 	TOPR.CD_EMPRESA, " +
                                            " 	TOPR.CD_FILIAL,   " +
                                            " 	TEF.DS_FILIAL,   " +
                                            " 	TOPC.CD_MATERIAL AS CODIGO " +
                                            " 	,'' AS Descricao  " +
                                            " 	, '' As Idenfiticadao " +
                                            " 	,0 AS OrdemCompra  " +
                                            " 	,0 AS OrdemProducaoo " +
                                            " 	,0 AS OrdemProducaoConsumo " +
                                            " 	,SUM(TOPC.NR_QUANTIDADE) AS Orcamento   " +
                                            " 	,0 AS OrdemServico  " +
                                            " 	,0 AS Pedidos  " +
                                            " 	,0 AS Requisicao  " +
                                            " 	,0 AS EstoqueAtual  " +
                                            " 	,0 AS Separado  " +
                                            " 	,0 AS Disponivel  " +
                                            " 	,0 AS Almoxarifado  " +
                                            " 		,0 AS EmSeparacao " +
                                            " FROM TBL_ORCAMENTOS_ITENS TOPC " +
                                            " LEFT JOIN TBL_ORCAMENTOS TOPR  " +
                                            " ON TOPR.CD_ORCAMENTO = TOPC.CD_ORCAMENTO  " +
                                            " AND TOPR.CD_STATUS = 1 " +
                                            " LEFT JOIN TBL_EMPRESAS TE ON TE.CD_EMPRESA = TOPR.CD_EMPRESA " +
                                            " LEFT JOIN TBL_EMPRESAS_FILIAIS TEF ON TEF.CD_FILIAL = TOPR.CD_FILIAL " +
                                            " whERE CD_MATERIAL = {0} " +
                                            " AND TOPR.CD_EMPRESA is not null " +
                                            " GROUP BY TOPR.CD_EMPRESA, TOPR.CD_FILIAL,TEF.DS_FILIAL, TOPC.CD_MATERIAL ", CodProduto);

                sqlOrdemServico = String.Format("", CodProduto);

                sqlEmSeparacao = String.Format(" SELECT  " +
                                                " TP.CD_EMPRESA,  " +
                                                "  TP.CD_FILIAL,  " +
                                                "  TEF.DS_FILIAL,  " +
                                                "  TPI.CD_MATERIAL  AS CODIGO  " +
                                                "  ,'' AS Descricao  " +
                                                "  , '' As Idenfiticadao   " +
                                                "  ,0 AS OrdemCompra    " +
                                                "  ,0 AS OrdemProducao   " +
                                                "  ,0 AS OrdemProducaoConsumo  " +
                                                "  ,0 AS Orcamento  " +
                                                "  ,0 AS OrdemServico  " +
                                                "  ,0 AS Pedidos  " +
                                                "  ,0 AS Requisicao   " +
                                                "  ,0 AS EstoqueAtual    " +
                                                "  ,0 AS Separado   " +
                                                "  ,0 AS Disponivel  "+ 
                                                "  ,0 AS Almoxarifado  " +
                                                "  , 0 AS Separaco   " +
                                                "  ,SUM(TPI.NR_QUANTIDADE-(IIF(TIPCE.NR_QUANTIDADE IS NULL, 0 , TIPCE.NR_QUANTIDADE))) AS EmSeparacao   " +
                                                "  FROM TBL_PEDIDOS_ITENS TPI   " +
                                                "  LEFT JOIN TBL_PEDIDOS TP    " +
                                                "  ON TPI.CD_PEDIDO = TP.CD_PEDIDO    " +
                                                "  LEFT JOIN TBL_PEDIDOS_ITENS_CONTROLE_ENTREGA TIPCE  " +
                                                "  ON TIPCE.CD_PEDIDO = TPI.CD_PEDIDO  " +
                                                "  AND TIPCE.CD_MATERIAL = TPI.CD_MATERIAL  " +
                                                "  LEFT JOIN TBL_EMPRESAS TE ON TE.CD_EMPRESA = TP.CD_EMPRESA  " +
                                                "  LEFT JOIN TBL_EMPRESAS_FILIAIS TEF ON TEF.CD_FILIAL = TP.CD_FILIAL   " +
                                                "  WHERE TPI.CD_MATERIAL = {0}     " +
                                                "  AND TP.CD_EMPRESA is not null   " +
                                                "  AND TP.CD_STATUS = 7   " +
                                                "  GROUP BY TP.CD_EMPRESA, TP.CD_FILIAL,TEF.DS_FILIAL, TPI.CD_MATERIAL", CodProduto);


                sqlSeparado = String.Format("SELECT " +
                                            " TP.CD_EMPRESA, " +
                                            " TP.CD_FILIAL, " +
                                            " TEF.DS_FILIAL, " +
                                            " TIPCE.CD_MATERIAL  AS CODIGO " +
                                            " ,'' AS Descricao " +
                                            " , '' As Idenfiticadao " +
                                            " ,0 AS OrdemCompra " +
                                            " ,0 AS OrdemProducaoo  " +
                                            " ,0 AS OrdemProducaoConsumo " +
                                            " ,0 AS Orcamento  " +
                                            " ,0 AS OrdemServico  " +
                                            " ,0 AS Pedidos  " +
                                            " ,0 AS Requisicao  " +
                                            " ,0 AS EstoqueAtual " +
                                            " ,0 AS Separa  " +
                                            " ,0 AS Disponivel  " +
                                            " ,0 AS Almoxarifado   " +
                                            " 		,0 AS EmSeparacao " +
                                            " ,SUM(TIPCE.NR_QUANTIDADE) AS Separado " +
                                            " FROM TBL_PEDIDOS_ITENS_CONTROLE_ENTREGA TIPCE " +
                                            " INNER JOIN TBL_PEDIDOS TP    " +
                                            " ON TIPCE.CD_PEDIDO = TP.CD_PEDIDO " +
                                            " AND TP.CD_STATUS = 7  " +
                                            " LEFT JOIN TBL_EMPRESAS TE ON TE.CD_EMPRESA = TP.CD_EMPRESA " +
                                            " LEFT JOIN TBL_EMPRESAS_FILIAIS TEF ON TEF.CD_FILIAL = TP.CD_FILIAL " +
                                            " WHERE CD_MATERIAL = {0}  " +
                                            " AND TP.CD_EMPRESA is not null  " +
                                            " AND TIPCE.X_ENTREGUE = 1 " +
                                            " GROUP BY TP.CD_EMPRESA, TP.CD_FILIAL,TEF.DS_FILIAL, TIPCE.CD_MATERIAL ", CodProduto);

                
                
                
                lista_estoque = preenchendoALista(dados(sqlEstoqueAtual), 0, contar);

                lista_estoque = preenchendoALista(dados(sqlOrdemCompra), 1, contar);

                lista_estoque = preenchendoALista(dados(sqlPedidos), 2, contar);

                lista_estoque = preenchendoALista(dados(sqlAlmoxarifado), 3, contar);

                lista_estoque = preenchendoALista(dados(sqlOrdemProducaoConsumo), 4, contar);

                lista_estoque = preenchendoALista(dados(sqlOrdemProducao), 5, contar    );

                lista_estoque = preenchendoALista(dados(sqlOrcamento), 6, contar    );

                //lista_estoque = preenchendoALista(dados(sqlOrdemServico), 7);

                lista_estoque = preenchendoALista(dados(sqlSeparado), 8, contar);

                lista_estoque = preenchendoALista(dados(sqlEmSeparacao), 9, contar);

            }
            catch (Exception ex) {

                MessageBox.Show("Não foi possível encontrar o estoque do produto solicitado!\n" + ex.Message, "Aviso Importante");
                lista_estoque.Clear();

            }

            return lista_estoque;
            
        }

        public void PreencherGradeEstoque(System.Windows.Forms.DataGridView grade, List<Estoque> lista)
        {

            
            grade.Rows.Clear();
            int item = 0;

            Util.FormatacaoGrade formatar = new Util.FormatacaoGrade();

            formatar.formatargradeEstoque(grade);

            try
            {
                if (lista.Count > 0) {

                    while (item < lista.Count) {

                        double OrdemDeCompra = (lista[item].OrdemCompra + (
                                       (lista[item].Almoxarifado < 0 ? (lista[item].Almoxarifado * (-1)) : 0)));

                        grade.Rows.Add(lista[item].Filial.ToString() + " - "+ lista[item].RazaoFilial.ToString()
                                       , lista[item].CodIdentificao.ToString()
                                       , Convert.ToDouble(lista[item].OrdemCompra + ((lista[item].Almoxarifado < 0 ? (lista[item].Almoxarifado * (-1)) : 0))).ToString("N4")
                                       , Convert.ToDouble(lista[item].OrdemProducaoConsumo).ToString("N4")
                                       , Convert.ToDouble(lista[item].OrdemProducao).ToString("N4")
                                       , Convert.ToDouble(lista[item].Orcamento).ToString("N4")
                                       , Convert.ToDouble(lista[item].OrdemServico).ToString("N4")
                                       , Convert.ToDouble(lista[item].Pedidos).ToString("N4")
                                       , Convert.ToDouble(lista[item].EmSeparacao).ToString("N4")
                                       , Convert.ToDouble(lista[item].Separado).ToString("N4")
                                       , Convert.ToDouble(lista[item].EstoqueAtual).ToString("N4")
                                       , Convert.ToDouble((lista[item].OrdemCompra +
                                                          lista[item].EstoqueAtual +
                                                          lista[item].OrdemProducao + lista[item].Separado + 
                                                          (lista[item].Almoxarifado < 0 ? 0 : (lista[item].Almoxarifado * (-1))))
                                                         -
                                                         (
                                                          lista[item].Pedidos +
                                                          (lista[item].Almoxarifado < 0 ? (lista[item].Almoxarifado * (-1)) : 0) +
                                                          lista[item].OrdemProducaoConsumo +
                                                          lista[item].Orcamento
                                                         )).ToString("N4")
                                        , Convert.ToDouble((lista[item].OrdemCompra +
                                                          lista[item].EstoqueAtual +
                                                          lista[item].OrdemProducao + lista[item].Separado +
                                                          (lista[item].Almoxarifado < 0 ? 0 : (lista[item].Almoxarifado * (-1))))
                                                         -
                                                         (
                                                          lista[item].Pedidos +
                                                          (lista[item].Almoxarifado < 0 ? (lista[item].Almoxarifado * (-1)) : 0) +
                                                          lista[item].OrdemProducaoConsumo +
                                                          lista[item].Orcamento
                                                         )).ToString("N4")
                                      );

                        

                        item++;
                    }
                    item = 0;                   

                }else
                {

                    //MessageBox.Show("Estoque não encontrado","Aviso Importante");
                }



            }
            catch (Exception ex) {

                MessageBox.Show("Ocorreu um problema ao tentar trazer o estoque \n" + ex.Message, "Estoque Aviso Importante");

            }
        }

        private void grade_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            throw new NotImplementedException();
        }

        public DataTable retornaDadosProduto(Dictionary<string, object> filtros = null)
        {
            DataTable ret = new DataTable();

            var bco = new BancoDeDados().lerXMLConfiguracao();

            string ordem = " ORDER BY CD_MATERIAL";

            try
            {
                string sql = " SELECT " +
                " CD_MATERIAL " +
                " , M.CD_IDENTIFICACAO " +
                " , M.DS_MATERIAL_NF " +
                " , MM.DS_MARCA " +
                " ,NR_ESTOQUE_DISPONIVEL " +
                " ,VL_VENDA " +
                " ,VL_CUSTO_REPOSICAO " +
                " ,CD_CEST " +
                " FROM TBL_MATERIAIS M " +
                " LEFT JOIN TBL_MATERIAIS_MARCA MM ON MM.CD_MARCA = M.CD_MARCA " +
                " WHERE M.X_ATIVO = 1 " +
                " AND X_SERVICO = 0 ";

                if (filtros != null)
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

                        sql += chave + " LIKE  '" + valor + "'";
                    }
                }
                

                sql += ordem;

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
                                adaptador.Fill(ret);
                            }
                        }
                    }

                    if (cnn.State == ConnectionState.Open) bco.desconectar(cnn);
                }
            }
            catch (Exception ex) {

                ret = null;
                MessageBox.Show(ex.Message, "[PRODUTO] - Aviso Importante");                
            }

            return ret;
        }

    }
}
