using System;
using System.Collections.Generic;

namespace IARA.Domain.Entities
{
	public class CotacaoEntitie
	{
        protected CotacaoEntitie() { }

        public CotacaoEntitie(string cnpjCliente, string cnpjFornecedor, int numeroCotacao, DateTime dataCotacao, DateTime dataEntregaCotacao,
                              string cep, string endereco, string complemento, string bairro, string cidade, string estado, string observacao,
                              ICollection<ItemCotacaoEntitie> cotacaoItem)
        {
            CnpjCliente = cnpjCliente;
            CnpjFornecedor = cnpjFornecedor;
            DataCotacao = dataCotacao;
            NumeroCotacao = numeroCotacao;
            DataEntregaCotacao = dataEntregaCotacao;
            Cep = cep;
            Endereco = endereco;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Observacao = observacao;
            CotacaoItem = cotacaoItem;
        }
        public int IdCotacao { get; set; }
        public string CnpjCliente { get; private set; }
        public string CnpjFornecedor { get; private set; }
        public int NumeroCotacao { get; private set; }
        public DateTime DataCotacao { get; private set; }
        public DateTime DataEntregaCotacao { get; private set; }
        public string Cep { get; private set; }
        public string Endereco { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public string Observacao { get; private set; }

        public virtual ICollection<ItemCotacaoEntitie> CotacaoItem { get; private set; } = new List<ItemCotacaoEntitie>();

        public void Update(string cnpjCliente, string cnpjFornecedor, int numeroCotacao, DateTime dataCotacao, DateTime dataEntregaCotacao,
                           string cep, string endereco, string complemento, string bairro, string cidade, string estado, string observacao,
                           ICollection<ItemCotacaoEntitie> cotacaoItem)
        {
            CnpjCliente = cnpjCliente;
            CnpjFornecedor = cnpjFornecedor;
            DataCotacao = dataCotacao;
            NumeroCotacao = numeroCotacao;
            DataEntregaCotacao = dataEntregaCotacao;
            Cep = cep;
            Endereco = endereco;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Observacao = observacao;
            CotacaoItem = cotacaoItem;
        }
    }
}

