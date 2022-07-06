using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LoftPM.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly DataContext _context;

        public DepartmentController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Department>>> GetDepartments()
        {
            var departments = await _context.Departments.ToListAsync();
            return Ok(departments);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetSingleDepartment(int id)
        {
            var department = await _context.Departments
                .FirstOrDefaultAsync(x => x.Id == id);
            if (department == null)
            {
                return NotFound("Sorry, Department doesn't exist here. :/");
            }
            return Ok(department); 
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<List<Department>>> CreateDepartment(Department department)
        {
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();

            return Ok(await GetDbDepartments());

        }
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Department>>> UpdateDepartment(Department department, int id)
        {
            var dbDepartment = await _context.Departments
                .FirstOrDefaultAsync(sh => sh.Id == id);
            if (dbDepartment == null) 
            { 
                return NotFound("Sorry, Department doesn't exist here. :/");
            }

            dbDepartment.Name = department.Name;
            dbDepartment.City = department.City;
            dbDepartment.Telephone = department.Telephone;

            await _context.SaveChangesAsync();

            return Ok(await GetDbDepartments());

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Department>>> DeleteDepartment(int id)
        {
            var dbDepartment = await _context.Departments
                .FirstOrDefaultAsync(sh => sh.Id == id);
            if (dbDepartment == null)
            {
                return NotFound("Sorry, Department doesn't exist here. :/");
            }
               
            _context.Departments.Remove(dbDepartment);
            await _context.SaveChangesAsync();
            
            return Ok(await GetDbDepartments());
        }

        private async Task<List<Department>> GetDbDepartments()
        {
            return await _context.Departments.ToListAsync();
        }  

    }
}
