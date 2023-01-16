using System;
using IARA.Buniness.CotacaoBusiness.BuscarCotacao;
using IARA.Buniness.Uteis;
using IARA.Domain.Entities;
using IARA.Domain.IRepositories;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using System.Collections.Generic;

namespace IARA.Buniness.CotacaoBusiness.BuscarTodasCotacoes
{
	public class ListarTodasCotacoesCommandHandler : IRequestHandler<ListarTodasCotacoesCommand, RetornoApi>
	{
        private readonly ICotacaoRepository _cotacaoRepository;

        public ListarTodasCotacoesCommandHandler(ICotacaoRepository cotacaoRepository)
        {
            _cotacaoRepository = cotacaoRepository;
        }

        public async Task<RetornoApi> Handle(ListarTodasCotacoesCommand request, CancellationToken cancellationToken)
        {
            var cotacaoLista = await _cotacaoRepository.BuscarTodasCotacoes();
            return new RetornoApi<IEnumerable<CotacaoEntitie>>() { ResultCode = StatusCodes.Status200OK, Data = cotacaoLista };
        }
    }
}

