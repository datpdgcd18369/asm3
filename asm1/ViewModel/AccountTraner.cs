using asm1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace asm1.ViewModel
{
    public class AccountTraner
    {
        public Trainer Trainer { get; set; }

        public IEnumerable<ApplicationUser> Users { get; set; }
    }
}