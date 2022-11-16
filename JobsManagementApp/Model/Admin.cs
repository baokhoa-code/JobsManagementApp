﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsManagementApp.Model
{
    public class Admin
    {
        public int? id { get; set; }
        public string? name { get; set; }
        public string? gender { get; set; }
        public string? dob { get; set; }
        public string? phone { get; set; }
        public string? address { get; set; }
        public string? nationality { get; set; }
        public string? organization { get; set; }
        public string? position { get; set; }
        public string? avatar { get; set; }
        public string? email { get; set; }
        public string? username { get; set; }
        public string? pass { get; set; }
        public string? question { get; set; }
        public string? answer { get; set; }
        public int? total_working_hour { get; set; }
        public Admin()
        { 
        }
        public Admin(int id_t, string name_t, string gender_t, string dob_t, string phone_t, 
            string address_t, string nationality_t, string organization_t, string position_t, string avatar_t, string email_t, string username_t, string pass_t, string question_t, string answer_t, int total_working_hour_t)
        {
            id= id_t;
            name= name_t;
            gender=gender_t;    
            dob= dob_t;
            phone=phone_t;
            address=address_t;
            nationality=nationality_t;
            organization = organization_t;
            position = position_t;
            avatar =avatar_t;    
            email=email_t;  
            username=username_t;
            pass=pass_t;
            question=question_t;
            answer=answer_t;
            total_working_hour = total_working_hour_t;
        }


    }
        
       
}
