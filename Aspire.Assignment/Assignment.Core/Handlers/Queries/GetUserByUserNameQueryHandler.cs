using MediatR;
using Assignment.Contracts.DTO;
using Assignment.Contracts.Data;
using Assignment.Core.Exceptions;
using AutoMapper;

namespace Assignment.Providers.Handlers.Queries
{
    public class GetUserByUserNameQuery : IRequest<UserDTO>
    {
        public string UserName { get; }
        public GetUserByUserNameQuery(string userName)
        {
            UserName = userName;
        }
     
    }

    public class GetUserByUserNameQueryHandler : IRequestHandler<GetUserByUserNameQuery, UserDTO>
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public GetUserByUserNameQueryHandler(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UserDTO> Handle(GetUserByUserNameQuery request, CancellationToken cancellationToken)
        {
            var app = await Task.FromResult(_repository.User.Get(request.UserName));

            if (app == null)
            {
                throw new EntityNotFoundException($"No App found for Id {request.UserName}");
            }

            return _mapper.Map<UserDTO>(app);
        }
    }
}