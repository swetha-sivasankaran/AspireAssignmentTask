using Assignment.Contracts.Data.Entities;
using Assignment.Contracts.Data.Repositories;
using Assignment.Contracts.DTO;
using Assignment.Migrations;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Core.Data.Repositories
{
    public class ReferencetblRepository : Repository<ReferenceTbl>, IReferencetblRepository
    {
        public ReferencetblRepository(AssignmentTaskDBContext context) : base(context)
        {
        }
    }
}

