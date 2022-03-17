using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaCompra.Domain.SolicitacaoCompraAggregate
{
    public interface IItemRepository
    {
        void Registrar(IList<Item> itens);
    }
}
