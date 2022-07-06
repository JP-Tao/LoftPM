using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoftPM.Shared.Models
{
    public class ProjectManager
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public Project? Project { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
    }
}
