using AutoMapper;
using Assignment.Contracts.Data;
using Assignment.Contracts.Data.Entities;
using Assignment.Contracts.DTO;
using MediatR;
using System.Linq;

namespace Assignment.Providers.Handlers.Queries
{
    
    public class GetAllReferenceTblQuery : IRequest<IEnumerable<ReferenceTblDTO>>
    {
        
    }

    public class GetAllReferenceTblQueryHandler : IRequestHandler<GetAllReferenceTblQuery, IEnumerable<ReferenceTblDTO>>
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public GetAllReferenceTblQueryHandler(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReferenceTblDTO>> Handle(GetAllReferenceTblQuery  request, CancellationToken cancellationToken)
        {   
            var result = await Task.FromResult(_repository.referencetbl.GetAll());            
            return _mapper.Map<IEnumerable<ReferenceTblDTO>>(result);
        }
    }
}