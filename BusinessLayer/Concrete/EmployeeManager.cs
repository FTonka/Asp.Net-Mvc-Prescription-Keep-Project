using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class EmployeeManager:IEmployeeService
    {
        IEmployeeDal _employeeDal;
        public EmployeeManager(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;
        } 

        public void AddEmployee(Employee employee)
        {
            _employeeDal.Insert(employee);
        }



        public Employee GetById(int id)
        {
            return _employeeDal.GetById(id);
        }

        public void UpdateEmployee(Employee employee)
        {
         _employeeDal.Update(employee);   
        }
    }
}
