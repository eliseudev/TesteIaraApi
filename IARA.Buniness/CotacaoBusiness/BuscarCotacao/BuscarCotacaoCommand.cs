using System;
using IARA.Buniness.Uteis;
using MediatR;

namespace IARA.Buniness.CotacaoBusiness.BuscarCotacao
{
	public class BuscarCotacaoCommand : IRequest<RetornoApi>
	{
		public int Id { get; set; }
	}
}

