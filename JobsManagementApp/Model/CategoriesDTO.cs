using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsManagementApp.Model
{
    public class CategoriesDTO
    {
        public string? name { get; set; }
        public CategoriesDTO()
        {

        }
        public CategoriesDTO( string name)
        {
            this.name = name;
        }
    }
}
