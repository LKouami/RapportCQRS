using AutoMapper;
using RapportCQRS.Domain.Commands.User;
using RapportCQRS.Model.Dtos;
using RapportCQRS.Model.Models;
using RapportCQRS.Domain.Dxos.Common;

namespace RapportCQRS.Domain.Dxos
{
    public class UserDxos : BaseDxos, IUserDxos
    {

        public UserDxos()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AUser, UserDto>()
                    .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dst => dst.Token, opt => opt.MapFrom(src => src.Token))
                    .ForMember(dst => dst.Email, opt => opt.MapFrom(src => src.Email))
                    .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status))
                  .ForMember(dst => dst.Password, opt => opt.MapFrom(src => src.Password))
                    .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status))
                  .ForMember(dst => dst.ModifiedAt, opt => opt.MapFrom(src => src.ModifiedAt))
                  .ForMember(dst => dst.ModifiedBy, opt => opt.MapFrom(src => src.ModifiedBy))
                    ;

                cfg.CreateMap<CreateUserCommand, AUser>()
                    .ForMember(dst => dst.Id, opt => opt.MapFrom(src => 0))
                    .ForMember(dst => dst.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dst => dst.Token, opt => opt.MapFrom(src => src.Token))
                  .ForMember(dst => dst.Password, opt => opt.MapFrom(src => src.Password))
                    .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status));

                cfg.CreateMap<UpdateUserCommand, AUser>()
                                 .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                                 .ForMember(dst => dst.Email, opt => opt.MapFrom(src => src.Email))
                                 .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status))
                                 .ForMember(dst => dst.Password, opt => opt.MapFrom(src => src.Password))
                                 .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status))
                                 ;

            });

            _mapper = config.CreateMapper();
        }

        public AUser MapCreateRequesttoUser(CreateUserCommand request)
        {
            return _mapper.Map<CreateUserCommand, AUser>(request);
        }

        public UserDto MapUserDto(AUser employee)
        {
            return _mapper.Map<AUser, UserDto>(employee);
        }

        public AUser MapUpdateRequesttoUser(UpdateUserCommand request)
        {
            return _mapper.Map<UpdateUserCommand, AUser>(request);
        }
    }
}