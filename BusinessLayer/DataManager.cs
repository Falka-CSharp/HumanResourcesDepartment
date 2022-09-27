using BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class DataManager
    {
        private IDepartments _depRepo { get; set; }
        private IEmployees _empRepo { get; set; }
        public DataManager(IDepartments depRepo, IEmployees empRepo)
        {
            _depRepo = depRepo;
            _empRepo = empRepo;
        }
        public IDepartments DepRepo
        {
            get { return _depRepo; }
        }
        public IEmployees EmpRepo
        {
            get { return _empRepo; }
        }
    }
}
