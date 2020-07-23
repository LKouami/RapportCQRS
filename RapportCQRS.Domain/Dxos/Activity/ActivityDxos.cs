using AutoMapper;
using RapportCQRS.Domain.Commands.Activity;
using RapportCQRS.Model.Dtos;
using RapportCQRS.Model.Models;
using RapportCQRS.Domain.Dxos.Common;

namespace RapportCQRS.Domain.Dxos
{
    public class ActivityDxos : BaseDxos, IActivityDxos
    {
        public ActivityDxos()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SActivity, ActivityDto>()
                  .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                  .ForMember(dst => dst.UserId, opt => opt.MapFrom(src => src.UserId))
                  .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status))
                  .ForMember(dst => dst.ContenuAct, opt => opt.MapFrom(src => src.ContenuAct))
                  .ForMember(dst => dst.ModifiedAt, opt => opt.MapFrom(src => src.ModifiedAt))
                  .ForMember(dst => dst.ModifiedBy, opt => opt.MapFrom(src => src.ModifiedBy))
                    ;

                cfg.CreateMap<CreateActivityCommand, SActivity>()
                  .ForMember(dst => dst.UserId, opt => opt.MapFrom(src => src.UserId))
                  .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status))
                  .ForMember(dst => dst.ContenuAct, opt => opt.MapFrom(src => src.ContenuAct))
                    ;


                cfg.CreateMap<UpdateActivityCommand, SActivity>()
                   .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                  .ForMember(dst => dst.UserId, opt => opt.MapFrom(src => src.UserId))
                  .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status))
                  .ForMember(dst => dst.ContenuAct, opt => opt.MapFrom(src => src.ContenuAct))
                    ;
            });

            _mapper = config.CreateMapper();
        }

        public SActivity MapCreateRequesttoActivity(CreateActivityCommand request)
        {
            return _mapper.Map<CreateActivityCommand, SActivity>(request);
        }

        public ActivityDto MapActivityDto(SActivity ActivityModel)
        {
            return _mapper.Map<SActivity, ActivityDto>(ActivityModel);
        }

        public SActivity MapUpdateRequesttoActivity(UpdateActivityCommand request)
        {
            return _mapper.Map<UpdateActivityCommand, SActivity>(request);
        }
    }
}
