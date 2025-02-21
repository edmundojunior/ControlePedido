using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlePedido
{
    public partial class usMenu : UserControl
    {
        public event EventHandler LocalizarButtonClicked;
        public event EventHandler ConfirmarButtonClicked;
        public event EventHandler PrimeiroButtonClicked;
        public event EventHandler AnteriorButtonClicked;
        public event EventHandler ProximoButtonClicked;
        public event EventHandler UltimoButtonClicked;        
        public event EventHandler FiltroButtonClicked;
        public event EventHandler ExecutarButtonClicked;
        public event EventHandler SalvarButtonClicked;
        public event EventHandler CancelarButtonClicked;
        public event EventHandler ImprimirButtonClicked;
        public event EventHandler RefreshButtonClicked;
        public event EventHandler CloseButtonClicked;

        public event EventHandler NovoButtonClicked;
        public event EventHandler EditarButtonClicked;
        public event EventHandler ExcluirButtonClicked;

        public usMenu()
        {
            InitializeComponent();
            btnLocalizar.Click += (s, e) => LocalizarButtonClicked?.Invoke(this, e);
            btnConfirmar.Click += (s, e) => ConfirmarButtonClicked?.Invoke(this, e);
            btnPrimeiro.Click += (s, e) => PrimeiroButtonClicked?.Invoke(this, e);
            btnAnterior.Click += (s, e) => AnteriorButtonClicked?.Invoke(this, e);
            btnProximo.Click += (s, e) => ProximoButtonClicked?.Invoke(this, e);
            btnUltimo.Click += (s, e) => UltimoButtonClicked?.Invoke(this, e);            
            btnFiltro.Click += (s, e) => FiltroButtonClicked?.Invoke(this, e);
            btnExecutar.Click += (s, e) => ExecutarButtonClicked?.Invoke(this, e);
            btnFechar.Click += (s, e) => CloseButtonClicked?.Invoke(this, e);
            btnSalvar.Click += (s,e) => SalvarButtonClicked?.Invoke(this, e);
            btnCancelar.Click += (s, e) => CancelarButtonClicked?.Invoke(this, e);
            btnImprimir.Click += (s, e) => ImprimirButtonClicked?.Invoke(this, e);
            btnrefresh.Click += (s, e) => RefreshButtonClicked?.Invoke(this, e);
            btnNovo.Click += (s, e) => NovoButtonClicked?.Invoke(this, e);
            btnEditar.Click += (s, e) => EditarButtonClicked?.Invoke(this, e);
            btnDelete.Click += (s, e) => ExcluirButtonClicked?.Invoke(this, e);
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            
        }

        private void usMenu_Load(object sender, EventArgs e)
        {

        }

        public void SetButtonVisible(string buttonName, bool isVisible)
        {
            switch (buttonName)
            {
                case "Localizar":
                    btnLocalizar.Visible = isVisible;
                    break;
                case "Confirmar":
                    btnConfirmar.Visible = isVisible;
                    break;
                case "Primeiro":
                    btnPrimeiro.Visible = isVisible;
                    break;
                case "Anterior":
                    btnAnterior.Visible = isVisible;
                    break;
                case "Proximo":
                    btnProximo.Visible = isVisible;
                    break;
                case "Ultimo":
                    btnUltimo.Visible = isVisible;
                    break;
                case "Filtro":
                    btnFiltro.Visible = isVisible;
                    break;
                case "Executar":
                    btnExecutar.Visible = isVisible;
                    break;
                case "Salvar":
                    btnSalvar.Visible = isVisible;
                    break;
                case "Cancelar":
                    btnCancelar.Visible = isVisible;
                    break;
                case "Imprimir":
                    btnImprimir.Visible = isVisible;
                    break;
                case "Atualizar":
                    btnrefresh.Visible = isVisible;
                    break;
                case "Fechar":
                    btnFechar.Visible = isVisible;
                    break;
                case "Novo":
                    btnNovo.Visible = isVisible;
                    break;
                case "Editar":
                    btnEditar.Visible = isVisible;
                    break;
                case "Excluir":
                    btnDelete.Visible = isVisible;
                    break;                    

            }

            
        }

        public void SetButtonEnabled(string buttonName, bool isEnabled)
        {
            switch (buttonName)
            {
                case "Localizar":
                    btnLocalizar.Enabled = isEnabled;
                    break;
                case "Confirmar":
                    btnConfirmar.Enabled = isEnabled;
                    break;
                case "Primeiro":
                    btnPrimeiro.Enabled = isEnabled;
                    break;
                case "Anterior":
                    btnAnterior.Enabled = isEnabled;
                    break;
                case "Proximo":
                    btnProximo.Enabled = isEnabled;
                    break;
                case "Ultimo":
                    btnUltimo.Enabled = isEnabled;
                    break;
                case "Filtro":
                    btnFiltro.Enabled = isEnabled;
                    break;
                case "Executar":
                    btnExecutar.Enabled = isEnabled;
                    break;
                case "Salvar":
                    btnSalvar.Enabled = isEnabled;
                    break;
                case "Cancelar":
                    btnCancelar.Enabled = isEnabled;
                    break;
                case "Imprimir":
                    btnImprimir.Enabled = isEnabled;
                    break;
                case "Atualizar":
                    btnrefresh.Enabled = isEnabled; 
                    break;
                case "Fechar":
                    btnFechar.Enabled = isEnabled;
                    break;
                case "Novo":
                    btnNovo.Enabled = isEnabled;
                    break;
                case "Editar":
                    btnEditar.Enabled = isEnabled;
                    break;
                case "Excluir":
                    btnDelete.Enabled = isEnabled;
                    break;
            }
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {

        }
    }
}
