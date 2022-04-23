using AutoMapper;
using Dominio.Entidades;
using Dominio.Interfaces;
using FluentResults;
using Services.Dtos;
using Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Services.services
{
    public class TodoServico : ITodoServico
    {
        private readonly ITodoRepositorio _todoRepositorio;
        private readonly IMapper _mapper;

        public TodoServico(ITodoRepositorio todo, IMapper mapper)
        {
            _todoRepositorio = todo;
            _mapper = mapper;
        }

        public Result AtualizaTodo(int id, Todo entidade)
        {
            if (id != entidade.Id)
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

        public Result CriaTodo(CriarTodoDto entidade)
        {
            var todo = _mapper.Map<Todo>(entidade);

            var result = _todoRepositorio.Inserir(todo);

            return result.IsSuccess ? Result.Ok() : Result
                .Fail("Não foi possivel registrar atividade")
                .WithError(result.Errors.FirstOrDefault());
        }

        public Result<LerTodoDto> ObtemPorId(int id)
        {
            var result = _todoRepositorio.ObterPorId(id);

            var todo = _mapper.Map<LerTodoDto>(result);

            return result != null ? Result.Ok(todo) : Result.Fail("Não foi possivel obter atividade");
        }

        public Result<IEnumerable<LerTodoDto>> ObterTodos()
        {
            var result = _todoRepositorio.ObterTodos();

            var todos = new List<LerTodoDto>(); 

            foreach (var item in result)
            {
                todos.Add(_mapper.Map<LerTodoDto>(item));
            }
            ;
            return result != null ? Result.Ok(todos.AsEnumerable<LerTodoDto>()) : Result.Fail("Não foi possivel obter atividades");
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
