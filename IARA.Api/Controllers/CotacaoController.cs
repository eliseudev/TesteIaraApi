using System.Threading.Tasks;
using IARA.Buniness.CotacaoBusiness.AtualizarCotacao;
using IARA.Buniness.CotacaoBusiness.BuscarCotacao;
using IARA.Buniness.CotacaoBusiness.ExcluirCotacao;
using IARA.Buniness.CotacaoBusiness.SalvarCotacao;
using IARA.Buniness.Uteis;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IARA.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CotacaoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CotacaoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(RetornoApi), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoApi), StatusCodes.Status400BadRequest)]
        public async Task<RetornoApi> Post(AdicionarCotacaoCommand command) =>
            await _mediator.Send(command);

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(RetornoApi), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoApi), StatusCodes.Status400BadRequest)]
        public async Task<RetornoApi> Get(int id) =>
            await _mediator.Send(new BuscarCotacaoCommand() { Id = id });

        [HttpGet]
        [ProducesResponseType(typeof(RetornoApi), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoApi), StatusCodes.Status400BadRequest)]
        public async Task<RetornoApi> Get()=>
            await _mediator.Send(new BuscarCotacaoCommand());

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(RetornoApi), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoApi), StatusCodes.Status400BadRequest)]
        public async Task<RetornoApi> Put(AtualizarCotacaoCommand command, int id)
        {
            command.IdCotacao = id;
            return await _mediator.Send(command);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(RetornoApi), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoApi), StatusCodes.Status400BadRequest)]
        public async Task<RetornoApi> Delete(int id) =>
            await _mediator.Send(new ExcluirCotacaoCommand { Id = id});


    }
}

