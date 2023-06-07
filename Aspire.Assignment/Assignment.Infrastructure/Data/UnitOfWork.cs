using Assignment.Contracts.Data;
using Assignment.Contracts.Data.Repositories;
using Assignment.Core.Data.Repositories;
using Assignment.Migrations;

namespace Assignment.Core.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AssignmentTaskDBContext _context;

        public UnitOfWork(AssignmentTaskDBContext context)
        {
            _context = context;
        }
        public IAppRepository App => new AppRepository(_context);

        public IUserRepository User => new UserRepository(_context);
        public IEmployeeRepository Employee=> new EmployeeRepository(_context);

        public IReferencetblRepository referencetbl=> new ReferencetblRepository(_context);
        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}