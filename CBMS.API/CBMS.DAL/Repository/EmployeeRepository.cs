using CBMS.DAL.Data;
using CBMS.Entity.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CBMS.DAL.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        CityBusManagementDbContext _employeeDbContext;

        public EmployeeRepository(CityBusManagementDbContext employeeDbContext)
        {
            _employeeDbContext = employeeDbContext;
        }

        public void AddEmployeeDetails(Employee employeedetails)
        {
            _employeeDbContext.employee.Add(employeedetails);
            _employeeDbContext.SaveChanges();
        }

        public void DeleteEmployeeDetails(int empNo)
        {
            var employeedetails = _employeeDbContext.employee.Find(empNo);
            _employeeDbContext.employee.Remove(employeedetails);
            _employeeDbContext.SaveChanges();
        }

        public IEnumerable<Employee> GetEmployeeDetails()
        {
            return _employeeDbContext.employee.ToList();
        }

        public Employee GetEmployeeNo(int empNo)
        {
            return _employeeDbContext.employee.Find(empNo);

        }

        public void UpdateEmployeeDetails(Employee employeedetails)
        {
            _employeeDbContext.Entry(employeedetails).State = EntityState.Modified;
            _employeeDbContext.SaveChanges();
        }
    }
}