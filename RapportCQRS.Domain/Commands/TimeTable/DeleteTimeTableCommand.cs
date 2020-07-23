using RapportCQRS.Domain.Commands.Common;
using RapportCQRS.Model.Dtos;

namespace RapportCQRS.Domain.Commands.TimeTable
{
    public class DeleteTimeTableCommand : DeleteBaseCommand<short, DeleteResult>
    {
    }
}
