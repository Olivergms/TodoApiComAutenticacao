using Dominio.Entidades;
using FluentResults;

namespace Dominio.Interfaces
{
    public interface ITodoRepositorio : IQuery<Todo>, ICommand<Todo>
    {
        public Result CompletaAtividade(int id, bool completa);
    }
}
