using lista6.Models;

namespace lista6.Service
{
    public interface IPessoaRepository
    {
        void Inserir(Pessoa pessoa);
        void Atualizar(Pessoa pessoa);
        void Deletar(string cpf);
        Pessoa BuscarPorCpf(string cpf);
        List<Pessoa> BuscarTodos();
        List<Pessoa> BuscarPorImc(double imc);
        List<Pessoa> BuscarPorNome(string nome);

    }
}
