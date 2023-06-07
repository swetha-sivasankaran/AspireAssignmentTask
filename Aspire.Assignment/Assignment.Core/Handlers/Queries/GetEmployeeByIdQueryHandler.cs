using MediatR;
using Assignment.Contracts.DTO;
using Assignment.Contracts.Data;
using Assignment.Core.Exceptions;
using AutoMapper;

namespace Assignment.Providers.Handlers.Queries
{
    public class GetEmployeeByIdQuery : IRequest<EmployeeDTO>
    {
        public int EmpId { get; }
        public GetEmployeeByIdQuery(int empId)
        {
            EmpId = empId;
        }
    }

    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeDTO>
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public GetEmployeeByIdQueryHandler(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<EmployeeDTO> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var employee = await Task.FromResult(_repository.Employee.Get(request.EmpId));

            if (employee == null)
            {
                throw new EntityNotFoundException($"No App found for Id {request.EmpId}");
            }

            return _mapper.Map<EmployeeDTO>(employee);
        }
    }
}