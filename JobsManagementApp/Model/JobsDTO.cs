using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsManagementApp.Model
{
    public class JobsDTO
    {
        public int? id { get; set; }
        public int? dependency_id { get; set; }
        public string? dependency_name { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
        public string? category { get; set; }
        public string? start_date { get; set; }
        public string? due_date { get; set; }
        public string? end_date { get; set; }
        public int? required_hour { get; set; }
        public int? worked_hour { get; set; }
        public int? percent { get; set; }
        public string? stage { get; set; }
        public int? assignor_id { get; set; }
        public string? assignor_type { get; set; }
        public string? assignor_name { get; set; }
        public int? assignee_id { get; set; }
        public string? assignee_type { get; set; }
        public string? assignee_name { get; set; }
        public ObservableCollection<JobsDTO> Jobs { get; set; }
        public JobsDTO()
        {
            this.Jobs = new ObservableCollection<JobsDTO>();
        }
        public JobsDTO(int id_t, int dependency_id_t, string dependency_name_t, string name_t, string description_t
            , string category_t, string start_date_t, string due_date_t, string end_date_t, int required_hour_t
            , int worked_hour_t, int percent_t, string stage_t, int assignor_id_t, string assignor_type_t
            , string assignor_name_t, int assignee_id_t, string assignee_type_t, string assignee_name_t)
        {
            id = id_t;
            dependency_id = dependency_id_t;
            dependency_name = dependency_name_t;
            name = name_t;
            description = description_t;
            category = category_t;
            start_date = start_date_t;
            due_date = due_date_t;
            end_date = end_date_t;
            required_hour = required_hour_t;
            worked_hour = worked_hour_t;
            percent = percent_t;
            stage = stage_t;
            assignor_id = assignor_id_t;
            assignor_name = assignor_name_t;
            assignor_type = assignor_type_t;
            assignee_id = assignee_id_t;
            assignee_name = assignee_name_t;
            assignee_type = assignee_type_t;
            this.Jobs = new ObservableCollection<JobsDTO>();
        }
    }
}
