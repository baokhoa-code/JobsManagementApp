using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsManagementApp.Model
{
    public class ReportsDTO
    {
        public int? id { get; set; }
        public int? job_id { get; set; }
        public string? job_name { get; set; }
        public string? tile { get; set; }
        public string? description { get; set; }
        public string? created_time { get; set; }
        public ReportsDTO()
        {

        }
        public ReportsDTO(int? id, int? job_id, string? job_name, string? tile, string? description, string? created_time)
        {
            this.id = id;
            this.job_id = job_id;
            this.job_name = job_name;
            this.tile = tile;
            this.description = description;
            this.created_time = created_time;
        }
        public ReportsDTO(ReportsDTO temp)
        {
            this.id = temp.id;
            this.job_id = temp.job_id;
            this.job_name = temp.job_name;
            this.tile = temp.tile;
            this.description = temp.description;
            this.created_time = temp.created_time;
        }
    }
}
