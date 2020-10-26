using AutoMapper;
using WebApi.Entities;
using WebApi.Models.Accounts;

namespace WebApi.Helpers
{
    public class AutoMapperProfile : Profile
    {
        // mappings between model and entity objects
        public AutoMapperProfile()
        {
            CreateMap<Tbl_Users, AccountResponse>();

            CreateMap<Tbl_Users, AuthenticateResponse>();

            CreateMap<RegisterRequest, Tbl_Users>();

            CreateMap<CreateRequest, Tbl_Users>();

            CreateMap<UpdateRequest, Tbl_Users>()
                .ForAllMembers(x => x.Condition(
                    (src, dest, prop) =>
                    {
                        // ignore null & empty string properties
                        if (prop == null) return false;
                        if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                        // ignore null role
                        if (x.DestinationMember.Name == "Role" && src.Role == null) return false;

                        return true;
                    }
                ));
        }
    }
}