using AutoMapper;
using HighfieldTest.Data.Models;
using HighfieldTest.Services.Models;
using HighfieldTest.Views.Models;

namespace HighfieldTest.Mapper
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<UserDto, User>()
                .ReverseMap();

            CreateMap<UserColourAges, UserColourAgesViewModel>()
                .ReverseMap();

            CreateMap<User, UsersViewModel>()
                .ReverseMap();

            CreateMap<Age, AgeViewModel>()
                .ReverseMap();

            CreateMap<Colour, ColourViewModel>()
             .ReverseMap();

            CreateMap<User, UserDto>()
              .ReverseMap();

            CreateMap<Age, AgesDto>()
                .ReverseMap();

            CreateMap<Colour, ColourDto>()
                .ReverseMap();

            CreateMap<UserColourAges, UserColourAgesDto>()
                .ReverseMap();
        }
    }
}
