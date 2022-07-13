using AutoMapper;
using ToDoProject.Application.Commands.ToDoList;
using ToDoProject.Application.Commands.ToDoListItem;
using ToDoProject.Application.Models;
using ToDoProject.Domain.Entities;

namespace ToDoProject.Application.AutoMapper
{
    public class ToDoListMapper : Profile
    {
        public ToDoListMapper()
        {
            CreateMap<ToDoList, ToDoListEntity>()
                .ReverseMap()
                .ForMember(entity => entity.Items, expression => expression.MapFrom(src => src.ItemsEntities));

            CreateMap<CreateToDoListCommand, ToDoListEntity>()
                .ForMember(entity => entity.Name, expression => expression.MapFrom(src => src.Name))
                .ForMember(entity => entity.User, expression => expression.MapFrom(src => src.User));

            CreateMap<UpdateToDoListCommand, ToDoListEntity>()
                .ForMember(entity => entity.Name, expression => expression.MapFrom(src => src.Name))
                .ForMember(entity => entity.User, expression => expression.MapFrom(src => src.User));


            CreateMap<ToDoListItem, ToDoListItemEntity>()
                .ReverseMap();

            CreateMap<CreateToDoListItemCommand, ToDoListItemEntity>()
                .ForMember(entity => entity.ToDoListEntityId, expression => expression.MapFrom(src => src.ToDoListEntityId))
                .ForMember(entity => entity.Name, expression => expression.MapFrom(src => src.Name))
                .ForMember(entity => entity.Description, expression => expression.MapFrom(src => src.Description))
                .ForMember(entity => entity.Status, expression => expression.MapFrom(src => src.Status));

            CreateMap<UpdateToDoListItemCommand, ToDoListItemEntity>()
                .ForMember(entity => entity.ToDoListEntityId, expression => expression.MapFrom(src => src.ToDoListEntityId))
                .ForMember(entity => entity.Name, expression => expression.MapFrom(src => src.Name))
                .ForMember(entity => entity.Description, expression => expression.MapFrom(src => src.Description))
                .ForMember(entity => entity.Status, expression => expression.MapFrom(src => src.Status));
        }
    }
}
