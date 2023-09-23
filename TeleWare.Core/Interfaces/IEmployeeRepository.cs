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
        Task<Employee> DeleteEmployeeAsync(Employee employee);
        Task updateEmployeeAsync(Employee employee);
        Task<Employee> GetEmployeeByIdAsync(int Id);
    }
}
