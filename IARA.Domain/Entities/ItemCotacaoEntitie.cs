using System;
using System.Collections.Generic;

namespace IARA.Domain.Entities
{
	public class ItemCotacaoEntitie
	{
        protected ItemCotacaoEntitie() { }

        public ItemCotacaoEntitie(string descricao, int numeroItem, long itemCotacaoId, decimal preco, int quantidade, string marca, string unidade)
        {
            Descricao = descricao;
            NumeroItem = numeroItem;
            ItemCotacaoId = itemCotacaoId;
            Preco = preco;
            Quantidade = quantidade;
            Marca = marca;
            Unidade = unidade;
        }

        public string Descricao { get; set; }
        public int NumeroItem { get; protected set; }
        public Int64 ItemCotacaoId { get; protected set; }
        public virtual CotacaoEntitie cotacao { get; protected set; }
        public decimal Preco { get; protected set; }
        public int Quantidade { get; protected set; }
        public string Marca { get; protected set; }
        public string Unidade { get; protected set; }
    }
}

