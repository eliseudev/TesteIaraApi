using System;
using System.Threading.Tasks;

namespace IARA.Buniness.Services.ViaCep
{
	public interface IViaCepService
	{
		Task<ViaCepEndereco> BuscarCep(string cep);
	}
}

