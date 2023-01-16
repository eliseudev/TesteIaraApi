using System;
using IARA.Buniness.Uteis;
using MediatR;

namespace IARA.Buniness.CotacaoBusiness.ExcluirCotacao
{
	public class ExcluirCotacaoCommand : IRequest<RetornoApi>
	{
		public int Id { get; set; }
	}
}

