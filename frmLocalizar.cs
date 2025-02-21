using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ControlePedido.Util;

namespace ControlePedido
{
    public partial class frmLocalizar : frmBase
    {
        public int retorno;
        public int localizacao = 0;
        public frmLocalizar(int tipoLocalizacao = 0)
        {
            InitializeComponent();

            localizacao=tipoLocalizacao;

            usMenu1.CloseButtonClicked += UsMenu1_CloseButtonClicked;
            usMenu1.FiltroButtonClicked += UsMenu1_FiltroButtonClicked;
            usMenu1.CancelarButtonClicked += UsMenu1_CancelarButtonClicked;

            reset();
        }

        private void UsMenu1_CancelarButtonClicked(object sender, EventArgs e)
        {
            reset();
        }
        private void UsMenu1_FiltroButtonClicked(object sender, EventArgs e)
        {
            
        }


        private void UsMenu1_CloseButtonClicked(object sender, EventArgs e)
        {
            Close();
        }
        private void frmLocalizar_Load(object sender, EventArgs e)
        {

        }

        private void reset()
        {
            //Configuração dos botões
            usMenu1.SetButtonVisible("Localizar", false);
            usMenu1.SetButtonVisible("Confirmar", false);
            usMenu1.SetButtonVisible("Imprimir", false);
            usMenu1.SetButtonVisible("Atualizar", false);
            usMenu1.SetButtonVisible("Filtro", true);
            usMenu1.SetButtonVisible("Salvar", false);
            usMenu1.SetButtonVisible("Novo", false);
            usMenu1.SetButtonVisible("Editar", false);
            usMenu1.SetButtonVisible("Excluir", false);
            usMenu1.SetButtonVisible("Executar", false);
            usMenu1.SetButtonVisible("Primeiro", false);
            usMenu1.SetButtonVisible("Anterior", false);
            usMenu1.SetButtonVisible("Proximo", false);
            usMenu1.SetButtonVisible("Ultimo", false);

            switch (localizacao) {
                case 0:
                    usBarraTitulo1.valor = "Localizar Padrão";
                    break;
                case 1:
                    usBarraTitulo1.valor = "Localizar Estoque";
                    break;
                default:
                    break;
            }            

        }

        private void formatarGrade()
        {

            switch (localizacao)
            {
                case 1:
                    FormatargradeEstoque();
                    break;
                default:
                    break;
            }
        }

        private void FormatargradeEstoque()
        {
            
        }
    }
}
