using AutoMapper;
using Assignment.Contracts.Data;
using Assignment.Contracts.Data.Entities;
using Assignment.Contracts.DTO;
using MediatR;
using System.Linq;

namespace Assignment.Providers.Handlers.Queries
{
    public class GetAllAppQuery : IRequest<IEnumerable<AppDTO>>
    {
    }

    public class GetAllAppQueryHandler : IRequestHandler<GetAllAppQuery, IEnumerable<AppDTO>>
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public GetAllAppQueryHandler(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AppDTO>> Handle(GetAllAppQuery request, CancellationToken cancellationToken)
        {
            var entities = await Task.FromResult(_repository.App.GetAll());
            return _mapper.Map<IEnumerable<AppDTO>>(entities);
        }
    }
}