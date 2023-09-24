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
            var  emp =   await _context.Employees.AddAsync(employee);
            var emptoReturn = emp.Entity;
            await _context.SaveChangesAsync();
            return emptoReturn;
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

        public async Task<IEnumerable<Employee>> GetlPaginatedEmployeeAsync(int page = 1, int pageSize = 10)
        {
            var Employees = await _context.Employees.Include(l=>l.Addresses).ToListAsync();
            var totalItems = Employees.Count();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
            var paginatedItems = Employees.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return paginatedItems;

        }

        public async Task<Employee> updateEmployeeAsync(Employee employee)
        {
           var empolyee =  _context.Employees.Update(employee).Entity;
            await _context.SaveChangesAsync();
            return empolyee;
        }
        
       
    }
}
