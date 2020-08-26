using asm1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace asm1.ViewModel
{
    public class TopicTrainer
    {
        public Topic Topic { get; set; }

        public IEnumerable<Trainer> Trainers { get; set; }
    }
}