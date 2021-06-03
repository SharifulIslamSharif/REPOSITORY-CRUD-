using Microsoft.EntityFrameworkCore;
using Repository_Test.Areas.Employees.Data;
using Repository_Test.Areas.Employees.Models;
using Repository_Test.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository_Test.Service
{
    public class EmployeeService : IEmployee
    {
        private readonly AppDbContext _context;

        public EmployeeService(AppDbContext context)
        {
            _context = context;
        }


        //Award Info

        public async Task<int> SaveEmployee(Employee employee)
        {
            if (employee.EmpId != 0)
                _context.Employees.Update(employee);
            else
                _context.Employees.Add(employee);

             await _context.SaveChangesAsync();
            return employee.EmpId;
        }

        public async Task<IEnumerable<Employee>> GetEmployee()
        {
            return await _context.Employees.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Employee>> GetById(int id)
        {
            return await _context.Employees.Where(x => x.EmpId == id).AsNoTracking().ToListAsync();
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task<bool> DeleteEmployeeById(int id)
        {
            _context.Employees.Remove(_context.Employees.Find(id));
            return 1 == await _context.SaveChangesAsync();
        }
    }
}
