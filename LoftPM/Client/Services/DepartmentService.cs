using LoftPM.Shared.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace LoftPM.Client.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public DepartmentService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }

        public List<Department> Departments { get ; set ; } = new List<Department>();

        public async Task CreateDepartment(Department department)
        {
            var result = await _http.PostAsJsonAsync("api/department", department);
            await SetDepartments(result);
        }

        private async Task SetDepartments(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Department>>();
            Departments = response;
            _navigationManager.NavigateTo("departments");
        }

        public async Task DeleteDepartment(int id)
        {
            var result = await _http.DeleteAsync($"api/department/{id}");
            await SetDepartments(result);
        }

        public async Task GetDepartments()
        {
            var result = await _http.GetFromJsonAsync<List<Department>>("api/department");
            if (result != null)
                Departments = result;
        }

        public async Task<Department> GetSingleDepartment(int id)
        {
            var result = await _http.GetFromJsonAsync<Department>($"api/department/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("Department not found! ");
        }

        public async Task UpdateDepartment(Department department)
        {
            var result = await _http.PutAsJsonAsync($"api/department/{department.Id}", department);
            await SetDepartments(result);
        }
    }
}
