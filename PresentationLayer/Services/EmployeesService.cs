using BusinessLayer;
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


    }
}
