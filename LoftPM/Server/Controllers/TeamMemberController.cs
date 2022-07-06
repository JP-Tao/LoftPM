using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoftPM.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamMemberController : ControllerBase
    {
        private readonly DataContext _context;

        public TeamMemberController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<TeamMember>>> GetTeamMembers()
        {
            var teamMembers = await _context.TeamMembers
                //.Include(x => x.Department)
                //.Include(x => x.Projects)
                .ToListAsync();
            return Ok(teamMembers);

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
        public async Task<ActionResult<TeamMember>> GetSingleTeamMember(int id)
        {
            var teamMember = await _context.TeamMembers
                //.Include(x => x.Projects)
                //.Include(x => x.Department)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (teamMember == null)
            {
                return NotFound("Sorry, Team Member doesn't exist here. :/");
            }
            return Ok(teamMember);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<List<TeamMember>>> CreateTeamMember(TeamMember teamMember)
        {
            teamMember.Department = null;
            teamMember.Projects = null;
            _context.TeamMembers.Add(teamMember);
            await _context.SaveChangesAsync();

            return Ok(await GetDbTeamMembers());

        }


        [HttpPut("{id}")]
        public async Task<ActionResult<List<TeamMember>>> UpdateTeamMember(TeamMember teamMember, int id)
        {
            var dbTeamMember = await _context.TeamMembers
                //.Include(x => x.Projects)
                //.Include(x => x.Department)
                .FirstOrDefaultAsync(sh => sh.Id == id);
            if (dbTeamMember == null)
            {
                return NotFound("Sorry,Team Member doesn't exist here. :/");
            }

            dbTeamMember.FirstName = teamMember.FirstName;
            dbTeamMember.LastName = teamMember.LastName;
            dbTeamMember.DepartmentId = teamMember.DepartmentId;

            await _context.SaveChangesAsync();

            return Ok(await GetDbTeamMembers());

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<TeamMember>>> DeleteTeamMember(int id)
        {
            var dbTeamMember = await _context.TeamMembers
                //.Include(x => x.Projects)
                //.Include(x => x.Department)
                .FirstOrDefaultAsync(sh => sh.Id == id);
            if (dbTeamMember == null)
            {
                return NotFound("Sorry, Team Member doesn't exist here. :/");
            }

            _context.TeamMembers.Remove(dbTeamMember);
            await _context.SaveChangesAsync();

            return Ok(await GetDbTeamMembers());
        }

        private async Task<List<TeamMember>> GetDbTeamMembers()
        {
            return await _context.TeamMembers.ToListAsync();
        }


    }
}
