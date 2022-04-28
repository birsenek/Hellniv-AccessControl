using AutoMapper;
using Helniv_AccessControl.Entities;
using Helniv_AccessControl.Models;
using Helniv_AccessControl.Services;

namespace Helniv_AccessControl.Utils
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateRequestUserModel, User>();
            CreateMap<CreateRequestRoleModel, Role>();

            CreateMap<UpdateRequestUserModel, User>()
                .ForAllMembers(x => x.Condition(
                    (src, dest, prop) =>
                    {
                        //ignore null/empty properties
                        if (prop == null) return false;
                        if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                        return true;
                    }
                    ));
            CreateMap<UpdateRequestRoleModel, Role>()
                .ForAllMembers(r => r.Condition(
                    (src, dest, prop) =>
                    {
                        if (prop == null) return false;
                        if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                        return true;
                    }
                    ));
        }
    }
}
