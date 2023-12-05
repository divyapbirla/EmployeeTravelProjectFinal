using API_TravelProject.Models;

namespace API_TravelRequest.Repository
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployees();

         Task<Employee> AddEmployee(Employee emp);

        Task DeleteEmployee(int EmployeeID);
        Task UpdateEmployee(Employee emp, int EmployeeID);
        Task<Employee> CreateEmployee(Employee emp);
        Task<Employee> GetEmployeeById(int EmployeeID);
    }
}