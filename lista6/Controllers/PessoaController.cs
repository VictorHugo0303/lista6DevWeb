using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using lista6.Validation;
using lista6.Service;
using lista6.Models;

namespace lista6.Controllers
{
    [Route("api/[controller]")]
                                       
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaController (IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        [HttpPost]
        [Route("Inserir")]
        public IActionResult Inserir(Pessoa pessoa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _pessoaRepository.Inserir(pessoa);

            return Ok($"{pessoa.Nome} inserido com sucesso. IMC calculado: {pessoa.Imc()}");
        }

        [HttpPut]
        [Route("AtualizarPessoa")]

        public IActionResult Atualizar(string cpf, Pessoa pessoa)
        {
            var pessoaPesquisado = _pessoaRepository.BuscarPorCpf(cpf);


            if (pessoaPesquisado is null)
                return NotFound($"Pessoa com cpf {cpf} não encontrado.");

            _pessoaRepository.Atualizar(pessoa);

            return Ok($"{pessoa.Nome} Atualizado com sucesso. IMC calculado: {pessoa.Imc()}");
        }

        [HttpDelete]
        [Route("DeletePessoa")]

        public IActionResult Deletar(string cpf)
        {
            var PessoaPesquisado = _pessoaRepository.BuscarPorCpf(cpf);

            if (PessoaPesquisado is null)
                return NotFound($"CPF {cpf} não encontrado.");

            _pessoaRepository.Deletar(cpf);

            return Ok("Pessoa excluida");
        }

        [HttpGet]
        [Route("BuscarPessoa")]

        public IActionResult BuscarTodos()
        {
            return Ok(_pessoaRepository.BuscarTodos());
        }

        [HttpGet]
        [Route("EspecificaCpf")]

        public IActionResult BuscarPorCpf(string cpf)
        {
            var PessoaPesquisando = _pessoaRepository.BuscarPorCpf(cpf);

            if (PessoaPesquisando is null)
                return NotFound($"CPF {cpf} não encontrado.");

            return Ok(PessoaPesquisando);
        }

        [HttpGet]
        [Route("EspecificaImc")]

        public IActionResult BuscarPorImc(double Imc)
        {
            var PessoaPesquisando = _pessoaRepository.BuscarPorImc(Imc);

            if (PessoaPesquisando is null)
                return NotFound($"IMC {Imc} não encontrado.");

            return Ok(PessoaPesquisando);
        }

        [HttpGet]
        [Route("EspecificaNome")]

        public IActionResult BuscarNome(string Nome)
        {
            var PessoaPesquisando = _pessoaRepository.BuscarPorNome(Nome);

            if (PessoaPesquisando is null)
                return NotFound($"Nome {Nome} não encontrado.");

            return Ok(PessoaPesquisando); ;
        }
    }
}
