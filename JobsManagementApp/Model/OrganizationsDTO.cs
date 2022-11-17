using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsManagementApp.Model
{
    public class OrganizationsDTO
    {
        public string? name { get; set; }
        public OrganizationsDTO()
        {

        }
        public OrganizationsDTO(string? name)
        {
            this.name = name;
        }
    }
}
