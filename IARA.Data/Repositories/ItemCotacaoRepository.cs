using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IARA.Domain.Entities;
using IARA.Domain.IRepositories;

namespace IARA.Data.Repositories
{
    public class ItemCotacaoRepository : IItemCotacaoRepository
    {
        private readonly IaraContext _context;

        public ItemCotacaoRepository(IaraContext context)
        {
            _context = context;
        }

        public Task<ItemCotacaoEntitie> AtualizarItem(ItemCotacaoEntitie cotacao)
        {
            throw new NotImplementedException();
        }

        public Task<ItemCotacaoEntitie> BuscarItem(long Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ItemCotacaoEntitie>> BuscarTodosItens()
        {
            throw new NotImplementedException();
        }

        public Task<ItemCotacaoEntitie> CriarItem(ItemCotacaoEntitie item)
        {
            throw new NotImplementedException();
        }

        public Task<ItemCotacaoEntitie> ExcluirItem(ItemCotacaoEntitie cotacao)
        {
            throw new NotImplementedException();
        }
    }
}

