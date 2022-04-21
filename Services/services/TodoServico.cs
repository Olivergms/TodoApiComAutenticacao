using Dominio.Entidades;
using Dominio.Interfaces;
using FluentResults;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.services
{
    public class TodoServico : ITodoServico
    {
        private readonly ITodoRepositorio _todoRepositorio;

        public TodoServico(ITodoRepositorio todo)
        {
            _todoRepositorio = todo;
        }

        public Result AtualizaTodo(int id, Todo entidade)
        {
            if(id != entidade.Id)
            {
                return Result.Fail("o id informado é diferente do objeto");
            }

            var result = _todoRepositorio.Atualiza(id, entidade);

            return result.IsSuccess ? Result.Ok() : Result
                .Fail("Não foi possivel atualizar entidade")
                .WithError(result.Errors.FirstOrDefault());
        }

        public Result CompletaAtividade(int id, bool completa)
        {
            var result = _todoRepositorio.CompletaAtividade(id, completa);

            return result.IsSuccess ? Result.Ok() : Result
                .Fail("Não foi possivel atualizar atividade")
                .WithError(result.Errors.FirstOrDefault());
        }

        public Result CriaTodo(Todo entidade)
        {
            var result = _todoRepositorio.Inserir(entidade);

            return result.IsSuccess ? Result.Ok() : Result
                .Fail("Não foi possivel registrar atividade")
                .WithError(result.Errors.FirstOrDefault());
        }

        public Result<Todo> ObtemPorId(int id)
        {
            var result = _todoRepositorio.ObterPorId(id);

            return result != null ? Result.Ok(result) : Result.Fail("Não foi possivel obter atividade");
        }

        public Result<IEnumerable<Todo>> ObterTodos()
        {
            var result = _todoRepositorio.ObterTodos();

            return result != null ? Result.Ok(result) : Result.Fail("Não foi possivel obter atividades");
        }

        public Result RemoveAtividade(int id)
        {
            var result = _todoRepositorio.Remover(id);

            return result.IsSuccess ? Result.Ok() : Result
                .Fail("Não foi possivel atualizar atividade")
                .WithError(result.Errors.FirstOrDefault());
        }
    }
}
