using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaCompra.Domain.SolicitacaoCompraAggregate
{
    public class Itens
    {
        public Guid Produto { get; set; }
        public int Qtde { get; set; }
    }
}
