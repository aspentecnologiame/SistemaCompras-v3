using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolicitacaoCompraAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Infra.Data.Item
{
    public class ItemConfiguration : IEntityTypeConfiguration<SolicitacaoCompraAgg.Item>
    {
        public void Configure(EntityTypeBuilder<SolicitacaoCompraAgg.Item> builder)
        {
            builder.ToTable("Item");
        }
    }
}
