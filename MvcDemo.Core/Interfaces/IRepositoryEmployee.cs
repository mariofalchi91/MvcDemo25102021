using MvcDemo.Core.Models;

namespace MvcDemo.Core.Interfaces
{
    public interface IRepositoryEmployee:IRepository<Employee>
    {
        Employee GetEmployeeByCode(string code);
    }
}
