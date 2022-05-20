using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class WorkingHour
    {
        [Key]
        public int WorkingHourId { get; set; }
        public string Day { get; set; }
        public string Hour { get; set; }
    }
}
