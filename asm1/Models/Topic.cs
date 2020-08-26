using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace asm1.Models
{
    public class Topic
    {
        [Key]
        [Required]

        public int  Id { get; set; }
        [Required(ErrorMessage = "Please enter Topic name")]

        public string Name { get; set; }
        public string Description { get; set; }

    
        public string TrainerId { get; set; }
        public Trainer Trainer { get; set; }

    }
}