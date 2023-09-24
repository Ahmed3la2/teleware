using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleWareAssessment.Entities;

namespace TeleWare.Core.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<Employee> AddEmployeeAsync(Employee employee);
        Task<IEnumerable<Employee>> GetAllEmployeeAsync();
        Task<IEnumerable<Employee>> GetlPaginatedEmployeeAsync(int page, int pageSize);
        Task<Employee> DeleteEmployeeAsync(Employee employee);
        Task<Employee> updateEmployeeAsync(Employee employee);
        Task<Employee> GetEmployeeByIdAsync(int Id);
    }
}
