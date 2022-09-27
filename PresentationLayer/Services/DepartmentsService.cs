using BusinessLayer;
using DataLayer.Entities;
using PresentationLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Services
{
    public class DepartmentsService
    {
        private DataManager _dataManager;
        private EmployeesService _employeesService;

        public DepartmentsService(DataManager dataManager, EmployeesService employeesService)
        {
            _dataManager = dataManager;
            _employeesService = new EmployeesService(dataManager);
        }

        public DepartmentsViewModel TransitSingleDepartmentToView(int departmentId)
        {
            var dep = _dataManager.DepRepo.GetDepartmentById(departmentId, true);
            
            List<EmployeeViewModel> employeesList = new List<EmployeeViewModel>();
            foreach (var item in dep.Employees)
                employeesList.Add(_employeesService.TransitEmployeeToView(item.Id));

            DepartmentsViewModel vm = new DepartmentsViewModel()
            {
                Department = dep,
                Employees = employeesList
            };
            return vm;
        }

        public List<DepartmentsViewModel> TransitDirectoriesToView()
        {
            var deps = _dataManager.DepRepo.GetAllDepartments();
            List<DepartmentsViewModel> depsList = new List<DepartmentsViewModel>();
            foreach (var item in deps)
                depsList.Add(TransitSingleDepartmentToView(item.Id));
            return depsList;
        }

        public DepartmentsViewModel GetDepartmentEditMode(int departmentId = 0)
        {
            if (departmentId == 0)
            {
                var dep = _dataManager.DepRepo.GetDepartmentById(departmentId);
                var depVm = new DepartmentsViewModel()
                {
                    Id = dep.Id,
                };
                return depVm;
            }
            else
            {
                return new DepartmentsViewModel() { };
            }
        }

        public DepartmentsViewModel SaveDepartmentToDb(DepartmentsViewModel vm)
        {
            Department? dep = null;
            if (vm.Id != 0)
                dep = _dataManager.DepRepo.GetDepartmentById(vm.Id);
            else
                dep = new Department();

            _dataManager.DepRepo.SaveDepartment(dep);

            return TransitSingleDepartmentToView(dep.Id);
        }

        public DepartmentsViewModel CreateNewDepartmentModel()
        {
            return new DepartmentsViewModel() { };
        }

    }
}
