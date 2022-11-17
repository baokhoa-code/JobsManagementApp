using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsManagementApp.Model
{
    public class PositionsDTO
    {
        public string? organization { get; set; }
        public string? name { get; set; }
        public PositionsDTO()
        {

        }
        public PositionsDTO(string? organization, string? name)
        {
            this.organization = organization;
            this.name = name;
        }
    }
}
