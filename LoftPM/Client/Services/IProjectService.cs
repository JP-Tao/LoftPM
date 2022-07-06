namespace LoftPM.Client.Services
{
    public interface IProjectService
    {
        List<Project> Projects { get; set; }
        List<ProjectManager> ProjectManagers { get; set; }
        List<Department> Departments { get; set; }
        List<TeamMember> TeamMembers { get; set; }
        List<Procedure> Procedures { get; set; }
        Task GetProjects();
        Task GetProjectManagers();
        Task GetDepartments();
        Task GetTeamMembers();
        Task GetProcedures();
        Task<Project> GetSingleProject(int id);
        Task CreateProject(Project project);
        Task UpdateProject(Project project);
        Task DeleteProject(int id);
    }
}
