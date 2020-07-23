//using RapportCQRS.Data.IRepositories;
//using RapportCQRS.Domain.Events.Department;
//using MediatR;
//using Microsoft.Extensions.Logging;
//using System;
//using System.Threading;
//using System.Threading.Tasks;

//namespace RapportCQRS.Service.Subcribers
//{
//    public class DepartmentCreatedHandler : INotificationHandler<DepartmentCreatedEvent>
//    {
//        private readonly IDepartmentRepository _DepartmentRepository;
//        private readonly ILogger _logger;

//        public DepartmentCreatedHandler(IDepartmentRepository DepartmentRepository, ILogger<DepartmentCreatedHandler> logger)
//        {
//            _DepartmentRepository = DepartmentRepository ?? throw new ArgumentNullException(nameof(DepartmentRepository));
//            _logger = logger;
//        }

//        public async Task Handle(DepartmentCreatedEvent notification, CancellationToken cancellationToken)
//        {
//            var Department = await _DepartmentRepository.GetAsync(e => e.Id == notification.DepartmentId);

//            if (Department == null)
//            {
//                //TODO: Handle next business logic if Department is not found
//                _logger.LogWarning("Department is not found by Department id from publisher");
//            }
//            else
//            {
//                _logger.LogInformation($"Department has found by Department id: {notification.DepartmentId} from publisher");
//            }
//        }
//    }
//}