
using Bai2.Models;

namespace Bai2.Repository
{
    public class MockEmployeeRepository:IEmployeeRepository
    {
        private List<Employee> _employeeList;
        
        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>
            {
                new Employee(){Id = 1, Name ="Alice", Department = "HR",Email = "alice@abc.com" },
                new Employee(){Id = 2, Name = "Henry", Department = "IT", Email = "henry@abc.com"},
                new Employee(){Id = 3, Name = "Jolly", Department = "IT", Email = "jolly@abc.com" }
            };
        }

        public IEnumerable<Employee> GetAllEmployees()
        {

            return _employeeList; 
        }
    }
}
