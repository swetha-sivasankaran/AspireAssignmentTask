using MediatR;
using Assignment.Contracts.Data;
using Assignment.Contracts.DTO;
using Assignment.Contracts.Data.Entities;
using FluentValidation;
using System.Text.Json;
using Assignment.Core.Exceptions;

namespace Assignment.Providers.Handlers.Commands
{
    public class CreateAppCommand : IRequest<int>
    {
        public CreateAppDTO Model { get; }
        public CreateAppCommand(CreateAppDTO model)
        {
            this.Model = model;
        }
    }

    public class CreateAppCommandHandler : IRequestHandler<CreateAppCommand, int>
    {
        private readonly IUnitOfWork _repository;
        private readonly IValidator<CreateAppDTO> _validator;

        public CreateAppCommandHandler(IUnitOfWork repository, IValidator<CreateAppDTO> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<int> Handle(CreateAppCommand request, CancellationToken cancellationToken)
        {
            CreateAppDTO model = request.Model;

            var result = _validator.Validate(model);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(x => x.ErrorMessage).ToArray();
                throw new InvalidRequestBodyException
                {
                    Errors = errors
                };
            }

            var entity = new App
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                Type = model.Type,
                Developer = model.Developer
            };

            _repository.App.Add(entity);
            await _repository.CommitAsync();

            return entity.Id;
        }
    }
}