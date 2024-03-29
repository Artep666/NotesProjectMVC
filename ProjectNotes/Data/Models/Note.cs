﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjectNotes.Data.Models
{
   public class Note
    {
        public Note()
        {

        }


        public Note(string name, string description,int date) 
        {
            this.Name = name;
            this.Description = description;
            this.Date = date;

        }
        
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        public string Description { get; set; }
        public int Date { get; set; }

       

    }
}
