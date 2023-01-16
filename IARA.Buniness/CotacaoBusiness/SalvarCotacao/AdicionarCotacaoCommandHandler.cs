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

namespace IARA.Buniness.CotacaoBusiness.SalvarCotacao
{
    public class AdicionarCotacaoCommandHandler : IRequestHandler<AdicionarCotacaoCommand, RetornoApi>
    {
        private readonly ICotacaoRepository _cotacaoRepository;
        private readonly IViaCepService _viaCepService;

        public AdicionarCotacaoCommandHandler(ICotacaoRepository cotacaoRepository, IViaCepService viaCepService)
        {
            _cotacaoRepository = cotacaoRepository;
            _viaCepService = viaCepService;
        }

        public async Task<RetornoApi> Handle(AdicionarCotacaoCommand request, CancellationToken cancellationToken)
        {
            var validar = new AdicionarCotacaoValidar();
            var validarResult = await validar.ValidateAsync(request);

            if (!validarResult.IsValid)
            {
                return new RetornoApi()
                {
                    Errors = validarResult.Errors,
                    ResultCode = StatusCodes.Status400BadRequest
                };
            }

            var localizarEnderecoViaCep = await _viaCepService.BuscarCep(request.Cep);

            if(request.Endereco == string.Empty || request.Bairro == string.Empty || request.Estado == string.Empty)
            {
                request.Endereco = localizarEnderecoViaCep.logradouro;
                request.Bairro = localizarEnderecoViaCep.bairro;
                request.Cidade = localizarEnderecoViaCep.localidade;
                request.Estado = localizarEnderecoViaCep.uf;
            }

            var itens = new List<ItemCotacaoEntitie>();

            int NumeroItem = 1;
            foreach (var item in request.CotacaoItem)
            {
                itens.Add(new ItemCotacaoEntitie(item.Descricao, NumeroItem, item.ItemCotacaoId, item.Preco, item.Quantidade, item.Marca, item.Unidade));
                NumeroItem++;
            }

            var cotacao = new CotacaoEntitie(request.CnpjCliente, request.CnpjFornecedor, request.NumeroCotacao, request.DataCotacao, request.DataEntregaCotacao,
                                             request.Cep, request.Endereco, request.Complemento, request.Bairro, request.Cidade,
                                             request.Estado, request.Observacao, itens);

            var result = await _cotacaoRepository.CriarCotacao(cotacao);
            return new RetornoApi<CotacaoEntitie>() { ResultCode = StatusCodes.Status200OK, Data = result};
        }
    }
}

