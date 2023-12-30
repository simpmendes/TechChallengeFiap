using TechChallengeFiap.Domain.Entities;

namespace TechChallengeFiap.Domain.Interfaces
{
    public interface IRepositoryBase<T> where T: Entity
    {
        IList<T> ObterTodos();
        T ObterPorId(int id);
        void Cadastrar(T entidade);
        void Alterar(T entidade);
        void Deletar(int id);
    }
}
