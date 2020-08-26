using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace asm1.Models
{
    public class TrainerStaff
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string UserId { get; set; }
        public string 123 { get; set; }
        public ApplicationUser User { get; set; }
    }
}