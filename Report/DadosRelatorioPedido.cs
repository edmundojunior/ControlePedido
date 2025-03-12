using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePedido.Report
{
    public class DadosRelatorioPedido
    {
        public int cd_pedido { get; set; }
        public int cd_cliente { get; set; }
        public string ds_cliente { get; set; }
        public DateTime? dt_emissao { get; set; }
        public DateTime? dt_entrega { get; set; }
        
        public int cd_filial { get; set; }
        public int cd_material { get; set; }
        public string ds_material { get; set; }

        public double nr_qtdepedida { get; set; }
        public double nr_emseparacao { get; set; }
        public double nr_separado { get; set; }
    }
}
