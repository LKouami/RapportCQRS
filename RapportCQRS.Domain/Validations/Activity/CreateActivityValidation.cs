using RapportCQRS.Domain.Commands.Activity;
using FluentValidation;
using RapportCQRS.Model.Models;
using System.Linq;

namespace RapportCQRS.Domain.Validations.Activity
{
    public class CreateActivityValidation : AbstractValidator<CreateActivityCommand>
    {
        RapportCQRSDbContext _dbContext;

        public CreateActivityValidation(RapportCQRSDbContext dbContext)
        {
            _dbContext = dbContext;

            RuleFor(x => x.ContenuAct).NotNull();

            RuleFor(x => x.ContenuAct).Length(2,255);

            //RuleFor(x => x.Name).Must(BeNotADuplicate)
            //    .WithMessage("There is already another bank with the same name");
        }

        private bool BeNotADuplicate(string name)
        {
            bool existAlready = _dbContext.SActivity.Any(d => d.ContenuAct.ToLower().Equals(name.ToLower()));

            return !existAlready;
        }
    }
}