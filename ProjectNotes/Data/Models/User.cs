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
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        public string LastName { get; set; }
     
    }
}
