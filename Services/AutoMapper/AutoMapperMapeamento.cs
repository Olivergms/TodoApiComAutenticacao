using AutoMapper;
using Dominio.Entidades;
using Services.Dtos;

namespace Services.AutoMapper
{
    public class AutoMapperMapeamento : Profile
    {
        public AutoMapperMapeamento()
        {
            TodoDtos();
        }

        private void TodoDtos()
        {
            CreateMap<CriarTodoDto, Todo>();
            CreateMap<Todo, LerTodoDto>();
            CreateMap<AtualizaTodoDto, Todo>();
        }
    }
}
