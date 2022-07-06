using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoftPM.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcedureController : ControllerBase
    {
        private readonly DataContext _context;

        public ProcedureController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Procedure>>> GetProcedures()
        {
            var procedures = await _context.Procedures
                //.Include(x => x.TeamMember)
                //.Include(x => x.Project)
                .ToListAsync();
            return Ok(procedures);
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

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Procedure>>> GetSingleProcedure(int id)
        {
            var procedure = await _context.Procedures
                //.Include(x => x.TeamMember)
                //.Include(x => x.Project)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (procedure == null)
                return NotFound("Sorry, Task doesn't exist here. :/");

            return Ok(procedure);
        }

        [HttpPost]
        public async Task<ActionResult<List<Procedure>>> CreateDepartment(Procedure procedure)
        {
            procedure.Project = null;
            procedure.TeamMember = null;
            _context.Procedures.Add(procedure);
            await _context.SaveChangesAsync();

            return (await GetDbProcedures());

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Procedure>>> UpdateProcedure(Procedure procedure, int id)
        {
            var dbProcedure = await _context.Procedures
                //.Include(x => x.Project)
                //.Include(x => x.TeamMember)
                .FirstOrDefaultAsync(sh => sh.Id == id);
            if (dbProcedure == null)
            {
                return NotFound("Sorry, Task doesn't exist here. :/");
            }

            dbProcedure.Name = procedure.Name;
            dbProcedure.TeamMemberId = procedure.TeamMemberId;
            dbProcedure.ProjectId = procedure.ProjectId;

            await _context.SaveChangesAsync();

            return Ok(await GetDbProcedures());

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Procedure>>> DeleteProcedure(int id)
        {
            var dbProcedure = await _context.Procedures
                 //.Include(x => x.Project)
                 //.Include(x => x.TeamMember)
                 .FirstOrDefaultAsync(sh => sh.Id == id);
            if (dbProcedure == null)
            {
                return NotFound("Sorry, Task doesn't exist here. :/");
            }

            _context.Procedures.Remove(dbProcedure);
            await _context.SaveChangesAsync();

            return Ok(await GetDbProcedures());
        }

        private async Task<List<Procedure>> GetDbProcedures()
        {
            return await _context.Procedures.ToListAsync();
        }

    }
}