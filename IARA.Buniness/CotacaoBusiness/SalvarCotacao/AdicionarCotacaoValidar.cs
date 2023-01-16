using System;
using FluentValidation;

namespace IARA.Buniness.CotacaoBusiness.SalvarCotacao
{
	public class AdicionarCotacaoValidar : AbstractValidator<AdicionarCotacaoCommand>
	{
		public AdicionarCotacaoValidar()
		{
            RuleFor(x => x.CnpjCliente)
                .NotEmpty()
                .WithMessage("Campo CNPJ do Comprador é obrigatório");

            RuleFor(x => x.CnpjFornecedor)
                .NotEmpty()
                .WithMessage("Campo CNPJ do Fornecedor é obrigatório");

            RuleFor(x => x.NumeroCotacao)
                .NotEmpty()
                .WithMessage("Campo Numero Cotação é obrigatório");

            RuleFor(x => x.DataCotacao)
                .NotNull()
                .WithMessage("Data de Inicio da Cotação é obrigatória");

            RuleFor(x => x.DataCotacao)
                .NotNull()
                .WithMessage("Data de Entrega da Cotação é obrigatória");

            RuleFor(x => x.DataEntregaCotacao)
                .NotEmpty()
                .WithMessage("Campo CEP é obrigatório");
        }
	}
}

