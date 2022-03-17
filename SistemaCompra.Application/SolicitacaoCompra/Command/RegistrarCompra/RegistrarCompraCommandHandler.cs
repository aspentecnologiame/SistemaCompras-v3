using MediatR;
using SistemaCompra.Infra.Data.UoW;
using System;
using System.Threading;
using System.Threading.Tasks;
using SolicitaCaoCompraAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;
using ProdutoAgg = SistemaCompra.Domain.ProdutoAggregate;
using System.Collections.Generic;

namespace SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra
{
    public class RegistrarCompraCommandHandler : CommandHandler, IRequestHandler<RegistrarCompraCommand, bool>
    {
        private readonly ProdutoAgg.IProdutoRepository _produtoRepository;
        private readonly SolicitaCaoCompraAgg.ISolicitacaoCompraRepository _solicitacaoCompraRepository;
        public RegistrarCompraCommandHandler(ProdutoAgg.IProdutoRepository produtoRepository, SolicitaCaoCompraAgg.ISolicitacaoCompraRepository solicitacaoCompraRepository, IUnitOfWork uow, IMediator mediator) : base(uow, mediator)
        {
            _produtoRepository = produtoRepository;
            _solicitacaoCompraRepository = solicitacaoCompraRepository;
        }

        public Task<bool> Handle(RegistrarCompraCommand request, CancellationToken cancellationToken)
        {
            var solicitacaoCompra = new SolicitaCaoCompraAgg.SolicitacaoCompra(request.Solicitante, request.Fornecedor);

            request.Produtos.ForEach((item) =>
            {
                var produto = _produtoRepository.Obter(item.Produto);
                solicitacaoCompra.AdicionarItem(produto, item.Qtde);
            });

            solicitacaoCompra.RegistrarCompra(solicitacaoCompra.Itens);

            _solicitacaoCompraRepository.RegistrarCompra(solicitacaoCompra);

            Commit();
            PublishEvents(solicitacaoCompra.Events);

            return Task.FromResult(true);
        }
    }
}
