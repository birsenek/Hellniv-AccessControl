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

            CreateMap<UpdateRequestModel, User>()
                .ForAllMembers(x => x.Condition(
                    (src, dest, prop) =>
                    {
                        //ignore null/empty properties
                        if (prop == null) return false;
                        if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                        return true;
                    }
                    ));
        }
    }
}
