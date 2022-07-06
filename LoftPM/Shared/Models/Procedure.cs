using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoftPM.Shared.Models
{
    public class Procedure
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TeamMember? TeamMember { get; set; }
        public int? TeamMemberId { get; set; }
        public Project Project { get; set; }
        public int ProjectId { get; set; }
    }
}
