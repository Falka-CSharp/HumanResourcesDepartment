using BusinessLayer;
using DataLayer.Entities;
using PresentationLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Services
{
    public class EmployeesService
    {
        private DataManager _dataManager;
        public EmployeesService(DataManager dataManager)
        {
            _dataManager = dataManager;
        }
        public EmployeeViewModel TransitEmployeeToView(int employeeId)
        {
            EmployeeViewModel vm = new EmployeeViewModel()
            {
                Employee = _dataManager.EmpRepo.GetEmployeeById(employeeId)
            };

            var dep_id = vm.Employee.DepartmentId;
            vm.DepartmentId = dep_id;
            return vm;
        }

        public EmployeeViewModel SaveEmployeeToDb(EmployeeViewModel vm)
        {
            Employee? emp = null;
            if (vm.Id != 0)
                emp = _dataManager.EmpRepo.GetEmployeeById(vm.Id);
            else
                emp = new Employee();

            emp.Name = vm.Employee.Name;
            emp.Position = vm.Employee.Position;
            emp.DepartmentId = vm.DepartmentId;

            _dataManager.EmpRepo.SaveEmployee(emp);
            return TransitEmployeeToView(emp.Id);
        }

        public EmployeeViewModel GetEmployeeViewModel(int employeeId)
        {
            var dbModel = _dataManager.EmpRepo.GetEmployeeById(employeeId);
            var editModel = new EmployeeViewModel()
            {
                Id = dbModel.Id,
                DepartmentId = dbModel.DepartmentId,
                Employee = dbModel
            };
            return editModel;
        }


        public EmployeeViewModel CreateNewEmployee(int departmentId)
        {
            return new EmployeeViewModel() { DepartmentId = departmentId };
        }
    }
}