using Dominio.Entidades;
using Dominio.Interfaces;
using FluentResults;
using Infra.Data.SqlServer.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infra.Data.SqlServer.Repositorios
{
    public class TodoRepositorio : ITodoRepositorio
    {
        private readonly AppContexto _context;

        public TodoRepositorio(AppContexto context)
        {
            _context = context;
        }

        public Result Atualiza(int id, Todo entidade)
        {
            try
            {
                var data = _context.Todos.FirstOrDefault(e => e.Id == id);

                entidade.UpdatedAt = DateTime.Now;
                entidade.CreatedAt = data.CreatedAt;
                //pega os valores contidos em entidade e seta com os valores de data
                _context.Entry(data).CurrentValues.SetValues(entidade);

                _context.SaveChanges();

                return Result.Ok();

            }
            catch (Exception ex)
            {

                return Result.Fail("Não foi possivel completar a atividade").WithError(ex.Message);
            }
        }

        public Result CompletaAtividade(int id, bool completa)
        {
            try
            {
                var data = _context.Todos.FirstOrDefault(e => e.Id == id);
                data.Complete = completa;
                data.UpdatedAt = DateTime.Now;

                _context.SaveChanges();

                return Result.Ok();

            }
            catch (Exception ex)
            {

                return Result.Fail("Não foi possivel completar a atividade").WithError(ex.Message);
            }
        }

        public Result Inserir(Todo entidade)
        {
            try
            {
                entidade.CreatedAt = DateTime.Now;
                _context.Todos.Add(entidade);
                _context.SaveChanges();

                return Result.Ok();
            }
            catch (Exception ex)
            {
                return Result.Fail("Não foi possivel inserir registro no banco").WithError(ex.Message);
            }
        }

        public Todo ObterPorId(int id)
        {
            try
            {
                var todo = _context.Todos.FirstOrDefault(e => e.Id == id);

                return todo;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Todo> ObterTodos()
        {
            try
            {
                return _context.Todos.ToList();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Result Remover(int id)
        {
            try
            {
                var todo = _context.Todos.FirstOrDefault(e => e.Id == id);
                _context.Remove(todo);
                _context.SaveChanges();

                return Result.Ok();
            }
            catch (Exception ex)
            {

                return Result.Fail("não foi possivel remover o registro").WithError(ex.Message);
            }
        }
    }
}
