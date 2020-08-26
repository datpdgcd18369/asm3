using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace asm1.Models
{
    public class Trainee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string TOEIC { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }

}