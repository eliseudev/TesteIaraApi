using System;
using FluentValidation;

namespace IARA.Buniness.CotacaoBusiness.AtualizarCotacao
{
	public class AtualizarCotacaoValidador :AbstractValidator<AtualizarCotacaoCommand>
	{
		public AtualizarCotacaoValidador()
		{
            RuleFor(x => x.CnpjCliente)
                .NotEmpty()
                .WithMessage("Campo CNPJ do Comprador é obrigatório");

            RuleFor(x => x.CnpjFornecedor)
                .NotEmpty()
                .WithMessage("Campo CNPJ do Fornecedor é obrigatório");

            RuleFor(x => x.DataCotacao)
                .NotNull()
                .WithMessage("Data de Inicio da Cotação é obrigatória");

            RuleFor(x => x.DataEntregaCotacao)
                .NotNull()
                .WithMessage("Data de Entrega da Cotação é obrigatória");

            RuleFor(x => x.Cep)
                .NotEmpty()
                .WithMessage("Campo CEP é obrigatório");
        }
	}
}

