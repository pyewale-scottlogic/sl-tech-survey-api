using Repository.Models;

namespace Repository.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(int EmployeeId);
        void CreateEmployee(Employee Employee);
        void UpdateEmployee(Employee Employee);
        void DeleteEmployee(Employee Employee);
    }
}
