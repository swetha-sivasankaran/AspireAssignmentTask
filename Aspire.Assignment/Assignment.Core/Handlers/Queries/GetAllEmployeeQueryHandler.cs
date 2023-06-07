using AutoMapper;
using Assignment.Contracts.Data;
using Assignment.Contracts.Data.Entities;
using Assignment.Contracts.DTO;
using MediatR;
using System.Linq;

namespace Assignment.Providers.Handlers.Queries
{
    
    public class GetAllEmployeeQuery : IRequest<IEnumerable<EmployeeDTO>>
    {
        
    }

    public class GetAllEmployeeQueryHandler : IRequestHandler<GetAllEmployeeQuery, IEnumerable<EmployeeDTO>>
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public GetAllEmployeeQueryHandler(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeDTO>> Handle(GetAllEmployeeQuery  request, CancellationToken cancellationToken)
        {   
            var entities = await Task.FromResult(_repository.Employee.GetAll().OrderByDescending(x => x.EmployeeDetailId).ToList());            
            return _mapper.Map<IEnumerable<EmployeeDTO>>(entities);
        }
    }
}