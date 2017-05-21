using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skolprojekt.Models
{
    public class Student : Person
    {
        public Student()
        {
            Attendants = new List<Attendee>();
        }
        public virtual ICollection<Attendee> Attendants { get; set; }
    }
}
