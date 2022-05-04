using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace Repository.Repositories
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(TechnologyStackContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await FindAll()
               .OrderBy(ow => ow.FirstName)
               .ToListAsync();
        }
        public async Task<Employee> GetEmployeeByIdAsync(int EmployeeId)
        {
            return await FindByCondition(Employee => Employee.EmployeeId.Equals(EmployeeId))
                .FirstOrDefaultAsync();
        }

        public void CreateEmployee(Employee Employee)
        {
            Create(Employee);
        }
        public void UpdateEmployee(Employee Employee)
        {
            Update(Employee);
        }
        public void DeleteEmployee(Employee Employee)
        {
            Delete(Employee);
        }
    }
}
