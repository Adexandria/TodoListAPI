using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Entity;
using Todo.ModelView;

namespace Todo.Profiles
{
    public class TodoProfile :Profile
    {
        public TodoProfile()
        {
            CreateMap<Tasks, TasksDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(dest => dest.Task, opt => opt.MapFrom(s => s.Task));

            CreateMap<Tasks, TaskDto>()
                .ForMember(dest => dest.Task, opt => opt.MapFrom(s => s.Task));

            CreateMap<TaskCreateDto, Tasks>().ForMember(dest => dest.Task, opt => opt.MapFrom(s => s.Task));

        }
    }
}
