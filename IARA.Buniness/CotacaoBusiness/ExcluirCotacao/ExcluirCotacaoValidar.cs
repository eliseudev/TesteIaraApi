using System;
using FluentValidation;

namespace IARA.Buniness.CotacaoBusiness.ExcluirCotacao
{
	public class ExcluirCotacaoValidar : AbstractValidator<ExcluirCotacaoCommand>
	{
		public ExcluirCotacaoValidar()
		{
			RuleFor(x => x.Id)
				.NotNull()
				.WithMessage("Informe o código da cotação");

		}
	}
}

