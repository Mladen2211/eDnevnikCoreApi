using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDnevnik.Model
{
    public class Subject
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int? TeachingProfessor { get; set; }
        public bool? Deleted { get; set; }
        public bool? Active { get; set; }


        public virtual User TeachingProfessorNavigation { get; set; }
    }
}
