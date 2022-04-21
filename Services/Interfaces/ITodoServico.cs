using Dominio.Entidades;
using FluentResults;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface ITodoServico
    {
        public Result<Todo> ObtemPorId(int id);
        public Result<IEnumerable<Todo>> ObterTodos();
        public Result CriaTodo(Todo entidade);
        public Result CompletaAtividade(int id, bool completa);
        public Result AtualizaTodo(int id, Todo entidade);
        public Result RemoveAtividade(int id);
    }
}
