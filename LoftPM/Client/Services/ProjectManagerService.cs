using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace LoftPM.Client.Services
{
    public class ProjectManagerService : IProjectManagerService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public ProjectManagerService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }
        public List<ProjectManager> ProjectManagers { get ; set ; } = new List<ProjectManager>();
        public List<Department> Departments { get; set; } = new List<Department>();
        public List<Project> Projects { get ; set ; } = new List<Project>();

        public async Task CreateProjectManager(ProjectManager projectManager)
        {
            var result = await _http.PostAsJsonAsync("api/projectManager", projectManager);
            await SetProjectManagers(result);
        }

        private async Task SetProjectManagers(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<ProjectManager>>();
            ProjectManagers = response;
            _navigationManager.NavigateTo("projectManagers");
        }

        public async Task DeleteProjectManager(int id)
        {
            var result = await _http.DeleteAsync($"api/projectManager/{id}");
            await SetProjectManagers(result);
        }

        public async Task GetProjectManagers()
        {
            var result = await _http.GetFromJsonAsync<List<ProjectManager>>("api/projectManager");
            if (result != null)
                ProjectManagers = result;
        }

        public async Task<ProjectManager> GetSingleProjectManager(int id)
        {
            var result = await _http.GetFromJsonAsync<ProjectManager>($"api/projectManager/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("Project Manager not found! ");
        }

        public async Task UpdateProjectManager(ProjectManager projectManager)
        {
            var result = await _http.PutAsJsonAsync($"api/projectManager/{projectManager.Id}", projectManager);
            await SetProjectManagers(result);
        }

        public async Task GetDepartments()
        {
            var result = await _http.GetFromJsonAsync<List<Department>>("api/projectManager/departments");
            if (result != null)
                Departments = result;
        }

        public async Task GetProjects()
        {
            var result = await _http.GetFromJsonAsync<List<Project>>("api/projectManager/projects");
            if (result != null)
                Projects = result;
        }
    }
}
