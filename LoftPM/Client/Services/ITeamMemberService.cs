namespace LoftPM.Client.Services
{
    public interface ITeamMemberService
    {
        List<TeamMember> TeamMembers { get; set; }
        List<Department> Departments { get; set; }
        List<Project> Projects { get; set; }
        Task GetTeamMembers();
        Task GetDepartments();
        Task GetProjects();
        Task<TeamMember> GetSingleTeamMember(int id);
        Task CreateTeamMember(TeamMember teamMember);
        Task UpdateTeamMember(TeamMember teamMember);
        Task DeleteTeamMember(int id);
    }
}
