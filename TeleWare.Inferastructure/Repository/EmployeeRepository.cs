using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleWareAssessment.Data;
using TeleWareAssessment.Entities;

namespace TeleWare.Core.Interfaces
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly TeleWareContext _context;

        public EmployeeRepository(TeleWareContext context)
        {
            _context = context;
        }
        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();

            return employee;
        }

        public async Task<Employee> DeleteEmployeeAsync(Employee employee)
        {
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return employee;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeeAsync()
        {
            return await _context.Employees.Include(l => l.Addresses).ToListAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int Id)
        {
            return await _context.Employees.Include(l=>l.Addresses).FirstOrDefaultAsync(l=>l.Id == Id);
        }

        public async Task updateEmployeeAsync(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }
        // delete all address
       
    }
}
