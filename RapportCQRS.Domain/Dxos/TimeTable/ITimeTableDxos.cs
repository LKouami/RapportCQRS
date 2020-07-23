using RapportCQRS.Domain.Commands.TimeTable;
using RapportCQRS.Model.Dtos;
using RapportCQRS.Model.Models;
using RapportCQRS.Domain.Dxos.Common;

namespace RapportCQRS.Domain.Dxos
{
    public interface ITimeTableDxos : IBaseDxos
    {
        TimeTableDto MapTimeTableDto(STimeTable timeTable);
        STimeTable MapCreateRequesttoTimeTable(CreateTimeTableCommand timeTable);
        STimeTable MapUpdateRequesttoTimeTable(UpdateTimeTableCommand timeTable);
    }
}
