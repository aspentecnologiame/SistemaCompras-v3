using System.Collections.Generic;
using SolicitacaoCompraAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Infra.Data.Item
{
    public class ItemRepository : SolicitacaoCompraAgg.IItemRepository
    {
        private readonly SistemaCompraContext context;

        public ItemRepository(SistemaCompraContext context)
        {
            this.context = context;
        }
        public void Registrar(IList<SolicitacaoCompraAgg.Item> itens)
        {
            foreach (var entity in itens)
            {
                context.Set<SolicitacaoCompraAgg.Item>().Add(entity);
            }
        }
    }
}
