using System;
using IARA.Buniness.Uteis;
using MediatR;

namespace IARA.Buniness.CotacaoBusiness.BuscarTodasCotacoes
{
	public class ListarTodasCotacoesCommand : IRequest<RetornoApi>
	{
		public int Id { get; set; }
	}
}

