using AutoMapper;
using baby_shop_backend.DTO;
using baby_shop_backend.Models.UserModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace baby_shop_backend.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDTO, User>().ReverseMap();

        }
    }
}
