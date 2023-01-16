using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IARA.Domain.Entities;
using IARA.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace IARA.Data.Repositories
{
    public class CotacaoRepositoty : ICotacaoRepository
    {
        private readonly IaraContext _context;

        public CotacaoRepositoty(IaraContext context)
        {
            _context = context;
        }

        public async Task<CotacaoEntitie> AtualizarCotacao(CotacaoEntitie cotacao)
        {
            var c = _context.Set<CotacaoEntitie>().Update(cotacao);
            await _context.SaveChangesAsync();
            return c.Entity;
        }

        public async Task<CotacaoEntitie> BuscarCotacao(int Id)
        {
            return await _context.Cotacao.AsNoTracking()
                .Include(x => x.CotacaoItem)
                .Where(x => x.IdCotacao == Id)
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<CotacaoEntitie>> BuscarTodasCotacoes()
        {
            return await _context.Cotacao.AsNoTracking()
                .Include(x => x.CotacaoItem)
                .ToListAsync();
        }

        public async Task<CotacaoEntitie> CriarCotacao(CotacaoEntitie cotacao)
        {
            var c = await _context.Set<CotacaoEntitie>().AddAsync(cotacao);
            await _context.SaveChangesAsync();
            return c.Entity;
        }

        public async Task<CotacaoEntitie> ExcluirCotacao(CotacaoEntitie cotacao)
        {
            var c = _context.Set<CotacaoEntitie>().Remove(cotacao);
            await _context.SaveChangesAsync();
            return c.Entity;
        }
    }
}

