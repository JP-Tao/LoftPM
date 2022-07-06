using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoftPM.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectManagerController : ControllerBase
    {
        private readonly DataContext _context;

        public ProjectManagerController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProjectManager>>> GetProjectManagers()
        {
            var projectManagers = await _context.ProjectManagers
                //.Include(x => x.Department)
                //.Include(x => x.Project)
                .ToListAsync();
            return Ok(projectManagers);

        }

        [HttpGet("departments")]
        public async Task<ActionResult<List<Department>>> GetDepartments()
        {
            var departments = await _context.Departments.ToListAsync();
            return Ok(departments);

        }

        [HttpGet("projects")]
        public async Task<ActionResult<List<Project>>> GetProjects()
        {
            var projects = await _context.Projects.ToListAsync();
            return Ok(projects);

        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectManager>> GetSingleProjectManager(int id)
        {
            var projectManager = await _context.ProjectManagers
                //.Include(x => x.Project)
                //.Include(x => x.Department)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (projectManager == null)
            {
                return NotFound("Sorry, ProjectManager doesn't exist here. :/");
            }
            return Ok(projectManager);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<List<ProjectManager>>> CreateProjectManager(ProjectManager projectManager)
        {
            projectManager.Department = null;
            projectManager.Project = null;
            _context.ProjectManagers.Add(projectManager);
            await _context.SaveChangesAsync();

            return Ok(await GetDbProjectManagers());

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<ProjectManager>>> UpdateProjectManager(ProjectManager projectManager, int id)
        {
            var dbProjectManager = await _context.ProjectManagers
                //.Include(x => x.Project)
                //.Include(x => x.Department)
                .FirstOrDefaultAsync(sh => sh.Id == id);
            if (dbProjectManager == null)
            {
                return NotFound("Sorry, Project Manager doesn't exist here. :/");
            }

            dbProjectManager.FirstName = projectManager.FirstName;
            dbProjectManager.LastName = projectManager.LastName;
            dbProjectManager.DepartmentId = projectManager.DepartmentId;

            await _context.SaveChangesAsync();

            return Ok(await GetDbProjectManagers());

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<ProjectManager>>> DeleteProjectManager(int id)
        {
            var dbProjectManager = await _context.ProjectManagers
                //.Include(x => x.Project)
                //.Include(x => x.Department)
                .FirstOrDefaultAsync(sh => sh.Id == id);
            if (dbProjectManager == null)
            {
                return NotFound("Sorry, Project Manager doesn't exist here. :/");
            }

            _context.ProjectManagers.Remove(dbProjectManager);
            await _context.SaveChangesAsync();

            return Ok(await GetDbProjectManagers());
        }

        private async Task<List<ProjectManager>> GetDbProjectManagers()
        {
            return await _context.ProjectManagers.ToListAsync();
        }


    }
}
