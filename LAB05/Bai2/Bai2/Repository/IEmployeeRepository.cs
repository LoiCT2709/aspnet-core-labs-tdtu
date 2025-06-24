using Bai2.Models;
namespace Bai2.Repository
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees();

    }
}
