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
    public partial class frmLocalizarAll : frmBase
    {
        public int Codigo;
        public string EstadoSelecionado;
        public string descricao;
        private int _oQueLocalizar;
        private string _sql = string.Empty;
        private string campo = null;
        private string Conteudo = null;

        public frmLocalizarAll(int oQueLocalizar)
        {
            InitializeComponent();
            usMenu1.CloseButtonClicked += UsMenu1_CloseButtonClicked;
            usMenu1.FiltroButtonClicked += usMenu1_FiltroButtonClicked;            
            usMenu1.CancelarButtonClicked += usMenu1_CancelarButtonClicked;
            usMenu1.LocalizarButtonClicked += usMenu1_LocalizarButtonClicked;
            usMenu1.ConfirmarButtonClicked += usMenu1_ConfirmarButtonClicked;
            _oQueLocalizar = oQueLocalizar;
            reset();
        }

        private void usMenu1_LocalizarButtonClicked(object sender, EventArgs e)
        {
            reset();

            filtrar(null);

            if (grade.Rows.Count >= 2)
            {
                usMenu1.SetButtonEnabled("Confirmar", true);
            }
            else
            {
                usMenu1.SetButtonEnabled("Confirmar", false);
            }

        }

        private void UsMenu1_CloseButtonClicked(object sender, EventArgs e)
        {
            Close();    
        }

        private void usMenu1_FiltroButtonClicked(object sender, EventArgs e)
        {
            frmFiltro frm = new frmFiltro(2);
            frm.ShowDialog();
            campo = frm.campo;
            Conteudo = frm.conteudo; 


        }

        private void usMenu1_CancelarButtonClicked(object sender, EventArgs e)
        {
            reset();
        }

        private void usMenu1_ConfirmarButtonClicked(object sender, EventArgs e)
        {
            if (grade.CurrentRow != null)
            {
                // Obtém o valor da célula na coluna "CodPedido"
                object codPedidos = grade.CurrentRow.Cells[0].Value;

                // Verifica se o valor não é nulo
                if (codPedidos != null)
                {
                    Codigo = Convert.ToInt32(codPedidos);

                    if (_oQueLocalizar == 11)
                    {
                        EstadoSelecionado = grade.CurrentRow.Cells[0].Value.ToString();
                    }
                    else
                    {
                        Codigo = Convert.ToInt32(grade.CurrentRow.Cells[0].Value);
                    }
                    // Captura o valor da primeira coluna da linha clicada

                    if (-_oQueLocalizar == 0 || _oQueLocalizar == 1)
                    {
                        descricao = grade.CurrentRow.Cells[1].Value.ToString();
                    }
                    Close();
                }
                else
                {
                    MessageBox.Show("Valor inválido", "Aviso");
                }
            }
            else
            {
                MessageBox.Show("Nenhuma linha está selecionada.", "Erro");
            }
        }

        


        private void frmLocalizarAll_Load(object sender, EventArgs e)
        {

        }
        private void reset()
        {

            usMenu1.SetButtonEnabled("Localizar", true);
            usMenu1.SetButtonEnabled("Confirmar", false);
            usMenu1.SetButtonEnabled("Imprimir", false);
            usMenu1.SetButtonEnabled("Atualizar", false);
            usMenu1.SetButtonEnabled("Filtro", true);
            usMenu1.SetButtonEnabled("Salvar", false);
            usMenu1.SetButtonEnabled("Novo", false);
            usMenu1.SetButtonEnabled("Editar", false);
            usMenu1.SetButtonEnabled("Excluir", false);
            usMenu1.SetButtonEnabled("Executar", false);
            usMenu1.SetButtonEnabled("Primeiro", false);
            usMenu1.SetButtonEnabled("Anterior", false);
            usMenu1.SetButtonEnabled("Proximo", false);
            usMenu1.SetButtonEnabled("Ultimo", false);

            switch (_oQueLocalizar)
            {
                case 0: //Empresa
                    usBarraTitulo1.valor = "Localizar Empresa";
                    break;
                case 1: //Filial
                    usBarraTitulo1.valor = "Localizar Filial";
                    break;
                case 2: //Cliente
                    usBarraTitulo1.valor = "Localizar Cliente ";
                    break;
                case 3: //Vendedor
                    usBarraTitulo1.valor = "Localizar Vendedor ";
                    break;
                case 4: //Transportador
                    usBarraTitulo1.valor = "Localizar Transportador ";
                    break;
                case 5: //Região
                    usBarraTitulo1.valor = "Localizar Região ";
                    break;
                case 6: //Carteira
                    usBarraTitulo1.valor = "Localizar Carteira ";
                    break;
                case 7: //Forma de Pagamento
                    usBarraTitulo1.valor = "Localizar Forma de Pagamento ";
                    break;
                case 8: //Produto
                    usBarraTitulo1.valor = "Localizar Produtos ";
                    break;
                case 9: //serviço
                    usBarraTitulo1.valor = "Localizar Serviços ";
                    break;
                case 10: //Cidade
                    usBarraTitulo1.valor = "Localizar Cidades ";
                    break;
                case 11: //estado
                    usBarraTitulo1.valor = "Localizar Estados ";
                    break;
                case 12: //grupo produto
                    usBarraTitulo1.valor = "Localizar Grupo Produto ";
                    break;
                case 13: //subgrupo produto
                    usBarraTitulo1.valor = "Localizar SubGrupo Produto ";
                    break;
                case 14: //Marca
                    usBarraTitulo1.valor = "Localizar Marca ";
                    break;
                case 15: //Tipo Produto
                    usBarraTitulo1.valor = "Localizar Tipo Produto ";
                    break;
                case 16: //Tipo Produto
                    usBarraTitulo1.valor = "Localizar Tipo Entidade ";
                    break;
                case 17: //Tipo Produto
                    usBarraTitulo1.valor = "Localizar Classificação da Entidade ";
                    break;
                case 18: //Tipo Produto
                    usBarraTitulo1.valor = "Localizar STATUS ";
                    break;
                case 19: //Tipo Produto
                    usBarraTitulo1.valor = "Localizar Tipo de Pedido ";
                    break;
                case 20: //Tipo Produto
                    usBarraTitulo1.valor = "Localizar Fornecedor ";
                    break;
                case 21: //Tipo Produto
                    usBarraTitulo1.valor = "Localizar Tipo Embalagem ";
                    break;
                case 22: //Tipo Produto
                    usBarraTitulo1.valor = "Localizar Indicador de Venda ";
                    break;
                case 23: //Tipo Produto
                    usBarraTitulo1.valor = "Localizar Obras ";
                    break;
                case 24: //Tipo Produto
                    usBarraTitulo1.valor = "Localizar Fretes ";
                    break;
                case 25: //Tipo Produto
                    usBarraTitulo1.valor = "Localizar Código Campanha/Promoção ";
                    break;
                default:
                    break;  
            }

            grade.Columns.Clear();

        }


        private void filtrar(Dictionary<string, object> filtros = null)
        {
            if (filtros == null)
            {
                switch (_oQueLocalizar)
                {
                    case 0: //Empresa                      

                        empresa(filtros);
                        break;
                    case 1: //Filial                   

                        filial(filtros);
                        break;
                    case 2: //CLiente 
                        Entidade(filtros,0);
                        break;
                    case 3: //Vendedor 
                        Entidade(filtros, 1);
                        break;
                    case 4: //Transportador 
                        Entidade(filtros, 2);
                        break;
                    case 5: //Regiao 
                        regiao(filtros);
                        break;
                    case 6: //Carteira 
                        carteira(filtros);
                        break;
                    case 7: //Forma de Pagamento 
                        formaPagto(filtros);
                        break;
                    case 8: //Produtos 
                        ProdutoServico(filtros, true );
                        break;
                    case 9: //Serviços 
                        ProdutoServico(filtros, false);
                        break;
                    case 10: //Cidade 
                        cidade(filtros);
                        break;
                    case 11: //estado 
                        estado(filtros);
                        break;
                    case 12: //estado 
                        grupoProduto(filtros);
                        break;
                    case 13: //estado 
                        subGrupoProduto(filtros);
                        break;
                    case 14: //estado 
                        Marca(filtros);
                        break;
                    case 15: //estado 
                        TipoProduto(filtros);
                        break;
                    case 16: //estado 
                        TipoEntidade(filtros);
                        break;
                    case 17: //estado 
                        classificaoEntidade(filtros);
                        break;
                    case 18: //estado 
                        statusGlobal(filtros);
                        break;
                    case 19: //estado 
                        tipoPedido(filtros);
                        break;
                    case 20: //Transportador 
                        Entidade(filtros, 3);
                        break;
                    case 21: //Transportador 
                        tipoEmbalagem(filtros);
                        break;
                    case 22: //Transportador 
                        Entidade(filtros, 2);
                        break;
                    case 23: //Transportador 
                        obra(filtros);
                        break;
                    case 24: //Transportador 
                        fretes(filtros);
                        break;
                    case 25: //Transportador 
                        promocao(filtros);
                        break;
                    default:
                        break;


                }
            }
            else
            {
                switch (_oQueLocalizar)
                {
                    case 0: //Empresa
                        filtros = new Dictionary<string, object>
                        {
                            { retornaCampo(campo), Conteudo.ToUpper() },

                        };
                        empresa(filtros);
                        break;
                    case 1: //Filial
                        filtros = new Dictionary<string, object>
                        {
                            { retornaCampo(campo), Conteudo.ToUpper() },
                        };
                        filial(filtros);
                        break;
                    case 2: //Cliente
                        filtros = new Dictionary<string, object>
                        {
                            { retornaCampo(campo), Conteudo.ToUpper() },
                        };
                        Entidade(filtros,0);
                        break;
                    case 3: //Vendedor
                        filtros = new Dictionary<string, object>
                        {
                            { retornaCampo(campo), Conteudo.ToUpper() },
                        };
                        Entidade(filtros, 1);
                        break;
                    case 4: //TRansportador
                        filtros = new Dictionary<string, object>
                        {
                            { retornaCampo(campo), Conteudo.ToUpper() },
                        };
                        Entidade(filtros, 2);
                        break;
                    case 5: //TRansportador
                        filtros = new Dictionary<string, object>
                        {
                            { retornaCampo(campo), Conteudo.ToUpper() },
                        };
                        regiao(filtros);
                        break;
                    case 6: //Carteira
                        filtros = new Dictionary<string, object>
                        {
                            { retornaCampo(campo), Conteudo.ToUpper() },
                        };
                        carteira(filtros);
                        break;
                    case 7: //Forma de Pagamento
                        filtros = new Dictionary<string, object>
                        {
                            { retornaCampo(campo), Conteudo.ToUpper() },
                        };
                        formaPagto(filtros);
                        break;
                    case 8: //produto
                        filtros = new Dictionary<string, object>
                        {
                            { retornaCampo(campo), Conteudo.ToUpper() },
                        };
                        ProdutoServico(filtros, true);
                        break;
                    case 9: //serviço
                        filtros = new Dictionary<string, object>
                        {
                            { retornaCampo(campo), Conteudo.ToUpper() },
                        };
                        ProdutoServico(filtros, false); 
                        break;
                    case 10: //Cidade
                        filtros = new Dictionary<string, object>
                        {
                            { retornaCampo(campo), Conteudo.ToUpper() },
                        };
                        cidade(filtros);
                        break;
                    case 11: //Estado
                        filtros = new Dictionary<string, object>
                        {
                            { retornaCampo(campo), Conteudo.ToUpper() },
                        };
                        estado(filtros);
                        break;
                    case 12: //Grupo Produto
                        filtros = new Dictionary<string, object>
                        {
                            { retornaCampo(campo), Conteudo.ToUpper() },
                        };
                        grupoProduto(filtros);
                        break;
                    case 13: //Grupo Produto
                        filtros = new Dictionary<string, object>
                        {
                            { retornaCampo(campo), Conteudo.ToUpper() },
                        };
                        subGrupoProduto(filtros);
                        break;
                    case 14: //Grupo Produto
                        filtros = new Dictionary<string, object>
                        {
                            { retornaCampo(campo), Conteudo.ToUpper() },
                        };
                        Marca(filtros);
                        break;
                    case 15: //Grupo Produto
                        filtros = new Dictionary<string, object>
                        {
                            { retornaCampo(campo), Conteudo.ToUpper() },
                        };
                        TipoProduto(filtros);
                        break;
                    case 16: //Grupo Produto
                        filtros = new Dictionary<string, object>
                        {
                            { retornaCampo(campo), Conteudo.ToUpper() },
                        };
                        TipoEntidade(filtros);
                        break;
                    case 17: //Grupo Produto
                        filtros = new Dictionary<string, object>
                        {
                            { retornaCampo(campo), Conteudo.ToUpper() },
                        };
                        classificaoEntidade(filtros);
                        break;
                    case 18: //Grupo Produto
                        filtros = new Dictionary<string, object>
                        {
                            { retornaCampo(campo), Conteudo.ToUpper() },
                        };
                        statusGlobal(filtros);
                        break;
                    case 19: //Grupo Produto
                        filtros = new Dictionary<string, object>
                        {
                            { retornaCampo(campo), Conteudo.ToUpper() },
                        };
                        tipoPedido(filtros);
                        break;
                    case 20: //Grupo Produto
                        filtros = new Dictionary<string, object>
                        {
                            { retornaCampo(campo), Conteudo.ToUpper() },
                        };
                        Entidade(filtros, 3);
                        break;
                    case 21: //Grupo Produto
                        filtros = new Dictionary<string, object>
                        {
                            { retornaCampo(campo), Conteudo.ToUpper() },
                        };
                        tipoEmbalagem(filtros);
                        break;
                    case 22: //Grupo Produto
                        filtros = new Dictionary<string, object>
                        {
                            { retornaCampo(campo), Conteudo.ToUpper() },
                        };
                        Entidade(filtros, 2);
                        break;
                    case 23: //Obra
                        filtros = new Dictionary<string, object>
                        {
                            { retornaCampo(campo), Conteudo.ToUpper() },
                        };
                        obra(filtros);
                        break;
                    case 24: //frete
                        filtros = new Dictionary<string, object>
                        {
                            { retornaCampo(campo), Conteudo.ToUpper() },
                        };
                        fretes(filtros);
                        break;
                    case 25: //frete
                        filtros = new Dictionary<string, object>
                        {
                            { retornaCampo(campo), Conteudo.ToUpper() },
                        };
                        promocao(filtros);
                        break;
                    default: 
                        break;


                }
            }
        }

        private string retornaCampo(string campo)
        {
            string retorno  = string.Empty;


             switch (_oQueLocalizar)
            {
                case 0://Empresa
                    if (campo != null)
                    {
                        if (campo == "CÓDIGO") retorno = "CD_EMPRESA";
                        if (campo == "DESCRIÇÃO") retorno = "DS_EMPRESA";
                    }
                    break;
                case 1://Filial
                    if (campo != null)
                    {
                        if (campo == "CÓDIGO") retorno = "CD_FILIAL";
                        if (campo == "DESCRIÇÃO") retorno = "DS_FILIAL";
                    }
                    break;
                case 2://Cliente 
                    if (campo != null)
                    {
                        if (campo == "CÓDIGO") retorno = "CD_ENTIDADE";
                        if (campo == "DESCRIÇÃO") retorno = "DS_ENTIDADE";
                    }
                    break;
                case 3://Vendedor 
                    if (campo != null)
                    {
                        if (campo == "CÓDIGO") retorno = "CD_ENTIDADE";
                        if (campo == "DESCRIÇÃO") retorno = "DS_ENTIDADE";
                    }
                    break;
                case 4://Transportador 
                    if (campo != null)
                    {
                        if (campo == "CÓDIGO") retorno = "CD_ENTIDADE";
                        if (campo == "DESCRIÇÃO") retorno = "DS_ENTIDADE";
                    }
                    break;
                case 5://Transportador 
                    if (campo != null)
                    {
                        if (campo == "CÓDIGO") retorno = "CD_REGIAO";
                        if (campo == "DESCRIÇÃO") retorno = "DS_REGIAO";
                    }
                    break;
                case 6://Carteira
                    if (campo != null)
                    {
                        if (campo == "CÓDIGO") retorno = "CD_CARTEIRA";
                        if (campo == "DESCRIÇÃO") retorno = "DS_CARTEIRA";
                    }
                    break;
                case 7://Carteira
                    if (campo != null)
                    {
                        if (campo == "CÓDIGO") retorno = "CD_FORMA_PAGAMENTO";
                        if (campo == "DESCRIÇÃO") retorno = "DS_FORMA_PAGAMENTO";
                    }
                    break;
                case 8://Produto
                    if (campo != null)
                    {
                        if (campo == "CÓDIGO") retorno = "CD_MATERIAL";
                        if (campo == "DESCRIÇÃO") retorno = "DS_MATERIAL";
                    }
                    break;
                case 9://Servico
                    if (campo != null)
                    {
                        if (campo == "CÓDIGO") retorno = "CD_MATERIAL";
                        if (campo == "DESCRIÇÃO") retorno = "DS_MATERIAL";
                    }
                    break;
                case 10://Cidade
                    if (campo != null)
                    {
                        if (campo == "CÓDIGO") retorno = "CD_MATERIAL";
                        if (campo == "DESCRIÇÃO") retorno = "DS_MATERIAL";
                        if (campo == "ESTADO") retorno = "DS_UF";
                        if (campo == "CEP") retorno = "NR_CEP";
                    }
                    break;
                case 11://Cidade
                    if (campo != null)
                    {
                        if (campo == "ESTADO") retorno = "DS_UF";
                        if (campo == "DESCRIÇÃO") retorno = "DS_ESTADO";
                    }
                    break;
                case 12://grupo Produto
                    if (campo != null)
                    {
                        if (campo == "CÓDIGO") retorno = "CD_GRUPO";
                        if (campo == "DESCRIÇÃO") retorno = "DS_GRUPO";
                    }
                    break;
                case 13://grupo Produto
                    if (campo != null)
                    {
                        if (campo == "CÓDIGO") retorno = "CD_SUBGRUPO";
                        if (campo == "DESCRIÇÃO") retorno = "DS_SUBGRUPO";
                    }
                    break;
                case 14://Subgrupo Produto
                    if (campo != null)
                    {
                        if (campo == "CÓDIGO") retorno = "CD_MARCA";
                        if (campo == "DESCRIÇÃO") retorno = "DS_MARCA";
                    }
                    break;
                case 15://Tipo Produto
                    if (campo != null)
                    {
                        if (campo == "CÓDIGO") retorno = "CD_TIPO";
                        if (campo == "DESCRIÇÃO") retorno = "DS_TIPO";
                    }
                    break;
                case 16://Tipo Entidade
                    if (campo != null)
                    {
                        if (campo == "CÓDIGO") retorno = "CD_TIPO";
                        if (campo == "DESCRIÇÃO") retorno = "DS_TIPO";
                    }
                    break;
                case 17://Tipo Entidade
                    if (campo != null)
                    {
                        if (campo == "CÓDIGO") retorno = "CD_CLASSIFICACAO";
                        if (campo == "DESCRIÇÃO") retorno = "DS_CLASSIFICACAO";
                    }
                    break;
                case 18://Tipo Entidade
                    if (campo != null)
                    {
                        if (campo == "CÓDIGO") retorno = "CD_STATUS";
                        if (campo == "DESCRIÇÃO") retorno = "DS_STATUS";
                    }
                    break;
                case 19://Tipo Entidade
                    if (campo != null)
                    {
                        if (campo == "CÓDIGO") retorno = "CD_TIPO_PEDIDO";
                        if (campo == "DESCRIÇÃO") retorno = "DS_TIPO_PEDIDO";
                    }
                    break;
                case 20://Tipo Entidade
                    if (campo != null)
                    {
                        if (campo == "CÓDIGO") retorno = "CD_ENTIDADE";
                        if (campo == "DESCRIÇÃO") retorno = "DS_ENTIDADE";
                    }
                    break;
                case 21://Tipo Entidade
                    if (campo != null)
                    {
                        if (campo == "CÓDIGO") retorno = "CD_TIPO_EMBALAGEM";
                        if (campo == "DESCRIÇÃO") retorno = "DS_TIPO_EMBALAGEM";
                    }
                    break;
                case 22://Tipo Entidade
                    if (campo != null)
                    {
                        if (campo == "CÓDIGO") retorno = "CD_ENTIDADE";
                        if (campo == "DESCRIÇÃO") retorno = "DS_ENTIDADE";
                    }
                    break;
                case 23://Obra
                    if (campo != null)
                    {
                        if (campo == "CÓDIGO") retorno = "CD_OBRA";
                        if (campo == "DESCRIÇÃO") retorno = "DS_OBRA";
                    }
                    break;
                case 24://Obra
                    if (campo != null)
                    {
                        if (campo == "CÓDIGO") retorno = "CD_FRETE";
                        if (campo == "DESCRIÇÃO") retorno = "DS_FRETE";
                    }
                    break;
                case 25://Obra
                    if (campo != null)
                    {
                        if (campo == "CÓDIGO") retorno = "CD_NOME_PROMOCAO";
                        if (campo == "DESCRIÇÃO") retorno = "DS_NOME_PROMOCAO";
                    }
                    break;
                default:
                    break;
            }
            


            return retorno; 
        }
        private void preencherGrade(string sql)
        {
            DataTable dt = new DataTable();

            var bco = new BancoDeDados().lerXMLConfiguracao();

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

                if (dt.Rows.Count > 0)
                {
                    grade.DataSource = dt;  
                    grade.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    grade.AllowUserToAddRows = false;
                }

                if (grade.Rows.Count >= 2)
                {
                    usMenu1.SetButtonEnabled("Confirmar", true);
                }
                else
                {
                    usMenu1.SetButtonEnabled("Confirmar", false);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante");
                dt = null;
            }
        }
        private void empresa(Dictionary<string, object> filtros = null)
        {

            
            _sql = "Select CD_EMPRESA AS CODIGO " +
                   " , DS_EMPRESA AS DESCRICAO " +                    
                   " from TBL_EMPRESAS ";

            if (filtros != null)
            {
                foreach (var filtro in filtros)
                {
                    string chave = filtro.Key;
                    object valor = filtro.Value;

                    if (_sql.Contains("WHERE"))
                    {
                        _sql += " AND ";
                    }
                    else _sql += " WHERE ";

                    _sql += chave + " = " + valor;

                }
            }

            _sql += " ORDER BY CD_EMPRESA ASC ";

            preencherGrade(_sql);

        }

        private void carteira(Dictionary<string, object> filtros = null)
        {


            _sql = "Select CD_CARTEIRA AS CODIGO " +
                   " , DS_CARTEIRA AS DESCRICAO " +
                   " from TBL_FINANCEIRO_CARTEIRA ";

            if (filtros != null)
            {
                foreach (var filtro in filtros)
                {
                    string chave = filtro.Key;
                    object valor = filtro.Value;

                    if (_sql.Contains("WHERE"))
                    {
                        _sql += " AND ";
                    }
                    else _sql += " WHERE ";

                    _sql += chave + " = " + valor;

                }
            }

            _sql += " ORDER BY CD_CARTEIRA ASC ";

            preencherGrade(_sql);

        }
        private void regiao(Dictionary<string, object> filtros = null)
        {


            _sql = "Select CD_REGIAO AS CODIGO " +
                   " , DS_REGIAO AS DESCRICAO " +
                   " from TBL_REGIAO ";

            if (filtros != null)
            {
                foreach (var filtro in filtros)
                {
                    string chave = filtro.Key;
                    object valor = filtro.Value;

                    if (_sql.Contains("WHERE"))
                    {
                        _sql += " AND ";
                    }
                    else _sql += " WHERE ";

                    _sql += chave + " = " + valor;

                }
            }

            _sql += " ORDER BY CD_REGIAO ASC ";

            preencherGrade(_sql);

        }
        private void Entidade(Dictionary<string, object> filtros = null, int qualEntidade = 0 )
        {


            _sql = "Select CD_ENTIDADE AS CODIGO " +
                   " , DS_ENTIDADE AS DESCRICAO " +
                   " from TBL_ENTIDADES";

            if (qualEntidade == 0) _sql += " WHERE X_CLIENTE = 1";
            if (qualEntidade == 1) _sql += " WHERE X_VENDEDOR = 1";
            if (qualEntidade == 2) _sql += " WHERE X_TRANSPORTADOR = 1";
            if (qualEntidade == 3) _sql += " WHERE X_FORNECEDOR = 1";

            _sql += " AND X_ATIVO = 1 ";

            if (filtros != null)
            {
                foreach (var filtro in filtros)
                {
                    string chave = filtro.Key;
                    object valor = filtro.Value;

                    if (_sql.Contains("WHERE"))
                    {
                        _sql += " AND ";
                    }
                    else _sql += " WHERE ";

                    _sql += chave + " = " + valor;

                }
            }

            _sql += " ORDER BY CD_ENTIDADE ASC ";

            preencherGrade(_sql);

        }
        private void filial(Dictionary<string, object> filtros = null)
        {


            _sql = "Select CD_FILIAL AS CODIGO " +
                   " , DS_FILIAL AS DESCRICAO " +
                   " from TBL_EMPRESAS_FILIAIS ";

            if (filtros != null)
            {
                foreach (var filtro in filtros)
                {
                    string chave = filtro.Key;
                    object valor = filtro.Value;

                    if (_sql.Contains("WHERE"))
                    {
                        _sql += " AND ";
                    }
                    else _sql += " WHERE ";

                    _sql += chave + " = " + valor;

                }
            }

            _sql += " ORDER BY CD_FILIAL ASC ";

            preencherGrade(_sql);

        }

        private void TipoProduto(Dictionary<string, object> filtros = null)
        {


            _sql = "Select CD_TIPO AS CODIGO " +
                   " , DS_TIPO AS DESCRICAO " +
                   " from TBL_MATERIAIS_TIPOS ";

            if (filtros != null)
            {
                foreach (var filtro in filtros)
                {
                    string chave = filtro.Key;
                    object valor = filtro.Value;

                    if (_sql.Contains("WHERE"))
                    {
                        _sql += " AND ";
                    }
                    else _sql += " WHERE ";

                    _sql += chave + " = " + valor;

                }
            }

            _sql += " ORDER BY CD_TIPO ASC ";

            preencherGrade(_sql);

        }

        private void TipoEntidade(Dictionary<string, object> filtros = null)
        {


            _sql = "Select CD_TIPO AS CODIGO " +
                   " , DS_TIPO AS DESCRICAO " +
                   " from TBL_ENTIDADES_TIPO ";

            if (filtros != null)
            {
                foreach (var filtro in filtros)
                {
                    string chave = filtro.Key;
                    object valor = filtro.Value;

                    if (_sql.Contains("WHERE"))
                    {
                        _sql += " AND ";
                    }
                    else _sql += " WHERE ";

                    _sql += chave + " = " + valor;

                }
            }

            _sql += " ORDER BY CD_TIPO ASC ";

            preencherGrade(_sql);

        }
        private void formaPagto(Dictionary<string, object> filtros = null)
        {


            _sql = "Select CD_FORMA_PAGAMENTO AS CODIGO " +
                   " , DS_FORMA_PAGAMENTO AS DESCRICAO " +
                   " from TBL_FINANCEIRO_FORMAS_PAGAMENTO ";

            if (filtros != null)
            {
                foreach (var filtro in filtros)
                {
                    string chave = filtro.Key;
                    object valor = filtro.Value;

                    if (_sql.Contains("WHERE"))
                    {
                        _sql += " AND ";
                    }
                    else _sql += " WHERE ";

                    _sql += chave + " = " + valor;

                }
            }

            _sql += " ORDER BY CD_FORMA_PAGAMENTO ASC ";

            preencherGrade(_sql);

        }


        private void cidade(Dictionary<string, object> filtros = null)
        {


            _sql = "Select CD_CIDADE AS CODIGO " +
                   " , DS_CIDADE AS DESCRICAO " +
                   " , DS_UF AS UF" +
                   " , NR_CEP AS CEP" +
                   " from TBL_ENDERECO_CIDADES ";

            if (filtros != null)
            {
                foreach (var filtro in filtros)
                {
                    string chave = filtro.Key;
                    object valor = filtro.Value;

                    if (_sql.Contains("WHERE"))
                    {
                        _sql += " AND ";
                    }
                    else _sql += " WHERE ";

                    _sql += chave + " = " + valor;

                }
            }

            _sql += " ORDER BY CD_CIDADE ASC ";

            preencherGrade(_sql);

        }

        private void estado(Dictionary<string, object> filtros = null)
        {


            _sql = "Select DS_UF AS ESTADO " +
                   " , DS_ESTADO AS DESCRICAO " +                   
                   " from TBL_ENDERECO_ESTADOS ";

            if (filtros != null)
            {
                foreach (var filtro in filtros)
                {
                    string chave = filtro.Key;
                    object valor = filtro.Value;

                    if (_sql.Contains("WHERE"))
                    {
                        _sql += " AND ";
                    }
                    else _sql += " WHERE ";

                    _sql += chave + " = " + valor;

                }
            }

            _sql += " ORDER BY DS_UF ASC ";

            preencherGrade(_sql);

        }

        private void grupoProduto(Dictionary<string, object> filtros = null)
        {


            _sql = "Select CD_GRUPO AS CODIGO " +
                   " , DS_GRUPO AS DESCRICAO " +
                   " from TBL_MATERIAIS_GRUPO ";

            if (filtros != null)
            {
                foreach (var filtro in filtros)
                {
                    string chave = filtro.Key;
                    object valor = filtro.Value;

                    if (_sql.Contains("WHERE"))
                    {
                        _sql += " AND ";
                    }
                    else _sql += " WHERE ";

                    _sql += chave + " = " + valor;

                }
            }

            _sql += " ORDER BY CD_GRUPO ASC ";

            preencherGrade(_sql);

        }

        private void subGrupoProduto(Dictionary<string, object> filtros = null)
        {


            _sql = "Select CD_SUBGRUPO AS CODIGO " +
                   " , DS_SUBGRUPO AS DESCRICAO " +
                   " from TBL_MATERIAIS_SUBGRUPO ";

            if (filtros != null)
            {
                foreach (var filtro in filtros)
                {
                    string chave = filtro.Key;
                    object valor = filtro.Value;

                    if (_sql.Contains("WHERE"))
                    {
                        _sql += " AND ";
                    }
                    else _sql += " WHERE ";

                    _sql += chave + " = " + valor;

                }
            }

            _sql += " ORDER BY CD_SUBGRUPO ASC ";

            preencherGrade(_sql);

        }
        private void ProdutoServico(Dictionary<string, object> filtros = null, bool produto = true)
        {


            _sql = "Select CD_MATERIAL AS CODIGO " +
                   " , DS_MATERIAL AS DESCRICAO " +
                   " from TBL_MATERIAIS ";

            if (produto)
            {
                _sql += " WHERE X_SERVICO = 0";    
            }else
            {
                _sql += " WHERE X_SERVICO = 1";
            }

            _sql += " AND X_ATIVO = 1 ";

            if (filtros != null)
            {
                foreach (var filtro in filtros)
                {
                    string chave = filtro.Key;
                    object valor = filtro.Value;

                    if (_sql.Contains("WHERE"))
                    {
                        _sql += " AND ";
                    }
                    else _sql += " WHERE ";

                    _sql += chave + " = " + valor;

                }
            }

            _sql += " ORDER BY CD_MATERIAL ASC ";

            preencherGrade(_sql);

        }


        private void Marca(Dictionary<string, object> filtros = null)
        {


            _sql = "Select CD_MARCA AS CODIGO " +
                   " , DS_MARCA AS DESCRICAO " +
                   " from TBL_MATERIAIS_MARCA ";

            

            if (filtros != null)
            {
                foreach (var filtro in filtros)
                {
                    string chave = filtro.Key;
                    object valor = filtro.Value;

                    if (_sql.Contains("WHERE"))
                    {
                        _sql += " AND ";
                    }
                    else _sql += " WHERE ";

                    _sql += chave + " = " + valor;

                }
            }

            _sql += " ORDER BY CD_MARCA ASC ";

            preencherGrade(_sql);

        }

        private void classificaoEntidade(Dictionary<string, object> filtros = null)
        {


            _sql = "Select CD_CLASSIFICACAO AS CODIGO " +
                   " , DS_CLASSIFICACAO AS DESCRICAO " +
                   " from TBL_ENTIDADES_CLASSIFICACAO ";



            if (filtros != null)
            {
                foreach (var filtro in filtros)
                {
                    string chave = filtro.Key;
                    object valor = filtro.Value;

                    if (_sql.Contains("WHERE"))
                    {
                        _sql += " AND ";
                    }
                    else _sql += " WHERE ";

                    _sql += chave + " = " + valor;

                }
            }

            _sql += " ORDER BY CD_CLASSIFICACAO ASC ";

            preencherGrade(_sql);

        }

        private void statusGlobal(Dictionary<string, object> filtros = null)
        {


            _sql = "Select CD_STATUS AS CODIGO " +
                   " , DS_STATUS AS DESCRICAO " +
                   " from TBL_STATUS_GLOBAL ";



            if (filtros != null)
            {
                foreach (var filtro in filtros)
                {
                    string chave = filtro.Key;
                    object valor = filtro.Value;

                    if (_sql.Contains("WHERE"))
                    {
                        _sql += " AND ";
                    }
                    else _sql += " WHERE ";

                    _sql += chave + " = " + valor;

                }
            }

            _sql += " ORDER BY CD_STATUS ASC ";

            preencherGrade(_sql);

        }

        private void tipoPedido(Dictionary<string, object> filtros = null)
        {


            _sql = "Select CD_TIPO_PEDIDO AS CODIGO " +
                   " , DS_TIPO_PEDIDO AS DESCRICAO " +
                   " from TBL_TIPO_PEDIDO ";



            if (filtros != null)
            {
                foreach (var filtro in filtros)
                {
                    string chave = filtro.Key;
                    object valor = filtro.Value;

                    if (_sql.Contains("WHERE"))
                    {
                        _sql += " AND ";
                    }
                    else _sql += " WHERE ";

                    _sql += chave + " = " + valor;

                }
            }

            _sql += " ORDER BY CD_TIPO_PEDIDO ASC ";

            preencherGrade(_sql);

        }

        private void obra(Dictionary<string, object> filtros = null)
        {


            _sql = "Select CD_OBRA AS CODIGO " +
                   " , DS_OBRA AS DESCRICAO " +
                   " from TBL_OBRAS ";



            if (filtros != null)
            {
                foreach (var filtro in filtros)
                {
                    string chave = filtro.Key;
                    object valor = filtro.Value;

                    if (_sql.Contains("WHERE"))
                    {
                        _sql += " AND ";
                    }
                    else _sql += " WHERE ";

                    _sql += chave + " = " + valor;

                }
            }

            _sql += " ORDER BY CD_OBRA ASC ";

            preencherGrade(_sql);

        }

        private void tipoEmbalagem(Dictionary<string, object> filtros = null)
        {


            _sql = "Select CD_TIPO_EMBALAGEM AS CODIGO " +
                   " , DS_TIPO_EMBALAGEM AS DESCRICAO " +
                   " from TBL_TIPO_EMBALAGEM ";



            if (filtros != null)
            {
                foreach (var filtro in filtros)
                {
                    string chave = filtro.Key;
                    object valor = filtro.Value;

                    if (_sql.Contains("WHERE"))
                    {
                        _sql += " AND ";
                    }
                    else _sql += " WHERE ";

                    _sql += chave + " = " + valor;

                }
            }

            _sql += " ORDER BY CD_TIPO_EMBALAGEM ASC ";

            preencherGrade(_sql);

        }

        private void fretes(Dictionary<string, object> filtros = null)
        {


            _sql = "Select CD_FRETE AS CODIGO " +
                   " , DS_FRETE AS DESCRICAO " +
                   " from TBL_FRETES ";



            if (filtros != null)
            {
                foreach (var filtro in filtros)
                {
                    string chave = filtro.Key;
                    object valor = filtro.Value;

                    if (_sql.Contains("WHERE"))
                    {
                        _sql += " AND ";
                    }
                    else _sql += " WHERE ";

                    _sql += chave + " = " + valor;

                }
            }

            _sql += " ORDER BY CD_FRETE ASC ";

            preencherGrade(_sql);

        }

        private void promocao(Dictionary<string, object> filtros = null)
        {


            _sql = "Select CD_NOME_PROMOCAO AS CODIGO " +
                   " , DS_NOME_PROMOCAO AS DESCRICAO " +
                   " from TBL_MATERIAIS_PROMOCAO_NOME ";



            if (filtros != null)
            {
                foreach (var filtro in filtros)
                {
                    string chave = filtro.Key;
                    object valor = filtro.Value;

                    if (_sql.Contains("WHERE"))
                    {
                        _sql += " AND ";
                    }
                    else _sql += " WHERE ";

                    _sql += chave + " = " + valor;

                }
            }

            _sql += " ORDER BY CD_NOME_PROMOCAO ASC ";

            preencherGrade(_sql);

        }

        private void grade_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void grade_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && grade.Rows[e.RowIndex].Cells[0].Value != null)
            {
                
                if (_oQueLocalizar == 11)
                {
                    EstadoSelecionado = grade.Rows[e.RowIndex].Cells[0].Value.ToString();
                }
                else
                {
                    Codigo = Convert.ToInt32(grade.Rows[e.RowIndex].Cells[0].Value);
                }
                // Captura o valor da primeira coluna da linha clicada
                
                if (-_oQueLocalizar == 0 || _oQueLocalizar == 1)
                {
                    descricao = grade.Rows[e.RowIndex].Cells[1].Value.ToString();
                }

                Close();
            }
        }

        private void usBarraTitulo1_Load(object sender, EventArgs e)
        {

        }
    }
}
