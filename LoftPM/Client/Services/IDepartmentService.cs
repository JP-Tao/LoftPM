using LoftPM.Shared.Models;

namespace LoftPM.Client.Services
{
    public interface IDepartmentService
    {

        List<Department> Departments { get; set; }
        Task GetDepartments();
        Task<Department> GetSingleDepartment(int id);
        Task CreateDepartment(Department department);
        Task UpdateDepartment(Department department);
        Task DeleteDepartment(int id);  

    }
}
