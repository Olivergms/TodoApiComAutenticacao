using Dominio.Entidades;
using FluentResults;
using Services.Dtos;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface ITodoServico
    {
        public Result<LerTodoDto> ObtemPorId(int id);
        public Result<IEnumerable<LerTodoDto>> ObterTodos();
        public Result CriaTodo(CriarTodoDto entidade);
        public Result CompletaAtividade(int id, bool completa);
        public Result AtualizaTodo(int id, AtualizaTodoDto entidade);
        public Result RemoveAtividade(int id);
    }
}
