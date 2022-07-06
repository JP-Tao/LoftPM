using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoftPM.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly DataContext _context;

        public ProjectController(DataContext context)
        {
            _context = context;
        }


        [HttpGet("projects")]
        public async Task<ActionResult<List<Project>>> GetProjects()
        {
            var projects = await _context.Projects
                //.Include(x => x.ProjectManager)
                //.Include(x => x.TeamMembers)
                //.Include(x => x.Procedures)
                .ToListAsync();
            return Ok(projects);

        }

        [HttpGet("departments")]
        public async Task<ActionResult<List<Department>>> GetDepartments()
        {
            var departments = await _context.Departments.ToListAsync();
            return Ok(departments);

        }

        [HttpGet("teamMembers")]
        public async Task<ActionResult<List<TeamMember>>> GetTeamMembers()
        {
            var teamMembers = await _context.TeamMembers.ToListAsync();
            return Ok(teamMembers);
        }

        [HttpGet("projectManagers")]
        public async Task<ActionResult<List<ProjectManager>>> GetProjectManagers()
        {
            var projectManagers = await _context.ProjectManagers.ToListAsync();
            return Ok(projectManagers);

        }

        [HttpGet("procedures")]
        public async Task<ActionResult<List<Procedure>>> GetProcedures()
        {
            var procedures = await _context.Procedures.ToListAsync();
            return Ok(procedures);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Project>>> GetSingleProject(int id)
        {
            var project = await _context.Projects
                //.Include(x => x.ProjectManager)
                //.Include(x => x.TeamMembers)
                //.Include(x => x.Procedures)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (project == null)
            {
                return NotFound("Sorry, Project doesn't exist here. :/");
            }

            return Ok(project);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<List<Project>>> CreateProject(Project project)
        {
            project.ProjectManager.Department = null;
            project.ProjectManager = null;
            project.TeamMembers = null;
            project.Procedures = null;
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();

            return (await GetDbProjects());

        }
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Project>>> UpdateProject(Project project, int id)
        {
            var dbProject = await _context.Projects
                //.Include(x => x.ProjectManager)
                //.Include(x => x.TeamMembers)
                //.Include(x => x.Procedures)
                .FirstOrDefaultAsync(sh => sh.Id == id);
            if (dbProject == null)
            {
                return NotFound("Sorry, Project doesn't exist here. :/");
            }
                
            dbProject.Name = project.Name;
            dbProject.ClientName = project.ClientName;
            dbProject.DateInitialised = project.DateInitialised;
            dbProject.DateToBeComplete = project.DateToBeComplete;
            dbProject.Status = project.Status;
            dbProject.ProjectManagerId = project.ProjectManagerId;


            await _context.SaveChangesAsync();

            return Ok(await GetDbProjects());

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Project>>> DeleteProject(int id)
        {
            var dbProject = await _context.Projects
                //.Include(x => x.ProjectManager)
                //.Include(x => x.TeamMembers)
                //.Include(x => x.Procedures)
                .FirstOrDefaultAsync(sh => sh.Id == id);
            if (dbProject == null)
            {
                return NotFound("Sorry, Project doesn't exist here. :/");
            }

            _context.Projects.Remove(dbProject);
            await _context.SaveChangesAsync();

            return Ok(await GetDbProjects());
        }

        private async Task<List<Project>> GetDbProjects()
        {
            return await _context.Projects.ToListAsync();
        }


    }
}
