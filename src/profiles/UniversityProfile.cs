using AutoMapper;
using yume_api.src.dtos;
using yume_api.src.repository.entities;


namespace yume_api.src.profiles
{
  public class UniversityProfile : Profile
  {
    public UniversityProfile()
    {
      CreateMap<User, UserDTO>();
      CreateMap<UserDTO, User>();
    }
  }
}
