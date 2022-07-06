using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoftPM.Shared.Models
{
    public class TeamMember
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public List<Project>? Projects { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public Procedure? Procedure { get; set; }
    }
}
