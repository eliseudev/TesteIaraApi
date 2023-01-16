using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using IARA.Buniness.Services.ViaCep;
using IARA.Buniness.Uteis;
using IARA.Domain.Entities;
using IARA.Domain.IRepositories;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace IARA.Buniness.CotacaoBusiness.AtualizarCotacao
{
	public class AtualizarCotacaoCommandHandler : IRequestHandler<AtualizarCotacaoCommand, RetornoApi>
	{
        private readonly ICotacaoRepository _cotacaoRepository;
        private readonly IViaCepService _viaCepService;

        public AtualizarCotacaoCommandHandler(ICotacaoRepository cotacaoRepository, IViaCepService viaCepService)
        {
            _cotacaoRepository = cotacaoRepository;
            _viaCepService = viaCepService;
        }

        public async Task<RetornoApi> Handle(AtualizarCotacaoCommand request, CancellationToken cancellationToken)
        {
            var validar = new AtualizarCotacaoValidador();
            var validarResult = await validar.ValidateAsync(request);

            if (!validarResult.IsValid)
            {
                return new RetornoApi()
                {
                    Errors = validarResult.Errors,
                    ResultCode = StatusCodes.Status400BadRequest
                };
            }


            var cotacaoResult = await _cotacaoRepository.BuscarCotacao(request.IdCotacao);
            var lista = new List<ItemCotacaoEntitie>();
            var buscaEndereco = await _viaCepService.BuscarCep(request.Cep);

            if (request.Endereco == string.Empty || request.Bairro == string.Empty || request.Estado == string.Empty)
            {
                request.Endereco = buscaEndereco.logradouro;
                request.Bairro = buscaEndereco.bairro;
                request.Cidade = buscaEndereco.localidade;
                request.Estado = buscaEndereco.uf;
            }

            foreach (var item in request.CotacaoItem)
            {
                lista.Add(new ItemCotacaoEntitie(item.Descricao, item.NumeroItem, item.ItemCotacaoId, item.Preco, item.Quantidade, item.Marca, item.Unidade));
            }

            cotacaoResult.Update(request.CnpjCliente, request.CnpjFornecedor, request.NumeroCotacao,
                                 request.DataCotacao, request.DataEntregaCotacao, request.Cep, request.Endereco,
                                 request.Complemento, request.Bairro, request.Cidade, request.Estado, request.Observacao,
                                 lista);

            var result = await _cotacaoRepository.AtualizarCotacao(cotacaoResult);
            return new RetornoApi<CotacaoEntitie>{ ResultCode = StatusCodes.Status200OK, Data = result};
        }
    }
}

