using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace P1.Models
{
    public class Project
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public string Client { get; set; }
        public string Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime Deadline { get; set; }
        public int User { get; set; }
        public string Status { get; set; }
    }
}
