using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDVjezba.Models
{
    public class Faculty
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Adress { get; set; }
        public List<Student> Students { get; set; }
        public string LogoString { get; set; }
        public DateTime Date { get; set; }
    }
}
