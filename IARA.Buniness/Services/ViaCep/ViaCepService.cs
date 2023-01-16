using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Flurl.Http;
using IARA.Buniness.Uteis;
using Microsoft.Extensions.Configuration;
using ServiceStack;

namespace IARA.Buniness.Services.ViaCep
{
    public class ViaCepService : IViaCepService
    {
        private IConfiguration _configuration;
            
        public async Task<ViaCepEndereco> BuscarCep(string cep)
        {
            string url = $"https://viacep.com.br/ws/{cep}/json";
            var retorno = url.GetJsonFromUrl().FromJson<ViaCepEndereco>();
            return retorno;
        }
    }
}

