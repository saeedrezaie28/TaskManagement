using AutoMapper;

namespace TaskManagement.Domain
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.User.User, Domain.User.SelectUserDto>();
            CreateMap<Domain.User.CreateUserDto, Domain.User.User>();
            CreateMap<Domain.User.UpdateUserDto, Domain.User.User>();

            CreateMap<Domain.Task.Task, Domain.Task.SelectTaskDto>();
            CreateMap<Domain.Task.CreateTaskDto, Domain.Task.Task>();
            CreateMap<Domain.Task.UpdateTaskDto, Domain.Task.Task>();

            CreateMap<Domain.Project.Project, Domain.Project.SelectProjectDto>();
            CreateMap<Domain.Project.CreateProjectDto, Domain.Project.Project>();
            CreateMap<Domain.Project.UpdateProjectDto, Domain.Project.Project>();
        }
    }
}
