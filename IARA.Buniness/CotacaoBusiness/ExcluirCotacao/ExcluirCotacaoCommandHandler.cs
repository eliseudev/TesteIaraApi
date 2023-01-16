using System;
using System.Threading;
using System.Threading.Tasks;
using IARA.Buniness.Uteis;
using IARA.Domain.Entities;
using IARA.Domain.IRepositories;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace IARA.Buniness.CotacaoBusiness.ExcluirCotacao
{
    public class ExcluirCotacaoCommandHandler : IRequestHandler<ExcluirCotacaoCommand, RetornoApi>
    {
        private readonly ICotacaoRepository _cotacaoRepository;

        public async Task<RetornoApi> Handle(ExcluirCotacaoCommand request, CancellationToken cancellationToken)
        {
            var validator = new ExcluirCotacaoValidar();
            var validationresults = await validator.ValidateAsync(request);

            if (!validationresults.IsValid)
                return new RetornoApi()
                {
                    Errors = validationresults.Errors,
                    ResultCode = StatusCodes.Status400BadRequest
                };

            var quotationResult = await _cotacaoRepository.BuscarCotacao(request.Id);
            await _cotacaoRepository.ExcluirCotacao(quotationResult);
            return new RetornoApi<CotacaoEntitie>() { ResultCode = StatusCodes.Status200OK };
        }
    }
}

