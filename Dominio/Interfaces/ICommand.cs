using FluentResults;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public interface ICommand<T>
    {
        public Result Inserir(T entidade);
        public Result Atualiza(int id, T entidade);
        public Result Remover(int id);
    }
}
