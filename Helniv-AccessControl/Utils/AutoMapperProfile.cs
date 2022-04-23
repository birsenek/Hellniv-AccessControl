using AutoMapper;
using Helniv_AccessControl.Entities;
using Helniv_AccessControl.Models;

namespace Helniv_AccessControl.Utils
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateRequestModel, User>();
        }
    }
}
