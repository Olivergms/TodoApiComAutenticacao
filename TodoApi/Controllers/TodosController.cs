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
    }
}
