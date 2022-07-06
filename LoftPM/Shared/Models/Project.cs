using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoftPM.Shared.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ClientName { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime DateInitialised { get; set; }
        public DateTime? DateToBeComplete { get; set; }
        public ProjectManager ProjectManager { get; set; }
        public int? ProjectManagerId { get; set; }
        public List<TeamMember>? TeamMembers { get; set; }
        public List<Procedure>? Procedures { get; set; }
    }
}
