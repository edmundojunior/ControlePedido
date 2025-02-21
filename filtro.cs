using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePedido
{
    public class filtro
    {
        public class filtrarPedidos
        {
            public string RetornaCampo(string campo = null)
            {
                string retorno = string.Empty;

                if (campo != null)
                {
                    if (campo == "CÓDIGO") retorno = "CD_PEDIDO";
                    if (campo == "VENDEDOR") retorno = "VEN.DS_ENTIDADE";
                    if (campo == "CLIENTE") retorno = "CL.DS_ENTIDADE";
                    if (campo == "STATUS") retorno = "ST.DS_STATUS";
                    if (campo == "CIDADE") retorno = "CID.DS_CIDADE";
                    if (campo == "CNPJ CLIENTE") retorno = "CL.NR_CPFCNPJ";
                    if (campo == "OBSERVAÇÕES") retorno = "PED.DS_OBS";
                    if (campo == "OBSERVAÇOES INTERNAS") retorno = "PED.DS_OBS_INTERNA";
                    if (campo == "NR. ORDEM DE COMPRA") retorno = "CD_PEDIDO";
                    if (campo == "CÓDIGO CLIENTE") retorno = "PED.CD_ENTIDADE";
                    

                }

                return retorno;
            }


            public string RetornaCampoProduto(string campo = null)
            {
                string retorno = string.Empty;

                if (campo != null)
                {
                    if (campo == "CÓDIGO") retorno = "CD_MATERIAL";
                    if (campo == "IDENTIFICAÇÃO") retorno = "CD_IDENTIFICACAO";
                    if (campo == "DESCRIÇÃO DO PRODUTO") retorno = "CL.DS_MATERIAL_NF";
                    if (campo == "MARCA") retorno = "DS_MARCA";
                    if (campo == "CEST") retorno = "CD_CEST";                   

                }

                return retorno;
            }
            public Dictionary<string, object> filtro(DateTime dtInicial, DateTime dtFinal,string Metodo, string campo = "", string Conteudo = "" )
            {
                Dictionary<string, object> retorno = new Dictionary<string, object>();

                if (Conteudo == "")
                {
                    var filtros = new Dictionary<string, object>
                    {
                        { "DataInicio", new DateTime(dtInicial.Year, dtInicial.Month, dtInicial.Day) },
                        { "DataFim", new DateTime(dtFinal.Year, dtFinal.Month, dtFinal.Day) }

                    };                    

                    retorno = filtros;

                }else
                {

                    if (Metodo == "INICIADO EM")
                    {
                        var filtros = new Dictionary<string, object>
                        {

                            { RetornaCampo(campo), Conteudo.ToUpper() + "%"},
                            { "DataInicio", new DateTime(dtInicial.Year, dtInicial.Month, dtInicial.Day) },
                            { "DataFim", new DateTime(dtFinal.Year, dtFinal.Month, dtFinal.Day) }

                        };

                        retorno = filtros;
                    }
                    else
                    {
                        var filtros = new Dictionary<string, object>
                        {
                            { RetornaCampo(campo), Conteudo.ToUpper() },
                            { "DataInicio", new DateTime(dtInicial.Year, dtInicial.Month, dtInicial.Day) },
                            { "DataFim", new DateTime(dtFinal.Year, dtFinal.Month, dtFinal.Day) }

                        };

                        retorno = filtros;
                    }                        
                }

                return retorno;
            }

            public Dictionary<string, object> filtroProduto(string Metodo, string campo = "", string Conteudo = "")
            {
                Dictionary<string, object> retorno = new Dictionary<string, object>();

                if (Conteudo == "")
                {
                   
                    retorno = null;

                }
                else
                {

                    if (Metodo == "INICIADO EM")
                    {
                        var filtros = new Dictionary<string, object>
                        {

                            { RetornaCampoProduto(campo), Conteudo.ToUpper() + "%"},
                            
                        };

                        retorno = filtros;
                    }
                    else
                    {
                        var filtros = new Dictionary<string, object>
                        {
                            { RetornaCampoProduto(campo), Conteudo.ToUpper() },
                            
                        };

                        retorno = filtros;
                    }
                }

                return retorno;
            }

        }

    }
}
