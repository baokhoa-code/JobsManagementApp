using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsManagementApp.Model
{
    public class CategoriesDTO
    {
        public int? id { get; set; }
        public string? name { get; set; }
        public CategoriesDTO()
        {

        }
        public CategoriesDTO(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}
