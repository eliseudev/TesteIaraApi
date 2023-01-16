using System;
using IARA.Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace IARA.Domain.IRepositories
{
	public interface IItemCotacaoRepository
	{
        Task<ItemCotacaoEntitie> CriarItem(ItemCotacaoEntitie item);
        Task<ItemCotacaoEntitie> AtualizarItem(ItemCotacaoEntitie cotacao);
        Task<ItemCotacaoEntitie> ExcluirItem(ItemCotacaoEntitie cotacao);
        Task<ItemCotacaoEntitie> BuscarItem(Int64 Id);
        Task<List<ItemCotacaoEntitie>> BuscarTodosItens();
    }
}

