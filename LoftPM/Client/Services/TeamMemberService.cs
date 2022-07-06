using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace LoftPM.Client.Services
{
    public class TeamMemberService : ITeamMemberService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public TeamMemberService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }
        public List<TeamMember> TeamMembers { get ; set ; } = new List<TeamMember>();
        public List<Department> Departments { get ; set ; } = new List<Department>();
        public List<Project> Projects { get ; set ; } = new List<Project>();

        public async Task CreateTeamMember(TeamMember teamMember)
        {
            var result = await _http.PostAsJsonAsync("api/teamMember", teamMember);
            await SetTeamMembers(result);
        }
        private async Task SetTeamMembers(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<TeamMember>>();
            TeamMembers = response;
            _navigationManager.NavigateTo("teamMembers");
        }

        public async Task DeleteTeamMember(int id)
        {
            var result = await _http.DeleteAsync($"api/teamMember/{id}");
            await SetTeamMembers(result);
        }

        public async Task GetTeamMembers()
        {
            var result = await _http.GetFromJsonAsync<List<TeamMember>>("api/teamMember");
            if (result != null)
                TeamMembers = result;
        }

        public async Task GetDepartments()
        {
            var result = await _http.GetFromJsonAsync<List<Department>>("api/teamMember/departments");
            if (result != null)
                Departments = result;
        }

        public async Task<TeamMember> GetSingleTeamMember(int id)
        {
            var result = await _http.GetFromJsonAsync<TeamMember>($"api/teamMember/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("Team Member not found! ");
        }

        public async Task UpdateTeamMember(TeamMember teamMember)
        {
            var result = await _http.PutAsJsonAsync($"api/teamMember/{teamMember.Id}", teamMember);
            await SetTeamMembers(result);
        }

        public async Task GetProjects()
        {
            var result = await _http.GetFromJsonAsync<List<Project>>("api/teamMember/projects");
            if (result != null)
                Projects = result;
        }
    }
}
