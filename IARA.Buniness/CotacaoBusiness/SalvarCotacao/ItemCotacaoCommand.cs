using System;
namespace IARA.Buniness.CotacaoBusiness.SalvarCotacao
{
	public class ItemCotacaoCommand
	{
        public string Descricao { get; set; }
        public int NumeroItem { get; set; }
        public int ItemCotacaoId { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public string Marca { get; set; }
        public string Unidade { get; set; }
    }
}

