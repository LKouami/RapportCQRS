using RapportCQRS.Domain.Commands.Common;
using RapportCQRS.Model.Dtos;

namespace RapportCQRS.Domain.Commands.Activity
{
    public class DeleteActivityCommand : DeleteBaseCommand<short, DeleteResult>
    {
    }
}
