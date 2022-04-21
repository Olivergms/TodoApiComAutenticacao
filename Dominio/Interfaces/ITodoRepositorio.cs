using Dominio.Entidades;
using FluentResults;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public interface ITodoRepositorio : IQuery<Todo>, ICommand<Todo>
    {
        public Result CompletaAtividade(int id, bool completa);
    }
}
