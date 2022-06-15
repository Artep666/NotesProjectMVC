using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjectNotes.Data.Models
{
    class User
    { 
        public User()
        {

        } 
        
     
        [Key]
        public int IdUser { get; set; }
        [Required]
        [MaxLength(20)]
        public string NameUser { get; set; }
        public string LastName { get; set; }
     
    }
}
