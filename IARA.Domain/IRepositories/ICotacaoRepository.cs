using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IARA.Domain.Entities;

namespace IARA.Domain.IRepositories
{
	public interface ICotacaoRepository
	{
		Task<CotacaoEntitie> CriarCotacao(CotacaoEntitie cotacao);
		Task<CotacaoEntitie> AtualizarCotacao(CotacaoEntitie cotacao);
		Task<CotacaoEntitie> ExcluirCotacao(CotacaoEntitie cotacao);
		Task<CotacaoEntitie> BuscarCotacao(int Id);
		Task<IEnumerable<CotacaoEntitie>> BuscarTodasCotacoes();
	}
}

