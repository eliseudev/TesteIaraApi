using System;
using FluentValidation;

namespace IARA.Buniness.CotacaoBusiness.BuscarCotacao
{
	public class BuscarCotacaoValidar : AbstractValidator<BuscarCotacaoCommand>
	{
		public BuscarCotacaoValidar()
		{
			RuleFor(x => x.Id)
				.NotNull()
				.WithMessage("Informe o código da contação para pesquisa.");
		}
    }
}

