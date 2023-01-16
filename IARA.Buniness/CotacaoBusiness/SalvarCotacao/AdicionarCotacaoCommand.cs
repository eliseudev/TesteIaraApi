using System;
using System.Collections.Generic;
using IARA.Buniness.Uteis;
using MediatR;

namespace IARA.Buniness.CotacaoBusiness.SalvarCotacao
{
	public class AdicionarCotacaoCommand : IRequest<RetornoApi>
	{
        public string CnpjCliente { get; set; }
        public string CnpjFornecedor { get; set; }
        public int NumeroCotacao { get; set; }
        public DateTime DataCotacao { get; set; }
        public DateTime DataEntregaCotacao { get; set; }
        public string Cep { get; set; }
        public string Endereco { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Observacao { get; set; }

        public virtual ICollection<ItemCotacaoCommand> CotacaoItem { get; set; } = new List<ItemCotacaoCommand>();
    }
}

