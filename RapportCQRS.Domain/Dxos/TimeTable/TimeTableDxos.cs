using AutoMapper;
using RapportCQRS.Domain.Commands.TimeTable;
using RapportCQRS.Model.Dtos;
using RapportCQRS.Model.Models;
using RapportCQRS.Domain.Dxos.Common;

namespace RapportCQRS.Domain.Dxos
{
    public class TimeTableDxos : BaseDxos, ITimeTableDxos
    {
        public TimeTableDxos()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<STimeTable, TimeTableDto>()
                  .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                  .ForMember(dst => dst.UserId, opt => opt.MapFrom(src => src.UserId))
                  .ForMember(dst => dst.DateDuJour, opt => opt.MapFrom(src => src.DateDuJour))
                  .ForMember(dst => dst.HeureArrive, opt => opt.MapFrom(src => src.HeureArrive))
                  .ForMember(dst => dst.HeureDepart, opt => opt.MapFrom(src => src.HeureDepart))
                  .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status))
                  .ForMember(dst => dst.ModifiedAt, opt => opt.MapFrom(src => src.ModifiedAt))
                  .ForMember(dst => dst.ModifiedBy, opt => opt.MapFrom(src => src.ModifiedBy))
                    ;

                cfg.CreateMap<CreateTimeTableCommand, STimeTable>()
                  .ForMember(dst => dst.UserId, opt => opt.MapFrom(src => src.UserId))
                  .ForMember(dst => dst.DateDuJour, opt => opt.MapFrom(src => src.DateDuJour))
                  .ForMember(dst => dst.HeureArrive, opt => opt.MapFrom(src => src.HeureArrive))
                  .ForMember(dst => dst.HeureDepart, opt => opt.MapFrom(src => src.HeureDepart))
                  .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status))
                  .ForMember(dst => dst.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                  .ForMember(dst => dst.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
                  .ForMember(dst => dst.ModifiedAt, opt => opt.MapFrom(src => src.CreatedAt))
                  .ForMember(dst => dst.ModifiedBy, opt => opt.MapFrom(src => src.CreatedBy))
                  ;


                cfg.CreateMap<UpdateTimeTableCommand, STimeTable>()
                    .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                  .ForMember(dst => dst.UserId, opt => opt.MapFrom(src => src.UserId))
                  .ForMember(dst => dst.DateDuJour, opt => opt.MapFrom(src => src.DateDuJour))
                  .ForMember(dst => dst.HeureArrive, opt => opt.MapFrom(src => src.HeureArrive))
                  .ForMember(dst => dst.HeureDepart, opt => opt.MapFrom(src => src.HeureDepart))
                  .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status))
                  .ForMember(dst => dst.ModifiedAt, opt => opt.MapFrom(src => src.ModifiedAt))
                  .ForMember(dst => dst.ModifiedBy, opt => opt.MapFrom(src => src.ModifiedBy))
                  ;
            });

            _mapper = config.CreateMapper();
        }

        public STimeTable MapCreateRequesttoTimeTable(CreateTimeTableCommand request)
        {
            return _mapper.Map<CreateTimeTableCommand, STimeTable>(request);
        }

        public TimeTableDto MapTimeTableDto(STimeTable TimeTableModel)
        {
            return _mapper.Map<STimeTable, TimeTableDto>(TimeTableModel);
        }

        public STimeTable MapUpdateRequesttoTimeTable(UpdateTimeTableCommand request)
        {
            return _mapper.Map<UpdateTimeTableCommand, STimeTable>(request);
        }
    }
}
