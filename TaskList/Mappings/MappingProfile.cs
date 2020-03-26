using System.Collections.Generic;
using AutoMapper;
using TaskList.Domain.Models;
using TaskList.Models;

namespace TaskList.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TaskViewModel, Task>()
                .ForMember(model => model.Status, opt => opt.MapFrom(account => account.Status));

            CreateMap<Task, TaskViewModel>()
                .ForMember(model => model.Status, opt => 
                    opt.MapFrom(account => account.Status));


        }
    }
}