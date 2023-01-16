using System;
using System.Threading;
using System.Threading.Tasks;
using IARA.Buniness.Uteis;
using IARA.Domain.Entities;
using IARA.Domain.IRepositories;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace IARA.Buniness.CotacaoBusiness.BuscarCotacao
{
    public class BuscarCotacaoCommandHandler : IRequestHandler<BuscarCotacaoCommand, RetornoApi>
    {
        private readonly ICotacaoRepository _cotacaoRepository;

        public BuscarCotacaoCommandHandler(ICotacaoRepository cotacaoRepository)
        {
            _cotacaoRepository = cotacaoRepository;
        }

        public async Task<RetornoApi> Handle(BuscarCotacaoCommand request, CancellationToken cancellationToken)
        {
            var validar = new BuscarCotacaoValidar();
            var validarResult = await validar.ValidateAsync(request);

            if (!validarResult.IsValid)
            {
                return new RetornoApi()
                {
                    Errors = validarResult.Errors,
                    ResultCode = StatusCodes.Status400BadRequest
                };
            }

            var cotacaoResult = await _cotacaoRepository.BuscarCotacao(request.Id);
            return new RetornoApi<CotacaoEntitie>() { ResultCode = StatusCodes.Status200OK, Data = cotacaoResult };
        }
    }
}

