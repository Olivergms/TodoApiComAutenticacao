using Dominio.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Dtos;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodosController : ControllerBase
    {
        private readonly ITodoServico _todoServico;

        public TodosController(ITodoServico todoServico)
        {
            _todoServico = todoServico;
        }

        [HttpGet("{id:int}")]
        public ActionResult<Todo> ObterPorId(int id)
        {
            try
            {
                var result = _todoServico.ObtemPorId(id);

                return result.IsSuccess ? StatusCode(StatusCodes.Status200OK, result.Value)
                    : StatusCode(StatusCodes.Status400BadRequest, result.Errors.FirstOrDefault());
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<LerTodoDto>> ObterTodos()
        {
            try
            {
                var result = _todoServico.ObterTodos();

                return result.IsSuccess ? StatusCode(StatusCodes.Status200OK, result.Value)
                    : StatusCode(StatusCodes.Status400BadRequest, result.Errors.FirstOrDefault());
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult CriarAtividade([FromBody] CriarTodoDto todo)
        {
            try
            {
                var result = _todoServico.CriaTodo(todo);

                return result.IsSuccess ? StatusCode(StatusCodes.Status201Created)
                    : StatusCode(StatusCodes.Status400BadRequest, result.Errors.FirstOrDefault());
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult RemoverAtividade(int id)
        {
            try
            {
                var result = _todoServico.RemoveAtividade(id);

                return result.IsSuccess ? StatusCode(StatusCodes.Status200OK)
                    : StatusCode(StatusCodes.Status400BadRequest, result.Errors.FirstOrDefault());
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult AtualizaAtividade(int id, [FromBody]AtualizaTodoDto todo)
        {
            try
            {
                var result = _todoServico.AtualizaTodo(id, todo);

                return result.IsSuccess ? StatusCode(StatusCodes.Status200OK)
                    : StatusCode(StatusCodes.Status400BadRequest, result.Errors.FirstOrDefault());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }

        [HttpPatch("{id:int}")]
        public ActionResult CompletaAtividade(int id, bool completa)
        {
            try
            {
                var result = _todoServico.CompletaAtividade(id, completa);

                return result.IsSuccess ? StatusCode(StatusCodes.Status200OK)
                    : StatusCode(StatusCodes.Status400BadRequest, result.Errors.FirstOrDefault());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }
    }
}
