using lista6.Models;

namespace lista6.Service
{
    public class PessoaRepository : IPessoaRepository
    {
        private static List<Pessoa> listaPessoa = [];

        public void Inserir(Pessoa pessoa)
        {
            listaPessoa.Add(pessoa);
        }

        public void Atualizar(Pessoa pessoa)
        {
            var pessoaExistente = BuscarPorCpf(pessoa.Cpf);
            if (pessoaExistente != null)
            {
                pessoaExistente.Nome = pessoa.Nome;
                pessoaExistente.Peso = pessoa.Peso;
                pessoaExistente.Altura = pessoa.Altura;
            }
        }

        public void Deletar(string cpf)
        {
            var pessoaRemover = BuscarPorCpf(cpf);
            if (pessoaRemover != null)
            {
                listaPessoa.Remove(pessoaRemover);
            }
        }
        public List<Pessoa> BuscarTodos()
        {
            return listaPessoa;
        }

        public Pessoa BuscarPorCpf(string cpf)
        {
            var pessoaPesquisando = listaPessoa.FirstOrDefault(Busca => Busca.Cpf == cpf);

            return pessoaPesquisando;
        }

        public List<Pessoa> BuscarPorImc(double imc)
        {
            return listaPessoa.Where(p => Math.Abs(p.Imc() - imc) < 0.01).ToList();
        }

        public List<Pessoa> BuscarPorNome(string nome)
        {
            return listaPessoa.Where(Busca => Busca.Nome.Equals(nome)).ToList();
        }

    }
}
