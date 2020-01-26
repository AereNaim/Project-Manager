using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace P1.Models
{
    public class Feedback
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int Author { get; set; }
        public string Category { get; set; }
        public string Project { get; set; }

        [DataType(DataType.Date)]
        public DateTime SubmiteDate { get; set; }
        public int User { get; set; }
    }
}
