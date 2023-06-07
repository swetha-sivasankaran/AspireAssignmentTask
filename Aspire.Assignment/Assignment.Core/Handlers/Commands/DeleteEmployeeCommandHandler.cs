using MediatR;
using Assignment.Contracts.Data;
using Assignment.Contracts.DTO;
using Assignment.Contracts.Data.Entities;
using FluentValidation;
using System.Text.Json;
using Assignment.Core.Exceptions;

namespace Assignment.Providers.Handlers.Commands
{
    public class DeleteEmployeeCommand : IRequest<int>
    {
        public int EmpId { get; }

        public DeleteEmployeeCommand(int empId)
        {
            EmpId = empId;
        }

        
    }

    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, int>
    {
        private readonly IUnitOfWork _repository;

        public DeleteEmployeeCommandHandler(IUnitOfWork repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {

            var employee = await Task.FromResult(_repository.Employee.Get(request.EmpId));
           if (employee == null)
            {
                throw new EntityNotFoundException($"No App found for Id {request.EmpId}");
            }
            _repository.Employee.Delete(employee.EmployeeDetailId);
             await _repository.CommitAsync();

            return employee.EmployeeDetailId;
        }
    }
}