using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace LoftPM.Client.Services
{
    public class ProjectService : IProjectService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public ProjectService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }
        public List<Project> Projects { get ; set ; } = new List<Project>();
        public List<ProjectManager> ProjectManagers { get ; set ; } = new List<ProjectManager>();
        public List<TeamMember> TeamMembers { get ; set ; } = new List<TeamMember>();
        public List<Procedure> Procedures { get ; set ; } = new List<Procedure>();
        public List<Department> Departments { get ; set ; } = new List<Department>();

        public async Task CreateProject(Project project)
        {
            var result = await _http.PostAsJsonAsync("api/project", project);
            await SetProjects(result); ;
        }

        private async Task SetProjects(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Project>>();
            Projects = response;
            _navigationManager.NavigateTo("projects");
        }

        public async Task DeleteProject(int id)
        {
            var result = await _http.DeleteAsync($"api/project/{id}");
            await SetProjects(result);
        }

        public async Task GetProcedures()
        {
            var result = await _http.GetFromJsonAsync<List<Procedure>>("api/project/procedures");
            if (result != null)
                Procedures = result;
        }

        public async Task GetProjectManagers()
        {
            var result = await _http.GetFromJsonAsync<List<ProjectManager>>("api/project/projectManagers");
            if (result != null)
                ProjectManagers = result;
        }

        public async Task GetProjects()
        {
            var result = await _http.GetFromJsonAsync<List<Project>>("api/project/projects");
            if (result != null)
            {
                Projects = result;
            }
                
        }

        public async Task<Project> GetSingleProject(int id)
        {
            var result = await _http.GetFromJsonAsync<Project>($"api/project/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("Project  not found! ");
        }

        public async Task GetTeamMembers()
        {
            var result = await _http.GetFromJsonAsync<List<TeamMember>>("api/project/teamMembers");
            if (result != null)
                TeamMembers = result;
        }

        public async Task UpdateProject(Project project)
        {
            var result = await _http.PutAsJsonAsync($"api/project/{project.Id}", project);
            await SetProjects(result);
        }

        public async Task GetDepartments()
        {
            var result = await _http.GetFromJsonAsync<List<Department>>("api/projectManager/departments");
            if (result != null)
                Departments = result;
        }
    }
}
