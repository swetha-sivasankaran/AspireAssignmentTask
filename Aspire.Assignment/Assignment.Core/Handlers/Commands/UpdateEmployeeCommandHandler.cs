using MediatR;
using Assignment.Contracts.Data;
using Assignment.Contracts.DTO;
using Assignment.Contracts.Data.Entities;
using FluentValidation;
using System.Text.Json;
using Assignment.Core.Exceptions;
using AutoMapper;


namespace Assignment.Providers.Handlers.Commands
{
    public class UpdateEmployeeCommand : IRequest<int>
    {
        public CreateEmployeeDTO Model { get;}

        public UpdateEmployeeCommand(CreateEmployeeDTO model)
        {
            this.Model = model;
        }

        
    }

    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, int>
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateEmployeeDTO> _validator;



        public UpdateEmployeeCommandHandler(IUnitOfWork repository,IValidator<CreateEmployeeDTO> validator, IMapper mapper)
        {
            _repository = repository;
            _validator= validator;
            _mapper =mapper;
        }

        public async Task<int> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            CreateEmployeeDTO model = _mapper.Map<CreateEmployeeDTO>(request.Model);

            var result = _validator.Validate(model);


            if (!result.IsValid)
            {
                var errors = result.Errors.Select(x => x.ErrorMessage).ToArray();
                throw new InvalidRequestBodyException
                {
                    Errors = errors
                };
            }

            var employee= _mapper.Map<EmployeeDetail>(request.Model);
            _repository.Employee.Update(employee);
            await _repository.CommitAsync();

            return employee.EmployeeDetailId;
        }
    }
}