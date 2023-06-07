using Assignment.Contracts.Data.Entities;
using Assignment.Contracts.Data.Repositories;
using Assignment.Contracts.DTO;
using Assignment.Migrations;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Core.Data.Repositories
{
    public class EmployeeRepository : Repository<EmployeeDetail>, IEmployeeRepository
    {
        public EmployeeRepository(AssignmentTaskDBContext context) : base(context)
        {
        }
    }
}

