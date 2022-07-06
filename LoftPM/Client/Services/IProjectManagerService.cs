namespace LoftPM.Client.Services
{
    public interface IProjectManagerService
    {
        List<ProjectManager> ProjectManagers { get; set; }
        List<Department> Departments { get; set; }
        List<Project> Projects { get; set; }
        Task GetProjectManagers();
        Task GetDepartments();
        Task GetProjects();
        Task<ProjectManager> GetSingleProjectManager(int id);
        Task CreateProjectManager(ProjectManager projectManager);
        Task UpdateProjectManager(ProjectManager projectManager);
        Task DeleteProjectManager(int id);
    }
}
