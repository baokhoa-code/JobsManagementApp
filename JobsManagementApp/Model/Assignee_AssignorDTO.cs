using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsManagementApp.Model
{
    public class Assignee_AssignorDTO
    {
        public int? id { get; set; }
        public string? type { get; set; }
        public string? name { get; set; }
        public Assignee_AssignorDTO()
        {

        }
        public Assignee_AssignorDTO(int id, string type, string name)
        {
            this.id = id;
            this.type = type;   
            this.name = name;
        }
    }
}
